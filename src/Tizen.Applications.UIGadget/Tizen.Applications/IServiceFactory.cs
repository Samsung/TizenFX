/*
 * Copyright (c) 2025 Samsung Electronics Co., Ltd All Rights Reserved
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

using System.ComponentModel;

namespace Tizen.Applications
{
    /// <summary>
    /// An interface that make the OneShotService object.
    /// </summary>
    /// <since_tizen> 13 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IServiceFactory
    {
        /// <summary>
        /// Creates a new OneShotService instance.
        /// </summary>
        /// <param name="name">Unique identifier for the service instance</param>
        /// <param name="autoClose">Whether to automatically close the service after execution</param>
        /// <returns>A new OneShotService instance</returns>
        /// <since_tizen> 13 </since_tizen>
        OneShotService CreateService(string name, bool autoClose);
    }
}
