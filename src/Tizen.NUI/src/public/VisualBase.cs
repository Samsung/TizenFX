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

using System;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace Tizen.NUI
{

    /// <summary>
    /// Sets whether the actor should be focusable by keyboard navigation.<br />
    /// Visuals reuse geometry, shader etc. across controls. They ensure that the renderer and texture sets exist only when control is on window.<br />
    /// Each visual also responds to actor size and color change, and provides clipping at the renderer level.<br />
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class VisualBase : BaseHandle
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal VisualBase(global::System.IntPtr cPtr, bool cMemoryOwn) : base(NDalicPINVOKE.VisualBase_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(VisualBase obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        /// <param name="type">The dispose type</param>
        /// <since_tizen> 3 </since_tizen>
        protected override void Dispose(DisposeTypes type)
        {
            if(disposed)
            {
                return;
            }

            if(type == DisposeTypes.Explicit)
            {
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.

            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;
                    NDalicPINVOKE.delete_VisualBase(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }

        /// <summary>
        /// Creates an empty visual handle.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public VisualBase() : this(NDalicPINVOKE.new_VisualBase__SWIG_0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal VisualBase(VisualBase handle) : this(NDalicPINVOKE.new_VisualBase__SWIG_1(VisualBase.getCPtr(handle)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The name of the visual.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Name
        {
            set
            {
                SetName(value);
            }
            get
            {
                return GetName();
            }
        }

        internal void SetName(string name)
        {
            NDalicPINVOKE.VisualBase_SetName(swigCPtr, name);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal string GetName()
        {
            string ret = NDalicPINVOKE.VisualBase_GetName(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets the transform and the control size.
        /// </summary>
        /// <param name="transform">A property map describing the transform.</param>
        /// <param name="controlSize">The size of the parent control for visuals that need to scale internally.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetTransformAndSize(PropertyMap transform, Vector2 controlSize)
        {
            NDalicPINVOKE.VisualBase_SetTransformAndSize(swigCPtr, PropertyMap.getCPtr(transform), Vector2.getCPtr(controlSize));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Returns the height for a given width.
        /// </summary>
        /// <param name="width">The width to use.</param>
        /// <returns>The height based on the width.</returns>
        /// <since_tizen> 3 </since_tizen>
        public float GetHeightForWidth(float width)
        {
            float ret = NDalicPINVOKE.VisualBase_GetHeightForWidth(swigCPtr, width);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Returns the width for a given height.
        /// </summary>
        /// <param name="height">The height to use.</param>
        /// <returns>The width based on the height.</returns>
        /// <since_tizen> 3 </since_tizen>
        public float GetWidthForHeight(float height)
        {
            float ret = NDalicPINVOKE.VisualBase_GetWidthForHeight(swigCPtr, height);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Returns the natural size of the visual.<br />
        /// Deriving classes stipulate the natural size and by default a visual has a zero natural size.<br />
        /// A visual may not actually have a natural size until it has been placed on window and acquired all it's resources.<br />
        /// </summary>
        /// <param name="naturalSize">The visual's natural size.</param>
        /// <since_tizen> 3 </since_tizen>
        public void GetNaturalSize(Size2D naturalSize)
        {
            NDalicPINVOKE.VisualBase_GetNaturalSize(swigCPtr, Size2D.getCPtr(naturalSize));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The depth index of this visual.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int DepthIndex
        {
            set
            {
                SetDepthIndex(value);
            }
            get
            {
                return GetDepthIndex();
            }
        }
        internal void SetDepthIndex(int index)
        {
            NDalicPINVOKE.VisualBase_SetDepthIndex(swigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal int GetDepthIndex()
        {
            int ret = NDalicPINVOKE.VisualBase_GetDepthIndex(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Creates the property map representing this visual.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap Creation
        {
            get
            {
                PropertyMap map = new PropertyMap();
                CreatePropertyMap(map);
                return map;
            }
        }

        internal void CreatePropertyMap(PropertyMap map)
        {
            NDalicPINVOKE.VisualBase_CreatePropertyMap(swigCPtr, PropertyMap.getCPtr(map));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

    }

}
