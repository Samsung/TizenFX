/*
* Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Collections.ObjectModel;

namespace Tizen.Messaging.Messages
{
    /// <summary>
    /// A class to represent all messages.
    /// </summary>
    public abstract class Message : IDisposable
    {
        protected IntPtr _messageHandle = IntPtr.Zero;
        private bool disposed = false;

        private MessagesAddress _from = null;
        protected ICollection<MessagesAddress> _to = new Collection<MessagesAddress>();
        protected ICollection<MessagesAddress> _cc = new Collection<MessagesAddress>();
        protected ICollection<MessagesAddress> _bcc = new Collection<MessagesAddress>();

        protected Message(MessageType type)
        {
            int ret = Interop.Messages.CreateMessage((int)type, out _messageHandle);
            if (ret != (int)MessagesError.None)
            {
                Log.Error(Globals.LogTag, "Failed to create message handle, Error - " + (MessagesError)ret);
                MessagesErrorFactory.ThrowMessagesException(ret);
            }
        }

        protected Message(IntPtr messageHandle)
        {
            _messageHandle = messageHandle;
            GetAllAddresses();
        }

        internal void FillHandle()
        {
            SetAddresses();
            (this as MmsMessage)?.SetAttachments();
        }

        ~Message()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free managed objects
            }

            // Free unmanaged objects
            if (_messageHandle != IntPtr.Zero)
            {
                Interop.Messages.DestroyMessage(_messageHandle);
                _messageHandle = IntPtr.Zero;
            }
            disposed = true;
        }

        internal IntPtr GetHandle()
        {
            return _messageHandle;
        }

        private void SetAddresses()
        {
            foreach (var it in _to)
            {
                AddAddress(it);
            }

            foreach (var it in _cc)
            {
                AddAddress(it);
            }

            foreach (var it in _bcc)
            {
                AddAddress(it);
            }
        }

        private void AddAddress(MessagesAddress address)
        {
            int ret = Interop.Messages.AddAddress(_messageHandle, address.Number, (int)address.Type);
            if (ret != (int)MessagesError.None)
            {
                Log.Error(Globals.LogTag, "Failed to add address, Error - " + (MessagesError)ret);
                MessagesErrorFactory.ThrowMessagesException(ret, _messageHandle);
            }
        }

        private void GetAllAddresses()
        {
            int count;

            int ret = Interop.Messages.GetAddressCount(_messageHandle, out count);
            if (ret != (int)MessagesError.None)
            {
                Log.Error(Globals.LogTag, "Failed to get address count, Error - " + (MessagesError)ret);
                MessagesErrorFactory.ThrowMessagesException(ret, _messageHandle);
            }

            string number;
            int type;
            var To = new Collection<MessagesAddress>();
            var Cc = new Collection<MessagesAddress>();
            var Bcc = new Collection<MessagesAddress>();

            for (int i = 0; i < count; i++)
            {
                ret = Interop.Messages.GetAddress(_messageHandle, i, out number, out type);
                if (ret != (int)MessagesError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get address, Error - " + (MessagesError)ret);
                    MessagesErrorFactory.ThrowMessagesException(ret, _messageHandle);
                }

                var addressItem = new MessagesAddress((RecipientType)type, number);
                switch ((RecipientType)type)
                {
                    case RecipientType.To:
                        To.Add(addressItem);
                        break;
                    case RecipientType.Cc:
                        Cc.Add(addressItem);
                        break;
                    case RecipientType.Bcc:
                        Bcc.Add(addressItem);
                        break;
                    default:
                        _from = addressItem;
                        break;
                }
            }

            _to = To;
            _cc = Cc;
            _bcc = Bcc;
        }

        public int Id
        {
            get
            {
                int id = 0;
                int ret = Interop.Messages.GetMessageId(_messageHandle, out id);
                if (ret != (int)MessagesError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get message id, Error - " + (MessagesError)ret);
                }

                return id;
            }
        }

        public int Port
        {
            get
            {
                int port = 0;
                int ret = Interop.Messages.GetMessagePort(_messageHandle, out port);
                if (ret != (int)MessagesError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get message port, Error - " + (MessagesError)ret);
                }

                return port;
            }
        }

        public MessageBoxType BoxType
        {
            get
            {
                int boxType = (int)MessageBoxType.All;
                int ret = Interop.Messages.GetMboxType(_messageHandle, out boxType);
                if (ret != (int)MessagesError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get message box type, Error - " + (MessagesError)ret);
                }

                return (MessageBoxType)boxType;
            }
            set
            {
                int ret = Interop.Messages.SetMboxType(_messageHandle, (int)value);
                if (ret != (int)MessagesError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set message box type, Error - " + (MessagesError)ret);
                    MessagesErrorFactory.ThrowMessagesException(ret, _messageHandle);
                }
            }
        }

        public string Text
        {
            get
            {
                string text = null;
                int ret = Interop.Messages.GetText(_messageHandle, out text);
                if (ret != (int)MessagesError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get text, Error - " + (MessagesError)ret);
                }

                return text;
            }
            set
            {
                int ret = Interop.Messages.SetText(_messageHandle, value);
                if (ret != (int)MessagesError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set text, Error - " + (MessagesError)ret);
                    MessagesErrorFactory.ThrowMessagesException(ret, _messageHandle);
                }
            }
        }

        public DateTime Time
        {
            get
            {
                int time = 0;
                int ret = Interop.Messages.GetTime(_messageHandle, out time);
                if (ret != (int)MessagesError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get time, Error - " + (MessagesError)ret);
                }

                return (new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).AddSeconds(time).ToLocalTime();
            }
            set
            {
                int ret = Interop.Messages.SetTime(_messageHandle, (int)(value.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds));
                if (ret != (int)MessagesError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set time, Error - " + (MessagesError)ret);
                    MessagesErrorFactory.ThrowMessagesException(ret, _messageHandle);
                }
            }
        }

        public SimSlotId SimId
        {
            get
            {
                int simId = (int)SimSlotId.Unknown;
                int ret = Interop.Messages.GetSimId(_messageHandle, out simId);
                if (ret != (int)MessagesError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get simId, Error - " + (MessagesError)ret);
                }

                return (SimSlotId)simId;
            }
            set
            {
                int ret = Interop.Messages.SetSimId(_messageHandle, (int)value);
                if (ret != (int)MessagesError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set simId, Error - " + (MessagesError)ret);
                    MessagesErrorFactory.ThrowMessagesException(ret, _messageHandle);
                }
            }
        }

        public MessagesAddress From
        {
            get
            {
                return _from;
            }
        }
    }
}
