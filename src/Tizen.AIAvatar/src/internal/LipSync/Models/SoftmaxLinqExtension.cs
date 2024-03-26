using System;
using System.Collections.Generic;
using System.Linq;

namespace Tizen.AIAvatar
{
    internal static class SoftmaxLinqExtension
    {
        internal static IEnumerable<float> SoftMax(this IEnumerable<float> source)
        {
            var exp = source.Select(x => MathF.Exp(x)).ToArray();
            var sum = exp.Sum();
            return exp.Select(x => x / sum);
        }
    }
}
