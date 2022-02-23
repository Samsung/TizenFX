using System.Collections.Generic;
using System.Data;
using System.Globalization;

using Mono.Cecil.Cil;

using Tizen.NUI.Xaml;
using Tizen.NUI.Xaml.Build.Tasks;

using static Mono.Cecil.Cil.Instruction;
using static Mono.Cecil.Cil.OpCodes;

namespace Tizen.NUI.Xaml.Core.XamlC
{
    class ConstraintTypeConverter : ICompiledTypeConverter
    {
        public IEnumerable<Instruction> ConvertFromString(string value, ILContext context, BaseNode node)
        {
            var module = context.Body.Method.Module;

            double size;

            if (string.IsNullOrEmpty(value) || !double.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, out size))
                throw new XamlParseException($"Cannot convert \"{value}\" into {typeof(Constraint)}", node);

            yield return Create(Ldc_R8, size);
            yield return Create(Call, module.ImportMethodReference((XamlTask.nuiAssemblyName, XamlTask.nuiNameSpace, "Constraint"),
                                                                   methodName: "Constant",
                                                                   parameterTypes: new[] { ("mscorlib", "System", "Double") },
                                                                   isStatic: true));
        }
    }
}
