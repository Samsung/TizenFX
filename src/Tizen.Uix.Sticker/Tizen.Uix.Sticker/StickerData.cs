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
using static Interop.StickerData;

namespace Tizen.Uix.Sticker
{
    /// <summary>
    /// Enumeration for the URI type.
    /// </summary>
    /// <since_tizen> 10 </since_tizen>
    public enum UriType
    {
        /// <summary>
        /// Local path URI
        /// </summary>
        LocalPath = 1,
        /// <summary>
        /// Web resource URI
        /// </summary>
        WebResource = 2
    };

    /// <summary>
    /// Enumeration for the display type.
    /// </summary>
    /// <since_tizen> 10 </since_tizen>
    public enum DisplayType
    {
        /// <summary>
        /// Emoji type
        /// </summary>
        Emoji = 1,
        /// <summary>
        /// Wallpaper type
        /// </summary>
        Wallpaper = 2
    };

    /// <summary>
    /// The StickerData provides the methods to get/set the sticker data.
    /// </summary>
    /// <since_tizen> 10 </since_tizen>
    public class StickerData : IDisposable
    {
        internal SafeStickerDataHandle _handle;
        private bool _disposed = false;

        /// <summary>
        /// The public constructor.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        /// <feature>http://tizen.org/feature/ui_service.sticker</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">
        /// This can occur due to the following reasons:
        /// 1) This exception can be due to out of memory.
        /// 2) This exception can be due to operation failed.
        /// </exception>
        public StickerData()
        {
            SafeStickerDataHandle handle;
            ErrorCode error = StickerDataCreate(out handle);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "StickerData Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
            _handle = handle;
        }

        internal SafeStickerDataHandle SafeStickerDataHandle
        {
            get
            {
                return _handle;
            }
        }

        internal StickerData(SafeStickerDataHandle handle)
        {
            _handle = handle;
        }

        internal StickerData(IntPtr handle)
        {
            IntPtr cloneHandle;
            ErrorCode error = StickerDataClone(handle, out cloneHandle);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "StickerData Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }

            _handle = new SafeStickerDataHandle(cloneHandle);
        }

        /// <summary>
        /// The destructor of the StickerData class.
        /// </summary>
        ~StickerData()
        {
            Dispose(false);
        }

        /// <summary>
        /// Release any unmanaged resources used by this object.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Release any unmanaged resources used by this object.
        /// </summary>
        /// <param name="disposing">
        /// If true, disposes any disposable objects. If false, does not dispose disposable objects.
        /// </param>
        /// <since_tizen> 10 </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                _handle?.Dispose();
                _handle = null;
            }

            _disposed = true;
        }

        /// <summary>
        /// Gets the name of the sticker provider application from sticker data.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        /// <feature>http://tizen.org/feature/ui_service.sticker</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">This exception can be due to no data available.</exception>
        public string AppId
        {
            get
            {
                string appId;
                ErrorCode error = StickerDataGetAppId(_handle, out appId);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "GetAppId Failed with error " + error);
                    throw ExceptionFactory.CreateException(error);
                }

                return appId;
            }
        }

        /// <summary>
        /// Gets the URI from sticker data.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        /// <feature>http://tizen.org/feature/ui_service.sticker</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">This exception can be due to no data available.</exception>
        public string Uri
        {
            get
            {
                string uri;
                UriType uriType;
                ErrorCode error = StickerDataGetUri(_handle, out uriType, out uri);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "GetUri Failed with error " + error);
                    throw ExceptionFactory.CreateException(error);
                }

                return uri;
            }
        }

        /// <summary>
        /// Gets the URI type from sticker data.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        /// <feature>http://tizen.org/feature/ui_service.sticker</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">This exception can be due to no data available.</exception>
        public UriType UriType
        {
            get
            {
                string uri;
                UriType uriType;
                ErrorCode error = StickerDataGetUri(_handle, out uriType, out uri);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "GetUriType Failed with error " + error);
                    throw ExceptionFactory.CreateException(error);
                }

                return uriType;
            }
        }

        /// <summary>
        /// Sets the URI of the sticker data.
        /// </summary>
        /// <remarks><paramref name="uri"/> must be a path inside the app package directory like 'res/smile.png' when the type of URI is local path.</remarks>
        /// <since_tizen> 10 </since_tizen>
        /// <feature>http://tizen.org/feature/ui_service.sticker</feature>
        /// <param name="uriType">The URI type to be saved.</param>
        /// <param name="uri">The URI to be saved.</param>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="ArgumentException">This exception can be due to an invalid parameter.</exception>
        public void SetUri(UriType uriType, string uri)
        {
            ErrorCode error = StickerDataSetUri(_handle, uriType, uri);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "SetUri Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Adds a keyword of the sticker to the list.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        /// <feature>http://tizen.org/feature/ui_service.sticker</feature>
        /// <param name="keyword">The keyword to be saved.</param>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="ArgumentException">This exception can be due to an invalid parameter.</exception>
        public void AddKeyword(string keyword)
        {
            ErrorCode error = StickerDataAddKeyword(_handle, keyword);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "AddKeyword Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Removes a keyword of the sticker from the list.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        /// <feature>http://tizen.org/feature/ui_service.sticker</feature>
        /// <param name="keyword">The keyword to be removed.</param>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="ArgumentException">This exception can be due to an invalid parameter.</exception>
        public void RemoveKeyword(string keyword)
        {
            ErrorCode error = StickerDataRemoveKeyword(_handle, keyword);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "RemoveKeyword Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Retrieves all keywords of the sticker data.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        /// <feature>http://tizen.org/feature/ui_service.sticker</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">This exception can be due to no data available.</exception>
        public IEnumerable<string> GetAllKeywords()
        {
            var keywords = new List<string>();
            StickerDataKeywordForeachCallback _keywordDelegate = (string keyword, IntPtr userData) =>
            {
                keywords.Add(keyword);
            };

            ErrorCode error = StickerDataForeachKeyword(_handle, _keywordDelegate, IntPtr.Zero);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "GetAllKeywords Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }

            return keywords.AsReadOnly();
        }

        /// <summary>
        /// Gets/Sets the group name of the sticker data.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        /// <feature>http://tizen.org/feature/ui_service.sticker</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">This exception can be due to no data available.</exception>
        public string GroupName
        {
            get
            {
                string groupName;
                ErrorCode error = StickerDataGetGroupName(_handle, out groupName);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "GetGroupName Failed with error " + error);
                    throw ExceptionFactory.CreateException(error);
                }

                return groupName;
            }
            set
            {
                ErrorCode error = StickerDataSetGroupName(_handle, value);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "SetGroupName Failed with error " + error);
                    throw ExceptionFactory.CreateException(error);
                }
            }
        }

        /// <summary>
        /// Gets/Sets the thumbnail local path of the sticker data.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        /// <feature>http://tizen.org/feature/ui_service.sticker</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="ArgumentException">This exception can be due to an invalid parameter.</exception>
        public string Thumbnail
        {
            get
            {
                string thumbnail;
                ErrorCode error = StickerDataGetThumbnail(_handle, out thumbnail);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "GetThumbnail Failed with error " + error);
                    throw ExceptionFactory.CreateException(error);
                }

                return thumbnail;
            }
            set
            {
                ErrorCode error = StickerDataSetThumbnail(_handle, value);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "SetThumbnail Failed with error " + error);
                    throw ExceptionFactory.CreateException(error);
                }
            }
        }

        /// <summary>
        /// Gets/Sets the description of the sticker data.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        /// <feature>http://tizen.org/feature/ui_service.sticker</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        public string Description
        {
            get
            {
                string description;
                ErrorCode error = StickerDataGetDescription(_handle, out description);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "GetDescription Failed with error " + error);
                    throw ExceptionFactory.CreateException(error);
                }

                return description;
            }
            set
            {
                ErrorCode error = StickerDataSetDescription(_handle, value);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "SetDescription Failed with error " + error);
                    throw ExceptionFactory.CreateException(error);
                }
            }
        }

        /// <summary>
        /// Gets the last update date from sticker data.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        /// <feature>http://tizen.org/feature/ui_service.sticker</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">This exception can be due to no data available.</exception>
        public DateTime LastUpdated
        {
            get
            {
                string date;
                ErrorCode error = StickerDataGetDate(_handle, out date);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "GetDate Failed with error " + error);
                    throw ExceptionFactory.CreateException(error);
                }

                return Convert.ToDateTime(date);
            }
        }

        /// <summary>
        /// Gets/Sets the display type of the sticker data.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        /// <feature>http://tizen.org/feature/ui_service.sticker</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="ArgumentException">This exception can be due to an invalid parameter.</exception>
        public DisplayType DisplayType
        {
            get
            {
                DisplayType displayType;
                ErrorCode error = StickerDataGetDisplayType(_handle, out displayType);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "GetDisplayType Failed with error " + error);
                    throw ExceptionFactory.CreateException(error);
                }

                return displayType;
            }
            set
            {
                ErrorCode error = StickerDataSetDisplayType(_handle, value);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "SetDisplayType Failed with error " + error);
                    throw ExceptionFactory.CreateException(error);
                }
            }
        }
    }
}
