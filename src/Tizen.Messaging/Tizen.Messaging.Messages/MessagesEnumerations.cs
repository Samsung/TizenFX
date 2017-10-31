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

namespace Tizen.Messaging.Messages
{
    /// <summary>
    /// Enumeration for the result of sending a message.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum SentResult
    {
        /// <summary>
        /// Message sending failed.
        /// </summary>
        Failed = -1,
        /// <summary>
        /// Message sending succeeded.
        /// </summary>
        Success = 0
    }

    /// <summary>
    /// Enumeration for the message type.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum MessageType
    {
        /// <summary>
        /// The unknown type.
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// The SMS type.
        /// </summary>
        Sms = 1,
        /// <summary>
        /// The MMS type.
        /// </summary>
        Mms = 2,
        /// <summary>
        /// The CB(Cell Broadcast) type.
        /// </summary>
        CellBroadcast = Sms | 1 << 4,
        /// <summary>
        /// The WAP Push type.
        /// </summary>
        Push = Sms | 10 << 4
    }

    /// <summary>
    /// Enumeration for the message box type.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum MessageBoxType
    {
        /// <summary>
        /// All message box type.
        /// </summary>
        All = 0,
        /// <summary>
        /// The Inbox type.
        /// </summary>
        Inbox = 1,
        /// <summary>
        /// The Outbox type.
        /// </summary>
        Outbox = 2,
        /// <summary>
        /// The Sentbox type.
        /// </summary>
        Sentbox = 3,
        /// <summary>
        /// The Draft type.
        /// </summary>
        Draft = 4
    }

    /// <summary>
    /// Enumeration for the SIM slot index of a message.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum SimSlotId
    {
        /// <summary>
        /// Unknown SIM Slot.
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// SIM Slot 1.
        /// </summary>
        Sim1 = 1,
        /// <summary>
        /// SIM Slot 2.
        /// </summary>
        Sim2 = 2
    }

    /// <summary>
    /// Enumeration for the recipient type of a message.
    /// </summary>
    internal enum RecipientType
    {
        /// <summary>
        /// Unknown.
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// 'To' recipient.
        /// </summary>
        To = 1,
        /// <summary>
        /// 'Cc' (carbon copy) recipient.
        /// </summary>
        Cc = 2,
        /// <summary>
        /// 'Bcc' (blind carbon copy) recipient.
        /// </summary>
        Bcc = 3
    }

    /// <summary>
    /// Enumeration for the attachment type for the MMS messaging.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum MediaType
    {
        /// <summary>
        /// Unknown.
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// The image.
        /// </summary>
        Image = 1,
        /// <summary>
        /// The audio.
        /// </summary>
        Audio = 2,
        /// <summary>
        /// The video.
        /// </summary>
        Video = 3
    }
}
