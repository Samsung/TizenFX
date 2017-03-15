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

namespace Tizen.Content.MediaContent
{
    /// <summary>
    /// Event arguments passed when content is updated in the media database
    /// </summary>
    public class ContentUpdatedEventArgs : EventArgs
    {
        internal ContentUpdatedEventArgs(MediaContentError error, int pid, MediaContentUpdateItemType updateItem,
            MediaContentDBUpdateType updateType, MediaContentType mediaType, string uuid, string filePath, string mimeType)
        {
            Error = error;
            Pid = pid;
            UpdateItem = updateItem;
            UpdateType = updateType;
            MediaType = mediaType;
            Uuid = uuid;
            FilePath = filePath;
            MimeType = mimeType;
        }
        /// <summary>
        /// The error code
        /// </summary>
        public MediaContentError Error
        {
            get;
            internal set;
        }

        /// <summary>
        /// The PID which publishes notification
        /// </summary>
        public int Pid
        {
            get; set;
        }

        /// <summary>
        /// The update item of notification
        /// </summary>
        public MediaContentUpdateItemType UpdateItem
        {
            get; set;
        }

        /// <summary>
        /// The update type of notification
        /// </summary>
        public MediaContentDBUpdateType UpdateType
        {
            get; set;
        }

        /// <summary>
        /// The type of the media content
        /// </summary>
        public MediaContentType MediaType
        {
            get; set;
        }

        /// <summary>
        /// The UUID of media or directory, which is updated
        /// </summary>
        public string Uuid
        {
            get; set;
        }

        /// <summary>
        /// The path of the media or directory
        /// </summary>
        public string FilePath
        {
            get; set;
        }

        /// <summary>
        /// The mime type of the media info
        /// </summary>
        public string MimeType
        {
            get; set;
        }
    }
}
