/*
 * Copyright(c) 2019 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Tizen.NUI
{
    /// <summary>
    /// TextureSet is a handle to an object that specifies the set of images used as textures by a renderer.<br />
    /// The images have to be ordered in the same order they are declared in the shader.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public partial class TextureSet : BaseHandle
    {
        /// <summary>
        /// Gets the number of textures present in the TextureSet.
        /// </summary>
        /// <returns>The number of textures in the TextureSet.</returns>
        /// <since_tizen> 3 </since_tizen>
        public uint GetTextureCount()
        {
            uint ret = Interop.TextureSet.GetTextureCount(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
    }
}
