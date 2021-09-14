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
    /// A class representing the linear gradient fill of the Shape object.
    /// Besides the class inherited from the Gradient class, it enables setting and getting the linear gradient bounds.
    /// The behavior outside the gradient bounds depends on the value specified in the spread API.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public class LinearGradient : Gradient
    {
        /// <summary>
        /// Creates an initialized linear gradient.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public LinearGradient() : this(Interop.LinearGradient.New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal LinearGradient(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// Sets the linear gradient bounds.
        /// 
        /// The bounds of the linear gradient are defined by two parallel lines crossing the given points firstPoint and secondPoint, respectively.
        /// Both lines are perpendicular to the line linking firstPoint and secondPoint.
        /// </summary>
        /// <param name="firstPoint">The first point used to determine the gradient bounds.</param>
        /// <param name="secondPoint">The second point used to determine the gradient bounds.</param>
        /// <since_tizen> 9 </since_tizen>
        public void SetBounds(Position2D firstPoint, Position2D secondPoint)
        {
            Interop.LinearGradient.SetBounds(BaseHandle.getCPtr(this), Position2D.getCPtr(firstPoint), Position2D.getCPtr(secondPoint));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the linear gradient bounds.
        /// </summary>
        /// <param name="firstPoint">The first point used to determine the gradient bounds.</param>
        /// <param name="secondPoint">The second point used to determine the gradient bounds.</param>
        /// <since_tizen> 9 </since_tizen>
        public void GetBounds(ref Position2D firstPoint, ref Position2D secondPoint)
        {
            Interop.LinearGradient.GetBounds(BaseHandle.getCPtr(this), Position2D.getCPtr(firstPoint), Position2D.getCPtr(secondPoint));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

    }
}
