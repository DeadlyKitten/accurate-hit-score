using CustomUI.GameplaySettings;
using Harmony;
using IPA;
using System.Reflection;
using UnityEngine.SceneManagement;
using IPALogger = IPA.Logging.Logger;

namespace Accurate_Hit_Scores
{
    public class Plugin : IBeatSaberPlugin
    {
        private static bool isEnabled;
        private static HarmonyInstance harmony;
        private static readonly string id = "com.steven.accurate.hit.scores";
        private static BS_Utils.Utilities.Config config;

        public void Init(IPALogger logger) => Logger.logger = logger;

        public void OnApplicationStart()
        {
            harmony = HarmonyInstance.Create(id);
            config = new BS_Utils.Utilities.Config("Accurate Hit Scores");
            isEnabled = config.GetBool("Settings", "Enabled", false, true);
        }

        public void OnApplicationQuit() { }

        public void OnFixedUpdate() { }

        public void OnUpdate() { }

        public void OnActiveSceneChanged(Scene prevScene, Scene nextScene)
        {
            if (nextScene.name == "GameCore" && isEnabled)
            {
                Logger.Log("Applying Harmony Patches");
                harmony.PatchAll(Assembly.GetExecutingAssembly());
            }
            else
            {
                if (harmony.HasAnyPatches(id))
                {
                    Logger.Log("Removing Harmony Patches");
                    harmony.UnpatchAll(id);
                }
            }
        }

        public void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
        {
            if (scene.name == "MenuCore") CreateUI();
        }

        public void OnSceneUnloaded(Scene scene) { }

        public static void CreateUI()
        {
            var enableToggle = GameplaySettingsUI.CreateToggleOption(GameplaySettingsPanels.PlayerSettingsRight, "Accurate Hit Score", "Apply Combo to Hit Scores", null, 0);
            enableToggle.GetValue = isEnabled;
            enableToggle.OnToggle += (value) =>
            {
                isEnabled = value;
                config.SetBool("Settings", "Enabled", value);
            };
        }

    }
}
