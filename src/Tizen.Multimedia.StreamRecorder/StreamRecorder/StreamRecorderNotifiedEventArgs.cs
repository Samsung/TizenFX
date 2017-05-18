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
using System.Collections.Generic;

namespace Tizen.Multimedia
{
    /// <summary>
    /// An extended Eventargs class which contains interrupted policy details, previous and current
    /// state of the recorder.
    /// </summary>
    public class StreamRecorderNotifiedEventArgs : EventArgs
    {
        private StreamRecorderState _previous = StreamRecorderState.None;
        private StreamRecorderState _current = StreamRecorderState.None;
        private StreamRecorderNotify _notify = StreamRecorderNotify.None;

        internal StreamRecorderNotifiedEventArgs(StreamRecorderState previous, StreamRecorderState current, StreamRecorderNotify notify)
        {
            _previous = previous;
            _current = current;
            _notify = notify;
        }

        /// <summary>
        /// The previous state of the stream recorder.
        /// </summary>
        public StreamRecorderState Previous {
            get {
                return _previous;
            }
        }

        /// <summary>
        /// The current state of the stream recorder.
        /// </summary>
        public StreamRecorderState Current {
            get {
                return _current;
            }
        }

        /// <summary>
        /// The notify of the event.
        /// </summary>
        public StreamRecorderNotify Notify {
            get {
                return _notify;
            }
        }
    }
}
