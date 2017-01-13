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
    public enum SentResult
    {
        /// <summary>
        /// Message sending failed
        /// </summary>
        Failed = -1,
        /// <summary>
        /// Message sending succeeded
        /// </summary>
        Success = 0
    }

    /// <summary>
    /// Enumeration for the message type.
    /// </summary>
    public enum MessageType
    {
        /// <summary>
        /// Unknown type
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// SMS type
        /// </summary>
        Sms = 1,
        /// <summary>
        /// MMS type
        /// </summary>
        Mms = 2,
        /// <summary>
        /// CB(Cell Broadcast) type
        /// </summary>
        CellBroadcast = Sms | 1 << 4,
        /// <summary>
        /// WAP Push type
        /// </summary>
        Push = Mms | 10 << 4
    }

    /// <summary>
    /// Enumeration for the message box type.
    /// </summary>
    public enum MessageBoxType
    {
        /// <summary>
        /// All message box type
        /// </summary>
        All = 0,
        /// <summary>
        /// Inbox type
        /// </summary>
        Inbox = 1,
        /// <summary>
        /// Outbox type
        /// </summary>
        Outbox = 2,
        /// <summary>
        /// Sentbox type
        /// </summary>
        Sentbox = 3,
        /// <summary>
        /// Draft type
        /// </summary>
        Draft = 4
    }

    /// <summary>
    /// Enumeration for the SIM slot index of a message
    /// </summary>
    public enum SimSlotId
    {
        /// <summary>
        /// Unknown SIM Slot
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// SIM Slot 1
        /// </summary>
        SimSlotId1 = 1,
        /// <summary>
        /// SIM Slot 2
        /// </summary>
        SimSlotId2 = 2
    }

    /// <summary>
    /// Enumeration for the recipient type of a message
    /// </summary>
    internal enum RecipientType
    {
        /// <summary>
        /// Unknown
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// 'To' recipient
        /// </summary>
        To = 1,
        /// <summary>
        /// 'Cc' (carbon copy) recipient
        /// </summary>
        Cc = 2,
        /// <summary>
        /// 'Bcc' (blind carbon copy) recipient
        /// </summary>
        Bcc = 3
    }

    /// <summary>
    /// Enumeration for the attachment tyoe for MMS messaging.
    /// </summary>
    public enum MediaType
    {
        /// <summary>
        /// Unknown
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// The image
        /// </summary>
        Image = 1,
        /// <summary>
        /// The audio
        /// </summary>
        Audio = 2,
        /// <summary>
        /// The video
        /// </summary>
        Video = 3
    }
}
