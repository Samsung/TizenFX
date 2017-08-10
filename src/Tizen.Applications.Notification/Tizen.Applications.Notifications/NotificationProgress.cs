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

namespace Tizen.Applications.Notifications
{
    /// <summary>
    /// Class containing common properties and methods of Notifications
    /// </summary>
    /// <remarks>
    /// A notification is a message that is displayed on the notification area.
    /// It is created to notify information to the user through the application.
    /// This class helps you to provide method and property for creating notification object.
    /// </remarks>
    public sealed partial class Notification
    {
        /// <summary>
        ///  Class for displaying progress notification
        ///  You must initialize progress category, current, max value when you create object.
        /// </summary>
        public sealed class ProgressType : MakerBase
        {
            private double progressCurrent;
            private double progressMax;

            /// <summary>
            /// Initializes a new instance of the <see cref="ProgressType"/> class.
            /// You must initialize category, current, max value of progress.
            /// </summary>
            /// <param name="category">The category of progress that appeared on Notification</param>
            /// <param name="current">The current value of the progress</param>
            /// <param name="max">The max value of the progress</param>
            /// <exception cref="ArgumentException">Thrown when argument is invalid</exception>
            public ProgressType(ProgressCategory category, double current, double max)
            {
                if (IsNegativeNumber(current))
                {
                    throw NotificationErrorFactory.GetException(NotificationError.InvalidParameter, "The current must be a positive integer.");
                }

                if (IsNegativeNumber(max))
                {
                    throw NotificationErrorFactory.GetException(NotificationError.InvalidParameter, "The max must be a positive integer.");
                }

                Category = category;
                ProgressCurrent = current;
                ProgressMax = max;
            }

            /// <summary>
            /// Gets or sets category of ProgressType.
            /// </summary>
            /// <seealso cref="Tizen.Applications.Notifications.ProgressCategory"></seealso>
            public ProgressCategory Category { get; set; }

            /// <summary>
            /// Gets or sets current value of ProgressType
            /// </summary>
            /// <exception cref="ArgumentException">Thrown when argument is invalid</exception>
            public double ProgressCurrent
            {
                get
                {
                    return progressCurrent;
                }

                set
                {
                    if (IsNegativeNumber(value))
                    {
                        throw NotificationErrorFactory.GetException(NotificationError.InvalidParameter, "The value must be a positive integer.");
                    }

                    progressCurrent = value;
                }
            }

            /// <summary>
            /// Gets or sets max value of ProgressType
            /// </summary>
            /// <exception cref="ArgumentException">Thrown when argument is invalid</exception>
            public double ProgressMax
            {
                get
                {
                    return progressMax;
                }

                set
                {
                    if (IsNegativeNumber(value))
                    {
                        throw NotificationErrorFactory.GetException(NotificationError.InvalidParameter, "The value must be a positive integer.");
                    }

                    progressMax = value;
                }
            }

            internal override void Make(Notification notification)
            {
                ProgressBinder.BindObject(notification);
            }

            private bool IsNegativeNumber(double number)
            {
                return number < 0;
            }
        }
    }
}
