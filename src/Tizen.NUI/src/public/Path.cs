/*
 * Copyright(c) 2017 Samsung Electronics Co., Ltd.
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
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal Path(global::System.IntPtr cPtr, bool cMemoryOwn) : base(NDalicPINVOKE.Path_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Path obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        /// <summary>
        /// Dispose
        /// </summary>
        /// <param name="type">The dispoase type</param>
        /// <since_tizen> 3 </since_tizen>
        protected override void Dispose(DisposeTypes type)
        {
            if(disposed)
            {
                return;
            }

            if(type == DisposeTypes.Explicit)
            {
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.

            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;
                    NDalicPINVOKE.delete_Path(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }


        internal class Property
        {
            internal static readonly int POINTS = NDalicPINVOKE.Path_Property_POINTS_get();
            internal static readonly int CONTROL_POINTS = NDalicPINVOKE.Path_Property_CONTROL_POINTS_get();
        }

        /// <summary>
        /// Creates an initialized path handle.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Path() : this(NDalicPINVOKE.Path_New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }

        /// <summary>
        /// Adds an interpolation point.
        /// </summary>
        /// <param name="point">The new interpolation point to be added.</param>
        /// <since_tizen> 3 </since_tizen>
        public void AddPoint(Position point)
        {
            NDalicPINVOKE.Path_AddPoint(swigCPtr, Position.getCPtr(point));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Adds a control point.
        /// </summary>
        /// <param name="point">The new control point to be added.</param>
        /// <since_tizen> 3 </since_tizen>
        public void AddControlPoint(Vector3 point)
        {
            NDalicPINVOKE.Path_AddControlPoint(swigCPtr, Vector3.getCPtr(point));
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
            NDalicPINVOKE.Path_GenerateControlPoints(swigCPtr, curvature);
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
            NDalicPINVOKE.Path_Sample(swigCPtr, progress, Vector3.getCPtr(position), Vector3.getCPtr(tangent));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// An accessor for the interpolation points.
        /// </summary>
        /// <param name="index">The index of the interpolation point.</param>
        /// <since_tizen> 3 </since_tizen>
        public Vector3 GetPoint(uint index)
        {
            Vector3 ret = new Vector3(NDalicPINVOKE.Path_GetPoint(swigCPtr, index), false);
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
            Vector3 ret = new Vector3(NDalicPINVOKE.Path_GetControlPoint(swigCPtr, index), false);
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
            uint ret = NDalicPINVOKE.Path_GetPointCount(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
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
                Tizen.NUI.Object.GetProperty(swigCPtr, Path.Property.POINTS).Get(temp);
                return temp;
            }
            set
            {
                Tizen.NUI.Object.SetProperty(swigCPtr, Path.Property.POINTS, new Tizen.NUI.PropertyValue(value));
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
                Tizen.NUI.Object.GetProperty(swigCPtr, Path.Property.CONTROL_POINTS).Get(temp);
                return temp;
            }
            set
            {
                Tizen.NUI.Object.SetProperty(swigCPtr, Path.Property.CONTROL_POINTS, new Tizen.NUI.PropertyValue(value));
            }
        }

    }

}