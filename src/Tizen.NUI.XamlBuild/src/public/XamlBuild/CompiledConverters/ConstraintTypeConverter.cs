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
 
