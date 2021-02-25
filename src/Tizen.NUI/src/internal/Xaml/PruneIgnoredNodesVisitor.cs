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

using System.Collections.Generic;
using System.Linq;

namespace Tizen.NUI.Xaml
{
    internal class PruneIgnoredNodesVisitor : IXamlNodeVisitor
    {
        public TreeVisitingMode VisitingMode => TreeVisitingMode.TopDown;
        public bool StopOnDataTemplate => false;
        public bool StopOnResourceDictionary => false;
        public bool VisitNodeOnDataTemplate => true;
        public bool SkipChildren(INode node, INode parentNode) => false;
        public bool IsResourceDictionary(ElementNode node) => false;

        public void Visit(ElementNode node, INode parentNode)
        {
            foreach (var propertyKvp in node.Properties)
            {
                var propertyName = propertyKvp.Key;
                var propertyValue = (propertyKvp.Value as ValueNode)?.Value as string;
                if (propertyValue == null)
                    continue;
                if (!propertyName.Equals(XamlParser.McUri, "Ignorable"))
                    continue;
                (parentNode.IgnorablePrefixes ?? (parentNode.IgnorablePrefixes = new List<string>()))?.AddRange(propertyValue.Split(','));
            }

            foreach (var propertyKvp in node.Properties.ToList())
            {
                // skip d:foo="bar"
                var prefix = node.NamespaceResolver.LookupPrefix(propertyKvp.Key.NamespaceURI);
                if (node.SkipPrefix(prefix))
                    node.Properties.Remove(propertyKvp.Key);
                var propNs = (propertyKvp.Value as IElementNode)?.NamespaceURI ?? "";
                var propPrefix = node.NamespaceResolver.LookupPrefix(propNs);
                if (node.SkipPrefix(propPrefix))
                    node.Properties.Remove(propertyKvp.Key);
            }

            foreach (var prop in node.CollectionItems.ToList())
            {
                var propNs = (prop as IElementNode)?.NamespaceURI ?? "";
                var propPrefix = node.NamespaceResolver.LookupPrefix(propNs);
                if (node.SkipPrefix(propPrefix))
                    node.CollectionItems.Remove(prop);
            }

            if (node.SkipPrefix(node.NamespaceResolver.LookupPrefix(node.NamespaceURI)))
            {
                node.Properties.Clear();
                node.CollectionItems.Clear();
            }
        }

        public void Visit(RootNode node, INode parentNode)
        {
            Visit((ElementNode)node, node);
        }

        public void Visit(MarkupNode node, INode parentNode)
        {
        }

        public void Visit(ListNode node, INode parentNode)
        {
            foreach (var prop in node.CollectionItems.ToList())
            {
                var propNs = (prop as IElementNode)?.NamespaceURI ?? "";
                var propPrefix = node.NamespaceResolver.LookupPrefix(propNs);
                if (node.SkipPrefix(propPrefix))
                    node.CollectionItems.Remove(prop);
            }
        }

        public void Visit(ValueNode node, INode parentNode)
        {
        }
    }
}
