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
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    internal class RenderTask : Animatable
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal RenderTask(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.RenderTask.RenderTask_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(RenderTask obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.

            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;
                    Interop.RenderTask.delete_RenderTask(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }


        public static RenderTask GetRenderTaskFromPtr(global::System.IntPtr cPtr)
        {
            RenderTask ret = new RenderTask(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal class Property
        {
            internal static readonly int VIEWPORT_POSITION = Interop.RenderTask.RenderTask_Property_VIEWPORT_POSITION_get();
            internal static readonly int VIEWPORT_SIZE = Interop.RenderTask.RenderTask_Property_VIEWPORT_SIZE_get();
            internal static readonly int CLEAR_COLOR = Interop.RenderTask.RenderTask_Property_CLEAR_COLOR_get();
            internal static readonly int REQUIRES_SYNC = Interop.RenderTask.RenderTask_Property_REQUIRES_SYNC_get();
        }

        internal static SWIGTYPE_p_f_r_Dali__Vector2__bool DEFAULT_SCREEN_TO_FRAMEBUFFER_FUNCTION
        {
            get
            {
                global::System.IntPtr cPtr = Interop.RenderTask.RenderTask_DEFAULT_SCREEN_TO_FRAMEBUFFER_FUNCTION_get();
                SWIGTYPE_p_f_r_Dali__Vector2__bool ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_f_r_Dali__Vector2__bool(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        internal static SWIGTYPE_p_f_r_Dali__Vector2__bool FULLSCREEN_FRAMEBUFFER_FUNCTION
        {
            get
            {
                global::System.IntPtr cPtr = Interop.RenderTask.RenderTask_FULLSCREEN_FRAMEBUFFER_FUNCTION_get();
                SWIGTYPE_p_f_r_Dali__Vector2__bool ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_f_r_Dali__Vector2__bool(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static bool DEFAULT_EXCLUSIVE
        {
            get
            {
                bool ret = Interop.RenderTask.RenderTask_DEFAULT_EXCLUSIVE_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static bool DEFAULT_INPUT_ENABLED
        {
            get
            {
                bool ret = Interop.RenderTask.RenderTask_DEFAULT_INPUT_ENABLED_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Vector4 DEFAULT_CLEAR_COLOR
        {
            get
            {
                global::System.IntPtr cPtr = Interop.RenderTask.RenderTask_DEFAULT_CLEAR_COLOR_get();
                Vector4 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector4(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static bool DEFAULT_CLEAR_ENABLED
        {
            get
            {
                bool ret = Interop.RenderTask.RenderTask_DEFAULT_CLEAR_ENABLED_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static bool DEFAULT_CULL_MODE
        {
            get
            {
                bool ret = Interop.RenderTask.RenderTask_DEFAULT_CULL_MODE_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static uint DEFAULT_REFRESH_RATE
        {
            get
            {
                uint ret = Interop.RenderTask.RenderTask_DEFAULT_REFRESH_RATE_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public RenderTask() : this(Interop.RenderTask.new_RenderTask__SWIG_0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public static RenderTask DownCast(BaseHandle handle)
        {
            RenderTask ret =  Registry.GetManagedBaseHandleFromNativePtr(handle) as RenderTask;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public RenderTask(RenderTask handle) : this(Interop.RenderTask.new_RenderTask__SWIG_1(RenderTask.getCPtr(handle)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public RenderTask Assign(RenderTask rhs)
        {
            RenderTask ret = new RenderTask(Interop.RenderTask.RenderTask_Assign(swigCPtr, RenderTask.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetSourceView(View view)
        {
            Interop.RenderTask.RenderTask_SetSourceActor(swigCPtr, View.getCPtr(view));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public View GetSourceView()
        {
            View ret = new View(Interop.RenderTask.RenderTask_GetSourceActor(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetExclusive(bool exclusive)
        {
            Interop.RenderTask.RenderTask_SetExclusive(swigCPtr, exclusive);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public bool IsExclusive()
        {
            bool ret = Interop.RenderTask.RenderTask_IsExclusive(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetInputEnabled(bool enabled)
        {
            Interop.RenderTask.RenderTask_SetInputEnabled(swigCPtr, enabled);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public bool GetInputEnabled()
        {
            bool ret = Interop.RenderTask.RenderTask_GetInputEnabled(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetCamera(Camera camera)
        {
            Interop.RenderTask.RenderTask_SetCameraActor(swigCPtr, Camera.getCPtr(camera));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Camera GetCamera()
        {
            Camera ret = new Camera(Interop.RenderTask.RenderTask_GetCameraActor(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetTargetFrameBuffer(FrameBufferImage frameBuffer)
        {
            Interop.RenderTask.RenderTask_SetTargetFrameBuffer(swigCPtr, FrameBufferImage.getCPtr(frameBuffer));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public FrameBufferImage GetTargetFrameBuffer()
        {
            FrameBufferImage ret = new FrameBufferImage(Interop.RenderTask.RenderTask_GetTargetFrameBuffer(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetFrameBuffer(FrameBuffer frameBuffer)
        {
            Interop.RenderTask.RenderTask_SetFrameBuffer(swigCPtr, FrameBuffer.getCPtr(frameBuffer));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public FrameBuffer GetFrameBuffer()
        {
            FrameBuffer ret = new FrameBuffer(Interop.RenderTask.RenderTask_GetFrameBuffer(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetScreenToFrameBufferFunction(SWIGTYPE_p_f_r_Dali__Vector2__bool conversionFunction)
        {
            Interop.RenderTask.RenderTask_SetScreenToFrameBufferFunction(swigCPtr, SWIGTYPE_p_f_r_Dali__Vector2__bool.getCPtr(conversionFunction));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal SWIGTYPE_p_f_r_Dali__Vector2__bool GetScreenToFrameBufferFunction()
        {
            global::System.IntPtr cPtr = Interop.RenderTask.RenderTask_GetScreenToFrameBufferFunction(swigCPtr);
            SWIGTYPE_p_f_r_Dali__Vector2__bool ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_f_r_Dali__Vector2__bool(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetScreenToFrameBufferMappingView(View mappingView)
        {
            Interop.RenderTask.RenderTask_SetScreenToFrameBufferMappingActor(swigCPtr, View.getCPtr(mappingView));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public View GetScreenToFrameBufferMappingView()
        {
            View ret = new View(Interop.RenderTask.RenderTask_GetScreenToFrameBufferMappingActor(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetViewportPosition(Vector2 position)
        {
            Interop.RenderTask.RenderTask_SetViewportPosition(swigCPtr, Vector2.getCPtr(position));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Vector2 GetCurrentViewportPosition()
        {
            Vector2 ret = new Vector2(Interop.RenderTask.RenderTask_GetCurrentViewportPosition(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetViewportSize(Vector2 size)
        {
            Interop.RenderTask.RenderTask_SetViewportSize(swigCPtr, Vector2.getCPtr(size));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Vector2 GetCurrentViewportSize()
        {
            Vector2 ret = new Vector2(Interop.RenderTask.RenderTask_GetCurrentViewportSize(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetViewport(Rectangle viewport)
        {
            Interop.RenderTask.RenderTask_SetViewport(swigCPtr, Rectangle.getCPtr(viewport));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Rectangle GetViewport()
        {
            Rectangle ret = new Rectangle(Interop.RenderTask.RenderTask_GetViewport(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetClearColor(Vector4 color)
        {
            Interop.RenderTask.RenderTask_SetClearColor(swigCPtr, Vector4.getCPtr(color));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Vector4 GetClearColor()
        {
            Vector4 ret = new Vector4(Interop.RenderTask.RenderTask_GetClearColor(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetClearEnabled(bool enabled)
        {
            Interop.RenderTask.RenderTask_SetClearEnabled(swigCPtr, enabled);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public bool GetClearEnabled()
        {
            bool ret = Interop.RenderTask.RenderTask_GetClearEnabled(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetCullMode(bool cullMode)
        {
            Interop.RenderTask.RenderTask_SetCullMode(swigCPtr, cullMode);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public bool GetCullMode()
        {
            bool ret = Interop.RenderTask.RenderTask_GetCullMode(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetRefreshRate(uint refreshRate)
        {
            Interop.RenderTask.RenderTask_SetRefreshRate(swigCPtr, refreshRate);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public uint GetRefreshRate()
        {
            uint ret = Interop.RenderTask.RenderTask_GetRefreshRate(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public bool WorldToViewport(Vector3 position, out float viewportX, out float viewportY)
        {
            bool ret = Interop.RenderTask.RenderTask_WorldToViewport(swigCPtr, Vector3.getCPtr(position), out viewportX, out viewportY);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public bool ViewportToLocal(View view, float viewportX, float viewportY, out float localX, out float localY)
        {
            bool ret = Interop.RenderTask.RenderTask_ViewportToLocal(swigCPtr, View.getCPtr(view), viewportX, viewportY, out localX, out localY);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal RenderTaskSignal FinishedSignal()
        {
            RenderTaskSignal ret = new RenderTaskSignal(Interop.RenderTask.RenderTask_FinishedSignal(swigCPtr), false);
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
                GetProperty(RenderTask.Property.VIEWPORT_POSITION).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(RenderTask.Property.VIEWPORT_POSITION, new Tizen.NUI.PropertyValue(value));
            }
        }
        public Vector2 ViewportSize
        {
            get
            {
                Vector2 temp = new Vector2(0.0f, 0.0f);
                GetProperty(RenderTask.Property.VIEWPORT_SIZE).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(RenderTask.Property.VIEWPORT_SIZE, new Tizen.NUI.PropertyValue(value));
            }
        }
        public Vector4 ClearColor
        {
            get
            {
                Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
                GetProperty(RenderTask.Property.CLEAR_COLOR).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(RenderTask.Property.CLEAR_COLOR, new Tizen.NUI.PropertyValue(value));
            }
        }
        public bool RequiresSync
        {
            get
            {
                bool temp = false;
                GetProperty(RenderTask.Property.REQUIRES_SYNC).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(RenderTask.Property.REQUIRES_SYNC, new Tizen.NUI.PropertyValue(value));
            }
        }
    }
}
