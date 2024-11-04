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

namespace Tizen.System
{
    /// <summary>
    /// Event arguments class for handling media key events.
    /// </summary>
    /// <remarks>
    /// This class provides properties that contain information about the media key event, such as the key value and key status.
    /// By implementing handlers for the appropriate events, you can respond to user interactions with media keys on supported devices.
    /// </remarks>
    /// <since_tizen> 3 </since_tizen>
    public class MediaKeyEventArgs : EventArgs
    {
        /// <summary>
        /// Enumeration for the key value.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public enum KeyValue
        {
            /// <summary>
            /// The play key.
            /// </summary>
            Play,

            /// <summary>
            /// The stop key.
            /// </summary>
            Stop,

            /// <summary>
            /// The pause key.
            /// </summary>
            Pause,

            /// <summary>
            /// The previous key.
            /// </summary>
            Previous,

            /// <summary>
            /// The next key.
            /// </summary>
            Next,

            /// <summary>
            /// The fast forward key.
            /// </summary>
            FastForward,

            /// <summary>
            /// The rewind key.
            /// </summary>
            Rewind,

            /// <summary>
            /// The play-pause key.
            /// </summary>
            PlayPause,

            /// <summary>
            /// The media key for the earjack.
            /// </summary>
            Media,

            /// <summary>
            /// The unknown key.
            /// </summary>
            Unknown
        }

        /// <summary>
        /// Enumeration for the key status.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public enum KeyStatus
        {
            /// <summary>
            /// The pressed status.
            /// </summary>
            Pressed,

            /// <summary>
            /// The released status.
            /// </summary>
            Released,

            /// <summary>
            /// The unknown status.
            /// </summary>
            Unknown
        }

        /// <summary>
        /// The key value.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public KeyValue Value { get; internal set; }

        /// <summary>
        /// The key status.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public KeyStatus Status { get; internal set; }
    }

    /// <summary>
    /// A class that provides methods for handling media key events.
    /// </summary>
    /// <remarks>
    /// This class enables developers to receive and handle events triggered by various media keys such as play/pause, volume up/down, etc.
    /// By implementing the appropriate event handlers, applications can respond accordingly to user input from these keys.
    /// </remarks>
    /// <since_tizen> 3 </since_tizen>
    public static class MediaKey
    {
        private static EventHandler<MediaKeyEventArgs> s_eventHandler;
        private static Interop.MediaKey.EventCallback s_callback;

        private static void OnEvent(Interop.MediaKey.KeyValue value, Interop.MediaKey.KeyStatus status, IntPtr userData)
        {
            s_eventHandler?.Invoke(null, new MediaKeyEventArgs()
            {
                Value = (MediaKeyEventArgs.KeyValue)value,
                Status = (MediaKeyEventArgs.KeyStatus)status
            });
        }

        /// <summary>
        /// Adds or removes events for all media keys.
        /// </summary>
        /// <remarks>
        /// By subscribing to this event, you can receive notifications about user interactions with media keys such as play/pause, volume up/down, etc.
        /// To handle these events, you need to provide a callback function that implements the EventHandler&lt;MediaKeyEventArgs&gt; delegate.
        /// In case of failure while reserving or releasing the key, an InvalidOperationException will be thrown.
        /// </remarks>
        /// <exception cref="InvalidOperationException">Failed to reserve or release the key.</exception>
        /// <since_tizen> 3 </since_tizen>
        public static event EventHandler<MediaKeyEventArgs> Event
        {
            add
            {
                if (s_eventHandler == null)
                {
                    if (s_callback == null)
                        s_callback = new Interop.MediaKey.EventCallback(OnEvent);
                    Interop.MediaKey.ErrorCode err = Interop.MediaKey.Reserve(s_callback, IntPtr.Zero);

                    if (err != Interop.MediaKey.ErrorCode.None)
                    {
                        throw new InvalidOperationException("Failed to reserve key. err = " + err);
                    }

                }
                s_eventHandler += value;

            }
            remove
            {
                s_eventHandler -= value;
                if (s_eventHandler == null)
                {
                    Interop.MediaKey.ErrorCode err = Interop.MediaKey.Release();

                    if (err != Interop.MediaKey.ErrorCode.None)
                    {
                        throw new InvalidOperationException("Failed to release key. err = " + err);
                    }
                    s_callback = null;
                }
            }
        }
    }
}

