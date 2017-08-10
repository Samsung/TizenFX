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
using Native = Interop.StreamRecorder;

namespace Tizen.Multimedia
{
    /// <summary>
    /// Resolution for stream recorder.
    /// </summary>
    public class StreamRecorderVideoResolution
    {
        private int _width, _height;
        private bool _interopFlag;
        internal IntPtr _Handle;

        internal StreamRecorderVideoResolution(IntPtr handle)
        {
            _Handle = handle;
            _interopFlag = true;
            int ret = Native.GetVideoResolution(_Handle, out _width, out _height);
            StreamRecorderError err = (StreamRecorderError)ret;
            Log.Info(StreamRecorderLog.Tag, "width " + _width + " height " + _height + "return " + err.ToString());
        }

        internal StreamRecorderVideoResolution(int width, int height)
        {
            _interopFlag = false;
            _width = width;
            _height = height;
        }

        /// <summary>
        /// The video width.
        /// </summary>
        /// <value>The width.</value>
        public int Width {
            get {
                if(_interopFlag == true)
                    Native.GetVideoResolution(_Handle, out _width, out _height);
                return _width;
            }
            set {
                _width = value;
                if(_interopFlag == true) {
                    int ret = Native.SetVideoResolution(_Handle, _width, _height);
                    StreamRecorderError err = (StreamRecorderError)ret;
                    Log.Info(StreamRecorderLog.Tag, " set width " + _width + " height " + _height + "set return " + err.ToString());
                }
            }
        }

        /// <summary>
        /// The video height.
        /// </summary>
        /// <value>The height.</value>
        public int Height {
            get {
                if(_interopFlag == true)
                    Native.GetVideoResolution(_Handle, out _width, out _height);
                return _height;
            }
            set {
                _height = value;
                if(_interopFlag == true) {
                    int ret = Native.SetVideoResolution(_Handle, _width, _height);
                    StreamRecorderError err = (StreamRecorderError)ret;
                    Log.Info(StreamRecorderLog.Tag, " set width " + _width + " height " + _height + "set return " + err.ToString());
                }
            }
        }
    }
}
