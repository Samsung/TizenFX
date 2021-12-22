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
using System.Reflection;
using System.Xml;
using Tizen.NUI.Binding.Internals;
using Tizen.NUI.Binding;


namespace Tizen.NUI.Xaml
{
    internal class CreateValuesVisitor : IXamlNodeVisitor
    {
        public CreateValuesVisitor(HydrationContext context)
        {
            Context = context;
        }

        Dictionary<INode, object> Values
        {
            get { return Context.Values; }
        }

        HydrationContext Context { get; }

        public TreeVisitingMode VisitingMode => TreeVisitingMode.BottomUp;
        public bool StopOnDataTemplate => true;
        public bool StopOnResourceDictionary => false;
        public bool VisitNodeOnDataTemplate => false;
        public bool SkipChildren(INode node, INode parentNode) => false;
        public bool IsResourceDictionary(ElementNode node) => typeof(ResourceDictionary).IsAssignableFrom(Context.Types[node]);

        public void Visit(ValueNode node, INode parentNode)
        {
            Values[node] = node.Value;
        }

        public void Visit(MarkupNode node, INode parentNode)
        {
        }

        public void Visit(ElementNode node, INode parentNode)
        {
            object value = null;

            XamlParseException xpe;
            var type = XamlParser.GetElementType(node.XmlType, node, Context.RootElement?.GetType().GetTypeInfo().Assembly,
                out xpe);
            if (type == null)
                throw new ArgumentNullException(null, "type should not be null");
            if (xpe != null)
                throw xpe;

            Context.Types[node] = type;
            string ctorargname;
            if (IsXaml2009LanguagePrimitive(node))
                value = CreateLanguagePrimitive(type, node);
            else if (node.Properties.ContainsKey(XmlName.xArguments) || node.Properties.ContainsKey(XmlName.xFactoryMethod))
                value = CreateFromFactory(type, node);
            else if (
                type.GetTypeInfo()
                    .DeclaredConstructors.Any(
                        ci =>
                            ci.IsPublic && ci.GetParameters().Length != 0 &&
                            ci.GetParameters().All(pi => pi.CustomAttributes.Any(attr => attr.AttributeType == typeof(ParameterAttribute)))) &&
                ValidateCtorArguments(type, node, out ctorargname))
                value = CreateFromParameterizedConstructor(type, node);
            else if (!type.GetTypeInfo().DeclaredConstructors.Any(ci => ci.IsPublic && ci.GetParameters().Length == 0) &&
                     !ValidateCtorArguments(type, node, out ctorargname))
            {
                throw new XamlParseException($"The Property {ctorargname} is required to create a {type?.FullName} object.", node);
            }
            else
            {
                //this is a trick as the DataTemplate parameterless ctor is internal, and we can't CreateInstance(..., false) on WP7
                try
                {
                    if (type == typeof(DataTemplate))
                        value = new DataTemplate();
                    if (type == typeof(ControlTemplate))
                        value = new ControlTemplate();
                    if (value == null && node.CollectionItems.Any() && node.CollectionItems.First() is ValueNode)
                    {
                        var serviceProvider = new XamlServiceProvider(node, Context);
                        var converted = ((ValueNode)node.CollectionItems.First()).Value.ConvertTo(type, () => type.GetTypeInfo(),
                            serviceProvider);
                        if (converted != null && converted.GetType() == type)
                            value = converted;
                    }
                    if (value == null)
                    {
                        if (type.GetTypeInfo().DeclaredConstructors.Any(ci => ci.IsPublic && ci.GetParameters().Length == 0))
                        {
                            //default constructor
                            value = Activator.CreateInstance(type);
                        }
                        else
                        {
                            ConstructorInfo constructorInfo = null;

                            //constructor with all default parameters
                            foreach (var constructor in type.GetConstructors())
                            {
                                if (!constructor.IsStatic)
                                {
                                    bool areAllParamsDefault = true;

                                    foreach (var param in constructor.GetParameters())
                                    {
                                        if (!param.HasDefaultValue)
                                        {
                                            areAllParamsDefault = false;
                                            break;
                                        }
                                    }

                                    if (areAllParamsDefault)
                                    {
                                        if (null == constructorInfo)
                                        {
                                            constructorInfo = constructor;
                                        }
                                        else
                                        {
                                            throw new XamlParseException($"{type.FullName} has more than one constructor which params are all default.", node);
                                        }
                                    }
                                }
                            }

                            if (null == constructorInfo)
                            {
                                throw new XamlParseException($"{type.FullName} has no constructor which params are all default.", node);
                            }

                            List<object> defaultParams = new List<object>();
                            foreach (var param in constructorInfo.GetParameters())
                            {
                                defaultParams.Add(param.DefaultValue);
                            }

                            value = Activator.CreateInstance(type, defaultParams.ToArray());
                        }
                        if (value is Element element)
                        {
                            if (null != Application.Current)
                            {
                                Application.Current.XamlResourceChanged += element.OnResourcesChanged;
                            }

                            element.IsCreateByXaml = true;
                            element.LineNumber = node.LineNumber;
                            element.LinePosition = node.LinePosition;
                        }
                    }
                }
                catch (TargetInvocationException e)
                {
                    if (e.InnerException is XamlParseException || e.InnerException is XmlException)
                        throw e.InnerException;
                    throw;
                }
            }

            Values[node] = value;

            var markup = value as IMarkupExtension;
            if (markup != null && (value is TypeExtension || value is StaticExtension || value is ArrayExtension))
            {
                var serviceProvider = new XamlServiceProvider(node, Context);

                var visitor = new ApplyPropertiesVisitor(Context);
                foreach (var cnode in node.Properties.Values.ToList())
                    cnode.Accept(visitor, node);
                foreach (var cnode in node.CollectionItems)
                    cnode.Accept(visitor, node);

                value = markup.ProvideValue(serviceProvider);

                INode xKey;
                if (!node.Properties.TryGetValue(XmlName.xKey, out xKey))
                    xKey = null;

                node.Properties.Clear();
                node.CollectionItems.Clear();

                if (xKey != null)
                    node.Properties.Add(XmlName.xKey, xKey);

                Values[node] = value;
            }

            if (value is BindableObject)
                NameScope.SetNameScope(value as BindableObject, node.Namescope);
        }

        public void Visit(RootNode node, INode parentNode)
        {
            var rnode = (XamlLoader.RuntimeRootNode)node;
            Values[node] = rnode.Root;
            Context.Types[node] = rnode.Root.GetType();
            var bindableRoot = rnode.Root as BindableObject;
            if (bindableRoot != null)
                NameScope.SetNameScope(bindableRoot, node.Namescope);
        }

        public void Visit(ListNode node, INode parentNode)
        {
            //this is a gross hack to keep ListNode alive. ListNode must go in favor of Properties
            XmlName name;
            if (ApplyPropertiesVisitor.TryGetPropertyName(node, parentNode, out name))
                node.XmlName = name;
        }

        bool ValidateCtorArguments(Type nodeType, IElementNode node, out string missingArgName)
        {
            missingArgName = null;
            var ctorInfo =
                nodeType.GetTypeInfo()
                    .DeclaredConstructors.FirstOrDefault(
                        ci =>
                            ci.GetParameters().Length != 0 && ci.IsPublic &&
                            ci.GetParameters().All(pi => pi.CustomAttributes.Any(attr => attr.AttributeType == typeof(ParameterAttribute))));
            if (ctorInfo == null)
                return true;
            foreach (var parameter in ctorInfo.GetParameters())
            {
                // Modify the namespace
                var propname =
                    parameter.CustomAttributes.First(ca => ca.AttributeType.FullName == "Tizen.NUI.Binding.ParameterAttribute")?
                        .ConstructorArguments.First()
                        .Value as string;
                if (!node.Properties.ContainsKey(new XmlName("", propname)))
                {
                    missingArgName = propname;
                    return false;
                }
            }

            return true;
        }

        public object CreateFromParameterizedConstructor(Type nodeType, IElementNode node)
        {
            var ctorInfo =
                nodeType.GetTypeInfo()
                    .DeclaredConstructors.FirstOrDefault(
                        ci =>
                            ci.GetParameters().Length != 0 && ci.IsPublic &&
                            ci.GetParameters().All(pi => pi.CustomAttributes.Any(attr => attr.AttributeType == typeof(ParameterAttribute))));
            object[] arguments = CreateArgumentsArray(node, ctorInfo);

            if (arguments != null)
            {
                return ctorInfo?.Invoke(arguments);
            }
            else
            {
                return null;
            }
        }

        public object CreateFromFactory(Type nodeType, IElementNode node)
        {
            object[] arguments = CreateArgumentsArray(node);

            if (!node.Properties.ContainsKey(XmlName.xFactoryMethod))
            {
                //non-default ctor
                object ret = Activator.CreateInstance(nodeType, BindingFlags.CreateInstance | BindingFlags.Public | BindingFlags.Instance | BindingFlags.OptionalParamBinding, null, arguments, CultureInfo.CurrentCulture);
                if (ret is Element element)
                {
                    if (null != Application.Current)
                    {
                        Application.Current.XamlResourceChanged += element.OnResourcesChanged;
                    }

                    element.IsCreateByXaml = true;
                    element.LineNumber = (node as ElementNode)?.LineNumber ?? -1;
                    element.LinePosition = (node as ElementNode)?.LinePosition ?? -1;
                }
                return ret;
            }

            var factoryMethod = ((string)((ValueNode)node.Properties[XmlName.xFactoryMethod]).Value);
            Type[] types = arguments == null ? System.Array.Empty<Type>() : arguments.Select(a => a.GetType()).ToArray();
            Func<MethodInfo, bool> isMatch = m =>
            {
                if (m.Name != factoryMethod)
                    return false;
                var p = m.GetParameters();
                if (p.Length != types.Length)
                    return false;
                if (!m.IsStatic)
                    return false;
                for (var i = 0; i < p.Length; i++)
                {
                    if ((p[i].ParameterType.IsAssignableFrom(types[i])))
                        continue;
                    var op_impl = p[i].ParameterType.GetImplicitConversionOperator(fromType: types[i], toType: p[i].ParameterType)
                                ?? types[i].GetImplicitConversionOperator(fromType: types[i], toType: p[i].ParameterType);

                    if (op_impl == null)
                        return false;
                    arguments[i] = op_impl.Invoke(null, new[] { arguments[i] });
                }
                return true;
            };
            var mi = nodeType.GetRuntimeMethods().FirstOrDefault(isMatch);
            if (mi == null)
            {
                if (node is ElementNode elementNode)
                {
                    var nodeTypeExtension = XamlParser.GetElementTypeExtension(node.XmlType, elementNode, Context.RootElement?.GetType().GetTypeInfo().Assembly);
                    mi = nodeTypeExtension?.GetRuntimeMethods().FirstOrDefault(isMatch);
                }
            }

            if (mi == null)
            {
                throw new MissingMemberException($"No static method found for {nodeType.FullName}::{factoryMethod} ({string.Join(", ", types.Select(t => t.FullName))})");
            }

            return mi.Invoke(null, arguments);
        }

        public object[] CreateArgumentsArray(IElementNode enode)
        {
            if (!enode.Properties.ContainsKey(XmlName.xArguments))
                return null;
            var node = enode.Properties[XmlName.xArguments];
            var elementNode = node as ElementNode;
            if (elementNode != null)
            {
                var array = new object[1];
                array[0] = Values[elementNode];

                if (array[0].GetType().IsClass)
                {
                    elementNode.Accept(new ApplyPropertiesVisitor(Context, true), null);
                }

                return array;
            }

            var listnode = node as ListNode;
            if (listnode != null)
            {
                var array = new object[listnode.CollectionItems.Count];
                for (var i = 0; i < listnode.CollectionItems.Count; i++)
                    array[i] = Values[(ElementNode)listnode.CollectionItems[i]];
                return array;
            }
            return null;
        }

        public object[] CreateArgumentsArray(IElementNode enode, ConstructorInfo ctorInfo)
        {
            if (ctorInfo != null)
            {
                var n = ctorInfo.GetParameters().Length;
                var array = new object[n];
                for (var i = 0; i < n; i++)
                {
                    var parameter = ctorInfo.GetParameters()[i];
                    var propname =
                        parameter?.CustomAttributes?.First(attr => attr.AttributeType == typeof(ParameterAttribute))?
                            .ConstructorArguments.First()
                            .Value as string;
                    var name = new XmlName("", propname);
                    INode node;
                    if (!enode.Properties.TryGetValue(name, out node))
                    {
                        String msg = "";
                        if (propname != null)
                        {
                            msg = String.Format("The Property {0} is required to create a {1} object.", propname, ctorInfo.DeclaringType.FullName);
                        }
                        else
                        {
                            msg = "propname is null.";
                        }
                        throw new XamlParseException(msg, enode as IXmlLineInfo);
                    }
                    if (!enode.SkipProperties.Contains(name))
                        enode.SkipProperties.Add(name);
                    var value = Context.Values[node];
                    var serviceProvider = new XamlServiceProvider(enode, Context);
                    var convertedValue = value?.ConvertTo(parameter?.ParameterType, () => parameter, serviceProvider);
                    array[i] = convertedValue;
                }
                return array;
            }

            return null;
        }

        static bool IsXaml2009LanguagePrimitive(IElementNode node)
        {
            return node.NamespaceURI == XamlParser.X2009Uri;
        }

        static object CreateLanguagePrimitive(Type nodeType, IElementNode node)
        {
            object value = null;
            if (nodeType == typeof(string))
                value = String.Empty;
            else if (nodeType == typeof(Uri))
                value = null;
            else
            {
                value = Activator.CreateInstance(nodeType);
                if (value is Element element)
                {
                    if (null != Application.Current)
                    {
                        Application.Current.XamlResourceChanged += element.OnResourcesChanged;
                    }

                    element.IsCreateByXaml = true;
                    element.LineNumber = (node as ElementNode)?.LineNumber ?? -1;
                    element.LinePosition = (node as ElementNode)?.LinePosition ?? -1;
                }
            }

            if (node.CollectionItems.Count == 1 && node.CollectionItems[0] is ValueNode &&
                ((ValueNode)node.CollectionItems[0]).Value is string)
            {
                var valuestring = ((ValueNode)node.CollectionItems[0]).Value as string;

                if (nodeType == typeof(SByte))
                {
                    sbyte retval;
                    if (sbyte.TryParse(valuestring, NumberStyles.Number, CultureInfo.InvariantCulture, out retval))
                        return retval;
                }
                if (nodeType == typeof(Int16))
                {
                    return Convert.ToInt16(GraphicsTypeManager.Instance.ConvertScriptToPixel(valuestring));
                }
                if (nodeType == typeof(Int32))
                {
                    return Convert.ToInt32(GraphicsTypeManager.Instance.ConvertScriptToPixel(valuestring));
                }
                if (nodeType == typeof(Int64))
                {
                    return Convert.ToInt64(GraphicsTypeManager.Instance.ConvertScriptToPixel(valuestring));
                }
                if (nodeType == typeof(Byte))
                {
                    byte retval;
                    if (byte.TryParse(valuestring, NumberStyles.Number, CultureInfo.InvariantCulture, out retval))
                        return retval;
                }
                if (nodeType == typeof(UInt16))
                {
                    return Convert.ToUInt16(GraphicsTypeManager.Instance.ConvertScriptToPixel(valuestring));
                }
                if (nodeType == typeof(UInt32))
                {
                    return Convert.ToUInt32(GraphicsTypeManager.Instance.ConvertScriptToPixel(valuestring));
                }
                if (nodeType == typeof(UInt64))
                {
                    return Convert.ToUInt64(GraphicsTypeManager.Instance.ConvertScriptToPixel(valuestring));
                }
                if (nodeType == typeof(Single))
                {
                    return GraphicsTypeManager.Instance.ConvertScriptToPixel(valuestring);
                }
                if (nodeType == typeof(Double))
                {
                    return Convert.ToDouble(GraphicsTypeManager.Instance.ConvertScriptToPixel(valuestring));
                }
                if (nodeType == typeof(Boolean))
                {
                    bool outbool;
                    if (bool.TryParse(valuestring, out outbool))
                        return outbool;
                }
                if (nodeType == typeof(TimeSpan))
                {
                    TimeSpan retval;
                    if (TimeSpan.TryParse(valuestring, CultureInfo.InvariantCulture, out retval))
                        return retval;
                }
                if (nodeType == typeof(char))
                {
                    char retval;
                    if (char.TryParse(valuestring, out retval))
                        return retval;
                }
                if (nodeType == typeof(string))
                    return valuestring;
                if (nodeType == typeof(decimal))
                {
                    decimal retval;
                    if (decimal.TryParse(valuestring, NumberStyles.Number, CultureInfo.InvariantCulture, out retval))
                        return retval;
                }

                else if (nodeType == typeof(Uri))
                {
                    Uri retval;
                    if (Uri.TryCreate(valuestring, UriKind.RelativeOrAbsolute, out retval))
                        return retval;
                }
            }
            return value;
        }
    }
}
