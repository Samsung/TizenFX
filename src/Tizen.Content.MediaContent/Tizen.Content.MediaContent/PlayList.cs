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
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Tizen.Content.MediaContent
{
    /// <summary>
    /// The PlayList API provides functions to manage media playlists.
    /// </summary>
    /// <remarks>
    /// A PlayList is a list of songs which can be played in some sequence i.e. sequential or shuffled order.
    /// The Media PlayList API provides functions to insert, delete or updates a media playlist in the database.
    /// </remarks>
    public class PlayList : ContentCollection
    {
        private readonly IDictionary<string, int> _dictionary = new Dictionary<string, int>();
        private IntPtr _playlistHandle = IntPtr.Zero;
        internal IntPtr Handle
        {
            get
            {
                if (_playlistHandle == IntPtr.Zero)
                {
                    throw new ObjectDisposedException(nameof(PlayList));
                }

                return _playlistHandle;
            }

            set
            {
                _playlistHandle = value;
            }
        }

        private void RefreshPlaylistDictionary()
        {
            _dictionary.Clear();
            Interop.Playlist.PlaylistMemberCallback callback = (int memberId, IntPtr mediaHandle, IntPtr data) =>
            {
                Interop.MediaInformation.SafeMediaInformationHandle newHandle;
                IntPtr val = IntPtr.Zero;
                try
                {
                    MediaContentValidator.ThrowIfError(
                        Interop.MediaInformation.Clone(out newHandle, mediaHandle), "Failed to clone media");

                    Interop.MediaInformation.GetMediaId(newHandle, out val);
                    _dictionary.Add(Marshal.PtrToStringAnsi(val), memberId);
                    return true;
                }
                finally
                {
                    Interop.Libc.Free(val);
                }
            };
            MediaContentValidator.ThrowIfError(
                Interop.Playlist.ForeachMediaFromDb(Id, IntPtr.Zero, callback, IntPtr.Zero), "Failed to get playlist items");
        }

        /// <summary>
        /// The ID of the media playlist
        /// </summary>
        public int Id
        {
            get
            {
                int id;
                MediaContentValidator.ThrowIfError(
                    Interop.Playlist.GetPlaylistId(Handle, out id), "Failed to get value");

                return id;
            }
        }

        internal string _playListName;
        /// <summary>
        /// The playlist name
        /// </summary>
        public string Name
        {
            get
            {
                return _playListName;
            }

            set
            {
                MediaContentValidator.ThrowIfError(
                    Interop.Playlist.SetName(Handle, value), "Failed to set value");
                _playListName = value;
            }
        }
        /// <summary>
        /// The path of the thumbnail
        /// </summary>
        public string ThumbnailPath
        {
            get
            {
                IntPtr val = IntPtr.Zero;
                try
                {
                    MediaContentValidator.ThrowIfError(
                        Interop.Playlist.GetThumbnailPath(Handle, out val), "Failed to get value");
                    return Marshal.PtrToStringAnsi(val);
                }
                finally
                {
                    Interop.Libc.Free(val);
                }
            }

            set
            {
                MediaContentValidator.ThrowIfError(
                    Interop.Playlist.SetThumbnailPath(Handle, value), "Failed to set value");
            }
        }

        /// <summary>
        /// The constructor to create a new playlist with the given name in the media database.
        /// </summary>
        /// <param name="name">The name of the inserted playlist</param>
        public PlayList(string name)
        {
            _playListName = name;
        }

        internal PlayList(IntPtr handle)
        {
            _playlistHandle = handle;
            IntPtr val = IntPtr.Zero;
            try
            {
                MediaContentValidator.ThrowIfError(
                    Interop.Playlist.GetName(handle, out val), "Failed to get value");
                _playListName = Marshal.PtrToStringAnsi(val);
            }
            finally
            {
                Interop.Libc.Free(val);
            }
        }

        /// <summary>
        /// Adds a new media info to the playlist.
        /// </summary>
        /// <param name="mediaContent">The AudioContent obect to be added</param>
        public void AddItem(MediaInformation mediaContent)
        {
            MediaContentValidator.ThrowIfError(
                Interop.Playlist.AddMedia(Handle, mediaContent.MediaId), "Failed to add item");
        }

        /// <summary>
        /// Removes the playlist members related with the media from the given playlist.
        /// </summary>
        /// <param name="media">The AudioContent object to be removed</param>
        public void RemoveItem(MediaInformation media)
        {
            int memberId = 0;
            RefreshPlaylistDictionary();
            _dictionary.TryGetValue(media.MediaId, out memberId);
            MediaContentValidator.ThrowIfError(
                Interop.Playlist.RemoveMedia(Handle, memberId), "Failed to remove item");
        }

        /// <summary>
        /// Sets the playing order in the playlist.
        /// </summary>
        /// <param name="media">The playlist reference</param>
        /// <param name="playOrder">The playing order</param>
        public void SetPlayOrder(MediaInformation media, int playOrder)
        {
            int memberId;
            RefreshPlaylistDictionary();
            _dictionary.TryGetValue(media.MediaId, out memberId);
            MediaContentValidator.ThrowIfError(
                Interop.Playlist.SetPlayOrder(Handle, memberId, playOrder), "Failed to set play order");
        }

        /// <summary>
        /// Gets the playing order in the playlist for the passed member id.
        /// </summary>
        /// <param name="media">The MediaInformation instance</param>
        /// <returns>The number of play order</returns>
        public int GetPlayOrder(MediaInformation media)
        {
            int playOrder;
            int memberId;
            RefreshPlaylistDictionary();
            _dictionary.TryGetValue(media.MediaId, out memberId);
            MediaContentValidator.ThrowIfError(
                Interop.Playlist.GetPlayOrder(Handle, memberId, out playOrder), "Failed to get play order");

            return playOrder;
        }

        /// <summary>
        /// Imports the playlist from m3u playlist file.
        /// </summary>
        /// <param name="name">The name of the playlist to save</param>
        /// <param name="filePath">The path to import the playlist file</param>
        /// <returns>The imported PlayList object</returns>
        public static PlayList Import(string name, string filePath)
        {
            PlayList playList = null;
            IntPtr playlistHandle;

            MediaContentValidator.ThrowIfError(
                Interop.Playlist.ImportFromFile(name, filePath, out playlistHandle), "Failed to import");

            playList = new PlayList(name);
            playList.Handle = playlistHandle;
            return playList;
        }

        /// <summary>
        /// Exports the playlist to m3u playlist file.
        /// </summary>
        /// <param name="list">The playlist instance to export</param>
        /// <param name="filePath">The path to save exported playlist</param>
        /// <returns>path The path to export the playlist</returns>
        public static void Export(PlayList list, string filePath)
        {
            MediaContentValidator.ThrowIfError(
                Interop.Playlist.ExportToFile(list.Handle, filePath), "Failed to export playlist:" + filePath);
        }

        /// <summary>
        /// Gets the number of the media info for the given playlist present in the media database.
        /// </summary>
        /// <param name="filter">ContentFilter used to match media content from the media database.</param>
        /// <returns>The number of media contents matching the filter passed</returns>
        public override int GetMediaInformationCount(ContentFilter filter)
        {
            int mediaCount;
            IntPtr handle = (filter != null) ? filter.Handle : IntPtr.Zero;
            MediaContentValidator.ThrowIfError(
                Interop.Playlist.GetMediaCountFromDb(Id, handle, out mediaCount), "Failed to get media count");

            return mediaCount;
        }

        public override void Dispose()
        {
            if (_playlistHandle != IntPtr.Zero)
            {
                Interop.Playlist.Destroy(_playlistHandle);
                _playlistHandle = IntPtr.Zero;
            }
        }

        /// <summary>
        /// Iterates through the media files with an optional filter in the given audio playlist from the media database.
        /// This function gets all media files associated with the given media playlist and meeting desired filter option.
        /// If NULL is passed to the filter, no filtering is applied.
        /// </summary>
        /// <param name="filter">ContentFilter used to match media content from the media database.</param>
        /// <returns>List of content media items matching the passed filter</returns>
        public override Task<IEnumerable<MediaInformation>> GetMediaInformationsAsync(ContentFilter filter)
        {
            var tcs = new TaskCompletionSource<IEnumerable<MediaInformation>>();
            List<MediaInformation> mediaContents = new List<MediaInformation>();
            IntPtr handle = (filter != null) ? filter.Handle : IntPtr.Zero;
            Interop.Playlist.PlaylistMemberCallback callback = (int memberId, IntPtr mediaHandle, IntPtr data) =>
            {
                Interop.MediaInformation.SafeMediaInformationHandle newHandle;
                MediaContentValidator.ThrowIfError(
                    Interop.MediaInformation.Clone(out newHandle, mediaHandle), "Failed to clone media");

                MediaContentType type;
                Interop.MediaInformation.GetMediaType(newHandle, out type);
                if (type == MediaContentType.Image)
                {
                    Interop.ImageInformation.SafeImageInformationHandle imageInfo;
                    MediaContentValidator.ThrowIfError(
                        Interop.MediaInformation.GetImage(mediaHandle, out imageInfo), "Failed to get image information");

                    mediaContents.Add(new ImageInformation(imageInfo, newHandle));
                }
                else if ((type == MediaContentType.Music) || (type == MediaContentType.Sound))
                {
                    Interop.AudioInformation.SafeAudioInformationHandle audioInfo;
                    MediaContentValidator.ThrowIfError(
                        Interop.MediaInformation.GetAudio(mediaHandle, out audioInfo), "Failed to get audio information");

                    mediaContents.Add(new AudioInformation(audioInfo, newHandle));
                }
                else if (type == MediaContentType.Video)
                {
                    Interop.VideoInformation.SafeVideoInformationHandle videoInfo;
                    MediaContentValidator.ThrowIfError(
                        Interop.MediaInformation.GetVideo(mediaHandle, out videoInfo), "Failed to get video information");

                    mediaContents.Add(new VideoInformation(videoInfo, newHandle));
                }
                else if (type == MediaContentType.Others)
                {
                    mediaContents.Add(new MediaInformation(newHandle));
                }

                return true;
            };
            MediaContentValidator.ThrowIfError(
                Interop.Playlist.ForeachMediaFromDb(Id, handle, callback, IntPtr.Zero), "Failed to get media information");

            tcs.TrySetResult(mediaContents);
            return tcs.Task;
        }
    }
}
