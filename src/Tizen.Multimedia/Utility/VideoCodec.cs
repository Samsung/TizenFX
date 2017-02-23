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

namespace Tizen.Multimedia.Utility
{
    /// <summary>
    /// Video codec for trans-coding
    /// </summary>
    public enum VideoCodec
    {
        /// <summary>
        /// No trans-coding for video
        /// </summary>
        None = Interop.VideoCodec.None,
        /// <summary>
        /// MPEG4
        /// </summary>
        Mpeg4 = Interop.VideoCodec.Mpeg4,
        /// <summary>
        /// H263
        /// </summary>
        H263 = Interop.VideoCodec.H263,
        /// <summary>
        /// H264
        /// </summary>
        H264 = Interop.VideoCodec.H264,
    }
}