/*
* Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
*
* Licensed under the Apache License, Version 2.0 (the License);
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an AS IS BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections;
using Tizen;
using System.Threading.Tasks;
using Tizen.Applications;
using RpcPort.Message.Proxy;
using Tizen.Applications.RPCPort;

namespace Tizen.Nlp
{
    
    /// <summary>
    /// This class contains the methods and inner class related to the NLP processing.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public class NltkClass
    {
        /// <summary>
        /// An EventHandler to expose to external to recieve data from remote Nlp service  .
        /// </summary>
        public event EventHandler OnMsgRecieved;
        private message _msg;
        private message.notify_cb _noti = new message.notify_cb();
        private string TAG = null;

        private void MakeRequest(string cmd, string info)
        {
            Bundle b = new Bundle();
            b.AddItem("command", cmd);
            b.AddItem("info", info);
            _msg.send(b);
        }

        private void OnReceived(string sender, Bundle msg)
        {
            Log.Debug(TAG, "OnReceived ++");
            CustomEventArg e = new CustomEventArg();
            e.msg = new Bundle();
            e.msg = msg;
            OnMsgRecieved(sender, e);
            Log.Debug(TAG, "done");
        }

        /// <summary>
        /// An init session to connect remote tidl service with 2 input parameters.
        /// </summary>
        /// <param name="ServiceId">remote nlp service id.</param>
        /// <param name="ClientId">local nlp client app id.</param>
        /// <returns></returns>
        /// <since_tizen> 5 </since_tizen>
        public void Init(string ServiceId, string ClientId)
        {
            TAG = ClientId;
            Log.Debug(TAG, "msg construct started");
            _msg = new message(ServiceId);
            Log.Debug(TAG, "msg construct success");
            _noti.Received += OnReceived;
            Log.Debug(TAG, "notify callback be assigned");
            _msg.Connected += (sender, e) => {
                Log.Debug(TAG, "start to register");
                _msg.coregister(ClientId, _noti);
                Log.Debug(TAG, "connected callback be called");
            };
            Log.Debug(TAG, "start to connect");
            _msg.Connect();
            Log.Debug(TAG, "wait to callback of onConnected");
        }

        /// <summary>
        /// An release session to disconnect remote tidl service.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public void Release()
        {
            _noti.Received -= OnReceived;
            _msg.unregister();
            _msg.Dispose();
            _msg = null;

        }

        /// <summary>
        /// Send Pos of Tag request to remote tidl service with 1 input parameters.
        /// </summary>
        /// <param name="info">A sentence need to be processed.</param>
        /// <returns></returns>
        /// <since_tizen> 5 </since_tizen>
        public void PosTag(string info)
        {
            MakeRequest("pos_tag", info);
        }

        /// <summary>
        /// Send Named Entity recognition request to remote tidl service with 1 input parameters.
        /// </summary>
        /// <param name="info">A sentence need to be processed.</param>
        /// <returns></returns>
        /// <since_tizen> 5 </since_tizen>
        public void NeChunk(string info)
        {
            MakeRequest("ne_chunk", info);
        }

        /// <summary>
        /// Send language detect request to remote tidl service with 1 input parameters.
        /// </summary>
        /// <param name="info">A sentence need to be processed.</param>
        /// <returns></returns>
        /// <since_tizen> 5 </since_tizen>
        public void LangDetect(string info)
        {
            MakeRequest("langdetect", info);
        }

        /// <summary>
        /// Send Lemmatize request to remote tidl service with 1 input parameters.
        /// </summary>
        /// <param name="info">A sentence need to be processed.</param>
        /// <returns></returns>
        /// <since_tizen> 5 </since_tizen>
        public void Lemmatize(string info)
        {
            MakeRequest("lemmatize", info);
        }

        /// <summary>
        /// Send word tokenize request to remote tidl service with 1 input parameters.
        /// </summary>
        /// <param name="info">A sentence need to be processed.</param>
        /// <returns></returns>
        /// <since_tizen> 5 </since_tizen>
        public void WordTokenize(string info)
        {
            MakeRequest("word_tokenize", info);
        }

    }

    /// <summary>
    /// This custom class extend from EventArgs to obtain Bundle object.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public class  CustomEventArg : EventArgs
    {
        /// <summary>
        /// An Bundle type to carry an array struct return from tidl service.
        /// To check which nlp command be return by  msg.GetItem("command") 
        /// To get value by  msg.GetItem("return_tag") and cast the value to string []
        /// To get value by  msg.GetItem("return_token") and cast the value to string []
        /// </summary>
        public Bundle msg;

    }
}
