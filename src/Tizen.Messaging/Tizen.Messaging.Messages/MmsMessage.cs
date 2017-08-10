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

namespace Tizen.Messaging.Messages
{
    /// <summary>
    /// A class to represent multimedia messages.
    /// </summary>
    public class MmsMessage : Message
    {
        private IList<MessagesAttachment> _attachment = new List<MessagesAttachment>();

        /// <summary>
        /// Creates a multimedia message.
        /// </summary>
        public MmsMessage() : base(MessageType.Mms)
        {
        }

        internal MmsMessage(IntPtr messageHandle) : base(messageHandle)
        {
            GetAllAttachments();
        }

        /// <summary>
        /// The subject of the multimedia message
        /// </summary>
        public string Subject
        {
            get
            {
                string subject = null;
                int ret = Interop.Messages.GetSubject(_messageHandle, out subject);
                if (ret != (int)MessagesError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get subject, Error - " + (MessagesError)ret);
                }

                return subject;
            }
            set
            {
                int ret = Interop.Messages.SetSubject(_messageHandle, value);
                if (ret != (int)MessagesError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set subject, Error - " + (MessagesError)ret);
                    MessagesErrorFactory.ThrowMessagesException(ret, _messageHandle);
                }
            }
        }

        /// <summary>
        /// Collection of normal message recipients
        /// </summary>
        public ICollection<MessagesAddress> To
        {
            get
            {
                return _to;
            }
        }

        /// <summary>
        /// Collection of CC(carbon copy) message recipients
        /// </summary>
        public ICollection<MessagesAddress> Cc
        {
            get
            {
                return _cc;
            }
        }

        /// <summary>
        /// Collection of BCC(blind carbon copy) message recipients
        /// </summary>
        public ICollection<MessagesAddress> Bcc
        {
            get
            {
                return _bcc;
            }
        }

        /// <summary>
        /// The list of attachment files
        /// </summary>
        public IList<MessagesAttachment> Attachments
        {
            get
            {
                return _attachment;
            }
        }

        internal void SetAttachments()
        {
            foreach (var it in _attachment)
            {
                AddAttachment(it);
            }
        }

        private void AddAttachment(MessagesAttachment attach)
        {
            int ret = Interop.Messages.AddAttachment(_messageHandle, (int)attach.Type, attach.FilePath);
            if (ret != (int)MessagesError.None)
            {
                Log.Error(Globals.LogTag, "Failed to add attachment, Error - " + (MessagesError)ret);
                MessagesErrorFactory.ThrowMessagesException(ret, _messageHandle);
            }
        }

        private void GetAllAttachments()
        {
            int count;

            int ret = Interop.Messages.GetAttachmentCount(_messageHandle, out count);
            if (ret != (int)MessagesError.None)
            {
                Log.Error(Globals.LogTag, "Failed to get attachment count, Error - " + (MessagesError)ret);
                MessagesErrorFactory.ThrowMessagesException(ret, _messageHandle);
            }

            string path;
            int type;
            var attachmentList = new List<MessagesAttachment>();

            for (int i = 0; i < count; i++)
            {
                ret = Interop.Messages.GetAttachment(_messageHandle, i, out type, out path);
                if (ret != (int)MessagesError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get attachment, Error - " + (MessagesError)ret);
                    MessagesErrorFactory.ThrowMessagesException(ret, _messageHandle);
                }

                var attachmentItem = new MessagesAttachment((MediaType)type, path);
                attachmentList.Add(attachmentItem);
            }

            _attachment = attachmentList;
        }

    }
}
