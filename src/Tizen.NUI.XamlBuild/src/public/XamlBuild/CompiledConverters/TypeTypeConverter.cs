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
using System.Xml;

using Mono.Cecil.Cil;

using Tizen.NUI.Xaml.Build.Tasks;
using Tizen.NUI.Xaml;

using static Mono.Cecil.Cil.Instruction;
using static Mono.Cecil.Cil.OpCodes;

namespace Tizen.NUI.Xaml.Core.XamlC
{
    class TypeTypeConverter : ICompiledTypeConverter
    {
        public IEnumerable<Instruction> ConvertFromString(string value, ILContext context, BaseNode node)
        {
            var module = context.Body.Method.Module;

            if (string.IsNullOrEmpty(value))
                goto error;

            var split = value.Split(':');
            if (split.Length > 2)
                goto error;

            XmlType xmlType;
            if (split.Length == 2)
                xmlType = new XmlType(node.NamespaceResolver.LookupNamespace(split[0]), split[1], null);
            else
                xmlType = new XmlType(node.NamespaceResolver.LookupNamespace(""), split[0], null);

            var typeRef = xmlType.GetTypeReference(module, (IXmlLineInfo)node, true);
            if (typeRef == null)
                goto error;

            yield return Create(Ldtoken, module.ImportReference(typeRef));
            yield return Create(Call, module.ImportMethodReference(("mscorlib", "System", "Type"),
                                                                   methodName: "GetTypeFromHandle",
                                                                   parameterTypes: new[] { ("mscorlib", "System", "RuntimeTypeHandle") },
                                                                   isStatic: true));

            yield break;

        error:
            throw new XamlParseException($"Cannot convert \"{value}\" into {typeof(Type)}", node);
        }
    }
}
 
