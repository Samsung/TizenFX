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

namespace Tizen.Multimedia
{
    /// <summary>
    /// An extended EventArgs class which contains details about error status and
    /// state of the recorder when it failed.
    /// </summary>
    public class RecordingErrorOccurredEventArgs : EventArgs
    {
        private RecorderErrorCode _error = RecorderErrorCode.DeviceError;
        private RecorderState _state = RecorderState.None;

        internal RecordingErrorOccurredEventArgs(RecorderErrorCode error, RecorderState state)
        {
            _error = error;
            _state = state;
        }

        /// <summary>
        /// The error code.
        /// </summary>
        public RecorderErrorCode Error {
            get {
                return _error;
            }
        }

        /// <summary>
        /// The state of the recorder.
        /// </summary>
        public RecorderState State {
            get {
                return _state;
            }
        }

    }
}
