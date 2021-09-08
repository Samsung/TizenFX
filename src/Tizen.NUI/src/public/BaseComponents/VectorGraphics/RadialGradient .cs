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
    /// A class representing the radial gradient fill of the Shape object.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class RadialGradient : Gradient
    {
        /// <summary>
        /// Creates an initialized radial gradient.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RadialGradient() : this(Interop.RadialGradient.New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal RadialGradient(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// Sets the radial gradient bounds.
        /// 
        /// The radial gradient bounds are defined as a circle centered in a given point of a given radius.
        /// </summary>
        /// <param name="centerPoint">The point of the center of the bounding circle.</param>
        /// <param name="radius">The radius of the bounding circle.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetBounds(Position2D centerPoint, float radius)
        {
            Interop.RadialGradient.SetBounds(BaseHandle.getCPtr(this), Position2D.getCPtr(centerPoint), radius);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the radial gradient bounds.
        /// </summary>
        /// <param name="centerPoint">The point of the center of the bounding circle.</param>
        /// <param name="radius">The radius of the bounding circle.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void GetBounds(ref Position2D centerPoint, ref float radius)
        {
            float ret = 0.0f;
            unsafe
            {
                float* radiusPtr = &ret;
                Interop.RadialGradient.GetBounds(BaseHandle.getCPtr(this), Position2D.getCPtr(centerPoint), radiusPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            }
            radius = ret;
        }

    }
}
