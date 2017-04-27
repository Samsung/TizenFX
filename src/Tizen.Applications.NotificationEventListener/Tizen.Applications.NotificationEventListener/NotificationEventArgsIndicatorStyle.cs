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
    /// This class provides the methods and properties to get information about the posted or updated notification.
    /// </summary>
    public partial class NotificationEventArgs
    {
        /// <summary>
        ///  Class to generate the Indicator style notification.
        /// </summary>
        public class IndicatorStyleArgs : StyleArgs
        {
            /// <summary>
            /// Gets the path of the image to display on the icon of the indicator style.
            /// </summary>
            /// <example>
            /// <code>
            /// string iconPath = NotificationEventArgs.IndicatorStyleArgs.IconPath;
            /// </code>
            /// </example>
            public string IconPath { get; internal set; }

            /// <summary>
            /// Gets the sub text to display Indicator style.
            /// </summary>
            /// <example>
            /// <code>
            /// string subText = NotificationEventArgs.IndicatorStyleArgs.SubText;
            /// </code>
            /// </example>
            public string SubText { get; internal set; }

            internal override string Key
            {
                get
                {
                    return "Indicator";
                }
            }
        }
    }
}
