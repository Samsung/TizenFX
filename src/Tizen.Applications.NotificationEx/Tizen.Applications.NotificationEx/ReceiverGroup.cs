/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Applications.NotificationEx
{
    public partial class NotificationEx
    {
        /// <summary>
        /// The ReciverGroups class.
        /// This class contains predefined receiver groups.
        /// Manager can be included to specific reciver group when it is created.
        /// If notification item assigns it's reciver-group using AddReceiverGroup API, 
        /// which included in the assigned reciver-group, are able to receive the notification item.
        /// </summary>
        /// <since_tizen> 7 </since_tizen>
        public static class ReceiverGroups
        {
            /// <summary>
            /// A panel group.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            public static string Panel
            {
                get { return "tizen.org/receiver/panel"; }
            }

            /// <summary>
            /// A ticker group.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            public static string Ticker
            {
                get { return "tizen.org/receiver/ticker"; }
            }

            /// <summary>
            /// A lockscreen group.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            public static string Lockscreen
            {
                get { return "tizen.org/receiver/lockscreen"; }
            }

            /// <summary>
            /// A indicator group.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            public static string Indicator
            {
                get { return "tizen.org/receiver/indicator"; }
            }

            /// <summary>
            /// A popup group.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            public static string Popup
            {
                get { return "tizen.org/receiver/popup"; }
            }
        }
    }
}
