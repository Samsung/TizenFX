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
using System.Xml;

using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Cecil.Rocks;
using Tizen.NUI.Binding;
using Tizen.NUI.Binding.Internals;

using Tizen.NUI.Xaml;

using static Mono.Cecil.Cil.Instruction;
using static Mono.Cecil.Cil.OpCodes;

namespace Tizen.NUI.Xaml.Build.Tasks
{
    class SetPropertiesVisitor : IXamlNodeVisitor
    {
        static int dtcount;
        static int typedBindingCount;

        static readonly IList<XmlName> skips = new List<XmlName>
        {
            XmlName.xKey,
            XmlName.xTypeArguments,
            XmlName.xArguments,
            XmlName.xFactoryMethod,
            XmlName.xName,
            XmlName.xDataType
        };

        public SetPropertiesVisitor(ILContext context, bool stopOnResourceDictionary = false)
        {
            Context = context;
            Module = context.Body.Method.Module;
            StopOnResourceDictionary = stopOnResourceDictionary;
        }

        public ILContext Context { get; }
        public bool StopOnResourceDictionary { get; }
        public TreeVisitingMode VisitingMode => TreeVisitingMode.BottomUp;
        public bool StopOnDataTemplate => true;
        public bool VisitNodeOnDataTemplate => true;
        public bool SkipChildren(INode node, INode parentNode) => false;

        public bool IsResourceDictionary(ElementNode node)
        {
            var parentVar = Context.Variables[(IElementNode)node];
            return parentVar.VariableType.FullName == "Tizen.NUI.Binding.ResourceDictionary"
                || parentVar.VariableType.Resolve().BaseType?.FullName == "Tizen.NUI.Binding.ResourceDictionary";
        }

        ModuleDefinition Module { get; }

        public void Visit(ValueNode node, INode parentNode)
        {
            //TODO support Label text as element
            XmlName propertyName;
            if (!TryGetPropertyName(node, parentNode, out propertyName))
            {
                if (!IsCollectionItem(node, parentNode))
                    return;
                string contentProperty;
                if (!Context.Variables.ContainsKey((IElementNode)parentNode))
                    return;
                var parentVar = Context.Variables[(IElementNode)parentNode];
                if ((contentProperty = GetContentProperty(parentVar.VariableType)) != null)
                    propertyName = new XmlName(((IElementNode)parentNode).NamespaceURI, contentProperty);
                else
                    return;
            }

            if (TrySetRuntimeName(propertyName, Context.Variables[(IElementNode)parentNode], node))
                return;
            if (skips.Contains(propertyName))
                return;
            if (parentNode is IElementNode && ((IElementNode)parentNode).SkipProperties.Contains (propertyName))
                return;
            if (propertyName.Equals(XamlParser.McUri, "Ignorable"))
                return;
            Context.IL.Append(SetPropertyValue(Context.Variables [(IElementNode)parentNode], propertyName, node, Context, node));
        }

        public void Visit(MarkupNode node, INode parentNode)
        {
        }

        public void Visit(ElementNode node, INode parentNode)
        {
            XmlName propertyName = XmlName.Empty;

            //Simplify ListNodes with single elements
            var pList = parentNode as ListNode;
            if (pList != null && pList.CollectionItems.Count == 1) {
                propertyName = pList.XmlName;
                parentNode = parentNode.Parent;
            }

            if ((propertyName != XmlName.Empty || TryGetPropertyName(node, parentNode, out propertyName)) && skips.Contains(propertyName))
                return;

            if (propertyName == XmlName._CreateContent) {
                SetDataTemplate((IElementNode)parentNode, node, Context, node);
                return;
            }

            //if this node is an IMarkupExtension, invoke ProvideValue() and replace the variable
            var vardef = Context.Variables[node];
            var vardefref = new VariableDefinitionReference(vardef);
            var localName = propertyName.LocalName;
            TypeReference declaringTypeReference = null;
            FieldReference bpRef = null;
            var _ = false;
            PropertyDefinition propertyRef = null;
            if (parentNode is IElementNode && propertyName != XmlName.Empty) {
                bpRef = GetBindablePropertyReference(Context.Variables [(IElementNode)parentNode], propertyName.NamespaceURI, ref localName, out _, Context, node);
                propertyRef = Context.Variables [(IElementNode)parentNode].VariableType.GetProperty(pd => pd.Name == localName, out declaringTypeReference);
            }
            Context.IL.Append(ProvideValue(vardefref, Context, Module, node, bpRef:bpRef, propertyRef:propertyRef, propertyDeclaringTypeRef: declaringTypeReference));
            if (vardef != vardefref.VariableDefinition)
            {
                vardef = vardefref.VariableDefinition;
                Context.Body.Variables.Add(vardef);
                Context.Variables[node] = vardef;
            }

            if (propertyName != XmlName.Empty) {
                if (skips.Contains(propertyName))
                    return;
                if (parentNode is IElementNode && ((IElementNode)parentNode).SkipProperties.Contains (propertyName))
                    return;
                
                Context.IL.Append(SetPropertyValue(Context.Variables[(IElementNode)parentNode], propertyName, node, Context, node));
            }
            else if (IsCollectionItem(node, parentNode) && parentNode is IElementNode) {
                var parentVar = Context.Variables[(IElementNode)parentNode];
                string contentProperty;

                bool isAdded = false;

                if (CanAddToResourceDictionary(parentVar, parentVar.VariableType, node, node, Context))
                {
                    Context.IL.Emit(Ldloc, parentVar);
                    Context.IL.Append(AddToResourceDictionary(node, node, Context));
                    isAdded = true;
                }
                // Collection element, implicit content, or implicit collection element.
                else if (parentVar.VariableType.GetMethods(md => md.Name == "Add" && md.Parameters.Count == 1, Module).Any())
                {
                    var elementType = parentVar.VariableType;
                    var paramType = Context.Variables[node].VariableType;

                    foreach (var adderTuple in elementType.GetMethods(md => md.Name == "Add" && md.Parameters.Count == 1, Module))
                    {
                        var adderRef = Module.ImportReference(adderTuple.Item1);
                        adderRef = Module.ImportReference(adderRef.ResolveGenericParameters(adderTuple.Item2, Module));

                        if (IsAddMethodOfCollection(Module, adderRef.Resolve()))
                        {
                            isAdded = true;
                        }
                        else if (paramType.InheritsFromOrImplements(adderTuple.Item1.Parameters[0].ParameterType.FullName))
                        {
                            isAdded = true;
                        }

                        if (isAdded)
                        {
                            Context.IL.Emit(Ldloc, parentVar);
                            Context.IL.Emit(Ldloc, vardef);
                            Context.IL.Emit(Callvirt, adderRef);
                            if (adderRef.ReturnType.FullName != "System.Void")
                                Context.IL.Emit(Pop);
                            break;
                        }
                    }
                }

                if (!isAdded && (contentProperty = GetContentProperty(parentVar.VariableType)) != null)
                {
                    var name = new XmlName(node.NamespaceURI, contentProperty);
                    if (skips.Contains(name))
                        return;
                    if (parentNode is IElementNode && ((IElementNode)parentNode).SkipProperties.Contains(propertyName))
                        return;
                    Context.IL.Append(SetPropertyValue(Context.Variables[(IElementNode)parentNode], name, node, Context, node));
                    isAdded = true;
                }
                
                if (!isAdded)
                {
                    throw new XamlParseException($"Can not set the content of {((IElementNode)parentNode).XmlType.Name} as it doesn't have a ContentPropertyAttribute", node);
                }
            }
            else if (IsCollectionItem(node, parentNode) && parentNode is ListNode)
            {
//                IL_000d:  ldloc.2 
//                IL_000e:  callvirt instance class [mscorlib]System.Collections.Generic.IList`1<!0> class [Tizen.NUI.Xaml.Core]Tizen.NUI.Xaml.Layout`1<class [Tizen.NUI.Xaml.Core]Tizen.NUI.Xaml.View>::get_Children()
//                IL_0013:  ldloc.0 
//                IL_0014:  callvirt instance void class [mscorlib]System.Collections.Generic.ICollection`1<class [Tizen.NUI.Xaml.Core]Tizen.NUI.Xaml.View>::Add(!0)

                var parentList = (ListNode)parentNode;
                var parent = Context.Variables[((IElementNode)parentNode.Parent)];

                if (skips.Contains(parentList.XmlName))
                    return;
                if (parentNode is IElementNode && ((IElementNode)parentNode).SkipProperties.Contains (propertyName))
                    return;
                var elementType = parent.VariableType;
                var localname = parentList.XmlName.LocalName;

                TypeReference propertyType;
                Context.IL.Append(GetPropertyValue(parent, parentList.XmlName, Context, node, out propertyType));

                if (CanAddToResourceDictionary(parent, propertyType, node, node, Context)) {
                    Context.IL.Append(AddToResourceDictionary(node, node, Context));
                    return;
                } 
                var adderTuple = propertyType.GetMethods(md => md.Name == "Add" && md.Parameters.Count == 1, Module).FirstOrDefault();
                if (adderTuple == null)
                    throw new XamlParseException($"Can not Add() elements to {parent.VariableType}.{localname}", node);
                var adderRef = Module.ImportReference(adderTuple.Item1);
                adderRef = Module.ImportReference(adderRef.ResolveGenericParameters(adderTuple.Item2, Module));

                Context.IL.Emit(OpCodes.Ldloc, vardef);
                Context.IL.Emit(OpCodes.Callvirt, adderRef);
                if (adderRef.ReturnType.FullName != "System.Void")
                        Context.IL.Emit(OpCodes.Pop);
            }
        }

        private static bool IsAddMethodOfCollection(ModuleDefinition module, MethodDefinition methodDef)
        {
            return module.ImportReference(typeof(List<string>)).InheritsFromOrImplements(methodDef.DeclaringType);
        }

        public void Visit(RootNode node, INode parentNode)
        {
        }

        public void Visit(ListNode node, INode parentNode)
        {
        }

        public static bool TryGetPropertyName(INode node, INode parentNode, out XmlName name)
        {
            name = default(XmlName);
            var parentElement = parentNode as IElementNode;
            if (parentElement == null)
                return false;
            foreach (var kvp in parentElement.Properties)
            {
                if (kvp.Value != node)
                    continue;
                name = kvp.Key;
                return true;
            }
            return false;
        }

        static bool IsCollectionItem(INode node, INode parentNode)
        {
            var parentList = parentNode as IListNode;
            if (parentList == null)
                return false;
            return parentList.CollectionItems.Contains(node);
        }

        internal static string GetContentProperty(TypeReference typeRef)
        {
            var typeDef = typeRef.ResolveCached();
            var attributes = typeDef.CustomAttributes;
            var attr =
                attributes.FirstOrDefault(cad => ContentPropertyAttribute.ContentPropertyTypes.Contains(cad.AttributeType.FullName));
            if (attr != null)
                return attr.ConstructorArguments[0].Value as string;
            if (typeDef.BaseType == null)
                return null;
            return GetContentProperty(typeDef.BaseType);
        }

        public static IEnumerable<Instruction> ProvideValue(VariableDefinitionReference vardefref, ILContext context,
                                                            ModuleDefinition module, ElementNode node, FieldReference bpRef = null,
                                                            PropertyReference propertyRef = null, TypeReference propertyDeclaringTypeRef = null)
        {
            GenericInstanceType markupExtension;
            IList<TypeReference> genericArguments;
            if (vardefref.VariableDefinition.VariableType.FullName == "Tizen.NUI.Xaml.ArrayExtension" &&
                vardefref.VariableDefinition.VariableType.ImplementsGenericInterface("Tizen.NUI.Xaml.IMarkupExtension`1",
                    out markupExtension, out genericArguments))
            {
                var markExt = markupExtension.ResolveCached();
                var provideValueInfo = markExt.Methods.First(md => md.Name == "ProvideValue");
                var provideValue = module.ImportReference(provideValueInfo);
                provideValue =
                    module.ImportReference(provideValue.ResolveGenericParameters(markupExtension, module));

                var typeNode = node.Properties[new XmlName("", "Type")];
                TypeReference arrayTypeRef;
                if (context.TypeExtensions.TryGetValue(typeNode, out arrayTypeRef))
                    vardefref.VariableDefinition = new VariableDefinition(module.ImportReference(arrayTypeRef.MakeArrayType()));
                else
                    vardefref.VariableDefinition = new VariableDefinition(module.ImportReference(genericArguments.First()));
                yield return Instruction.Create(OpCodes.Ldloc, context.Variables[node]);
                foreach (var instruction in node.PushServiceProvider(context, bpRef, propertyRef, propertyDeclaringTypeRef))
                    yield return instruction;
                yield return Instruction.Create(OpCodes.Callvirt, provideValue);

                if (arrayTypeRef != null)
                    yield return Instruction.Create(OpCodes.Castclass, module.ImportReference(arrayTypeRef.MakeArrayType()));
                yield return Instruction.Create(OpCodes.Stloc, vardefref.VariableDefinition);
            }
            else if (vardefref.VariableDefinition.VariableType.ImplementsGenericInterface("Tizen.NUI.Xaml.IMarkupExtension`1",
                out markupExtension, out genericArguments))
            {
                var acceptEmptyServiceProvider = vardefref.VariableDefinition.VariableType.GetCustomAttribute(module, (XamlCTask.xamlAssemblyName, XamlCTask.xamlNameSpace, "AcceptEmptyServiceProviderAttribute")) != null;
                if (vardefref.VariableDefinition.VariableType.FullName == "Tizen.NUI.Xaml.BindingExtension")
                    foreach (var instruction in CompileBindingPath(node, context, vardefref.VariableDefinition))
                        yield return instruction;

                var markExt = markupExtension.ResolveCached();
                var provideValueInfo = markExt.Methods.First(md => md.Name == "ProvideValue");
                var provideValue = module.ImportReference(provideValueInfo);
                provideValue =
                    module.ImportReference(provideValue.ResolveGenericParameters(markupExtension, module));

                vardefref.VariableDefinition = new VariableDefinition(module.ImportReference(genericArguments.First()));
                yield return Instruction.Create(OpCodes.Ldloc, context.Variables[node]);
                if (acceptEmptyServiceProvider)
                    yield return Instruction.Create(OpCodes.Ldnull);
                else
                    foreach (var instruction in node.PushServiceProvider(context, bpRef, propertyRef, propertyDeclaringTypeRef))
                        yield return instruction;
                yield return Instruction.Create(OpCodes.Callvirt, provideValue);
                yield return Instruction.Create(OpCodes.Stloc, vardefref.VariableDefinition);
            }
            else if (context.Variables[node].VariableType.ImplementsInterface(module.ImportReference((XamlCTask.xamlAssemblyName, XamlCTask.xamlNameSpace, "IMarkupExtension"))))
            {
                var acceptEmptyServiceProvider = context.Variables[node].VariableType.GetCustomAttribute(module, (XamlCTask.xamlAssemblyName, XamlCTask.xamlNameSpace, "AcceptEmptyServiceProviderAttribute")) != null;
                vardefref.VariableDefinition = new VariableDefinition(module.TypeSystem.Object);
                yield return Create(Ldloc, context.Variables[node]);
                if (acceptEmptyServiceProvider)
                    yield return Create(Ldnull);
                else
                    foreach (var instruction in node.PushServiceProvider(context, bpRef, propertyRef, propertyDeclaringTypeRef))
                        yield return instruction;
                yield return Create(Callvirt, module.ImportMethodReference((XamlCTask.xamlAssemblyName, XamlCTask.xamlNameSpace, "IMarkupExtension"),
                                                                           methodName: "ProvideValue",
                                                                           parameterTypes: new[] { ("System.ComponentModel", "System", "IServiceProvider") }));
                yield return Create(Stloc, vardefref.VariableDefinition);
            }
            else if (context.Variables[node].VariableType.ImplementsInterface(module.ImportReference((XamlCTask.xamlAssemblyName, XamlCTask.xamlNameSpace, "IValueProvider"))))
            {
                var acceptEmptyServiceProvider = context.Variables[node].VariableType.GetCustomAttribute(module, (XamlCTask.xamlAssemblyName, XamlCTask.xamlNameSpace, "AcceptEmptyServiceProviderAttribute")) != null;
                var valueProviderType = context.Variables[node].VariableType;
                //If the IValueProvider has a ProvideCompiledAttribute that can be resolved, shortcut this
                var compiledValueProviderName = valueProviderType?.GetCustomAttribute(module, (XamlCTask.xamlAssemblyName, XamlCTask.xamlNameSpace, "ProvideCompiledAttribute"))?.ConstructorArguments?[0].Value as string;
                Type compiledValueProviderType;
                if (compiledValueProviderName != null && (compiledValueProviderType = Type.GetType(compiledValueProviderName)) != null) {
                    var compiledValueProvider = Activator.CreateInstance(compiledValueProviderType);
                    var cProvideValue = typeof(ICompiledValueProvider).GetMethods().FirstOrDefault(md => md.Name == "ProvideValue");
                    var instructions = (IEnumerable<Instruction>)cProvideValue.Invoke(compiledValueProvider, new object[] {
                        vardefref,
                        context.Body.Method.Module,
                        node as BaseNode,
                        context});
                    foreach (var i in instructions)
                        yield return i;
                    yield break;
                }

                vardefref.VariableDefinition = new VariableDefinition(module.TypeSystem.Object);
                yield return Create(Ldloc, context.Variables[node]);
                if (acceptEmptyServiceProvider)
                    yield return Create(Ldnull);
                else
                    foreach (var instruction in node.PushServiceProvider(context, bpRef, propertyRef, propertyDeclaringTypeRef))
                        yield return instruction;
                yield return Create(Callvirt, module.ImportMethodReference((XamlCTask.xamlAssemblyName, XamlCTask.xamlNameSpace, "IValueProvider"),
                                                                           methodName: "ProvideValue",
                                                                           parameterTypes: new[] { ("System.ComponentModel", "System", "IServiceProvider") }));
                yield return Create(Stloc, vardefref.VariableDefinition);
            }
        }

        //Once we get compiled IValueProvider, this will move to the BindingExpression
        static IEnumerable<Instruction> CompileBindingPath(ElementNode node, ILContext context, VariableDefinition bindingExt)
        {
            //TODO support casting operators
            var module = context.Module;

            INode pathNode;
            if (!node.Properties.TryGetValue(new XmlName("", "Path"), out pathNode) && node.CollectionItems.Any())
                pathNode = node.CollectionItems [0];
            var path = (pathNode as ValueNode)?.Value as string;
            BindingMode declaredmode;
            if (   !node.Properties.TryGetValue(new XmlName("", "Mode"), out INode modeNode)
                || !Enum.TryParse((modeNode as ValueNode)?.Value as string, true, out declaredmode))
                declaredmode = BindingMode.TwoWay;    //meaning the mode isn't specified in the Binding extension. generate getters, setters, handlers

            INode dataTypeNode = null;
            IElementNode n = node;
            while (n != null) {
                if (n.Properties.TryGetValue(XmlName.xDataType, out dataTypeNode))
                    break;
                n = n.Parent as IElementNode;
            }
            var dataType = (dataTypeNode as ValueNode)?.Value as string;
            if (dataType == null)
                yield break; //throw

            var prefix = dataType.Contains(":") ? dataType.Substring(0, dataType.IndexOf(":", StringComparison.Ordinal)) : "";
            var namespaceuri = node.NamespaceResolver.LookupNamespace(prefix) ?? "";
            if (!string.IsNullOrEmpty(prefix) && string.IsNullOrEmpty(namespaceuri))
                throw new XamlParseException($"Undeclared xmlns prefix '{prefix}'", dataTypeNode as IXmlLineInfo);

            var dtXType = new XmlType(namespaceuri, dataType, null);

            var tSourceRef = dtXType.GetTypeReference(module, (IXmlLineInfo)node);
            if (tSourceRef == null)
                yield break; //throw

            var properties = ParsePath(path, tSourceRef, node as IXmlLineInfo, module);
            var tPropertyRef = properties != null && properties.Any() ? properties.Last().Item1.PropertyType : tSourceRef;
            tPropertyRef = module.ImportReference(tPropertyRef);

            var funcRef = module.ImportReference(module.ImportReference(("mscorlib", "System", "Func`2")).MakeGenericInstanceType(new [] { tSourceRef, tPropertyRef }));
            var actionRef = module.ImportReference(module.ImportReference(("mscorlib", "System", "Action`2")).MakeGenericInstanceType(new [] { tSourceRef, tPropertyRef }));
            var funcObjRef = module.ImportReference(module.ImportReference(("mscorlib", "System", "Func`2")).MakeGenericInstanceType(new [] { tSourceRef, module.TypeSystem.Object }));
            var tupleRef = module.ImportReference(module.ImportReference(("mscorlib", "System", "Tuple`2")).MakeGenericInstanceType(new [] { funcObjRef, module.TypeSystem.String}));
            var typedBindingRef = module.ImportReference(module.ImportReference((XamlCTask.bindingAssemblyName, XamlCTask.bindingInternalNameSpace, "TypedBinding`2")).MakeGenericInstanceType(new [] { tSourceRef, tPropertyRef}));

            var ctorInfo =  module.ImportReference(typedBindingRef.ResolveCached().Methods.FirstOrDefault(md => md.IsConstructor && !md.IsStatic && md.Parameters.Count == 3 ));
            var ctorinforef = ctorInfo.MakeGeneric(typedBindingRef, funcRef, actionRef, tupleRef);

            yield return Instruction.Create(OpCodes.Ldloc, bindingExt);
            foreach (var instruction in CompiledBindingGetGetter(tSourceRef, tPropertyRef, properties, node, context))
                yield return instruction;
            if (declaredmode != BindingMode.OneTime && declaredmode != BindingMode.OneWay) { //if the mode is explicitly 1w, or 1t, no need for setters
                foreach (var instruction in CompiledBindingGetSetter(tSourceRef, tPropertyRef, properties, node, context))
                    yield return instruction;
            } else
                yield return Create(Ldnull);
            if (declaredmode != BindingMode.OneTime) { //if the mode is explicitly 1t, no need for handlers
                foreach (var instruction in CompiledBindingGetHandlers(tSourceRef, tPropertyRef, properties, node, context))
                    yield return instruction;
            } else
                yield return Create(Ldnull);
            yield return Instruction.Create(OpCodes.Newobj, module.ImportReference(ctorinforef));
            yield return Instruction.Create(OpCodes.Callvirt, module.ImportPropertySetterReference((XamlCTask.bindingAssemblyName, XamlCTask.bindingNameSpace, "BindingExtension"), propertyName: "TypedBinding"));
        }

        static IList<Tuple<PropertyDefinition, string>> ParsePath(string path, TypeReference tSourceRef, IXmlLineInfo lineInfo, ModuleDefinition module)
        {
            if (string.IsNullOrWhiteSpace(path))
                return null;
            path = path.Trim(' ', '.'); //trim leading or trailing dots
            var parts = path.Split(new [] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            var properties = new List<Tuple<PropertyDefinition, string>>();

            var previousPartTypeRef = tSourceRef;
            TypeReference _;
            foreach (var part in parts) {
                var p = part;
                string indexArg = null;
                var lbIndex = p.IndexOf('[');
                if (lbIndex != -1) {
                    var rbIndex = p.LastIndexOf(']');
                    if (rbIndex == -1)
                        throw new XamlParseException("Binding: Indexer did not contain closing bracket", lineInfo);
                    
                    var argLength = rbIndex - lbIndex - 1;
                    if (argLength == 0)
                        throw new XamlParseException("Binding: Indexer did not contain arguments", lineInfo);

                    indexArg = p.Substring(lbIndex + 1, argLength).Trim();
                    if (indexArg.Length == 0)
                        throw new XamlParseException("Binding: Indexer did not contain arguments", lineInfo);
                    
                    p = p.Substring(0, lbIndex);
                    p = p.Trim();
                }

                if (p.Length > 0) {
                    var property = previousPartTypeRef.GetProperty(pd => pd.Name == p && pd.GetMethod != null && pd.GetMethod.IsPublic, out _)
                                                      ?? throw new XamlParseException($"Binding: Property '{p}' not found on '{previousPartTypeRef}'", lineInfo);
                    properties.Add(new Tuple<PropertyDefinition, string>(property,null));
                    previousPartTypeRef = property.PropertyType;
                }
                if (indexArg != null) {
                    var defaultMemberAttribute = previousPartTypeRef.GetCustomAttribute(module, ("mscorlib", "System.Reflection", "DefaultMemberAttribute"));
                    var indexerName = defaultMemberAttribute?.ConstructorArguments?.FirstOrDefault().Value as string ?? "Item";
                    var indexer = previousPartTypeRef.GetProperty(pd => pd.Name == indexerName && pd.GetMethod != null && pd.GetMethod.IsPublic, out _);
                    properties.Add(new Tuple<PropertyDefinition, string>(indexer, indexArg));
                    if (indexer.PropertyType != module.TypeSystem.String && indexer.PropertyType != module.TypeSystem.Int32)
                        throw new XamlParseException($"Binding: Unsupported indexer index type: {indexer.PropertyType.FullName}", lineInfo);
                    previousPartTypeRef = indexer.PropertyType;
                }
            }
            return properties;
        }

        static IEnumerable<Instruction> CompiledBindingGetGetter(TypeReference tSourceRef, TypeReference tPropertyRef, IList<Tuple<PropertyDefinition, string>> properties, ElementNode node, ILContext context)
        {
//            .method private static hidebysig default string '<Main>m__0' (class ViewModel vm)  cil managed
//            {
//                .custom instance void class [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::'.ctor'() =  (01 00 00 00 ) // ...
//
//                IL_0000:  ldarg.0 
//                IL_0001:  callvirt instance class ViewModel class ViewModel::get_Model()
//                IL_0006:  callvirt instance string class ViewModel::get_Text()
//                IL_0006:  ret
//            }

            var module = context.Module;
            var getter = new MethodDefinition($"<{context.Body.Method.Name}>typedBindingsM__{typedBindingCount++}",
                                              MethodAttributes.Private | MethodAttributes.HideBySig | MethodAttributes.Static,
                                              tPropertyRef) {
                Parameters = {
                    new ParameterDefinition(tSourceRef)
                },
                CustomAttributes = {
                    new CustomAttribute (module.ImportCtorReference(("mscorlib", "System.Runtime.CompilerServices", "CompilerGeneratedAttribute"), parameterTypes: null))
                }
            };
            getter.Body.InitLocals = true;
            var il = getter.Body.GetILProcessor();

            if (properties == null || properties.Count == 0) { //return self
                il.Emit(Ldarg_0);
                il.Emit(Ret);
            }
            else {
                if (tSourceRef.IsValueType)
                    il.Emit(Ldarga_S, (byte)0);
                else
                    il.Emit(Ldarg_0);

                foreach (var propTuple in properties) {
                    var property = propTuple.Item1;
                    var indexerArg = propTuple.Item2;
                    if (indexerArg != null) {
                        if (property.GetMethod.Parameters[0].ParameterType == module.TypeSystem.String)
                            il.Emit(Ldstr, indexerArg);
                        else if (property.GetMethod.Parameters[0].ParameterType == module.TypeSystem.Int32) {
                            int index;
                            if (!int.TryParse(indexerArg, out index))
                                throw new XamlParseException($"Binding: {indexerArg} could not be parsed as an index for a {property.Name}", node as IXmlLineInfo);
                            il.Emit(Ldc_I4, index);
                        }
                    }
                    if (property.GetMethod.IsVirtual)
                        il.Emit(Callvirt, module.ImportReference(property.GetMethod));
                    else
                        il.Emit(Call, module.ImportReference(property.GetMethod));
                    }

                il.Emit(Ret);
            }
            context.Body.Method.DeclaringType.Methods.Add(getter);

//            IL_0007:  ldnull
//            IL_0008:  ldftn string class Test::'<Main>m__0'(class ViewModel)
//            IL_000e:  newobj instance void class [mscorlib]System.Func`2<class ViewModel, string>::'.ctor'(object, native int)

            yield return Create(Ldnull);
            yield return Create(Ldftn, getter);
            yield return Create(Newobj, module.ImportCtorReference(("mscorlib", "System", "Func`2"), paramCount: 2, classArguments: new[] { tSourceRef, tPropertyRef }));
        }

        static IEnumerable<Instruction> CompiledBindingGetSetter(TypeReference tSourceRef, TypeReference tPropertyRef, IList<Tuple<PropertyDefinition, string>> properties, ElementNode node, ILContext context)
        {
            if (properties == null || properties.Count == 0) {
                yield return Create(Ldnull);
                yield break;
            }

            //            .method private static hidebysig default void '<Main>m__1' (class ViewModel vm, string s)  cil managed
            //            {
            //                .custom instance void class [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::'.ctor'() =  (01 00 00 00 ) // ....
            //
            //                IL_0000:  ldarg.0 
            //                IL_0001:  callvirt instance class ViewModel class ViewModel::get_Model()
            //                IL_0006:  ldarg.1 
            //                IL_0007:  callvirt instance void class ViewModel::set_Text(string)
            //                IL_000c:  ret
            //            }

            var module = context.Module;
            var setter = new MethodDefinition($"<{context.Body.Method.Name}>typedBindingsM__{typedBindingCount++}",
                                              MethodAttributes.Private | MethodAttributes.HideBySig | MethodAttributes.Static,
                                              module.TypeSystem.Void) {
                Parameters = {
                    new ParameterDefinition(tSourceRef),
                    new ParameterDefinition(tPropertyRef)
                },
                CustomAttributes = {
                    new CustomAttribute (module.ImportCtorReference(("mscorlib", "System.Runtime.CompilerServices", "CompilerGeneratedAttribute"), parameterTypes: null))
                }
            };
            setter.Body.InitLocals = true;

            var il = setter.Body.GetILProcessor();
            var lastProperty = properties.LastOrDefault();
            var setterRef = lastProperty?.Item1.SetMethod;
            if (setterRef == null) {
                yield return Create(Ldnull); //throw or not ?
                yield break;
            }

            if (tSourceRef.IsValueType)
                il.Emit(Ldarga_S, (byte)0);
            else
                il.Emit(Ldarg_0);
            for (int i = 0; i < properties.Count - 1; i++) {
                var property = properties[i].Item1;
                var indexerArg = properties[i].Item2;
                if (indexerArg != null) {
                    if (property.GetMethod.Parameters [0].ParameterType == module.TypeSystem.String)
                        il.Emit(Ldstr, indexerArg);
                    else if (property.GetMethod.Parameters [0].ParameterType == module.TypeSystem.Int32) {
                        int index;
                        if (!int.TryParse(indexerArg, out index))
                            throw new XamlParseException($"Binding: {indexerArg} could not be parsed as an index for a {property.Name}", node as IXmlLineInfo);
                        il.Emit(Ldc_I4, index);
                    }
                }
                if (property.GetMethod.IsVirtual)
                    il.Emit(Callvirt, module.ImportReference(property.GetMethod));
                else
                    il.Emit(Call, module.ImportReference(property.GetMethod));
            }

            var indexer = properties.Last().Item2;
            if (indexer != null) {
                if (lastProperty.Item1.GetMethod.Parameters [0].ParameterType == module.TypeSystem.String)
                    il.Emit(Ldstr, indexer);
                else if (lastProperty.Item1.GetMethod.Parameters [0].ParameterType == module.TypeSystem.Int32) {
                    int index;
                    if (!int.TryParse(indexer, out index))
                        throw new XamlParseException($"Binding: {indexer} could not be parsed as an index for a {lastProperty.Item1.Name}", node as IXmlLineInfo);
                    il.Emit(Ldc_I4, index);
                }
            }

            il.Emit(Ldarg_1);

            if (setterRef.IsVirtual)
                il.Emit(Callvirt, module.ImportReference(setterRef));
            else
                il.Emit(Call, module.ImportReference(setterRef));

            il.Emit(Ret);

            context.Body.Method.DeclaringType.Methods.Add(setter);

//            IL_0024: ldnull
//            IL_0025: ldftn void class Test::'<Main>m__1'(class ViewModel, string)
//            IL_002b: newobj instance void class [mscorlib]System.Action`2<class ViewModel, string>::'.ctor'(object, native int)
            yield return Create(Ldnull);
            yield return Create(Ldftn, setter);
            yield return Create(Newobj, module.ImportCtorReference(("mscorlib", "System", "Action`2"),
                                                                   paramCount: 2,
                                                                   classArguments:
                                                                   new[] { tSourceRef, tPropertyRef }));
        }

        static IEnumerable<Instruction> CompiledBindingGetHandlers(TypeReference tSourceRef, TypeReference tPropertyRef, IList<Tuple<PropertyDefinition, string>> properties, ElementNode node, ILContext context)
        {
//            .method private static hidebysig default object '<Main>m__2'(class ViewModel vm)  cil managed {
//                .custom instance void class [mscorlib] System.Runtime.CompilerServices.CompilerGeneratedAttribute::'.ctor'() =  (01 00 00 00 ) // ....
//                IL_0000:  ldarg.0 
//                IL_0001:  ret
//            } // end of method Test::<Main>m__2

//            .method private static hidebysig default object '<Main>m__3' (class ViewModel vm)  cil managed {
//                .custom instance void class [mscorlib] System.Runtime.CompilerServices.CompilerGeneratedAttribute::'.ctor'() =  (01 00 00 00 ) // ....
//                IL_0000:  ldarg.0 
//                IL_0001:  callvirt instance class ViewModel class ViewModel::get_Model()
//                IL_0006:  ret
//            }

            var module = context.Module;

            var partGetters = new List<MethodDefinition>();
            if (properties == null || properties.Count == 0) {
                yield return Instruction.Create(OpCodes.Ldnull);
                yield break;
            }
                
            for (int i = 0; i < properties.Count; i++) {
                var tuple = properties [i];
                var partGetter = new MethodDefinition($"<{context.Body.Method.Name}>typedBindingsM__{typedBindingCount++}", MethodAttributes.Private | MethodAttributes.HideBySig | MethodAttributes.Static, module.TypeSystem.Object) {
                    Parameters = {
                        new ParameterDefinition(tSourceRef)
                    },
                    CustomAttributes = {
                        new CustomAttribute (module.ImportCtorReference(("mscorlib", "System.Runtime.CompilerServices", "CompilerGeneratedAttribute"), parameterTypes: null))
                    }
                };
                partGetter.Body.InitLocals = true;
                var il = partGetter.Body.GetILProcessor();

                if (i == 0) { //return self
                    il.Emit(Ldarg_0);
                    if (tSourceRef.IsValueType)
                        il.Emit(Box, module.ImportReference(tSourceRef));

                    il.Emit(Ret);
                    context.Body.Method.DeclaringType.Methods.Add(partGetter);
                    partGetters.Add(partGetter);
                    continue;
                }

                if (tSourceRef.IsValueType)
                    il.Emit(Ldarga_S, (byte)0);
                else
                    il.Emit(Ldarg_0);
                var lastGetterTypeRef = tSourceRef;
                for (int j = 0; j < i; j++) {
                    var propTuple = properties [j];
                    var property = propTuple.Item1;
                    var indexerArg = propTuple.Item2;
                    if (indexerArg != null) {
                        if (property.GetMethod.Parameters [0].ParameterType == module.TypeSystem.String)
                            il.Emit(OpCodes.Ldstr, indexerArg);
                        else if (property.GetMethod.Parameters [0].ParameterType == module.TypeSystem.Int32) {
                            int index;
                            if (!int.TryParse(indexerArg, out index))
                                throw new XamlParseException($"Binding: {indexerArg} could not be parsed as an index for a {property.Name}", node as IXmlLineInfo);
                            il.Emit(OpCodes.Ldc_I4, index);
                        }
                    }
                    if (property.GetMethod.IsVirtual)
                        il.Emit(Callvirt, module.ImportReference(property.GetMethod));
                    else
                        il.Emit(Call, module.ImportReference(property.GetMethod));
                    lastGetterTypeRef = property.PropertyType;
                }
                if (lastGetterTypeRef.IsValueType)
                    il.Emit(Box, module.ImportReference(lastGetterTypeRef));

                il.Emit(OpCodes.Ret);
                context.Body.Method.DeclaringType.Methods.Add(partGetter);
                partGetters.Add(partGetter);
            }

            var funcObjRef = context.Module.ImportReference(module.ImportReference(("mscorlib", "System", "Func`2")).MakeGenericInstanceType(new [] { tSourceRef, module.TypeSystem.Object }));
            var tupleRef = context.Module.ImportReference(module.ImportReference(("mscorlib", "System", "Tuple`2")).MakeGenericInstanceType(new [] { funcObjRef, module.TypeSystem.String }));
            var funcCtor = module.ImportReference(funcObjRef.ResolveCached().GetConstructors().First());
            funcCtor = funcCtor.MakeGeneric(funcObjRef, new [] { tSourceRef, module.TypeSystem.Object });
            var tupleCtor = module.ImportReference(tupleRef.ResolveCached().GetConstructors().First());
            tupleCtor = tupleCtor.MakeGeneric(tupleRef, new [] { funcObjRef, module.TypeSystem.String});

//            IL_003a:  ldc.i4.2 
//            IL_003b:  newarr class [mscorlib] System.Tuple`2<class [mscorlib]System.Func`2<class ViewModel,object>,string>

//            IL_0040:  dup
//            IL_0041:  ldc.i4.0 
//            IL_0049:  ldnull
//            IL_004a:  ldftn object class Test::'<Main>m__2'(class ViewModel)
//            IL_0050:  newobj instance void class [mscorlib]System.Func`2<class ViewModel, object>::'.ctor'(object, native int)
//            IL_005f:  ldstr "Model"
//            IL_0064:  newobj instance void class [mscorlib]System.Tuple`2<class [mscorlib]System.Func`2<class ViewModel, object>, string>::'.ctor'(!0, !1)
//            IL_0069:  stelem.ref 

//            IL_006a:  dup
//            IL_006b:  ldc.i4.1 
//            IL_0073:  ldnull
//            IL_0074:  ldftn object class Test::'<Main>m__3'(class ViewModel)
//            IL_007a:  newobj instance void class [mscorlib]System.Func`2<class ViewModel, object>::'.ctor'(object, native int)
//            IL_0089:  ldstr "Text"
//            IL_008e:  newobj instance void class [mscorlib]System.Tuple`2<class [mscorlib]System.Func`2<class ViewModel, object>, string>::'.ctor'(!0, !1)
//            IL_0093:  stelem.ref 

            yield return Instruction.Create(OpCodes.Ldc_I4, properties.Count);
            yield return Instruction.Create(OpCodes.Newarr, tupleRef);

            for (var i = 0; i < properties.Count; i++) {
                yield return Instruction.Create(OpCodes.Dup);
                yield return Instruction.Create(OpCodes.Ldc_I4, i);
                yield return Instruction.Create(OpCodes.Ldnull);
                yield return Instruction.Create(OpCodes.Ldftn, partGetters [i]);
                yield return Instruction.Create(OpCodes.Newobj, module.ImportReference(funcCtor));
                yield return Instruction.Create(OpCodes.Ldstr, properties [i].Item1.Name);
                yield return Instruction.Create(OpCodes.Newobj, module.ImportReference(tupleCtor));
                yield return Instruction.Create(OpCodes.Stelem_Ref);
            }
        }

        public static IEnumerable<Instruction> SetPropertyValue(VariableDefinition parent, XmlName propertyName, INode valueNode, ILContext context, IXmlLineInfo iXmlLineInfo)
        {
            var module = context.Body.Method.Module;
            var localName = propertyName.LocalName;
            bool attached;

            var bpRef = GetBindablePropertyReference(parent, propertyName.NamespaceURI, ref localName, out attached, context, iXmlLineInfo);

            //If the target is an event, connect
            if (CanConnectEvent(parent, localName, attached))
            {
                var instrunctions = ConnectEvent(parent, localName, valueNode, iXmlLineInfo, context);
                if (null != context.InsOfAddEvent)
                {
                    foreach (var ins in instrunctions)
                    {
                        context.InsOfAddEvent.Add(ins);
                    }
                }
                return instrunctions;
            }

            //If Value is DynamicResource, SetDynamicResource
            if (CanSetDynamicResource(bpRef, valueNode, context))
                return SetDynamicResource(parent, bpRef, valueNode as IElementNode, iXmlLineInfo, context);

            //If Value is a BindingBase and target is a BP, SetBinding
            if (CanSetBinding(bpRef, valueNode, context))
                return SetBinding(parent, bpRef, valueNode as IElementNode, iXmlLineInfo, context);

            //If it's a property, set it
            if (CanSet(parent, localName, valueNode, context))
                return Set(parent, localName, valueNode, iXmlLineInfo, context);

            //If it's a BP, SetValue ()
            if (CanSetValue(bpRef, attached, valueNode, iXmlLineInfo, context))
                return SetValue(parent, bpRef, valueNode, iXmlLineInfo, context);

            //If it's an already initialized property, add to it
            if (CanAdd(parent, propertyName, valueNode, iXmlLineInfo, context))
                return Add(parent, propertyName, valueNode, iXmlLineInfo, context);

            throw new XamlParseException($"No property, bindable property, or event found for '{localName}', or mismatching type between value and property.", iXmlLineInfo);
        }

        public static IEnumerable<Instruction> GetPropertyValue(VariableDefinition parent, XmlName propertyName, ILContext context, IXmlLineInfo lineInfo, out TypeReference propertyType)
        {
            var module = context.Body.Method.Module;
            var localName = propertyName.LocalName;
            bool attached;
            var bpRef = GetBindablePropertyReference(parent, propertyName.NamespaceURI, ref localName, out attached, context, lineInfo);

            //If it's a BP, GetValue ()
            if (CanGetValue(parent, bpRef, attached, lineInfo, context, out _))
                return GetValue(parent, bpRef, lineInfo, context, out propertyType);

            //If it's a property, set it
            if (CanGet(parent, localName, context, out _))
                return Get(parent, localName, lineInfo, context, out propertyType);

            throw new XamlParseException($"Property {localName} is not found or does not have an accessible getter", lineInfo);
        }

        static FieldReference GetBindablePropertyReference(VariableDefinition parent, string namespaceURI, ref string localName, out bool attached, ILContext context, IXmlLineInfo iXmlLineInfo)
        {
            var module = context.Body.Method.Module;
            TypeReference declaringTypeReference;

            //If it's an attached BP, update elementType and propertyName
            var bpOwnerType = parent.VariableType;
            attached = GetNameAndTypeRef(ref bpOwnerType, namespaceURI, ref localName, context, iXmlLineInfo);
            var name = $"{localName}Property";
            FieldReference bpRef = bpOwnerType.GetField(fd => fd.Name == name &&
                                                        fd.IsStatic &&
                                                        (fd.IsPublic || fd.IsAssembly), out declaringTypeReference);
            if (bpRef != null) {
                bpRef = module.ImportReference(bpRef.ResolveGenericParameters(declaringTypeReference));
                bpRef.FieldType = module.ImportReference(bpRef.FieldType);
            }
            return bpRef;
        }

        static bool CanConnectEvent(VariableDefinition parent, string localName, bool attached)
        {
            return !attached && parent.VariableType.GetEvent(ed => ed.Name == localName, out _) != null;
        }

        static IEnumerable<Instruction> ConnectEvent(VariableDefinition parent, string localName, INode valueNode, IXmlLineInfo iXmlLineInfo, ILContext context)
        {
            var elementType = parent.VariableType;
            var module = context.Body.Method.Module;
            TypeReference eventDeclaringTypeRef;

            var eventinfo = elementType.GetEvent(ed => ed.Name == localName, out eventDeclaringTypeRef);

//            IL_0007:  ldloc.0 
//            IL_0008:  ldarg.0 
//
//            IL_0009:  ldftn instance void class Tizen.NUI.Xaml.XamlcTests.MyPage::OnButtonClicked(object, class [mscorlib]System.EventArgs)
//OR, if the handler is virtual
//            IL_000x:  ldarg.0 
//            IL_0009:  ldvirtftn instance void class Tizen.NUI.Xaml.XamlcTests.MyPage::OnButtonClicked(object, class [mscorlib]System.EventArgs)
//
//            IL_000f:  newobj instance void class [mscorlib]System.EventHandler::'.ctor'(object, native int)
//            IL_0014:  callvirt instance void class [Tizen.NUI.Xaml.Core]Tizen.NUI.Xaml.Button::add_Clicked(class [mscorlib]System.EventHandler)

            var value = ((ValueNode)valueNode).Value;

            yield return Create(Ldloc, parent);
            if (context.Root is VariableDefinition)
                yield return Create(Ldloc, context.Root as VariableDefinition);
            else if (context.Root is FieldDefinition) {
                yield return Create(Ldarg_0);
                yield return Create(Ldfld, context.Root as FieldDefinition);
            } else 
                throw new InvalidProgramException();
            var declaringType = context.Body.Method.DeclaringType;
            while (declaringType.IsNested)
                declaringType = declaringType.DeclaringType;
            var handler = declaringType.AllMethods().FirstOrDefault(md => md.Name == value as string);
            if (handler == null) 
                throw new XamlParseException($"EventHandler \"{value}\" not found in type \"{context.Body.Method.DeclaringType.FullName}\"", iXmlLineInfo);

            //check if the handler signature matches the Invoke signature;
            var invoke = module.ImportReference(eventinfo.EventType.ResolveCached().GetMethods().First(md => md.Name == "Invoke"));
            invoke = invoke.ResolveGenericParameters(eventinfo.EventType, module);
            if (!handler.ReturnType.InheritsFromOrImplements(invoke.ReturnType))
            {
                TypeDefinition realType = eventinfo.EventType.ResolveCached();

                GenericInstanceType genericInstanceType = eventinfo.EventType as GenericInstanceType;

                if (null != genericInstanceType
                    && genericInstanceType.GenericArguments.Count == realType.GenericParameters.Count)
                {
                    Dictionary<string, TypeReference> dict = new Dictionary<string, TypeReference>();

                    for (int i = 0; i < realType.GenericParameters.Count; i++)
                    {
                        string p = realType.GenericParameters[i].Name;
                        TypeReference type = genericInstanceType.GenericArguments[i];

                        dict.Add(p, type);
                    }

                    if (dict.ContainsKey(invoke.ReturnType.Name))
                    {
                        invoke.ReturnType = dict[invoke.ReturnType.Name];
                    }

                    for (int i = 0; i < invoke.Parameters.Count; i++)
                    {
                        if (dict.ContainsKey(invoke.Parameters[i].ParameterType.Name))
                        {
                            invoke.Parameters[i].ParameterType = dict[invoke.Parameters[i].ParameterType.Name];
                        }
                    }
                }
            }

            if (!handler.ReturnType.InheritsFromOrImplements(invoke.ReturnType))
                throw new XamlParseException($"Signature (return type) of EventHandler \"{context.Body.Method.DeclaringType.FullName}.{value}\" doesn't match the event type", iXmlLineInfo);
            if (invoke.Parameters.Count != handler.Parameters.Count)
                throw new XamlParseException($"Signature (number of arguments) of EventHandler \"{context.Body.Method.DeclaringType.FullName}.{value}\" doesn't match the event type", iXmlLineInfo);
            if (!invoke.ContainsGenericParameter)
                for (var i = 0; i < invoke.Parameters.Count;i++)
                    if (!handler.Parameters[i].ParameterType.InheritsFromOrImplements(invoke.Parameters[i].ParameterType))
                        throw new XamlParseException($"Signature (parameter {i}) of EventHandler \"{context.Body.Method.DeclaringType.FullName}.{value}\" doesn't match the event type", iXmlLineInfo);

            if (handler.IsVirtual) {
                yield return Create(Ldarg_0);
                yield return Create(Ldvirtftn, handler);
            } else
                yield return Create(Ldftn, handler);

            //FIXME: eventually get the right ctor instead fo the First() one, just in case another one could exists (not even sure it's possible).
            var ctor = module.ImportReference(eventinfo.EventType.ResolveCached().GetConstructors().First());
            ctor = ctor.ResolveGenericParameters(eventinfo.EventType, module);
            yield return Create(Newobj, module.ImportReference(ctor));
            //Check if the handler has the same signature as the ctor (it should)
            var adder = module.ImportReference(eventinfo.AddMethod);
            adder = adder.ResolveGenericParameters(eventDeclaringTypeRef, module);
            yield return Create(Callvirt, module.ImportReference(adder));
        }

        static bool CanSetDynamicResource(FieldReference bpRef, INode valueNode, ILContext context)
        {
            if (bpRef == null)
                return false;
            var elementNode = valueNode as IElementNode;
            if (elementNode == null)
                return false;
            
            VariableDefinition varValue;
            if (!context.Variables.TryGetValue(valueNode as IElementNode, out varValue))
                return false;
            return varValue.VariableType.FullName == typeof(DynamicResource).FullName;
        }

        static IEnumerable<Instruction> SetDynamicResource(VariableDefinition parent, FieldReference bpRef, IElementNode elementNode, IXmlLineInfo iXmlLineInfo, ILContext context)
        {
            var module = context.Body.Method.Module;

            yield return Create(Ldloc, parent);
            yield return Create(Ldsfld, bpRef);
            yield return Create(Ldloc, context.Variables[elementNode]);
            yield return Create(Callvirt, module.ImportPropertyGetterReference((XamlCTask.bindingAssemblyName, XamlCTask.bindingInternalNameSpace, "DynamicResource"), propertyName: "Key"));
            yield return Create(Callvirt, module.ImportMethodReference((XamlCTask.bindingAssemblyName, XamlCTask.bindingInternalNameSpace, "IDynamicResourceHandler"),
                                                                       methodName: "SetDynamicResource",
                                                                       parameterTypes: new[] {
                                                                           (XamlCTask.bindingAssemblyName, XamlCTask.bindingNameSpace, "BindableProperty"),
                                                                           ("mscorlib", "System", "String"),
                                                                       }));
        }

        static bool CanSetBinding(FieldReference bpRef, INode valueNode, ILContext context)
        {
            var module = context.Body.Method.Module;

            if (bpRef == null)
                return false;
            var elementNode = valueNode as IElementNode;
            if (elementNode == null)
                return false;

            VariableDefinition varValue;
            if (!context.Variables.TryGetValue(valueNode as IElementNode, out varValue))
                return false;

            var implicitOperator = varValue.VariableType.GetImplicitOperatorTo(module.ImportReference((XamlCTask.bindingAssemblyName, XamlCTask.bindingNameSpace, "BindingBase")), module);
            if (implicitOperator != null)
                return true;

            return varValue.VariableType.InheritsFromOrImplements(module.ImportReference((XamlCTask.bindingAssemblyName, XamlCTask.bindingNameSpace, "BindingBase")));
        }

        static IEnumerable<Instruction> SetBinding(VariableDefinition parent, FieldReference bpRef, IElementNode elementNode, IXmlLineInfo iXmlLineInfo, ILContext context)
        {
            var module = context.Body.Method.Module;
            var varValue = context.Variables [elementNode];
            var implicitOperator = varValue.VariableType.GetImplicitOperatorTo(module.ImportReference((XamlCTask.bindingAssemblyName, XamlCTask.bindingNameSpace, "BindingBase")), module);

            //TODO: check if parent is a BP
            yield return Create(Ldloc, parent);
            yield return Create(Ldsfld, bpRef);
            yield return Create(Ldloc, varValue);
            if (implicitOperator != null) 
//                IL_000f:  call !0 class [Tizen.NUI.Xaml.Core]Tizen.NUI.Xaml.OnPlatform`1<BindingBase>::op_Implicit(class [Tizen.NUI.Xaml.Core]Tizen.NUI.Xaml.OnPlatform`1<!0>)
                yield return Create(Call, module.ImportReference(implicitOperator));
            yield return Create(Callvirt, module.ImportMethodReference((XamlCTask.bindingAssemblyName, XamlCTask.bindingNameSpace, "BindableObject"),
                                                                       methodName: "SetBinding",
                                                                       parameterTypes: new[] {
                                                                           (XamlCTask.bindingAssemblyName, XamlCTask.bindingNameSpace, "BindableProperty"),
                                                                           (XamlCTask.bindingAssemblyName, XamlCTask.bindingNameSpace, "BindingBase"),
                                                                       }));
        }

        static bool CanSetValue(FieldReference bpRef, bool attached, INode node, IXmlLineInfo iXmlLineInfo, ILContext context)
        {
            var module = context.Body.Method.Module;

            if (bpRef == null)
                return false;

            var valueNode = node as ValueNode;
            if (valueNode != null && valueNode.CanConvertValue(context.Body.Method.Module, bpRef))
                return true;

            var elementNode = node as IElementNode;
            if (elementNode == null)
                return false;

            VariableDefinition varValue;
            if (!context.Variables.TryGetValue(elementNode, out varValue))
                return false;

            var bpTypeRef = bpRef.GetBindablePropertyType(iXmlLineInfo, module);
            // If it's an attached BP, there's no second chance to handle IMarkupExtensions, so we try here.
            // Worst case scenario ? InvalidCastException at runtime
            if (attached && varValue.VariableType.FullName == "System.Object") 
                return true;
            var implicitOperator = varValue.VariableType.GetImplicitOperatorTo(bpTypeRef, module);
            if (implicitOperator != null)
                return true;

            //as we're in the SetValue Scenario, we can accept value types, they'll be boxed
            if (varValue.VariableType.IsValueType && bpTypeRef.FullName == "System.Object")
                return true;

            return varValue.VariableType.InheritsFromOrImplements(bpTypeRef);
        }

        static bool CanGetValue(VariableDefinition parent, FieldReference bpRef, bool attached, IXmlLineInfo iXmlLineInfo, ILContext context, out TypeReference propertyType)
        {
            var module = context.Body.Method.Module;
            propertyType = null;

            if (bpRef == null)
                return false;

            if (!parent.VariableType.InheritsFromOrImplements(module.ImportReference((XamlCTask.bindingAssemblyName, XamlCTask.bindingNameSpace, "BindableObject"))))
                return false;

            propertyType = bpRef.GetBindablePropertyType(iXmlLineInfo, module);
            return true;
        }

        static IEnumerable<Instruction> SetValue(VariableDefinition parent, FieldReference bpRef, INode node, IXmlLineInfo iXmlLineInfo, ILContext context)
        {
            var valueNode = node as ValueNode;
            var elementNode = node as IElementNode;
            var module = context.Body.Method.Module;

//            IL_0007:  ldloc.0 
//            IL_0008:  ldsfld class [Tizen.NUI.Xaml.Core]Tizen.NUI.Xaml.BindableProperty [Tizen.NUI.Xaml.Core]Tizen.NUI.Xaml.Label::TextProperty
//            IL_000d:  ldstr "foo"
//            IL_0012:  callvirt instance void class [Tizen.NUI.Xaml.Core]Tizen.NUI.Xaml.BindableObject::SetValue(class [Tizen.NUI.Xaml.Core]Tizen.NUI.Xaml.BindableProperty, object)

            yield return Create(Ldloc, parent);
            yield return Create(Ldsfld, bpRef);

            if (valueNode != null) {
                foreach (var instruction in valueNode.PushConvertedValue(context, bpRef, valueNode.PushServiceProvider(context, bpRef:bpRef), true, false))
                    yield return instruction;
            } else if (elementNode != null) {
                var bpTypeRef = bpRef.GetBindablePropertyType(iXmlLineInfo, module);
                var varDef = context.Variables[elementNode];
                var varType = varDef.VariableType;
                var implicitOperator = varDef.VariableType.GetImplicitOperatorTo(bpTypeRef, module);
                yield return Create(Ldloc, varDef);
                if (implicitOperator != null) {
                    yield return Create(Call, module.ImportReference(implicitOperator));
                    varType = module.ImportReference(bpTypeRef);
                }
                if (varType.IsValueType)
                    yield return Create(Box, varType);
            }
            yield return Create(Callvirt, module.ImportMethodReference((XamlCTask.bindingAssemblyName, XamlCTask.bindingNameSpace, "BindableObject"),
                                                                       methodName: "SetValue",
                                                                       parameterTypes: new[] {
                                                                           (XamlCTask.bindingAssemblyName, XamlCTask.bindingNameSpace, "BindableProperty"),
                                                                           ("mscorlib", "System", "Object"),
                                                                       }));
        }

        static IEnumerable<Instruction> GetValue(VariableDefinition parent, FieldReference bpRef, IXmlLineInfo iXmlLineInfo, ILContext context, out TypeReference propertyType)
        {
            var module = context.Body.Method.Module;
            propertyType = bpRef.GetBindablePropertyType(iXmlLineInfo, module);

            return new[] {
                Create(Ldloc, parent),
                Create(Ldsfld, bpRef),
                Create(Callvirt,  module.ImportMethodReference((XamlCTask.bindingAssemblyName, XamlCTask.bindingNameSpace, "BindableObject"),
                                                               methodName: "GetValue",
                                                               parameterTypes: new[] { (XamlCTask.bindingAssemblyName, XamlCTask.bindingNameSpace, "BindableProperty") })),
            };
        }

        static bool CanSet(VariableDefinition parent, string localName, INode node, ILContext context)
        {
            var module = context.Body.Method.Module;
            TypeReference declaringTypeReference;
            var property = parent.VariableType.GetProperty(pd => pd.Name == localName, out declaringTypeReference);
            if (property == null)
                return false;
            var propertyType = property.ResolveGenericPropertyType(declaringTypeReference, module);
            var propertySetter = property.SetMethod;
            if (propertySetter == null || !propertySetter.IsPublic || propertySetter.IsStatic)
                return false;

            var valueNode = node as ValueNode;
            if (valueNode != null && valueNode.CanConvertValue(context.Body.Method.Module, propertyType, new ICustomAttributeProvider[] { property, propertyType.ResolveCached()}))
                return true;

            var elementNode = node as IElementNode;
            if (elementNode == null)
                return false;

            var vardef = context.Variables [elementNode];
            var implicitOperator = vardef.VariableType.GetImplicitOperatorTo(propertyType, module);

            if (vardef.VariableType.InheritsFromOrImplements(propertyType))
                return true;
            if (implicitOperator != null)
                return true;
            if (propertyType.FullName == "System.Object")
                return true;

            //I'd like to get rid of this condition. This comment used to be //TODO replace latest check by a runtime type check
            if (vardef.VariableType.FullName == "System.Object")
                return true;

            return false;
        }

        static bool CanGet(VariableDefinition parent, string localName, ILContext context, out TypeReference propertyType)
        {
            var module = context.Body.Method.Module;
            propertyType = null;
            TypeReference declaringTypeReference;
            var property = parent.VariableType.GetProperty(pd => pd.Name == localName, out declaringTypeReference);
            if (property == null)
                return false;
            var propertyGetter = property.GetMethod;
            if (propertyGetter == null || !propertyGetter.IsPublic || propertyGetter.IsStatic)
                return false;

            module.ImportReference(parent.VariableType.ResolveCached());
            var propertyGetterRef = module.ImportReference(module.ImportReference(propertyGetter).ResolveGenericParameters(declaringTypeReference, module));
            propertyGetterRef.ImportTypes(module);
            propertyType = propertyGetterRef.ReturnType.ResolveGenericParameters(declaringTypeReference);

            return true;
        }

        static IEnumerable<Instruction> Set(VariableDefinition parent, string localName, INode node, IXmlLineInfo iXmlLineInfo, ILContext context)
        {
            var module = context.Body.Method.Module;
            TypeReference declaringTypeReference;
            var property = parent.VariableType.GetProperty(pd => pd.Name == localName, out declaringTypeReference);
            var propertySetter = property.SetMethod;

//            IL_0007:  ldloc.0
//            IL_0008:  ldstr "foo"
//            IL_000d:  callvirt instance void class [Tizen.NUI.Xaml.Core]Tizen.NUI.Xaml.Label::set_Text(string)

            module.ImportReference(parent.VariableType.ResolveCached());
            var propertySetterRef = module.ImportReference(module.ImportReference(propertySetter).ResolveGenericParameters(declaringTypeReference, module));
            propertySetterRef.ImportTypes(module);
            var propertyType = property.ResolveGenericPropertyType(declaringTypeReference, module);
            var valueNode = node as ValueNode;
            var elementNode = node as IElementNode;

            //if it's a value type, load the address so we can invoke methods on it
            if (parent.VariableType.IsValueType)
                yield return Instruction.Create(OpCodes.Ldloca, parent);
            else
                yield return Instruction.Create(OpCodes.Ldloc, parent);

            if (valueNode != null) {
                foreach (var instruction in valueNode.PushConvertedValue(context, propertyType, new ICustomAttributeProvider [] { property, propertyType.ResolveCached() }, valueNode.PushServiceProvider(context, propertyRef:property), false, true))
                    yield return instruction;
                if (parent.VariableType.IsValueType)
                    yield return Instruction.Create(OpCodes.Call, propertySetterRef);
                else
                    yield return Instruction.Create(OpCodes.Callvirt, propertySetterRef);
            } else if (elementNode != null) {
                var vardef = context.Variables [elementNode];
                var implicitOperator = vardef.VariableType.GetImplicitOperatorTo(propertyType, module);
                yield return Instruction.Create(OpCodes.Ldloc, vardef);
                if (!vardef.VariableType.InheritsFromOrImplements(propertyType) && implicitOperator != null) {
//                    IL_000f:  call !0 class [Tizen.NUI.Xaml.Core]Tizen.NUI.Xaml.OnPlatform`1<bool>::op_Implicit(class [Tizen.NUI.Xaml.Core]Tizen.NUI.Xaml.OnPlatform`1<!0>)
                    yield return Instruction.Create(OpCodes.Call, module.ImportReference(implicitOperator));
                } else if (!vardef.VariableType.IsValueType && propertyType.IsValueType)
                    yield return Instruction.Create(OpCodes.Unbox_Any, module.ImportReference(propertyType));
                else if (vardef.VariableType.IsValueType && propertyType.FullName == "System.Object")
                    yield return Instruction.Create(OpCodes.Box, vardef.VariableType);
                if (parent.VariableType.IsValueType)
                    yield return Instruction.Create(OpCodes.Call, propertySetterRef);
                else
                    yield return Instruction.Create(OpCodes.Callvirt, propertySetterRef);
            }
        }

        static IEnumerable<Instruction> Get(VariableDefinition parent, string localName, IXmlLineInfo iXmlLineInfo, ILContext context, out TypeReference propertyType)
        {
            var module = context.Body.Method.Module;
            var property = parent.VariableType.GetProperty(pd => pd.Name == localName, out var declaringTypeReference);
            var propertyGetter = property.GetMethod;

            module.ImportReference(parent.VariableType.ResolveCached());
            var propertyGetterRef = module.ImportReference(module.ImportReference(propertyGetter).ResolveGenericParameters(declaringTypeReference, module));
            propertyGetterRef.ImportTypes(module);
            propertyType = propertyGetterRef.ReturnType.ResolveGenericParameters(declaringTypeReference);

            if (parent.VariableType.IsValueType)
                return new[] {
                    Instruction.Create(OpCodes.Ldloca, parent),
                    Instruction.Create(OpCodes.Call, propertyGetterRef),
                };
            else
                return new[] {
                    Instruction.Create(OpCodes.Ldloc, parent),
                    Instruction.Create(OpCodes.Callvirt, propertyGetterRef),
                };
        }

        static bool CanAdd(VariableDefinition parent, XmlName propertyName, INode node, IXmlLineInfo lineInfo, ILContext context)
        {
            var module = context.Body.Method.Module;
            var localName = propertyName.LocalName;
            bool attached;
            var bpRef = GetBindablePropertyReference(parent, propertyName.NamespaceURI, ref localName, out attached, context, lineInfo);
            TypeReference propertyType;

            if (   !CanGetValue(parent, bpRef, attached, null, context, out propertyType)
                && !CanGet(parent, localName, context, out propertyType))
                return false;

            //TODO check md.Parameters[0] type
            var adderTuple = propertyType.GetMethods(md => md.Name == "Add" && md.Parameters.Count == 1, module).FirstOrDefault();
            if (adderTuple == null)
                return false;

            return true;
        }

        static Dictionary<VariableDefinition, IList<string>> resourceNamesInUse = new Dictionary<VariableDefinition, IList<string>>();
        static bool CanAddToResourceDictionary(VariableDefinition parent, TypeReference collectionType, IElementNode node, IXmlLineInfo lineInfo, ILContext context)
        {
            if (   collectionType.FullName != "Tizen.NUI.Binding.ResourceDictionary"
                && collectionType.ResolveCached().BaseType?.FullName != "Tizen.NUI.Binding.ResourceDictionary")
                return false;


            if (node.Properties.ContainsKey(XmlName.xKey)) {
                var key = (node.Properties[XmlName.xKey] as ValueNode).Value as string;
                if (!resourceNamesInUse.TryGetValue(parent, out var names))
                    resourceNamesInUse[parent] = (names = new List<string>());
                if (names.Contains(key))
                    throw new XamlParseException($"A resource with the key '{key}' is already present in the ResourceDictionary.", lineInfo);
                names.Add(key);
                return true;
            }

            //is there a RD.Add() overrides that accepts this ?
            var nodeTypeRef = context.Variables[node].VariableType;
            var module = context.Body.Method.Module;
            if (module.ImportMethodReference((XamlCTask.bindingAssemblyName, XamlCTask.bindingNameSpace, "ResourceDictionary"),
                                             methodName: "Add",
                                             parameterTypes: new[] { (nodeTypeRef.Scope.Name, nodeTypeRef.Namespace, nodeTypeRef.Name) }) != null)
                return true;

            throw new XamlParseException("resources in ResourceDictionary require a x:Key attribute", lineInfo);
        }

        static IEnumerable<Instruction> Add(VariableDefinition parent, XmlName propertyName, INode node, IXmlLineInfo iXmlLineInfo, ILContext context)
        {
            var module = context.Body.Method.Module;
            var elementNode = node as IElementNode;
            var vardef = context.Variables [elementNode];

            TypeReference propertyType;
            foreach (var instruction in GetPropertyValue(parent, propertyName, context, iXmlLineInfo, out propertyType))
                yield return instruction;

            if (CanAddToResourceDictionary(parent, propertyType, elementNode, iXmlLineInfo, context)) {
                foreach (var instruction in AddToResourceDictionary(elementNode, iXmlLineInfo, context))
                    yield return instruction;
                yield break;
            }

            var adderTuple = propertyType.GetMethods(md => md.Name == "Add" && md.Parameters.Count == 1, module).FirstOrDefault();
            var adderRef = module.ImportReference(adderTuple.Item1);
            adderRef = module.ImportReference(adderRef.ResolveGenericParameters(adderTuple.Item2, module));
            var childType = GetParameterType(adderRef.Parameters[0]);
            var implicitOperator = vardef.VariableType.GetImplicitOperatorTo(childType, module);

            yield return Instruction.Create(OpCodes.Ldloc, vardef);
            if (implicitOperator != null)
                yield return Instruction.Create(OpCodes.Call, module.ImportReference(implicitOperator));
            if (implicitOperator == null && vardef.VariableType.IsValueType && !childType.IsValueType)
                yield return Instruction.Create(OpCodes.Box, vardef.VariableType);
            yield return Instruction.Create(OpCodes.Callvirt, adderRef);
            if (adderRef.ReturnType.FullName != "System.Void")
                yield return Instruction.Create(OpCodes.Pop);
        }

        static IEnumerable<Instruction> AddToResourceDictionary(IElementNode node, IXmlLineInfo lineInfo, ILContext context)
        {
            var module = context.Body.Method.Module;

            if (node.Properties.ContainsKey(XmlName.xKey)) {
//                IL_0014:  ldstr "key"
//                IL_0019:  ldstr "foo"
//                IL_001e:  callvirt instance void class [Tizen.NUI.Xaml.Core]Tizen.NUI.Xaml.ResourceDictionary::Add(string, object)
                yield return Create(Ldstr, (node.Properties[XmlName.xKey] as ValueNode).Value as string);
                var varDef = context.Variables[node];
                yield return Create(Ldloc, varDef);
                if (varDef.VariableType.IsValueType)
                    yield return Create(Box, module.ImportReference(varDef.VariableType));
                yield return Create(Callvirt, module.ImportMethodReference((XamlCTask.bindingAssemblyName, XamlCTask.bindingNameSpace, "ResourceDictionary"),
                                                                           methodName: "Add",
                                                                           parameterTypes: new[] {
                                                                               ("mscorlib", "System", "String"),
                                                                               ("mscorlib", "System", "Object"),
                                                                           }));
                yield break;
            }

            var nodeTypeRef = context.Variables[node].VariableType;
            yield return Create(Ldloc, context.Variables[node]);
            yield return Create(Callvirt, module.ImportMethodReference((XamlCTask.bindingAssemblyName, XamlCTask.bindingNameSpace, "ResourceDictionary"),
                                                                       methodName: "Add",
                                                                       parameterTypes: new[] { (nodeTypeRef.Scope.Name, nodeTypeRef.Namespace, nodeTypeRef.Name) }));
            yield break;
        }

        public static TypeReference GetParameterType(ParameterDefinition param)
        {
            if (!param.ParameterType.IsGenericParameter)
                return param.ParameterType;
            var type = (param.Method as MethodReference).DeclaringType as GenericInstanceType;
            return type.GenericArguments [0];
        }

        static bool GetNameAndTypeRef(ref TypeReference elementType, string namespaceURI, ref string localname,
            ILContext context, IXmlLineInfo lineInfo)
        {
            var dotIdx = localname.IndexOf('.');
            if (dotIdx > 0)
            {
                var typename = localname.Substring(0, dotIdx);
                localname = localname.Substring(dotIdx + 1);
                elementType = new XmlType(namespaceURI, typename, null).GetTypeReference(context.Body.Method.Module, lineInfo);
                return true;
            }
            return false;
        }

        static void SetDataTemplate(IElementNode parentNode, ElementNode node, ILContext parentContext,
            IXmlLineInfo xmlLineInfo)
        {
            var parentVar = parentContext.Variables[parentNode];
            //Push the DataTemplate to the stack, for setting the template
            parentContext.IL.Emit(OpCodes.Ldloc, parentVar);

            //Create nested class
            //            .class nested private auto ansi sealed beforefieldinit '<Main>c__AnonStorey0'
            //            extends [mscorlib]System.Object


            var module = parentContext.Module;
            var anonType = new TypeDefinition(
                null,
                "_" + parentContext.Body.Method.Name + "_anonXamlCDataTemplate_" + dtcount++,
                TypeAttributes.BeforeFieldInit |
                TypeAttributes.Sealed |
                TypeAttributes.NestedPrivate) {
                BaseType = module.TypeSystem.Object,
                CustomAttributes = {
                    new CustomAttribute (module.ImportCtorReference(("mscorlib", "System.Runtime.CompilerServices", "CompilerGeneratedAttribute"), parameterTypes: null)),
                }
            };

            parentContext.Body.Method.DeclaringType.NestedTypes.Add(anonType);
            var ctor = anonType.AddDefaultConstructor();

            var loadTemplate = new MethodDefinition("LoadDataTemplate",
                MethodAttributes.Assembly | MethodAttributes.HideBySig,
                module.TypeSystem.Object);
            loadTemplate.Body.InitLocals = true;
            anonType.Methods.Add(loadTemplate);

            var parentValues = new FieldDefinition("parentValues", FieldAttributes.Assembly, module.ImportArrayReference(("mscorlib", "System", "Object")));
            anonType.Fields.Add(parentValues);

            TypeReference rootType = null;
            var vdefRoot = parentContext.Root as VariableDefinition;
            if (vdefRoot != null)
                rootType = vdefRoot.VariableType;
            var fdefRoot = parentContext.Root as FieldDefinition;
            if (fdefRoot != null)
                rootType = fdefRoot.FieldType;

            var root = new FieldDefinition("root", FieldAttributes.Assembly, rootType);
            anonType.Fields.Add(root);

            //Fill the loadTemplate Body
            var templateIl = loadTemplate.Body.GetILProcessor();
            templateIl.Emit(OpCodes.Nop);
            var templateContext = new ILContext(templateIl, loadTemplate.Body, null, module, parentValues)
            {
                Root = root
            };
            node.Accept(new CreateObjectVisitor(templateContext), null);
            node.Accept(new SetNamescopesAndRegisterNamesVisitor(templateContext), null);
            node.Accept(new SetFieldVisitor(templateContext), null);
            node.Accept(new SetResourcesVisitor(templateContext), null);
            node.Accept(new SetPropertiesVisitor(templateContext, stopOnResourceDictionary: true), null);

            templateIl.Emit(OpCodes.Ldloc, templateContext.Variables[node]);
            templateIl.Emit(OpCodes.Ret);

            //Instanciate nested class
            var parentIl = parentContext.IL;
            parentIl.Emit(OpCodes.Newobj, ctor);

            //Copy required local vars
            parentIl.Emit(OpCodes.Dup); //Duplicate the nestedclass instance
            parentIl.Append(node.PushParentObjectsArray(parentContext));
            parentIl.Emit(OpCodes.Stfld, parentValues);
            parentIl.Emit(OpCodes.Dup); //Duplicate the nestedclass instance
            if (parentContext.Root is VariableDefinition)
                parentIl.Emit(OpCodes.Ldloc, parentContext.Root as VariableDefinition);
            else if (parentContext.Root is FieldDefinition)
            {
                parentIl.Emit(OpCodes.Ldarg_0);
                parentIl.Emit(OpCodes.Ldfld, parentContext.Root as FieldDefinition);
            }
            else
                throw new InvalidProgramException();
            parentIl.Emit(OpCodes.Stfld, root);

            //SetDataTemplate
            parentIl.Emit(Ldftn, loadTemplate);
            parentIl.Emit(Newobj, module.ImportCtorReference(("mscorlib", "System", "Func`1"),
                                                             classArguments: new[] { ("mscorlib", "System", "Object") },
                                                             paramCount: 2));

            var setterRef = module.ImportPropertySetterReference((XamlCTask.bindingAssemblyName, XamlCTask.bindingNameSpace, "IDataTemplate"), propertyName: "LoadTemplate");
            parentContext.IL.Emit(OpCodes.Callvirt, setterRef);

            loadTemplate.Body.Optimize();
        }

        bool TrySetRuntimeName(XmlName propertyName, VariableDefinition variableDefinition, ValueNode node)
        {
            if (propertyName != XmlName.xName)
                return false;

            var attributes = variableDefinition.VariableType.ResolveCached()
                .CustomAttributes.Where(attribute => attribute.AttributeType.FullName == "Tizen.NUI.Xaml.RuntimeNamePropertyAttribute").ToList();

            if (!attributes.Any())
                return false;

            var runTimeName = attributes[0].ConstructorArguments[0].Value as string;

            if (string.IsNullOrEmpty(runTimeName)) 
                return false;

            Context.IL.Append(SetPropertyValue(variableDefinition, new XmlName("", runTimeName), node, Context, node));
            return true;
        }
    }
}
 
