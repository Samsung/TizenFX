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
    /// A class for message management. It allows applications to use message service.
    /// </summary>
    /// <privilege>http://tizen.org/privilege/message.read</privilege>
    public static class MessagesManager
    {
        /// <summary>
        /// Sends a message.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/message.write</privilege>
        /// <param name="message">The message to be sent</param>
        /// <param name="saveToSentbox">The boolean variable to indicate sent message should be saved in sentbox or not</param>
        /// <returns>A task contains the result of message sending</returns>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation</exception>
        /// <exception cref="NotSupportedException">Thrown when message service is not supported</exception>
        /// <exception cref="ArgumentException">Thrown when input coordinates are invalid</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have proper privileges</exception>
        public static Task<SentResult> SendMessageAsync(Message message, bool saveToSentbox)
        {
            return MessagesManagerImpl.Instance.SendMessageAsync(message, saveToSentbox);
        }

        /// <summary>
        /// Searches for messages.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/message.read</privilege>
        /// <param name="filter">The search filter for searching messages</param>
        /// <returns>A task contains the messages which fit with search filter</returns>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation</exception>
        /// <exception cref="NotSupportedException">Thrown when message service is not supported</exception>
        /// <exception cref="ArgumentException">Thrown when input coordinates are invalid</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have proper privileges</exception>
        public static Task<IEnumerable<Message>> SearchMessageAsync(MessagesSearchFilter filter)
        {
            return MessagesManagerImpl.Instance.SearchMessageAsync(filter);
        }

        /// <summary>
        /// (event) MessageReceived is raised when receiving a message.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/message.read</privilege>
        static public event EventHandler<MessageReceivedEventArgs> MessageReceived
        {
            add
            {
                MessagesManagerImpl.Instance._MessageReceived += value;
            }
            remove
            {
                MessagesManagerImpl.Instance._MessageReceived -= value;
            }
        }
    }
}
