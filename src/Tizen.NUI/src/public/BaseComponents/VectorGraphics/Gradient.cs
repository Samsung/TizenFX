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
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Tizen.NUI.BaseComponents.VectorGraphics
{
    /// <summary>
    /// An abstract class representing the gradient fill of the Shape.
    /// It contains the information about the gradient colors and their arrangement
    /// inside the gradient bounds. The gradients bounds are defined in the LinearGradient
    /// or RadialGradient class, depending on the type of the gradient to be used.
    /// It specifies the gradient behavior in case the area defined by the gradient bounds
    /// is smaller than the area to be filled.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Gradient : BaseHandle
    {
        /// <summary>
        /// Creates an initialized gradient.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private Gradient() { }

        internal Gradient(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// Specifying how to fill the area outside the gradient bounds.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SpreadType Spread
        {
            get
            {
                return (SpreadType)Interop.Gradient.GetSpread(BaseHandle.getCPtr(this));
            }
            set
            {
                Interop.Gradient.SetSpread(BaseHandle.getCPtr(this), (int)value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// The parameters list of the colors of the gradient and their position.
        /// </summary>
        /// <exception cref="ArgumentNullException"> Thrown when value is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ReadOnlyCollection<ColorStop> ColorStops
        {
            get
            {
                List<ColorStop> retList = new List<ColorStop>();
                uint colorStopsCount = Interop.Gradient.GetColorStopsCount(BaseHandle.getCPtr(this));
                for (uint i = 0; i < colorStopsCount; i++)
                {
                    retList.Add(new ColorStop(Interop.Gradient.GetColorStopsOffsetIndexOf(BaseHandle.getCPtr(this), i),
                                              Vector4.GetVector4FromPtr(Interop.Gradient.GetColorStopsColorIndexOf(BaseHandle.getCPtr(this), i))));
                }

                return retList.AsReadOnly();
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                float[] rawColorStops = new float[value.Count * 5];
                for (int i = 0; i < value.Count; i++)
                {
                    rawColorStops[i * 5] = value[i].Offset;
                    rawColorStops[i * 5 + 1] = value[i].Color.R;
                    rawColorStops[i * 5 + 2] = value[i].Color.G;
                    rawColorStops[i * 5 + 3] = value[i].Color.B;
                    rawColorStops[i * 5 + 4] = value[i].Color.A;
                }

                Interop.Gradient.SetColorStops(BaseHandle.getCPtr(this), rawColorStops, (uint)value.Count);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }
    }
}
