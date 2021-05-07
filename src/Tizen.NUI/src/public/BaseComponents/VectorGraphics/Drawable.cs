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

namespace Tizen.NUI.BaseComponents.VectorGraphics
{
    /// <summary>
    /// Drawable is a object class for drawing a vector primitive.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public class Drawable : BaseHandle
    {
        /// <summary>
        /// Creates an initialized drawable.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private Drawable() { }

        internal Drawable(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// The transparency level [0 ~ 1.0], 0 means totally transparent, while 1 means opaque.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public float Opacity
        {
            get
            {
                return Interop.Drawable.GetOpacity(BaseHandle.getCPtr(this));
            }
            set
            {
                Interop.Drawable.SetOpacity(BaseHandle.getCPtr(this), value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// Set the angle of rotation transformation.
        /// </summary>
        /// <param name="degree">The degree value of angle.</param>
        /// <returns>True when it's successful. False otherwise.</returns>
        /// <since_tizen> 9 </since_tizen>
        public bool Rotate(float degree)
        {
            bool ret = Interop.Drawable.Rotate(BaseHandle.getCPtr(this), degree);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Set the scale value of scale transformation.
        /// </summary>
        /// <param name="factor">The scale factor value.</param>
        /// <returns>True when it's successful. False otherwise.</returns>
        /// <since_tizen> 9 </since_tizen>
        public bool Scale(float factor)
        {
            bool ret = Interop.Drawable.Scale(BaseHandle.getCPtr(this), factor);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Set the matrix value for affine transform.
        /// </summary>
        /// <param name="matrix">The float type array of 3x3 matrix.</param>
        /// <returns>True when it's successful. False otherwise.</returns>
        /// <exception cref="ArgumentNullException"> Thrown when matrix is null. </exception>
        /// <exception cref="ArgumentException"> Thrown when matrix array length is not 9. </exception>
        /// <since_tizen> 9 </since_tizen>
        public bool Transform(float[] matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }
            if (matrix.Length != 9)
            {
                throw new ArgumentException("matrix array length is not 9.", nameof(matrix));
            }
            bool ret = Interop.Drawable.Transform(BaseHandle.getCPtr(this), matrix);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Set the x, y movement value of translate transformation.
        /// </summary>
        /// <param name="x">The x-axis movement value.</param>
        /// <param name="y">The y-axis movement value.</param>
        /// <returns>True when it's successful. False otherwise.</returns>
        /// <since_tizen> 9 </since_tizen>
        public bool Translate(float x, float y)
        {
            bool ret = Interop.Drawable.Translate(BaseHandle.getCPtr(this), x, y);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
    }
}
