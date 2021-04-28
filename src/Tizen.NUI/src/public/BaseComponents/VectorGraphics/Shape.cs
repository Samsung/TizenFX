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
    /// Shape is a command list for drawing one shape groups It has own path data and properties for sync/asynchronous drawing
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public class Shape : Drawable
    {
        /// <summary>
        /// Creates an initialized Shape.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public Shape() : this(Interop.Shape.New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Shape(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// Enumeration for The fill rule of shape.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public enum FillRuleType
        {
            /// <summary>
            /// Draw a horizontal line from the point to a location outside the shape. Determine whether the direction of the line at each intersection point is up or down. The winding number is determined by summing the direction of each intersection. If the number is non zero, the point is inside the shape.
            /// </summary>
            Winding = 0,
            /// <summary>
            /// Draw a horizontal line from the point to a location outside the shape, and count the number of intersections. If the number of intersections is an odd number, the point is inside the shape.
            /// </summary>
            EvenOdd
        }

        /// <summary>
        /// Enumeration for The cap style to be used for stroking the path.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public enum StrokeCapType
        {
            /// <summary>
            /// The end of lines is rendered as a square around the last point.
            /// </summary>
            Square = 0,
            /// <summary>
            /// The end of lines is rendered as a half-circle around the last point.
            /// </summary>
            Round,
            /// <summary>
            /// The end of lines is rendered as a full stop on the last point itself.
            /// </summary>
            Butt
        }

        /// <summary>
        /// numeration for The join style to be used for stroking the path.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public enum StrokeJoinType
        {
            /// <summary>
            /// Used to render beveled line joins. The outer corner of the joined lines is filled by enclosing the triangular region of the corner with a straight line between the outer corners of each stroke.
            /// </summary>
            Bevel = 0,
            /// <summary>
            /// Used to render rounded line joins. Circular arcs are used to join two lines smoothly.
            /// </summary>
            Round,
            /// <summary>
            /// Used to render mitered line joins. The intersection of the strokes is clipped at a line perpendicular to the bisector of the angle between the strokes, at the distance from the intersection of the segments equal to the product of the miter limit value and the border radius.  This prevents long spikes being created.
            /// </summary>
            Miter
        }

        /// <summary>
        /// The color to use for filling the path.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public Color FillColor
        {
            get
            {
                global::System.IntPtr cPtr = Interop.Shape.GetFillColor(BaseHandle.getCPtr(this));
                return Vector4.GetVector4FromPtr(cPtr);
            }
            set
            {
                Interop.Shape.SetFillColor(BaseHandle.getCPtr(this), Vector4.getCPtr(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// The current fill rule of the shape.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public FillRuleType FillRule
        {
            get
            {
                return (FillRuleType)Interop.Shape.GetFillRule(BaseHandle.getCPtr(this));
            }
            set
            {
                Interop.Shape.SetFillRule(BaseHandle.getCPtr(this), (int)value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// The stroke width to use for stroking the path.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public float StrokeWidth
        {
            get
            {
                return Interop.Shape.GetStrokeWidth(BaseHandle.getCPtr(this));
            }
            set
            {
                Interop.Shape.SetStrokeWidth(BaseHandle.getCPtr(this), value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// The color to use for stroking the path.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public Color StrokeColor
        {
            get
            {
                global::System.IntPtr cPtr = Interop.Shape.GetStrokeColor(BaseHandle.getCPtr(this));
                return Vector4.GetVector4FromPtr(cPtr);
            }
            set
            {
                Interop.Shape.SetStrokeColor(BaseHandle.getCPtr(this), Vector4.getCPtr(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// The cap style to use for stroking the path. The cap will be used for capping the end point of a open subpath.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public StrokeCapType StrokeCap
        {
            get
            {
                return (StrokeCapType)Interop.Shape.GetStrokeCap(BaseHandle.getCPtr(this));
            }
            set
            {
                Interop.Shape.SetStrokeCap(BaseHandle.getCPtr(this), (int)value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// The join style to use for stroking the path.
        /// The join style will be used for joining the two line segment while stroking the path.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public StrokeJoinType StrokeJoin
        {
            get
            {
                return (StrokeJoinType)Interop.Shape.GetStrokeJoin(BaseHandle.getCPtr(this));
            }
            set
            {
                Interop.Shape.SetStrokeJoin(BaseHandle.getCPtr(this), (int)value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// The stroke dash pattern. The dash pattern is specified dash pattern.
        /// </summary>
        /// <exception cref="ArgumentNullException"> Thrown when value is null. </exception>
        /// <since_tizen> 9 </since_tizen>
        public ReadOnlyCollection<float> StrokeDash
        {
            get
            {
                List<float> retList = new List<float>();
                int patternCount = Interop.Shape.GetStrokeDashCount(BaseHandle.getCPtr(this));
                for (int i = 0; i < patternCount; i++)
                {
                    retList.Add(Interop.Shape.GetStrokeDashIndexOf(BaseHandle.getCPtr(this), i));
                }

                ReadOnlyCollection<float> ret = new ReadOnlyCollection<float>(retList);
                return ret;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }
                float[] pattern = new float[value.Count];
                for (int i = 0; i < value.Count; i++)
                {
                    pattern[i] = value[i];
                }
                Interop.Shape.SetStrokeDash(BaseHandle.getCPtr(this), pattern, value.Count);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// Append the given rectangle with rounded corner to the path.
        /// The roundedCorner arguments specify the radii of the ellipses defining the
        /// corners of the rounded rectangle.
        ///
        /// roundedCorner are specified in terms of width and height respectively.
        ///
        /// If roundedCorner's values are 0, then it will draw a rectangle without rounded corner.
        /// </summary>
        /// <param name="x">X co-ordinate of the rectangle.</param>
        /// <param name="y">Y co-ordinate of the rectangle.</param>
        /// <param name="width">Width of the rectangle.</param>
        /// <param name="height">Height of the rectangle.</param>
        /// <param name="roundedCornerX">The x radius of the rounded corner and should be in range [ 0 to w/2 ].</param>
        /// <param name="roundedCornerY">The y radius of the rounded corner and should be in range [ 0 to w/2 ].</param>
        /// <returns>True when it's successful. False otherwise.</returns>
        /// <since_tizen> 9 </since_tizen>
        public bool AddRect(float x, float y, float width, float height, float roundedCornerX, float roundedCornerY)
        {
            bool ret = Interop.Shape.AddRect(BaseHandle.getCPtr(this), x, y, width, height, roundedCornerX, roundedCornerY);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Append a circle with given center and x,y-axis radius
        /// </summary>
        /// <param name="x">X co-ordinate of the center of the circle.</param>
        /// <param name="y">Y co-ordinate of the center of the circle.</param>
        /// <param name="radiusX">X axis radius.</param>
        /// <param name="radiusY">Y axis radius.</param>
        /// <returns>True when it's successful. False otherwise.</returns>
        /// <since_tizen> 9 </since_tizen>
        public bool AddCircle(float x, float y, float radiusX, float radiusY)
        {
            bool ret = Interop.Shape.AddCircle(BaseHandle.getCPtr(this), x, y, radiusX, radiusY);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Append the arcs.
        /// </summary>
        /// <param name="x">X co-ordinate of end point of the arc.</param>
        /// <param name="y">Y co-ordinate of end point of the arc.</param>
        /// <param name="radius">Radius of arc</param>
        /// <param name="startAngle">Start angle (in degrees) where the arc begins.</param>
        /// <param name="sweep">The Angle measures how long the arc will be drawn.</param>
        /// <param name="pie">If True, the area is created by connecting start angle point and sweep angle point of the drawn arc. If false, it doesn't.</param>
        /// <returns>True when it's successful. False otherwise.</returns>
        /// <since_tizen> 9 </since_tizen>
        public bool AddArc(float x, float y, float radius, float startAngle, float sweep, bool pie)
        {
            bool ret = Interop.Shape.AddArc(BaseHandle.getCPtr(this), x, y, radius, startAngle, sweep, pie);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Add a point that sets the given point as the current point,
        /// implicitly starting a new subpath and closing the previous one.
        /// </summary>
        /// <param name="x">X co-ordinate of the current point.</param>
        /// <param name="y">Y co-ordinate of the current point.</param>
        /// <returns>True when it's successful. False otherwise.</returns>
        /// <since_tizen> 9 </since_tizen>
        public bool AddMoveTo(float x, float y)
        {
            bool ret = Interop.Shape.AddMoveTo(BaseHandle.getCPtr(this), x, y);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Adds a straight line from the current position to the given end point.
        /// After the line is drawn, the current position is updated to be at the
        /// end point of the line.
        /// If no current position present, it draws a line to itself, basically * a point.
        /// </summary>
        /// <param name="x">X co-ordinate of end point of the line.</param>
        /// <param name="y">Y co-ordinate of end point of the line.</param>
        /// <returns>True when it's successful. False otherwise.</returns>
        /// <since_tizen> 9 </since_tizen>
        public bool AddLineTo(float x, float y)
        {
            bool ret = Interop.Shape.AddLineTo(BaseHandle.getCPtr(this), x, y);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Adds a cubic Bezier curve between the current position and the
        /// given end point (lineEndPoint) using the control points specified by
        /// (controlPoint1), and (controlPoint2). After the path is drawn,
        /// the current position is updated to be at the end point of the path.
        /// </summary>
        /// <param name="controlPoint1X">X co-ordinate of 1st control point.</param>
        /// <param name="controlPoint1Y">Y co-ordinate of 1st control point.</param>
        /// <param name="controlPoint2X">X co-ordinate of 2nd control point.</param>
        /// <param name="controlPoint2Y">Y co-ordinate of 2nd control point.</param>
        /// <param name="endPointX">X co-ordinate of end point of the line.</param>
        /// <param name="endPointY">Y co-ordinate of end point of the line.</param>
        /// <returns>True when it's successful. False otherwise.</returns>
        /// <since_tizen> 9 </since_tizen>
        public bool AddCubicTo(float controlPoint1X, float controlPoint1Y, float controlPoint2X, float controlPoint2Y, float endPointX, float endPointY)
        {
            bool ret = Interop.Shape.AddCubicTo(BaseHandle.getCPtr(this), controlPoint1X, controlPoint1Y, controlPoint2X, controlPoint2Y, endPointX, endPointY);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Closes the current subpath by drawing a line to the beginning of the
        /// subpath, automatically starting a new path. The current point of the
        /// new path is (0, 0).
        /// If the subpath does not contain any points, this function does nothing.
        /// </summary>
        /// <returns>True when it's successful. False otherwise.</returns>
        /// <since_tizen> 9 </since_tizen>
        public bool Close()
        {
            bool ret = Interop.Shape.Close(BaseHandle.getCPtr(this));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Reset the added path(rect, circle, path, etc...) information.
        /// Color and Stroke information are keeped.
        /// </summary>
        /// <returns>True when it's successful. False otherwise.</returns>
        /// <since_tizen> 9 </since_tizen>
        public bool ResetPath()
        {
            bool ret = Interop.Shape.ResetPath(BaseHandle.getCPtr(this));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
    }
}
