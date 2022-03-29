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

using static Mono.Cecil.Cil.Instruction;
using static Mono.Cecil.Cil.OpCodes;

using Tizen.NUI.Xaml.Build.Tasks;
using Tizen.NUI.Xaml;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Xaml.Core.XamlC
{
    class RDSourceTypeConverter : ICompiledTypeConverter
    {
        public IEnumerable<Instruction> ConvertFromString(string value, ILContext context, BaseNode node)
        {
            var module = context.Body.Method.Module;
            var body = context.Body;

            INode rootNode = node;
            while (!(rootNode is ILRootNode))
                rootNode = rootNode.Parent;

            var rdNode = node.Parent as IElementNode;

            var rootTargetPath = XamlTask.GetPathForType(module, ((ILRootNode)rootNode).TypeReference);
            var uri = new Uri(value, UriKind.Relative);

            var resourcePath = ResourceDictionary.RDSourceTypeConverter.GetResourcePath(uri, rootTargetPath);

            //fail early
            var resourceId = XamlTask.GetResourceIdForPath(module, resourcePath);
            if (resourceId == null)
                throw new XamlParseException($"Resource '{value}' not found.", node);


            //abuse the converter, produce some side effect, but leave the stack untouched
            //public void SetAndLoadSource(Uri value, string resourceID, Assembly assembly, System.Xml.IXmlLineInfo lineInfo)
            yield return Create(Ldloc, context.Variables[rdNode]); //the resourcedictionary
            foreach (var instruction in (new UriTypeConverter()).ConvertFromString(value, context, node))
                yield return instruction; //the Uri

            //keep the Uri for later
            yield return Create(Dup);
            var uriVarDef = new VariableDefinition(module.ImportReference(("System", "System", "Uri")));
            body.Variables.Add(uriVarDef);
            yield return Create(Stloc, uriVarDef);
            yield return Create(Ldstr, resourcePath); //resourcePath
            yield return Create(Ldtoken, module.ImportReference(((ILRootNode)rootNode).TypeReference));
            yield return Create(Call, module.ImportMethodReference(("mscorlib", "System", "Type"), methodName: "GetTypeFromHandle", parameterTypes: new[] { ("mscorlib", "System", "RuntimeTypeHandle") }, isStatic: true));
            yield return Create(Call, module.ImportMethodReference(("mscorlib", "System.Reflection", "IntrospectionExtensions"), methodName: "GetTypeInfo", parameterTypes: new[] { ("mscorlib", "System", "Type") }, isStatic: true));
            yield return Create(Callvirt, module.ImportPropertyGetterReference(("mscorlib", "System.Reflection", "TypeInfo"), propertyName: "Assembly", flatten: true));

            foreach (var instruction in node.PushXmlLineInfo(context))
                yield return instruction; //lineinfo
            yield return Create(Callvirt, module.ImportMethodReference((XamlTask.bindingAssemblyName, XamlTask.bindingNameSpace, "ResourceDictionary"),
                                                                       methodName: "SetAndLoadSource",
                                                                       parameterTypes: new[] { ("System", "System", "Uri"), ("mscorlib", "System", "String"), ("mscorlib", "System.Reflection", "Assembly"), ("System.Xml.ReaderWriter", "System.Xml", "IXmlLineInfo") }));
            //ldloc the stored uri as return value
            yield return Create(Ldloc, uriVarDef);
        }

        internal static string GetPathForType(ModuleDefinition module, TypeReference type)
        {
            foreach (var ca in type.Module.GetCustomAttributes()) {
                if (!TypeRefComparer.Default.Equals(ca.AttributeType, module.ImportReference((XamlTask.xamlAssemblyName, XamlTask.xamlNameSpace, "XamlResourceIdAttribute"))))
                    continue;
                if (!TypeRefComparer.Default.Equals(ca.ConstructorArguments[2].Value as TypeReference, type))
                    continue;
                return ca.ConstructorArguments[1].Value as string;
            }
            return null;
        }
    }
}
 
