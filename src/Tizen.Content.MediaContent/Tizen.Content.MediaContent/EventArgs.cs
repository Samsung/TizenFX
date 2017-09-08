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
    /// Provides data for the <see cref="MediaDatabase.MediaInfoUpdated"/> event.
    /// </summary>
    public class MediaInfoUpdatedEventArgs : EventArgs
    {
        internal MediaInfoUpdatedEventArgs(int pid,
            OperationType operationType, MediaType mediaType, string id, string path, string mimeType)
        {
            ProcessId = pid;
            OperationType = operationType;
            Id = id;
            Path = path;

            MediaType = mediaType;
            MimeType = mimeType;
        }

        /// <summary>
        /// Gets the process ID which triggers the event.
        /// </summary>
        /// <value>The process ID which triggers the event.</value>
        public int ProcessId
        {
            get;
        }

        /// <summary>
        /// Gets the operation type.
        /// </summary>
        /// <value>The operation type which triggers the event.</value>
        public OperationType OperationType
        {
            get;
        }

        /// <summary>
        /// Gets the ID of the media updated.
        /// </summary>
        /// <value>The ID of the media updated.</value>
        public string Id
        {
            get;
        }

        /// <summary>
        /// Gets the path of the media updated.
        /// </summary>
        /// <value>The path of the media updated.</value>
        public string Path
        {
            get;
        }

        /// <summary>
        /// Gets the type of the media updated.
        /// </summary>
        /// <value>The <see cref="MediaType"/> of the media updated.</value>
        public MediaType MediaType
        {
            get;
        }

        /// <summary>
        /// The MIME type of the media updated.
        /// </summary>
        /// <value>The MIME type of the media updated.</value>
        public string MimeType
        {
            get;
        }
    }


    /// <summary>
    /// Provides data for the <see cref="MediaDatabase.FolderUpdated"/> event.
    /// </summary>
    public class FolderUpdatedEventArgs : EventArgs
    {
        internal FolderUpdatedEventArgs(OperationType operationType, string id, string path)
        {
            OperationType = operationType;
            Id = id;
            Path = path;
        }

        /// <summary>
        /// Gets the operation type.
        /// </summary>
        /// <value>The operation type which triggers the event.</value>
        public OperationType OperationType
        {
            get;
        }

        /// <summary>
        /// Gets the ID of the folder updated.
        /// </summary>
        /// <value>The ID of the folder updated.</value>
        public string Id
        {
            get;
        }

        /// <summary>
        /// Gets the path of the folder updated.
        /// </summary>
        /// <value>The path of the folder updated.</value>
        public string Path
        {
            get;
        }
    }

}
