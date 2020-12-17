/*
 * Copyright(c) 2017 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

namespace Tizen.NUI
{
    /// <summary>
    /// The filter mode type.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum FilterModeType
    {
        /// <summary>
        /// Use GL defaults (minification NEAREST_MIPMAP_LINEAR, magnification LINEAR).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        NONE = 0,
        /// <summary>
        /// Use Dali defaults (minification LINEAR, magnification LINEAR).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        DEFAULT,
        /// <summary>
        /// Filter nearest.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        NEAREST,
        /// <summary>
        /// Filter linear.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        LINEAR,
        /// <summary>
        /// Filter nearest mipmap nearest.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        NEAREST_MIPMAP_NEAREST,
        /// <summary>
        /// Filter linear mipmap nearest.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        LINEAR_MIPMAP_NEAREST,
        /// <summary>
        /// Filter nearest mipmap linear.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        NEAREST_MIPMAP_LINEAR,
        /// <summary>
        /// Filter linear mipmap linear.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        LINEAR_MIPMAP_LINEAR
    }
}
