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

namespace Tizen.System
{
    /// <summary>
    /// Enumeration of the storage directory types.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum DirectoryType
    {
        /// <summary>
        /// Image directory
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Images = Interop.Storage.DirectoryType.Images,
        /// <summary>
        /// Sounds directory
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Sounds = Interop.Storage.DirectoryType.Sounds,
        /// <summary>
        /// Videos directory
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Videos = Interop.Storage.DirectoryType.Videos,
        /// <summary>
        /// Camera directory
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Camera = Interop.Storage.DirectoryType.Camera,
        /// <summary>
        /// Downloads directory
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Downloads = Interop.Storage.DirectoryType.Downloads,
        /// <summary>
        /// Music directory
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Music = Interop.Storage.DirectoryType.Music,
        /// <summary>
        /// Documents directory
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Documents = Interop.Storage.DirectoryType.Documents,
        /// <summary>
        /// Others directory
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Others = Interop.Storage.DirectoryType.Others,
        /// <summary>
        /// System ringtones directory. Only available for internal storage.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Ringtones = Interop.Storage.DirectoryType.Ringtones,
    }
}
