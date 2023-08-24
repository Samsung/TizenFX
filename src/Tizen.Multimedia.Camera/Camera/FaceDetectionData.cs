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
using System.Runtime.InteropServices;
using static Interop.Camera;

namespace Tizen.Multimedia
{
    /// <summary>
    /// The class contains the details of the detected face.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class FaceDetectionData
    {
        internal FaceDetectionData(IntPtr ptr)
        {
            var unmanagedStruct = Marshal.PtrToStructure<DetectedFaceStruct>(ptr);

            Id = unmanagedStruct.Id;
            Score = unmanagedStruct.Score;
            X = unmanagedStruct.X;
            Y = unmanagedStruct.Y;
            Width = unmanagedStruct.Width;
            Height = unmanagedStruct.Height;
        }

        /// <summary>
        /// The ID of each face.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int Id { get; }

        /// <summary>
        /// The confidence level for the detection of the face.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int Score { get; }

        /// <summary>
        /// The X co-ordinate of the face.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int X { get; }

        /// <summary>
        /// The Y co-ordinate of the face.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int Y { get; }

        /// <summary>
        /// The width of the face.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int Width { get; }

        /// <summary>
        /// The height of the face.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int Height { get; }
    }
}
