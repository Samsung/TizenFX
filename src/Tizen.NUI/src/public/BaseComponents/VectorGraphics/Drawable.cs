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
        /// Enumeration indicating the type used in the masking of two objects - the mask drawable and the own drawable.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum MaskType
        {
            /// <summary>
            /// The pixels of the own drawable and the mask drawable are alpha blended. As a result, only the part of the own drawable, which intersects with the mask drawable is visible.
            /// </summary>
            Alpha = 0,
            /// <summary>
            /// The pixels of the own drawable and the complement to the mask drawable's pixels are alpha blended. As a result, only the part of the own which is not covered by the mask is visible.
            /// </summary>
            AlphaInverse
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
        /// The bounding box of the drawable object to which no transformation has been applied.
        /// </summary>
        /// <remarks>
        /// The bounding box doesn't indicate the rendering region in the result but primitive region of the object.
        /// </remarks>
        /// <remarks>
        /// The float type Rectangle class is not ready yet.
        /// Therefore, it transmits data in Vector4 class.
        /// This type should later be changed to the appropriate data type.
        /// </remarks>
        /// <code>
        ///  Shape shape = new Shape()
        ///  {      
        ///      FillColor = new Color(1.0f, 0.0f, 0.0f, 1.0f)
        ///  };
        ///  shape.AddRect(0.0f, 0.0f, 100.0f, 100.0f, 0.0f, 0.0f);
        ///  float boundingBoxX = shape.BoundingBox[0];      // boundingBoxX will be 0.
        ///  float boundingBoxY = shape.BoundingBox[1];      // boundingBoxY will be 0.
        ///  float boundingBoxWidth = shape.BoundingBox[2];  // boundingBoxWidth will be 100.
        ///  float boundingBoxHeight = shape.BoundingBox[3]; // boundingBoxHeight will be 100.
        /// </code>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector4 BoundingBox
        {
            get
            {
                global::System.IntPtr cPtr = Interop.Drawable.GetBoundingBox(BaseHandle.getCPtr(this));
                return Vector4.GetVector4FromPtr(cPtr);
            }
        }

        /// <summary>
        /// The intersection with clip drawable is determined and only the resulting pixels from own drawable are rendered.
        /// </summary>
        /// <param name="clip">The clip drawable object.</param>
        /// <exception cref="Exception"> Drawable clpping failed. </exception>
        /// <exception cref="ArgumentNullException"> Thrown when drawable is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ClipPath(Drawable clip)
        {
            if (clip == null)
            {
                throw new ArgumentNullException(nameof(clip));
            }
            bool ret = Interop.Drawable.SetClipPath(View.getCPtr(this), BaseHandle.getCPtr(clip));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            if (!ret)
            {
                throw new Exception("Drawable clipping failed or clip drawable is already added other drawable or canvas.");
            }
        }

        /// <summary>
        /// The pixels of mask drawable and own drawable are blended according to MaskType.
        /// </summary>
        /// <param name="mask">The mask drawable object.</param>
        /// <param name="type">The masking type.</param>
        /// <exception cref="Exception"> Drawable masking failed. </exception>
        /// <exception cref="ArgumentNullException"> Thrown when drawable is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Mask(Drawable mask, MaskType type)
        {
            if (mask == null)
            {
                throw new ArgumentNullException(nameof(mask));
            }
            bool ret = Interop.Drawable.SetMask(View.getCPtr(this), BaseHandle.getCPtr(mask), (int)type);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            if (!ret)
            {
                throw new Exception("Drawable masking failed or mask drawable is already added other drawable or canvas.");
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
