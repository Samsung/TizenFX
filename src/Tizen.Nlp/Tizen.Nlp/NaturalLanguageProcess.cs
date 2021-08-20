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
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Tizen.Applications;
using Tizen.Applications.RPCPort;


namespace Tizen.Nlp
{

    /// <summary>
    /// This class contains the methods in the NLP processing.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public class NaturalLanguageProcess : IDisposable
    {
        private Message _msg;
        private Message.NotifyCb _noti = new Message.NotifyCb();
        private const string ServiceId = "org.tizen.nlp.service";
        private const string LogTag = "tizen.nlp.client";
        private bool disposed = false;
        private int _requestIdPos = 0;
        private int _requestIdLang = 0;
        private int _requestIdNeChunk = 0;
        private int _requestIdWordTokenize = 0;
        private Task _connectionTask;
        private ConnectedState _connectionState = ConnectedState.Disconnected;

        private readonly Dictionary<int, PostagCallback> _mapsPosTag = new Dictionary<int, PostagCallback>();

        private readonly Dictionary<int, LangDetectCallback>
            _mapsLangDetect = new Dictionary<int, LangDetectCallback>();

        private readonly Dictionary<int, WordTokenizeCallback> _mapsWordTokenize =
            new Dictionary<int, WordTokenizeCallback>();

        private readonly Dictionary<int, NamedEntityRecognitionCallback> _mapsNamedEntity =
            new Dictionary<int, NamedEntityRecognitionCallback>();

        /// <summary>
        /// An construct method  to init local env of NLP .
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        /// <feature>
        /// http://tizen.org/feature/nlp
        /// </feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        public NaturalLanguageProcess()
        {
            _noti.Received += ResultReceived;
        }

        private delegate bool LangDetectCallback(MessageReceivedEventArgs e);

        private delegate bool WordTokenizeCallback(MessageReceivedEventArgs e);

        private delegate bool PostagCallback(MessageReceivedEventArgs e);

        private delegate bool NamedEntityRecognitionCallback(MessageReceivedEventArgs e);

        /// <summary>
        /// A connection status change event
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public event EventHandler Disconnected;
        private enum ConnectedState
        {
            Disconnected,
            Connecting,
            Connected
        }

        private void MakeRequest(string cmd, string sentence, int requestid)
        {
            if (_connectionState == ConnectedState.Connected)
            {
                using (Bundle b = new Bundle())
                {
                    b.AddItem("command", cmd);
                    b.AddItem("info", sentence);
                    b.AddItem("request_id", requestid.ToString());
                    _msg.Send(b);
                    b.Dispose();
                }
            }
            else if (_connectionState == ConnectedState.Connecting)
            {
                throw new InvalidOperationException("natural language service is connecting");
            }
            else
            {
                throw new InvalidOperationException("disconnected from natural language service");
            }
        }

        private void ResultReceived(string sender, Bundle msg)
        {
            Log.Debug(LogTag, "OnReceived ");
            MessageReceivedEventArgs e = new MessageReceivedEventArgs();
            int requestid = 0;
            Dictionary<string, string[]> result = new Dictionary<string, string[]>();
            if (msg.Contains("return_token"))
                result.Add("token", (string[])msg.GetItem("return_token"));

            if (msg.Contains("request_id"))
                e.RequestId = requestid = int.Parse((string)msg.GetItem("request_id"));
            else
                return;

            if (msg.Contains("command"))
            {
                if (msg.GetItem("command").Equals("word_tokenize"))
                {
                    e.Message = result;
                    if (_mapsWordTokenize.ContainsKey(requestid))
                    {
                        _mapsWordTokenize[requestid]?.Invoke(e);
                        _mapsWordTokenize.Remove(requestid);
                    }
                }
                else if (msg.GetItem("command").Equals("pos_tag"))
                {
                    result.Add("tag", (string[])msg.GetItem("return_tag"));
                    e.Message = result;
                    if (_mapsPosTag.ContainsKey(requestid))
                    {
                        _mapsPosTag[requestid]?.Invoke(e);
                        _mapsPosTag.Remove(requestid);
                    }
                }
                else if (msg.GetItem("command").Equals("ne_chunk"))
                {
                    result.Add("tag", (string[])msg.GetItem("return_tag"));
                    e.Message = result;
                    if (_mapsNamedEntity.ContainsKey(requestid))
                    {
                        _mapsNamedEntity[requestid]?.Invoke(e);
                        _mapsNamedEntity.Remove(requestid);
                    }
                }
                else if (msg.GetItem("command").Equals("langdetect"))
                {
                    e.Message = result;
                    if (_mapsLangDetect.ContainsKey(requestid))
                    {
                        _mapsLangDetect[requestid]?.Invoke(e);
                        _mapsLangDetect.Remove(requestid);
                    }
                }
            }
        }

        /// <summary>
        /// An async method  to connect remote service.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        /// <returns>A task representing the asynchronous connect operation.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the connect is rejected.</exception>
        public Task Connect()
        {
            if (_connectionState == ConnectedState.Connected)
            {
                return Task.CompletedTask;
            }
            else if (_connectionState == ConnectedState.Connecting)
            {

                return _connectionTask;
            }
            _connectionState = ConnectedState.Connecting;
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
            _msg = new Message(ServiceId);
            _msg.Disconnected += (s, e) =>
            {
                _connectionState = ConnectedState.Disconnected;
                Disconnected?.Invoke(this, e);
            };
            _msg.Connected += (sender, e) =>
            {
                Log.Debug(LogTag, "start to register");
                _msg.CoRegister(Application.Current.ApplicationInfo.ApplicationId, _noti);
                _connectionState = ConnectedState.Connected;
                tcs.SetResult(true);
            };
            _msg.Rejected += (sender, e) =>
            {
                _connectionState = ConnectedState.Disconnected;
                tcs.SetException(new InvalidOperationException("invalid id cause exception"));
            };
            _msg.Connect();
            return _connectionTask = tcs.Task;
        }

        /// <summary>
        /// A method to close message connection
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public void Close()
        {
            if (_connectionState == ConnectedState.Disconnected) return;
            _msg.UnRegister();
            _msg.Dispose();
            _msg = null;
            _connectionState = ConnectedState.Disconnected;
            _connectionTask.Dispose();
            _connectionTask = null;
        }


        private void MapClear()
        {
            _mapsWordTokenize.Clear();
            _mapsPosTag.Clear();
            _mapsNamedEntity.Clear();
            _mapsLangDetect.Clear();
        }

        /// <summary>
        /// A method to release resource of library
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <inheritdoc/>
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                Close();
                _noti.Received -= ResultReceived;
                _noti = null;
                MapClear();
            }
            disposed = true;
        }

        /// <summary>
        /// Send Pos of Tag request to remote tidl service with one parameters.
        /// </summary>
        /// <param name="sentence">A sentence need to be processed.</param>
        /// <returns>PosTagResult</returns>
        /// <since_tizen> 5 </since_tizen>
        public Task<PosTagResult> PosTagAsync(string sentence)
        {
            int id = _requestIdPos++;
            MakeRequest("pos_tag", sentence, id);
            var task = new TaskCompletionSource<PosTagResult>();
            _mapsPosTag[id] = (e) =>
            {
                PosTagResult pr = new PosTagResult();
                e.Message.TryGetValue("token", out string[] tokens);
                e.Message.TryGetValue("tag", out string[] tags);
                pr.Tokens = tokens;
                pr.Tags = tags;
                task.SetResult(pr);
                return true;
            };
            return task.Task;
        }

        /// <summary>
        /// Send Named Entity recognition request to remote tidl service with one parameters.
        /// </summary>
        /// <param name="sentence">A sentence need to be processed.</param>
        /// <returns>NamedEntityRecognitionResult</returns>
        /// <since_tizen> 5 </since_tizen>
        public Task<NamedEntityRecognitionResult> NamedEntityRecognitionAsync(string sentence)
        {
            int id = _requestIdNeChunk++;
            MakeRequest("ne_chunk", sentence, id);
            var task = new TaskCompletionSource<NamedEntityRecognitionResult>();
            _mapsNamedEntity[id] = (e) =>
            {
                NamedEntityRecognitionResult nr = new NamedEntityRecognitionResult();
                e.Message.TryGetValue("token", out string[] tokens);
                e.Message.TryGetValue("tag", out string[] tags);
                nr.Tokens = tokens;
                nr.Tags = tags;
                task.SetResult(nr);
                return true;
            };
            return task.Task;
        }

        /// <summary>
        /// Send language detect request to remote tidl service with one parameters.
        /// </summary>
        /// <param name="sentence">A sentence need to be processed.</param>
        /// <returns>LanguageDetectedResult</returns>
        /// <since_tizen> 5 </since_tizen>
        public Task<LanguageDetectedResult> LanguageDetectAsync(string sentence)
        {
            int id = _requestIdLang++;
            MakeRequest("langdetect", sentence, id);
            var task = new TaskCompletionSource<LanguageDetectedResult>();
            _mapsLangDetect[id] = (e) =>
            {
                LanguageDetectedResult lr = new LanguageDetectedResult();
                e.Message.TryGetValue("token", out string[] lang);
                if (lang != null) lr.Language = lang[0];
                task.SetResult(lr);
                return true;
            };
            return task.Task;
        }

        /// <summary>
        /// Send word tokenize request to remote tidl service with one parameters.
        /// </summary>
        /// <param name="sentence">A sentence need to be processed.</param>
        /// <returns>ProcessResult</returns>
        /// <since_tizen> 5 </since_tizen>
        public Task<WordTokenizeResult> WordTokenizeAsync(string sentence)
        {
            int id = _requestIdWordTokenize++;
            MakeRequest("word_tokenize", sentence, id);
            var task = new TaskCompletionSource<WordTokenizeResult>();
            _mapsWordTokenize[id] = (e) =>
            {
                WordTokenizeResult wr = new WordTokenizeResult();
                e.Message.TryGetValue("token", out string[] tokens);
                wr.Tokens = tokens;
                task.SetResult(wr);
                return true;
            };
            return task.Task;
        }
    }
}
