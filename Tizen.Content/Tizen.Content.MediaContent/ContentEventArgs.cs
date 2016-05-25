/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc.("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
