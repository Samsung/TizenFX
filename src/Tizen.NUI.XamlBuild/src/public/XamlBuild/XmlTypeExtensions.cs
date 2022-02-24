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
using Mono.Cecil.Rocks;
using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Xaml.Build.Tasks
{
    static class XmlTypeExtensions
    {
        static internal IList<XmlnsDefinitionAttribute> s_xmlnsDefinitions;

        static void GatherXmlnsDefinitionAttributes()
        {
            //this could be extended to look for [XmlnsDefinition] in all assemblies
            s_xmlnsDefinitions = XamlTask.s_xmlnsDefinitions.OrderByDescending(a => a.Level).ToList(); ;
        }

        public static TypeReference GetTypeReference(string xmlType, ModuleDefinition module, BaseNode node)
        {
            var split = xmlType.Split(':');
            if (split.Length > 2)
                throw new XamlParseException($"Type \"{xmlType}\" is invalid", node as IXmlLineInfo);

            string prefix, name;
            if (split.Length == 2) {
                prefix = split[0];
                name = split[1];
            } else {
                prefix = "";
                name = split[0];
            }
            var namespaceuri = node.NamespaceResolver.LookupNamespace(prefix) ?? "";
            return GetTypeReference(new XmlType(namespaceuri, name, null), module, node as IXmlLineInfo);
        }

        public static TypeReference GetTypeReference(string namespaceURI, string typename, ModuleDefinition module, IXmlLineInfo xmlInfo)
        {
            return new XmlType(namespaceURI, typename, null).GetTypeReference(module, xmlInfo);
        }

        public static TypeReference GetTypeReference(this XmlType xmlType, ModuleDefinition module, IXmlLineInfo xmlInfo, bool fromAllAssembly = false)
        {
            if (s_xmlnsDefinitions == null)
                GatherXmlnsDefinitionAttributes();

            var namespaceURI = xmlType.NamespaceUri;
            var elementName = xmlType.Name;
            var typeArguments = xmlType.TypeArguments;

            if (elementName.Contains("-"))
            {
                elementName = elementName.Replace('-', '+');
            }

            var lookupAssemblies = new List<XmlnsDefinitionAttribute>();

            var lookupNames = new List<string>();

            if (true == fromAllAssembly)
            {
                foreach (var xmlnsDef in s_xmlnsDefinitions)
                {
                    lookupAssemblies.Add(xmlnsDef);
                }
            }
            else
            {
                foreach (var xmlnsDef in s_xmlnsDefinitions)
                {
                    if (xmlnsDef.XmlNamespace != namespaceURI)
                        continue;
                    lookupAssemblies.Add(xmlnsDef);
                }
            }

            if (lookupAssemblies.Count == 0) {
                string ns;
                string typename;
                string asmstring;
                string targetPlatform;

                XmlnsHelper.ParseXmlns(namespaceURI, out typename, out ns, out asmstring, out targetPlatform);
                asmstring = asmstring ?? module.Assembly.Name.Name;
                if (ns != null)
                    lookupAssemblies.Add(new XmlnsDefinitionAttribute(namespaceURI, ns, 0) {
                        AssemblyName = asmstring
                    });
            }

            lookupNames.Add(elementName);
            lookupNames.Add(elementName + "Extension");

            for (var i = 0; i < lookupNames.Count; i++)
            {
                var name = lookupNames[i];
                if (name.Contains(":"))
                    name = name.Substring(name.LastIndexOf(':') + 1);
                if (typeArguments != null)
                    name += "`" + typeArguments.Count; //this will return an open generic Type
                lookupNames[i] = name;
            }

            TypeReference type = null;
            foreach (var asm in lookupAssemblies)
            {
                if (type != null)
                    break;
                foreach (var name in lookupNames)
                {
                    if (type != null)
                        break;

                    var clrNamespace = asm.ClrNamespace;
                    var typeName = name.Replace('+', '/'); //Nested types
                    var idx = typeName.LastIndexOf('.');
                    if (idx >= 0) {
                        clrNamespace += '.' + typeName.Substring(0, typeName.LastIndexOf('.'));
                        typeName = typeName.Substring(typeName.LastIndexOf('.') + 1);
                    }
                    type = module.GetTypeDefinition((asm.AssemblyName, clrNamespace, typeName));
                }
            }

            if (type != null && typeArguments != null && type.HasGenericParameters)
            {
                type =
                    module.ImportReference(type)
                        .MakeGenericInstanceType(typeArguments.Select(x => GetTypeReference(x, module, xmlInfo)).ToArray());
            }

            if (type == null)
                throw new XamlParseException(string.Format("Type {0} not found in xmlns {1}", elementName, namespaceURI), xmlInfo);

            return module.ImportReference(type);
        }

        public static TypeReference GetTypeExtensionReference(this XmlType xmlType, ModuleDefinition module, IXmlLineInfo xmlInfo, bool fromAllAssembly = false)
        {
            if (s_xmlnsDefinitions == null)
                GatherXmlnsDefinitionAttributes();

            var namespaceURI = xmlType.NamespaceUri;
            var elementName = xmlType.Name;
            var typeArguments = xmlType.TypeArguments;

            if (elementName.Contains("-"))
            {
                elementName = elementName.Replace('-', '+');
            }

            var lookupAssemblies = new List<XmlnsDefinitionAttribute>();

            var lookupNames = new List<string>();

            if (true == fromAllAssembly)
            {
                foreach (var xmlnsDef in s_xmlnsDefinitions)
                {
                    lookupAssemblies.Add(xmlnsDef);
                }
            }
            else
            {
                foreach (var xmlnsDef in s_xmlnsDefinitions)
                {
                    if (xmlnsDef.XmlNamespace != namespaceURI)
                        continue;
                    lookupAssemblies.Add(xmlnsDef);
                }
            }

            if (lookupAssemblies.Count == 0)
            {
                string ns;
                string typename;
                string asmstring;
                string targetPlatform;

                XmlnsHelper.ParseXmlns(namespaceURI, out typename, out ns, out asmstring, out targetPlatform);
                asmstring = asmstring ?? module.Assembly.Name.Name;
                if (ns != null)
                    lookupAssemblies.Add(new XmlnsDefinitionAttribute(namespaceURI, ns, 0)
                    {
                        AssemblyName = asmstring
                    });
            }

            lookupNames.Add(elementName + "Extension");

            for (var i = 0; i < lookupNames.Count; i++)
            {
                var name = lookupNames[i];
                if (name.Contains(":"))
                    name = name.Substring(name.LastIndexOf(':') + 1);
                if (typeArguments != null)
                    name += "`" + typeArguments.Count; //this will return an open generic Type
                lookupNames[i] = name;
            }

            TypeReference type = null;
            foreach (var asm in lookupAssemblies)
            {
                if (type != null)
                    break;
                foreach (var name in lookupNames)
                {
                    if (type != null)
                        break;

                    var clrNamespace = asm.ClrNamespace;
                    var typeName = name.Replace('+', '/'); //Nested types
                    var idx = typeName.LastIndexOf('.');
                    if (idx >= 0)
                    {
                        clrNamespace += '.' + typeName.Substring(0, typeName.LastIndexOf('.'));
                        typeName = typeName.Substring(typeName.LastIndexOf('.') + 1);
                    }
                    type = module.GetTypeDefinition((asm.AssemblyName, clrNamespace, typeName));

                    if (null == type)
                    {
                        type = module.GetTypeDefinition((module.Assembly.Name.Name, clrNamespace, typeName));
                    }
                }
            }

            if (type != null && typeArguments != null && type.HasGenericParameters)
            {
                type =
                    module.ImportReference(type)
                        .MakeGenericInstanceType(typeArguments.Select(x => GetTypeReference(x, module, xmlInfo)).ToArray());
            }

            if (type == null)
                throw new XamlParseException(string.Format("Type {0} not found in xmlns {1}", elementName, namespaceURI), xmlInfo);

            return module.ImportReference(type);
        }
    }
}
 
