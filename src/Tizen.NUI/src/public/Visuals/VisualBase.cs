/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
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
    /// Sets whether the actor should be focusable by keyboard navigation.<br />
    /// Visuals reuse geometry, shader etc. across controls. They ensure that the renderer and texture sets exist only when control is on window.<br />
    /// Each visual also responds to actor size and color change, and provides clipping at the renderer level.<br />
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class VisualBase : BaseHandle
    {

        /// <summary>
        /// Creates an empty visual handle.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public VisualBase() : this(Interop.VisualBase.NewVisualBase(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal VisualBase(VisualBase handle) : this(Interop.VisualBase.NewVisualBase(VisualBase.getCPtr(handle)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
        internal VisualBase(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
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

        /// <summary>
        /// Sets the transform and the control size.
        /// </summary>
        /// <param name="transform">A property map describing the transform.</param>
        /// <param name="controlSize">The size of the parent control for visuals that need to scale internally.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetTransformAndSize(PropertyMap transform, Vector2 controlSize)
        {
            Interop.VisualBase.SetTransformAndSize(SwigCPtr, PropertyMap.getCPtr(transform), Vector2.getCPtr(controlSize));
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
            float ret = Interop.VisualBase.GetHeightForWidth(SwigCPtr, width);
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
            float ret = Interop.VisualBase.GetWidthForHeight(SwigCPtr, height);
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
            Interop.VisualBase.GetNaturalSize(SwigCPtr, Size2D.getCPtr(naturalSize));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(VisualBase obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        internal void SetName(string name)
        {
            Interop.VisualBase.SetName(SwigCPtr, name);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal string GetName()
        {
            string ret = Interop.VisualBase.GetName(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetDepthIndex(int index)
        {
            Interop.VisualBase.SetDepthIndex(SwigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal int GetDepthIndex()
        {
            int ret = Interop.VisualBase.GetDepthIndex(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void CreatePropertyMap(PropertyMap map)
        {
            Interop.VisualBase.CreatePropertyMap(SwigCPtr, PropertyMap.getCPtr(map));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.VisualBase.DeleteVisualBase(swigCPtr);
        }
    }
}
