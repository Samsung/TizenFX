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
    using Tizen.Common;

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
        ///  Class for Notification AccessorySet which is included vibration, led, sound option
        /// </summary>
        public sealed class AccessorySet : MakerBase
        {
            /// <summary>
            /// Gets or sets the sound option. Default to AccessoryOption.Off.
            /// </summary>
            /// <remarks>
            /// If you set AccessoryOption.Custom and not set SoundPath, then turn on the default sound.
            /// </remarks>
            public AccessoryOption SoundOption { get; set; } = AccessoryOption.Off;

            /// <summary>
            /// Gets or sets the sound path, It will play on the sound file you set.
            /// </summary>
            public string SoundPath { get; set; }

            /// <summary>
            /// Gets or sets a value indicating whether vibration is operated. Default to false.
            /// </summary>
            public bool CanVibrate { get; set; } = false;

            /// <summary>
            /// Gets or sets the led option. Default to AccessoryOption.Off.
            /// </summary>
            /// <remarks>
            /// If you set AccessoryOption.Custom and not set LedColor, then turn on the LED with default color.
            /// </remarks>
            public AccessoryOption LedOption { get; set; } = AccessoryOption.Off;

            /// <summary>
            /// Gets or sets the led on time period that you would like the LED on the device to blink. as well as the rate
            /// </summary>
            /// <remarks>
            /// Default value of LedOnMillisecond is 0.
            /// The rate is specified in terms of the number of Milliseconds to be on.
            /// You should always set LedOnMillisecond with LedOffMillisecond. Otherwise, it may not operate normally.
            /// </remarks>
            public int LedOnMillisecond { get; set; }

            /// <summary>
            /// Gets or sets the led on time period that you would like the LED on the device to blink. as well as the rate.
            /// </summary>
            /// <remarks>
            /// The rate is specified in terms of the number of Milliseconds to be off.
            /// You should always set LedOffMillisecond with LedOnMillisecond. Otherwise, it may not operate normally.
            /// </remarks>
            public int LedOffMillisecond { get; set; }

            /// <summary>
            /// Gets or sets the led color that you would like the LED on the device to blink.
            /// </summary>
            /// <remarks>
            /// If you want to set LedColor, you should always set LedOption is AccessoryOption.Custom. Otherwise, it may operate default led color.
            /// </remarks>
            public Color LedColor { get; set; }

            internal override void Make(Notification notification)
            {
                AccessorySetBinder.BindObject(notification);
            }
        }
    }
}
