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
//
// XamlLoader.cs
//
// Author:
//       Stephane Delcroix <stephane@mi8.be>
//
// Copyright (c) 2018 Mobile Inception
// Copyright (c) 2018-2014 Xamarin, Inc
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Binding.Internals;

namespace Tizen.NUI.Xaml.Internals
{
    /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("Replaced by ResourceLoader")]
    public static class XamlLoader
    {
        static Func<Type, string> xamlFileProvider;

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Func<Type, string> XamlFileProvider
        {
            get { return xamlFileProvider; }
            internal set
            {
                xamlFileProvider = value;
                Tizen.NUI.Xaml.DesignMode.IsDesignModeEnabled = true;
                //¯\_(??_/¯ the previewer forgot to set that bool
                DoNotThrowOnExceptions = value != null;
            }
        }

        internal static bool DoNotThrowOnExceptions { get; set; }
    }
}

namespace Tizen.NUI.Xaml
{
    static internal class XamlLoader
    {
        public static void Load(object view, Type callingType)
        {
            try
            {
                var xaml = GetXamlForType(callingType);
                if (string.IsNullOrEmpty(xaml))
                    throw new XamlParseException(string.Format("Can't get xaml from type {0}", callingType), new XmlLineInfo());
                Load(view, xaml);
            }
            catch (XamlParseException e)
            {
                Tizen.Log.Fatal("NUI", "XamlParseException e.Message: " + e.Message);
                Console.WriteLine("\n[FATAL] XamlParseException e.Message: {0}\n", e.Message);
            }
        }

        public static T LoadObject<T>(string path)
        {
            var xaml = GetAnimationXaml(path);
            if (string.IsNullOrEmpty(xaml))
                throw new XamlParseException(string.Format("No embeddedresource found for {0}", path), new XmlLineInfo());
            Type type = typeof(T);
            T ret = (T)type.Assembly.CreateInstance(type.FullName);

            NameScopeExtensions.PushElement(ret);

            using (var textReader = new StringReader(xaml))
            using (var reader = XmlReader.Create(textReader))
            {
                while (reader.Read())
                {
                    //Skip until element
                    if (reader.NodeType == XmlNodeType.Whitespace)
                        continue;
                    if (reader.NodeType == XmlNodeType.XmlDeclaration)
                        continue;
                    if (reader.NodeType != XmlNodeType.Element)
                    {
                        Debug.WriteLine("Unhandled node {0} {1} {2}", reader.NodeType, reader.Name, reader.Value);
                        continue;
                    }

                    var rootnode = new RuntimeRootNode(new XmlType(reader.NamespaceURI, reader.Name, null), ret, (IXmlNamespaceResolver)reader);
                    XamlParser.ParseXaml(rootnode, reader);
                    Visit(rootnode, new HydrationContext
                    {
                        RootElement = ret,
#pragma warning disable 0618
                        ExceptionHandler = ResourceLoader.ExceptionHandler ?? (Internals.XamlLoader.DoNotThrowOnExceptions ? e => { } : (Action<Exception>)null)
#pragma warning restore 0618
                    });
                    break;
                }
            }

            NameScopeExtensions.PopElement();
            return ret;
        }

        public static void Load(object view, string xaml)
        {
            using (var textReader = new StringReader(xaml))
            using (var reader = XmlReader.Create(textReader))
            {
                Load(view, reader);
            }
        }

        public static void Load(object view, XmlReader reader)
        {
            if (reader != null)
            {
                while (reader.Read())
                {
                    //Skip until element
                    if (reader.NodeType == XmlNodeType.Whitespace)
                        continue;
                    if (reader.NodeType == XmlNodeType.XmlDeclaration)
                        continue;
                    if (reader.NodeType != XmlNodeType.Element)
                    {
                        Debug.WriteLine("Unhandled node {0} {1} {2}", reader.NodeType, reader.Name, reader.Value);
                        continue;
                    }

                    if (view is Element)
                    {
                        (view as Element).IsCreateByXaml = true;
                    }

                    var rootnode = new RuntimeRootNode(new XmlType(reader.NamespaceURI, reader.Name, null), view, (IXmlNamespaceResolver)reader);
                    XamlParser.ParseXaml(rootnode, reader);
                    Visit(rootnode, new HydrationContext
                    {
                        RootElement = view,
#pragma warning disable 0618
                        ExceptionHandler = ResourceLoader.ExceptionHandler ?? (Internals.XamlLoader.DoNotThrowOnExceptions ? e => { } : (Action<Exception>)null)
#pragma warning restore 0618
                    });
                    break;
                }
            }
        }

        [Obsolete("Use the XamlFileProvider to provide xaml files. We will remove this when Cycle 8 hits Stable.")]
        public static object Create(string xaml, bool doNotThrow = false)
        {
            object inflatedView = null;
            using (var textreader = new StringReader(xaml))
            using (var reader = XmlReader.Create(textreader))
            {
                inflatedView = Create(reader, doNotThrow);
            }
            return inflatedView;
        }

        public static object Create(XmlReader reader, bool doNotThrow = false)
        {
            object inflatedView = null;
            if (reader != null)
            {
                while (reader.Read())
                {
                    //Skip until element
                    if (reader.NodeType == XmlNodeType.Whitespace)
                        continue;
                    if (reader.NodeType == XmlNodeType.XmlDeclaration)
                        continue;
                    if (reader.NodeType != XmlNodeType.Element)
                    {
                        Debug.WriteLine("Unhandled node {0} {1} {2}", reader.NodeType, reader.Name, reader.Value);
                        continue;
                    }

                    var rootnode = new RuntimeRootNode(new XmlType(reader.NamespaceURI, reader.Name, null), null, (IXmlNamespaceResolver)reader);
                    XamlParser.ParseXaml(rootnode, reader);
                    var visitorContext = new HydrationContext
                    {
                        ExceptionHandler = doNotThrow ? e => { } : (Action<Exception>)null,
                    };
                    var cvv = new CreateValuesVisitor(visitorContext);

                    // Visit Parameter Properties to create instance from parameterized constructor
                    var type = XamlParser.GetElementType(rootnode.XmlType, rootnode, null, out XamlParseException xpe);
                    if (xpe != null)
                        throw xpe;

                    var ctorInfo =
                        type.GetTypeInfo()
                            .DeclaredConstructors.FirstOrDefault(
                                ci =>
                                    ci.GetParameters().Length != 0 && ci.IsPublic &&
                                    ci.GetParameters().All(pi => pi.CustomAttributes.Any(attr => attr.AttributeType == typeof(ParameterAttribute))));
                    if (ctorInfo != null)
                    {
                        foreach (var parameter in ctorInfo.GetParameters())
                        {
                            var propname =
                                parameter.CustomAttributes.First(ca => ca.AttributeType.FullName == "Tizen.NUI.Binding.ParameterAttribute")?
                                    .ConstructorArguments.First()
                                    .Value as string;

                            var name = new XmlName("", propname);
                            if (rootnode.Properties.TryGetValue(name, out INode node) && node is ValueNode)
                            {
                                node.Accept(cvv, rootnode);
                            }
                        }
                    }


                    cvv.Visit((ElementNode)rootnode, null);
                    inflatedView = rootnode.Root = visitorContext.Values[rootnode];
                    visitorContext.RootElement = inflatedView as BindableObject;

                    Visit(rootnode, visitorContext);
                    break;
                }
            }
            return inflatedView;
        }

        static void Visit(RootNode rootnode, HydrationContext visitorContext)
        {
            rootnode.Accept(new XamlNodeVisitor((node, parent) => node.Parent = parent), null); //set parents for {StaticResource}
            rootnode.Accept(new ExpandMarkupsVisitor(visitorContext), null);
            rootnode.Accept(new PruneIgnoredNodesVisitor(), null);
            rootnode.Accept(new NamescopingVisitor(visitorContext), null); //set namescopes for {x:Reference}
            rootnode.Accept(new CreateValuesVisitor(visitorContext), null);
            rootnode.Accept(new RegisterXNamesVisitor(visitorContext), null);
            rootnode.Accept(new FillResourceDictionariesVisitor(visitorContext), null);
            rootnode.Accept(new ApplyPropertiesVisitor(visitorContext, true), null);
        }

        static string GetAnimationXaml(string animationXamlPath)
        {
            string xaml;
            if (File.Exists(animationXamlPath))
            {
                StreamReader reader = new StreamReader(animationXamlPath);
                xaml = reader.ReadToEnd();
                reader.Close();
                reader.Dispose();
                Tizen.Log.Fatal("NUI", "File is exist!, try with xaml: " + xaml);
                return xaml;
            }

            return null;
        }
        static string GetXamlForType(Type type)
        {
            //the Previewer might want to provide it's own xaml for this... let them do that
            //the check at the end is preferred (using ResourceLoader). keep this until all the previewers are updated

            string xaml;
            string resourceName = type.Name + ".xaml";
            string resource = Tizen.Applications.Application.Current.DirectoryInfo.Resource;

            Tizen.Log.Fatal("NUI", "the resource path: " + resource);
            int windowWidth = NUIApplication.GetDefaultWindow().Size.Width;
            int windowHeight = NUIApplication.GetDefaultWindow().Size.Height;

            string likelyResourcePath = resource + "layout/" + windowWidth.ToString() + "x" + windowHeight.ToString() + "/" + resourceName;
            Tizen.Log.Fatal("NUI", "the resource path: " + likelyResourcePath);

            if (!File.Exists(likelyResourcePath))
            {
                likelyResourcePath = resource + "layout/" + resourceName;
            }

            //Find the xaml file in the layout folder
            if (File.Exists(likelyResourcePath))
            {
                StreamReader reader = new StreamReader(likelyResourcePath);
                xaml = reader.ReadToEnd();
                reader.Close();
                reader.Dispose();
                Tizen.Log.Fatal("NUI", "File is exist!, try with xaml: " + xaml);
                var pattern = String.Format("x:Class *= *\"{0}\"", type.FullName);
                var regex = new Regex(pattern, RegexOptions.ECMAScript);
                if (regex.IsMatch(xaml) || xaml.Contains(String.Format("x:Class=\"{0}\"", type.FullName)))
                {
                    return xaml;
                }
                else
                {
                    throw new XamlParseException(string.Format("Can't find type {0}", type.FullName), new XmlLineInfo());
                }
            }
            else
            {
                Assembly assembly = type.Assembly;

                var resourceId = XamlResourceIdAttribute.GetResourceIdForType(type);
                if (null == resourceId)
                {
                    throw new XamlParseException(string.Format("Can't find type {0} in embedded resource", type.FullName), new XmlLineInfo());
                }
                else
                {
                    Stream stream = assembly.GetManifestResourceStream(resourceId);

                    if (null != stream)
                    {
                        Byte[] buffer = new byte[stream.Length];
                        stream.Read(buffer, 0, (int)stream.Length);

                        string ret = System.Text.Encoding.Default.GetString(buffer);
                        return ret;
                    }
                    else
                    {
                        throw new XamlParseException(string.Format("Can't get xaml stream {0} in embedded resource", type.FullName), new XmlLineInfo());
                    }
                }
            }
        }

        //if the assembly was generated using a version of XamlG that doesn't outputs XamlResourceIdAttributes, we still need to find the resource, and load it
        static readonly Dictionary<Type, string> XamlResources = new Dictionary<Type, string>();
        static string LegacyGetXamlForType(Type type)
        {
            var assembly = type.GetTypeInfo().Assembly;

            string resourceId;
            if (XamlResources.TryGetValue(type, out resourceId))
            {
                var result = ReadResourceAsXaml(type, assembly, resourceId);
                if (result != null)
                    return result;
            }

            var likelyResourceName = type.Name + ".xaml";
            var resourceNames = assembly.GetManifestResourceNames();
            string resourceName = null;

            // first pass, pray to find it because the user named it correctly

            foreach (var resource in resourceNames)
            {
                if (ResourceMatchesFilename(assembly, resource, likelyResourceName))
                {
                    resourceName = resource;
                    var xaml = ReadResourceAsXaml(type, assembly, resource);
                    if (xaml != null)
                        return xaml;
                }
            }

            // okay maybe they at least named it .xaml

            foreach (var resource in resourceNames)
            {
                if (!resource.EndsWith(".xaml", StringComparison.OrdinalIgnoreCase))
                    continue;

                resourceName = resource;
                var xaml = ReadResourceAsXaml(type, assembly, resource);
                if (xaml != null)
                    return xaml;
            }

            foreach (var resource in resourceNames)
            {
                if (resource.EndsWith(".xaml", StringComparison.OrdinalIgnoreCase))
                    continue;

                resourceName = resource;
                var xaml = ReadResourceAsXaml(type, assembly, resource, true);
                if (xaml != null)
                    return xaml;
            }

            return null;
        }

        //legacy...
        static bool ResourceMatchesFilename(Assembly assembly, string resource, string filename)
        {
            try
            {
                var info = assembly.GetManifestResourceInfo(resource);

                if (!string.IsNullOrEmpty(info.FileName) &&
                    string.Compare(info.FileName, filename, StringComparison.OrdinalIgnoreCase) == 0)
                    return true;
            }
            catch (PlatformNotSupportedException)
            {
                // Because Win10 + .NET Native
            }

            if (resource.EndsWith("." + filename, StringComparison.OrdinalIgnoreCase) ||
                string.Compare(resource, filename, StringComparison.OrdinalIgnoreCase) == 0)
                return true;

            return false;
        }

        //part of the legacy as well...
        static string ReadResourceAsXaml(Type type, Assembly assembly, string likelyTargetName, bool validate = false)
        {
            using (var stream = assembly.GetManifestResourceStream(likelyTargetName))
            using (var reader = new StreamReader(stream))
            {
                if (validate)
                {
                    // terrible validation of XML. Unfortunately it will probably work most of the time since comments
                    // also start with a <. We can't bring in any real deps.

                    var firstNonWhitespace = (char)reader.Read();
                    while (char.IsWhiteSpace(firstNonWhitespace))
                        firstNonWhitespace = (char)reader.Read();

                    if (firstNonWhitespace != '<')
                        return null;

                    stream.Seek(0, SeekOrigin.Begin);
                }

                var xaml = reader.ReadToEnd();

                var pattern = String.Format("x:Class *= *\"{0}\"", type.FullName);
                var regex = new Regex(pattern, RegexOptions.ECMAScript);
                if (regex.IsMatch(xaml) || xaml.Contains(String.Format("x:Class=\"{0}\"", type.FullName)))
                    return xaml;
            }
            return null;
        }

        public class RuntimeRootNode : RootNode
        {
            public RuntimeRootNode(XmlType xmlType, object root, IXmlNamespaceResolver resolver) : base(xmlType, resolver)
            {
                Root = root;
            }

            public object Root { get; internal set; }
        }

        internal static string GetXamlForName(string nameOfXamlFile)
        {
            string xaml;
            string resourceName = nameOfXamlFile + ".xaml";
            string resource = Tizen.Applications.Application.Current.DirectoryInfo.Resource;

            NUILog.Debug($"resource=({resource})");

            int windowWidth = NUIApplication.GetDefaultWindow().Size.Width;
            int windowHeight = NUIApplication.GetDefaultWindow().Size.Height;

            string likelyResourcePath = resource + "layout/" + windowWidth.ToString() + "x" + windowHeight.ToString() + "/" + resourceName;

            NUILog.Debug($"likelyResourcePath=({likelyResourcePath})");


            if (!File.Exists(likelyResourcePath))
            {
                likelyResourcePath = resource + "layout/" + resourceName;
            }

            //Find the xaml file in the layout folder
            if (File.Exists(likelyResourcePath))
            {
                StreamReader reader = new StreamReader(likelyResourcePath);
                xaml = reader.ReadToEnd();

                NUILog.Debug($"File is exist!, try with xaml: {xaml}");

                // Layer
                var pattern = String.Format("x:Class *= *\"{0}\"", "Tizen.NUI.Layer");
                var regex = new Regex(pattern, RegexOptions.ECMAScript);
                if (regex.IsMatch(xaml) || xaml.Contains(String.Format("x:Class=\"{0}\"", "Tizen.NUI.Layer")))
                {
                    reader.Dispose();
                    return xaml;
                }
                // View
                pattern = String.Format("x:Class *= *\"{0}\"", "Tizen.NUI.BaseComponents.View");
                regex = new Regex(pattern, RegexOptions.ECMAScript);
                if (regex.IsMatch(xaml) || xaml.Contains(String.Format("x:Class=\"{0}\"", "Tizen.NUI.BaseComponents.View")))
                {
                    reader.Dispose();
                    return xaml;
                }

                reader.Dispose();
                throw new XamlParseException(string.Format("Can't find type {0}", "Tizen.NUI.XamlMainPage nor View nor Layer"), new XmlLineInfo());
            }
            return null;
        }

    }
}
