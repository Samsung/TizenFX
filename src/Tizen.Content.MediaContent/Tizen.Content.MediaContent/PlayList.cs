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
                return _playlistHandle;
            }
            set
            {
                _playlistHandle = value;
            }
        }

        private void refreshPlaylistDictionary()
        {
            _dictionary.Clear();
            Interop.Playlist.PlaylistMemberCallback callback = (int memberId, IntPtr mediaHandle, IntPtr data) =>
            {
                Interop.MediaInformation.SafeMediaInformationHandle newHandle;
                MediaContentRetValidator.ThrowIfError(
                    Interop.MediaInformation.Clone(out newHandle, mediaHandle), "Failed to clone media");

                string mediaId;
                Interop.MediaInformation.GetMediaId(newHandle, out mediaId);
                _dictionary.Add(mediaId, memberId);
                return true;
            };
            MediaContentRetValidator.ThrowIfError(
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
                MediaContentRetValidator.ThrowIfError(
                    Interop.Playlist.GetPlaylistId(_playlistHandle, out id), "Failed to get value");

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
                MediaContentRetValidator.ThrowIfError(
                    Interop.Playlist.SetName(_playlistHandle, value), "Failed to set value");
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
                string path;
                MediaContentRetValidator.ThrowIfError(
                    Interop.Playlist.GetThumbnailPath(_playlistHandle, out path), "Failed to get value");
                return path;
            }
            set
            {
                MediaContentRetValidator.ThrowIfError(
                    Interop.Playlist.SetThumbnailPath(_playlistHandle, value), "Failed to set value");
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
            MediaContentRetValidator.ThrowIfError(
                Interop.Playlist.GetName(handle, out _playListName), "Failed to get value");
        }

        /// <summary>
        /// Adds a new media info to the playlist.
        /// </summary>
        /// <param name="mediaContent">The AudioContent obect to be added</param>
        public void AddItem(MediaInformation mediaContent)
        {
            MediaContentRetValidator.ThrowIfError(
                Interop.Playlist.AddMedia(_playlistHandle, mediaContent.MediaId), "Failed to add item");
        }

        /// <summary>
        /// Removes the playlist members related with the media from the given playlist.
        /// </summary>
        /// <param name="media">The AudioContent object to be removed</param>
        public void RemoveItem(MediaInformation media)
        {
            int memberId = 0;
            refreshPlaylistDictionary();
            _dictionary.TryGetValue(media.MediaId, out memberId);
            MediaContentRetValidator.ThrowIfError(
                Interop.Playlist.RemoveMedia(_playlistHandle, memberId), "Failed to remove item");
        }

        /// <summary>
        /// Sets the playing order in the playlist.
        /// </summary>
        /// <param name="media">The playlist reference</param>
        /// <param name="playOrder">The playing order</param>
        public void SetPlayOrder(MediaInformation media, int playOrder)
        {
            int memberId;
            refreshPlaylistDictionary();
            _dictionary.TryGetValue(media.MediaId, out memberId);
            MediaContentRetValidator.ThrowIfError(
                Interop.Playlist.SetPlayOrder(_playlistHandle, memberId, playOrder), "Failed to set play order");
        }

        /// <summary>
        /// Gets the playing order in the playlist for the passed member id.
        /// </summary>
        /// <param name="media"></param>
        public int GetPlayOrder(MediaInformation media)
        {
            int playOrder;
            int memberId;
            refreshPlaylistDictionary();
            _dictionary.TryGetValue(media.MediaId, out memberId);
            MediaContentRetValidator.ThrowIfError(
                Interop.Playlist.GetPlayOrder(_playlistHandle, memberId, out playOrder), "Failed to get play order");

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

            MediaContentRetValidator.ThrowIfError(
                Interop.Playlist.ImportFromFile(name, filePath, out playlistHandle), "Failed to import");

            playList = new PlayList(name);
            playList._playlistHandle = playlistHandle;
            return playList;
        }

        /// <summary>
        /// Exports the playlist to m3u playlist file.
        /// </summary>
        /// <returns>path The path to export the playlist</returns>
        public static void Export(PlayList list, string filePath)
        {
            MediaContentRetValidator.ThrowIfError(
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
            MediaContentRetValidator.ThrowIfError(
                Interop.Playlist.GetMediaCountFromDb(Id, handle, out mediaCount), "Failed to get media count");

            return mediaCount;
        }

        public override void Dispose()
        {
            if (_playlistHandle != IntPtr.Zero) {
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
                MediaContentRetValidator.ThrowIfError(
                    Interop.MediaInformation.Clone(out newHandle, mediaHandle), "Failed to clone media");

                mediaContents.Add(new MediaInformation(newHandle));
                return true;
            };
            MediaContentRetValidator.ThrowIfError(
                Interop.Playlist.ForeachMediaFromDb(Id, handle, callback, IntPtr.Zero), "Failed to get media information");

            tcs.TrySetResult(mediaContents);
            return tcs.Task;
        }
    }
}
