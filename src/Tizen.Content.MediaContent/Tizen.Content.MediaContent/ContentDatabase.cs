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
                MediaContentValidator.ThrowIfError(Interop.Content.Connect(), "Connect failed");

                _isConnected = true;
            }
        }

        private void DisconnectFromDB()
        {
            if (_isConnected)
            {
                MediaContentValidator.ThrowIfError(Interop.Content.Disconnect(), "Disconnect failed");

                _isConnected = false;
            }
        }

        private static readonly Interop.Content.MediaContentDBUpdatedCallback s_contentUpdatedCallback = (
            MediaContentError error,
            int pid,
            MediaContentUpdateItemType updateItem,
            MediaContentDBUpdateType updateType,
            MediaContentType mediaType,
            string uuid,
            string filePath,
            string mimeType,
            IntPtr userData) =>
        {
            _contentUpdated?.Invoke(
                null, new ContentUpdatedEventArgs(error, pid, updateItem, updateType, mediaType, uuid, filePath, mimeType));
        };

        private static event EventHandler<ContentUpdatedEventArgs> _contentUpdated;
        /// <summary>
        /// ContentUpdated event is triggered when the media DB changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">A ContentUpdatedEventArgs object that contains information about the update operation.</param>
        public static event EventHandler<ContentUpdatedEventArgs> ContentUpdated
        {
            add
            {
                if (_contentUpdated == null)
                {
                    MediaContentValidator.ThrowIfError(
                        Interop.Content.SetDbUpdatedCb(s_contentUpdatedCallback, IntPtr.Zero), "Failed to set callback");
                }

                _contentUpdated += value;
            }

            remove
            {
                _contentUpdated -= value;
                if (_contentUpdated == null)
                {
                    MediaContentValidator.ThrowIfError(
                        Interop.Content.UnsetDbUpdatedCb(), "Failed to unset callback");
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
            MediaGroupType groupType = MediaGroupType.DisplayName;
            if (handle != IntPtr.Zero)
            {
                groupType = filter.GroupType;
            }

            ConnectToDB();

            if (typeof(T) == typeof(MediaInformation))
            {
                MediaContentValidator.ThrowIfError(
                    Interop.MediaInformation.GetMediaCount(handle, out count), "Failed to get count");
            }
            else if (typeof(T) == typeof(MediaBookmark))
            {
                MediaContentValidator.ThrowIfError(
                    Interop.MediaBookmark.GetBookmarkCountFromDb(handle, out count), "Failed to get count");
            }
            else if (typeof(T) == typeof(Album))
            {
                MediaContentValidator.ThrowIfError(
                    Interop.Group.MediaAlbumGetAlbumCountFromDb(handle, out count), "Failed to get count");
            }
            else if (typeof(T) == typeof(MediaFolder))
            {
                MediaContentValidator.ThrowIfError(
                    Interop.Folder.GetFolderCountFromDb(handle, out count), "Failed to get count");
            }
            else if (typeof(T) == typeof(Storage))
            {
                MediaContentValidator.ThrowIfError(
                    Interop.Storage.GetStorageCountFromDb(handle, out count), "Failed to get count");
            }
            else if (typeof(T) == typeof(Tag))
            {
                MediaContentValidator.ThrowIfError(
                    Interop.Tag.GetTagCountFromDb(handle, out count), "Failed to get count");
            }
            else if (typeof(T) == typeof(PlayList))
            {
                MediaContentValidator.ThrowIfError(
                    Interop.Playlist.GetPlaylistCountFromDb(handle, out count), "Failed to get count");
            }
            else if (typeof(T) == typeof(Group))
            {
                MediaContentValidator.ThrowIfError(
                    Interop.Group.GetGroupCountFromDb(handle, groupType, out count), "Failed to get count");
            }
            else
            {
                throw new ArgumentException("Wrong type");
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
            ConnectToDB();
            Interop.MediaInformation.SafeMediaInformationHandle mediaHandle;
            MediaContentValidator.ThrowIfError(
                Interop.MediaInformation.GetMediaFromDB(id, out mediaHandle), "Failed to get information");

            MediaContentType type;
            MediaInformation res;
            Interop.MediaInformation.GetMediaType(mediaHandle, out type);
            if (type == MediaContentType.Image)
            {
                Interop.ImageInformation.SafeImageInformationHandle imageInfo;
                MediaContentValidator.ThrowIfError(
                    Interop.MediaInformation.GetImage(mediaHandle.DangerousGetHandle(), out imageInfo), "Failed to get image information");

                res = new ImageInformation(imageInfo, mediaHandle);
            }
            else if ((type == MediaContentType.Music) || (type == MediaContentType.Sound))
            {
                Interop.AudioInformation.SafeAudioInformationHandle audioInfo;
                MediaContentValidator.ThrowIfError(
                    Interop.MediaInformation.GetAudio(mediaHandle.DangerousGetHandle(), out audioInfo), "Failed to get audio information");

                res = new AudioInformation(audioInfo, mediaHandle);
            }
            else if (type == MediaContentType.Video)
            {
                Interop.VideoInformation.SafeVideoInformationHandle videoInfo;
                MediaContentValidator.ThrowIfError(
                    Interop.MediaInformation.GetVideo(mediaHandle.DangerousGetHandle(), out videoInfo), "Failed to get video information");

                res = new VideoInformation(videoInfo, mediaHandle);
            }
            else
            {
                res = new MediaInformation(mediaHandle);
            }

            return res;
        }

        /// <summary>
        /// Gets the ContentCollection object for the passed media Id.
        /// Applicable for MediaFolder and Storage types.
        /// </summary>
        /// <param name="id">The ContentCollection id to fetch the respective MediaInformation instance</param>
        /// <returns>ContentCollection instance for the associated id.It throws Exception for invalid Id.</returns>
        public T Select<T>(string id) where T : ContentCollection
        {
            ConnectToDB();
            ContentCollection result = null;
            IntPtr handle = IntPtr.Zero;

            if (typeof(T) == typeof(MediaFolder))
            {
                MediaContentValidator.ThrowIfError(
                    Interop.Folder.GetFolderFromDb(id, out handle), "Failed to get information");

                if (handle != IntPtr.Zero)
                {
                    result = new MediaFolder(handle);
                    return (T)result;
                }

            }
            else if (typeof(T) == typeof(Storage))
            {
                MediaContentValidator.ThrowIfError(
                    Interop.Storage.GetStorageInfoFromDb(id, out handle), "Failed to get information");

                if (handle != IntPtr.Zero)
                {
                    result = new Storage(handle);
                    return (T)result;
                }
            }

            return null;
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
            ContentCollection result = null;
            IntPtr handle = IntPtr.Zero;

            if (typeof(T) == typeof(PlayList))
            {
                MediaContentValidator.ThrowIfError(
                    Interop.Playlist.GetPlaylistFromDb(id, out handle), "Failed to get information");

                if (handle != IntPtr.Zero)
                {
                    result = new PlayList(handle);
                    return (T)result;
                }
            }
            else if (typeof(T) == typeof(Album))
            {
                MediaContentValidator.ThrowIfError(
                Interop.Group.MediaAlbumGetAlbumFromDb(id, out handle), "Failed to get information");

                if (handle != IntPtr.Zero)
                {
                    result = new Album(handle);
                    return (T)result;
                }
            }
            else if (typeof(T) == typeof(Tag))
            {
                MediaContentValidator.ThrowIfError(
                    Interop.Tag.GetTagFromDb(id, out handle), "Failed to get information");

                if (handle != IntPtr.Zero)
                {
                    result = new Tag(handle);
                    return (T)result;
                }
            }

            return null;
        }

        private static IEnumerable<MediaFolder> ForEachFolder(ContentFilter filter)
        {
            List<MediaFolder> result = new List<MediaFolder>();
            Interop.Folder.MediaFolderCallback callback = (IntPtr handle, IntPtr data) =>
            {
                IntPtr newHandle = IntPtr.Zero;
                MediaContentValidator.ThrowIfError(
                    Interop.Folder.Clone(out newHandle, handle), "Failed to clone");

                result.Add(new MediaFolder(newHandle));
                return true;
            };
            IntPtr filterHandle = filter != null ? filter.Handle : IntPtr.Zero;
            MediaContentValidator.ThrowIfError(
                Interop.Folder.ForeachFolderFromDb(filterHandle, callback, IntPtr.Zero), "Failed to get information");

            return result;
        }

        private static IEnumerable<Album> ForEachAlbum(ContentFilter filter)
        {
            List<Album> result = new List<Album>();
            Interop.Group.MediaAlbumCallback callback = (IntPtr handle, IntPtr data) =>
            {
                IntPtr newHandle = IntPtr.Zero;
                MediaContentValidator.ThrowIfError(
                    Interop.Group.MediaAlbumClone(out newHandle, handle), "Failed to clone");

                result.Add(new Album(newHandle));
                return true;
            };
            IntPtr filterHandle = (filter != null) ? filter.Handle : IntPtr.Zero;
            MediaContentValidator.ThrowIfError(
                Interop.Group.MediaAlbumForeachAlbumFromDb(filterHandle, callback, IntPtr.Zero), "Failed to get information");

            return result;
        }

        private static IEnumerable<Group> ForEachGroup(ContentFilter filter)
        {
            IntPtr handle = (filter != null) ? filter.Handle : IntPtr.Zero;
            MediaGroupType groupType;
            if (filter == null)
            {
                groupType = MediaGroupType.DisplayName;
            }
            else
            {
                groupType = filter.GroupType;
            }

            List<Group> result = new List<Group>();
            Interop.Group.MediaGroupCallback callback = (string groupName, IntPtr data) =>
            {
                result.Add(new Group(groupName, groupType));
                return true;
            };
            MediaContentValidator.ThrowIfError(
                Interop.Group.ForeachGroupFromDb(handle, groupType, callback, IntPtr.Zero), "Failed to get information");

            return result;
        }

        private static IEnumerable<Storage> ForEachStorage(ContentFilter filter)
        {
            IntPtr handle = (filter != null) ? filter.Handle : IntPtr.Zero;
            List<Storage> result = new List<Storage>();
            Interop.Storage.MediaStorageCallback callback = (IntPtr storageHandle, IntPtr data) =>
            {
                IntPtr newHandle = IntPtr.Zero;
                MediaContentValidator.ThrowIfError(
                    Interop.Storage.Clone(out newHandle, storageHandle), "Failed to clone");

                result.Add(new Storage(newHandle));
                return true;
            };
            MediaContentValidator.ThrowIfError(
                Interop.Storage.ForeachStorageFromDb(handle, callback, IntPtr.Zero), "Failed to get information");

            return result;
        }

        private static IEnumerable<Tag> ForEachTag(ContentFilter filter)
        {
            IntPtr handle = (filter != null) ? filter.Handle : IntPtr.Zero;

            List<Tag> result = new List<Tag>();
            Interop.Tag.MediaTagCallback callback = (IntPtr tagHandle, IntPtr data) =>
            {
                IntPtr newHandle = IntPtr.Zero;
                MediaContentValidator.ThrowIfError(
                    Interop.Tag.Clone(out newHandle, tagHandle), "Failed to clone");

                result.Add(new Tag(newHandle));
                return true;
            };
            MediaContentValidator.ThrowIfError(
                Interop.Tag.ForeachTagFromDb(handle, callback, IntPtr.Zero), "Failed to get information");

            return result;
        }

        private static IEnumerable<PlayList> ForEachPlayList(ContentFilter filter)
        {
            IntPtr handle = (filter != null) ? filter.Handle : IntPtr.Zero;

            List<PlayList> result = new List<PlayList>();
            Interop.Playlist.MediaPlaylistCallback callback = (IntPtr playListHandle, IntPtr data) =>
            {
                IntPtr newHandle = IntPtr.Zero;
                MediaContentValidator.ThrowIfError(
                    Interop.Playlist.Clone(out newHandle, playListHandle), "Failed to clone");

                result.Add(new PlayList(newHandle));
                return true;
            };
            MediaContentValidator.ThrowIfError(
                Interop.Playlist.ForeachPlaylistFromDb(handle, callback, IntPtr.Zero), "Failed to get information");

            return result;
        }

        /// <summary>
        /// Returns the ContentCollections with optional filter from the media database.
        /// </summary>
        /// <remarks>
        /// This function gets all ContentCollections matching the given filter. If NULL is passed to the filter, no filtering is applied.
        /// </remarks>
        /// <param name="filter">Filter for content items</param>
        /// <returns>
        /// Task with the list of the ContentCollection
        /// </returns>
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
            IntPtr handle = (filter != null) ? filter.Handle : IntPtr.Zero;
            List<MediaInformation> mediaInformationList = new List<MediaInformation>();
            Interop.MediaInformation.MediaInformationCallback callback = (IntPtr mediaHandle, IntPtr userData) =>
            {
                Interop.MediaInformation.SafeMediaInformationHandle newHandle;
                MediaContentValidator.ThrowIfError(
                Interop.MediaInformation.Clone(out newHandle, mediaHandle), "Failed to clone");

                MediaContentType type;
                Interop.MediaInformation.GetMediaType(newHandle, out type);
                if (type == MediaContentType.Image)
                {
                    Interop.ImageInformation.SafeImageInformationHandle imageInfo;
                    MediaContentValidator.ThrowIfError(
                        Interop.MediaInformation.GetImage(mediaHandle, out imageInfo), "Failed to get image information");

                    mediaInformationList.Add(new ImageInformation(imageInfo, newHandle));
                }
                else if ((type == MediaContentType.Music) || (type == MediaContentType.Sound))
                {
                    Interop.AudioInformation.SafeAudioInformationHandle audioInfo;
                    MediaContentValidator.ThrowIfError(
                        Interop.MediaInformation.GetAudio(mediaHandle, out audioInfo), "Failed to get audio information");

                    mediaInformationList.Add(new AudioInformation(audioInfo, newHandle));
                }
                else if (type == MediaContentType.Video)
                {
                    Interop.VideoInformation.SafeVideoInformationHandle videoInfo;
                    MediaContentValidator.ThrowIfError(
                        Interop.MediaInformation.GetVideo(mediaHandle, out videoInfo), "Failed to get video information");

                    mediaInformationList.Add(new VideoInformation(videoInfo, newHandle));
                }
                else if (type == MediaContentType.Others)
                {
                    mediaInformationList.Add(new MediaInformation(newHandle));
                }

                return true;
            };
            MediaContentValidator.ThrowIfError(
                Interop.MediaInformation.GetAllMedia(handle, callback, IntPtr.Zero), "Failed to get media information");

            return mediaInformationList;
        }

        /// <summary>
        /// Deletes a MediaInformation from the media database.
        /// </summary>
        /// <param name="mediaInfo">The MediaInformation to be deleted</param>
        public void Delete(MediaInformation mediaInfo)
        {
            ConnectToDB();
            MediaContentValidator.ThrowIfError(
                Interop.MediaInformation.Delete(mediaInfo.MediaId), "Failed to remove information");
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

            if (type == typeof(Tag))
            {
                MediaContentValidator.ThrowIfError(
                    Interop.Tag.DeleteFromDb(((Tag)contentcollection).Id), "Failed to remove information");
            }
            else if (type == typeof(PlayList))
            {
                MediaContentValidator.ThrowIfError(
                    Interop.Playlist.DeleteFromDb(((PlayList)contentcollection).Id), "Failed to remove information");
            }
            else
            {
                throw new ArgumentException("The type of content collection is wrong");
            }
        }

        internal void Delete(MediaBookmark bookmark)
        {
            ConnectToDB();
            MediaContentValidator.ThrowIfError(
                Interop.MediaBookmark.DeleteFromDb(bookmark.Id), "Failed to remove information");
        }

        internal void Delete(MediaFace face)
        {
            ConnectToDB();
            MediaContentValidator.ThrowIfError(
                Interop.Face.DeleteFromDb(face.Id), "Failed to remove face information");
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
            if (type == typeof(Tag))
            {
                MediaContentValidator.ThrowIfError(
                    Interop.Tag.UpdateToDb(((Tag)contentCollection).Handle), "Failed to update DB");
            }
            else if (type == typeof(PlayList))
            {
                MediaContentValidator.ThrowIfError(
                    Interop.Playlist.UpdateToDb(((PlayList)contentCollection).Handle), "Failed to update DB");
            }
            else if (type == typeof(MediaFolder))
            {
                MediaContentValidator.ThrowIfError(
                    Interop.Folder.UpdateToDb(((MediaFolder)contentCollection).Handle), "Failed to update DB");
            }
            else
            {
                throw new ArgumentException("The type of content collection is wrong");
            }
        }

        /// <summary>
        /// Updates a media information instance in the media database
        /// </summary>
        /// <param name="mediaInfo">The MediaInformation object to be updated</param>
        public void Update(MediaInformation mediaInfo)
        {
            ConnectToDB();
            Type type = mediaInfo.GetType();
            if (type == typeof(ImageInformation))
            {
                MediaContentValidator.ThrowIfError(
                    Interop.ImageInformation.UpdateToDB(((ImageInformation)mediaInfo).ImageHandle), "Failed to update DB");

                MediaContentValidator.ThrowIfError(
                    Interop.MediaInformation.UpdateToDB(mediaInfo.MediaHandle), "Failed to update DB");
            }
            else if (type == typeof(AudioInformation))
            {
                MediaContentValidator.ThrowIfError(
                    Interop.AudioInformation.UpdateToDB(((AudioInformation)mediaInfo).AudioHandle), "Failed to update DB");

                MediaContentValidator.ThrowIfError(
                    Interop.MediaInformation.UpdateToDB(mediaInfo.MediaHandle), "Failed to update DB");
            }
            else if (type == typeof(VideoInformation))
            {
                MediaContentValidator.ThrowIfError(
                    Interop.VideoInformation.UpdateToDB(((VideoInformation)mediaInfo).VideoHandle), "Failed to update DB");

                MediaContentValidator.ThrowIfError(
                    Interop.MediaInformation.UpdateToDB(mediaInfo.MediaHandle), "Failed to update DB");
            }
            else if (type == typeof(MediaInformation))
            {
                MediaContentValidator.ThrowIfError(
                    Interop.MediaInformation.UpdateToDB(mediaInfo.MediaHandle), "Failed to update DB");
            }
            else
            {
                throw new ArgumentException("Invalid information type");
            }
        }

        internal void Update(MediaFace face)
        {
            ConnectToDB();
            MediaContentValidator.ThrowIfError(Interop.Face.UpdateToDb(face.Handle), "Failed to update DB");
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
            IntPtr handle = IntPtr.Zero;
            if (type == typeof(Tag))
            {
                MediaContentValidator.ThrowIfError(
                    Interop.Tag.InsertToDb(((Tag)contentCollection).Name, out handle), "Failed to insert collection");
                ((Tag)contentCollection).Handle = handle;
            }
            else if (type == typeof(PlayList))
            {
                MediaContentValidator.ThrowIfError(
                    Interop.Playlist.InsertToDb(((PlayList)contentCollection).Name, out handle), "Failed to insert collection");
                ((PlayList)contentCollection).Handle = handle;
            }
            else
            {
                throw new ArgumentException("collection type is wrong");
            }
        }

        internal void Insert(string mediaId, uint offset, string thumbnailPath)
        {
            ConnectToDB();
            MediaContentValidator.ThrowIfError(
                Interop.MediaBookmark.InsertToDb(mediaId, offset, thumbnailPath), "Failed to insert information");
        }

        internal void Insert(MediaFace face)
        {
            ConnectToDB();
            MediaContentValidator.ThrowIfError(
                Interop.Face.InsertToDb(((MediaFace)face).Handle), "Failed to insert information");
        }
    }
}
