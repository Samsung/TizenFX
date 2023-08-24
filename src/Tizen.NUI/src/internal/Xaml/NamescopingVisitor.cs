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
using Tizen.NUI.Binding.Internals;

namespace Tizen.NUI.Xaml
{
    internal class NamescopingVisitor : IXamlNodeVisitor
    {
        readonly Dictionary<INode, INameScope> scopes = new Dictionary<INode, INameScope>();

        public NamescopingVisitor(HydrationContext context)
        {
            Values = context.Values;
        }

        Dictionary<INode, object> Values { get; set; }

        public TreeVisitingMode VisitingMode => TreeVisitingMode.TopDown;
        public bool StopOnDataTemplate => false;
        public bool StopOnResourceDictionary => false;
        public bool VisitNodeOnDataTemplate => true;
        public bool SkipChildren(INode node, INode parentNode) => false;
        public bool IsResourceDictionary(ElementNode node) => false;

        public void Visit(ValueNode node, INode parentNode)
        {
            scopes[node] = scopes[parentNode];
        }

        public void Visit(MarkupNode node, INode parentNode)
        {
            scopes[node] = scopes[parentNode];
        }

        public void Visit(ElementNode node, INode parentNode)
        {
            var ns = parentNode == null || IsDataTemplate(node, parentNode) || IsStyle(parentNode) || IsVisualStateGroupList(node)
                ? new NameScope()
                : scopes[parentNode];
            node.Namescope = ns;
            scopes[node] = ns;
        }

        public void Visit(RootNode node, INode parentNode)
        {
            var ns = new NameScope();
            node.Namescope = ns;
            scopes[node] = ns;
        }

        public void Visit(ListNode node, INode parentNode)
        {
            scopes[node] = scopes[parentNode];
        }

        static bool IsDataTemplate(INode node, INode parentNode)
        {
            var parentElement = parentNode as IElementNode;
            INode createContent;
            if (parentElement != null && parentElement.Properties.TryGetValue(XmlName._CreateContent, out createContent) &&
                createContent == node)
                return true;
            return false;
        }

        static bool IsStyle(INode parentNode)
        {
            var pnode = parentNode as ElementNode;
            return pnode != null && pnode.XmlType.Name == "Style";
        }

        static bool IsVisualStateGroupList(ElementNode node)
        {
            return node != null && node.XmlType.Name == "VisualStateGroup" && node.Parent is IListNode;
        }
    }
}
