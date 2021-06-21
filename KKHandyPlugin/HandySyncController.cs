using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using KKAPI;
using KKAPI.MainGame;
using KKAPI.Chara;
using KKAPI.Maker;
using KKAPI.Studio;
using UnityEngine;
using KKAPI.Utilities;

namespace KKHandy
{
    class HandySyncController : GameCustomFunctionController
    {

        private const int DebounceLoopMs = 50;
        private const int DebounceSpeedChgMs = 50;

        private long LastSpeedChg = HandySyncUtils.GetTimestamp();

        private float LastSpeedMulti = -1;
        private const float SpeedChgThreshold = 0.1f;

        private static HSprite HSpriteRef;

        private static System.Timers.Timer LoopTimer;

        public HandySyncController()
        {
            SetTimer();
        }

        public void HandlePause()
        {
            LoopTimer.Stop();
            new HandySyncClient().GetStop();
        }

        protected override void OnEndH(HSceneProc proc, bool freeH)
        {
            HandlePause();
        }


        public void OnInitHeroine(ref HSprite hSprite)
        {
            HSpriteRef = hSprite;
            new HandySyncClient().PostNewPose(hSprite);
            LoopTimer.Start();
        }

        private static void OnLoop(System.Object source, ElapsedEventArgs e)
        {
            if (null != HSpriteRef)
            {
                new HandySyncClient().PostLoop(HSpriteRef);
            }
        }

        private static void SetTimer()
        {
            LoopTimer = new Timer(DebounceLoopMs);
            LoopTimer.Elapsed += OnLoop;
            LoopTimer.AutoReset = true;
            LoopTimer.Enabled = true;
        }
        

        private bool ThrottleSpeedChg(AnimatorStateInfo state)
        {
            if ((state.speedMultiplier - LastSpeedMulti) > SpeedChgThreshold)
            {
                LastSpeedMulti = state.speedMultiplier;
                return false;
            } else
            {
                return true;
            }
        }

        public void OnSpeedChange(HFlag hFlag)
        {
            if (ThrottleSpeedChg(hFlag.GetLeadingHeroine().chaCtrl.getAnimatorStateInfo(0)))
            {
                return;
            }
            new HandySyncClient().PostSpeedChg(hFlag);
        }
    }
}
