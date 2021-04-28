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
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Tizen.NUI.BaseComponents.VectorGraphics
{
    /// <summary>
    /// CanvasView is a class for displaying vector primitives.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public class CanvasView : View
    {
        static CanvasView() { }

        /// <summary>
        /// Creates an initialized CanvasView.
        /// </summary>
        /// <param name="viewBox">The size of viewbox.</param>
        /// <exception cref="ArgumentNullException"> Thrown when viewBox is null. </exception>
        /// <since_tizen> 9 </since_tizen>
        [SuppressMessage("Microsoft.Design", "CA2000: Dispose objects before losing scope", Justification = "It does not have dispose ownership.")]
        public CanvasView(Size2D viewBox) : this(viewBox == null ? throw new ArgumentNullException(nameof(viewBox)) : Interop.CanvasView.New(Uint16Pair.getCPtr(new Uint16Pair((uint)viewBox.Width, (uint)viewBox.Height))), true)
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
        /// You can override it to clean-up your own resources.
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

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.CanvasView.DeleteCanvasView(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Add drawable object to the CanvasView.
        /// This method is similar to registration. The added shape is drawn on the inner canvas.
        /// </summary>
        /// <param name="drawable">Drawable object</param>
        /// <since_tizen> 9 </since_tizen>
        public void AddDrawable(Drawable drawable)
        {
            Interop.CanvasView.AddDrawable(View.getCPtr(this), BaseHandle.getCPtr(drawable));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
    }
}
