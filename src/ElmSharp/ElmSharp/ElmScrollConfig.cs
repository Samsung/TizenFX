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
using System.ComponentModel;

namespace ElmSharp
{
    /// <summary>
    /// The ElmScrollConfig is a scrollable views's configuration.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public static class ElmScrollConfig
    {
        /// <summary>
        /// Gets or sets the amount of inertia that a scroller imposes during the region to bring animations.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static double BringInScrollFriction
        {
            get
            {
                return Elementary.BringInScrollFriction;
            }
            set
            {
                Elementary.BringInScrollFriction = value;
            }
        }
    }
}