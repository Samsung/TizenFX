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
    /// Class for event arguments of the media key.
    /// </summary>
    public class MediaKeyEventArgs : EventArgs
    {
        /// <summary>
        /// Enumeration for Key value.
        /// </summary>
        public enum KeyValue
        {
            /// <summary>
            /// Play key.
            /// </summary>
            Play,

            /// <summary>
            /// Stop key.
            /// </summary>
            Stop,

            /// <summary>
            /// Pause key.
            /// </summary>
            Pause,

            /// <summary>
            /// Previous key.
            /// </summary>
            Previous,

            /// <summary>
            /// Next key.
            /// </summary>
            Next,

            /// <summary>
            /// Fast forward key.
            /// </summary>
            FastForward,

            /// <summary>
            /// Rewind key.
            /// </summary>
            Rewind,

            /// <summary>
            /// Play-pause key.
            /// </summary>
            PlayPause,

            /// <summary>
            /// Media key for earjack.
            /// </summary>
            Media,

            /// <summary>
            /// Unknown key.
            /// </summary>
            Unknown
        }

        /// <summary>
        /// Enumeration for Key status.
        /// </summary>
        public enum KeyStatus
        {
            /// <summary>
            /// Pressed status.
            /// </summary>
            Pressed,

            /// <summary>
            /// Released status.
            /// </summary>
            Released,

            /// <summary>
            /// Unknown status.
            /// </summary>
            Unknown
        }

        /// <summary>
        /// Key value.
        /// </summary>
        public KeyValue Value { get; internal set; }

        /// <summary>
        /// Key status.
        /// </summary>
        public KeyStatus Status { get; internal set; }
    }

    /// <summary>
    /// Class for receiving events of media keys.
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
        /// <exception cref="InvalidOperationException">Failed to reserve or release key.</exception>
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

