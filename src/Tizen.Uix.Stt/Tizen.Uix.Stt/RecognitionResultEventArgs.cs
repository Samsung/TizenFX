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
using System.Runtime.InteropServices;
using static Interop.Stt;
using static Tizen.Uix.Stt.ResultTime;

namespace Tizen.Uix.Stt
{
    /// <summary>
    /// The recognition result from the engine.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class RecognitionResultEventArgs
    {
        private ResultEvent _result;
        private List<string> _data = new List<string>();
        private ResultMessage _msg;
        private int _dataCount;

        internal RecognitionResultEventArgs(ResultEvent e, IntPtr data, int count, string msg)
        {
            _result = e;
            switch (msg)
            {
                case "stt.result.message.none":
                    {
                        _msg = ResultMessage.None;
                        break;
                    }

                case "stt.result.message.error.too.soon":
                    {
                        _msg = ResultMessage.TooSoon;
                        break;
                    }

                case "stt.result.message.error.too.short":
                    {
                        _msg = ResultMessage.TooShort;
                        break;
                    }

                case "stt.result.message.error.too.long":
                    {
                        _msg = ResultMessage.TooLong;
                        break;
                    }

                case "stt.result.message.error.too.quiet":
                    {
                        _msg = ResultMessage.TooQuiet;
                        break;
                    }

                case "stt.result.message.error.too.loud":
                    {
                        _msg = ResultMessage.TooLoud;
                        break;
                    }

                case "stt.result.message.error.too.fast":
                    {
                        _msg = ResultMessage.TooFast;
                        break;
                    }

            }

            this._dataCount = count;

            _data.Clear();
            if (count > 0)
            {
                IntPtr[] dataArray = new IntPtr[count];
                Marshal.Copy(data, dataArray, 0, count);
                foreach (IntPtr handle in dataArray)
                {
                    string info = Marshal.PtrToStringAnsi(handle);
                    _data.Add(info);
                }
            }
        }

        /// <summary>
        /// The result event.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public ResultEvent Result
        {
            get
            {
                return _result;
            }
        }

        /// <summary>
        /// The result text.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public IEnumerable<string> Data
        {
            get
            {
                return _data;
            }
        }

        /// <summary>
        /// Returns the result text count.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int DataCount
        {
            get
            {
                return _dataCount;
            }
        }

        /// <summary>
        /// The engine message.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public ResultMessage Message
        {
            get
            {
                return _msg;
            }
        }
    }
}
