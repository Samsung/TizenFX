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
    /// This class represents message search filters.
    /// </summary>
    public class MessagesSearchFilter
    {
        /// <summary>
        /// Creates a search filter for searching messages.
        /// </summary>
        public MessagesSearchFilter()
        {
        }

        /// <summary>
        /// The message box type.
        /// </summary>
        public MessageBoxType MessageBoxType { get; set; }
        /// <summary>
        /// The message type.
        /// </summary>
        public MessageType MessageType { get; set; }
        /// <summary>
        /// The keyword to search in the text and the subject.
        /// </summary>
        public string TextKeyword { get; set; }
        /// <summary>
        /// The recipient address.
        /// </summary>
        public string AddressKeyword { get; set; }
    }
}
