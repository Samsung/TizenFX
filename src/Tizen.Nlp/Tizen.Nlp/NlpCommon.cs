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
using Tizen.Applications.Messages;

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

namespace Tizen.Nlp
{
    public class NltkClass
    {
        public event EventHandler OnMsgRecieved;
        private message _msg;
        private message.notify_cb _noti = new message.notify_cb();
        string TAG = null;
        public enum Methods { word_tokenize, pos_tag, ne_chunk, lemmatize, lang_detect}
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
        public void Init(string service_id, string client_id)
        {
            TAG = client_id;
            Log.Debug(TAG, "msg construct started");
            _msg = new message(service_id);
            Log.Debug(TAG, "msg construct success");
            _noti.Received += OnReceived;
            Log.Debug(TAG, "notify callback be assigned");
            _msg.Connected += (sender, e) => {
                Log.Debug(TAG, "start to register");
                _msg.coregister(client_id, _noti);
                Log.Debug(TAG, "connected callback be called");
            };
            Log.Debug(TAG, "start to connect");
            _msg.Connect();
            Log.Debug(TAG, "wait to callback of onConnected");
        }


        public void Release()
        {
            _noti.Received -= OnReceived;
            _msg.unregister();
            _msg.Dispose();
            _msg = null;

        }

        //example call for pos_tag of nltk , and return an element of tuple under an element of list
        public void PosTag(string str)
        {
            MakeRequest("pos_tag", str);
        }

        //example call for ne_chunk of nltk , but because the ne_chunk return Tree struct ,so far ,we only convert it to List ,and return an element of tuple under an element of list
        public void NeChunk(string str)
        {
            MakeRequest("ne_chunk", str);
        }

        //example call for langdetect of langdetect , and return a string about language
        public void LangDetect(string str)
        {
            MakeRequest("langdetect", str);
        }

        public void Lemmatize(string str)
        {
            MakeRequest("lemmatize", str);
        }

        //example call for word_tokenize of nltk , and return an element of list
        public void WordTokenize(string str)
        {
            MakeRequest("word_tokenize", str);
        }

    }

    public class  CustomEventArg : EventArgs
    {

        public Bundle msg;

    }
}
