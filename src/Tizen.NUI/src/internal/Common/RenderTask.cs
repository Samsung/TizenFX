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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    /// This will be released at Tizen.NET API Level 6, so currently this would be used as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class RenderTask : Animatable
    {
        internal RenderTask(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
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

        protected override void Dispose(DisposeTypes type)
        {
            if (Disposed)
            {
                return;
            }

            foreach (var window in Application.GetWindowList() ?? Enumerable.Empty<Window>())
            {
                window.GetRenderTaskList().RemoveTask(this);
            }

            base.Dispose(type);
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
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        public static bool DEFAULT_INPUT_ENABLED
        {
            get
            {
                bool ret = Interop.RenderTask.DefaultInputEnabledGet();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        public static Vector4 DEFAULT_CLEAR_COLOR
        {
            get
            {
                global::System.IntPtr cPtr = Interop.RenderTask.DefaultClearColorGet();
                Vector4 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector4(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        public static bool DEFAULT_CLEAR_ENABLED
        {
            get
            {
                bool ret = Interop.RenderTask.DefaultClearEnabledGet();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        public static bool DEFAULT_CULL_MODE
        {
            get
            {
                bool ret = Interop.RenderTask.DefaultCullModeGet();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        public static uint DEFAULT_REFRESH_RATE
        {
            get
            {
                uint ret = Interop.RenderTask.DefaultRefreshRateGet();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
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
            RenderTask ret = new RenderTask(Interop.RenderTask.Assign(SwigCPtr, RenderTask.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetSourceView(View view)
        {
            Interop.RenderTask.SetSourceActor(SwigCPtr, View.getCPtr(view));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public View GetSourceView()
        {
            // TODO : Fix me, to avoid memory leak issue.
            View ret = new View(Interop.RenderTask.GetSourceActor(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetExclusive(bool exclusive)
        {
            Interop.RenderTask.SetExclusive(SwigCPtr, exclusive);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public bool IsExclusive()
        {
            bool ret = Interop.RenderTask.IsExclusive(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetInputEnabled(bool enabled)
        {
            Interop.RenderTask.SetInputEnabled(SwigCPtr, enabled);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public bool GetInputEnabled()
        {
            bool ret = Interop.RenderTask.GetInputEnabled(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        [Obsolete("Do not use this. Use Tizen.NUI.Scene3D.Camera instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetCamera(Camera camera)
        {
            Interop.RenderTask.SetCameraActor(SwigCPtr, Camera.getCPtr(camera));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        [Obsolete("Do not use this. Use Tizen.NUI.Scene3D.Camera instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Camera GetCamera()
        {
            Camera ret = new Camera(Interop.RenderTask.GetCameraActor(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetFrameBuffer(FrameBuffer frameBuffer)
        {
            Interop.RenderTask.SetFrameBuffer(SwigCPtr, FrameBuffer.getCPtr(frameBuffer));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public FrameBuffer GetFrameBuffer()
        {
            // TODO : Fix me, to avoid memory leak issue.
            FrameBuffer ret = new FrameBuffer(Interop.RenderTask.GetFrameBuffer(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetScreenToFrameBufferFunction(SWIGTYPE_p_f_r_Dali__Vector2__bool conversionFunction)
        {
            Interop.RenderTask.SetScreenToFrameBufferFunction(SwigCPtr, SWIGTYPE_p_f_r_Dali__Vector2__bool.getCPtr(conversionFunction));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal SWIGTYPE_p_f_r_Dali__Vector2__bool GetScreenToFrameBufferFunction()
        {
            global::System.IntPtr cPtr = Interop.RenderTask.GetScreenToFrameBufferFunction(SwigCPtr);
            SWIGTYPE_p_f_r_Dali__Vector2__bool ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_f_r_Dali__Vector2__bool(cPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetScreenToFrameBufferMappingView(View mappingView)
        {
            Interop.RenderTask.SetScreenToFrameBufferMappingActor(SwigCPtr, View.getCPtr(mappingView));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public View GetScreenToFrameBufferMappingView()
        {
            // TODO : Fix me, to avoid memory leak issue.
            View ret = new View(Interop.RenderTask.GetScreenToFrameBufferMappingActor(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetViewportPosition(Vector2 position)
        {
            Interop.RenderTask.SetViewportPosition(SwigCPtr, Vector2.getCPtr(position));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Vector2 GetCurrentViewportPosition()
        {
            Vector2 ret = new Vector2(Interop.RenderTask.GetCurrentViewportPosition(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetViewportSize(Vector2 size)
        {
            Interop.RenderTask.SetViewportSize(SwigCPtr, Vector2.getCPtr(size));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Vector2 GetCurrentViewportSize()
        {
            Vector2 ret = new Vector2(Interop.RenderTask.GetCurrentViewportSize(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetViewport(Rectangle viewport)
        {
            Interop.RenderTask.SetViewport(SwigCPtr, Rectangle.getCPtr(viewport));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Rectangle GetViewport()
        {
            Rectangle ret = new Rectangle(Interop.RenderTask.GetViewport(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        [Obsolete("This has been deprecated in API9 and will be removed in API11. Use ClearColor property instead.")]
        public void SetClearColor(Vector4 color)
        {
            Interop.RenderTask.SetClearColor(SwigCPtr, Vector4.getCPtr(color));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        [Obsolete("This has been deprecated in API9 and will be removed in API11. Use ClearColor property instead.")]
        public Vector4 GetClearColor()
        {
            Vector4 ret = new Vector4(Interop.RenderTask.GetClearColor(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetClearEnabled(bool enabled)
        {
            Interop.RenderTask.SetClearEnabled(SwigCPtr, enabled);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public bool GetClearEnabled()
        {
            bool ret = Interop.RenderTask.GetClearEnabled(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetCullMode(bool cullMode)
        {
            Interop.RenderTask.SetCullMode(SwigCPtr, cullMode);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public bool GetCullMode()
        {
            bool ret = Interop.RenderTask.GetCullMode(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetRefreshRate(uint refreshRate)
        {
            Interop.RenderTask.SetRefreshRate(SwigCPtr, refreshRate);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public uint GetRefreshRate()
        {
            uint ret = Interop.RenderTask.GetRefreshRate(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void RenderUntil(View view)
        {
            Interop.RenderTask.RenderUntil(SwigCPtr, View.getCPtr(view));
            NDalicPINVOKE.ThrowExceptionIfExists();
        }

        public View GetStopperView()
        {
            // TODO : Fix me, to avoid memory leak issue.
            View ret = new View(Interop.RenderTask.GetStopperView(SwigCPtr), true);
            NDalicPINVOKE.ThrowExceptionIfExists();
            return ret;
        }

        public bool WorldToViewport(Vector3 position, out float viewportX, out float viewportY)
        {
            bool ret = Interop.RenderTask.WorldToViewport(SwigCPtr, Vector3.getCPtr(position), out viewportX, out viewportY);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public bool ViewportToLocal(View view, float viewportX, float viewportY, out float localX, out float localY)
        {
            bool ret = Interop.RenderTask.ViewportToLocal(SwigCPtr, View.getCPtr(view), viewportX, viewportY, out localX, out localY);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal RenderTaskSignal FinishedSignal()
        {
            RenderTaskSignal ret = new RenderTaskSignal(Interop.RenderTask.FinishedSignal(SwigCPtr), false);
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
                Vector2 retVal = new Vector2(0.0f, 0.0f);
                PropertyValue viewportPos = GetProperty(RenderTask.Property.ViewportPosition);
                viewportPos?.Get(retVal);
                viewportPos?.Dispose();
                return retVal;
            }
            set
            {
                PropertyValue setVal = new Tizen.NUI.PropertyValue(value);
                SetProperty(RenderTask.Property.ViewportPosition, setVal);
                setVal?.Dispose();
            }
        }
        public Vector2 ViewportSize
        {
            get
            {
                Vector2 retVal = new Vector2(0.0f, 0.0f);
                PropertyValue viewportSize = GetProperty(RenderTask.Property.ViewportSize);
                viewportSize?.Get(retVal);
                viewportSize?.Dispose();
                return retVal;
            }
            set
            {
                PropertyValue setVal = new Tizen.NUI.PropertyValue(value);
                SetProperty(RenderTask.Property.ViewportSize, setVal);
                setVal?.Dispose();
            }
        }
        public Vector4 ClearColor
        {
            get
            {
                Vector4 retVal = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
                PropertyValue clearColor = GetProperty(RenderTask.Property.ClearColor);
                clearColor?.Get(retVal);
                clearColor?.Dispose();
                return retVal;
            }
            set
            {
                PropertyValue setVal = new Tizen.NUI.PropertyValue(value);
                SetProperty(RenderTask.Property.ClearColor, setVal);
                setVal?.Dispose();
            }
        }
        public bool RequiresSync
        {
            get
            {
                bool retVal = false;
                PropertyValue reqSync = GetProperty(RenderTask.Property.RequiresSync);
                reqSync?.Get(out retVal);
                reqSync?.Dispose();
                return retVal;
            }
            set
            {
                PropertyValue setVal = new Tizen.NUI.PropertyValue(value);
                SetProperty(RenderTask.Property.RequiresSync, setVal);
                setVal?.Dispose();
            }
        }

        /// <summary>
        /// Sets / gets the tag of render pass. It will be used when we want to change render pass without change shader.
        /// Default is 0.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint RenderPassTag
        {
            get
            {
                uint ret = Interop.RenderTask.GetRenderPassTag(SwigCPtr);
                NDalicPINVOKE.ThrowExceptionIfExists();
                return ret;
            }
            set
            {
                Interop.RenderTask.SetRenderPassTag(SwigCPtr, value);
                NDalicPINVOKE.ThrowExceptionIfExists();
            }
        }

        /// <summary>
        /// Sets / gets the rendering order of render task.
        /// </summary>
        /// <remarks>
        /// In the DALi, offscreen renderTasks are rendered earlier than onscreen renderTask.
        ///  * In each category of OffScreen RenderTask and OnScreen RenderTask,
        ///  * a RenderTask with a smaller orderIndex is rendered first.
        ///  * The RenderTasks in RenderTaskList is always sorted as acending order of the OrderIndex.
        ///  * The OrderIndex value is needed to be set between [-1000, 1000].
        ///  * Default orderIndex is 0.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int OrderIndex
        {
            get
            {
                int ret = Interop.RenderTask.GetOrderIndex(SwigCPtr);
                NDalicPINVOKE.ThrowExceptionIfExists();
                return ret;
            }
            set
            {
                Interop.RenderTask.SetOrderIndex(SwigCPtr, value);
                NDalicPINVOKE.ThrowExceptionIfExists();
            }
        }

        /// <summary>
        /// Gets the render task's ID. 0 if render task is invalid.
        /// Read-only
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint ID
        {
            get
            {
                uint ret = 0u;

                if(!Disposed && !IsDisposeQueued)
                {
                    ret = Interop.RenderTask.GetRenderTaskId(SwigCPtr);
                }

                NDalicPINVOKE.ThrowExceptionIfExists();
                return ret;
            }
        }
    }
}
