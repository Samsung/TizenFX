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
using System.Runtime.InteropServices;
using static Interop.StickerData;
using static Interop.StickerConsumer;

namespace Tizen.Uix.Sticker
{
    /// <summary>
    /// Enumeration for the event type.
    /// </summary>
    /// <since_tizen> 10 </since_tizen>
    internal enum EventType
    {
        /// <summary>
        /// A sticker data has been added.
        /// </summary>
        Insert = 0,
        /// <summary>
        /// A sticker data has been removed.
        /// </summary>
        Delete = 1,
        /// <summary>
        /// A sticker data has been updated.
        /// </summary>
        Update = 2
    };

    /// <summary>
    /// The StickerConsumer provides the methods to retrieve sticker data.
    /// </summary>
    /// <since_tizen> 10 </since_tizen>
    public static class StickerConsumer
    {
        private static IntPtr _handle = IntPtr.Zero;
        private static event EventHandler<InsertedEventArgs> _inserted;
        private static event EventHandler<DeletedEventArgs> _deleted;
        private static event EventHandler<UpdatedEventArgs> _updated;
        private static StickerConsumerEventCallback _eventDelegate;

        /// <summary>
        /// Gets a flag indicating whether the StickerConsumer is initialized
        /// </summary>
        public static bool Initialized { get; private set; }

        /// <summary>
        /// Initialize sticker consumer.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        /// <privilege>http://tizen.org/privilege/mediastorage</privilege>
        /// <privlevel>public</privlevel>
        /// <feature>http://tizen.org/feature/ui_service.sticker</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
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
                ErrorCode error = StickerConsumerCreate(out handle);
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
        /// Deinitialize the sticker consumer.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        /// <feature>http://tizen.org/feature/ui_service.sticker</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">This exception can be due to operation failed.</exception>
        /// <pre>
        /// StickerConsumer must be initialized.
        /// </pre>
        public static void Deinitialize()
        {
            if (_handle != IntPtr.Zero)
            {
                ErrorCode error = StickerConsumerDestroy(_handle);
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
        /// Retrieves all sticker data in the sticker database.
        /// If you set the <paramref name="offset"/> as 10 and <paramref name="count"/> as 10, then only records from 10 to 19 will be retrieved.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        /// <feature>http://tizen.org/feature/ui_service.sticker</feature>
        /// <param name="offset">The start position (Starting from zero).</param>
        /// <param name="count">The number of stickers to be retrieved with respect to the offset.</param>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="ArgumentException">This exception can be due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">This exception can be due to operation failed.</exception>
        public static IEnumerable<StickerData> GetAllStickers(int offset, int count)
        {
            var stickers = new List<StickerData>();
            StickerConsumerDataForeachCallback _dataForeachDelegate = (IntPtr stickerData, IntPtr userData) =>
            {
                StickerData data = new StickerData(stickerData);
                stickers.Add(data);
            };
            ErrorCode error = StickerConsumerDataForeachAll(_handle, offset, count, out var result, _dataForeachDelegate, IntPtr.Zero);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "GetAllStickers Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }

            return stickers;
        }

        /// <summary>
        /// Retrieves all sticker data in the sticker database using keyword.
        /// If you set the <paramref name="offset"/> as 10 and <paramref name="count"/> as 10, then only records from 10 to 19 will be retrieved.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        /// <feature>http://tizen.org/feature/ui_service.sticker</feature>
        /// <param name="offset">The start position (Starting from zero).</param>
        /// <param name="count">The number of stickers to be retrieved with respect to the offset.</param>
        /// <param name="keyword">The keyword of the sticker for getting sticker data.</param>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="ArgumentException">This exception can be due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">This exception can be due to operation failed.</exception>
        public static IEnumerable<StickerData> GetStickersByKeyword(int offset, int count, string keyword)
        {
            var stickers = new List<StickerData>();
            StickerConsumerDataForeachCallback _dataForeachDelegate = (IntPtr stickerData, IntPtr userData) =>
            {
                StickerData data = new StickerData(stickerData);
                stickers.Add(data);
            };
            ErrorCode error = StickerConsumerDataForeachByKeyword(_handle, offset, count, out var result, keyword, _dataForeachDelegate, IntPtr.Zero);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "GetStickersByKeyword Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }

            return stickers;
        }

        /// <summary>
        /// Retrieves all sticker data in the sticker database using group name.
        /// If you set the <paramref name="offset"/> as 10 and <paramref name="count"/> as 10, then only records from 10 to 19 will be retrieved.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        /// <feature>http://tizen.org/feature/ui_service.sticker</feature>
        /// <param name="offset">The start position (Starting from zero).</param>
        /// <param name="count">The number of stickers to be retrieved with respect to the offset.</param>
        /// <param name="groupName">The group name of the sticker for getting sticker data.</param>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="ArgumentException">This exception can be due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">This exception can be due to operation failed.</exception>
        public static IEnumerable<StickerData> GetStickersByGroup(int offset, int count, string groupName)
        {
            var stickers = new List<StickerData>();
            StickerConsumerDataForeachCallback _dataForeachDelegate = (IntPtr stickerData, IntPtr userData) =>
            {
                StickerData data = new StickerData(stickerData);
                stickers.Add(data);
            };
            ErrorCode error = StickerConsumerDataForeachByGroup(_handle, offset, count, out var result, groupName, _dataForeachDelegate, IntPtr.Zero);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "GetStickersByGroup Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }

            return stickers;
        }

        /// <summary>
        /// Retrieves all sticker data in the sticker database using URI type.
        /// If you set the <paramref name="offset"/> as 10 and <paramref name="count"/> as 10, then only records from 10 to 19 will be retrieved.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        /// <feature>http://tizen.org/feature/ui_service.sticker</feature>
        /// <param name="offset">The start position (Starting from zero).</param>
        /// <param name="count">The number of stickers to be retrieved with respect to the offset.</param>
        /// <param name="uriType">The URI type of the sticker for getting sticker data.</param>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="ArgumentException">This exception can be due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">This exception can be due to operation failed.</exception>
        public static IEnumerable<StickerData> GetStickersByUriType(int offset, int count, UriType uriType)
        {
            var stickers = new List<StickerData>();
            StickerConsumerDataForeachCallback _dataForeachDelegate = (IntPtr stickerData, IntPtr userData) =>
            {
                StickerData data = new StickerData(stickerData);
                stickers.Add(data);
            };
            ErrorCode error = StickerConsumerDataForeachByType(_handle, offset, count, out var result, uriType, _dataForeachDelegate, IntPtr.Zero);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "GetStickersByUriType Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }

            return stickers;
        }

        /// <summary>
        /// Retrieves all sticker data in the sticker database using display type.
        /// If you set the <paramref name="offset"/> as 10 and <paramref name="count"/> as 10, then only records from 10 to 19 will be retrieved.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        /// <feature>http://tizen.org/feature/ui_service.sticker</feature>
        /// <param name="offset">The start position (Starting from zero).</param>
        /// <param name="count">The number of stickers to be retrieved with respect to the offset.</param>
        /// <param name="displayType">The display type of the sticker for getting sticker data.</param>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="ArgumentException">This exception can be due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">This exception can be due to operation failed.</exception>
        public static IEnumerable<StickerData> GetStickersByDisplayType(int offset, int count, DisplayType displayType)
        {
            var stickers = new List<StickerData>();
            StickerConsumerDataForeachCallback _dataForeachDelegate = (IntPtr stickerData, IntPtr userData) =>
            {
                StickerData data = new StickerData(stickerData);
                stickers.Add(data);
            };
            ErrorCode error = StickerConsumerDataForeachByDisplayType(_handle, offset, count, out var result, displayType, _dataForeachDelegate, IntPtr.Zero);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "GetStickersByDisplayType Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }

            return stickers;
        }

        /// <summary>
        /// Retrieves all group names in the sticker database.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        /// <feature>http://tizen.org/feature/ui_service.sticker</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">This exception can be due to operation failed.</exception>
        public static IEnumerable<string> GetAllGroupNames()
        {
            var groupNames = new List<string>();
            StickerConsumerGroupListForeachCallback _groupForeachDelegate = (IntPtr group, IntPtr userData) =>
            {
                string groupName = Marshal.PtrToStringAnsi(group);
                groupNames.Add(groupName);
            };
            ErrorCode error = StickerConsumerGroupListForeachAll(_handle, _groupForeachDelegate, IntPtr.Zero);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "GetAllGroupNames Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }

            return groupNames;
        }

        /// <summary>
        /// Retrieves all group names assigned to stickers with a matching display <paramref name="displayType"/>.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        /// <feature>http://tizen.org/feature/ui_service.sticker</feature>
        /// <param name="displayType">The display type of the sticker for getting sticker data.</param>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="ArgumentException">This exception can be due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">This exception can be due to operation failed.</exception>
        public static IEnumerable<string> GetGroupNamesByDisplayType(DisplayType displayType)
        {
            var groupNames = new List<string>();
            StickerConsumerGroupListForeachCallback _groupForeachDelegate = (IntPtr group, IntPtr userData) =>
            {
                string groupName = Marshal.PtrToStringAnsi(group);
                groupNames.Add(groupName);
            };
            ErrorCode error = StickerConsumerGroupListForeachByDisplayType(_handle, displayType, _groupForeachDelegate, IntPtr.Zero);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "GetGroupNamesByDisplayType Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }

            return groupNames;
        }

        /// <summary>
        /// Retrieves all keywords in the sticker database.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        /// <feature>http://tizen.org/feature/ui_service.sticker</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">This exception can be due to operation failed.</exception>
        public static IEnumerable<string> GetAllKeywords()
        {
            var keywords = new List<string>();
            StickerConsumerKeywordListForeachCallback _keywordForeachDelegate = (IntPtr keyword, IntPtr userData) =>
            {
                string stickerKeyword = Marshal.PtrToStringAnsi(keyword);
                keywords.Add(stickerKeyword);
            };
            ErrorCode error = StickerConsumerKeywordListForeachAll(_handle, _keywordForeachDelegate, IntPtr.Zero);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "GetAllKeywords Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }

            return keywords;
        }

        /// <summary>
        /// Adds entry to recently used stickers list.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        /// <feature>http://tizen.org/feature/ui_service.sticker</feature>
        /// <param name="data">The sticker data class</param>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="ArgumentException">This exception can be due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">This exception can be due to operation failed.</exception>
        public static void AddRecentData(StickerData data)
        {
            ErrorCode error = StickerConsumerAddRecentData(_handle, data.SafeStickerDataHandle);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "AddRecentData Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Gets recently used stickers list.
        /// The most recently used stickers are delivered in order.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        /// <feature>http://tizen.org/feature/ui_service.sticker</feature>
        /// <param name="count">The number of stickers that you want to receive.</param>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="ArgumentException">This exception can be due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">This exception can be due to operation failed.</exception>
        public static IEnumerable<StickerData> GetRecentStickers(int count)
        {
            var stickers = new List<StickerData>();
            StickerConsumerDataForeachCallback _dataForeachDelegate = (IntPtr stickerData, IntPtr userData) =>
            {
                StickerData data = new StickerData(stickerData);
                stickers.Add(data);
            };
            ErrorCode error = StickerConsumerGetRecentDataList(_handle, count, out var result, _dataForeachDelegate, IntPtr.Zero);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "GetRecentStickers Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }

            return stickers;
        }

        private static void RegisterEventOccurredCallback()
        {
            _eventDelegate = (EventType type, IntPtr stickerData, IntPtr userData) =>
            {
                if (type == EventType.Insert)
                {
                    if (_inserted != null)
                    {
                        InsertedEventArgs args = new InsertedEventArgs(stickerData);
                        _inserted?.Invoke(null, args);
                    }
                }
                else if (type == EventType.Delete)
                {
                    if (_deleted != null)
                    {
                        DeletedEventArgs args = new DeletedEventArgs(stickerData);
                        _deleted?.Invoke(null, args);
                    }
                }
                else if (type == EventType.Update)
                {
                    if (_updated != null)
                    {
                        UpdatedEventArgs args = new UpdatedEventArgs(stickerData);
                        _updated?.Invoke(null, args);
                    }
                }
            };
            ErrorCode error = StickerConsumerSetEventCB(_handle, _eventDelegate, IntPtr.Zero);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "Add EventOccurred Failed with error " + error);
            }
        }

        private static void UnregisterEventOccurredCallback()
        {
            ErrorCode error = StickerConsumerUnsetEventCB(_handle);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "Remove EventOccurred Failed with error " + error);
            }
        }

        /// <summary>
        /// Called when the stickers are inserted.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        public static event EventHandler<InsertedEventArgs> Inserted
        {
            add
            {
                if (_inserted == null && _deleted == null && _updated == null)
                {
                    RegisterEventOccurredCallback();
                }
                _inserted += value;
            }

            remove
            {
                _inserted -= value;
                if (_inserted == null && _deleted == null && _updated == null)
                {
                    UnregisterEventOccurredCallback();
                }
            }
        }

        /// <summary>
        /// Called when the stickers are deleted.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        public static event EventHandler<DeletedEventArgs> Deleted
        {
            add
            {
                if (_inserted == null && _deleted == null && _updated == null)
                {
                    RegisterEventOccurredCallback();
                }
                _deleted += value;
            }

            remove
            {
                _deleted -= value;
                if (_inserted == null && _deleted == null && _updated == null)
                {
                    UnregisterEventOccurredCallback();
                }
            }
        }

        /// <summary>
        /// Called when the stickers are updated.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        public static event EventHandler<UpdatedEventArgs> Updated
        {
            add
            {
                if (_inserted == null && _deleted == null && _updated == null)
                {
                    RegisterEventOccurredCallback();
                }
                _updated += value;
            }

            remove
            {
                _updated -= value;
                if (_inserted == null && _deleted == null && _updated == null)
                {
                    UnregisterEventOccurredCallback();
                }
            }
        }

        /// <summary>
        /// Retrieves images of all sticker groups in the database.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        /// <feature>http://tizen.org/feature/ui_service.sticker</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">This exception can be due to operation failed.</exception>
        public static IEnumerable<GroupImage> GetGroupImageList()
        {
            var imageList = new List<GroupImage>();
            StickerConsumerGroupImageListForeachCallback _groupImageForeachDelegate = (IntPtr group, UriType type, IntPtr uri, IntPtr userData) =>
            {
                imageList.Add(new GroupImage(Marshal.PtrToStringAnsi(group), type, Marshal.PtrToStringAnsi(uri)));
            };
            ErrorCode error = StickerConsumerGroupImageListForeachAll(_handle, _groupImageForeachDelegate, IntPtr.Zero);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "GetGroupImageList Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }

            return imageList;
        }
    }
}
