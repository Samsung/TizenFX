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
using System;
using System.Collections.Generic;
using System.Linq;

using Mono.Cecil;
using Mono.Cecil.Cil;
using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;
using Tizen.NUI.Xaml.Build.Tasks;

namespace Tizen.NUI.Xaml.Core.XamlC
{
    class LayoutOptionsConverter : ICompiledTypeConverter
    {
        public IEnumerable<Instruction> ConvertFromString(string value, ILContext context, BaseNode node)
        {
            var module = context.Body.Method.Module;

            do {
                if (string.IsNullOrEmpty(value))
                    break;

                value = value.Trim();

                var parts = value.Split('.');
                if (parts.Length == 1 || (parts.Length == 2 && parts [0] == "LayoutOptions")) {
                    var options = parts [parts.Length - 1];

                    var fieldReference = module.ImportFieldReference((XamlTask.bindingAssemblyName, XamlTask.bindingNameSpace, "LayoutOptions"),
                                                                     fieldName: options,
                                                                     isStatic: true);
                    if (fieldReference != null) {
                        yield return Instruction.Create(OpCodes.Ldsfld, fieldReference);
                        yield break;
                    }
                }
            } while (false);

            throw new XamlParseException(String.Format("Cannot convert \"{0}\" into LayoutOptions", value), node);
        }
    }
}
 
