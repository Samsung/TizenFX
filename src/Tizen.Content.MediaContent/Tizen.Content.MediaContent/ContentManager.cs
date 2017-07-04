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
using System.Threading;

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
        private static readonly ContentDatabase s_contentDB = new ContentDatabase();

        /// <summary>
        /// Database instance to do all the Database oprtions for media content management.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static ContentDatabase Database
        {
            get
            {
                return s_contentDB;
            }
        }

        /// <summary>
        /// Requests to scan a media file.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="filePath">File path of the media to be scanned</param>
        /// <returns>A reference to the MediaInformation object scanned</returns>
        /// <remarks>
        /// This function requests to scan a media file to the media server. If media file is not registered to DB yet,
        /// that media file information will be added to the media DB. If it is already registered to the DB,
        /// then this tries to refresh information. If requested file does not exist on file system,
        /// information of the media file will be removed from the media DB.
        /// </remarks>
        public static void Scan(string filePath)
        {
            MediaContentValidator.ThrowIfError(Interop.Content.ScanFile(filePath), "Failed scan");
        }

        /// <summary>
        /// Inserts a media to the media database
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="filePath">File path of the media to be inserted</param>
        /// <returns>the MediaInformation instance about added media path</returns>
        public static MediaInformation AddMediaInformation(string filePath)
        {
            Interop.MediaInformation.SafeMediaInformationHandle mediaInformationHandle;
            MediaContentValidator.ThrowIfError(
                Interop.MediaInformation.Insert(filePath, out mediaInformationHandle), "Failed to Insert MediaInformation to DB");

            MediaContentType type;
            MediaInformation res;
            Interop.MediaInformation.GetMediaType(mediaInformationHandle, out type);
            if (type == MediaContentType.Image)
            {
                Interop.ImageInformation.SafeImageInformationHandle imageInfo;
                MediaContentValidator.ThrowIfError(
                    Interop.MediaInformation.GetImage(mediaInformationHandle.DangerousGetHandle(), out imageInfo), "Failed to get image information");

                res = new ImageInformation(imageInfo, mediaInformationHandle);
            }
            else if ((type == MediaContentType.Music) || (type == MediaContentType.Sound))
            {
                Interop.AudioInformation.SafeAudioInformationHandle audioInfo;
                MediaContentValidator.ThrowIfError(
                    Interop.MediaInformation.GetAudio(mediaInformationHandle.DangerousGetHandle(), out audioInfo), "Failed to get audio information");

                res = new AudioInformation(audioInfo, mediaInformationHandle);
            }
            else if (type == MediaContentType.Video)
            {
                Interop.VideoInformation.SafeVideoInformationHandle videoInfo;
                MediaContentValidator.ThrowIfError(
                    Interop.MediaInformation.GetVideo(mediaInformationHandle.DangerousGetHandle(), out videoInfo), "Failed to get video information");

                res = new VideoInformation(videoInfo, mediaInformationHandle);
            }
            else
            {
                res = new MediaInformation(mediaInformationHandle);
            }

            return res;
        }

        /// <summary>
        /// Requests to scan a media folder, asynchronously.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="folderPath">The folder path</param>
        /// <param name="recursive">Indicate sif the folder is to recursively scanned. Default value: true</param>
        /// <remarks>
        /// This function requests to scan a media folder to the media server with given completed callback function.
        /// The sub folders are also scanned,if there are sub folders in that folder.
        /// If any folder must not be scanned, a blank file ".scan_ignore" has to be created in that folder.
        /// </remarks>
        /// <returns>Task with scanning result</returns>
        public static Task<MediaContentError> ScanFolderAsync(string folderPath, bool recursive = true)
        {
            var task = new TaskCompletionSource<MediaContentError>();

            Interop.Content.MediaScanCompletedCallback scanCompleted = (MediaContentError scanResult, IntPtr data) =>
            {
                MediaContentValidator.ThrowIfError(scanResult, "Failed to scan");
                task.SetResult(scanResult);
            };

            MediaContentValidator.ThrowIfError(
                Interop.Content.ScanFolder(folderPath, recursive, scanCompleted, IntPtr.Zero), "Failed to scan");

            return task.Task;
        }

        internal static Interop.Content.MediaScanCompletedCallback scanCompletedWithToken = null;
        internal static Object l = new Object();
        /// <summary>
        /// Requests to scan a media folder, asynchronously.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="folderPath">The folder path</param>
        /// <param name="cancellationToken">Cancellation token required to cancel the current scan</param>
        /// <param name="recursive">Indicate sif the folder is to recursively scanned. Default value: true</param>
        /// <remarks>
        /// This function requests to scan a media folder to the media server with given completed callback function.
        /// The sub folders are also scanned,if there are sub folders in that folder.
        /// If any folder must not be scanned, a blank file ".scan_ignore" has to be created in that folder.
        /// </remarks>
        /// <returns>Task with scanning result</returns>
        public static Task ScanFolderAsync(string folderPath, CancellationToken cancellationToken, bool recursive = true)
        {
            var task = new TaskCompletionSource<int>();
            bool taskCompleted = false;

            cancellationToken.Register(() =>
            {
                lock (l)
                {
                    if (!taskCompleted)
                    {
                        taskCompleted = true;
                        MediaContentValidator.ThrowIfError(
                            Interop.Content.CancelScanFolder(folderPath), "Failed CancelScanFolder");

                        task.SetCanceled();
                    }
                }
            });
            scanCompletedWithToken = (MediaContentError scanResult, IntPtr data) =>
            {
                lock (l)
                {
                    if (!taskCompleted)
                    {
                        taskCompleted = true;
                        MediaContentValidator.ThrowIfError(scanResult, "Failed scan");
                        task.SetResult((int)scanResult);
                    }
                }
            };

            MediaContentValidator.ThrowIfError(
                Interop.Content.ScanFolder(folderPath, recursive, scanCompletedWithToken, IntPtr.Zero), "Failed to scan");

            return task.Task;

        }

        /// <summary>
        /// Inserts media files into the media database, asynchronously.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="filePaths">The path array to the media files</param>
        /// <returns>
        /// Task with the result of batch insertion
        /// </returns>
        public static Task AddMediaInformationBatchAsync(IEnumerable<string> filePaths)
        {
            var task = new TaskCompletionSource<int>();
            string[] paths = ((List<string>)filePaths).ToArray();
            Interop.MediaInformation.MediaInsertCompletedCallback callback = (MediaContentError error, IntPtr userData) =>
            {
                MediaContentValidator.ThrowIfError(error, "Failed to batch insert");
                task.SetResult((int)error);
            };
            MediaContentValidator.ThrowIfError(
                Interop.MediaInformation.BatchInsert(paths, paths.Length, callback, IntPtr.Zero), "Failed to add batch media");

            return task.Task;
        }

        /// <summary>
        /// Inserts the burst shot images into the media database, asynchronously.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="filePaths">The path array to the burst shot images</param>
        /// <returns>
        /// Task with the result of the burstshot insertion
        /// </returns>
        public static Task AddBurstShotImagesAsync(IEnumerable<string> filePaths)
        {
            var task = new TaskCompletionSource<int>();
            string[] paths = ((List<string>)filePaths).ToArray();
            Interop.MediaInformation.MediaInsertBurstShotCompletedCallback callback = (MediaContentError error, IntPtr userData) =>
            {
                MediaContentValidator.ThrowIfError(error, "Failed to add burstshot");
                task.SetResult((int)error);
            };
            MediaContentValidator.ThrowIfError(
                Interop.MediaInformation.BurstShotInsert(paths, paths.Length, callback, IntPtr.Zero), "Failed to add burst shots to db");

            return task.Task;
        }

        /// <summary>
        /// Deletes media files from the media database. The media files for deletion can be specified as a condition in a filter.
        /// This function deletes the media items from the content storage.Normally, deleting media files in the database are done automatically by the media server,
        /// without calling this function.This function is only called when the media server is busy and user needs to get quick result of deleting.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="filter">The content filter to which media will be matched</param>
        public static void RemoveMediaInformationBatch(ContentFilter filter)
        {
            IntPtr handle = (filter != null) ? filter.Handle : IntPtr.Zero;
            MediaContentValidator.ThrowIfError(
                Interop.MediaInformation.BatchDelete(handle), "Failed to remove items");
        }
    }
}
