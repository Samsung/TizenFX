/*
* Copyright (c) 2022 Samsung Electronics Co., Ltd All Rights Reserved
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
using static Interop.StickerData;
using static Interop.StickerProvider;

namespace Tizen.Uix.Sticker
{
    /// <summary>
    /// The StickerProvider provides the methods to create/update/delete the sticker data.
    /// </summary>
    /// <since_tizen> 10 </since_tizen>
    public static class StickerProvider
    {
        private static IntPtr _handle = IntPtr.Zero;
        private static StickerProviderInsertFinishedCallback _insertDelegate;

        /// <summary>
        /// Gets a flag indicating whether the StickerProvider is initialized
        /// </summary>
        public static bool Initialized { get; private set; }

        /// <summary>
        /// Initialize sticker provider.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        /// <feature>http://tizen.org/feature/ui_service.sticker</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">
        /// This can occur due to the following reasons:
        /// 1) This exception can be due to out of memory.
        /// 2) This exception can be due to operation failed.
        /// </exception>
        public static void Initialize()
        {
            if (!Initialized)
            {
                IntPtr handle;
                ErrorCode error = StickerProviderCreate(out handle);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "Create Failed with error " + error);
                    throw ExceptionFactory.CreateException(error);
                }
                _handle = handle;
                Initialized = true;
            }
            else
            {
                Log.Debug(LogTag, "Already initialized");
            }
        }

        /// <summary>
        /// Deinitialize the sticker provider.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        /// <feature>http://tizen.org/feature/ui_service.sticker</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">This exception can be due to operation failed.</exception>
        /// <pre>
        /// StickerProvider must be initialized.
        /// </pre>
        public static void Deinitialize()
        {
            if (_handle != IntPtr.Zero)
            {
                ErrorCode error = StickerProviderDestroy(_handle);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "Destroy Failed with error " + error);
                    if (error == ErrorCode.InvalidParameter)
                        throw ExceptionFactory.CreateException(ErrorCode.OperationFailed);
                    else
                        throw ExceptionFactory.CreateException(error);
                }
                _handle = IntPtr.Zero;
            }
            Initialized = false;
        }

        /// <summary>
        /// Inserts a sticker data to the sticker database.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        /// <feature>http://tizen.org/feature/ui_service.sticker</feature>
        /// <param name="data">The sticker data to be saved.</param>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="ArgumentException">This exception can be due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">
        /// This can occur due to the following reasons:
        /// 1) This exception can be due to operation failed.
        /// 2) This exception can be due to file exists.
        /// 3) This exception can be due to no such file.
        /// </exception>
        public static void InsertData(StickerData data)
        {
            ErrorCode error = StickerProviderInsertData(_handle, data.SafeStickerDataHandle);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "InsertData Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Inserts a sticker data using JSON file.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        /// <feature>http://tizen.org/feature/ui_service.sticker</feature>
        /// <remarks>
        /// All data except thumbnail, description, and display_type must be set in the JSON file to insert the sticker data.
        /// <paramref name="jsonPath"/> must have a non-null value and must be an existing file.
        /// If the URI type is local path, the sticker file is copied to a sticker directory.
        /// It is recommended to delete your sticker files after inserting a sticker data.
        /// </remarks>
        /// <param name="jsonPath">The path of JSON file containing sticker data to be saved</param>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="ArgumentException">This exception can be due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">This exception can be due to operation failed.</exception>
        public static Task InsertData(string jsonPath)
        {
            var task = new TaskCompletionSource<bool>();
            _insertDelegate = (ErrorCode errorCode, IntPtr userData) =>
            {
                if (errorCode != ErrorCode.None)
                {
                    Log.Error(LogTag, "Exception occurred while inserting");
                    throw ExceptionFactory.CreateException(errorCode);
                }
                else
                {
                    task.SetResult(true);
                }
            };
            ErrorCode error = StickerProviderInsertDataByJsonFile(_handle, jsonPath, _insertDelegate, IntPtr.Zero);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "InsertData Failed with error " + error);
                task.SetException(ExceptionFactory.CreateException(error));
            }
            return task.Task;
        }

        /// <summary>
        /// Updates a sticker data in the sticker database.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        /// <feature>http://tizen.org/feature/ui_service.sticker</feature>
        /// <param name="data">The sticker data to be updated.</param>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="ArgumentException">This exception can be due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">
        /// This can occur due to the following reasons:
        /// 1) This exception can be due to operation failed.
        /// 2) This exception can be due to file exists.
        /// 3) This exception can be due to no such file.
        /// </exception>
        public static void UpdateData(StickerData data)
        {
            ErrorCode error = StickerProviderUpdateData(_handle, data.SafeStickerDataHandle);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "UpdateData Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Deletes a sticker data in the sticker database.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        /// <feature>http://tizen.org/feature/ui_service.sticker</feature>
        /// <param name="data">The sticker data to be deleted.</param>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="ArgumentException">This exception can be due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">This exception can be due to operation failed.</exception>
        public static void DeleteData(StickerData data)
        {
            ErrorCode error = StickerProviderDeleteData(_handle, data.SafeStickerDataHandle);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "DeleteData Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Deletes a sticker data in the sticker database.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        /// <feature>http://tizen.org/feature/ui_service.sticker</feature>
        /// <param name="uri">The URI of the sticker data to be deleted.</param>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">
        /// This can occur due to the following reasons:
        /// 1) This exception can be due to operation failed.
        /// 2) This exception can be due to no such file.
        /// </exception>
        public static void DeleteData(string uri)
        {
            ErrorCode error = StickerProviderDeleteDataByUri(_handle, uri);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "DeleteData Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Gets the count of stickers stored by the provider application.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        /// <feature>http://tizen.org/feature/ui_service.sticker</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">This exception can be due to operation failed.</exception>
        public static int StickerCount
        {
            get
            {
                int _count = 0;
                ErrorCode error = StickerProviderGetStickerCount(_handle, out _count);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "StickerCount Failed with error " + error);
                    throw ExceptionFactory.CreateException(error);
                }

                return _count;
            }
        }

        /// <summary>
        /// Retrieves all sticker data in the sticker database.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        /// <feature>http://tizen.org/feature/ui_service.sticker</feature>
        /// <param name="offset">The start position (Starting from zero).</param>
        /// <param name="count">The number of stickers to be retrieved with respect to the offset.</param>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="ArgumentException">This exception can be due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">
        /// This can occur due to the following reasons:
        /// 1) This exception can be due to out of memory.
        /// 2) This exception can be due to operation failed.
        /// </exception>
        public static IEnumerable<StickerData> GetAllStickers(int offset, int count)
        {
            var stickers = new List<StickerData>();
            StickerProviderDataForeachCallback _dataForeachDelegate = (IntPtr stickerData, IntPtr userData) =>
            {
                StickerData data = new StickerData(stickerData);
                stickers.Add(data);
            };
            ErrorCode error = StickerProviderDataForeachAll(_handle, offset, count, out var result, _dataForeachDelegate, IntPtr.Zero);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "GetAllStickers Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }

            return stickers;
        }

        /// <summary>
        /// Sets the image of the sticker group.
        /// URI must be a relative path like '/res/smile.png' when URI type is local path.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        /// <feature>http://tizen.org/feature/ui_service.sticker</feature>
        /// <param name="groupImage">The group image to be set.</param>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="ArgumentException">This exception can be due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">
        /// This can occur due to the following reasons:
        /// 1) This exception can be due to operation failed.
        /// 2) This exception can be due to no such file.
        /// </exception>
        public static void SetGroupImage(GroupImage groupImage)
        {
            ErrorCode error = StickerProviderSetGroupImage(_handle, groupImage.GroupName, groupImage.UriType, groupImage.Uri);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "SetGroupImage Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }
    }
}
