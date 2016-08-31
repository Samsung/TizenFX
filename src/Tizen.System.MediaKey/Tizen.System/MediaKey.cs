// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

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
        /// <exception cref="InvalidOperationException">Failed to reserve or release key"</exception>
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

