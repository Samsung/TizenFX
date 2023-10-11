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
    /// <summary>
    /// This class is used to manage the information of the message attachment.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [Obsolete("Deprecated since API11. Might be removed in API13.")]
    public class MessagesAttachment
    {
        /// <summary>
        /// The media type of the attachment.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated since API11. Might be removed in API13.")]
        public MediaType Type { get; }

        /// <summary>
        /// The file path of the attachment.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated since API11. Might be removed in API13.")]
        public string FilePath { get; }

        /// <summary>
        /// Creates an attachment.
        /// </summary>
        /// <param name="type">The attachment's type.</param>
        /// <param name="filePath">The file path to attach.</param>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated since API11. Might be removed in API13.")]
        public MessagesAttachment(MediaType type, string filePath)
        {
            Type = type;
            FilePath = filePath;
        }
    }
}
