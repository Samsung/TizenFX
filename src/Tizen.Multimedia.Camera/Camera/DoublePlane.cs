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

using System.Runtime.InteropServices;
using static Interop.Camera;

namespace Tizen.Multimedia
{
    /// <summary>
    /// The class containing image data which has two planes.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class DoublePlane : IPreviewPlane
    {
        internal DoublePlane(DoublePlaneStruct unmanaged)
        {
            Y = new byte[unmanaged.YLength];
            UV = new byte[unmanaged.UVLength];
            Marshal.Copy(unmanaged.Y, Y, 0, (int)unmanaged.YLength);
            Marshal.Copy(unmanaged.UV, UV, 0, (int)unmanaged.UVLength);
        }

        /// <summary>
        /// The Y plane data.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public byte[] Y { get; }

        /// <summary>
        /// The UV plane data.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public byte[] UV { get; }
    }
}
