/*
 * Copyright(c) 2025 Samsung Electronics Co., Ltd.
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
        /// Create an instance of TextureSet.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public TextureSet() : this(Interop.TextureSet.New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal TextureSet(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// Gets texture count.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint TextureCount
        {
            get => RetrieveTextureCount();
        }

        /// <summary>
        /// Sets the texture at position "index".
        /// </summary>
        /// <param name="index">The position in the texture set of the texture.</param>
        /// <param name="texture">The texture.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetTexture(uint index, Texture texture)
        {
            Interop.TextureSet.SetTexture(SwigCPtr, index, Texture.getCPtr(texture));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Removes the texture at position "index".
        /// </summary>
        /// <param name="index">The position in the texture set of the texture.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RemoveTexture(uint index)
        {
            Interop.TextureSet.RemoveTexture(SwigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the image at position "index".
        /// </summary>
        /// <param name="index">The position in the texture set of the image.</param>
        /// <returns>A handle to the image at the specified position.</returns>
        /// <since_tizen> 3 </since_tizen>
        public Texture GetTexture(uint index)
        {
            global::System.IntPtr cPtr = Interop.TextureSet.GetTexture(SwigCPtr, index);
            Texture ret = Registry.GetManagedBaseHandleFromNativePtr(cPtr) as Texture;
            if (ret != null)
            {
                Interop.BaseHandle.DeleteBaseHandle(new global::System.Runtime.InteropServices.HandleRef(this, cPtr));
                NDalicPINVOKE.ThrowExceptionIfExists();
                return ret;
            }
            else
            {
                ret = new Texture(cPtr, true);
                return ret;
            }
        }

        /// <summary>
        /// Sets the sampler to be used by the image at position "index".
        /// </summary>
        /// <param name="index">The position in the texture set of the image.</param>
        /// <param name="sampler">The sampler to use.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetSampler(uint index, Sampler sampler)
        {
            Interop.TextureSet.SetSampler(SwigCPtr, index, Sampler.getCPtr(sampler));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Removes the sampler at position "index".
        /// </summary>
        /// <param name="index">The position in the texture set of the sampler.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RemoveSampler(uint index)
        {
            Interop.TextureSet.RemoveSampler(SwigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets the sampler to be used by the image at position "index".
        /// </summary>
        /// <param name="index">The position in the texture set of the image.</param>
        /// <returns>A handle to the sampler at the specified position.</returns>
        /// <since_tizen> 3 </since_tizen>
        public Sampler GetSampler(uint index)
        {
            global::System.IntPtr cPtr = Interop.TextureSet.GetSampler(SwigCPtr, index);
            Sampler ret = Registry.GetManagedBaseHandleFromNativePtr(cPtr) as Sampler;
            if (ret != null)
            {
                Interop.BaseHandle.DeleteBaseHandle(new global::System.Runtime.InteropServices.HandleRef(this, cPtr));
                NDalicPINVOKE.ThrowExceptionIfExists();
                return ret;
            }
            else
            {
                ret = new Sampler(cPtr, true);
                return ret;
            }
        }

        /// <summary>
        /// Gets the number of textures present in the TextureSet.
        /// </summary>
        /// <returns>The number of textures in the TextureSet.</returns>
        private uint RetrieveTextureCount()
        {
            uint ret = Interop.TextureSet.GetTextureCount(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.TextureSet.DeleteTextureSet(swigCPtr);
        }
    }
}
