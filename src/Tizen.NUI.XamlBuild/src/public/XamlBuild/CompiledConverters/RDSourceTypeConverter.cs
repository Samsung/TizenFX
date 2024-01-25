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
using System.Linq;

namespace Tizen.NUI.Xaml.Core.XamlC
{
    class RDSourceTypeConverter : ICompiledTypeConverter
    {
        public IEnumerable<Instruction> ConvertFromString(string value, ILContext context, BaseNode node)
        {
            var module = context.Module;

            EmbeddedResource matchedResource = null;

            foreach (var resource in module.Resources.OfType<EmbeddedResource>())
            {
                if (resource.Name.StartsWith(context.EmbeddedResourceNameSpace) && resource.Name.EndsWith(value))
                {
                    matchedResource = resource;
                    break;
                }
            }

            if (null == matchedResource)
            {
                foreach (var resource in module.Resources.OfType<EmbeddedResource>())
                {
                    if (resource.Name.EndsWith(value))
                    {
                        matchedResource = resource;
                        break;
                    }
                }
            }

            if (null != matchedResource)
            {
                string classname;
                if (matchedResource.IsResourceDictionaryXaml(module, out classname))
                {
                    int lastIndex = classname.LastIndexOf('.');
                    var realClassName = classname.Substring(lastIndex + 1);
                    var typeref = XmlTypeExtensions.GetTypeReference(realClassName, module, node, XmlTypeExtensions.ModeOfGetType.Both);

                    var typeName = matchedResource.Name.Replace('.', '_');
                    var typeDefOfGetResource = module.Types.FirstOrDefault(type => type.FullName == "GetResource." + typeName);
                    if (null != typeDefOfGetResource)
                    {
                        module.Types.Remove(typeDefOfGetResource);
                        typeDefOfGetResource = null;
                    }

                    if (null == typeDefOfGetResource)
                    {
                        typeDefOfGetResource = new TypeDefinition("GetResource", typeName, TypeAttributes.NotPublic);
                        typeDefOfGetResource.BaseType = typeref;
                        module.Types.Add(typeDefOfGetResource);

                        typeDefOfGetResource.AddDefaultConstructor(typeref);
                    }

                    var methodName = "GetResource";
                    var methodOfGetResource = typeDefOfGetResource.Methods.FirstOrDefault(m => m.Name == methodName);

                    if (null == methodOfGetResource)
                    {
                        methodOfGetResource = new MethodDefinition(methodName, MethodAttributes.Public, typeref);
                        typeDefOfGetResource.Methods.Add(methodOfGetResource);
                    }

                    var constructor = typeDefOfGetResource.Methods.FirstOrDefault(m => m.IsConstructor);

                    if (null != constructor)
                    {
                        constructor.Body.Instructions.Insert(constructor.Body.Instructions.Count - 1, Instruction.Create(OpCodes.Ldarg_0));
                        constructor.Body.Instructions.Insert(constructor.Body.Instructions.Count - 1, Instruction.Create(OpCodes.Call, methodOfGetResource));
                        constructor.Body.Instructions.Insert(constructor.Body.Instructions.Count - 1, Instruction.Create(OpCodes.Pop));
                    }

                    var rootnode = XamlTask.ParseXaml(matchedResource.GetResourceStream(), typeref);

                    Exception exception;
                    TryCoreCompile(methodOfGetResource, rootnode, context.EmbeddedResourceNameSpace, out exception);

                    yield return Create(Newobj, constructor);
                }
            }
        }

        internal static string GetPathForType(ModuleDefinition module, TypeReference type)
        {
            foreach (var ca in type.Module.GetCustomAttributes())
            {
                if (!TypeRefComparer.Default.Equals(ca.AttributeType, module.ImportReference((XamlTask.xamlAssemblyName, XamlTask.xamlNameSpace, "XamlResourceIdAttribute"))))
                    continue;
                if (!TypeRefComparer.Default.Equals(ca.ConstructorArguments[2].Value as TypeReference, type))
                    continue;
                return ca.ConstructorArguments[1].Value as string;
            }
            return null;
        }

        private bool TryCoreCompile(MethodDefinition initComp, ILRootNode rootnode, string resourceName, out Exception exception)
        {
            try
            {
                var body = new MethodBody(initComp);
                var module = body.Method.Module;
                var type = initComp.DeclaringType;

                body.InitLocals = true;
                var il = body.GetILProcessor();
                il.Emit(OpCodes.Ldarg_0);
                var resourcePath = GetPathForType(module, type);

                il.Emit(Nop);

                List<Instruction> insOfAddEvent = new List<Instruction>();

                var visitorContext = new ILContext(il, body, insOfAddEvent, module, resourceName);

                rootnode.Accept(new XamlNodeVisitor((node, parent) => node.Parent = parent), null);
                rootnode.Accept(new Tizen.NUI.Xaml.Build.Tasks.ExpandMarkupsVisitor(visitorContext), null);
                rootnode.Accept(new PruneIgnoredNodesVisitor(), null);
                rootnode.Accept(new CreateObjectVisitor(visitorContext), null);

                rootnode.Accept(new SetNamescopesAndRegisterNamesVisitor(visitorContext), null);
                rootnode.Accept(new SetFieldVisitor(visitorContext), null);
                rootnode.Accept(new SetResourcesVisitor(visitorContext), null);
                rootnode.Accept(new SetPropertiesVisitor(visitorContext, true), null);

                il.Emit(Ret);
                initComp.Body = body;
                exception = null;
                return true;
            }
            catch (Exception e)
            {
                XamlParseException xamlParseException = e as XamlParseException;
                if (null != xamlParseException)
                {
                    XamlParseException ret = new XamlParseException(xamlParseException.Message, xamlParseException.XmlInfo, xamlParseException.InnerException);
                    exception = ret;
                }
                else
                {
                    exception = e;
                }

                return false;
            }
        }
    }
}

