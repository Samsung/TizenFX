using System;
using System.Collections.Generic;
using System.Text;

namespace ElmSharp
{
    /// <summary>
    /// The AnimatorMotionMapper interface.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public interface IAnimatorMotionMapper
    {
        /// <summary>
        /// Maps an input position from 0.0 to 1.0 along a timeline to a position in a different curve.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        double Calculate(double position);
    }

    /// <summary>
    /// The LinearMotionMapper class.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class LinearMotionMapper : IAnimatorMotionMapper
    {
        /// <summary>
        /// Maps an input position from 0.0 to 1.0 along a timeline to a position in a different curve.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public double Calculate(double position)
        {
            return Interop.Ecore.ecore_animator_pos_map(position, Interop.Ecore.PositionMap.Linear, 0, 0);
        }
    }

    /// <summary>
    /// The AccelerateMotionMapper class.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class AccelerateMotionMapper : IAnimatorMotionMapper
    {
        /// <summary>
        /// Maps an input position from 0.0 to 1.0 along a timeline to a position in a different curve.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public double Calculate(double position)
        {
            return Interop.Ecore.ecore_animator_pos_map(position, Interop.Ecore.PositionMap.Accelerate, 0, 0);
        }
    }

    /// <summary>
    /// The DecelerateMotionMapper class.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class DecelerateMotionMapper : IAnimatorMotionMapper
    {
        /// <summary>
        /// Maps an input position from 0.0 to 1.0 along a timeline to a position in a different curve.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public double Calculate(double position)
        {
            return Interop.Ecore.ecore_animator_pos_map(position, Interop.Ecore.PositionMap.Decelerate, 0, 0);
        }
    }

    /// <summary>
    /// The SinusoidalMotionMapper class.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class SinusoidalMotionMapper : IAnimatorMotionMapper
    {
        /// <summary>
        /// Maps an input position from 0.0 to 1.0 along a timeline to a position in a different curve.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public double Calculate(double position)
        {
            return Interop.Ecore.ecore_animator_pos_map(position, Interop.Ecore.PositionMap.Sinusoidal, 0, 0);
        }
    }

    /// <summary>.
    /// The AccelerateFactorMotionMapper class.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class AccelerateFactorMotionMapper : IAnimatorMotionMapper
    {
        /// <summary>
        /// The power factor of AccelerateFactorMotionMapper.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public double PowerFactor { get; set; } = 0;

        /// <summary>
        /// Maps an input position from 0.0 to 1.0 along a timeline to a position in a different curve.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public double Calculate(double position)
        {
            return Interop.Ecore.ecore_animator_pos_map(position, Interop.Ecore.PositionMap.AccelerateFactor, PowerFactor, 0);
        }
    }

    /// <summary>
    /// The DecelerateFactorMotionMapper class.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class DecelerateFactorMotionMapper : IAnimatorMotionMapper
    {
        /// <summary>
        /// The power factor of DecelerateFactorMotionMapper.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public double PowerFactor { get; set; } = 0;

        /// <summary>
        /// Maps an input position from 0.0 to 1.0 along a timeline to a position in a different curve.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public double Calculate(double position)
        {
            return Interop.Ecore.ecore_animator_pos_map(position, Interop.Ecore.PositionMap.DecelerateFactor, PowerFactor, 0);
        }
    }

    /// <summary>
    /// The SinusoidalFactorMotionMapper class.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class SinusoidalFactorMotionMapper : IAnimatorMotionMapper
    {
        /// <summary>
        /// The power factor of SinusoidalFactorMotionMapper.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public double PowerFactor { get; set; } = 0;

        /// <summary>
        /// Maps an input position from 0.0 to 1.0 along a timeline to a position in a different curve.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public double Calculate(double position)
        {
            return Interop.Ecore.ecore_animator_pos_map(position, Interop.Ecore.PositionMap.SinusoidalFactor, PowerFactor, 0);
        }
    }

    /// <summary>
    /// The DivisorInterpolatedMotionMapper class.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class DivisorInterpolatedMotionMapper : IAnimatorMotionMapper
    {
        /// <summary>
        /// The Divisor of DivisorInterpolatedMotionMapper.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public double Divisor { get; set; } = 0;

        /// <summary>
        /// The power of DivisorInterpolatedMotionMapper.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public double Power { get; set; } = 0;

        /// <summary>
        /// Maps an input position from 0.0 to 1.0 along a timeline to a position in a different curve.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public double Calculate(double position)
        {
            return Interop.Ecore.ecore_animator_pos_map(position, Interop.Ecore.PositionMap.DivisorInterp, Divisor, Power);
        }
    }

    /// <summary>
    /// The BounceMotionMapper class.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class BounceMotionMapper : IAnimatorMotionMapper
    {
        /// <summary>
        /// The bounces of BounceMotionMapper.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int Bounces { get; set; } = 0;

        /// <summary>
        /// The decay factor of BounceMotionMapper.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public double DecayFactor { get; set; } = 0;

        /// <summary>
        /// Maps an input position from 0.0 to 1.0 along a timeline to a position in a different curve.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public double Calculate(double position)
        {
            return Interop.Ecore.ecore_animator_pos_map(position, Interop.Ecore.PositionMap.Bounce, DecayFactor, Bounces);
        }
    }

    /// <summary>
    /// The SpringMotionMapper class.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class SpringMotionMapper : IAnimatorMotionMapper
    {
        /// <summary>
        /// The wobbles of SpringMotionMapper.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int Wobbles { get; set; } = 0;

        /// <summary>
        /// The decay factor of SpringMotionMapper.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public double DecayFactor { get; set; } = 0;

        /// <summary>
        /// Maps an input position from 0.0 to 1.0 along a timeline to a position in a different curve.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public double Calculate(double position)
        {
            return Interop.Ecore.ecore_animator_pos_map(position, Interop.Ecore.PositionMap.Bounce, DecayFactor, Wobbles);
        }
    }

    /// <summary>
    /// The CubicBezierMotionMapper class.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class CubicBezierMotionMapper : IAnimatorMotionMapper
    {
        /// <summary>
        /// The X1 of CubicBezierMotionMapper.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public double X1 { get; set; } = 0;

        /// <summary>
        /// The Y1 of CubicBezierMotionMapper.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public double Y1 { get; set; } = 0;

        /// <summary>
        /// The X2 of CubicBezierMotionMapper.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public double X2 { get; set; } = 0;

        /// <summary>
        /// The Y2 of CubicBezierMotionMapper.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public double Y2 { get; set; } = 0;

        /// <summary>
        /// Maps an input position from 0.0 to 1.0 along a timeline to a position in a different curve.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public double Calculate(double position)
        {
            double[] values = { X1, Y1, X2, Y2 };
            return Interop.Ecore.ecore_animator_pos_map_n(position, Interop.Ecore.PositionMap.Bounce, values.Length, values);
        }
    }
}
