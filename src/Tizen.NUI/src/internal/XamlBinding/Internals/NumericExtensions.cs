using System;
using System.ComponentModel;

namespace Tizen.NUI.Binding.Internals
{
    internal static class NumericExtensions
    {

        public static double Clamp(this double self, double min, double max)
        {
            return Math.Min(max, Math.Max(self, min));
        }

        public static float Clamp(this float self, float min, float max)
        {
            return Math.Min(max, Math.Max(self, min));
        }

        public static int Clamp(this int self, int min, int max)
        {
            return Math.Min(max, Math.Max(self, min));
        }
    }
}
