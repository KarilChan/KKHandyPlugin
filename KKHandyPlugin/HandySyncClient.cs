using RestSharp;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using UnityEngine;
using KKHandy.PostModels;
using KKAPI.Utilities;

namespace KKHandy
{
    class HandySyncClient
    {

        private const string LOCALHOST = "127.0.0.1";

        private readonly RestClient Client;

        public HandySyncClient()
        {
            Client = GetClient();
        }

        private static RestClient GetClient()
        {
            return new RestClient($"http://{LOCALHOST}:{HandySync.ConfigServerPort.Value}");
        }


        private void Get(string Route)
        {
            var request = new RestRequest(Route, Method.GET);
            Client.ExecuteAsync(request, response => {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    HandlePostError(response);
                }
            });
        }

        public void GetStop()
        {
            Get("stop");
        }


        /// <summary>
        /// Post a JSON stringified PostModel to the plugin server
        /// </summary>
        private void Post(PostModel Model, string Route)
        {
            var request = new RestRequest(Route, Method.POST) {
                RequestFormat = DataFormat.Json 
            }; 
            request.AddBody(Model);
            Client.ExecuteAsync(request, response => {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    HandlePostError(response);
                }
            });
        }

        public void PostSpeedChg(HFlag hFlag)
        {
            Post(new LoopPostModel
            {
                animState = hFlag.nowAnimStateName,
                stateInfo = hFlag.GetLeadingHeroine().chaCtrl.getAnimatorStateInfo(0)
            }, "speedChg");
        }

        public void PostNewPose(HSprite hSprite)
        {
            Post(new NewPosePostModel {
                nameAnimation = hSprite.flags.nowAnimationInfo.nameAnimation
            }, "newPose");
        }

        public void PostLoop(HSprite hSprite)
        {
            Post(new LoopPostModel {
                animState = hSprite.flags.nowAnimStateName,
                stateInfo = hSprite.flags.GetLeadingHeroine().chaCtrl.getAnimatorStateInfo(0),
                speed = hSprite.flags.speed
            }, "loop");
        }

        private void HandlePostError(IRestResponse response)
        {
            if (response.Content.Length > 0)
            {
                // reached server and returned something
                UnityEngine.Debug.LogError($"{response.Content}");
            } else
            {
                // request never reached the server
                throw response.ErrorException;
            }
        }
    }
}
