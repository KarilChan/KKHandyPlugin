using BepInEx;
using KKAPI.Chara;
using KKAPI.MainGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KKAPI.Studio;
using UnityEngine.SceneManagement;

namespace KKHandy
{
    [BepInPlugin(GUID, PluginName, Version)]
    [BepInDependency(KKAPI.KoikatuAPI.GUID, KKAPI.KoikatuAPI.VersionConst)]
    [BepInProcess("Koikatu")]
    [BepInProcess("KoikatuVR")]
    public partial class HandySync: BaseUnityPlugin
    {
        public const string PluginName = "Koikatsu Handy Sync";
        public const string GUID = "karil.handysync";
        public const string Version = "0.9.0.0";

        private void Awake()
        {
            Logger.LogDebug("Awake");
            GameAPI.RegisterExtraBehaviour<HandySyncController>(GUID);
        }

        private void Start()
        {
            Logger.LogDebug("Start");
            BindConfig();
            if (StudioAPI.InsideStudio)
            {
                Logger.LogDebug("Inside studio, returning");
                return;
            }

            Hooks.InstallHooks();
        }
    }
}
