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
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml;
using Tizen.NUI.Binding;
using Tizen.NUI.Binding.Internals;

namespace Tizen.NUI.Xaml.Internals
{
    [Obsolete ("Replaced by ResourceLoader")]
    internal static class XamlLoader
    {
        static Func<Type, string> xamlFileProvider;

        public static Func<Type, string> XamlFileProvider {
            get { return xamlFileProvider; }
            internal set {
                xamlFileProvider = value;
                Tizen.NUI.Xaml.DesignMode.IsDesignModeEnabled = true;
                //¯\_(ツ)_/¯ the previewer forgot to set that bool
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
        public static void Load(object view, string xaml)
        {
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
                    if (reader.NodeType != XmlNodeType.Element) {
                        Debug.WriteLine("Unhandled node {0} {1} {2}", reader.NodeType, reader.Name, reader.Value);
                        continue;
                    }

                    for (int i = 0; i < 100; i++)
                    {
                        XmlType temp = new XmlType(reader.NamespaceURI, reader.Name, null);
                    }

                    XmlType xmlType = new XmlType(reader.NamespaceURI, reader.Name, null);

                    for (int i = 0; i < 100; i++)
                    {
                        new RuntimeRootNode(xmlType, view, (IXmlNamespaceResolver)reader);
                    }

                    var rootnode = new RuntimeRootNode (xmlType, view, (IXmlNamespaceResolver)reader);
                    XamlParser.ParseXaml (rootnode, reader);
                    Visit (rootnode, new HydrationContext {
                        RootElement = view,
#pragma warning disable 0618
                        ExceptionHandler = ResourceLoader.ExceptionHandler ?? (Internals.XamlLoader.DoNotThrowOnExceptions ? e => { }: (Action<Exception>)null)
#pragma warning restore 0618
                    });
                    break;
                }
            }
        }

        [Obsolete ("Use the XamlFileProvider to provide xaml files. We will remove this when Cycle 8 hits Stable.")]
        public static object Create (string xaml, bool doNotThrow = false)
        {
            object inflatedView = null;
            using (var textreader = new StringReader(xaml))
            using (var reader = XmlReader.Create (textreader)) {
                while (reader.Read ()) {
                    //Skip until element
                    if (reader.NodeType == XmlNodeType.Whitespace)
                        continue;
                    if (reader.NodeType == XmlNodeType.XmlDeclaration)
                        continue;
                    if (reader.NodeType != XmlNodeType.Element) {
                        Debug.WriteLine("Unhandled node {0} {1} {2}", reader.NodeType, reader.Name, reader.Value);
                        continue;
                    }

                    var rootnode = new RuntimeRootNode (new XmlType (reader.NamespaceURI, reader.Name, null), null, (IXmlNamespaceResolver)reader);
                    XamlParser.ParseXaml (rootnode, reader);
                    var visitorContext = new HydrationContext {
                        ExceptionHandler = doNotThrow ? e => { } : (Action<Exception>)null,
                    };
                    var cvv = new CreateValuesVisitor (visitorContext);
                    cvv.Visit ((ElementNode)rootnode, null);
                    inflatedView = rootnode.Root = visitorContext.Values [rootnode];
                    visitorContext.RootElement = inflatedView as BindableObject;

                    Visit (rootnode, visitorContext);
                    break;
                }
            }
            return inflatedView;
        }

        static void Visit (RootNode rootnode, HydrationContext visitorContext)
        {
            rootnode.Accept (new XamlNodeVisitor ((node, parent) => node.Parent = parent), null); //set parents for {StaticResource}
            rootnode.Accept (new ExpandMarkupsVisitor (visitorContext), null);
            rootnode.Accept (new PruneIgnoredNodesVisitor(), null);
            rootnode.Accept (new NamescopingVisitor (visitorContext), null); //set namescopes for {x:Reference}
            rootnode.Accept (new CreateValuesVisitor (visitorContext), null);
            rootnode.Accept (new RegisterXNamesVisitor (visitorContext), null);
            rootnode.Accept (new FillResourceDictionariesVisitor (visitorContext), null);
            rootnode.Accept (new ApplyPropertiesVisitor (visitorContext, true), null);
        }

        static string LoadObjectFromXaml(string animationXamlPath)
        {
            string xaml;
            if (File.Exists(animationXamlPath))
            {
                StreamReader reader = new StreamReader(animationXamlPath);
                xaml = reader.ReadToEnd();
                return xaml;
            }

            return null;
        }
        //if the assembly was generated using a version of XamlG that doesn't outputs XamlResourceIdAttributes, we still need to find the resource, and load it

        //        static string GetXamlForType(Type type)
        //        {
        //            //the Previewer might want to provide it's own xaml for this... let them do that
        //            //the check at the end is preferred (using ResourceLoader). keep this until all the previewers are updated

        //            string xaml;
        //#pragma warning disable 0618
        //            if (ResourceLoader.ResourceProvider == null && (xaml = Internals.XamlLoader.XamlFileProvider?.Invoke(type)) != null)
        //                return xaml;
        //#pragma warning restore 0618

        //            var assembly = type.GetTypeInfo().Assembly;
        //            var resourceId = XamlResourceIdAttribute.GetResourceIdForType(type);

        //            if (resourceId == null)
        //                return LegacyGetXamlForType(type);

        //            using (var stream = assembly.GetManifestResourceStream(resourceId))
        //            {
        //                if (stream != null)
        //                    using (var reader = new StreamReader(stream))
        //                        xaml = reader.ReadToEnd();
        //                else
        //                    xaml = null;
        //            }

        //            var alternateXaml = ResourceLoader.ResourceProvider?.Invoke(assembly.GetName(), XamlResourceIdAttribute.GetPathForType(type));
        //            return alternateXaml ?? xaml;
        //        }

        static readonly Dictionary<Type, string> XamlResources = new Dictionary<Type, string>();
        static string LegacyGetXamlForType(Type type)
        {
            var assembly = type.GetTypeInfo().Assembly;

            string resourceId;
            if (XamlResources.TryGetValue(type, out resourceId)) {
                var result = ReadResourceAsXaml(type, assembly, resourceId);
                if (result != null)
                    return result;
            }

            var likelyResourceName = type.Name + ".xaml";
            var resourceNames = assembly.GetManifestResourceNames();
            string resourceName = null;

            // first pass, pray to find it because the user named it correctly

            foreach (var resource in resourceNames) {
                if (ResourceMatchesFilename(assembly, resource, likelyResourceName)) {
                    resourceName = resource;
                    var xaml = ReadResourceAsXaml(type, assembly, resource);
                    if (xaml != null)
                        return xaml;
                }
            }

            // okay maybe they at least named it .xaml

            foreach (var resource in resourceNames) {
                if (!resource.EndsWith(".xaml", StringComparison.OrdinalIgnoreCase))
                    continue;

                resourceName = resource;
                var xaml = ReadResourceAsXaml(type, assembly, resource);
                if (xaml != null)
                    return xaml;
            }

            foreach (var resource in resourceNames) {
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
            try {
                var info = assembly.GetManifestResourceInfo(resource);

                if (!string.IsNullOrEmpty(info.FileName) &&
                    string.Compare(info.FileName, filename, StringComparison.OrdinalIgnoreCase) == 0)
                    return true;
            }
            catch (PlatformNotSupportedException) {
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
            using (var reader = new StreamReader(stream)) {
                if (validate) {
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
            public RuntimeRootNode(XmlType xmlType, object root, IXmlNamespaceResolver resolver) : base (xmlType, resolver)
            {
                Root = root;
            }

            public object Root { get; internal set; }
        }
    }
}
 
