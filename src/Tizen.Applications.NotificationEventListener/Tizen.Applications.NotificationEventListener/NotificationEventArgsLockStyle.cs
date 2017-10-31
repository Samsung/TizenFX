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
    /// <summary>
    /// This class provides methods and properties to get information about the posted or updated notification.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public partial class NotificationEventArgs
    {
        /// <summary>
        ///  Class to get infomation about notification lock style.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public class LockStyleArgs : StyleArgs
        {
            /// <summary>
            /// Gets the path of the image file to display on the icon of lock style.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public string IconPath { get; internal set; }

            /// <summary>
            /// Gets the path of the thumbnail image file to display on the icon of lock style.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public string Thumbnail { get; internal set; }

            internal override string Key
            {
                get
                {
                    return "Lock";
                }
            }
        }
    }
}
