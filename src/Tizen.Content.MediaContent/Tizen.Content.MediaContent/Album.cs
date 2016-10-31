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

namespace Tizen.Content.MediaContent
{
    /// <summary>
    /// An album is a logical collection or grouping of related audio files. It is also used for filtering media items.
    /// The Media Album API allows to manage media albums which contains all video and audio items from the same album.
    /// </summary>
    public class Album : ContentCollection
    {
        internal IntPtr _albumHandle = IntPtr.Zero;
        /// <summary>
        /// The media album ID
        /// </summary>
        public int Id
        {
            get
            {
                int id = 0;
                MediaContentError res = (MediaContentError)Interop.Group.MediaAlbumGetAlbumId(_albumHandle, out id);
                if (res != MediaContentError.None)
                {
                    Log.Warn(MediaContentErrorFactory.LogTag, "Failed to get Id for the Album");
                }
                return id;
            }
        }

        /// <summary>
        /// The name of the media artist
        /// </summary>
        public string Artist
        {
            get
            {
                string artist = "";
                MediaContentError res = (MediaContentError)Interop.Group.MediaAlbumGetArtist(_albumHandle, out artist);
                if (res != MediaContentError.None)
                {
                    Log.Warn(MediaContentErrorFactory.LogTag, "Failed to get Artist for the Album");
                }
                return artist;
            }
        }

        /// <summary>
        /// The path of the media album art
        /// </summary>
        public string Art
        {
            get
            {
                string art = "";
                MediaContentError res = (MediaContentError)Interop.Group.MediaAlbumGetAlbumArt(_albumHandle, out art);
                Tizen.Log.Info("TCT", "Album Art Property: " + art);
                if (res != MediaContentError.None)
                {
                    Log.Warn(MediaContentErrorFactory.LogTag, "Failed to get Album Art for the Album");
                }
                return art;
            }
        }

        /// <summary>
        /// The name of the media album
        /// </summary>
        public string Name
        {
            get
            {
                string name = "";
                MediaContentError res = (MediaContentError)Interop.Group.MediaAlbumGetArtist(_albumHandle, out name);
                if (res != MediaContentError.None)
                {
                    Log.Warn(MediaContentErrorFactory.LogTag, "Failed to get Name for the Album");
                }
                return name;
            }
        }

        internal Album(IntPtr handle)
        {
            this._albumHandle = handle;
        }

        /// <summary>
        /// Gets the number of MediaInformation Items for the given album present in the media database.
        /// If NULL is passed to the filter, no filtering is applied.
        /// </summary>
        /// <param name="filter">ContentFilter used to match media content from the media database.</param>
        /// <returns>The number of media contents matching the filter passed</returns>
        public override int GetMediaInformationCount(ContentFilter filter)
        {
            int mediaCount = 0;
            IntPtr handle = (filter != null) ? filter.Handle : IntPtr.Zero;
            MediaContentError res = (MediaContentError)Interop.Group.MediaAlbumGetMediaCountFromDb(Id, handle, out mediaCount);
            if (res != MediaContentError.None)
            {
                Log.Warn(MediaContentErrorFactory.LogTag, "Failed to get media count for the album");
            }
            return mediaCount;
        }

        public override void Dispose()
        {
            MediaContentError res = (MediaContentError)Interop.Group.MediaAlbumDestroy(_albumHandle);
            if (res != MediaContentError.None)
            {
                Log.Warn(MediaContentErrorFactory.LogTag, "Failed to dispose the album");
            }
            _albumHandle = IntPtr.Zero;
        }

        /// <summary>
        /// Iterates through the media files with a filter in the given media album from the media database.
        /// This function gets all media files associated with the given media album and meeting desired filter option.
        /// If NULL is passed to the filter, no filtering is applied.
        /// </summary>
        /// <param name="filter">ContentFilter used to match media content from the media database.</param>
        /// <returns>List of content media items matching the passed filter</returns>
        public override Task<IEnumerable<MediaInformation>> GetMediaInformationsAsync(ContentFilter filter)
        {
            var tcs = new TaskCompletionSource<IEnumerable<MediaInformation>>();
            List<MediaInformation> mediaContents = new List<MediaInformation>();
            MediaContentError res;
            IntPtr handle = (filter != null) ? filter.Handle : IntPtr.Zero;
            Interop.Group.MediaInfoCallback callback = (IntPtr mediaHandle, IntPtr data) =>
            {
                Interop.MediaInformation.SafeMediaInformationHandle newHandle;
                res = (MediaContentError)Interop.MediaInformation.Clone(out newHandle, mediaHandle);
                if (res != MediaContentError.None)
                {
                    throw MediaContentErrorFactory.CreateException(res, "Failed to clone media");
                }

                MediaInformation info = new MediaInformation(newHandle);
                mediaContents.Add(info);
                return true;
            };
            res = (MediaContentError)Interop.Group.MediaAlbumForeachMediaFromDb(Id, handle, callback, IntPtr.Zero);
            if (res != MediaContentError.None)
            {
                throw MediaContentErrorFactory.CreateException(res, "Failed to get media information for the album");
            }
            tcs.TrySetResult(mediaContents);
            return tcs.Task;
        }
    }
}
