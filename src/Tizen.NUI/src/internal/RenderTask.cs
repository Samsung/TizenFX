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

        internal RenderTask(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.RenderTask.Upcast(cPtr), cMemoryOwn)
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


        public static RenderTask GetRenderTaskFromPtr(global::System.IntPtr cPtr)
        {
            RenderTask ret = new RenderTask(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal class Property
        {
            internal static readonly int ViewportPosition = Interop.RenderTask.ViewportPositionGet();
            internal static readonly int ViewportSize = Interop.RenderTask.ViewportSizeGet();
            internal static readonly int ClearColor = Interop.RenderTask.ClearColorGet();
            internal static readonly int RequiresSync = Interop.RenderTask.RequiresSyncGet();
        }

        internal static SWIGTYPE_p_f_r_Dali__Vector2__bool DEFAULT_SCREEN_TO_FRAMEBUFFER_FUNCTION
        {
            get
            {
                global::System.IntPtr cPtr = Interop.RenderTask.DefaultScreenToFramebufferFunctionGet();
                SWIGTYPE_p_f_r_Dali__Vector2__bool ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_f_r_Dali__Vector2__bool(cPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        internal static SWIGTYPE_p_f_r_Dali__Vector2__bool FULLSCREEN_FRAMEBUFFER_FUNCTION
        {
            get
            {
                global::System.IntPtr cPtr = Interop.RenderTask.FullscreenFramebufferFunctionGet();
                SWIGTYPE_p_f_r_Dali__Vector2__bool ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_f_r_Dali__Vector2__bool(cPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static bool DEFAULT_EXCLUSIVE
        {
            get
            {
                bool ret = Interop.RenderTask.DefaultExclusiveGet();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static bool DEFAULT_INPUT_ENABLED
        {
            get
            {
                bool ret = Interop.RenderTask.DefaultInputEnabledGet();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Vector4 DEFAULT_CLEAR_COLOR
        {
            get
            {
                global::System.IntPtr cPtr = Interop.RenderTask.DefaultClearColorGet();
                Vector4 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector4(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static bool DEFAULT_CLEAR_ENABLED
        {
            get
            {
                bool ret = Interop.RenderTask.DefaultClearEnabledGet();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static bool DEFAULT_CULL_MODE
        {
            get
            {
                bool ret = Interop.RenderTask.DefaultCullModeGet();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static uint DEFAULT_REFRESH_RATE
        {
            get
            {
                uint ret = Interop.RenderTask.DefaultRefreshRateGet();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public RenderTask() : this(Interop.RenderTask.NewRenderTask(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

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

        public RenderTask(RenderTask handle) : this(Interop.RenderTask.NewRenderTask(RenderTask.getCPtr(handle)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public RenderTask Assign(RenderTask rhs)
        {
            RenderTask ret = new RenderTask(Interop.RenderTask.Assign(swigCPtr, RenderTask.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetSourceView(View view)
        {
            Interop.RenderTask.SetSourceActor(swigCPtr, View.getCPtr(view));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public View GetSourceView()
        {
            View ret = new View(Interop.RenderTask.GetSourceActor(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetExclusive(bool exclusive)
        {
            Interop.RenderTask.SetExclusive(swigCPtr, exclusive);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public bool IsExclusive()
        {
            bool ret = Interop.RenderTask.IsExclusive(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetInputEnabled(bool enabled)
        {
            Interop.RenderTask.SetInputEnabled(swigCPtr, enabled);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public bool GetInputEnabled()
        {
            bool ret = Interop.RenderTask.GetInputEnabled(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetCamera(Camera camera)
        {
            Interop.RenderTask.SetCameraActor(swigCPtr, Camera.getCPtr(camera));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Camera GetCamera()
        {
            Camera ret = new Camera(Interop.RenderTask.GetCameraActor(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetFrameBuffer(FrameBuffer frameBuffer)
        {
            Interop.RenderTask.SetFrameBuffer(swigCPtr, FrameBuffer.getCPtr(frameBuffer));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public FrameBuffer GetFrameBuffer()
        {
            FrameBuffer ret = new FrameBuffer(Interop.RenderTask.GetFrameBuffer(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetScreenToFrameBufferFunction(SWIGTYPE_p_f_r_Dali__Vector2__bool conversionFunction)
        {
            Interop.RenderTask.SetScreenToFrameBufferFunction(swigCPtr, SWIGTYPE_p_f_r_Dali__Vector2__bool.getCPtr(conversionFunction));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal SWIGTYPE_p_f_r_Dali__Vector2__bool GetScreenToFrameBufferFunction()
        {
            global::System.IntPtr cPtr = Interop.RenderTask.GetScreenToFrameBufferFunction(swigCPtr);
            SWIGTYPE_p_f_r_Dali__Vector2__bool ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_f_r_Dali__Vector2__bool(cPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetScreenToFrameBufferMappingView(View mappingView)
        {
            Interop.RenderTask.SetScreenToFrameBufferMappingActor(swigCPtr, View.getCPtr(mappingView));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public View GetScreenToFrameBufferMappingView()
        {
            View ret = new View(Interop.RenderTask.GetScreenToFrameBufferMappingActor(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetViewportPosition(Vector2 position)
        {
            Interop.RenderTask.SetViewportPosition(swigCPtr, Vector2.getCPtr(position));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Vector2 GetCurrentViewportPosition()
        {
            Vector2 ret = new Vector2(Interop.RenderTask.GetCurrentViewportPosition(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetViewportSize(Vector2 size)
        {
            Interop.RenderTask.SetViewportSize(swigCPtr, Vector2.getCPtr(size));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Vector2 GetCurrentViewportSize()
        {
            Vector2 ret = new Vector2(Interop.RenderTask.GetCurrentViewportSize(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetViewport(Rectangle viewport)
        {
            Interop.RenderTask.SetViewport(swigCPtr, Rectangle.getCPtr(viewport));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Rectangle GetViewport()
        {
            Rectangle ret = new Rectangle(Interop.RenderTask.GetViewport(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetClearColor(Vector4 color)
        {
            Interop.RenderTask.SetClearColor(swigCPtr, Vector4.getCPtr(color));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Vector4 GetClearColor()
        {
            Vector4 ret = new Vector4(Interop.RenderTask.GetClearColor(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetClearEnabled(bool enabled)
        {
            Interop.RenderTask.SetClearEnabled(swigCPtr, enabled);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public bool GetClearEnabled()
        {
            bool ret = Interop.RenderTask.GetClearEnabled(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetCullMode(bool cullMode)
        {
            Interop.RenderTask.SetCullMode(swigCPtr, cullMode);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public bool GetCullMode()
        {
            bool ret = Interop.RenderTask.GetCullMode(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetRefreshRate(uint refreshRate)
        {
            Interop.RenderTask.SetRefreshRate(swigCPtr, refreshRate);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public uint GetRefreshRate()
        {
            uint ret = Interop.RenderTask.GetRefreshRate(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public bool WorldToViewport(Vector3 position, out float viewportX, out float viewportY)
        {
            bool ret = Interop.RenderTask.WorldToViewport(swigCPtr, Vector3.getCPtr(position), out viewportX, out viewportY);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public bool ViewportToLocal(View view, float viewportX, float viewportY, out float localX, out float localY)
        {
            bool ret = Interop.RenderTask.ViewportToLocal(swigCPtr, View.getCPtr(view), viewportX, viewportY, out localX, out localY);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal RenderTaskSignal FinishedSignal()
        {
            RenderTaskSignal ret = new RenderTaskSignal(Interop.RenderTask.FinishedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <since_tizen> 3 </since_tizen>
        public enum RefreshRate
        {
            REFRESH_ONCE = 0,
            REFRESH_ALWAYS = 1
        }

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
