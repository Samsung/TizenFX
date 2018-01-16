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
    /// <summary>
    /// This class is used for the message management. It allows applications to use the message service.
    /// </summary>
    /// <privilege>http://tizen.org/privilege/message.read</privilege>
    /// <since_tizen> 3 </since_tizen>
    public static class MessagesManager
    {
        /// <summary>
        /// Sends a message.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/message.write</privilege>
        /// <param name="message">The message to be sent.</param>
        /// <param name="saveToSentbox">The boolean variable used to indicate whether the sent message should be saved in the sentbox or not.</param>
        /// <returns>A task containing the result of message sending.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to an invalid operation.</exception>
        /// <exception cref="NotSupportedException">Thrown when the message service is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when input coordinates are invalid.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when an application does not have proper privileges.</exception>
        /// <since_tizen> 3 </since_tizen>
        public static Task<SentResult> SendMessageAsync(Message message, bool saveToSentbox)
        {
            return MessagesManagerImpl.GetInstance().SendMessageAsync(message, saveToSentbox);
        }

        /// <summary>
        /// Searches for messages.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/message.read</privilege>
        /// <param name="filter">The search filter for searching messages.</param>
        /// <returns>A task containing the messages, which match the search filter.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to an invalid operation.</exception>
        /// <exception cref="NotSupportedException">Thrown when the message service is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when input coordinates are invalid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when an application does not have proper privileges.</exception>
        /// <since_tizen> 3 </since_tizen>
        public static Task<IEnumerable<Message>> SearchMessageAsync(MessagesSearchFilter filter)
        {
            return MessagesManagerImpl.GetInstance().SearchMessageAsync(filter);
        }

        /// <summary>
        /// The MessageReceived event that is raised when receiving a message.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/message.read</privilege>
        /// <since_tizen> 3 </since_tizen>
        static public event EventHandler<MessageReceivedEventArgs> MessageReceived
        {
            add
            {
                MessagesManagerImpl.GetInstance()._MessageReceived += value;
            }
            remove
            {
                MessagesManagerImpl.GetInstance()._MessageReceived -= value;
            }
        }
    }
}
