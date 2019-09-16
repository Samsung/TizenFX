/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd.
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
    /// [Draft]
    /// Interface that defines a layout Parent. Enables a layout child to access methods on its parent, e.g. Remove (during unparenting)
    /// </summary>
    public interface ILayoutParent
    {
        /// <summary>
        /// Add this child to the parent.
        /// </summary>
        /// <param name="layoutItem">The layout child to add.</param>
        /// <since_tizen> 6 </since_tizen>
        void Add(LayoutItem layoutItem);

        /// <summary>
        /// Remove this child from the parent
        /// </summary>
        /// <param name="layoutItem">The layout child to add.</param>
        /// <since_tizen> 6 </since_tizen>
        void Remove(LayoutItem layoutItem);
    }
}
