/*
 * Copyright(c) 2024 Samsung Electronics Co., Ltd.
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

using System.ComponentModel;

namespace Tizen.NUI.AIAvatar
{
    /// <summary>
    /// The type of predefined node. We can customize each type name by "TODO_mapper"
    /// The basic names provided by AIAvatar to control the default avatar of AREmoji.
    /// Contains the node information of AIAvatar.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal enum NodeType
    {
        /// <summary>
        /// head geometry
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        HeadGeo,
        /// <summary>
        /// mouth geometry
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        MouthGeo,
        /// <summary>
        /// eyelash geometry
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        EyelashGeo
    }
}
