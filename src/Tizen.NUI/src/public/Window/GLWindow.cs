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

extern alias TizenSystemInformation;

using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Tizen.NUI
{
    /// <summary>
    /// The GLWindow class is to draw with native GLES.<br />
    /// This class is the special window. It is for native GLES application.<br />
    /// So, some special functions and type are supported.<br />
    /// In addition, basic window's functions are supported, too.<br />
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class GLWindow : BaseHandle
    {
        internal GLWindow(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {

        }

        /// <summary>
        /// Creates an initialized handle to a new GLWindow.<br />
        /// This creates an GLWindow with default options.!--<br />
        /// </summary>
        /// <returns>A new GLWindow.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public GLWindow() : this(Interop.GLWindow.GlWindowNew(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Creates an initialized handle to a new GLWindow.<br />
        /// This API can create GLWindow with specific option.<br />
        /// </summary>
        /// <param name="name">The name for GL window. </param>
        /// <param name="windowPosition">The position and size of the Window.</param>
        /// <param name="isTranslucent">Whether Window is translucent.</param>
        /// <returns>A new Window.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public GLWindow(string name, Rectangle windowPosition = null, bool isTranslucent = false) : this(Interop.GLWindow.GlWindowNew(Rectangle.getCPtr(windowPosition), name, "", isTranslucent), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Enumeration for orientation of the window is the way in which a rectangular page is oriented for normal viewing.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum GLWindowOrientation
        {
            /// <summary>
            /// Portrait orientation. The height of the display area is greater than the width.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Portrait = 0,

            /// <summary>
            /// Landscape orientation. A wide view area is needed.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Landscape = 90,

            /// <summary>
            /// Portrait inverse orientation.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            PortraitInverse = 180,

            /// <summary>
            /// Landscape inverse orientation.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            LandscapeInverse = 270,

            /// <summary>
            /// No orientation. It is for the preferred orientation
            /// Especially, NoOrientationPreference only has the effect for the preferred orientation.
            /// It is used to unset the preferred orientation with SetPreferredOrientation.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            NoOrientationPreference = -1
        }

        /// <summary>
        /// Gets or sets a size of the window.
        /// </summary>
        /// <exception cref="ArgumentNullException"> Thrown when value is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size2D WindowSize
        {
            get
            {
                global::System.IntPtr intPtr = Interop.GLWindow.GlWindowGetPositionSize(SwigCPtr);
                var val = new Rectangle(intPtr, true);
                Size2D ret = new Size2D(val.Width, val.Height);
                val.Dispose();

                return ret;
            }
            set
            {
                if (null == value)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                global::System.IntPtr intPtr = Interop.GLWindow.GlWindowGetPositionSize(SwigCPtr);
                Rectangle val = new Rectangle(intPtr, true);
                Rectangle ret = new Rectangle(val.X, val.Y, value.Width, value.Height);
                val.Dispose();

                Interop.GLWindow.GlWindowSetPositionSize(SwigCPtr, Rectangle.getCPtr(ret));
                ret.Dispose();
            }
        }

        /// <summary>
        /// This Enumeration is used the GLES version for EGL configuration.<br />
        /// If the device can not support GLES version 3.0 over, the version will be chosen with GLES version 2.0<br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum GLESVersion
        {
            /// <summary>
            /// GLES version 2.0
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Version_2_0 = 0,

            /// <summary>
            /// GLES version 3.0
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Version_3_0
        }

        /// <summary>
        /// Sets egl configuration for GLWindow
        /// </summary>
        /// <param name="depth">The flag of depth buffer. If true is set, 24bit depth buffer is enabled.</param>
        /// <param name="stencil">The flag of stencil. it true is set, 8bit stencil buffer is enabled.</param>
        /// <param name="msaa">The bit of msaa.</param>
        /// <param name="version">The GLES version.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetEglConfig(bool depth, bool stencil, int msaa, GLESVersion version)
        {
            Interop.GLWindow.GlWindowSetEglConfig(SwigCPtr, depth, stencil, msaa, (int)version);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Shows the GLWindow if it is hidden.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Show()
        {
            Interop.GLWindow.GlWindowShow(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Hides the GLWindow if it is showing.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Hide()
        {
            Interop.GLWindow.GlWindowHide(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Raises the window to the top of the window stack.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Raise()
        {
            Interop.GLWindow.GlWindowRaise(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Lowers the window to the bottom of the window stack.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Lower()
        {
            Interop.GLWindow.GlWindowLower(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Activates the window to the top of the window stack even it is iconified.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Activate()
        {
            Interop.GLWindow.GlWindowActivate(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets position and size of the window. This API guarantees that
        /// both moving and resizing of window will appear on the screen at once.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Rectangle WindowPositionSize
        {
            get
            {
                global::System.IntPtr intPtr = Interop.GLWindow.GlWindowGetPositionSize(SwigCPtr);
                Rectangle val = new Rectangle(intPtr, true);
                Rectangle ret = new Rectangle(val.X, val.Y, val.Width, val.Height);
                val.Dispose();

                return ret;
            }
            set
            {
                Interop.GLWindow.GlWindowSetPositionSize(SwigCPtr, Rectangle.getCPtr(value));
            }
        }

        /// <summary>
        /// Gets the count of supported auxiliary hints of the GLWindow.
        /// </summary>
        /// <returns>The number of supported auxiliary hints.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint GetSupportedAuxiliaryHintCount()
        {
            uint ret = Interop.GLWindow.GlWindowGetSupportedAuxiliaryHintCount(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets the supported auxiliary hint string of the GLWindow.
        /// </summary>
        /// <param name="index">The index of the supported auxiliary hint lists.</param>
        /// <returns>The auxiliary hint string of the index.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string GetSupportedAuxiliaryHint(uint index)
        {
            string ret = Interop.GLWindow.GlWindowGetSupportedAuxiliaryHint(SwigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Creates an auxiliary hint of the GLWindow.
        /// </summary>
        /// <param name="hint">The auxiliary hint string.</param>
        /// <param name="value">The value string.</param>
        /// <returns>The ID of created auxiliary hint, or 0 on failure.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint AddAuxiliaryHint(string hint, string value)
        {
            uint ret = Interop.GLWindow.GlWindowAddAuxiliaryHint(SwigCPtr, hint, value);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Removes an auxiliary hint of the GLWindow.
        /// </summary>
        /// <param name="id">The ID of the auxiliary hint.</param>
        /// <returns>True if no error occurred, false otherwise.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool RemoveAuxiliaryHint(uint id)
        {
            bool ret = Interop.GLWindow.GlWindowRemoveAuxiliaryHint(SwigCPtr, id);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Changes a value of the auxiliary hint.
        /// </summary>
        /// <param name="id">The auxiliary hint ID.</param>
        /// <param name="value">The value string to be set.</param>
        /// <returns>True if no error occurred, false otherwise.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool SetAuxiliaryHintValue(uint id, string value)
        {
            bool ret = Interop.GLWindow.GlWindowSetAuxiliaryHintValue(SwigCPtr, id, value);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets a value of the auxiliary hint.
        /// </summary>
        /// <param name="id">The auxiliary hint ID.</param>
        /// <returns>The string value of the auxiliary hint ID, or an empty string if none exists.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string GetAuxiliaryHintValue(uint id)
        {
            string ret = Interop.GLWindow.GlWindowGetAuxiliaryHintValue(SwigCPtr, id);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets an ID of the auxiliary hint string.
        /// </summary>
        /// <param name="hint">The auxiliary hint string.</param>
        /// <returns>The ID of auxiliary hint string, or 0 on failure.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint GetAuxiliaryHintId(string hint)
        {
            uint ret = Interop.GLWindow.GlWindowGetAuxiliaryHintId(SwigCPtr, hint);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets a region to accept input events.
        /// </summary>
        /// <param name="inputRegion">The region to accept input events.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetInputRegion(Rectangle inputRegion)
        {
            Interop.GLWindow.GlWindowSetInputRegion(SwigCPtr, Rectangle.getCPtr(inputRegion));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets a transparent window's visual state to opaque. <br />
        /// If a visual state of a transparent window is opaque, <br />
        /// then the window manager could handle it as an opaque window when calculating visibility.
        /// </summary>
        /// <param name="opaque">Whether the window's visual state is opaque.</param>
        /// <remarks>This will have no effect on an opaque window. <br />
        /// It doesn't change transparent window to opaque window but lets the window manager know the visual state of the window.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetOpaqueState(bool opaque)
        {
            Interop.GLWindow.GlWindowSetOpaqueState(SwigCPtr, opaque);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Returns whether a transparent window's visual state is opaque or not.
        /// </summary>
        /// <returns>True if the window's visual state is opaque, false otherwise.</returns>
        /// <remarks> The return value has no meaning on an opaque window. </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsOpaqueState()
        {
            bool ret = Interop.GLWindow.GlWindowIsOpaqueState(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets a preferred orientation.
        /// </summary>
        /// <param name="orientation">The preferred orientation.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetPreferredOrientation(GLWindow.GLWindowOrientation orientation)
        {
            Interop.GLWindow.GlWindowSetPreferredOrientation(SwigCPtr, (int)orientation);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets current orientation of the window.
        /// </summary>
        /// <returns>The current window orientation if previously set, or none.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public GLWindow.GLWindowOrientation GetCurrentOrientation()
        {
            GLWindow.GLWindowOrientation ret = (GLWindow.GLWindowOrientation)Interop.GLWindow.GlWindowGetCurrentOrientation(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets available orientations of the window.
        /// This API is for setting several orientations one time.
        /// </summary>
        /// <param name="orientations">The list of orientations.</param>
        /// <exception cref="ArgumentNullException"> Thrown when orientations is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetAvailableOrientations(List<GLWindow.GLWindowOrientation> orientations)
        {
            if (null == orientations)
            {
                throw new ArgumentNullException(nameof(orientations));
            }

            PropertyArray orientationArray = new PropertyArray();
            for (int i = 0; i < orientations.Count; i++)
            {
                PropertyValue val = new PropertyValue((int)orientations[i]);
                orientationArray.PushBack(val);
                val.Dispose();
            }

            Interop.GLWindow.GlWindowSetAvailableOrientations(SwigCPtr, PropertyArray.getCPtr(orientationArray), orientations.Count);
            orientationArray.Dispose();
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Allows at least one more render, even when paused.
        /// The window should be shown, not minimised.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RenderOnce()
        {
            Interop.GLWindow.GlWindowRenderOnce(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Type of callback to initialize native GL code.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void GLInitializeCallbackType();

        GLInitializeCallbackType GLInitializeCallback;
        HandleRef InitHandleRef;

        /// <summary>
        /// Type of callback to render to frame to use native GL code.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate int GLRenderFrameCallbackType();

        GLRenderFrameCallbackType GLRenderFrameCallback;
        HandleRef RenderHandlerRef;


        /// <summary>
        /// Type of callback to cleanup native GL resource.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void GLTerminateCallbackType();

        GLTerminateCallbackType GLTerminateCallback;
        HandleRef TerminateHandlerRef;

        /// <summary>
        /// Registers a GL callback function for application.
        /// </summary>
        /// <param name="glInit">The callback function for application initialize</param>
        /// <param name="glRenderFrame">The callback function to render to the frame</param>
        /// <param name="glTerminate">The callback function to clean-up application GL resource</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RegisterGlCallback(GLInitializeCallbackType glInit, GLRenderFrameCallbackType glRenderFrame, GLTerminateCallbackType glTerminate)
        {
            GLInitializeCallback = glInit;
            InitHandleRef = new HandleRef(this, Marshal.GetFunctionPointerForDelegate<Delegate>(GLInitializeCallback));

            GLRenderFrameCallback = glRenderFrame;
            RenderHandlerRef = new HandleRef(this, Marshal.GetFunctionPointerForDelegate<Delegate>(GLRenderFrameCallback));

            GLTerminateCallback = glTerminate;
            TerminateHandlerRef = new HandleRef(this, Marshal.GetFunctionPointerForDelegate<Delegate>(GLTerminateCallback));

            Interop.GLWindow.GlWindowRegisterGlCallback(SwigCPtr, InitHandleRef, RenderHandlerRef, TerminateHandlerRef);

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Destroy the window immediately.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Destroy()
        {
            this.Dispose();
        }

        /// <summary>
        /// Dispose for Window
        /// </summary>
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            this.DisconnectNativeSignals();

            base.Dispose(type);
        }

        /// This will not be public opened.
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Window.DeleteWindow(swigCPtr);
        }
    }
}
