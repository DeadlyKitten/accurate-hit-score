using Harmony;
using UnityEngine;
using System.Linq;

namespace Accurate_Hit_Scores.Patches
{
    [HarmonyPatch(typeof(FlyingScoreEffect))]
    [HarmonyPatch("GetScoreText")]
    class FlyingScoreEffect_GetScoreText
    {
        private static bool Prefix(int score, ref string __result)
        {
            if (_scoreController == null) _scoreController = Resources.FindObjectsOfTypeAll<ScoreController>().FirstOrDefault();
            __result = (score * _scoreController.multiplierWithFever).ToString(); 

            return false;
        }

        private static ScoreController _scoreController;
    }
}
