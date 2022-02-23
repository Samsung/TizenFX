using Mono.Cecil;
using Mono.Cecil.Cil;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;

using Tizen.NUI;
using Tizen.NUI.Xaml.Build.Tasks;

namespace Tizen.NUI.Xaml.Core.XamlC
{
    internal class ExtentsTypeConverter : ICompiledTypeConverter
    {
        IEnumerable<Instruction> GenerateIL(ModuleDefinition module, params ushort[] args)
        {
            foreach (var d in args)
                yield return Instruction.Create(OpCodes.Ldc_I4, d);

            yield return Instruction.Create(OpCodes.Newobj, module.ImportCtorReference((XamlTask.nuiAssemblyName, XamlTask.nuiNameSpace, "Extents"),
                parameterTypes: args.Select(a => ("mscorlib", "System", "UInt16")).ToArray()));
        }

        public IEnumerable<Instruction> ConvertFromString(string value, ILContext context, BaseNode node)
        {
            var module = context.Body.Method.Module;

            if (!string.IsNullOrEmpty(value))
            {
                var thickness = value.Split(',');

                foreach (var thick in thickness)
                {
                    if (thick.EndsWith("dp") || thick.EndsWith("px"))
                    {
                        return null;
                    }
                }

                if (4 == thickness.Length)
                {
                    ushort start, end, top, bottom;

                    if (ushort.TryParse(thickness[0], NumberStyles.Number, CultureInfo.InvariantCulture, out start) &&
                        ushort.TryParse(thickness[1], NumberStyles.Number, CultureInfo.InvariantCulture, out end) &&
                        ushort.TryParse(thickness[2], NumberStyles.Number, CultureInfo.InvariantCulture, out top) &&
                        ushort.TryParse(thickness[2], NumberStyles.Number, CultureInfo.InvariantCulture, out bottom))

                        return GenerateIL(module, start, end, top, bottom);
                }
                else if (1 == thickness.Length)
                {
                    ushort v;
                    ushort.TryParse(thickness[0], NumberStyles.Number, CultureInfo.InvariantCulture, out v);
                    return GenerateIL(module, v, v, v, v);
                }
            }

            throw new XamlParseException($"Cannot convert \"{value}\" into Position", node);
        }
    }
}
