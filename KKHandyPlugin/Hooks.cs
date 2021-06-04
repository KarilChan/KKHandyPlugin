using BepInEx.Harmony;
using KKAPI.Studio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KKHandy
{
    internal static partial class Hooks
    {
        public static void InstallHooks()
        {
            if (StudioAPI.InsideStudio)
            {
                UnityEngine.Debug.Log("Inside studio, not installing hooks");
                return;
            }
            HarmonyLib.Harmony.CreateAndPatchAll(typeof(HSceneTriggers));
        }

        private static HandySyncController GetController()
        {
            return UnityEngine.Object.FindObjectOfType<HandySyncController>();
        }
    }
}
