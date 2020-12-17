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

namespace ElmSharp
{
    /// <summary>
    /// Predefined values for the hint properties in EvasObject.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public static class NamedHint
    {
        /// <summary>
        /// This value can be used for <see cref="EvasObject.WeightX"/> and <see cref="EvasObject.WeightY"/>.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public static readonly double Expand = 1.0;

        /// <summary>
        /// This value can be used for <see cref="EvasObject.AlignmentX"/> and <see cref="EvasObject.AlignmentY"/>.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public static readonly double Fill = -1.0;
    }
}
