/*
 * Copyright (c) 2023 Samsung Electronics Co., Ltd.
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
using System.ComponentModel;
using Tizen.NUI.Binding;

namespace Tizen.NUI
{
    /// <summary>
    /// This class represents the default window data for an Application object.
    /// It contains information about the default window.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class WindowData : Disposable
    {
        private IBorderInterface borderInterface = null;

        public WindowData() : this(Interop.WindowData.New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal WindowData(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// Gets or sets the position and size of the default window.
        /// The default size of the position and size is X=0, Y=0, WIDTH=0, HEIGHT=0.
        /// </summary>
        /// <value>The position and size of the default window.</value>
        public Rectangle PositionSize
        {
            set
            {
                Interop.WindowData.SetPositionSize(SwigCPtr, Rectangle.getCPtr(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                Rectangle ret = Rectangle.GetRectangleFromPtr(Interop.WindowData.GetPositionSize(SwigCPtr));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// Gets or sets the mode of the default window.
        /// The default mode is WindowMode.Transparent.
        /// </summary>
        /// <value>The mode of the default window.</value>
        public NUIApplication.WindowMode WindowMode
        {
            set
            {
                Interop.WindowData.SetTransparency(SwigCPtr, NUIApplication.WindowMode.Transparent == value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                bool transparent = Interop.WindowData.GetTransparency(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return transparent ? NUIApplication.WindowMode.Transparent : NUIApplication.WindowMode.Opaque;
            }
        }

        /// <summary>
        /// Gets or sets the type of the default window.
        /// The default type is WindowType.Normal.
        /// </summary>
        /// <value>The type of the default window.</value>
        public WindowType WindowType
        {
            set
            {
                Interop.WindowData.SetWindowType(SwigCPtr, (int)value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                WindowType ret = (WindowType)Interop.WindowData.GetWindowType(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// Gets or sets the border interface of the default window.
        /// The default value is null.
        /// </summary>
        /// <value>The border interface of the default window.</value>
        public IBorderInterface BorderInterface
        {
            set
            {
                borderInterface = value;
            }
            get
            {
                return borderInterface;
            }
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.WindowData.DeleteWindowData(swigCPtr);
        }
    }
}