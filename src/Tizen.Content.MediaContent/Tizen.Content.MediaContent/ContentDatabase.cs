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
/// <summary>
/// The Media Content API provides functions, enumerations used in the entire Content Service.
/// </summary>
/// <remarks>
/// The Media Content API provides functions and enumerations used in the entire Content Service.
/// The information about media items i.e.image, audio and video, are managed in the content database
/// and operations that involve database requires an active connection with the media content service.
/// During media scanning, Media Service extract media information automatically. media information
/// include basic file info like path, size, modified time etc and some metadata like ID3tag, EXIF,
/// thumbnail, etc. (thumbnail extracted only in Internal and SD card storage.
/// Media content services do not manage hidden files.
/// The API provides functions for connecting (media_content_connect()) and disconnecting(media_content_disconnect())
/// from the media content service.
/// </remarks>


namespace Tizen.Content.MediaContent
{
    /// <summary>
    /// ContentDatabase class is the interface class for managing the ContentCollection and MediaInformation from/to the database.
    /// This class allows usre to access/create/update db operations for media content.
    /// </summary>
    public class ContentDatabase
    {
        private bool _isConnected = false;
        internal ContentDatabase()
        {
        }
        internal void ConnectToDB()
        {
            if (!_isConnected)
            {
                MediaContentError err = (MediaContentError)Interop.Content.Connect();
                if (err != MediaContentError.None)
                {
                    throw MediaContentErrorFactory.CreateException(err, "failed to connect to db.");
                }
                _isConnected = true;
            }
        }
        private void DisconnectFromDB()
        {
            if (_isConnected)
            {
                MediaContentError err = (MediaContentError)Interop.Content.Disconnect();
                if (err != MediaContentError.None)
                {
                    throw MediaContentErrorFactory.CreateException(err, "failed to disconnect to db.");
                }
                _isConnected = false;
            }
        }

        private static readonly Interop.Content.MediaContentDBUpdatedCallback s_contentUpdatedCallback = (MediaContentError error, int pid, MediaContentUpdateItemType updateItem, MediaContentDBUpdateType updateType, MediaContentType mediaType, string uuid, string filePath, string mimeType, IntPtr userData) =>
        {
            ContentUpdatedEventArgs eventArgs = new ContentUpdatedEventArgs(error, pid, updateItem, updateType, mediaType, uuid, filePath, mimeType);
            s_contentUpdated?.Invoke(null, eventArgs);
        };
        private static event EventHandler<ContentUpdatedEventArgs> s_contentUpdated;
        /// <summary>
        /// ContentUpdated event is triggered when the media DB changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">A ContentUpdatedEventArgs object that contains information about the update operation.</param>
        public static event EventHandler<ContentUpdatedEventArgs> ContentUpdated
        {
            add
            {
                if (s_contentUpdated == null)
                {
                    MediaContentError ret = (MediaContentError)Interop.Content.SetDbUpdatedCb(s_contentUpdatedCallback, IntPtr.Zero);
                    if (ret != MediaContentError.None)
                    {
                        throw MediaContentErrorFactory.CreateException(ret, "Error in callback handling");
                    }
                }
                s_contentUpdated += value;
            }

            remove
            {
                s_contentUpdated -= value;
                if (s_contentUpdated == null)
                {
                    MediaContentError ret = (MediaContentError)Interop.Content.UnsetDbUpdatedCb();
                    if (ret != MediaContentError.None)
                    {
                        throw MediaContentErrorFactory.CreateException(ret, "Error in callback handling");
                    }
                }
            }
        }

        /// <summary>
        /// Gets the count of ContentCollections for the ContentCollectionType & passed filter from the media database.
        /// </summary>
        /// <param name="filter">The media filter</param>
        /// <returns>The count of contents present in the media database for a ContentSourceType</returns>
        public int GetCount<T>(ContentFilter filter) where T : class
        {
            int count = 0;
            IntPtr handle = (filter != null) ? filter.Handle : IntPtr.Zero;
            MediaContentError res = MediaContentError.None;
            MediaGroupType groupType = MediaGroupType.DisplayName;
            if (handle != IntPtr.Zero)
                groupType = filter.GroupType;

            ConnectToDB();

            if (typeof(T) == typeof(MediaInformation))
            {
                res = (MediaContentError)Interop.MediaInformation.GetMediaCount(handle, out count);
            }
            else if (typeof(T) == typeof(MediaBookmark))
            {
                res = (MediaContentError)Interop.MediaBookmark.GetBookmarkCountFromDb(handle, out count);
            }
            else if (typeof(T) == typeof(Album))
            {
                res = (MediaContentError)Interop.Group.MediaAlbumGetAlbumCountFromDb(handle, out count);
            }
            else if (typeof(T) == typeof(MediaFolder))
            {
                res = (MediaContentError)Interop.Folder.GetFolderCountFromDb(handle, out count);
            }
            else if (typeof(T) == typeof(Storage))
            {
                res = (MediaContentError)Interop.Storage.GetStorageCountFromDb(handle, out count);
            }
            else if (typeof(T) == typeof(Tag))
            {
                res = (MediaContentError)Interop.Tag.GetTagCountFromDb(handle, out count);
            }
            else if (typeof(T) == typeof(PlayList))
            {
                res = (MediaContentError)Interop.Playlist.GetPlaylistCountFromDb(handle, out count);
            }
            else if (typeof(T) == typeof(Group))
            {
                res = (MediaContentError)Interop.Group.GetGroupCountFromDb(handle, groupType, out count);
            }
            else
            {
                res = MediaContentError.InvalidParameter;
            }

            if (res != MediaContentError.None)
            {
                throw MediaContentErrorFactory.CreateException(res, "Failed to get count for the content");
            }
            return count;
        }

        /// <summary>
        /// Gets the MediaInformation object for the passed media Id.
        /// </summary>
        /// <param name="id">The media id to fetch the respective MediaInformation instance</param>
        /// <returns>MediaInformation instance for the associated id.It throws Exception for invalid Id.</returns>
        public MediaInformation Select(string id)
        {
            MediaContentError error = MediaContentError.None;
            ConnectToDB();
            MediaInformation result;
            Interop.MediaInformation.SafeMediaInformationHandle mediaHandle;
            error = (MediaContentError)Interop.MediaInformation.GetMediaFromDB(id, out mediaHandle);
            if (error != MediaContentError.None)
            {
                throw MediaContentErrorFactory.CreateException(error, "Failed to get the media information from the database");
            }
            result = new MediaInformation(mediaHandle);
            return result;
        }

        /// <summary>
        /// Gets the ContentCollection object for the passed media Id.
        /// Applicable for MediaFolder and Storage types.
        /// </summary>
        /// <param name="id">The ContentCollection id to fetch the respective MediaInformation instance</param>
        /// <returns>ContentCollection instance for the associated id.It throws Exception for invalid Id.</returns>
        public T Select<T>(string id) where T : ContentCollection
        {
            MediaContentError error = MediaContentError.None;
            ConnectToDB();
            ContentCollection result = null;
            if (typeof(T) == typeof(MediaFolder))
            {
                IntPtr handle = IntPtr.Zero;
                error = (MediaContentError)Interop.Folder.GetFolderFromDb(id, out handle);
                if (error != MediaContentError.None)
                {
                    throw MediaContentErrorFactory.CreateException(error, "Failed to get the content collection");
                }
                if (handle != IntPtr.Zero)
                    result = new MediaFolder(handle);
            }
            else if (typeof(T) == typeof(Storage))
            {
                IntPtr handle = IntPtr.Zero;
                error = (MediaContentError)Interop.Storage.GetStorageInfoFromDb(id, out handle);
                if (error != MediaContentError.None)
                {
                    throw MediaContentErrorFactory.CreateException(error, "Failed to get the content collection");
                }
                if (handle != IntPtr.Zero)
                {
                    result = new Storage(handle);
                }
            }
            return (result != null) ? (T)result : null;
        }


        /// <summary>
        /// Gets the ContentCollection object for the passed media Id.
        /// Applicable for PlayList, Album and Tag types.
        /// </summary>
        /// <param name="id">The ContentCollection id to fetch the respective MediaInformation instance</param>
        /// <returns>ContentCollection instance for the associated id.It throws Exception for invalid Id.</returns>
        public T Select<T>(int id) where T : ContentCollection
        {
            ConnectToDB();
            MediaContentError res = MediaContentError.None;
            ContentCollection contentCollection = null;
            IntPtr _handle;
            if (typeof(T) == typeof(PlayList))
            {
                res = (MediaContentError)Interop.Playlist.GetPlaylistFromDb(id, out _handle);
                if (res != MediaContentError.None)
                {
                    Log.Warn(Globals.LogTag, "Failed to get the content collection");
                    throw MediaContentErrorFactory.CreateException(res, "Failed to get the content collection");
                }
                if (_handle != IntPtr.Zero)
                    contentCollection = new PlayList(_handle);
            }
            else if (typeof(T) == typeof(Album))
            {
                res = (MediaContentError)Interop.Group.MediaAlbumGetAlbumFromDb(id, out _handle);
                if (res != MediaContentError.None)
                {
                    Log.Warn(Globals.LogTag, "Failed to get the content collection");
                    throw MediaContentErrorFactory.CreateException(res, "Failed to get the content collection");
                }
                if (_handle != IntPtr.Zero)
                    contentCollection = new Album(_handle);
            }
            else if (typeof(T) == typeof(Tag))
            {
                res = (MediaContentError)Interop.Tag.GetTagFromDb(id, out _handle);
                if (res != MediaContentError.None)
                {
                    Log.Warn(Globals.LogTag, "Failed to get the content collection");
                    throw MediaContentErrorFactory.CreateException(res, "Failed to get the content collection");
                }
                if (_handle != IntPtr.Zero)
                    contentCollection = new Tag(_handle);
            }
            return (contentCollection != null) ? (T)contentCollection : null;
        }

        private static IEnumerable<MediaFolder> ForEachFolder(ContentFilter filter)
        {
            MediaContentError res = MediaContentError.None;
            List<MediaFolder> folderCollections = new List<MediaFolder>();
            Interop.Folder.MediaFolderCallback folderCallback = (IntPtr folderHandle, IntPtr data) =>
            {
                IntPtr newHandle;
                res = (MediaContentError)Interop.Folder.Clone(out newHandle, folderHandle);
                if (res != MediaContentError.None)
                {
                    Log.Warn(MediaContentErrorFactory.LogTag, "Failed to get path for the MediaFolder " + res);
                }

                MediaFolder folder = new MediaFolder(newHandle);
                folderCollections.Add(folder);
                return true;
            };
            IntPtr filterHandle = filter != null ? filter.Handle : IntPtr.Zero;
            res = (MediaContentError)Interop.Folder.ForeachFolderFromDb(filterHandle, folderCallback, IntPtr.Zero);
            if (res != MediaContentError.None)
            {
                Log.Warn(Globals.LogTag, "Failed to get content collections from the database");
                throw MediaContentErrorFactory.CreateException(res, "Failed to get content collections from the database");
            }
            return folderCollections;
        }

        private static IEnumerable<Album> ForEachAlbum(ContentFilter filter)
        {
            MediaContentError res = MediaContentError.None;
            List<Album> albumCollections = new List<Album>();
            Interop.Group.MediaAlbumCallback albumCallback = (IntPtr albumHandle, IntPtr data) =>
            {
                IntPtr newHandle;
                res = (MediaContentError)Interop.Group.MediaAlbumClone(out newHandle, albumHandle);
                if (res != MediaContentError.None)
                {
                    Log.Warn(MediaContentErrorFactory.LogTag, "Failed to get path for the MediaFolder " + res);
                }

                albumCollections.Add(new Album(newHandle));
                return true;
            };
            IntPtr handle = (filter != null) ? filter.Handle : IntPtr.Zero;
            res = (MediaContentError)Interop.Group.MediaAlbumForeachAlbumFromDb(handle, albumCallback, IntPtr.Zero);
            if (res != MediaContentError.None)
            {
                Log.Warn(Globals.LogTag, "Failed to get content collections from the database");
                throw MediaContentErrorFactory.CreateException(res, "Failed to get content collections from the database");
            }
            return albumCollections;
        }

        private static IEnumerable<Group> ForEachGroup(ContentFilter filter)
        {
            IntPtr handle = (filter != null) ? filter.Handle : IntPtr.Zero;
            MediaGroupType groupType;
            if (filter == null)
            {
                groupType = MediaGroupType.DisplayName;
            }
            else {
                groupType = filter.GroupType;
            }
            MediaContentError res = MediaContentError.None;
            List<Group> groupCollections = new List<Group>();
            Interop.Group.MediaGroupCallback groupCallback = (string groupName, IntPtr data) =>
            {
                groupCollections.Add(new Group(groupName, groupType));
                return true;
            };
            res = (MediaContentError)Interop.Group.ForeachGroupFromDb(handle, groupType, groupCallback, IntPtr.Zero);
            if (res != MediaContentError.None)
            {
                Log.Warn(Globals.LogTag, "Failed to get content collections from the database");
                throw MediaContentErrorFactory.CreateException(res, "Failed to get content collections from the database");
            }
            return groupCollections;
        }

        private static IEnumerable<Storage> ForEachStorage(ContentFilter filter)
        {
            IntPtr handle = (filter != null) ? filter.Handle : IntPtr.Zero;
            MediaContentError res = MediaContentError.None;
            List<Storage> storageCollections = new List<Storage>();
            Interop.Storage.MediaStorageCallback storageCallback = (IntPtr storageHandle, IntPtr data) =>
            {
                IntPtr newHandle;
                res = (MediaContentError)Interop.Storage.Clone(out newHandle, storageHandle);
                if (res != MediaContentError.None)
                {
                    Log.Warn(Globals.LogTag, "Failed to clone storage handle");
                    throw MediaContentErrorFactory.CreateException(res, "Failed to clone storage handle");
                }
                storageCollections.Add(new Storage(newHandle));
                return true;
            };
            res = (MediaContentError)Interop.Storage.ForeachStorageFromDb(handle, storageCallback, IntPtr.Zero);
            if (res != MediaContentError.None)
            {
                Log.Warn(Globals.LogTag, "Failed to get content collections from the database");
                throw MediaContentErrorFactory.CreateException(res, "Failed to get content collections from the database");
            }
            return storageCollections;
        }

        private static IEnumerable<Tag> ForEachTag(ContentFilter filter)
        {
            IntPtr handle = (filter != null) ? filter.Handle : IntPtr.Zero;
            MediaContentError res = MediaContentError.None;
            List<Tag> tagCollections = new List<Tag>();
            Interop.Tag.MediaTagCallback tagCallback = (IntPtr tagHandle, IntPtr data) =>
            {
                IntPtr newHandle;
                res = (MediaContentError)Interop.Tag.Clone(out newHandle, tagHandle);
                if (res != MediaContentError.None)
                {
                    Log.Warn(MediaContentErrorFactory.LogTag, "Failed to get path for the MediaFolder " + res);
                }

                tagCollections.Add(new Tag(newHandle));
                return true;
            };
            res = (MediaContentError)Interop.Tag.ForeachTagFromDb(handle, tagCallback, IntPtr.Zero);
            if (res != MediaContentError.None)
            {
                Log.Warn(Globals.LogTag, "Failed to get content collections from the database");
                throw MediaContentErrorFactory.CreateException(res, "Failed to get content collections from the database");
            }
            return tagCollections;
        }

        private static IEnumerable<PlayList> ForEachPlayList(ContentFilter filter)
        {
            IntPtr handle = (filter != null) ? filter.Handle : IntPtr.Zero;
            MediaContentError res = MediaContentError.None;
            List<PlayList> playListCollections = new List<PlayList>();
            Interop.Playlist.MediaPlaylistCallback playListCallback = (IntPtr playListHandle, IntPtr data) =>
            {
                IntPtr newHandle;
                res = (MediaContentError)Interop.Tag.Clone(out newHandle, playListHandle);
                if (res != MediaContentError.None)
                {
                    Log.Warn(MediaContentErrorFactory.LogTag, "Failed to get path for the MediaFolder " + res);
                }

                playListCollections.Add(new PlayList(newHandle));
                return true;
            };
            res = (MediaContentError)Interop.Playlist.ForeachPlaylistFromDb(handle, playListCallback, IntPtr.Zero);
            if (res != MediaContentError.None)
            {
                Log.Warn(Globals.LogTag, "Failed to get content collections from the database");
                throw MediaContentErrorFactory.CreateException(res, "Failed to get content collections from the database");
            }
            return playListCollections;
        }

        /// <summary>
        /// Returns the ContentCollections with optional filter from the media database.
        /// </summary>
        /// <remarks>
        /// This function gets all ContentCollections matching the given filter. If NULL is passed to the filter, no filtering is applied.
        /// </remarks>
        /// <param name="filter">Filter for content items</param>
        /// <returns></returns>
        public Task<IEnumerable<T>> SelectAsync<T>(ContentFilter filter)
        {
            ConnectToDB();
            var task = new TaskCompletionSource<IEnumerable<T>>();
            if (typeof(T) == typeof(MediaInformation))
            {
                IEnumerable<MediaInformation> mediaList = GetMediaInformations(filter);
                task.TrySetResult((IEnumerable<T>)mediaList);
            }
            else if (typeof(T) == typeof(Album))
            {
                IEnumerable<Album> collectionList = ForEachAlbum(filter);
                task.TrySetResult((IEnumerable<T>)collectionList);
            }
            else if (typeof(T) == typeof(MediaFolder))
            {
                IEnumerable<MediaFolder> collectionList = ForEachFolder(filter);
                task.TrySetResult((IEnumerable<T>)collectionList);
            }
            else if (typeof(T) == typeof(Group))
            {
                IEnumerable<Group> collectionList = ForEachGroup(filter);
                task.TrySetResult((IEnumerable<T>)collectionList);
            }
            else if (typeof(T) == typeof(Storage))
            {
                IEnumerable<Storage> collectionList = ForEachStorage(filter);
                task.TrySetResult((IEnumerable<T>)collectionList);
            }
            else if (typeof(T) == typeof(Tag))
            {
                IEnumerable<Tag> collectionList = ForEachTag(filter);
                task.TrySetResult((IEnumerable<T>)collectionList);
            }
            else if (typeof(T) == typeof(PlayList))
            {
                IEnumerable<PlayList> collectionList = ForEachPlayList(filter);
                task.TrySetResult((IEnumerable<T>)collectionList);
            }
            return task.Task;
        }

        /// <summary>
        /// Returns media from the media database.
        /// This function gets all media meeting the given filter
        /// </summary>
        /// <param name="filter">The media filter</param>
        /// <returns>List of media</returns>
        private IEnumerable<MediaInformation> GetMediaInformations(ContentFilter filter)
        {
            ConnectToDB();
            MediaContentError result;
            IntPtr handle = (filter != null) ? filter.Handle : IntPtr.Zero;
            List<MediaInformation> mediaInformationList = new List<MediaInformation>();
            Interop.MediaInformation.MediaInformationCallback callback = (IntPtr mediaHandle, IntPtr userData) =>
            {
                Interop.MediaInformation.SafeMediaInformationHandle newHandle;
                result = (MediaContentError)Interop.MediaInformation.Clone(out newHandle, mediaHandle);
                if (result != MediaContentError.None)
                {
                    throw MediaContentErrorFactory.CreateException(result, "Failed to clone media");
                }

                MediaContentType type;
                Interop.MediaInformation.GetMediaType(newHandle, out type);
                if (type == MediaContentType.Image)
                {
                    Interop.ImageInformation.SafeImageInformationHandle imageInfo;
                    result = (MediaContentError)Interop.MediaInformation.GetImage(mediaHandle, out imageInfo);
                    if (result != MediaContentError.None)
                    {
                        Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                    }
                    if (imageInfo != null)
                    {
                        MediaInformation info = new ImageInformation(imageInfo, newHandle);
                        mediaInformationList.Add(info);
                    }
                    else
                    {
                        throw MediaContentErrorFactory.CreateException(MediaContentError.InvalidParameter, "Could not find the Image Information");
                    }
                }
                else if ((type == MediaContentType.Music) || (type == MediaContentType.Sound))
                {
                    Interop.AudioInformation.SafeAudioInformationHandle audioInfo;
                    result = (MediaContentError)Interop.MediaInformation.GetAudio(mediaHandle, out audioInfo);
                    if (result != MediaContentError.None)
                    {
                        Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                    }
                    if (audioInfo != null)
                    {
                        MediaInformation info = new AudioInformation(audioInfo, newHandle);
                        mediaInformationList.Add(info);
                    }
                    else
                    {
                        throw MediaContentErrorFactory.CreateException(MediaContentError.InvalidParameter, "Could not find the Audio Information");
                    }
                }
                else if (type == MediaContentType.Video)
                {
                    Interop.VideoInformation.SafeVideoInformationHandle audioInfo;
                    result = (MediaContentError)Interop.MediaInformation.GetVideo(mediaHandle, out audioInfo);
                    if (result != MediaContentError.None)
                    {
                        Log.Error(Globals.LogTag, "Error Occured with error code: " + (MediaContentError)result);
                    }
                    if (audioInfo != null)
                    {
                        MediaInformation info = new VideoInformation(audioInfo, newHandle);
                        mediaInformationList.Add(info);
                    }
                    else
                    {
                        throw MediaContentErrorFactory.CreateException(MediaContentError.InvalidParameter, "Could not find the Audio Information");
                    }
                }
                else if (type == MediaContentType.Others)
                {
                    MediaInformation info = new MediaInformation(newHandle);
                    mediaInformationList.Add(info);
                }
                return true;
            };
            result = (MediaContentError)Interop.MediaInformation.GetAllMedia(handle, callback, IntPtr.Zero);
            if (result != MediaContentError.None)
            {
                Log.Error(Globals.LogTag, "Failed to get media information from the database");
            }
            return mediaInformationList;
        }

        /// <summary>
        /// Deletes a MediaInformation from the media database.
        /// </summary>
        /// <param name="mediaInfo">The MediaInformation to be deleted</param>
        public void Delete(MediaInformation mediaInfo)
        {
            ConnectToDB();
            MediaContentError result = (MediaContentError)Interop.MediaInformation.Delete(mediaInfo.MediaId);
            if (result != MediaContentError.None)
                throw MediaContentErrorFactory.CreateException(result, "failed to Delete bookmark from DB");
        }


        /// <summary>
        /// Deletes a content collection from the media database.
        /// Applicable for Tag and PlayList only.
        /// For other types ArgumentException is thrown.
        /// </summary>
        /// <param name="contentcollection">The ContentCollection instance to be deleted</param>
        public void Delete(ContentCollection contentcollection)
        {
            ConnectToDB();
            Type type = contentcollection.GetType();
            MediaContentError result = MediaContentError.None;
            if (type == typeof(Tag))
            {
                result = (MediaContentError)Interop.Tag.DeleteFromDb(((Tag)contentcollection).Id);
            }
            else if (type == typeof(PlayList))
            {
                result = (MediaContentError)Interop.Playlist.DeleteFromDb(((PlayList)contentcollection).Id);
            }
            else
            {
                result = MediaContentError.InvalidParameter;
            }
            if (result != MediaContentError.None)
                throw MediaContentErrorFactory.CreateException(result, "failed to Delete ContentCollection from DB");
        }

        internal void Delete(MediaBookmark bookmark)
        {
            ConnectToDB();
            MediaContentError result = MediaContentError.None;
            result = (MediaContentError)Interop.MediaBookmark.DeleteFromDb(bookmark.Id);
            if (result != MediaContentError.None)
                throw MediaContentErrorFactory.CreateException(result, "failed to Delete bookmark from DB");
        }

        internal void Delete(MediaFace face)
        {
            ConnectToDB();
            MediaContentError result = MediaContentError.None;
            result = (MediaContentError)Interop.Face.DeleteFromDb(face.Id);
            if (result != MediaContentError.None)
                throw MediaContentErrorFactory.CreateException(result, "failed to Delete face from DB");
        }

        /// <summary>
        /// Updates a content collection in the media database
        /// Applicable for Tag, PlayList and MediagFolder types only.
        /// </summary>
        /// <param name="contentCollection">The content collection to be updated</param>
        public void Update(ContentCollection contentCollection)
        {
            ConnectToDB();
            Type type = contentCollection.GetType();
            MediaContentError result = MediaContentError.None;
            if (type == typeof(Tag))
            {
                result = (MediaContentError)Interop.Tag.UpdateToDb(((Tag)contentCollection).Handle);
            }
            else if (type == typeof(PlayList))
            {
                result = (MediaContentError)Interop.Playlist.UpdateToDb(((PlayList)contentCollection).Handle);
            }
            else if (type == typeof(MediaFolder))
            {
                result = (MediaContentError)Interop.Folder.UpdateToDb(((MediaFolder)contentCollection).Handle);
            }
            else
            {
                result = MediaContentError.InvalidParameter;
            }

            if (result != MediaContentError.None)
                throw MediaContentErrorFactory.CreateException(result, "Failed to update DB");
        }

        /// <summary>
        /// Updates a media information instance in the media database
        /// </summary>
        /// <param name="mediaInfo">The MediaInformation object to be updated</param>
        public void Update(MediaInformation mediaInfo)
        {
            ConnectToDB();
            Type type = mediaInfo.GetType();
            MediaContentError result = MediaContentError.None;
            if (type == typeof(ImageInformation))
            {
                result = (MediaContentError)Interop.ImageInformation.UpdateToDB(((ImageInformation)mediaInfo).ImageHandle);
            }
            else if (type == typeof(AudioInformation))
            {
                result = (MediaContentError)Interop.AudioInformation.UpdateToDB(((AudioInformation)mediaInfo).AudioHandle);
            }
            else if (type == typeof(VideoInformation))
            {
                result = (MediaContentError)Interop.VideoInformation.UpdateToDB(((VideoInformation)mediaInfo).VideoHandle);
            }
            else if (type == typeof(MediaInformation))
            {
                result = (MediaContentError)Interop.MediaInformation.UpdateToDB(((MediaInformation)mediaInfo).MediaHandle);
            }
            else
            {
                result = MediaContentError.InvalidOperation;
            }

            if (result != MediaContentError.None)
                throw MediaContentErrorFactory.CreateException(result, "Failed to update DB");
        }

        internal void Update(MediaFace face)
        {
            ConnectToDB();

            MediaContentError result = (MediaContentError)Interop.Face.UpdateToDb(face.Handle);
            if (result != MediaContentError.None)
                throw MediaContentErrorFactory.CreateException(result, "Failed to update DB");
        }

        /// <summary>
        /// Inserts a content collection to the media database.
        /// Applicable for Tag and PlayList types only.
        /// </summary>
        /// <param name="contentCollection">The content collection to be inserted</param>
        public void Insert(ContentCollection contentCollection)
        {
            ConnectToDB();
            Type type = contentCollection.GetType();
            MediaContentError result = MediaContentError.None;
            IntPtr handle = IntPtr.Zero;
            if (type == typeof(Tag))
            {
                result = (MediaContentError)Interop.Tag.InsertToDb(((Tag)contentCollection).Name, out handle);
                ((Tag)contentCollection).Handle = handle;
            }
            else if (type == typeof(PlayList))
            {
                Console.WriteLine("Playlist insert");
                result = (MediaContentError)Interop.Playlist.InsertToDb(((PlayList)contentCollection).Name, out handle);
                ((PlayList)contentCollection).Handle = handle;
            }
            else
            {
                Console.WriteLine("Inalid insert");
                result = MediaContentError.InvalidParameter;
            }
            if (result != MediaContentError.None)
            {
                throw MediaContentErrorFactory.CreateException(result, "Failed to insert collection to the database");
            }
        }

        internal void Insert(string mediaId, uint offset, string thumbnailPath)
        {
            ConnectToDB();
            MediaContentError result = (MediaContentError)Interop.MediaBookmark.InsertToDb(mediaId, offset, thumbnailPath);
            if (result != MediaContentError.None)
            {
                throw MediaContentErrorFactory.CreateException(result, "Failed to insert bookmark to the database");
            }
        }

        internal void Insert(MediaFace face)
        {
            ConnectToDB();
            MediaContentError result = (MediaContentError)Interop.Face.InsertToDb(((MediaFace)face).Handle);
            if (result != MediaContentError.None)
            {
                throw MediaContentErrorFactory.CreateException(result, "Failed to insert collection to the database");
            }
        }
    }
}
