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

using System.Collections.Generic;
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
        private Message _msg;
        private readonly Message.NotifyCb _noti = new Message.NotifyCb();
        private readonly string _tag;
        private const string ServiceId = "org.tizen.nlp.service";
        private delegate bool LangDetectAsync(MessageReceivedEventArgs e);
        private delegate bool WordTokenizeAsync(MessageReceivedEventArgs e);
        private delegate bool PostagAsync(MessageReceivedEventArgs e);
        private delegate bool NamedEntityRecognitionAsync(MessageReceivedEventArgs e);
        private delegate bool LemmatizeAsync(MessageReceivedEventArgs e);

        /// <summary>
        /// This class contains result of language detected.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public class LanguageDetectedResult
        {
            public string Language { get; set; }
        }

        /// <summary>
        /// This class contains result of word tokenized.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public class WordTokenizeResult
        {
            public IList<string> Tokens { get; set; }
        }

        /// <summary>
        /// This class contains result of named entity recognition.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public class NamedEntityRecognitionResult
        {
            public IList<string> Tokens { get; set; }
            public IList<string> Tags { get; set; }
        }

        /// <summary>
        /// This class contains result of lemmatized.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public class LemmatizeResult
        {
            public string ActualWords { get; set; }
        }

        /// <summary>
        /// This class contains result of position tagged .
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public class PosTagResult
        {
            public IList<string> Tokens { get; set; }
            public IList<string> Tags { get; set; }
        }

        private LangDetectAsync _langdetectasync;
        private WordTokenizeAsync _wordtokenizeasync;
        private PostagAsync _postagasync;
        private LemmatizeAsync _Lemmatizeasync;
        private NamedEntityRecognitionAsync _namedentityrecognitionasyncasync;
        private void MakeRequest(string cmd, string sentence)
        {
            Bundle b = new Bundle();
            b.AddItem("command", cmd);
            b.AddItem("info", sentence);
            _msg.Send(b);
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
                _wordtokenizeasync?.Invoke(e);
            }
            else if (msg.GetItem("command").Equals("pos_tag"))
            {
                result.Add("token", (string[])msg.GetItem("return_token"));
                result.Add("tag", (string[])msg.GetItem("return_tag"));
                e.Message = result;
                _postagasync?.Invoke(e);
            }
            else if (msg.GetItem("command").Equals("ne_chunk"))
            {
                result.Add("token", (string[])msg.GetItem("return_token"));
                result.Add("tag", (string[])msg.GetItem("return_tag"));
                e.Message = result;
                _namedentityrecognitionasyncasync?.Invoke(e);
            }
            else if (msg.GetItem("command").Equals("lemmatize"))
            {
                result.Add("token", (string[])msg.GetItem("return_token"));
                e.Message = result;
                _Lemmatizeasync?.Invoke(e);
            }
            else if (msg.GetItem("command").Equals("langdetect"))
            {
                result.Add("token", (string[])msg.GetItem("return_token"));
                e.Message = result;
                _langdetectasync.Invoke(e);
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
        /// <since_tizen> 5 </since_tizen>
        public NaturalLanguageProcess()
        {
            _tag = Application.Current.ApplicationInfo.ApplicationId;
            Log.Debug(_tag, "msg construct started");
            _msg = new Message(ServiceId);
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
        /// <returns>PosTagResult</returns>
        /// <since_tizen> 5 </since_tizen>
        public Task<PosTagResult> PosTagAsyncTask(string sentence)
        {
            MakeRequest("pos_tag", sentence);
            var task = new TaskCompletionSource<PosTagResult>();
            _postagasync = (e) =>
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
        public Task<NamedEntityRecognitionResult> NamedEntityRecognitionAsyncTask(string sentence)
        {
            MakeRequest("ne_chunk", sentence);
            var task = new TaskCompletionSource<NamedEntityRecognitionResult>();
            _namedentityrecognitionasyncasync = (e) =>
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
        public Task<LanguageDetectedResult> LanguageDetectAsyncTask(string sentence)
        {
            MakeRequest("langdetect", sentence);
            var task = new TaskCompletionSource<LanguageDetectedResult>();
            _langdetectasync = (e) =>
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
        /// Send Lemmatize request to remote tidl service with one parameters.
        /// </summary>
        /// <param name="sentence">A sentence need to be processed.</param>
        /// <returns>ProcessResult</returns>
        /// <since_tizen> 5 </since_tizen>
        public Task<LemmatizeResult> LemmatizeaAsyncTask(string sentence)
        {
            MakeRequest("lemmatize", sentence);
            var task = new TaskCompletionSource<LemmatizeResult>();
            _Lemmatizeasync = (e) =>
            {
                LemmatizeResult mr = new LemmatizeResult();
                e.Message.TryGetValue("token", out string[] tokens);
                if (tokens != null) mr.ActualWords = tokens[0];
                task.SetResult(mr);
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
        public Task<WordTokenizeResult> WordTokenizeAsyncTask(string sentence)
        {
            MakeRequest("word_tokenize", sentence);
            var task = new TaskCompletionSource<WordTokenizeResult>();
            _wordtokenizeasync = (e) =>
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