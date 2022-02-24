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
using Mono.Cecil.Cil;

using Tizen.NUI.Xaml;

using static System.String;
using Tizen.NUI.Xaml.Build.Tasks;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Xaml.Core.XamlC
{
    class BindingTypeConverter : ICompiledTypeConverter
    {
        public IEnumerable<Instruction> ConvertFromString(string value, ILContext context, BaseNode node)
        {
            var module = context.Body.Method.Module;

            if (IsNullOrEmpty(value))
                throw new XamlParseException($"Cannot convert \"{value}\" into {typeof(Tizen.NUI.Binding.Binding)}", node);

            yield return Instruction.Create(OpCodes.Ldstr, value);
            yield return Instruction.Create(OpCodes.Ldc_I4, (int)BindingMode.Default);
            yield return Instruction.Create(OpCodes.Ldnull);
            yield return Instruction.Create(OpCodes.Ldnull);
            yield return Instruction.Create(OpCodes.Ldnull);
            yield return Instruction.Create(OpCodes.Ldnull);
            yield return Instruction.Create(OpCodes.Newobj, module.ImportCtorReference((XamlTask.bindingAssemblyName, XamlTask.bindingNameSpace, "Binding"), parameterTypes: new[] {
                ("mscorlib", "System", "String"),
                (XamlTask.bindingAssemblyName, XamlTask.bindingNameSpace, "BindingMode"),
                (XamlTask.bindingAssemblyName, XamlTask.bindingNameSpace, "IValueConverter"),
                ("mscorlib", "System", "Object"),
                ("mscorlib", "System", "String"),
                ("mscorlib", "System", "Object")}));
        }
    }
}
 
