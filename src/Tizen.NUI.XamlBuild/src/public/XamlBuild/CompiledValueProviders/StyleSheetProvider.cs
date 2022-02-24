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

using Mono.Cecil;
using Mono.Cecil.Cil;

using Tizen.NUI.Xaml.Build.Tasks;
using Tizen.NUI.Xaml;

using static Mono.Cecil.Cil.Instruction;
using static Mono.Cecil.Cil.OpCodes;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Xaml.Core.XamlC
{
    class StyleSheetProvider : ICompiledValueProvider
    {
        public IEnumerable<Instruction> ProvideValue(VariableDefinitionReference vardefref, ModuleDefinition module, BaseNode node, ILContext context)
        {
            INode sourceNode = null;
            ((IElementNode)node).Properties.TryGetValue(new XmlName("", "Source"), out sourceNode);
            if (sourceNode == null)
                ((IElementNode)node).Properties.TryGetValue(new XmlName(XamlParser.XFUri, "Source"), out sourceNode);

            INode styleNode = null;
            if (!((IElementNode)node).Properties.TryGetValue(new XmlName("", "Style"), out styleNode) &&
                !((IElementNode)node).Properties.TryGetValue(new XmlName(XamlParser.XFUri, "Style"), out styleNode) &&
                ((IElementNode)node).CollectionItems.Count == 1)
                styleNode = ((IElementNode)node).CollectionItems[0];

            if (sourceNode != null && styleNode != null)
                throw new XamlParseException("StyleSheet can not have both a Source and a content", node);

            if (sourceNode == null && styleNode == null)
                throw new XamlParseException("StyleSheet require either a Source or a content", node);

            if (styleNode != null && !(styleNode is ValueNode))
                throw new XamlParseException("Style property or Content is not a string literal", node);

            if (sourceNode != null && !(sourceNode is ValueNode))
                throw new XamlParseException("Source property is not a string literal", node);

            if (styleNode != null) {
                var style = (styleNode as ValueNode).Value as string;
                yield return Create(Ldstr, style);
                yield return Create(Call, module.ImportMethodReference((XamlTask.xamlAssemblyName, "Tizen.NUI.StyleSheets", "StyleSheet"),
                                                                       methodName: "FromString",
                                                                       parameterTypes: new[] { ("mscorlib", "System", "String") },
                                                                       isStatic: true));
            }
            else {
                var source = (sourceNode as ValueNode)?.Value as string;
                INode rootNode = node;
                while (!(rootNode is ILRootNode))
                    rootNode = rootNode.Parent;

                var rootTargetPath = RDSourceTypeConverter.GetPathForType(module, ((ILRootNode)rootNode).TypeReference);
                var uri = new Uri(source, UriKind.Relative);

                var resourcePath = ResourceDictionary.RDSourceTypeConverter.GetResourcePath(uri, rootTargetPath);
                //fail early
                var resourceId = XamlTask.GetResourceIdForPath(module, resourcePath);
                if (resourceId == null)
                    throw new XamlParseException($"Resource '{source}' not found.", node);

                yield return Create(Ldtoken, module.ImportReference(((ILRootNode)rootNode).TypeReference));
                yield return Create(Call, module.ImportMethodReference(("mscorlib", "System", "Type"), methodName: "GetTypeFromHandle", parameterTypes: new[] { ("mscorlib", "System", "RuntimeTypeHandle") }, isStatic: true));
                yield return Create(Call, module.ImportMethodReference(("mscorlib", "System.Reflection", "IntrospectionExtensions"), methodName: "GetTypeInfo", parameterTypes: new[] { ("mscorlib", "System", "Type") }, isStatic: true));
                yield return Create(Callvirt, module.ImportPropertyGetterReference(("mscorlib", "System.Reflection", "TypeInfo"), propertyName: "Assembly", flatten: true));

                yield return Create(Ldstr, resourceId); //resourceId

                foreach (var instruction in node.PushXmlLineInfo(context))
                    yield return instruction; //lineinfo

                yield return Create(Call, module.ImportMethodReference((XamlTask.xamlAssemblyName, "Tizen.NUI.StyleSheets", "StyleSheet"),
                                                                       methodName: "FromAssemblyResource",
                                                                       parameterTypes: new[] { ("mscorlib", "System.Reflection", "Assembly"), ("mscorlib", "System", "String"), ("System.Xml.ReaderWriter", "System.Xml", "IXmlLineInfo") },
                                                                       isStatic: true));
            }

            //the variable is of type `object`. fix that
            var vardef = new VariableDefinition(module.ImportReference((XamlTask.xamlAssemblyName, "Tizen.NUI.StyleSheets", "StyleSheet")));
            yield return Create(Stloc, vardef);
            vardefref.VariableDefinition = vardef;
        }
    }
}
 
