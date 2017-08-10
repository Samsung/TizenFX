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
        ///  Class to get infomation about Progress Notification.
        /// </summary>
        public class ProgressArgs
        {
            /// <summary>
            /// Gets category of ProgressType.
            /// </summary>
            public ProgressCategory Category { get; internal set; }

            /// <summary>
            /// Gets current value of ProgressType.
            /// </summary>
            public double Current { get; internal set; }

            /// <summary>
            /// Gets max value of ProgressType.
            /// </summary>
            public double Max { get; internal set; }
        }
    }
}