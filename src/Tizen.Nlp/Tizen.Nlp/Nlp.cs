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
using Tizen.Applications;

namespace Tizen.Nlp
{

    /// <summary>
    /// This class contains the methods and inner class related to the NLP processing.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public class Nlp
    {
        /// <summary>
        /// An EventHandler to expose to external to recieve data from remote Nlp service  .
        /// </summary>
        public event EventHandler<MessageReceivedEventArgs> MessageReceived;
        private Message _msg;
        private readonly Message.NotifyCb _noti = new Message.NotifyCb();
        private string _tag;


        private void MakeRequest(string cmd, string sentence)
        {
            Bundle b = new Bundle();
            b.AddItem("command", cmd);
            b.AddItem("info", sentence);
            _msg.Send(b);
        }

        private void OnReceived(string sender, Bundle msg)
        {
            Log.Debug(_tag, "OnReceived ++");
            MessageReceivedEventArgs e = new MessageReceivedEventArgs();
            e.Message = msg;
            MessageReceived?.Invoke(this, e);
            Log.Debug(_tag, "done");
        }

        /// <summary>
        /// An construct method  to connect remote tidl service with 2 input parameters.
        /// </summary>
        /// <param name="serviceId">remote nlp service id.</param>
        /// <param name="clientId">local nlp client app id.</param>
        /// <returns></returns>
        /// <since_tizen> 5 </since_tizen>
        public Nlp(string serviceId, string clientId)
        {
            _tag = clientId;
            Log.Debug(_tag, "msg construct started");
            _msg = new Message(serviceId);
            Log.Debug(_tag, "msg construct success");
            _noti.Received += OnReceived;
            Log.Debug(_tag, "notify callback be assigned");
            _msg.Connected += (sender, e) =>
            {
                Log.Debug(_tag, "start to register");
                _msg.CoRegister(clientId, _noti);
                Log.Debug(_tag, "connected callback be called");
            };
            Log.Debug(_tag, "start to connect");
            _msg.Connect();
            Log.Debug(_tag, "wait to callback of onConnected");
        }

        /// <summary>
        /// An release session to disconnect remote tidl service.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public void Release()
        {
            _noti.Received -= OnReceived;
            _msg.UnRegister();
            _msg.Dispose();
            _msg = null;

        }

        /// <summary>
        /// Send Pos of Tag request to remote tidl service with 1 input parameters.
        /// </summary>
        /// <param name="sentence">A sentence need to be processed.</param>
        /// <returns></returns>
        /// <since_tizen> 5 </since_tizen>
        public void PosTag(string sentence)
        {
            MakeRequest("pos_tag", sentence);
        }

        /// <summary>
        /// Send Named Entity recognition request to remote tidl service with 1 input parameters.
        /// </summary>
        /// <param name="sentence">A sentence need to be processed.</param>
        /// <returns></returns>
        /// <since_tizen> 5 </since_tizen>
        public void NeChunk(string sentence)
        {
            MakeRequest("ne_chunk", sentence);
        }

        /// <summary>
        /// Send language detect request to remote tidl service with 1 input parameters.
        /// </summary>
        /// <param name="sentence">A sentence need to be processed.</param>
        /// <returns></returns>
        /// <since_tizen> 5 </since_tizen>
        public void LanguageDetect(string sentence)
        {
            MakeRequest("langdetect", sentence);
        }

        /// <summary>
        /// Send Lemmatize request to remote tidl service with 1 input parameters.
        /// </summary>
        /// <param name="sentence">A sentence need to be processed.</param>
        /// <returns></returns>
        /// <since_tizen> 5 </since_tizen>
        public void Lemmatize(string sentence)
        {
            MakeRequest("lemmatize", sentence);
        }

        /// <summary>
        /// Send word tokenize request to remote tidl service with 1 input parameters.
        /// </summary>
        /// <param name="sentence">A sentence need to be processed.</param>
        /// <returns></returns>
        /// <since_tizen> 5 </since_tizen>
        public void WordTokenize(string sentence)
        {
            MakeRequest("word_tokenize", sentence);
        }

    }
}