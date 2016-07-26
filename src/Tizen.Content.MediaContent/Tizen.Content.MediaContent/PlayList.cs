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
            MediaContentError res;
            Interop.Playlist.PlaylistMemberCallback callback = (int memberId, IntPtr mediaHandle, IntPtr data) =>
            {
                Interop.MediaInformation.SafeMediaInformationHandle newHandle;
                res = (MediaContentError)Interop.MediaInformation.Clone(out newHandle, mediaHandle);
                if (res != MediaContentError.None)
                {
                    throw MediaContentErrorFactory.CreateException(res, "Failed to clone media");
                }
                string mediaId;
                Interop.MediaInformation.GetMediaId(newHandle, out mediaId);
                _dictionary.Add(mediaId, memberId);
                return true;
            };
            res = (MediaContentError)Interop.Playlist.ForeachMediaFromDb(Id, IntPtr.Zero, callback, IntPtr.Zero);
            if (res != MediaContentError.None)
            {
                throw MediaContentErrorFactory.CreateException(res, "Failed to get playlist items");
            }
        }

        /// <summary>
        /// The ID of the media playlist
        /// </summary>
        public int Id
        {
            get
            {
                int id;
                MediaContentError res = (MediaContentError)Interop.Playlist.GetPlaylistId(_playlistHandle, out id);
                if (res != MediaContentError.None)
                {
                    Log.Warn(MediaContentErrorFactory.LogTag, "Failed to get Id for the PlayList");
                }
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
                MediaContentError res = (MediaContentError)Interop.Playlist.SetName(_playlistHandle, value);
                if (res == MediaContentError.None)
                {
                    _playListName = value;
                }
                else
                {
                    Log.Warn(MediaContentErrorFactory.LogTag, "Failed to set Name for the PlayList");
                }
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
                MediaContentError res = (MediaContentError)Interop.Playlist.GetThumbnailPath(_playlistHandle, out path);
                if (res != MediaContentError.None)
                {
                    Log.Warn(MediaContentErrorFactory.LogTag, "Failed to get Thumbnail Path for the PlayList");
                }
                return path;
            }
            set
            {
                MediaContentError res = (MediaContentError)Interop.Playlist.SetThumbnailPath(_playlistHandle, value);
                if (res != MediaContentError.None)
                {
                    Log.Warn(MediaContentErrorFactory.LogTag, "Failed to set Thumbnail Path for the PlayList");
                }
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
            MediaContentError res = (MediaContentError)Interop.Playlist.GetName(handle, out _playListName);
            if (res != MediaContentError.None)
            {
                Log.Warn(MediaContentErrorFactory.LogTag, "Failed to get Name for the PlayList");
            }
        }

        /// <summary>
        /// Adds a new media info to the playlist.
        /// </summary>
        /// <param name="mediaContent">The AudioContent obect to be added</param>
        public void AddItem(MediaInformation mediaContent)
        {
            MediaContentError res = (MediaContentError)Interop.Playlist.AddMedia(_playlistHandle, mediaContent.MediaId);
            if (res != MediaContentError.None)
            {
                //TODO improve the error message once media content is implemented
                throw MediaContentErrorFactory.CreateException(res, "Failed to add media content to the playlist");
            }
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
            MediaContentError res = (MediaContentError)Interop.Playlist.RemoveMedia(_playlistHandle, memberId);
            if (res != MediaContentError.None)
            {
                throw MediaContentErrorFactory.CreateException(res, "Failed to remove media content from the playlist");
            }
        }

        /// <summary>
        /// Sets the playing order in the playlist.
        /// </summary>
        /// <param name="media">The playlist reference</param>
        /// <param name="playOrder">The playing order</param>
        public void SetPlayOrder(MediaInformation media, int playOrder)
        {
            Tizen.Log.Info("TCT", "Order set for Media Id: " + media.MediaId);
            int memberId;
            refreshPlaylistDictionary();
            _dictionary.TryGetValue(media.MediaId, out memberId);
            Tizen.Log.Info("TCT", "Order set for member Id: " + memberId);
            MediaContentError res = (MediaContentError)Interop.Playlist.SetPlayOrder(_playlistHandle, memberId, playOrder);
            if (res != MediaContentError.None)
            {
                throw MediaContentErrorFactory.CreateException(res, "Failed to set play order for the playlist member " + memberId);
            }
        }

        /// <summary>
        /// Gets the playing order in the playlist for the passed member id.
        /// </summary>
        /// <param name="media"></param>
        public int GetPlayOrder(MediaInformation media)
        {
            Tizen.Log.Info("TCT", "Getting order for Media Id: " + media.MediaId);
            int playOrder;
            int memberId;
            refreshPlaylistDictionary();
            _dictionary.TryGetValue(media.MediaId, out memberId);
            Tizen.Log.Info("TCT", "Order get for Member Id: " + memberId);
            MediaContentError res = (MediaContentError)Interop.Playlist.GetPlayOrder(_playlistHandle, memberId, out playOrder);
            if (res != MediaContentError.None)
            {
                throw MediaContentErrorFactory.CreateException(res, "Failed to get play order for the playlist member " + memberId);
            }
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

            MediaContentError res = (MediaContentError)Interop.Playlist.ImportFromFile(name, filePath, out playlistHandle);
            if (res != MediaContentError.None)
            {
                throw MediaContentErrorFactory.CreateException(res, "Failed to import playlist  " + name + " from " + filePath);
            }
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
            MediaContentError res = (MediaContentError)Interop.Playlist.ExportToFile(list.Handle, filePath);
            if (res != MediaContentError.None)
            {
                throw MediaContentErrorFactory.CreateException(res, "Failed to export playlist  " + list.Name + " to " + filePath);
            }
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
            MediaContentError res = (MediaContentError)Interop.Playlist.GetMediaCountFromDb(Id, handle, out mediaCount);
            if (res != MediaContentError.None)
            {
                throw MediaContentErrorFactory.CreateException(res, "Failed to get media count for the playlist");
            }
            return mediaCount;
        }

        public override void Dispose()
        {
            MediaContentError res = (MediaContentError)Interop.Playlist.Destroy(_playlistHandle);
            _playlistHandle = IntPtr.Zero;
            if (res != MediaContentError.None)
            {
                throw MediaContentErrorFactory.CreateException(res, "Failed to dispose the playlist");
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
            MediaContentError res;
            Interop.Playlist.PlaylistMemberCallback callback = (int memberId, IntPtr mediaHandle, IntPtr data) =>
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
            res = (MediaContentError)Interop.Playlist.ForeachMediaFromDb(Id, handle, callback, IntPtr.Zero);
            if (res != MediaContentError.None)
            {
                throw MediaContentErrorFactory.CreateException(res, "Failed to get media information for the playlist");
            }
            tcs.TrySetResult(mediaContents);
            return tcs.Task;
        }
    }
}
