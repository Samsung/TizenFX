/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Applications.NotificationEventListener
{
    using System.ComponentModel;

    /// <summary>
    /// This class provides methods and properties to get information about the posted or updated notification.
    /// </summary>
    public partial class NotificationEventArgs
    {
        /// <summary>
        ///  Class to generate the extension style notification.
        /// </summary>
        /// <since_tizen> 14 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class ExtensionStyleArgs : StyleArgs
        {
            [EditorBrowsable(EditorBrowsableState.Never)]
            public bool IsActive { get; set; }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public string ExtensionImagePath { get; set; }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public int ExtensionImageSize { get; set; }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public bool IsThumbnail { get; set; } = false;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public string ThumbnailImagePath { get; set; }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public AppControl ThumbnailAction { get; set; }

            internal override string Key
            {
                get
                {
                    return "Extension";
                }
            }
        }
    }
}
