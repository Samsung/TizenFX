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

namespace Tizen.Messaging.Messages
{
    internal partial class MessagesManagerImpl
    {
        private event EventHandler<MessageReceivedEventArgs> _messageReceived;

        private Interop.Messages.MessageIncomingCallback _messageReceivedCallback;

        private bool _registered = false;

        internal event EventHandler<MessageReceivedEventArgs> _MessageReceived
        {
            add
            {
                if (_registered == false && _messageReceived == null)
                {
                    RegisterMessageReceivedEvent();
                }
                _messageReceived += value;
            }
            remove
            {
                _messageReceived -= value;
            }
        }

        private void RegisterMessageReceivedEvent()
        {
            _messageReceivedCallback = (IntPtr messageHandle, IntPtr userData) =>
            {
                try
                {
                    IntPtr duplicatedMessageHandle = IntPtr.Zero;

                    DuplicateMessageHandle(messageHandle, out duplicatedMessageHandle);
                    if (duplicatedMessageHandle != IntPtr.Zero)
                    {
                        int type = (int)MessageType.Unknown;
                        int result = Interop.Messages.GetMessageType(duplicatedMessageHandle, out type);
                        if (result != (int)MessagesError.None)
                        {
                            Log.Error(Globals.LogTag, "Failed to get message type, Error - " + (MessagesError)result);
                        }

                        switch ((MessageType)type)
                        {
                            case MessageType.Sms:
                            {
                                var receivedMessage = new SmsMessage(duplicatedMessageHandle);
                                MessageReceivedEventArgs args = new MessageReceivedEventArgs(receivedMessage);
                                _messageReceived?.Invoke(null, args);
                                break;
                            }
                            case MessageType.Mms:
                            {
                                var receivedMessage = new MmsMessage(duplicatedMessageHandle);
                                MessageReceivedEventArgs args = new MessageReceivedEventArgs(receivedMessage);
                                _messageReceived?.Invoke(null, args);
                                break;
                            }
                            case MessageType.CellBroadcast:
                            {
                                var receivedMessage = new CBMessage(duplicatedMessageHandle);
                                MessageReceivedEventArgs args = new MessageReceivedEventArgs(receivedMessage);
                                _messageReceived?.Invoke(null, args);
                                break;
                            }
                            case MessageType.Push:
                            {
                                var receivedMessage = new PushMessage(duplicatedMessageHandle);
                                MessageReceivedEventArgs args = new MessageReceivedEventArgs(receivedMessage);
                                _messageReceived?.Invoke(null, args);
                                break;
                            }
                            default:
                            {
                                Log.Error(Globals.LogTag, "Invaild message type - " + type);
                                break;
                            }
                        }
                    }
                }
                catch
                {
                    Log.Error(Globals.LogTag, "Exception in Callback");
                }
            };

            int ret = Interop.Messages.SetMessageIncomingCb(_MessageServiceHandle, _messageReceivedCallback, IntPtr.Zero);
            if (ret != (int)MessagesError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set message incoming callback, Error - " + (MessagesError)ret);
            }

            _registered = true;
        }
    }
}
