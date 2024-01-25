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
using Tizen.NUI.Xaml;
using Tizen.NUI.Xaml.Build.Tasks;

namespace Tizen.NUI.Xaml.Core.XamlC
{
    class RectangleTypeConverter : ICompiledTypeConverter
    {
        public IEnumerable<Instruction> ConvertFromString(string value, ILContext context, BaseNode node)
        {
            var module = context.Body.Method.Module;

            if (string.IsNullOrEmpty(value))
                throw new XamlParseException($"Cannot convert \"{value}\" into Rectangle", node);
            double x, y, w, h;
            var xywh = value.Split(',');

            foreach (var thick in xywh)
            {
                if (null != NodeILExtensions.GetDPValueSubFix(thick))
                {
                    return null;
                }
            }

            if (xywh.Length != 4 ||
                !double.TryParse(xywh [0], NumberStyles.Number, CultureInfo.InvariantCulture, out x) ||
                !double.TryParse(xywh [1], NumberStyles.Number, CultureInfo.InvariantCulture, out y) ||
                !double.TryParse(xywh [2], NumberStyles.Number, CultureInfo.InvariantCulture, out w) ||
                !double.TryParse(xywh [3], NumberStyles.Number, CultureInfo.InvariantCulture, out h))
                throw new XamlParseException($"Cannot convert \"{value}\" into Rectangle", node);

            return GenerateIL(x, y, w, h, module);
        }

        IEnumerable<Instruction> GenerateIL(double x, double y, double w, double h, ModuleDefinition module)
        {
//            IL_0000:  ldc.r8 3.1000000000000001
//            IL_0009:  ldc.r8 4.2000000000000002
//            IL_0012:  ldc.r8 5.2999999999999998
//            IL_001b:  ldc.r8 6.4000000000000004
//            IL_0024:  newobj instance void valuetype Test.Rectangle::'.ctor'(int, int, int, int)

            yield return Instruction.Create(OpCodes.Ldc_I4, (int)x);
            yield return Instruction.Create(OpCodes.Ldc_I4, (int)y);
            yield return Instruction.Create(OpCodes.Ldc_I4, (int)w);
            yield return Instruction.Create(OpCodes.Ldc_I4, (int)h);
            yield return Instruction.Create(OpCodes.Newobj, module.ImportCtorReference((XamlTask.nuiAssemblyName, XamlTask.nuiNameSpace, "Rectangle"), parameterTypes: new[] {
                ("mscorlib", "System", "Int32"),
                ("mscorlib", "System", "Int32"),
                ("mscorlib", "System", "Int32"),
                ("mscorlib", "System", "Int32")}));
        }
    }
}
 
