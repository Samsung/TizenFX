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
using System.ComponentModel;
using System.Collections.Generic;

namespace Tizen.NUI.BaseComponents
{

    namespace VectorGraphics
    {
        /// <summary>
        /// Shape is a command list for drawing one shape groups It has own path data & properties for sync/asynchronous drawing
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class Shape : Paint
        {
            /// <summary>
            /// Enumeration for The cap style to be used for stroking the path.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public enum StrokeCap
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
            [EditorBrowsable(EditorBrowsableState.Never)]
            public enum StrokeJoin
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
            /// Enumeration for The fill rule of shape.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public enum FillRule
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

            public Shape() : this(Interop.Shape.New(), true)
            {
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }

            internal Shape(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
            {
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
            /// <param name="Y">Y co-ordinate of the rectangle.</param>
            /// <param name="width">Width of the rectangle.</param>
            /// <param name="height">Height of the rectangle.</param>
            /// <param name="roundedCornerX">The x radius of the rounded corner and should be in range [ 0 to w/2 ].</param>
            /// <param name="roundedCornerY">The y radius of the rounded corner and should be in range [ 0 to w/2 ].</param>
            /// <returns>True when it's successful. False otherwise.</returns>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public bool AddRect(float x, float y, float width, float height, float roundedCornerX, float roundedCornerY)
            {   
                if (Interop.Shape.AddRect(BaseHandle.getCPtr(this), x, y, width, height, roundedCornerX, roundedCornerY))
                    return true;
                return false;
            }

            /// <summary>
            /// Append a circle with given center and x,y-axis radius
            /// </summary>
            /// <param name="x">X co-ordinate of the center of the circle.</param>
            /// <param name="y">Y co-ordinate of the center of the circle.</param>
            /// <param name="radiusX">X axis radius of the circle.</param>
            /// <param name="radiusY">X axis radius of the circle.</param>
            /// <returns>True when it's successful. False otherwise.</returns>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public bool AddCircle(float x, float y, float radiusX, float radiusY)
            {
                if (Interop.Shape.AddCircle(BaseHandle.getCPtr(this), x, y, radiusX, radiusY))
                    return true;
                return false;
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
            [EditorBrowsable(EditorBrowsableState.Never)]
            public bool AddArc(float x, float y, float radius, float startAngle, float sweep, bool pie)
            {
                if (Interop.Shape.AddArc(BaseHandle.getCPtr(this), x, y, radius, startAngle, sweep, pie))
                    return true;
                return false;
            }

            /// <summary>
            /// Add a point that sets the given point as the current point,
            /// implicitly starting a new subpath and closing the previous one.
            /// </summary>
            /// <param name="x">X co-ordinate of the current point.</param>
            /// <param name="y">Y co-ordinate of the current point.</param>
            /// <returns>True when it's successful. False otherwise.</returns>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public bool AddMoveTo(float x, float y)
            {
                if (Interop.Shape.AddMoveTo(BaseHandle.getCPtr(this), x, y))
                    return true;
                return false;
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
            [EditorBrowsable(EditorBrowsableState.Never)]
            public bool AddLineTo(float x, float y)
            {
                if (Interop.Shape.AddLineTo(BaseHandle.getCPtr(this), x, y))
                    return true;
                return false;
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
            [EditorBrowsable(EditorBrowsableState.Never)]
            public bool AddCubicTo(float controlPoint1X, float controlPoint1Y, float controlPoint2X, float controlPoint2Y, float endPointX, float endPointY)
            {
                if (Interop.Shape.AddCubicTo(BaseHandle.getCPtr(this),  controlPoint1X, controlPoint1Y, controlPoint2X, controlPoint2Y, endPointX, endPointY))
                    return true;
                return false;
            }

            /// <summary>
            /// Closes the current subpath by drawing a line to the beginning of the
            /// subpath, automatically starting a new path. The current point of the
            /// new path is (0, 0).
            /// If the subpath does not contain any points, this function does nothing.
            /// </summary>
            /// <returns>True when it's successful. False otherwise.</returns>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public bool Close()
            {
                if (Interop.Shape.Close(BaseHandle.getCPtr(this)))
                    return true;
                return false;
            }

            /// <summary>
            /// Set the color to use for filling the path.
            /// </summary>
            /// <param name="color">The color value.</param>
            /// <returns>True when it's successful. False otherwise.</returns>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public bool SetFillColor(Color color)
            {   
                if (Interop.Shape.SetFillColor(BaseHandle.getCPtr(this), Vector4.getCPtr(color)))
                    return true;
                return false;
            }

            /// <summary>
            /// Get the color to use for filling the path.
            /// </summary>
            /// <returns>Returns the color value.</returns>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Color GetFillColor()
            {   
                global::System.IntPtr cPtr = Interop.Shape.GetFillColor(BaseHandle.getCPtr(this));
                Color color = Vector4.GetVector4FromPtr(cPtr);
                return color;
            }

            /// <summary>
            /// Set the fill rule.
            /// </summary>
            /// <param name="rule">The current fill rule of the shape.</param>
            /// <returns>True when it's successful. False otherwise.</returns>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public bool SetFillRule(FillRule rule)
            {
                if (Interop.Shape.SetFillRule(BaseHandle.getCPtr(this), (int)rule))
                    return true;
                return false;
            }

            /// <summary>
            /// Get the fill rule.
            /// </summary>
            /// <returns>Returns the current fill rule of the shape.</returns>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public FillRule GetFillRule()
            {
                return (FillRule)Interop.Shape.GetFillRule(BaseHandle.getCPtr(this));
            }

            /// <summary>
            /// Set the stroke width to use for stroking the path.
            /// </summary>
            /// <param name="width">Stroke width to be used.</param>
            /// <returns>True when it's successful. False otherwise.</returns>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public bool SetStrokeWidth(float width)
            {
                if (Interop.Shape.SetStrokeWidth(BaseHandle.getCPtr(this), width))
                    return true;
                return false;
            }

            /// <summary>
            /// Get the stroke width to use for stroking the path.
            /// </summary>
            /// <returns>Returns stroke width to be used.</returns>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public float GetStrokeWidth()
            {
                return Interop.Shape.GetStrokeWidth(BaseHandle.getCPtr(this));
            }
            
            /// <summary>
            /// Set the color to use for stroking the path.
            /// </summary>
            /// <param name="color">The stroking color.</param>
            /// <returns>True when it's successful. False otherwise.</returns>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public bool SetStrokeColor(Color color)
            {
                if (Interop.Shape.SetStrokeColor(BaseHandle.getCPtr(this), Vector4.getCPtr(color)))
                    return true;
                return false;
            }

            /// <summary>
            /// Get the color to use for stroking the path.
            /// </summary>
            /// <returns>Returns the stroking color.</returns>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Color GetStrokeColor()
            {
                global::System.IntPtr cPtr = Interop.Shape.GetStrokeColor(BaseHandle.getCPtr(this));
                Color color = Vector4.GetVector4FromPtr(cPtr);
                return color;
            }

            /// <summary>
            /// Sets the stroke dash pattern. The dash pattern is specified dash pattern.
            /// </summary>
            /// <param name="dashPattern">Lenght and a gap list.</param>
            /// <param name="count">Pattern list length</param>
            /// <returns>True when it's successful. False otherwise.</returns>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public bool SetStrokeDash(float[] dashPattern, int count)
            {
                if (Interop.Shape.SetStrokeDash(BaseHandle.getCPtr(this), dashPattern, count))
                    return true;
                return false;
            }

            /// <summary>
            /// Gets the stroke dash pattern.
            /// </summary>
            /// <returns>Returns the stroke dash pattern. The dash pattern is specified dash pattern.</returns>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public List<float> GetStrokeDash()
            {
                List<float> pattern = new List<float>();

                int patternCount = Interop.Shape.GetStrokeDashCount(BaseHandle.getCPtr(this));
                for(int i = 0; i < patternCount; i++)
                {
                    pattern.Add(Interop.Shape.GetStrokeDashIndexOf(BaseHandle.getCPtr(this), i));
                }
                return pattern;
            }

            /// <summary>
            /// Set the cap style to use for stroking the path. The cap will be used for capping the end point of a open subpath.
            /// </summary>
            /// <param name="cap">Cap style to use.</param>
            /// <returns>True when it's successful. False otherwise.</returns>
            [EditorBrowsable(EditorBrowsableState.Never)]            
            public bool SetStrokeCap(StrokeCap cap)
            {
                if (Interop.Shape.SetStrokeCap(BaseHandle.getCPtr(this), (int)cap))
                    return true;
                return false;
            }

            /// <summary>
            /// Get the cap style to use for stroking the path.
            /// </summary>
            /// <returns>Returns the cap style.</returns>
            [EditorBrowsable(EditorBrowsableState.Never)]            
            public StrokeCap GetStrokeCap()
            {
                return (StrokeCap)Interop.Shape.GetStrokeCap(BaseHandle.getCPtr(this));
            }

            /// <summary>
            /// Set the join style to use for stroking the path.
            /// The join style will be used for joining the two line segment while stroking the path.
            /// </summary>
            /// <param name="join">Join style to use.</param>
            /// <returns>True when it's successful. False otherwise.</returns>
            [EditorBrowsable(EditorBrowsableState.Never)]            
            public bool SetStrokeJoin(StrokeJoin join)
            {
                if (Interop.Shape.SetStrokeJoin(BaseHandle.getCPtr(this), (int)join))
                    return true;
                return false;
            }

            /// <summary>
            /// Get the join style to use for stroking the path.
            /// </summary>
            /// <returns>Returns join style to use.</returns>
            [EditorBrowsable(EditorBrowsableState.Never)]            
            public StrokeJoin GetStrokeJoin()
            {
                return (StrokeJoin)Interop.Shape.GetStrokeJoin(BaseHandle.getCPtr(this));
            }
        }
    }
}
