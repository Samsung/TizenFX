using System;
using System.Collections.Generic;
using System.Text;

namespace ElmSharp
{
    public interface AnimatorMotionMapper
    {
        double Caculate(double position);
    }

    public class LinearMotionMapper : AnimatorMotionMapper
    {
        public double Caculate(double position)
        {
            return Interop.Ecore.ecore_animator_pos_map(position, Interop.Ecore.PositionMap.Linear, 0, 0);
        }
    }

    public class AccelerateMotionMapper : AnimatorMotionMapper
    {
        public double Caculate(double position)
        {
            return Interop.Ecore.ecore_animator_pos_map(position, Interop.Ecore.PositionMap.Accelerate, 0, 0);
        }
    }

    public class DecelerateMotionMapper : AnimatorMotionMapper
    {
        public double Caculate(double position)
        {
            return Interop.Ecore.ecore_animator_pos_map(position, Interop.Ecore.PositionMap.Decelerate, 0, 0);
        }
    }

    public class SinusoidalMotionMapper : AnimatorMotionMapper
    {
        public double Caculate(double position)
        {
            return Interop.Ecore.ecore_animator_pos_map(position, Interop.Ecore.PositionMap.Sinusoidal, 0, 0);
        }
    }

    public class AccelerateFactorMotionMapper : AnimatorMotionMapper
    {
        public double PowerFactor { get; set; } = 0;

        public double Caculate(double position)
        {
            return Interop.Ecore.ecore_animator_pos_map(position, Interop.Ecore.PositionMap.AccelerateFactor, PowerFactor, 0);
        }
    }

    public class DecelerateFactorMotionMapper : AnimatorMotionMapper
    {
        public double PowerFactor { get; set; } = 0;

        public double Caculate(double position)
        {
            return Interop.Ecore.ecore_animator_pos_map(position, Interop.Ecore.PositionMap.DecelerateFactor, PowerFactor, 0);
        }
    }

    public class SinusoidalFactorMotionMapper : AnimatorMotionMapper
    {
        public double PowerFactor { get; set; } = 0;

        public double Caculate(double position)
        {
            return Interop.Ecore.ecore_animator_pos_map(position, Interop.Ecore.PositionMap.SinusoidalFactor, PowerFactor, 0);
        }
    }

    public class DivisorInterpolatedMotionMapper : AnimatorMotionMapper
    {
        public double Divisor { get; set; } = 0;
        public double Power { get; set; } = 0;

        public double Caculate(double position)
        {
            return Interop.Ecore.ecore_animator_pos_map(position, Interop.Ecore.PositionMap.DivisorInterp, Divisor, Power);
        }
    }

    public class BounceMotionMapper : AnimatorMotionMapper
    {
        public int Bounces { get; set; } = 0;
        public double DecayFactor { get; set; } = 0;
        public double Caculate(double position)
        {
            return Interop.Ecore.ecore_animator_pos_map(position, Interop.Ecore.PositionMap.Bounce, DecayFactor, Bounces);
        }
    }

    public class SpringMotionMapper : AnimatorMotionMapper
    {
        public int Wobbles { get; set; } = 0;
        public double DecayFactor { get; set; } = 0;

        public double Caculate(double position)
        {
            return Interop.Ecore.ecore_animator_pos_map(position, Interop.Ecore.PositionMap.Bounce, DecayFactor, Wobbles);
        }
    }

    public class CubicBezierMotionMapper : AnimatorMotionMapper
    {
        public double X1 { get; set; } = 0;
        public double Y1 { get; set; } = 0;
        public double X2 { get; set; } = 0;
        public double Y2 { get; set; } = 0;

        public double Caculate(double position)
        {
            double[] values = { X1, Y1, X2, Y2 };
            return Interop.Ecore.ecore_animator_pos_map_n(position, Interop.Ecore.PositionMap.Bounce, values.Length, values);
        }
    }
}
