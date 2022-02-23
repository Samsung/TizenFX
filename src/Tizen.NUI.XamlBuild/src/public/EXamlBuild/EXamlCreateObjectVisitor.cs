/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
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
using System.Globalization;
using System.Linq;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Tizen.NUI.Xaml;
using System.Xml;

using static Mono.Cecil.Cil.Instruction;
using static Mono.Cecil.Cil.OpCodes;
using Tizen.NUI.Xaml.Build.Tasks;
using ArrayExtension = Tizen.NUI.Xaml.Build.Tasks.ArrayExtension;

namespace Tizen.NUI.EXaml.Build.Tasks
{
    class EXamlCreateObjectVisitor : IXamlNodeVisitor
    {
        public EXamlCreateObjectVisitor(EXamlContext context)
        {
            Context = context;
            Module = context.Module;
        }

        public EXamlContext Context { get; }

        ModuleDefinition Module { get; }

        public TreeVisitingMode VisitingMode => TreeVisitingMode.BottomUp;
        public bool StopOnDataTemplate => true;
        public bool StopOnResourceDictionary => false;
        public bool VisitNodeOnDataTemplate => false;
        public bool SkipChildren(INode node, INode parentNode) => false;

        public bool IsResourceDictionary(ElementNode node)
        {
            var parentVar = Context.Variables[(IElementNode)node];
            return parentVar.VariableType.FullName == "Tizen.NUI.Binding.ResourceDictionary"
                || parentVar.VariableType.Resolve().BaseType?.FullName == "Tizen.NUI.Binding.ResourceDictionary";
        }

        public void Visit(ValueNode node, INode parentNode)
        {
            Context.Values[node] = node.Value;
        }

        public void Visit(MarkupNode node, INode parentNode)
        {
            //At this point, all MarkupNodes are expanded to ElementNodes
        }

        public void Visit(ElementNode node, INode parentNode)
        {
            var typeref = Module.ImportReference(node.XmlType.GetTypeReference(Module, node));

            if (IsXaml2009LanguagePrimitive(node))
            {
                var vardef = new VariableDefinition(typeref);
                Context.Variables[node] = vardef;

                var value = GetValueFromLanguagePrimitive(typeref, node);

                Context.Values[node] = value;
                return;
            }

            TypeDefinition typedef = typeref.ResolveCached();

            //if this is a MarkupExtension that can be compiled directly, compile and returns the value
            var compiledMarkupExtensionName = typeref
                .GetCustomAttribute(Module, (XamlTask.xamlAssemblyName, XamlTask.xamlNameSpace, "ProvideCompiledAttribute"))
                ?.ConstructorArguments?[0].Value as string;
            Type compiledMarkupExtensionType;
            ICompiledMarkupExtension markupProvider;
            if (compiledMarkupExtensionName != null &&
                (compiledMarkupExtensionType = Type.GetType(compiledMarkupExtensionName)) != null &&
                (markupProvider = Activator.CreateInstance(compiledMarkupExtensionType) as ICompiledMarkupExtension) != null)
            {

                Context.Values[node] = markupProvider.ProvideValue(node, Module, Context);

                VariableDefinition vardef = new VariableDefinition(typeref);
                Context.Variables[node] = vardef;

                //clean the node as it has been fully exhausted
                foreach (var prop in node.Properties)
                    if (!node.SkipProperties.Contains(prop.Key))
                        node.SkipProperties.Add(prop.Key);
                node.CollectionItems.Clear();
                return;
            }

            MethodDefinition factoryCtorInfo = null;
            MethodDefinition factoryMethodInfo = null;
            MethodDefinition parameterizedCtorInfo = null;
            MethodDefinition ctorInfo = null;

            if (node.Properties.ContainsKey(XmlName.xArguments) && !node.Properties.ContainsKey(XmlName.xFactoryMethod))
            {
                factoryCtorInfo = typedef.AllMethods().FirstOrDefault(md => md.IsConstructor &&
                                                                            !md.IsStatic &&
                                                                            md.HasParameters &&
                                                                            md.MatchXArguments(node, typeref, Module, Context));
                if (factoryCtorInfo == null)
                {
                    throw new XamlParseException(
                        string.Format("No constructors found for {0} with matching x:Arguments", typedef.FullName), node);
                }
                ctorInfo = factoryCtorInfo;
                if (!typedef.IsValueType) //for ctor'ing typedefs, we first have to ldloca before the params
                {
                    VariableDefinition vardef = new VariableDefinition(typeref);
                    Context.Variables[node] = vardef;

                    var argumentList = GetCtorXArguments(node, factoryCtorInfo.Parameters.Count);
                    Context.Values[node] = new EXamlCreateObject(Context, null, typedef, argumentList.ToArray());
                    return;
                }
            }
            else if (node.Properties.ContainsKey(XmlName.xFactoryMethod))
            {
                var factoryMethod = (string)(node.Properties[XmlName.xFactoryMethod] as ValueNode).Value;
                factoryMethodInfo = typedef.AllMethods().FirstOrDefault(md => !md.IsConstructor &&
                                                                              md.Name == factoryMethod &&
                                                                              md.IsStatic &&
                                                                              md.MatchXArguments(node, typeref, Module, Context));

                if (factoryMethodInfo == null)
                {
                    var typeExtensionRef = Module.ImportReference(node.XmlType.GetTypeExtensionReference(Module, node));
                    typeExtensionRef = typeExtensionRef?.ResolveCached();

                    if (null != typeExtensionRef)
                    {
                        factoryMethodInfo = typeExtensionRef.ResolveCached().AllMethods().FirstOrDefault(md => !md.IsConstructor &&
                                                                              md.Name == factoryMethod &&
                                                                              md.IsStatic &&
                                                                              md.MatchXArguments(node, typeExtensionRef, Module, Context));
                    }
                }

                if (factoryMethodInfo == null)
                {
                    throw new XamlParseException(
                        String.Format("No static method found for {0}::{1} ({2})", typedef.FullName, factoryMethod, null), node);
                }

                VariableDefinition vardef = new VariableDefinition(typeref);
                Context.Variables[node] = vardef;

                var argumentList = GetCtorXArguments(node, factoryMethodInfo.Parameters.Count);
                Context.Values[node] = new EXamlCreateObject(Context, null, typedef, factoryMethodInfo, argumentList?.ToArray());
                return;
            }

            if (ctorInfo == null && factoryMethodInfo == null)
            {
                parameterizedCtorInfo = typedef.Methods.FirstOrDefault(md => md.IsConstructor &&
                                                                             !md.IsStatic &&
                                                                             md.HasParameters &&
                                                                             md.Parameters.All(
                                                                                 pd =>
                                                                                     pd.CustomAttributes.Any(
                                                                                         ca =>
                                                                                             ca.AttributeType.FullName ==
                                                                                             "Tizen.NUI.Binding.ParameterAttribute")));
            }
            string missingCtorParameter = null;
            List<object> parameterizedCtorParams = null;

            if (parameterizedCtorInfo != null && ValidateCtorArguments(parameterizedCtorInfo, node, out missingCtorParameter))
            {
                ctorInfo = parameterizedCtorInfo;
                parameterizedCtorParams = GetCtorArguments(parameterizedCtorInfo, node, Context);
                //Fang
                //IL_0000:  ldstr "foo"
                //Context.IL.Append(PushCtorArguments(parameterizedCtorInfo, node));
            }

            ctorInfo = ctorInfo ?? typedef.Methods.FirstOrDefault(md => md.IsConstructor && !md.HasParameters && !md.IsStatic);

            if (null == ctorInfo)
            {
                foreach (var method in typedef.Methods)
                {
                    if (method.IsConstructor && !method.IsStatic)
                    {
                        bool areAllParamsDefault = true;

                        foreach (var param in method.Parameters)
                        {
                            if (!param.HasDefault)
                            {
                                areAllParamsDefault = false;
                                break;
                            }
                        }

                        if (areAllParamsDefault)
                        {
                            if (null == ctorInfo)
                            {
                                ctorInfo = method;
                            }
                            else
                            {
                                throw new XamlParseException($"{typedef.FullName} has more than one constructor which params are all default.", node);
                            }
                        }
                    }
                }

                if (null == ctorInfo && !typedef.IsValueType)
                {
                    throw new XamlParseException($"{typedef.FullName} has no constructor which params are all default.", node);
                }
            }

            if (parameterizedCtorInfo != null && ctorInfo == null)
                //there was a parameterized ctor, we didn't use it
                throw new XamlParseException($"The Property '{missingCtorParameter}' is required to create a '{typedef.FullName}' object.", node);
            var ctorinforef = ctorInfo?.ResolveGenericParameters(typeref, Module);

            var factorymethodinforef = factoryMethodInfo?.ResolveGenericParameters(typeref, Module);
            var implicitOperatorref = typedef.Methods.FirstOrDefault(md =>
                md.IsPublic &&
                md.IsStatic &&
                md.IsSpecialName &&
                md.Name == "op_Implicit" && md.Parameters[0].ParameterType.FullName == "System.String");

            if (ctorinforef != null || factorymethodinforef != null || typedef.IsValueType)
            {
                VariableDefinition vardef = new VariableDefinition(typeref);
                Context.Variables[node] = vardef;

                ValueNode vnode = null;
                if (node.CollectionItems.Count == 1 && (vnode = node.CollectionItems.First() as ValueNode) != null &&
                    vardef.VariableType.IsValueType)
                {
                    Context.Values[node] = vnode.GetBaseValue(Context, typeref);
                }
                else if (node.CollectionItems.Count == 1 && (vnode = node.CollectionItems.First() as ValueNode) != null &&
                           implicitOperatorref != null)
                {
                    var converterType = vnode.GetConverterType(new ICustomAttributeProvider[] { typeref.ResolveCached() });
                    if (null == converterType)
                    {
                        var realValue = vnode.GetBaseValue(Context, typeref);
                        Context.Values[node] = new EXamlCreateObject(Context, realValue, typeref);
                    }
                    else
                    {
                        var converterValue = new EXamlValueConverterFromString(Context, converterType.Resolve(), vnode.Value as string);
                        Context.Values[node] = new EXamlCreateObject(Context, converterValue, typeref);
                    }
                }
                else if (factorymethodinforef != null)
                {
                    //Fang
                    //Context.IL.Emit(OpCodes.Call, Module.ImportReference(factorymethodinforef));
                    //Context.IL.Emit(OpCodes.Stloc, vardef);
                }
                else if (!typedef.IsValueType)
                {
                    var ctor = Module.ImportReference(ctorinforef);
                    //IL_0001:  newobj instance void class [Tizen.NUI.Xaml.UIComponents]Tizen.NUI.Xaml.UIComponents.Button::'.ctor'()
                    //IL_0006:  stloc.0
                    //Context.IL.Emit(OpCodes.Newobj, ctor);
                    //Context.IL.Emit(OpCodes.Stloc, vardef);
                    if (typeref.FullName == "Tizen.NUI.Xaml.ArrayExtension")
                    {
                        typeref = Module.ImportReference(typeof(ArrayExtension));
                        typedef = typeref.ResolveCached();
                    }

                    var accordingType = this.GetType().Assembly.GetType(typedef.FullName);

                    if (null != accordingType && accordingType != typeof(Binding.Setter))
                    {
                        Context.Values[node] = new EXamlCreateObject(Context, Activator.CreateInstance(accordingType), typeref);
                    }
                    else if (null != parameterizedCtorParams)
                    {
                        Context.Values[node] = new EXamlCreateObject(Context, null, typeref, parameterizedCtorParams.ToArray());
                    }
                    else
                    {
                        bool canConvertCollectionItem = false;

                        if (!typeref.InheritsFromOrImplements(Context.Module.ImportReference(typeof(List<string>)).Resolve())
                            &&
                            node.CollectionItems.Count == 1 && (vnode = node.CollectionItems.First() as ValueNode) != null)
                        {
                            var valueNode = node.CollectionItems.First() as ValueNode;

                            if (valueNode.CanConvertValue(Context.Module, typeref, (TypeReference)null))
                            {
                                var converterType = valueNode.GetConverterType(new ICustomAttributeProvider[] { typeref.Resolve() });
                                if (null != converterType)
                                {
                                    var converterValue = new EXamlValueConverterFromString(Context, converterType.Resolve(), valueNode.Value as string);
                                    Context.Values[node] = new EXamlCreateObject(Context, converterValue, typeref);
                                }
                                else
                                {
                                    var valueItem = valueNode.GetBaseValue(Context, typeref);
                                    if (null == valueItem)
                                    {
                                        throw new XamlParseException($"Can't convert collection item \"{vnode.Value}\" to object", node);
                                    }

                                    Context.Values[node] = valueItem;
                                }

                                canConvertCollectionItem = true;
                            }
                        }

                        if (false == canConvertCollectionItem)
                        {
                            if (!ctorInfo.HasParameters)
                            {
                                Context.Values[node] = new EXamlCreateObject(Context, null, typeref);
                            }
                            else
                            {
                                object[] @params = new object[ctorInfo.Parameters.Count];

                                for (int i = 0; i < ctorInfo.Parameters.Count; i++)
                                {
                                    var param = ctorInfo.Parameters[i];

                                    if (ctorInfo.Parameters[i].ParameterType.ResolveCached().IsEnum)
                                    {
                                        @params[i] = NodeILExtensions.GetParsedEnum(Context, param.ParameterType, param.Constant.ToString());
                                    }
                                    else
                                    {
                                        @params[i] = param.Constant;
                                    }
                                }

                                Context.Values[node] = new EXamlCreateObject(Context, null, typeref, @params);
                            }
                        }
                    }
                }
                else if (ctorInfo != null && node.Properties.ContainsKey(XmlName.xArguments) &&
                         !node.Properties.ContainsKey(XmlName.xFactoryMethod) && ctorInfo.MatchXArguments(node, typeref, Module, Context))
                {
                    //IL_0008:  ldloca.s 1
                    //IL_000a:  ldc.i4.1 
                    //IL_000b:  call instance void valuetype Test/Foo::'.ctor'(bool)

                    //Fang
                    //var ctor = Module.ImportReference(ctorinforef);
                    //Context.IL.Emit(OpCodes.Ldloca, vardef);
                    //Context.IL.Append(PushCtorXArguments(factoryCtorInfo, node));
                    //Context.IL.Emit(OpCodes.Call, ctor);
                }
                else
                {
                    //IL_0000:  ldloca.s 0
                    //IL_0002:  initobj Test/Foo
                    //Fang
                    //Context.IL.Emit(OpCodes.Ldloca, vardef);
                    //Context.IL.Emit(OpCodes.Initobj, Module.ImportReference(typedef));
                }

                if (typeref.FullName == "Tizen.NUI.Xaml.ArrayExtension")
                {
                    //Fang
                    //var visitor = new SetPropertiesVisitor(Context);
                    //foreach (var cnode in node.Properties.Values.ToList())
                    //    cnode.Accept(visitor, node);
                    //foreach (var cnode in node.CollectionItems)
                    //    cnode.Accept(visitor, node);

                    //markupProvider = new ArrayExtension();

                    //var il = markupProvider.ProvideValue(node, Module, Context, out typeref);

                    //vardef = new VariableDefinition(typeref);
                    //Context.Variables[node] = vardef;
                    //Context.Body.Variables.Add(vardef);

                    //Context.IL.Append(il);
                    //Context.IL.Emit(OpCodes.Stloc, vardef);

                    ////clean the node as it has been fully exhausted
                    //foreach (var prop in node.Properties)
                    //    if (!node.SkipProperties.Contains(prop.Key))
                    //        node.SkipProperties.Add(prop.Key);
                    //node.CollectionItems.Clear();

                    return;
                }
            }
        }

        public void Visit(RootNode node, INode parentNode)
        {
            //IL_0013:  ldarg.0 
            //IL_0014:  stloc.3 

            var ilnode = (ILRootNode)node;
            var typeref = ilnode.TypeReference;
            var vardef = new VariableDefinition(typeref);
            Context.Variables[node] = vardef;
            Context.Root = vardef;
            Context.RootNode = node;
            //Context.IL.Emit(OpCodes.Ldarg_0);
            //Context.IL.Emit(OpCodes.Stloc, vardef);
        }

        public void Visit(ListNode node, INode parentNode)
        {
            XmlName name;
            if (EXamlSetPropertiesVisitor.TryGetPropertyName(node, parentNode, out name))
                node.XmlName = name;
        }

        bool ValidateCtorArguments(MethodDefinition ctorinfo, ElementNode enode, out string firstMissingProperty)
        {
            firstMissingProperty = null;
            foreach (var parameter in ctorinfo.Parameters)
            {
                var propname =
                    parameter.CustomAttributes.First(ca => ca.AttributeType.FullName == "Tizen.NUI.Binding.ParameterAttribute")
                        .ConstructorArguments.First()
                        .Value as string;
                if (!enode.Properties.ContainsKey(new XmlName("", propname)))
                {
                    firstMissingProperty = propname;
                    return false;
                }
            }
            return true;
        }

        List<object> GetCtorXArguments(ElementNode enode, int paramsCount)
        {
            if (!enode.Properties.ContainsKey(XmlName.xArguments))
            {
                return null;
            }

            List<object> argumentList = new List<object>();

            var arguments = new List<INode>();
            var node = enode.Properties[XmlName.xArguments] as ElementNode;
            if (node != null)
            {
                node.Accept(new EXamlSetPropertiesVisitor(Context, true), null);
                arguments.Add(node);
            }

            var list = enode.Properties[XmlName.xArguments] as ListNode;
            if (list != null)
            {
                foreach (var n in list.CollectionItems)
                    arguments.Add(n);
            }

            for (int i = 0; i < arguments.Count; i++)
            {
                argumentList.Add(Context.Values[arguments[i]]);
            }

            for (int i = arguments.Count; i < paramsCount; i++)
            {
                argumentList.Add(null);
            }

            return argumentList;
        }

        static bool IsXaml2009LanguagePrimitive(IElementNode node)
        {
            if (node.NamespaceURI == XamlParser.X2009Uri)
            {
                var n = node.XmlType.Name.Split(':')[1];
                return n != "Array";
            }
            if (node.NamespaceURI != "clr-namespace:System;assembly=mscorlib")
                return false;
            var name = node.XmlType.Name.Split(':')[1];
            if (name == "SByte" ||
                name == "Int16" ||
                name == "Int32" ||
                name == "Int64" ||
                name == "Byte" ||
                name == "UInt16" ||
                name == "UInt32" ||
                name == "UInt64" ||
                name == "Single" ||
                name == "Double" ||
                name == "Boolean" ||
                name == "String" ||
                name == "Char" ||
                name == "Decimal" ||
                name == "TimeSpan" ||
                name == "Uri")
                return true;
            return false;
        }

        object GetValueFromLanguagePrimitive(TypeReference typeRef, ElementNode node)
        {
            var module = Context.Module;
            var hasValue = node.CollectionItems.Count == 1 && node.CollectionItems[0] is ValueNode &&
                           ((ValueNode)node.CollectionItems[0]).Value is string;
            var valueString = hasValue ? ((ValueNode)node.CollectionItems[0]).Value as string : string.Empty;
            object ret = null;

            TypeDefinition typedef = typeRef.ResolveCached();

            switch (typedef.FullName)
            {
                case "System.SByte":
                    if (hasValue && sbyte.TryParse(valueString, NumberStyles.Number, CultureInfo.InvariantCulture, out sbyte outsbyte))
                        ret = outsbyte;
                    else
                        ret = 0;
                    break;
                case "System.Int16":
                    if (hasValue && short.TryParse(valueString, NumberStyles.Number, CultureInfo.InvariantCulture, out short outshort))
                        ret = outshort;
                    else
                        ret = 0;
                    break;
                case "System.Int32":
                    if (hasValue && int.TryParse(valueString, NumberStyles.Number, CultureInfo.InvariantCulture, out int outint))
                        ret = outint;
                    else
                        ret = 0;
                    break;
                case "System.Int64":
                    if (hasValue && long.TryParse(valueString, NumberStyles.Number, CultureInfo.InvariantCulture, out long outlong))
                        ret = outlong;
                    else
                        ret = 0;
                    break;
                case "System.Byte":
                    if (hasValue && byte.TryParse(valueString, NumberStyles.Number, CultureInfo.InvariantCulture, out byte outbyte))
                        ret = outbyte;
                    else
                        ret = 0;
                    break;
                case "System.UInt16":
                    if (hasValue && short.TryParse(valueString, NumberStyles.Number, CultureInfo.InvariantCulture, out short outushort))
                        ret = outushort;
                    else
                        ret = 0;
                    break;
                case "System.UInt32":
                    if (hasValue && uint.TryParse(valueString, NumberStyles.Number, CultureInfo.InvariantCulture, out uint outuint))
                        ret = outuint;
                    else
                        ret = 0;
                    break;
                case "System.UInt64":
                    if (hasValue && long.TryParse(valueString, NumberStyles.Number, CultureInfo.InvariantCulture, out long outulong))
                        ret = outulong;
                    else
                        ret = 0;
                    break;
                case "System.Boolean":
                    if (hasValue && bool.TryParse(valueString, out bool outbool))
                        ret = true;
                    else
                        ret = false;
                    break;
                case "System.String":
                    ret = valueString;
                    break;
                case "System.Object":
                    var ctorinfo =
                        module.TypeSystem.Object.ResolveCached()
                            .Methods.FirstOrDefault(md => md.IsConstructor && !md.HasParameters);
                    var ctor = module.ImportReference(ctorinfo);
                    ret = Create(Newobj, ctor);
                    break;
                case "System.Char":
                    if (hasValue && char.TryParse(valueString, out char outchar))
                        ret = outchar;
                    else
                        ret = (char)0;
                    break;
                case "System.Decimal":
                    decimal outdecimal;
                    if (hasValue && decimal.TryParse(valueString, NumberStyles.Number, CultureInfo.InvariantCulture, out outdecimal))
                    {
                        ret = outdecimal;
                    }
                    else
                    {
                        ret = (decimal)0;
                    }
                    break;
                case "System.Single":
                    if (hasValue && float.TryParse(valueString, NumberStyles.Number, CultureInfo.InvariantCulture, out float outfloat))
                        ret = outfloat;
                    else
                        ret = 0f;
                    break;
                case "System.Double":
                    if (hasValue && double.TryParse(valueString, NumberStyles.Number, CultureInfo.InvariantCulture, out double outdouble))
                        ret = outdouble;
                    else
                        ret = 0d;
                    break;
                case "System.TimeSpan":
                    if (hasValue && TimeSpan.TryParse(valueString, CultureInfo.InvariantCulture, out TimeSpan outspan))
                    {

                        ret = outspan;
                    }
                    else
                    {
                        ret = null;
                    }
                    break;
                case "System.Uri":
                    if (hasValue && Uri.TryCreate(valueString, UriKind.RelativeOrAbsolute, out Uri outuri))
                    {
                        ret = outuri;
                    }
                    else
                    {
                        ret = null;
                    };
                    break;
                default:
                    ret = new EXamlCreateObject(Context, null, typeRef);
                    break;
            }

            return ret;
        }

        List<object> GetCtorArguments(MethodDefinition ctorinfo, ElementNode enode, EXamlContext context)
        {
            List<object> ret = null;

            foreach (var parameter in ctorinfo.Parameters)
            {
                var propname =
                    parameter.CustomAttributes.First(ca => ca.AttributeType.FullName == "Tizen.NUI.Binding.ParameterAttribute")
                        .ConstructorArguments.First()
                        .Value as string;
                var node = enode.Properties[new XmlName("", propname)];
                if (!enode.SkipProperties.Contains(new XmlName("", propname)))
                    enode.SkipProperties.Add(new XmlName("", propname));

                if (node is ValueNode valueNode)
                {
                    var valueType = parameter.ParameterType;

                    if ("System.Type" == valueType.FullName)
                    {
                        var typeRef = XmlTypeExtensions.GetTypeReference(valueNode.Value as string, Module, node as BaseNode);
                        context.Values[node] = new EXamlCreateObject(context, typeRef);
                    }
                    else
                    {
                        var converterType = valueNode.GetConverterType(new ICustomAttributeProvider[] { parameter, parameter.ParameterType.ResolveCached() });

                        if (null != converterType)
                        {
                            var converterValue = new EXamlValueConverterFromString(context, converterType.Resolve(), valueNode.Value as string);
                            context.Values[node] = new EXamlCreateObject(context, converterValue, valueType);
                        }
                        else
                        {
                            context.Values[node] = valueNode.GetBaseValue(context, valueType);
                        }
                    }

                    if (null == ret)
                    {
                        ret = new List<object>();
                    }

                    ret.Add(context.Values[node]);
                }
            }

            return ret;
        }
    }
}
