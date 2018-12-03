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
using Tizen.Applications;
using Tizen.Applications.RPCPort;

namespace Tizen.Nlp
{
    internal class Message : ProxyBase
    {
        public event EventHandler Connected;
        public event EventHandler Disconnected;
        public event EventHandler Rejected;

        private bool _online;
        private readonly string _appId = null;
        private readonly Object _lock = new Object();
        private readonly List<CallbackBase> _delegateList = new List<CallbackBase>();

        public abstract class CallbackBase
        {
            internal int Id;
            internal int SeqId;
            internal bool Once;
            private static volatile int _seqNum = 0;

            public string Tag => Id.ToString() + "::" + SeqId.ToString();

            protected CallbackBase(int delegateId, bool once)
            {
                Id = delegateId;
                SeqId = _seqNum++;
                Once = once;
            }

            internal virtual void OnReceivedEvent(Parcel p) { }

            internal static void Serialize(Parcel h, CallbackBase param)
            {
                h.WriteInt(param.Id);
                h.WriteInt(param.SeqId);
                h.WriteBool(param.Once);
            }

            internal static void Deserialize(Parcel h, CallbackBase param)
            {
                param.Id = h.ReadInt();
                param.SeqId = h.ReadInt();
                param.Once = h.ReadBool();
            }
        }

        public sealed class NotifyCb : CallbackBase
        {
            public NotifyCb(bool once = false) : base((int)DelegateId.NotifyCb, once)
            {
            }

            public delegate void Callback(string sender, Bundle msg);
            public event Callback Received;

            internal override void OnReceivedEvent(Parcel parcel)
            {
                string param1 = parcel.ReadString();
                Bundle param2 = parcel.ReadBundle();
                Received?.Invoke(param1, param2);
            }

        }

        private enum DelegateId
        {
            NotifyCb = 1,
        }

        private enum MethodId
        {
            Result = 0,
            Callback = 1,
            CoRegister = 2,
            UnRegister = 3,
            Send = 4,
        }

        protected override void OnConnectedEvent(string endPoint, string portName, Port port)
        {
            _online = true;
            Connected?.Invoke(this, null);
        }

        protected override void OnDisconnectedEvent(string endPoint, string portName)
        {
            _online = false;
            Disconnected?.Invoke(this, null);
        }

        protected override void OnRejectedEvent(string endPoint, string portName)
        {
            Rejected?.Invoke(this, null);
        }

        private void ProcessReceivedEvent(Parcel parcel)
        {
            int id = parcel.ReadInt();
            int seqId = parcel.ReadInt();
            bool once = parcel.ReadBool();

            foreach (var i in _delegateList)
            {
                if (i.Id == id && i.SeqId == seqId)
                {
                    i.OnReceivedEvent(parcel);
                    if (i.Once)
                        _delegateList.Remove(i);
                    break;
                }
            }
        }

        protected override void OnReceivedEvent(string endPoint, string portName)
        {
            Parcel parcelReceived;

            parcelReceived = new Parcel(CallbackPort);

            using (parcelReceived)
            {
                int cmd = parcelReceived.ReadInt();
                if (cmd != (int)MethodId.Callback)
                {
                    return;
                }

                ProcessReceivedEvent(parcelReceived);
            }
        }

        private void ConsumeCommand(out Parcel parcel, Port port)
        {
            do
            {
                var p = new Parcel(port);

                int cmd = p.ReadInt();
                if (cmd == (int)MethodId.Result)
                {
                    parcel = p;
                    return;
                }

                p.Dispose();
                parcel = null;
            } while (true);
        }

        public Message(string appId)
        {
            _appId = appId;
        }

        public void Connect()
        {
            Connect(_appId, "message");
        }

        void DisposeCallback(string tag)
        {
            foreach (var i in _delegateList)
            {
                if (i.Tag.Equals(tag))
                {
                    _delegateList.Remove(i);
                    return;
                }
            }
        }

        public int CoRegister(string name, NotifyCb cb)
        {
            if (!_online)
                throw new NotConnectedSocketException();

            using (Parcel p = new Parcel())
            {
                p.WriteInt((int)MethodId.CoRegister);
                p.WriteString(name);
                CallbackBase.Serialize(p, cb);

                Parcel parcelReceived;
                lock (_lock)
                {
                    _delegateList.Add(cb);

                    // Send
                    p.Send(Port);

                    // Receive
                    ConsumeCommand(out parcelReceived, Port);
                }
                if (parcelReceived == null)
                {
                    throw new InvalidProtocolException();
                }

                int ret = parcelReceived.ReadInt();
                parcelReceived.Dispose();
                return ret;
            }
        }

        public void UnRegister()
        {
            if (!_online)
                throw new NotConnectedSocketException();

            using (Parcel p = new Parcel())
            {
                p.WriteInt((int)MethodId.UnRegister);

                lock (_lock)
                {
                    // Send
                    p.Send(Port);

                }
            }
        }

        public int Send(Bundle msg)
        {
            if (!_online)
                throw new NotConnectedSocketException();

            using (Parcel p = new Parcel())
            {
                p.WriteInt((int)MethodId.Send);
                p.WriteBundle(msg);

                Parcel parcelReceived;
                lock (_lock)
                {
                    // Send
                    p.Send(Port);

                    // Receive
                    ConsumeCommand(out parcelReceived, Port);
                }
                if (parcelReceived == null)
                {
                    throw new InvalidProtocolException();
                }

                int ret = parcelReceived.ReadInt();
                parcelReceived.Dispose();
                return ret;
            }
        }
    }
}
