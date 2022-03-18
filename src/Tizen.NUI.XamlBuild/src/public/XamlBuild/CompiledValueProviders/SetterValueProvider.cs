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

using Mono.Cecil;
using Mono.Cecil.Cil;

using Tizen.NUI.Xaml;
using Tizen.NUI.Xaml.Build.Tasks;
using System.Xml;

namespace Tizen.NUI.Xaml.Core.XamlC
{
    class SetterValueProvider : ICompiledValueProvider
    {
        public IEnumerable<Instruction> ProvideValue(VariableDefinitionReference vardefref, ModuleDefinition module, BaseNode node, ILContext context)
        {
            INode valueNode = null;
            if (!((IElementNode)node).Properties.TryGetValue(new XmlName("", "Value"), out valueNode) &&
                !((IElementNode)node).Properties.TryGetValue(new XmlName(XamlParser.XFUri, "Value"), out valueNode) &&
                ((IElementNode)node).CollectionItems.Count == 1)
                valueNode = ((IElementNode)node).CollectionItems[0];

            var bpNode = ((ValueNode)((IElementNode)node).Properties[new XmlName("", "Property")]);
            var bpRef = BindablePropertyConverter.GetBindablePropertyFieldReference((string)bpNode.Value, module, bpNode);

            if (SetterValueIsCollection(bpRef, module, node, context))
                yield break;

            if (valueNode == null)
                throw new XamlParseException("Missing Value for Setter", (IXmlLineInfo)node);

            //if it's an elementNode, there's probably no need to convert it
            if (valueNode is IElementNode)
                yield break;

            var value = ((string)((ValueNode)valueNode).Value);

            //push the setter
            yield return Instruction.Create(OpCodes.Ldloc, vardefref.VariableDefinition);

            //push the value
            foreach (var instruction in ((ValueNode)valueNode).PushConvertedValue(context, bpRef, valueNode.PushServiceProvider(context, bpRef: bpRef), boxValueTypes: true, unboxValueTypes: false))
                yield return instruction;

            //set the value
            yield return Instruction.Create(OpCodes.Callvirt, module.ImportPropertySetterReference((XamlTask.bindingAssemblyName, XamlTask.bindingNameSpace, "Setter"), propertyName: "Value"));
        }

        static bool SetterValueIsCollection(FieldReference bindablePropertyReference, ModuleDefinition module, BaseNode node, ILContext context)
        {
            var items = (node as IElementNode)?.CollectionItems;

            if (items == null || items.Count <= 0)
                return false;

            // Is this a generic type ?
            var generic = bindablePropertyReference.GetBindablePropertyType(node, module) as GenericInstanceType;

            // With a single generic argument?
            if (generic?.GenericArguments.Count != 1)
                return false;

            // Is the generic argument assignable from this value?
            var genericType = generic.GenericArguments[0];

            if (!(items[0] is IElementNode firstItem))
                return false;

            return context.Variables[firstItem].VariableType.InheritsFromOrImplements(genericType);
        }
    }
}
 
