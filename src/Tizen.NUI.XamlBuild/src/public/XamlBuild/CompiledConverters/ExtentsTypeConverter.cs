/*
 * Copyright(c) 2022 Samsung Electronics Co., Ltd.
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
                    if (null != NodeILExtensions.GetDPValueSubFix(thick))
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
 
