/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc.("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.


using System;
using System.Collections.Generic;
using System.Threading;
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
    /// ContentManager class is the interface class for accessing the ContentCollection and MediaInformation.
    /// This class allows usre to create/update db operations for media content.
    /// </summary>
    public static class ContentManager
    {
        private static bool s_isConnected = false;
        internal static void ConnectToDB()
        {
            if (!s_isConnected)
            {
                MediaContentError err = (MediaContentError)Interop.Content.Connect();
                if (err != MediaContentError.None)
                {
                    throw MediaContentErrorFactory.CreateException(err, "failed to connect to db.");
                }
                s_isConnected = true;
            }
        }
        private static void DisconnectFromDB()
        {
            if (s_isConnected)
            {
                MediaContentError err = (MediaContentError)Interop.Content.Disconnect();
                if (err != MediaContentError.None)
                {
                    throw MediaContentErrorFactory.CreateException(err, "failed to disconnect to db.");
                }
                s_isConnected = false;
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
        /// Requests to cancel the media folder scanning.
        /// </summary>
        /// <param name="folderPath">The folder path</param>
        public static void CancelScanningFolder(string folderPath)
        {
            MediaContentError result = (MediaContentError)Interop.Content.CancelScanFolder(folderPath);
            if (result != MediaContentError.None)
            {
                throw MediaContentErrorFactory.CreateException(result, "Failed scan");
            }
        }

        /// <summary>
        /// Gets the count of ContentCollections for the ContentCollectionType & passed filter from the media database.
        /// </summary>
        /// <param name="type">The content source type. Available types: Folder, Storage, MediaBookmark, Album, Playlist, Tag</param>
        /// <param name="filter">The media filter</param>
        /// <returns>The count of contents present in the media database for a ContentSourceType</returns>
        public static int GetContentCollectionCount(ContentCollectionType type, ContentFilter filter)
        {
            ConnectToDB();
            int count = 0;
            IntPtr handle = (filter != null) ? filter.Handle : IntPtr.Zero;
            MediaContentError res = MediaContentError.None;
            MediaGroupType groupType = MediaGroupType.DisplayName;
            if (handle != IntPtr.Zero)
                groupType = filter.GroupType;
            switch (type)
            {
                case ContentCollectionType.Album:
                    res = (MediaContentError)Interop.Group.MediaAlbumGetAlbumCountFromDb(handle, out count);
                    break;
                case ContentCollectionType.Folder:
                    res = (MediaContentError)Interop.Folder.GetFolderCountFromDb(handle, out count);
                    break;
                case ContentCollectionType.Storage:
                    res = (MediaContentError)Interop.Storage.GetStorageCountFromDb(handle, out count);
                    break;
                case ContentCollectionType.Tag:
                    res = (MediaContentError)Interop.Tag.GetTagCountFromDb(handle, out count);
                    break;
                case ContentCollectionType.PlayList:
                    res = (MediaContentError)Interop.Playlist.GetPlaylistCountFromDb(handle, out count);
                    break;
                case ContentCollectionType.Group:
                    res = (MediaContentError)Interop.Group.GetGroupCountFromDb(handle, groupType, out count);
                    break;
                default:
                    res = MediaContentError.InavlidParameter;
                    break;
            }
            if (res != MediaContentError.None)
            {
                throw MediaContentErrorFactory.CreateException(res, "Failed to get count for the content collection type");
            }
            return count;
        }

        /// <summary>
        /// Gets the count of media matching the passed content filter
        /// </summary>
        /// <param name="filter">The media filter</param>
        /// <returns>Count of media matching the filter</returns>
        public static int GetMediaInformationCount(ContentFilter filter)
        {
            ConnectToDB();
            int count = 0;
            IntPtr handle = (filter != null) ? filter.Handle : IntPtr.Zero;

            MediaContentError res = MediaContentError.None;
            res = (MediaContentError)Interop.MediaInformation.GetMediaCount(handle, out count);
            if (res != MediaContentError.None)
            {
                throw MediaContentErrorFactory.CreateException(res, "Unable to get the count of media from the database.");
            }
            return count;
        }

        /// <summary>
        /// Returns a reference to the MediaInformation object based on the media id passed
        /// </summary>
        /// <param name="mediaId">Media id that needs to be searched</param>
        /// <returns>MediaInformation object</returns>
        public static MediaInformation GetMediaInformation(string mediaId)
        {
            ConnectToDB();
            Interop.MediaInformation.SafeMediaInformationHandle mediaHandle;
            MediaContentError res = MediaContentError.None;
            res = (MediaContentError)Interop.MediaInformation.GetMediaFromDB(mediaId, out mediaHandle);
            if (res != MediaContentError.None)
            {
                Log.Warn(Globals.LogTag, "Failed to get the media information count from the database");
            }
            return new MediaInformation(mediaHandle);
        }

        /// <summary>
        /// Gets the number of bookmarks with the filter from the media database.
        /// </summary>
        /// <param name="filter">ContentFilter used to match bookmarks from the media database.</param>
        /// <returns>The count of bookmarks</returns>
        public static int GetBookmarkCount(ContentFilter filter)
        {
            ConnectToDB();
            MediaContentError res = MediaContentError.None;
            int count = 0;
            IntPtr handle = (filter != null) ? filter.Handle : IntPtr.Zero;
            res = (MediaContentError)Interop.MediaBookmark.GetBookmarkCountFromDb(handle, out count);
            if (res != MediaContentError.None)
            {
                throw MediaContentErrorFactory.CreateException(res, "Failed to get bookmark count from the database");
            }
            return count;
        }

        /// <summary>
        /// Requests to scan a media file.
        /// </summary>
        /// <param name="filePath">The file path</param>
        /// <returns>A reference to the MediaInformation object scanned</returns>
        /// <remarks>
        /// This function requests to scan a media file to the media server. If media file is not registered to DB yet,
        /// that media file information will be added to the media DB. If it is already registered to the DB,
        /// then this tries to refresh information. If requested file does not exist on file system,
        /// information of the media file will be removed from the media DB.
        /// </remarks>
        public static void Scan(string filePath)
        {
            ConnectToDB();
            MediaContentError result = (MediaContentError)Interop.Content.ScanFile(filePath);
            if (result != MediaContentError.None)
            {
                throw MediaContentErrorFactory.CreateException(result, "Failed scan");
            }
        }

        /// <summary>
        /// Inserts a media to the media database
        /// </summary>
        /// <param name="MediaInformation">Media to be inserted</param>
        public static MediaInformation AddMediaInformation(string filePath)
        {
            MediaInformation mediaInformation = null;
            ConnectToDB();
            Interop.MediaInformation.SafeMediaInformationHandle mediaInformationHandle;
            //TODO: verify the usage of MediaInformation._handle.DangerousGetHandle()
            MediaContentError result = (MediaContentError)Interop.MediaInformation.Insert(filePath, out mediaInformationHandle);
            if (result != MediaContentError.None)
            {
                throw MediaContentErrorFactory.CreateException(result, "Failed to Insert Bookmark to DB");
            }
            mediaInformation = new MediaInformation(mediaInformationHandle);
            return mediaInformation;
        }

        /// <summary>
        /// Requests to scan a media folder, asynchronously.
        /// </summary>
        /// <param name="folderPath">The folder path</param>
        /// <remarks>
        /// This function requests to scan a media folder to the media server with given completed callback function.
        /// ContentScanCompleted event will be truggered when the scanning is finished.
        /// The sub folders are also scanned,if there are sub folders in that folder.
        /// If any folder must not be scanned, a blank file ".scan_ignore" has to be created in that folder.
        /// </remarks>
        public static Task StartScanningFolderAsync(string folderPath, bool recursive = true)
        {
            var task = new TaskCompletionSource<int>();
            Interop.Content.MediaScanCompletedCallback scanCompleted = (MediaContentError scanResult, IntPtr data) =>
            {
                Console.WriteLine("Scan Result: "+ scanResult);
                task.SetResult((int)scanResult);
            };

            MediaContentError result = (MediaContentError)Interop.Content.ScanFolder(folderPath, recursive, scanCompleted, IntPtr.Zero);
            if (result != MediaContentError.None)
            {
                throw MediaContentErrorFactory.CreateException(result, "Failed scan");
            }
            return task.Task;
        }

        /// <summary>
        /// Gets the reference to a content store.
        /// </summary>
        /// <param name="type">Allowed types: MediaFolder, Storage</param>
        /// <param name="id">The id of the media content</param>
        /// <returns>Reference to the ContentSourceType item</returns>
        public static T GetContentCollection<T>(string id) where T : ContentCollection
        {
            ConnectToDB();
            MediaContentError res = MediaContentError.None;
            ContentCollection contentCollection = null;
            IntPtr _handle;
            if (typeof(T) == typeof(MediaFolder))
            {
                res = (MediaContentError)Interop.Folder.GetFolderFromDb(id, out _handle);
                if (res != MediaContentError.None)
                {
                    Log.Warn(Globals.LogTag, "Failed to get the content collection");
                    throw MediaContentErrorFactory.CreateException(res, "Failed to get the content collection");
                }
                if (_handle != IntPtr.Zero)
                    contentCollection = new MediaFolder(_handle);
            }
            else if (typeof(T) == typeof(Storage))
            {
                res = (MediaContentError)Interop.Storage.GetStorageInfoFromDb(id, out _handle);
                if (res != MediaContentError.None)
                {
                    Log.Warn(Globals.LogTag, "Failed to get the content collection");
                    throw MediaContentErrorFactory.CreateException(res, "Failed to get the content collection");
                }
                if (_handle != IntPtr.Zero)
                {
                    String path;
                    Interop.Storage.GetId(_handle, out path);
                    Console.WriteLine("path from framework : " + path);
                    contentCollection = new Storage(_handle);
                }
                else
                    Console.WriteLine("invalid handle");
            }

            return (T)contentCollection;
        }

        /// <summary>
        /// Gets the reference to a content store.
        /// </summary>
        /// <param name="type">Allowed types: PlayList, Album, Tag</param>
        /// <param name="id">The id of the media content</param>
        /// <returns>Reference to the ContentSourceType item</returns>
        public static T GetContentCollectionAsync<T>(int id) where T : ContentCollection
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
                    contentCollection = new MediaFolder(_handle);
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
                    contentCollection = new Storage(_handle);
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
                    contentCollection = new Storage(_handle);
            }
            return (T)contentCollection;
        }

        private static List<MediaFolder> ForEachFolder(ContentFilter filter)
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

        private static List<Album> ForEachAlbum(ContentFilter filter)
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

        private static List<Group> ForEachGroup(ContentFilter filter)
        {
            IntPtr handle = (filter != null) ? filter.Handle : IntPtr.Zero;
            MediaContentError res = MediaContentError.None;
            List<Group> groupCollections = new List<Group>();
            Interop.Group.MediaGroupCallback groupCallback = (string groupName, IntPtr data) =>
            {
                groupCollections.Add(new Group(groupName));
                return true;
            };
            res = (MediaContentError)Interop.Group.ForeachGroupFromDb(handle, filter.GroupType, groupCallback, IntPtr.Zero);
            if (res != MediaContentError.None)
            {
                Log.Warn(Globals.LogTag, "Failed to get content collections from the database");
                throw MediaContentErrorFactory.CreateException(res, "Failed to get content collections from the database");
            }
            return groupCollections;
        }

        private static List<Storage> ForEachStorage(ContentFilter filter)
        {
            IntPtr handle = (filter != null) ? filter.Handle : IntPtr.Zero;
            MediaContentError res = MediaContentError.None;
            List<Storage> storageCollections = new List<Storage>();
            Interop.Storage.MediaStorageCallback storageCallback = (IntPtr storageHandle, IntPtr data) =>
            {
                storageCollections.Add(new Storage(storageHandle));
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

        private static List<Tag> ForEachTag(ContentFilter filter)
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

        private static List<PlayList> ForEachPlayList(ContentFilter filter)
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
        /// <param name="type">Allowed types: Album, MediaBookmark, Folder, Storage, Playlist, Tag</param>
        /// <param name="filter">Filter for content items</param>
        /// <returns></returns>
        public static Task<IEnumerable<T>> GetContentCollectionsAsync<T>(ContentFilter filter) where T : ContentCollection
        {
            ConnectToDB();
            var task = new TaskCompletionSource<IEnumerable<T>>();
            if (typeof(T) == typeof(Album))
            {
                List<Album> collectionList = ForEachAlbum(filter);
                task.TrySetResult((IEnumerable<T>)collectionList);
            }
            else if (typeof(T) == typeof(MediaFolder))
            {
                List<MediaFolder> collectionList = ForEachFolder(filter);
                task.TrySetResult((IEnumerable<T>)collectionList);
            }
            else if (typeof(T) == typeof(Group))
            {
                List<Group> collectionList = ForEachGroup(filter);
                task.TrySetResult((IEnumerable<T>)collectionList);
            }
            else if (typeof(T) == typeof(Storage))
            {
                List<Storage> collectionList = ForEachStorage(filter);
                task.TrySetResult((IEnumerable<T>)collectionList);
            }
            else if (typeof(T) == typeof(Tag))
            {
                List<Tag> collectionList = ForEachTag(filter);
                task.TrySetResult((IEnumerable<T>)collectionList);
            }
            else if (typeof(T) == typeof(PlayList))
            {
                List<PlayList> collectionList = ForEachPlayList(filter);
                task.TrySetResult((IEnumerable<T>)collectionList);
            }
            return task.Task;
        }

        /// <summary>
        /// Inserts media files into the media database, asynchronously.
        /// </summary>
        /// <param name="filePaths">The path array to the media files</param>
        /// <returns></returns>
        public static Task AddBatchMediaInformationAsync(IEnumerable<string> filePaths)
        {
            ConnectToDB();
            string[] paths = ((List<string>)filePaths).ToArray();
            var task = new TaskCompletionSource<int>();
            MediaContentError res = MediaContentError.None;
            Interop.MediaInformation.MediaInsertCompletedCallback callback = (MediaContentError error, IntPtr userData) =>
            {
                task.SetResult((int)error);
            };
            res = (MediaContentError)Interop.MediaInformation.BatchInsert(paths, paths.Length, callback, IntPtr.Zero);
            if (res != MediaContentError.None)
            {
                Log.Warn(Globals.LogTag, "Failed to add media information to the database");
            }
            return task.Task;
        }

        /// <summary>
        /// Inserts the burst shot images into the media database, asynchronously.
        /// </summary>
        /// <param name="filePaths">The path array to the burst shot images</param>
        /// <returns></returns>
        public static Task AddBurstShotImagesAsync(IEnumerable<string> filePaths)
        {
            ConnectToDB();
            var task = new TaskCompletionSource<int>();
            string[] paths = ((List<string>)filePaths).ToArray();
            MediaContentError res = MediaContentError.None;
            Interop.MediaInformation.MediaInsertBurstShotCompletedCallback callback = (MediaContentError error, IntPtr userData) =>
            {
                task.SetResult((int)error);
            };
            res = (MediaContentError)Interop.MediaInformation.BurstShotInsert(paths, paths.Length, callback, IntPtr.Zero);
            if (res != MediaContentError.None)
            {
                Log.Warn(Globals.LogTag, "Failed to add burst shots to the database");
            }
            return task.Task;
        }

        /// <summary>
        /// Deletes media files from the media database. The media files for deletion can be specified as a condition in a filter.
        /// This function deletes the media items from the content storage.Normally, deleting media files in the database are done automatically by the media server,
        /// without calling this function.This function is only called when the media server is busy and user needs to get quick result of deleting.
        /// </summary>
        /// <param name="filter">The content filter to which media will be matched</param>
        /// <returns></returns>
        public static Task DeleteBatchMediaAsync(ContentFilter filter)
        {
            ConnectToDB();
            var task = new TaskCompletionSource<int>();
            MediaContentError res = MediaContentError.None;
            IntPtr handle = (filter != null) ? filter.Handle : IntPtr.Zero;
            res = (MediaContentError)Interop.MediaInformation.BatchDelete(handle);
            if (res != MediaContentError.None)
            {
                Log.Warn(Globals.LogTag, "Failed to delete media from the database");
            }
            task.SetResult(0);
            return task.Task;
        }

        /// <summary>
        /// Returns media from the media database.
        /// This function gets all media meeting the given filter
        /// </summary>
        /// <param name="filter">The media filter</param>
        /// <returns>List of media</returns>
        public static Task<IEnumerable<MediaInformation>> GetMediaInformationsAsync(ContentFilter filter)
        {
            ConnectToDB();
            MediaContentError result;
            var task = new TaskCompletionSource<IEnumerable<MediaInformation>>();
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
                        throw MediaContentErrorFactory.CreateException(MediaContentError.InavlidParameter, "Could not find the Image Information");
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
                        throw MediaContentErrorFactory.CreateException(MediaContentError.InavlidParameter, "Could not find the Audio Information");
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
                        throw MediaContentErrorFactory.CreateException(MediaContentError.InavlidParameter, "Could not find the Audio Information");
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
            task.SetResult(mediaInformationList);
            return task.Task;
        }

        /// <summary>
        /// Deletes a content collection from the media database
        /// </summary>
        /// <param name="collection">The content collection to be deleted</param>
        public static Task DeleteFromDatabaseAsync(ContentCollection collection)
        {
            ConnectToDB();
            var task = new TaskCompletionSource<int>();
            task.SetResult(0);
            Type type = collection.GetType();
            if (type == typeof(Tag))
            {
                MediaContentError result = (MediaContentError)Interop.Tag.DeleteFromDb(((Tag)collection).Id);
                if (result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to delete collection from the database");
                }
                task.SetResult((int)result);
            }
            if (type == typeof(PlayList))
            {
                MediaContentError result = (MediaContentError)Interop.Playlist.DeleteFromDb(((PlayList)collection).Id);
                if (result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to delete collection from the database");
                }
                task.SetResult((int)result);
            }
            if (type == typeof(MediaFolder))
            {
                MediaContentError result = MediaContentError.NotSupported;
                /*
                MediaContentError result = (MediaContentError)Interop.Folder.Destroy(((MediaFolder)collection)._folderHandle);
                if (result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to delete collection from the database");
                }
                */
                task.SetResult((int)result);
            }
            if (type == typeof(Storage))
            {
                MediaContentError result = (MediaContentError)Interop.Storage.Destroy(((Storage)collection).Handle);
                if (result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to delete collection from the database");
                }
                task.SetResult((int)result);
            }
            if (type == typeof(Album))
            {
                MediaContentError result = (MediaContentError)Interop.Group.MediaAlbumDestroy(((Album)collection)._albumHandle);
                if (result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to delete collection from the database");
                }
                task.SetResult((int)result);
            }
            if (type == typeof(Group))
            {
                MediaContentError result = MediaContentError.InavlidOperation;
                task.SetResult((int)result);
            }
            return task.Task;
        }

        /// <summary>
        /// Updates a content collection in the media database
        /// </summary>
        /// <param name="collection">The content collection to be updated</param>
        public static Task UpdateToDatabaseAsync(ContentCollection collection)
        {
            ConnectToDB();
            var task = new TaskCompletionSource<int>();
            task.SetResult(0);
            Type type = collection.GetType();
            if (type == typeof(Tag))
            {
                MediaContentError result = (MediaContentError)Interop.Tag.UpdateToDb(((Tag)collection).Handle);
                if (result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to update collection to the database");
                }
                task.SetResult((int)result);
            }
            if (type == typeof(PlayList))
            {
                MediaContentError result = (MediaContentError)Interop.Playlist.UpdateToDb(((PlayList)collection).Handle);
                if (result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to update collection to the database");
                }
                task.SetResult((int)result);
            }
            if (type == typeof(MediaFolder))
            {
                MediaContentError result = (MediaContentError)Interop.Folder.UpdateToDb(((MediaFolder)collection).Handle);
                if (result != MediaContentError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to update collection to the database");
                }
                task.SetResult((int)result);
            }
            if (type == typeof(Storage))
            {
                MediaContentError result = MediaContentError.InavlidOperation;
                task.SetResult((int)result);
            }
            if (type == typeof(Album))
            {
                MediaContentError result = MediaContentError.InavlidOperation;
                task.SetResult((int)result);
            }
            if (type == typeof(Group))
            {
                MediaContentError result = MediaContentError.InavlidOperation;
                task.SetResult((int)result);
            }
            return task.Task;
        }

        /// <summary>
        /// Inserts a content collection to the media database
        /// </summary>
        /// <param name="collection">The content collection to be inserted</param>
        public static void InsertToDatabase(ContentCollection collection)
        {
            ConnectToDB();
            Type type = collection.GetType();
            if (type == typeof(Tag))
            {
                IntPtr tagHandle;
                MediaContentError result = (MediaContentError)Interop.Tag.InsertToDb(((Tag)collection).Name, out tagHandle);
                if (result != MediaContentError.None)
                {
                    throw MediaContentErrorFactory.CreateException(result, "Failed to insert collection to the database");
                }
                ((Tag)collection).Handle= tagHandle;
            }
            if (type == typeof(PlayList))
            {
                IntPtr playListHandle;
                MediaContentError result = (MediaContentError)Interop.Playlist.InsertToDb(((PlayList)collection).Name, out playListHandle);
                if (result != MediaContentError.None)
                {
                    throw MediaContentErrorFactory.CreateException(result, "Failed to insert collection to the database");
                }
                ((PlayList)collection).Handle = playListHandle;
            }
            if (type == typeof(MediaFolder))
            {
                MediaContentError result = MediaContentError.InvalidOperation;
                if (result != MediaContentError.None)
                {
                    throw MediaContentErrorFactory.CreateException(result, "Failed to insert collection to the database");
                }
            }
            if (type == typeof(Storage))
            {
                MediaContentError result = MediaContentError.InvalidOperation;
                if (result != MediaContentError.None)
                {
                    throw MediaContentErrorFactory.CreateException(result, "Failed to insert collection to the database");
                }
            }
            if (type == typeof(Album))
            {
                MediaContentError result = MediaContentError.InvalidOperation;
                if (result != MediaContentError.None)
                {
                    throw MediaContentErrorFactory.CreateException(result, "Failed to insert collection to the database");
                }
            }
            if (type == typeof(Group))
            {
                MediaContentError result = MediaContentError.InvalidOperation;
                if (result != MediaContentError.None)
                {
                    throw MediaContentErrorFactory.CreateException(result, "Failed to insert collection to the database");
                }
            }
        }

        /// <summary>
        /// Deletes a media from the media database
        /// </summary>
        /// <param name="MediaInformation">Media to be deleted</param>
        public static void DeleteFromDatabase(MediaInformation MediaInformation)
        {
            ConnectToDB();
            //TODO: verify the usage of MediaInformation._handle.DangerousGetHandle()
            MediaContentError result = (MediaContentError)Interop.MediaInformation.Delete(MediaInformation.MediaId);
            if (result != MediaContentError.None)
            {
                throw MediaContentErrorFactory.CreateException(result, "Failed to Insert Bookmark to DB");
            }
        }

        /// <summary>
        /// Update a media in the media database
        /// </summary>
        /// <param name="MediaInformation">Media to be updated</param>
        public static void UpdateToDatabase(MediaInformation mediaInformation)
        {
            ConnectToDB();
            MediaContentError result;
            if (mediaInformation is ImageInformation)
            {
                result = (MediaContentError)Interop.AudioInformation.UpdateToDB(((ImageInformation)mediaInformation).ImageHandle);
                if (result != MediaContentError.None)
                {
                    throw MediaContentErrorFactory.CreateException(result, "Failed to Insert Bookmark to DB");
                }
            }
            else if(mediaInformation is VideoInformation)
            {
                result = (MediaContentError)Interop.VideoInformation.UpdateToDB(((VideoInformation)mediaInformation).VideoHandle);
                if (result != MediaContentError.None)
                {
                    throw MediaContentErrorFactory.CreateException(result, "Failed to Insert Bookmark to DB");
                }
            }
            else if(mediaInformation is AudioInformation)
            {
                result = (MediaContentError)Interop.AudioInformation.UpdateToDB(((AudioInformation)mediaInformation).AudioHandle);
                if (result != MediaContentError.None)
                {
                    throw MediaContentErrorFactory.CreateException(result, "Failed to Insert Bookmark to DB");
                }
            }
            result = (MediaContentError)Interop.MediaInformation.UpdateToDB(mediaInformation.MediaHandle);
            if (result != MediaContentError.None)
            {
                throw MediaContentErrorFactory.CreateException(result, "Failed to Insert Bookmark to DB");
            }
        }

        /// <summary>
        /// Inserts a MediaBookmark to the media database
        /// </summary>
        /// <param name="bookmark">MediaBookmark to be inserted</param>
        public static void InsertToDatabase(MediaBookmark bookmark)
        {
            ConnectToDB();
            MediaContentError result = (MediaContentError)Interop.MediaBookmark.InsertToDb(bookmark._mediaId, bookmark._timeStamp, bookmark._thumbnailPath);
            if (result != MediaContentError.None)
            {
                throw MediaContentErrorFactory.CreateException(result, "Failed to Insert Bookmark to DB");
            }
        }

        /// <summary>
        /// Deletes a bookmark from the media database
        /// </summary>
        /// <param name="bookmark">MediaBookmark to be deleted</param>
        public static void DeleteFromDatabase(MediaBookmark bookmark)
        {
            ConnectToDB();
            MediaContentError result = (MediaContentError)Interop.MediaBookmark.DeleteFromDb(bookmark.Id);
            if (result != MediaContentError.None)
            {
                throw MediaContentErrorFactory.CreateException(result, "Failed to Delete Bookmark from DB");
            }
        }

        /// <summary>
        /// Deletes a media face from the media database
        /// </summary>
        /// <param name="mediaFace">Media face to be deleted</param>
        public static void DeleteFromDatabase(MediaFace mediaFace)
        {
            ConnectToDB();
            MediaContentError result = (MediaContentError)Interop.Face.DeleteFromDb(mediaFace.Id);
            if (result != MediaContentError.None)
            {
                throw MediaContentErrorFactory.CreateException(result, "Failed to Delete Face from DB");
            }
        }

        /// <summary>
        /// Updates a media face in the media database
        /// </summary>
        /// <param name="mediaFace">Media face to be updated</param>
        public static void UpdateToDatabase(MediaFace mediaFace)
        {
            ConnectToDB();
            MediaContentError result = (MediaContentError)Interop.Face.UpdateToDb(mediaFace.Handle);
            if (result != MediaContentError.None)
            {
                throw MediaContentErrorFactory.CreateException(result, "Failed to update Face to DB");
            }
        }

        /// <summary>
        /// Inserts a media face to the media database
        /// </summary>
        /// <param name="mediaFace">Media face to be inserted</param>
        public static void InsertToDatabase(MediaFace mediaFace)
        {
            ConnectToDB();
            MediaContentError result = (MediaContentError)Interop.Face.InsertToDb(mediaFace.Handle);
            if (result != MediaContentError.None)
            {
                throw MediaContentErrorFactory.CreateException(result, "Failed to add Face to DB");
            }
        }
    }
}
