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
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Tizen.NUI.BaseComponents.VectorGraphics
{
    /// <summary>
    /// Enumeration for The fill rule of shape.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
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
    [EditorBrowsable(EditorBrowsableState.Never)]
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
    [EditorBrowsable(EditorBrowsableState.Never)]
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
    /// Enumeration specifying how to fill the area outside the gradient bounds.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum SpreadType
    {
        /// <summary>
        /// The remaining area is filled with the closest stop color.
        /// </summary>
        Pad = 0,
        /// <summary>
        /// The gradient pattern is reflected outside the gradient area until the expected region is filled.
        /// </summary>
        Reflect,
        /// <summary>
        /// The gradient pattern is repeated continuously beyond the gradient area until the expected region is filled.
        /// </summary>
        Repeat
    };
}
