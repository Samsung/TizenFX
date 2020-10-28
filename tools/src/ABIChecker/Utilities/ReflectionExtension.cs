using System;
using System.Linq;
using System.Reflection;

namespace Checker_ABI.Utilities
{
    public static class ReflectionExtension
    {
        public static bool IsOverride(this MethodInfo method)
        {
            if (method == null) throw new ArgumentNullException();
            return method.DeclaringType != method.GetBaseDefinition().DeclaringType;
        }

        public static bool AreMethodsEqualForDeclaringType(MethodInfo first, MethodInfo second)
        {
            first = first.ReflectedType == first.DeclaringType ? first : first.DeclaringType.GetMethod(first.Name, first.GetParameters().Select(p => p.ParameterType).ToArray());
            second = second.ReflectedType == second.DeclaringType ? second : second.DeclaringType.GetMethod(second.Name, second.GetParameters().Select(p => p.ParameterType).ToArray());
            return first == second;
        }

    }
}
