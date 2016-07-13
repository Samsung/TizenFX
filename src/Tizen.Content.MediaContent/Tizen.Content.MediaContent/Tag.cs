/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc.("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.


using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tizen.Content.MediaContent
{
    /// <summary>
    /// A Tag is a special piece of information that may be associated with media content items.
    /// Tagging allows a user to organize large number of items into logical groups providing a simplified and faster way of accessing media content items.
    /// </summary>
    public class Tag : ContentCollection
    {
        private IntPtr _tagHandle = IntPtr.Zero;
        private string _tagName = "";
        internal IntPtr Handle
        {
            get
            {
                return _tagHandle;
            }
            set
            {
                _tagHandle = value;
            }
        }
        /// <summary>
        /// The ID of the media tag
        /// </summary>
        public int Id
        {
            get
            {
                int id;
                MediaContentError res = (MediaContentError)Interop.Tag.GetTagId(_tagHandle, out id);
                if (res != MediaContentError.None)
                {
                    Log.Warn(MediaContentErrorFactory.LogTag, "Failed to get Id for the Tag");
                }
                return id;
            }
        }

        /// <summary>
        /// The name of the tag
        /// </summary>
        public string Name
        {
            get
            {
                return _tagName;
            }
            set
            {
                MediaContentError res = (MediaContentError)Interop.Tag.SetName(_tagHandle, value);
                if (res == MediaContentError.None)
                {
                    _tagName = value;
                }
                else
                {
                    Log.Warn(MediaContentErrorFactory.LogTag, "Failed to set name for the Tag");
                }
            }
        }

        internal Tag(IntPtr tagHandle)
        {
            _tagHandle = tagHandle;
            MediaContentError error = (MediaContentError)Interop.Tag.GetName(tagHandle, out _tagName);
            if (error != MediaContentError.None)
            {
                throw MediaContentErrorFactory.CreateException(error, "Failed to get the tage Name");
            }
        }
        /// <summary>
        /// Creates a Tag object which can be inserted to the media database using ContentManager:InsertToDatabaseAsync(ContentCollection)
        /// </summary>
        /// <param name="tagName">The name of the media tag</param>
        public Tag(string tagName)
        {
            _tagName = tagName;
        }

        /// <summary>
        /// Adds a new media info to the tag.
        /// </summary>
        /// <param name="mediaContent">The media info which is added</param>
        public void AddItem(MediaInformation mediaContent)
        {
            Console.WriteLine("Tag add item info: " + mediaContent.MediaId);
            MediaContentError res = (MediaContentError)Interop.Tag.AddMedia(_tagHandle, mediaContent.MediaId);
            if (res != MediaContentError.None)
            {
                Console.WriteLine("exception :" + res);
                throw MediaContentErrorFactory.CreateException(res, "Failed to add the media item to the Tag");
            }
        }

        /// <summary>
        /// Removes the media info from the given tag.
        /// </summary>
        /// <param name="mediaContent">The media info which is removed</param>
        public void RemoveItem(MediaInformation mediaContent)
        {
            MediaContentError res = (MediaContentError)Interop.Tag.RemoveMedia(_tagHandle, mediaContent.MediaId);
            if (res != MediaContentError.None)
            {
                throw MediaContentErrorFactory.CreateException(res, "Failed to remove the media item from the Tag");
            }
        }

        /// <summary>
        /// Gets the number of media files for the passed filter in the given tag from the media database.
        /// </summary>
        /// <param name="filter">ContentFilter used to match media content from the media database.</param>
        /// <returns>The number of media contents matching the filter passed</returns>
        public override int GetMediaInformationCount(ContentFilter filter)
        {
            int mediaCount;
            IntPtr handle = (filter != null) ? filter.Handle : IntPtr.Zero;
            MediaContentError res = (MediaContentError)Interop.Tag.GetMediaCountFromDb(Id, handle, out mediaCount);
            if (res != MediaContentError.None)
            {
                throw MediaContentErrorFactory.CreateException(res, "Failed to get media count for the tag");
            }
            return mediaCount;
        }

        public override void Dispose()
        {
            MediaContentError res = (MediaContentError)Interop.Tag.Destroy(_tagHandle);
            _tagHandle = IntPtr.Zero;
            if (res != MediaContentError.None)
            {
                throw MediaContentErrorFactory.CreateException(res, "Failed to dispose the tag");
            }
        }

        /// <summary>
        /// Iterates through media items for a given tag from the media database.
        /// This function gets all media items associated with a given tag and meeting a desired filter.
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
            Interop.Tag.MediaInfoCallback callback = (IntPtr mediaHandle, IntPtr data) =>
            {
                Interop.MediaInformation.SafeMediaInformationHandle newHandle;
                res = (MediaContentError)Interop.MediaInformation.Clone(out newHandle, mediaHandle);
                if (res != MediaContentError.None)
                {
                    throw MediaContentErrorFactory.CreateException(res, "Failed to clone media");
                }
                MediaInformation info = new MediaInformation(newHandle);
                mediaContents.Add(info);
            };
            res = (MediaContentError)Interop.Tag.ForeachMediaFromDb(Id, handle, callback, IntPtr.Zero);
            if (res != MediaContentError.None)
            {
                Log.Warn(MediaContentErrorFactory.LogTag, "Failed to get media information for the tag");
            }
            tcs.TrySetResult(mediaContents);
            return tcs.Task;
        }
    }
}
