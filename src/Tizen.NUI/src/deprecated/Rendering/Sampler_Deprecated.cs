/*
 * Copyright(c) 2017 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI
{
    /// <summary>
    /// Sampler is a handle to an object that can be used to provide the sampling parameters to sample textures.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public partial class Sampler : BaseHandle
    {
        /// <summary>
        /// Sets the filter modes for this sampler.
        /// </summary>
        /// <param name="minFilter">The minification filter that will be used.</param>
        /// <param name="magFilter">The magnification filter that will be used.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetFilterMode(FilterModeType minFilter, FilterModeType magFilter)
        {
            Interop.Sampler.SetFilterMode(SwigCPtr, (int)minFilter, (int)magFilter);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
    }
}
