using HarmonyLib;
using UnityEngine;

namespace KKHandy
{
    internal static partial class Hooks
    {
        private static class HSceneTriggers
        {
            [HarmonyPostfix]
            [HarmonyPatch(typeof(HSprite), nameof(HSprite.InitHeroine))]
            public static void InitHeroine(HSprite __instance)
            {
                GetController()?.OnInitHeroine(ref __instance);
            }

            [HarmonyPostfix]
            [HarmonyPatch(typeof(HSprite), nameof(HSprite.OnChangePlaySelect))]
            public static void OnChangePlaySelect(HSprite __instance)
            {
                GetController()?.HandlePause();
            }

            [HarmonyPostfix]
            [HarmonyPatch(typeof(HFlag), nameof(HFlag.SpeedUpClick))]
            public static void SpeedUpClick(HFlag __instance)
            {
                GetController()?.OnSpeedChange(__instance);
            }

        }
    }
}
