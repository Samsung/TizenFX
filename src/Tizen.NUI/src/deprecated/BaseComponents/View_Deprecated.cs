/*
 * Copyright(c) 2022 Samsung Electronics Co., Ltd.
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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Tizen.NUI.Binding;

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// View is the base class for all views.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public partial class View : Container, IResourcesProvider
    {
        /// <summary>
        /// Gets the number of renderers held by the view.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public uint RendererCount
        {
            get
            {
                return GetRendererCount();
            }
        }

        /// <summary>
        /// Adds a renderer to the view.
        /// </summary>
        /// <param name="renderer">The renderer to add.</param>
        /// <returns>The index of the Renderer that was added to the view.</returns>
        /// <since_tizen> 3 </since_tizen>
        public uint AddRenderer(Renderer renderer)
        {
            uint ret = Interop.Actor.AddRenderer(SwigCPtr, Renderer.getCPtr(renderer));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves the renderer at the specified index.
        /// </summary>
        /// <param name="index">The index of the renderer to retrieve.</param>
        /// <returns>A Renderer object at the specified index.</returns>
        /// <remarks>
        /// The index must be between 0 and GetRendererCount()-1
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public Renderer GetRendererAt(uint index)
        {
            IntPtr cPtr = Interop.Actor.GetRendererAt(SwigCPtr, index);
            Renderer ret = Registry.GetManagedBaseHandleFromNativePtr(cPtr) as Renderer;
            if (ret != null)
            {
                Interop.BaseHandle.DeleteBaseHandle(new HandleRef(this, cPtr));
                NDalicPINVOKE.ThrowExceptionIfExists();
                return ret;
            }
            else
            {
                ret = new Renderer(cPtr, true);
                return ret;
            }
        }

        /// <summary>
        /// Removes the specified renderer from the view.
        /// </summary>
        /// <param name="renderer">The renderer to remove.</param>
        /// <since_tizen> 3 </since_tizen>
        public void RemoveRenderer(Renderer renderer)
        {
            Interop.Actor.RemoveRenderer(SwigCPtr, Renderer.getCPtr(renderer));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Removes a renderer at the specified index from the view.
        /// </summary>
        /// <param name="index">The index of the renderer to remove.</param>
        /// <since_tizen> 3 </since_tizen>
        public void RemoveRenderer(uint index)
        {
            Interop.Actor.RemoveRenderer(SwigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
    }
}
