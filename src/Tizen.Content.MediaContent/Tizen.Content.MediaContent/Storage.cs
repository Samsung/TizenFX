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

namespace Tizen.Content.MediaContent
{
    /// <summary>
    /// Represents the storage information for media.
    /// </summary>
    /// <remarks>
    /// The system generates the storage ID when the external storage is added and manages the media information
    /// in each of the storage by using the storage ID.
    /// </remarks>
    /// <since_tizen> 3 </since_tizen>
    [Obsolete("Please do not use! this will be deprecated in level 6")]
    public class Storage
    {
        internal Storage(IntPtr handle)
        {
            Path = InteropHelper.GetString(handle, Interop.Storage.GetPath);
            Id = InteropHelper.GetString(handle, Interop.Storage.GetId);
            Type = InteropHelper.GetValue<StorageType>(handle, Interop.Storage.GetType);
        }

        internal static Storage FromHandle(IntPtr handle) => new Storage(handle);

        /// <summary>
        /// Gets the ID of the storage.
        /// </summary>
        /// <value>The unique ID of the storage.</value>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Please do not use! this will be deprecated in level 6")]
        public string Id { get; }

        /// <summary>
        /// Gets the path of the storage.
        /// </summary>
        /// <value>The path of the storage.</value>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Please do not use! this will be deprecated in level 6")]
        public string Path { get; }

        /// <summary>
        /// Gets the type of the storage.
        /// </summary>
        /// <value>The type of the storage.</value>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Please do not use! this will be deprecated in level 6")]
        public StorageType Type { get; }

        /// <summary>
        /// Returns a string representation of the storage.
        /// </summary>
        /// <returns>A string representation of the current storage.</returns>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Please do not use! this will be deprecated in level 6")]
        public override string ToString() =>
            $"Id={Id}, Path={Path}, Type={Type}";
    }
}
