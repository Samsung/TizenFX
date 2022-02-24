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
using System.Linq;
using System.Xml;

using Mono.Cecil;
using Mono.Cecil.Cil;
using Tizen.NUI.EXaml;
using Tizen.NUI.EXaml.Build.Tasks;
using Tizen.NUI.Xaml;

using static Mono.Cecil.Cil.Instruction;
using static Mono.Cecil.Cil.OpCodes;


namespace Tizen.NUI.Xaml.Build.Tasks
{
    class TypeExtension : ICompiledMarkupExtension
    {
        public IEnumerable<Instruction> ProvideValue(IElementNode node, ModuleDefinition module, ILContext context, out TypeReference memberRef)
        {
            memberRef = module.ImportReference(("mscorlib", "System", "Type"));
            INode typeNameNode;

            var name = new XmlName("", "TypeName");
            if (!node.Properties.TryGetValue(name, out typeNameNode) && node.CollectionItems.Any())
                typeNameNode = node.CollectionItems[0];

            var valueNode = typeNameNode as ValueNode;
            if (valueNode == null)
                throw new XamlParseException("TypeName isn't set.", node as XmlLineInfo);

            if (!node.Properties.ContainsKey(name))
            {
                node.Properties[name] = typeNameNode;
                node.CollectionItems.Clear();
            }

            var typeref = module.ImportReference(XmlTypeExtensions.GetTypeReference(valueNode.Value as string, module, node as BaseNode));

            context.TypeExtensions[node] = typeref ?? throw new XamlParseException($"Can't resolve type `{valueNode.Value}'.", node as IXmlLineInfo);

            return new List<Instruction> {
                Create(Ldtoken, module.ImportReference(typeref)),
                Create(Call, module.ImportMethodReference(("mscorlib", "System", "Type"),
                                                          methodName: "GetTypeFromHandle",
                                                          parameterTypes: new[] { ("mscorlib", "System", "RuntimeTypeHandle") },
                                                          isStatic: true)),
            };
        }

        public EXamlCreateObject ProvideValue(IElementNode node, ModuleDefinition module, EXamlContext context)
        {
            INode typeNameNode;

            var name = new XmlName("", "TypeName");
            if (!node.Properties.TryGetValue(name, out typeNameNode) && node.CollectionItems.Any())
                typeNameNode = node.CollectionItems[0];

            var valueNode = typeNameNode as ValueNode;
            if (valueNode == null)
                throw new XamlParseException("TypeName isn't set.", node as XmlLineInfo);

            if (!node.Properties.ContainsKey(name))
            {
                node.Properties[name] = typeNameNode;
                node.CollectionItems.Clear();
            }

            var typeref = module.ImportReference(XmlTypeExtensions.GetTypeReference(valueNode.Value as string, module, node as BaseNode));

            context.TypeExtensions[node] = typeref ?? throw new XamlParseException($"Can't resolve type `{valueNode.Value}'.", node as IXmlLineInfo);

            return new EXamlCreateObject(context, typeref, module.ImportReference(typeof(TypeReference)));
        }
    }
}
 
