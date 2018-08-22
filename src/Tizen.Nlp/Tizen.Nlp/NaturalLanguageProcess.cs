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
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Tizen.Applications;

namespace Tizen.Nlp
{

    /// <summary>
    /// This class contains the methods and inner class related to the NLP processing.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public class NaturalLanguageProcess
    {
        /// <summary>
        /// An EventHandler to receive data after wordtokenize processing.
        /// </summary>
        /// <remarks>
        /// if this succeeds, the object contain Key/Pari about Nlp will be received.
        /// and you can use TryGetValue() with the Key "token" or "tag" to get a array of string for access,
        /// </remarks>
        public event EventHandler<MessageReceivedEventArgs> WordTokenizeResultReceived;
        /// <summary>
        /// An EventHandler to recieve data after the pos of tag processing.
        /// </summary>
        /// <remarks>
        /// if this succeeds, the object contain Key/Pari about Nlp will be received.
        /// and you can use TryGetValue() with the Key "token" or "tag" to get a array of string for access,
        /// </remarks>
        public event EventHandler<MessageReceivedEventArgs> PosTagResultReceived;
        /// <summary>
        /// An EventHandler to recieve data after named entity recognition processing.
        /// </summary>
        /// <remarks>
        /// if this succeeds, the object contain Key/Pari about Nlp will be received.
        /// and you can use TryGetValue() with the Key "token" or "tag" to get a array of string for access,
        /// </remarks>
        public event EventHandler<MessageReceivedEventArgs> NamedEntityRecognitionResultReceived;
        /// <summary>
        /// An EventHandler to recieve data after lemmatize processing.
        /// </summary>
        /// <remarks>
        /// if this succeeds, the object contain Key/Pari about Nlp will be received.
        /// and you can use TryGetValue() with the Key "token" or "tag" to get a array of string for access,
        /// </remarks>
        public event EventHandler<MessageReceivedEventArgs> LemmatizeResultReceived;
        /// <summary>
        /// An EventHandler to recieve data after language detect processing.
        /// </summary>
        /// <remarks>
        /// if this succeeds, the object contain Key/Pari about Nlp will be received.
        /// and you can use TryGetValue() with the Key "token" or "tag" to get a array of string for access,
        /// </remarks>
        public event EventHandler<MessageReceivedEventArgs> LanguageDetectResultReceived;
        private Message _msg;
        private readonly Message.NotifyCb _noti = new Message.NotifyCb();
        private string _tag;
        private const string SERVICE_ID = "org.tizen.nlp.service";

        /// <summary>
        /// The enum type of the message be sent.
        /// </summary>
        public enum ProcessResult
        {
            /// <summary>
            ///  Unsuccess
            /// </summary>
            ProcessError = -1,
            /// <summary>
            /// Success
            /// </summary>
            ProcessSuccess = 0
        }

        private ProcessResult MakeRequest(string cmd, string sentence)
        {
            Bundle b = new Bundle();
            b.AddItem("command", cmd);
            b.AddItem("info", sentence);
            if (_msg.Send(b) != 0)
            {
                return ProcessResult.ProcessError;
            }
            else
            {
                return ProcessResult.ProcessSuccess;
            }
        }

        private void ResultReceived(string sender, Bundle msg)
        {
            Log.Debug(_tag, "OnReceived ++");
            MessageReceivedEventArgs e = new MessageReceivedEventArgs();
            Dictionary<string, string[]> result = new Dictionary<string, string[]>();
            if (msg.GetItem("command").Equals("word_tokenize"))
            {
                result.Add("token", (string[])msg.GetItem("return_token"));
                e.Message = result;
                WordTokenizeResultReceived?.Invoke(this, e);
            }
            else if (msg.GetItem("command").Equals("pos_tag"))
            {
                result.Add("token", (string[])msg.GetItem("return_token"));
                result.Add("tag", (string[])msg.GetItem("return_tag"));
                e.Message = result;
                PosTagResultReceived?.Invoke(this, e);
            }
            else if (msg.GetItem("command").Equals("ne_chunk"))
            {
                result.Add("token", (string[])msg.GetItem("return_token"));
                result.Add("tag", (string[])msg.GetItem("return_tag"));
                e.Message = result;
                NamedEntityRecognitionResultReceived?.Invoke(this, e);
            }
            else if (msg.GetItem("command").Equals("lemmatize"))
            {
                result.Add("token", (string[])msg.GetItem("return_token"));
                e.Message = result;
                LemmatizeResultReceived?.Invoke(this, e);
            }
            else if (msg.GetItem("command").Equals("langdetect"))
            {
                result.Add("token", (string[])msg.GetItem("return_token"));
                e.Message = result;
                LanguageDetectResultReceived?.Invoke(this, e);
            }
            else
            {
                return;
            }
            Log.Debug(_tag, "done");
        }

        /// <summary>
        /// An construct method  to connect remote tidl service.
        /// </summary>
        /// <returns></returns>
        /// <since_tizen> 5 </since_tizen>
        public NaturalLanguageProcess()
        {
            _tag = Application.Current.ApplicationInfo.ApplicationId;
            Log.Debug(_tag, "msg construct started");
            _msg = new Message(SERVICE_ID);
            Log.Debug(_tag, "msg construct success");
            _noti.Received += ResultReceived;
            Log.Debug(_tag, "notify callback be assigned");
            _msg.Connected += (sender, e) =>
            {
                Log.Debug(_tag, "start to register");
                _msg.CoRegister(Application.Current.ApplicationInfo.ApplicationId, _noti);
                Log.Debug(_tag, "connected callback be called");
            };
            _msg.Rejected += (sender, e) =>
            {
                Log.Debug(_tag, "rejected callback be called");
            };
            _msg.Disconnected += (sender, e) =>
            {
                Log.Debug(_tag, "disconnected callback be called");
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
            _noti.Received -= ResultReceived;
            _msg.UnRegister();
            _msg.Dispose();
            _msg = null;

        }

        /// <summary>
        /// Send Pos of Tag request to remote tidl service with one parameters.
        /// </summary>
        /// <param name="sentence">A sentence need to be processed.</param>
        /// <returns>ProcessResult</returns>
        /// <since_tizen> 5 </since_tizen>
        public ProcessResult PosTag(string sentence)
        {
            return MakeRequest("pos_tag", sentence);
        }

        /// <summary>
        /// Send Named Entity recognition request to remote tidl service with one parameters.
        /// </summary>
        /// <param name="sentence">A sentence need to be processed.</param>
        /// <returns>ProcessResult</returns>
        /// <since_tizen> 5 </since_tizen>
        public ProcessResult NamedEntityRecognition(string sentence)
        {
            return MakeRequest("ne_chunk", sentence);
        }

        /// <summary>
        /// Send language detect request to remote tidl service with one parameters.
        /// </summary>
        /// <param name="sentence">A sentence need to be processed.</param>
        /// <returns>ProcessResult</returns>
        /// <since_tizen> 5 </since_tizen>
        public ProcessResult LanguageDetect(string sentence)
        {
            return MakeRequest("langdetect", sentence);
        }

        /// <summary>
        /// Send Lemmatize request to remote tidl service with one parameters.
        /// </summary>
        /// <param name="sentence">A sentence need to be processed.</param>
        /// <returns>ProcessResult</returns>
        /// <since_tizen> 5 </since_tizen>
        public ProcessResult Lemmatize(string sentence)
        {
            return MakeRequest("lemmatize", sentence);
        }

        /// <summary>
        /// Send word tokenize request to remote tidl service with one parameters.
        /// </summary>
        /// <param name="sentence">A sentence need to be processed.</param>
        /// <returns>ProcessResult</returns>
        /// <since_tizen> 5 </since_tizen>
        public ProcessResult WordTokenize(string sentence)
        {
            return MakeRequest("word_tokenize", sentence);
        }

    }
}