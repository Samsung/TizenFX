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
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    /// This will be released at Tizen.NET API Level 6, so currently this would be used as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class RenderTask : Animatable
    {

        internal RenderTask(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.RenderTask.RenderTaskSwigUpcast(cPtr), cMemoryOwn)
        {
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(RenderTask obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.RenderTask.DeleteRenderTask(swigCPtr);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RenderTask GetRenderTaskFromPtr(global::System.IntPtr cPtr)
        {
            RenderTask ret = new RenderTask(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal class Property
        {
            internal static readonly int ViewportPosition = Interop.RenderTask.RenderTaskPropertyViewportPositionGet();
            internal static readonly int ViewportSize = Interop.RenderTask.RenderTaskPropertyViewportSizeGet();
            internal static readonly int ClearColor = Interop.RenderTask.RenderTaskPropertyClearColorGet();
            internal static readonly int RequiresSync = Interop.RenderTask.RenderTaskPropertyRequiresSyncGet();
        }

        internal static SWIGTYPE_p_f_r_Dali__Vector2__bool DefaultScreenToFramebufferFunction
        {
            get
            {
                global::System.IntPtr cPtr = Interop.RenderTask.RenderTaskDefaultScreenToFramebufferFunctionGet();
                SWIGTYPE_p_f_r_Dali__Vector2__bool ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_f_r_Dali__Vector2__bool(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        internal static SWIGTYPE_p_f_r_Dali__Vector2__bool FullscreenFramebufferFunction
        {
            get
            {
                global::System.IntPtr cPtr = Interop.RenderTask.RenderTaskFullscreenFramebufferFunctionGet();
                SWIGTYPE_p_f_r_Dali__Vector2__bool ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_f_r_Dali__Vector2__bool(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool DefaultExclusive
        {
            get
            {
                bool ret = Interop.RenderTask.RenderTaskDefaultExclusiveGet();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool DefaultInputEnabled
        {
            get
            {
                bool ret = Interop.RenderTask.RenderTaskDefaultInputEnabledGet();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Vector4 DefaultClearColor
        {
            get
            {
                global::System.IntPtr cPtr = Interop.RenderTask.RenderTaskDefaultClearColorGet();
                Vector4 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector4(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool DefaultClearEnabled
        {
            get
            {
                bool ret = Interop.RenderTask.RenderTaskDefaultClearEnabledGet();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool DefaultCullMode
        {
            get
            {
                bool ret = Interop.RenderTask.RenderTaskDefaultCullModeGet();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static uint DefaultRefreshRate
        {
            get
            {
                uint ret = Interop.RenderTask.RenderTaskDefaultRefreshRateGet();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public RenderTask() : this(Interop.RenderTask.NewRenderTaskSwig0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RenderTask DownCast(BaseHandle handle)
        {
            if (handle == null)
            {
                throw new global::System.ArgumentNullException(nameof(handle));
            }
            RenderTask ret = Registry.GetManagedBaseHandleFromNativePtr(handle) as RenderTask;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public RenderTask(RenderTask handle) : this(Interop.RenderTask.NewRenderTaskSwig1(RenderTask.getCPtr(handle)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public RenderTask Assign(RenderTask rhs)
        {
            RenderTask ret = new RenderTask(Interop.RenderTask.RenderTaskAssign(swigCPtr, RenderTask.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetSourceView(View view)
        {
            Interop.RenderTask.RenderTaskSetSourceActor(swigCPtr, View.getCPtr(view));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public View GetSourceView()
        {
            View ret = new View(Interop.RenderTask.RenderTaskGetSourceActor(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetExclusive(bool exclusive)
        {
            Interop.RenderTask.RenderTaskSetExclusive(swigCPtr, exclusive);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsExclusive()
        {
            bool ret = Interop.RenderTask.RenderTaskIsExclusive(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetInputEnabled(bool enabled)
        {
            Interop.RenderTask.RenderTaskSetInputEnabled(swigCPtr, enabled);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool GetInputEnabled()
        {
            bool ret = Interop.RenderTask.RenderTaskGetInputEnabled(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetCamera(Camera camera)
        {
            Interop.RenderTask.RenderTaskSetCameraActor(swigCPtr, Camera.getCPtr(camera));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Camera GetCamera()
        {
            Camera ret = new Camera(Interop.RenderTask.RenderTaskGetCameraActor(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetFrameBuffer(FrameBuffer frameBuffer)
        {
            Interop.RenderTask.RenderTaskSetFrameBuffer(swigCPtr, FrameBuffer.getCPtr(frameBuffer));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public FrameBuffer GetFrameBuffer()
        {
            FrameBuffer ret = new FrameBuffer(Interop.RenderTask.RenderTaskGetFrameBuffer(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetScreenToFrameBufferFunction(SWIGTYPE_p_f_r_Dali__Vector2__bool conversionFunction)
        {
            Interop.RenderTask.RenderTaskSetScreenToFrameBufferFunction(swigCPtr, SWIGTYPE_p_f_r_Dali__Vector2__bool.getCPtr(conversionFunction));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal SWIGTYPE_p_f_r_Dali__Vector2__bool GetScreenToFrameBufferFunction()
        {
            global::System.IntPtr cPtr = Interop.RenderTask.RenderTaskGetScreenToFrameBufferFunction(swigCPtr);
            SWIGTYPE_p_f_r_Dali__Vector2__bool ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_f_r_Dali__Vector2__bool(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetScreenToFrameBufferMappingView(View mappingView)
        {
            Interop.RenderTask.RenderTaskSetScreenToFrameBufferMappingActor(swigCPtr, View.getCPtr(mappingView));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public View GetScreenToFrameBufferMappingView()
        {
            View ret = new View(Interop.RenderTask.RenderTaskGetScreenToFrameBufferMappingActor(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetViewportPosition(Vector2 position)
        {
            Interop.RenderTask.RenderTaskSetViewportPosition(swigCPtr, Vector2.getCPtr(position));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 GetCurrentViewportPosition()
        {
            Vector2 ret = new Vector2(Interop.RenderTask.RenderTaskGetCurrentViewportPosition(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetViewportSize(Vector2 size)
        {
            Interop.RenderTask.RenderTaskSetViewportSize(swigCPtr, Vector2.getCPtr(size));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 GetCurrentViewportSize()
        {
            Vector2 ret = new Vector2(Interop.RenderTask.RenderTaskGetCurrentViewportSize(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetViewport(Rectangle viewport)
        {
            Interop.RenderTask.RenderTaskSetViewport(swigCPtr, Rectangle.getCPtr(viewport));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public Rectangle GetViewport()
        {
            Rectangle ret = new Rectangle(Interop.RenderTask.RenderTaskGetViewport(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetClearColor(Vector4 color)
        {
            Interop.RenderTask.RenderTaskSetClearColor(swigCPtr, Vector4.getCPtr(color));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector4 GetClearColor()
        {
            Vector4 ret = new Vector4(Interop.RenderTask.RenderTaskGetClearColor(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetClearEnabled(bool enabled)
        {
            Interop.RenderTask.RenderTaskSetClearEnabled(swigCPtr, enabled);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool GetClearEnabled()
        {
            bool ret = Interop.RenderTask.RenderTaskGetClearEnabled(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetCullMode(bool cullMode)
        {
            Interop.RenderTask.RenderTaskSetCullMode(swigCPtr, cullMode);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool GetCullMode()
        {
            bool ret = Interop.RenderTask.RenderTaskGetCullMode(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetRefreshRate(uint refreshRate)
        {
            Interop.RenderTask.RenderTaskSetRefreshRate(swigCPtr, refreshRate);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint GetRefreshRate()
        {
            uint ret = Interop.RenderTask.RenderTaskGetRefreshRate(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool WorldToViewport(Vector3 position, out float viewportX, out float viewportY)
        {
            bool ret = Interop.RenderTask.RenderTaskWorldToViewport(swigCPtr, Vector3.getCPtr(position), out viewportX, out viewportY);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ViewportToLocal(View view, float viewportX, float viewportY, out float localX, out float localY)
        {
            bool ret = Interop.RenderTask.RenderTaskViewportToLocal(swigCPtr, View.getCPtr(view), viewportX, viewportY, out localX, out localY);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal RenderTaskSignal FinishedSignal()
        {
            RenderTaskSignal ret = new RenderTaskSignal(Interop.RenderTask.RenderTaskFinishedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <since_tizen> 3 </since_tizen>
        public enum RefreshRate
        {
            REFRESH_ONCE = 0,
            REFRESH_ALWAYS = 1
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 ViewportPosition
        {
            get
            {
                Vector2 temp = new Vector2(0.0f, 0.0f);
                GetProperty(RenderTask.Property.ViewportPosition).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(RenderTask.Property.ViewportPosition, new Tizen.NUI.PropertyValue(value));
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 ViewportSize
        {
            get
            {
                Vector2 temp = new Vector2(0.0f, 0.0f);
                GetProperty(RenderTask.Property.ViewportSize).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(RenderTask.Property.ViewportSize, new Tizen.NUI.PropertyValue(value));
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector4 ClearColor
        {
            get
            {
                Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
                GetProperty(RenderTask.Property.ClearColor).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(RenderTask.Property.ClearColor, new Tizen.NUI.PropertyValue(value));
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool RequiresSync
        {
            get
            {
                bool temp = false;
                GetProperty(RenderTask.Property.RequiresSync).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(RenderTask.Property.RequiresSync, new Tizen.NUI.PropertyValue(value));
            }
        }
    }
}
