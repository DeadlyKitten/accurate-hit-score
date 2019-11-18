using IPA;
using UnityEngine.SceneManagement;
using IPALogger = IPA.Logging.Logger;

namespace Accurate_Hit_Scores
{
    public class Plugin : IBeatSaberPlugin
    {
        public void Init(IPALogger logger)
        {
            Logger.logger = logger;
        }

        public void OnApplicationStart() { }

        public void OnApplicationQuit() { }

        public void OnFixedUpdate() { }

        public void OnUpdate() { }

        public void OnActiveSceneChanged(Scene prevScene, Scene nextScene) { }

        public void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode) { }

        public void OnSceneUnloaded(Scene scene) { }
    }
}
