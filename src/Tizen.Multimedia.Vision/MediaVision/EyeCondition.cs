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

namespace Tizen.Multimedia.Vision
{
    /// <summary>
    /// Specifies the eyes state types.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum EyeCondition
    {
        /// <summary>
        /// Eyes are open.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Open,

        /// <summary>
        /// Eyes are closed.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Closed,

        /// <summary>
        /// The eyes condition wasn't determined.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        NotFound
    }
}
