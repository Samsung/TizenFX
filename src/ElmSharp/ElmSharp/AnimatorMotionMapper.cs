using System;
using System.Collections.Generic;
using System.Text;

namespace ElmSharp
{
    /// <summary>
    /// The AnimatorMotionMapper interface
    /// </summary>
    public interface AnimatorMotionMapper
    {
        /// <summary>
        /// Maps an input position from 0.0 to 1.0 along a timeline to a position in a different curve
        /// </summary>
        double Caculate(double position);
    }

    /// <summary>
    /// The LinearMotionMapper class
    /// </summary>
    public class LinearMotionMapper : AnimatorMotionMapper
    {
        /// <summary>
        /// Maps an input position from 0.0 to 1.0 along a timeline to a position in a different curve
        /// </summary>
        public double Caculate(double position)
        {
            return Interop.Ecore.ecore_animator_pos_map(position, Interop.Ecore.PositionMap.Linear, 0, 0);
        }
    }

    /// <summary>
    /// The AccelerateMotionMapper class
    /// </summary>
    public class AccelerateMotionMapper : AnimatorMotionMapper
    {
        /// <summary>
        /// Maps an input position from 0.0 to 1.0 along a timeline to a position in a different curve
        /// </summary>
        public double Caculate(double position)
        {
            return Interop.Ecore.ecore_animator_pos_map(position, Interop.Ecore.PositionMap.Accelerate, 0, 0);
        }
    }

    /// <summary>
    /// The DecelerateMotionMapper class
    /// </summary>
    public class DecelerateMotionMapper : AnimatorMotionMapper
    {
        /// <summary>
        /// Maps an input position from 0.0 to 1.0 along a timeline to a position in a different curve
        /// </summary>
        public double Caculate(double position)
        {
            return Interop.Ecore.ecore_animator_pos_map(position, Interop.Ecore.PositionMap.Decelerate, 0, 0);
        }
    }

    /// <summary>
    /// The SinusoidalMotionMapper class
    /// </summary>
    public class SinusoidalMotionMapper : AnimatorMotionMapper
    {
        /// <summary>
        /// Maps an input position from 0.0 to 1.0 along a timeline to a position in a different curve
        /// </summary>
        public double Caculate(double position)
        {
            return Interop.Ecore.ecore_animator_pos_map(position, Interop.Ecore.PositionMap.Sinusoidal, 0, 0);
        }
    }

    /// <summary>
    /// The AccelerateFactorMotionMapper class
    /// </summary>
    public class AccelerateFactorMotionMapper : AnimatorMotionMapper
    {
        /// <summary>
        /// The power factor of AccelerateFactorMotionMapper
        /// </summary>
        public double PowerFactor { get; set; } = 0;

        /// <summary>
        /// Maps an input position from 0.0 to 1.0 along a timeline to a position in a different curve
        /// </summary>
        public double Caculate(double position)
        {
            return Interop.Ecore.ecore_animator_pos_map(position, Interop.Ecore.PositionMap.AccelerateFactor, PowerFactor, 0);
        }
    }

    /// <summary>
    /// The DecelerateFactorMotionMapper class
    /// </summary>
    public class DecelerateFactorMotionMapper : AnimatorMotionMapper
    {
        /// <summary>
        /// The power factor of DecelerateFactorMotionMapper
        /// </summary>
        public double PowerFactor { get; set; } = 0;

        /// <summary>
        /// Maps an input position from 0.0 to 1.0 along a timeline to a position in a different curve
        /// </summary>
        public double Caculate(double position)
        {
            return Interop.Ecore.ecore_animator_pos_map(position, Interop.Ecore.PositionMap.DecelerateFactor, PowerFactor, 0);
        }
    }

    /// <summary>
    /// The SinusoidalFactorMotionMapper class
    /// </summary>
    public class SinusoidalFactorMotionMapper : AnimatorMotionMapper
    {
        /// <summary>
        /// The power factor of SinusoidalFactorMotionMapper
        /// </summary>
        public double PowerFactor { get; set; } = 0;

        /// <summary>
        /// Maps an input position from 0.0 to 1.0 along a timeline to a position in a different curve
        /// </summary>
        public double Caculate(double position)
        {
            return Interop.Ecore.ecore_animator_pos_map(position, Interop.Ecore.PositionMap.SinusoidalFactor, PowerFactor, 0);
        }
    }

    /// <summary>
    /// The DivisorInterpolatedMotionMapper class
    /// </summary>
    public class DivisorInterpolatedMotionMapper : AnimatorMotionMapper
    {
        /// <summary>
        /// The Divisor of DivisorInterpolatedMotionMapper
        /// </summary>
        public double Divisor { get; set; } = 0;

        /// <summary>
        /// The power of DivisorInterpolatedMotionMapper
        /// </summary>
        public double Power { get; set; } = 0;

        /// <summary>
        /// Maps an input position from 0.0 to 1.0 along a timeline to a position in a different curve
        /// </summary>
        public double Caculate(double position)
        {
            return Interop.Ecore.ecore_animator_pos_map(position, Interop.Ecore.PositionMap.DivisorInterp, Divisor, Power);
        }
    }

    /// <summary>
    /// The BounceMotionMapper class
    /// </summary>
    public class BounceMotionMapper : AnimatorMotionMapper
    {
        /// <summary>
        /// The bounces of BounceMotionMapper
        /// </summary>
        public int Bounces { get; set; } = 0;

        /// <summary>
        /// The decay factor of BounceMotionMapper
        /// </summary>
        public double DecayFactor { get; set; } = 0;

        /// <summary>
        /// Maps an input position from 0.0 to 1.0 along a timeline to a position in a different curve
        /// </summary>
        public double Caculate(double position)
        {
            return Interop.Ecore.ecore_animator_pos_map(position, Interop.Ecore.PositionMap.Bounce, DecayFactor, Bounces);
        }
    }

    /// <summary>
    /// The SpringMotionMapper class
    /// </summary>
    public class SpringMotionMapper : AnimatorMotionMapper
    {
        /// <summary>
        /// The wobbles of SpringMotionMapper
        /// </summary>
        public int Wobbles { get; set; } = 0;

        /// <summary>
        /// The decat factir of SpringMotionMapper
        /// </summary>
        public double DecayFactor { get; set; } = 0;

        /// <summary>
        /// Maps an input position from 0.0 to 1.0 along a timeline to a position in a different curve
        /// </summary>
        public double Caculate(double position)
        {
            return Interop.Ecore.ecore_animator_pos_map(position, Interop.Ecore.PositionMap.Bounce, DecayFactor, Wobbles);
        }
    }

    /// <summary>
    /// The CubicBezierMotionMapper class
    /// </summary>
    public class CubicBezierMotionMapper : AnimatorMotionMapper
    {
        /// <summary>
        /// The X1 of CubicBezierMotionMapper
        /// </summary>
        public double X1 { get; set; } = 0;

        /// <summary>
        /// The Y1 of CubicBezierMotionMapper
        /// </summary>
        public double Y1 { get; set; } = 0;

        /// <summary>
        /// The X2 of CubicBezierMotionMapper
        /// </summary>
        public double X2 { get; set; } = 0;

        /// <summary>
        /// The Y2 of CubicBezierMotionMapper
        /// </summary>
        public double Y2 { get; set; } = 0;

        /// <summary>
        /// Maps an input position from 0.0 to 1.0 along a timeline to a position in a different curve
        /// </summary>
        public double Caculate(double position)
        {
            double[] values = { X1, Y1, X2, Y2 };
            return Interop.Ecore.ecore_animator_pos_map_n(position, Interop.Ecore.PositionMap.Bounce, values.Length, values);
        }
    }
}
