/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections.Generic;

namespace ElmSharp
{
    /// <summary>
    /// Enumeration for the axis along which flip effect should be applied.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public enum FlipAxis
    {
        /// <summary>
        /// Flip on X-axis.
        /// </summary>
        X,

        /// <summary>
        /// Flip on Y-axis.
        /// </summary>
        Y,
    }

    /// <summary>
    /// Enumeration for the direction in which the wipe effect should occur.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public enum WipeDirection
    {
        /// <summary>
        /// Wipe to the left.
        /// </summary>
        Left,

        /// <summary>
        /// Wipe to the right.
        /// </summary>
        Right,

        /// <summary>
        /// Wipe to the up.
        /// </summary>
        Up,

        /// <summary>
        /// Wipe to the down.
        /// </summary>
        Down,
    }

    /// <summary>
    /// Enumeration for whether the wipe effect should show or hide the object.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public enum WipeType
    {
        /// <summary>
        /// Hide the object during the animation.
        /// </summary>
        Hide,

        /// <summary>
        /// Show the object during the animation.
        /// </summary>
        Show,
    }

    /// <summary>
    /// Enumration for the type of acceleration used in transition.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public enum TweenMode
    {
        /// <summary>
        /// Constant speed.
        /// </summary>
        Linear,

        /// <summary>
        /// Starts slow, increases speed over time, then decrease again and stop slowly, v1 being a power factor.
        /// </summary>
        Sinusoidal,

        /// <summary>
        /// Starts fast and decreases speed over time, v1 being a power factor.
        /// </summary>
        Decelerate,

        /// <summary>
        /// Starts slow and increases speed over time, v1 being a power factor.
        /// </summary>
        Accelerate,

        /// <summary>
        /// Starts at gradient v1, interpolated via power of v2 curve.
        /// </summary>
        DivisorInterpolate,

        /// <summary>
        /// Starts at 0.0 then "drop" like a ball bouncing to the ground at 1.0, and bounce v2 times, with decay factor of v1.
        /// </summary>
        Bounce,

        /// <summary>
        /// Starts at 0.0 then "wobble" like a spring rest position 1.0, and wobble v2 times, with decay factor of v1.
        /// </summary>
        Spring,

        /// <summary>
        /// Follows the cubic-bezier curve calculated with the control points (x1, y1), (x2, y2).
        /// </summary>
        BezierCurve,
    }

    /// <summary>
    /// Blend effect class.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class BlendEffect : EffectBase
    {
        /// <summary>
        /// Creates and initializes a new instance of the BlendEffect class.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public BlendEffect()
        {
        }

        internal override IntPtr CreateEffect(IntPtr transit)
        {
            return Interop.Elementary.elm_transit_effect_blend_add(transit);
        }
    }

    /// <summary>
    /// Color effect class.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class ColorEffect : EffectBase
    {
        Color _begin;
        Color _end;

        /// <summary>
        /// Creates and initializes a new instance of the ColorEffect class.
        /// </summary>
        /// <param name="beginColor">The begin color of the effect.</param>
        /// <param name="endColor">The end color of the effect.</param>
        /// <since_tizen> preview </since_tizen>
        public ColorEffect(Color beginColor, Color endColor)
        {
            _begin = beginColor;
            _end = endColor;
        }

        /// <summary>
        /// The begin color of the effect.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public Color BeginColor
        {
            get { return _begin; }
        }

        /// <summary>
        /// The end color of the effect.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public Color EndColor
        {
            get { return _end; }
        }

        internal override IntPtr CreateEffect(IntPtr transit)
        {
            return Interop.Elementary.elm_transit_effect_color_add(transit, _begin.R, _begin.G, _begin.B, _begin.A, _end.R, _end.G, _end.B, _end.A);
        }
    }

    /// <summary>
    /// Fade effect class.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class FadeEffect : EffectBase
    {
        /// <summary>
        /// Creates and initializes a new instance of the FadeEffect class.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public FadeEffect()
        {
        }

        internal override IntPtr CreateEffect(IntPtr transit)
        {
            return Interop.Elementary.elm_transit_effect_fade_add(transit);
        }
    }

    /// <summary>
    /// Flip effect class.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class FlipEffect : EffectBase
    {
        FlipAxis _axis;
        bool _clockWise;
        bool _resizable;

        /// <summary>
        /// Creates and initializes a new instance of the FlipEffect class.
        /// </summary>
        /// <param name="axis">Flipping axis (X or Y).</param>
        /// <param name="clockWise">Flipping Direction. True is clockwise.</param>
        /// <param name="resizable">Resizable effect with FlipEffect.</param>
        /// <since_tizen> preview </since_tizen>
        public FlipEffect(FlipAxis axis, bool clockWise, bool resizable = false)
        {
            _axis = axis;
            _clockWise = clockWise;
            _resizable = resizable;
        }

        /// <summary>
        /// Flipping axis (X or Y).
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public FlipAxis Axis
        {
            get { return _axis; }
        }

        /// <summary>
        /// Flipping direction. True is clockwise.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool ClockWise
        {
            get { return _clockWise; }
        }

        /// <summary>
        /// Resizable FlipEffect.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool Resizable
        {
            get { return _resizable; }
        }

        internal override IntPtr CreateEffect(IntPtr transit)
        {
            if (_resizable)
                return Interop.Elementary.elm_transit_effect_resizable_flip_add(transit, (int)_axis, _clockWise);
            return Interop.Elementary.elm_transit_effect_flip_add(transit, (int)_axis, _clockWise);
        }
    }

    /// <summary>
    /// Resizing effect class.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class ResizingEffect : EffectBase
    {
        Size _begin;
        Size _end;

        /// <summary>
        /// Creates and initializes a new instance of the ResizingEffect class.
        /// </summary>
        /// <param name="beginSize">The begin size of the effect.</param>
        /// <param name="endSize">The end size of the effect.</param>
        /// <since_tizen> preview </since_tizen>
        public ResizingEffect(Size beginSize, Size endSize)
        {
            _begin = beginSize;
            _end = endSize;
        }

        /// <summary>
        /// The begin size of the effect.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public Size BeginSize
        {
            get { return _begin; }
        }

        /// <summary>
        /// The end size of the effect.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public Size EndSize
        {
            get { return _end; }
        }

        internal override IntPtr CreateEffect(IntPtr transit)
        {
            return Interop.Elementary.elm_transit_effect_resizing_add(transit, _begin.Width, _begin.Height, _end.Width, _end.Height);
        }
    }

    /// <summary>
    /// Rotation effect class.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class RotationEffect : EffectBase
    {
        float _begin;
        float _end;

        /// <summary>
        /// Creates and initializes a new instance of the RotationEffect class.
        /// </summary>
        /// <param name="beginDegree">The begin degree of the effect.</param>
        /// <param name="endDegree">The end degree of the effect.</param>
        /// <since_tizen> preview </since_tizen>
        public RotationEffect(float beginDegree, float endDegree)
        {
            _begin = beginDegree;
            _end = endDegree;
        }

        /// <summary>
        /// The begin degree of the effect.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public float BeginDegree
        {
            get { return _begin; }
        }

        /// <summary>
        /// The end degree of the effect.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public float EndDegree
        {
            get { return _end; }
        }

        internal override IntPtr CreateEffect(IntPtr transit)
        {
            return Interop.Elementary.elm_transit_effect_rotation_add(transit, _begin, _end);
        }
    }

    /// <summary>
    /// Translation effect class.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class TranslationEffect : EffectBase
    {
        Point _begin;
        Point _end;

        /// <summary>
        /// Creates and initializes a new instance of the TranslationEffect class.
        /// </summary>
        /// <param name="beginPoint">The begin point of the effect.</param>
        /// <param name="endPoint">The end point of the effect.</param>
        /// <since_tizen> preview </since_tizen>
        public TranslationEffect(Point beginPoint, Point endPoint)
        {
            _begin = beginPoint;
            _end = endPoint;
        }

        /// <summary>
        /// The begin point of the effect.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public Point BeginPoint
        {
            get { return _begin; }
        }

        /// <summary>
        /// The end point of the effect.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public Point EndPoint
        {
            get { return _end; }
        }

        internal override IntPtr CreateEffect(IntPtr transit)
        {
            return Interop.Elementary.elm_transit_effect_translation_add(transit, _begin.X, _begin.Y, _end.X, _end.Y);
        }
    }

    /// <summary>
    /// Wipe effect class.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class WipeEffect : EffectBase
    {
        WipeType _type;
        WipeDirection _direction;

        /// <summary>
        /// Creates and initializes a new instance of the WipeEffect class.
        /// </summary>
        /// <param name="type">Wipe type. Hide or show.</param>
        /// <param name="direction">Wipe direction.</param>
        /// <since_tizen> preview </since_tizen>
        public WipeEffect(WipeType type, WipeDirection direction)
        {
            _type = type;
            _direction = direction;
        }

        /// <summary>
        /// Wipe type. Hide or show.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public WipeType Type
        {
            get { return _type; }
        }

        /// <summary>
        /// Wipe direction.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public WipeDirection Direction
        {
            get { return _direction; }
        }

        internal override IntPtr CreateEffect(IntPtr transit)
        {
            return Interop.Elementary.elm_transit_effect_wipe_add(transit, (int)_type, (int)_direction);
        }
    }

    /// <summary>
    /// Zoom effect class.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class ZoomEffect : EffectBase
    {
        float _begin;
        float _end;

        /// <summary>
        /// Creates and initializes a new instance of the ZoomEffect class.
        /// </summary>
        /// <param name="beginRate">The begin rate of the effect.</param>
        /// <param name="endRate">The end rate of the effect.</param>
        /// <since_tizen> preview </since_tizen>
        public ZoomEffect(float beginRate, float endRate)
        {
            _begin = beginRate;
            _end = endRate;
        }

        /// <summary>
        /// The begin rate of the effect.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public float BeginRate
        {
            get { return _begin; }
        }

        /// <summary>
        /// The end rate of the effect.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public float EndRate
        {
            get { return _end; }
        }

        internal override IntPtr CreateEffect(IntPtr transit)
        {
            return Interop.Elementary.elm_transit_effect_zoom_add(transit, _begin, _end);
        }
    }
}