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
    using Tizen.Common;

    public partial class NotificationEventArgs
    {
        public class AccessoryArgs
        {
            /// <summary>
            /// Gets the sound option.
            /// </summary>
            /// <example>
            /// <code>
            /// AccessoryOption vibrationOption = NotificationEventArgs.Accessory.SoundOption;
            /// </code>
            /// </example>
            public AccessoryOption SoundOption { get; internal set; }

            /// <summary>
            /// Gets the sound path.
            /// </summary>
            /// <example>
            /// <code>
            /// string soundPath = NotificationEventArgs.Accessory.SountPath;
            /// </code>
            /// </example>
            public string SountPath { get; internal set; }

            /// <summary>
            /// Gets the vibration option.
            /// </summary>
            /// <example>
            /// <code>
            /// bool vibrationOption = NotificationEventArgs.Accessory.CanVibrate;
            /// </code>
            /// </example>
            public bool CanVibrate { get; internal set; }

            /// <summary>
            /// Gets the led option.
            /// </summary>
            /// <example>
            /// <code>
            /// AccessoryOption ledOption = NotificationEventArgs.Accessory.LedOption;
            /// </code>
            /// </example>
            public AccessoryOption LedOption { get; internal set; }

            /// <summary>
            /// Gets led on time period that you would like the LED on the device to blink. as well as the rate.
            /// </summary>
            /// <value>
            /// Default value of LedOnMilliseconds is 0.
            /// The rate is specified in terms of the number of milliseconds to be on.
            /// You should always set the LedOnMillisecond and LedOffMillisecond. Otherwise, it may not operate normally.
            /// </value>
            /// <example>
            /// <code>
            /// int ledOnMillisecond = NotificationEventArgs.Accessory.LedOnMillisecond;
            /// </code>
            /// </example>
            public int LedOnMillisecond { get; internal set; }

            /// <summary>
            /// Gets led on time period that you would like the LED on the device to blink. as well as the rate.
            /// </summary>
            /// <value>
            /// Default value of LedOffMillisecond is 0.
            /// The rate is specified in terms of the number of millisecond to be off.
            /// You should always set the LedOnMillisecond and LedOffMillisecond. Otherwise, it may not operate normally.
            /// </value>
            /// <example>
            /// <code>
            /// int ledOffMillisecond = NotificationEventArgs.Accessory.LedOffMillisecond;
            /// </code>
            /// </example>
            public int LedOffMillisecond { get; internal set; }

            /// <summary>
            /// Gets led color that you would like the LED on the device to blink.
            /// </summary>
            /// <example>
            /// <code>
            /// Color ledColor = NotificationEventArgs.Accessory.LedColor;
            /// </code>
            /// </example>
            public Color LedColor { get; internal set; }
        }
    }
}