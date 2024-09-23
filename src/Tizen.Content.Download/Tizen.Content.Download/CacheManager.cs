/*
* Copyright (c) 2023 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.ComponentModel;

namespace Tizen.Content.Download
{
    /// <summary>
    /// The CacheManager class provides the functions to manage cache properties,
    /// allowing downloaded content to be reused without redownloading.
    /// </summary>
    /// <since_tizen> 11 </since_tizen>
    public static class CacheManager
    {

        /// <summary>
        /// Clears all cached data related to downloads, resetting the cache to its initial state.
        /// </summary>
        /// <since_tizen> 11 </since_tizen>
        /// <privilege>http://tizen.org/privilege/download</privilege>
        /// <feature>http://tizen.org/feature/download</feature>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to an invalid operation.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when a permission is denied.</exception>
        /// <exception cref="NotSupportedException">Thrown when not supported.</exception>
        static public void ResetCache()
        {
            int ret = Interop.Download.ResetDownloadCache();
            if (ret != (int)DownloadError.None)
            {
                DownloadErrorFactory.ThrowException(ret, "Failed to reset cache");
            }
        }

        /// <summary>
        /// Total maximum cache size considering all apps.
        /// </summary>
        /// <since_tizen> 11 </since_tizen>
        /// <privilege>http://tizen.org/privilege/download</privilege>
        /// <feature>http://tizen.org/feature/download</feature>
        /// <exception cref="ArgumentException">Thrown when it is failed due to setting an invalid value.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to an invalid operation.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when a permission is denied.</exception>
        /// <exception cref="NotSupportedException">Thrown when not supported.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        static public uint MaxCacheSize
        {
            get
            {
                uint maxCacheSize;
                int ret = Interop.Download.GetDownloadCacheMaxSize(out maxCacheSize);
                if (ret != (int)DownloadError.None)
                {
                    DownloadErrorFactory.ThrowException(ret, "Failed to get max size of cache");
                }
                return maxCacheSize;
            }
            set
            {
                int ret = Interop.Download.SetDownloadCacheMaxSize(value);
                if (ret != (int)DownloadError.None)
                {
                    DownloadErrorFactory.ThrowException(ret, "Failed to set cache max size");
                }
            }
        }

        /// <summary>
        /// Clears all system download cache.
        /// </summary>
        /// <since_tizen> 11 </since_tizen>
        /// <privilege>http://tizen.org/privilege/download</privilege>
        /// <feature>http://tizen.org/feature/download</feature>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to an invalid operation.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when a permission is denied.</exception>
        /// <exception cref="NotSupportedException">Thrown when not supported.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        static public void ResetAllCache()
        {
            int ret = Interop.Download.ResetAllDownloadCache();
            if (ret != (int)DownloadError.None)
            {
                DownloadErrorFactory.ThrowException(ret, "Failed to reset all cache");
            }
        }

        /// <summary>
        /// Path of the cache stored.
        /// </summary>
        /// <since_tizen> 11 </since_tizen>
        /// <privilege>http://tizen.org/privilege/download</privilege>
        /// <feature>http://tizen.org/feature/download</feature>
        /// <exception cref="ArgumentException">Thrown when it is failed due to setting an invalid value.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to an invalid operation.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when a permission is denied.</exception>
        /// <exception cref="NotSupportedException">Thrown when not supported.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        static public string CachePath
        {
            get
            {
                string cachePath;
                int ret = Interop.Download.GetDownloadCachePath(out cachePath);
                if (ret != (int)DownloadError.None)
                {
                    DownloadErrorFactory.ThrowException(ret, "Failed to get cache path");
                }
                return cachePath;
            }
            set
            {
                int ret = Interop.Download.SetDownloadCachePath(value);
                if (ret != (int)DownloadError.None)
                {
                    DownloadErrorFactory.ThrowException(ret, "Failed to set cache path");
                }
            }
        }

        /// <summary>
        /// Life cycle of the cache in seconds.
        /// </summary>
        /// <since_tizen> 11 </since_tizen>
        /// <privilege>http://tizen.org/privilege/download</privilege>
        /// <feature>http://tizen.org/feature/download</feature>
        /// <remarks> The time after which the stored cache will be invalid/stale.</remarks>
        /// <exception cref="ArgumentException">Thrown when it is failed due to setting an invalid value.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to an invalid operation.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when a permission is denied.</exception>
        /// <exception cref="NotSupportedException">Thrown when not supported.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        static public uint CacheLifeCycle
        {
            get
            {
                uint lifeCycle;
                int ret = Interop.Download.GetDownloadCacheLifeCycle(out lifeCycle);
                if (ret != (int)DownloadError.None)
                {
                    DownloadErrorFactory.ThrowException(ret, "Failed to get cache life cycle.");
                }
                return lifeCycle;
            }
            set
            {
                int ret = Interop.Download.SetDownloadCacheLifeCycle(value);
                if (ret != (int)DownloadError.None)
                {
                    DownloadErrorFactory.ThrowException(ret, "Failed to set cache life cycle.");
                }
            }
        }
    }
}
