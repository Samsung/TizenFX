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
        private static ContentDatabase s_contentDB = new ContentDatabase();
        public static ContentDatabase Database
        {
            get
            {
                return s_contentDB;
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
            Database.ConnectToDB();
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
            Database.ConnectToDB();
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
        /// Inserts media files into the media database, asynchronously.
        /// </summary>
        /// <param name="filePaths">The path array to the media files</param>
        /// <returns></returns>
        public static Task AddMediaInformationBatchAsync(IEnumerable<string> filePaths)
        {
            Database.ConnectToDB();
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
            Database.ConnectToDB();
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
        public static Task RemoveMediaInformationBatchAsync(ContentFilter filter)
        {
            Database.ConnectToDB();
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
    }
}
