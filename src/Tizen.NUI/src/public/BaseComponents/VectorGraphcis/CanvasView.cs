/*
* Copyright(c) 2019 Samsung Electronics Co., Ltd.
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


namespace Tizen.NUI.BaseComponents
{
    namespace VectorGraphics
    {
        /// <summary>
        /// CanvasView is a class for displaying vector primitives.<br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class CanvasView : View
        {
            
            static CanvasView() { }

            /// <summary>
            /// Creates an initialized CanvasView.
            /// </summary>
            /// <param name="viewBox">The size of viewbox.</param>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public CanvasView(Size2D viewBox) : this(Interop.CanvasView.New(Uint16Pair.getCPtr( new Uint16Pair((uint)viewBox.Width, (uint)viewBox.Height))), true)
            {
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }

            internal CanvasView(global::System.IntPtr cPtr, bool shown = true) : base(cPtr, shown)
            {
                if (!shown)
                {
                    SetVisible(false);
                }
            }

            /// <summary>
            /// Downcasts a handle to CanvasView handle.
            /// </summary>
            /// <exception cref="ArgumentNullException"> Thrown when handle is null. </exception>
            /// Please do not use! this will be deprecated!
            /// Instead please use as keyword.
            [Obsolete("Please do not use! This will be deprecated! Please use as keyword instead! " +
            "Like: " +
            "BaseHandle handle = new CanvasView(viewBox); " +
            "CanvasView canvasView = handle as CanvasView")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static CanvasView DownCast(BaseHandle handle)
            {
                if (null == handle)
                {
                    throw new ArgumentNullException(nameof(handle));
                }
                CanvasView ret = Registry.GetManagedBaseHandleFromNativePtr(handle) as CanvasView;
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }

            /// This will not be public opened.
            [EditorBrowsable(EditorBrowsableState.Never)]
            protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
            {
                Interop.CanvasView.DeleteCanvasView(swigCPtr);
            }

            /// <summary>
            /// you can override it to clean-up your own resources.
            /// </summary>
            /// <param name="type">DisposeTypes</param>
            [EditorBrowsable(EditorBrowsableState.Never)]
            protected override void Dispose(DisposeTypes type)
            {
                if (disposed)
                {
                    return;
                }

                base.Dispose(type);
            }

            /// <summary>
            /// Add paint object to the CanvasView.
            /// This method is similar to registration. The added shape is drawn on the inner canvas.
            /// </summary>
            /// <param name="paint">Paint object</param>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void AddPaint(Paint paint)
            {   
                Interop.CanvasView.AddPaint(View.getCPtr(this), BaseHandle.getCPtr(paint));
            }

        }
    }
}
