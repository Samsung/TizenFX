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

namespace Tizen.NUI
{
    /// <summary>
    /// A 3D parametric curve.<br />
    /// Paths can be used to animate the position and orientation of actors.<br />
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class Path : BaseHandle
    {
        /// <summary>
        /// Creates an initialized path handle.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Path() : this(Interop.Path.New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Path(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// Enumeration for the Points.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyArray Points
        {
            get
            {
                Tizen.NUI.PropertyArray temp = new Tizen.NUI.PropertyArray();
                var pValue = Tizen.NUI.Object.GetProperty(SwigCPtr, Path.Property.POINTS);
                pValue.Get(temp);
                pValue.Dispose();
                return temp;
            }
            set
            {
                var temp = new Tizen.NUI.PropertyValue(value);
                Tizen.NUI.Object.SetProperty(SwigCPtr, Path.Property.POINTS, temp);
                temp.Dispose();
            }
        }

        /// <summary>
        /// Enumeration for the ControlPoints.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyArray ControlPoints
        {
            get
            {
                Tizen.NUI.PropertyArray temp = new Tizen.NUI.PropertyArray();
                var pValue = Tizen.NUI.Object.GetProperty(SwigCPtr, Path.Property.ControlPoints);
                pValue.Get(temp);
                pValue.Dispose();
                return temp;
            }
            set
            {
                var temp = new Tizen.NUI.PropertyValue(value);
                Tizen.NUI.Object.SetProperty(SwigCPtr, Path.Property.ControlPoints, temp);
                temp.Dispose();
            }
        }

        /// <summary>
        /// Adds an interpolation point.
        /// </summary>
        /// <param name="point">The new interpolation point to be added.</param>
        /// <since_tizen> 3 </since_tizen>
        public void AddPoint(Position point)
        {
            Interop.Path.AddPoint(SwigCPtr, Position.getCPtr(point));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Adds a control point.
        /// </summary>
        /// <param name="point">The new control point to be added.</param>
        /// <since_tizen> 3 </since_tizen>
        public void AddControlPoint(Vector3 point)
        {
            Interop.Path.AddControlPoint(SwigCPtr, Vector3.getCPtr(point));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Automatic generation of control points. Generated control points which result in a smooth join between the splines of each segment.<br />
        /// The generating algorithm is as follows:<br />
        /// For a given knot point K[N], find the vector that bisects K[N-1],[N] and [N],[N+1].<br />
        /// Calculate the tangent vector by taking the normal of this bisector.<br />
        /// The in control point is the length of the preceding segment back along this bisector multiplied by the curvature.<br />
        /// The out control point is the length of the succeeding segment forward along this bisector multiplied by the curvature.<br />
        /// </summary>
        /// <param name="curvature">The curvature of the spline. 0 gives straight lines between the knots, negative values means the spline contains loops, positive values up to 0.5 result in a smooth curve, positive values between 0.5 and 1 result in looped curves where the loops are not distinct (i.e., the curve appears to be non-continuous), positive values higher than 1 result in looped curves.</param>
        /// <since_tizen> 3 </since_tizen>
        public void GenerateControlPoints(float curvature)
        {
            Interop.Path.GenerateControlPoints(SwigCPtr, curvature);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sample path at a given progress. Calculates the position and tangent at that point of the curve.
        /// </summary>
        /// <param name="progress">A floating point value between 0.0 and 1.0.</param>
        /// <param name="position">The interpolated position at that progress.</param>
        /// <param name="tangent">The interpolated tangent at that progress.</param>
        /// <since_tizen> 3 </since_tizen>
        public void Sample(float progress, Vector3 position, Vector3 tangent)
        {
            Interop.Path.Sample(SwigCPtr, progress, Vector3.getCPtr(position), Vector3.getCPtr(tangent));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// An accessor for the interpolation points.
        /// </summary>
        /// <param name="index">The index of the interpolation point.</param>
        /// <since_tizen> 3 </since_tizen>
        public Vector3 GetPoint(uint index)
        {
            Vector3 ret = new Vector3(Interop.Path.GetPoint(SwigCPtr, index), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// An accessor for the control points.
        /// </summary>
        /// <param name="index">The index of the control point.</param>
        /// <since_tizen> 3 </since_tizen>
        public Vector3 GetControlPoint(uint index)
        {
            Vector3 ret = new Vector3(Interop.Path.GetControlPoint(SwigCPtr, index), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets the number of interpolation points in the path.
        /// </summary>
        /// <returns>The number of interpolation points in the path.</returns>
        /// <since_tizen> 3 </since_tizen>
        public uint GetPointCount()
        {
            uint ret = Interop.Path.GetPointCount(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Path obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Path.DeletePath(swigCPtr);
        }

        internal class Property
        {
            internal static readonly int POINTS = Interop.Path.PointsGet();
            internal static readonly int ControlPoints = Interop.Path.ControlPointsGet();
        }
    }
}
