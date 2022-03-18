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
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

using Mono.Cecil;
using Mono.Cecil.Cil;
using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;
using Tizen.NUI.Xaml.Build.Tasks;

namespace Tizen.NUI.Xaml.Core.XamlC
{
    internal class PositionTypeConverter : ICompiledTypeConverter
    {
        IEnumerable<Instruction> GenerateIL(ModuleDefinition module, params double[] args)
        {
            foreach (var d in args)
                yield return Instruction.Create(OpCodes.Ldc_R8, d);

            yield return Instruction.Create(OpCodes.Newobj, module.ImportCtorReference((XamlTask.nuiAssemblyName, XamlTask.nuiNameSpace, "Position"),
                parameterTypes: args.Select(a => ("mscorlib", "System", "Single")).ToArray()));
        }

        private IEnumerable<Instruction> ConvertToPoint(string value, ILContext context, BaseNode node)
        {
            var module = context.Body.Method.Module;

            switch (value)
            {
                case "Top":
                    return GenerateIL(module, 0.0);
                case "Bottom":
                    return GenerateIL(module, 1.0);
                case "Left":
                    return GenerateIL(module, 0.0);
                case "Right":
                    return GenerateIL(module, 1.0);
                case "Middle":
                    return GenerateIL(module, 0.5);
                case "TopLeft":
                    return GenerateIL(module, 0.0, 0.0, 0.5);
                case "TopCenter":
                    return GenerateIL(module, 0.5, 0.0, 0.5);
                case "TopRight":
                    return GenerateIL(module, 1.0, 0.0, 0.5);
                case "CenterLeft":
                    return GenerateIL(module, 0.0, 0.5, 0.5);
                case "Center":
                    return GenerateIL(module, 0.5, 0.5, 0.5);
                case "CenterRight":
                    return GenerateIL(module, 1.0, 0.5, 0.5);
                case "BottomLeft":
                    return GenerateIL(module, 0.0, 1.0, 0.5);
                case "BottomCenter":
                    return GenerateIL(module, 0.5, 1.0, 0.5);
                case "BottomRight":
                    return GenerateIL(module, 1.0, 1.0, 0.5);
            }

            throw new XamlParseException($"Cannot convert \"{value}\" into Position", node);
        }

        public IEnumerable<Instruction> ConvertFromString(string value, ILContext context, BaseNode node)
        {
            var module = context.Body.Method.Module;

            var thickness = value.Split(',');

            foreach (var thick in thickness)
            {
                if (thick.EndsWith("dp") || thick.EndsWith("px"))
                {
                    return null;
                }
            }

            if (3 == thickness.Length)
            {
                double x, y, z;

                if (double.TryParse(thickness[0], NumberStyles.Number, CultureInfo.InvariantCulture, out x) &&
                            double.TryParse(thickness[1], NumberStyles.Number, CultureInfo.InvariantCulture, out y) &&
                            double.TryParse(thickness[2], NumberStyles.Number, CultureInfo.InvariantCulture, out z))
                    return GenerateIL(module, x, y, z);
            }
            else if (2 == thickness.Length)
            {
                double x, y;

                if (double.TryParse(thickness[0], NumberStyles.Number, CultureInfo.InvariantCulture, out x) &&
                            double.TryParse(thickness[1], NumberStyles.Number, CultureInfo.InvariantCulture, out y))
                    return GenerateIL(module, x, y, 0);
            }
            else if (1 == thickness.Length)
            {
                if (value.Contains("."))
                {
                    string[] parts = value.Split('.');
                    if (parts.Length == 2 && (parts[0].Trim() == "ParentOrigin" || parts[0].Trim() == "PivotPoint"))
                    {
                        string position = parts[parts.Length - 1].Trim();
                        return ConvertToPoint(position, context, node);
                    }
                }
                else
                {
                    return ConvertToPoint(value, context, node);
                }
            }

            throw new XamlParseException($"Cannot convert \"{value}\" into Position", node);
        }
    }

    internal class Position2DTypeConverter : ICompiledTypeConverter
    {
        IEnumerable<Instruction> GenerateIL(ModuleDefinition module, params int[] args)
        {
            foreach (var d in args)
                yield return Instruction.Create(OpCodes.Ldc_I4, d);

            yield return Instruction.Create(OpCodes.Newobj, module.ImportCtorReference((XamlTask.nuiAssemblyName, XamlTask.nuiNameSpace, "Position2D"),
                parameterTypes: args.Select(a => ("mscorlib", "System", "Int32")).ToArray()));
        }

        public IEnumerable<Instruction> ConvertFromString(string value, ILContext context, BaseNode node)
        {
            var module = context.Body.Method.Module;

            if (!string.IsNullOrEmpty(value))
            {
                int x, y;
                var thickness = value.Split(',');

                foreach (var thick in thickness)
                {
                    if (thick.EndsWith("dp") || thick.EndsWith("px"))
                    {
                        return null;
                    }
                }

                if (int.TryParse(thickness[0], NumberStyles.Number, CultureInfo.InvariantCulture, out x) &&
                    int.TryParse(thickness[1], NumberStyles.Number, CultureInfo.InvariantCulture, out y))
                    return GenerateIL(module, x, y);
            }

            throw new XamlParseException($"Cannot convert \"{value}\" into Position2D", node);
        }
    }
}
 
