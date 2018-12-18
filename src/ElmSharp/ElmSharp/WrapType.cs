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

namespace ElmSharp
{
    /// <summary>
    /// Enumeration for the wrap types.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public enum WrapType
    {
        /// <summary>
        /// No wrap.
        /// </summary>
        None = 0,
        /// <summary>
        /// Char wrap - wrap between characters.
        /// </summary>
        Char,
        /// <summary>
        /// Word wrap - wrap within the allowed wrapping points.
        /// (as defined in the unicode standard).
        /// </summary>
        Word,
        /// <summary>
        /// Mixed wrap - word wrap, if that fails, char wrap.
        /// </summary>
        Mixed
    }
}
