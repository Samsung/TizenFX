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
    /// The class for event arguments of the media key.
    /// </summary>
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
    /// The class for receiving events of media keys.
    /// </summary>
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
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="InvalidOperationException">Failed to reserve or release the key.</exception>
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

