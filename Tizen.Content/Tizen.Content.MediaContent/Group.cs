using System;
using System.Collections.Generic;
using System.Threading.Tasks;
/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc.("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.


namespace Tizen.Content.MediaContent
{
    /// <summary>
    /// A Media Group represents logical grouping of media files with respect to their group name.
    /// It is also used for filtering media items.
    /// </summary>
    public class Group : ContentCollection
    {
        private readonly string _groupName;
        private readonly MediaGroupType _groupType;
        private bool _disposedValue = false;

        /// <summary>
        /// The name of the media group
        /// </summary>
        public string Name
        {
            get { return _groupName; }
        }

        internal Group(string name, MediaGroupType groupType)
        {
            _groupName = name;
            _groupType = groupType;
        }

        /// <summary>
        /// Dispose API for closing the internal resources.
        /// This function can be used to stop all effects started by Vibrate().
        /// </summary>
        public override void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                _disposedValue = true;
            }
        }

        /// <summary>
        /// Gets the count of the media info for the given media group present in the media database.
        /// </summary>
        /// <param name="filter">ContentFilter used to match media content from the media database.</param>
        /// <returns>The number of media contents matching the filter passed</returns>
        public override int GetMediaInformationCount(ContentFilter filter)
        {
            int mediaCount;
            IntPtr handle = (filter != null) ? filter.Handle : IntPtr.Zero;
            MediaContentError res = (MediaContentError)Interop.Group.GetMediaCountFromDb(Name, _groupType, handle, out mediaCount);
            if (res != MediaContentError.None)
            {
                Log.Warn(MediaContentErrorFactory.LogTag, "Failed to get media count for the group");
            }
            return mediaCount;
        }


        /// <summary>
        /// Iterates through the media files with an optional filter in the given group from the media database.
        /// This function gets all media files associated with the given group and meeting desired filter option.
        /// If NULL is passed to the filter, no filtering is applied.
        /// </summary>
        /// <param name="filter">ContentFilter used to match media content from the media database.</param>
        /// <returns>List of content media items matching the passed filter</returns>
        public override Task<IEnumerable<MediaInformation>> GetMediaInformationsAsync(ContentFilter filter)
        {
            var tcs = new TaskCompletionSource<IEnumerable<MediaInformation>>();
            List<MediaInformation> mediaContents = new List<MediaInformation>();
            IntPtr handle = (filter != null) ? filter.Handle : IntPtr.Zero;
            MediaContentError res;
            Interop.Group.MediaInfoCallback callback = (IntPtr mediaHandle, IntPtr data) =>
            {
                Interop.MediaInformation.SafeMediaInformationHandle newHandle;
                res = (MediaContentError)Interop.MediaInformation.Clone(out newHandle, mediaHandle);
                MediaInformation info = new MediaInformation(newHandle);
                mediaContents.Add(info);
                return true;
            };
            res = (MediaContentError)Interop.Group.ForeachMediaFromDb(Name, _groupType, handle, callback, IntPtr.Zero);
            if (res != MediaContentError.None)
            {
                Log.Warn(MediaContentErrorFactory.LogTag, "Failed to get media information for the group");
            }
            tcs.TrySetResult(mediaContents);
            return tcs.Task;
        }
    }
}
