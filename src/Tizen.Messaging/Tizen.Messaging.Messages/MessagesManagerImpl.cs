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
using System.Threading.Tasks;

namespace Tizen.Messaging.Messages
{
    static internal class Globals
    {
        internal const string LogTag = "Tizen.Messaging.Messages";
    }

    internal partial class MessagesManagerImpl : IDisposable
    {
        private static readonly MessagesManagerImpl _instance = new MessagesManagerImpl();
        private bool disposed = false;

        private static IntPtr _MessageServiceHandle;

        int _requestId = 0;
        Dictionary<int, TaskCompletionSource<SentResult>> _sendMessageTaskSource = new Dictionary<int, TaskCompletionSource<SentResult>>();
        Interop.Messages.MessageSentCallback _messageSentCallback;

        internal static MessagesManagerImpl Instance
        {
            get
            {
                return _instance;
            }
        }

        private MessagesManagerImpl()
        {
            initialize();
        }

        ~MessagesManagerImpl()
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
            deinitialize();
            disposed = true;
        }

        private void initialize()
        {
            _messageSentCallback = MessageSentCallback;
            int ret;

            ret = Interop.Messages.OpenService(out _MessageServiceHandle);
            if (ret != (int)MessagesError.None)
            {
                Log.Error(Globals.LogTag, "Failed to open service, Error - " + (MessagesError)ret);
            }
        }

        private void deinitialize()
        {
            if (_MessageServiceHandle != IntPtr.Zero)
            {
                int ret;

                ret = Interop.Messages.CloseService(_MessageServiceHandle);
                if (ret != (int)MessagesError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to close service, Error - " + (MessagesError)ret);
                }

                _MessageServiceHandle = IntPtr.Zero;
            }
        }

        void MessageSentCallback(int result, IntPtr data) {
            int requestId = (int)data;
            if (_sendMessageTaskSource.ContainsKey(requestId))
            {
                _sendMessageTaskSource[requestId].SetResult((SentResult)result);
                _sendMessageTaskSource.Remove(requestId);
            }
        }

        internal Task<SentResult> SendMessageAsync(Message message, bool saveToSentbox)
        {
            TaskCompletionSource<SentResult> task = new TaskCompletionSource<SentResult>();
            int requestId = 0;

            lock (this)
            {
                requestId = _requestId++;
                _sendMessageTaskSource[requestId] = task;
            }
            message.FillHandle();
            IntPtr messageHandle = message.GetHandle();
            int ret = Interop.Messages.SendMessage(_MessageServiceHandle, messageHandle, saveToSentbox, _messageSentCallback, (IntPtr)requestId);
            if (ret != (int)MessagesError.None)
            {
                Log.Error(Globals.LogTag, "Failed to send message, Error - " + (MessagesError)ret);
                _sendMessageTaskSource.Remove(requestId);
                MessagesErrorFactory.ThrowMessagesException(ret, _MessageServiceHandle);
            }
            return task.Task;
        }

        internal Task<IEnumerable<Message>> SearchMessageAsync(MessagesSearchFilter filter)
        {
            return Task.Run<IEnumerable<Message>>(() =>
            {
                List<Message> messageList = new List<Message>();
                int ret;

                Interop.Messages.MessageSearchCallback callback = (IntPtr messageHandle, int index, int resultCount, int totalCount, IntPtr userData) =>
                {
                    try
                    {
                        if (messageHandle != IntPtr.Zero)
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
                                        var messageItem = new SmsMessage(duplicatedMessageHandle);
                                        messageList.Add(messageItem);
                                        break;
                                    }
                                    case MessageType.Mms:
                                    {
                                        var messageItem = new MmsMessage(duplicatedMessageHandle);
                                        messageList.Add(messageItem);
                                        break;
                                    }
                                    case MessageType.CellBroadcast:
                                    {
                                        var messageItem = new CBMessage(duplicatedMessageHandle);
                                        messageList.Add(messageItem);
                                        break;
                                    }
                                    case MessageType.Push:
                                    {
                                        var messageItem = new PushMessage(duplicatedMessageHandle);
                                        messageList.Add(messageItem);
                                        break;
                                    }
                                    default:
                                    {
                                        Log.Error(Globals.LogTag, "Invaild message type - " + type);
                                        break;
                                    }
                                }

                                return true;
                            }
                        }
                    }
                    catch
                    {
                        Log.Error(Globals.LogTag, "Exception in Callback");
                    }

                    return false;
                };

                ret = Interop.Messages.SearchMessage(_MessageServiceHandle, (int)filter.MessageBoxType, (int)filter.MessageType, filter.TextKeyword, filter.AddressKeyword, 0, 0, callback, IntPtr.Zero);
                if (ret != (int)MessagesError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to search message, Error - " + (MessagesError)ret);
                    MessagesErrorFactory.ThrowMessagesException(ret, _MessageServiceHandle);
                }

                return messageList;
            });
        }

        private void DuplicateMessageHandle(IntPtr sourceHandle, out IntPtr clonedHandle)
        {
            int msgId;
            IntPtr returnedHandle = IntPtr.Zero;

            int ret = Interop.Messages.GetMessageId(sourceHandle, out msgId);
            if (ret == (int)MessagesError.None)
            {
                ret = Interop.Messages.GetMessageById(_MessageServiceHandle, msgId, out returnedHandle);
                if (ret != (int)MessagesError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get message by id, Error - " + (MessagesError)ret);
                    MessagesErrorFactory.ThrowMessagesException(ret, _MessageServiceHandle);
                }
            }
            else
            {
                Log.Error(Globals.LogTag, "Failed to get message id, Error - " + (MessagesError)ret);
                MessagesErrorFactory.ThrowMessagesException(ret, _MessageServiceHandle);
            }

            clonedHandle = returnedHandle;
        }
    }
}
