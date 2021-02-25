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
using Tizen.NUI.Binding;

namespace Tizen.NUI.Xaml
{
    internal class RegisterXNamesVisitor : IXamlNodeVisitor
    {
        public RegisterXNamesVisitor(HydrationContext context)
        {
            Context = context;
            Values = context.Values;
        }

        Dictionary<INode, object> Values { get; }
        HydrationContext Context { get; }
        public TreeVisitingMode VisitingMode => TreeVisitingMode.TopDown;
        public bool StopOnDataTemplate => true;
        public bool StopOnResourceDictionary => false;
        public bool VisitNodeOnDataTemplate => false;
        public bool SkipChildren(INode node, INode parentNode) => false;
        public bool IsResourceDictionary(ElementNode node) => typeof(ResourceDictionary).IsAssignableFrom(Context.Types[node]);

        public void Visit(ValueNode node, INode parentNode)
        {
            if (!IsXNameProperty(node, parentNode))
                return;
            try
            {
                ((IElementNode)parentNode).Namescope.RegisterName((string)node.Value, Values[parentNode]);
            }
            catch (ArgumentException ae)
            {
                if (ae.ParamName != "name")
                    throw;
                throw new XamlParseException($"An element with the name \"{(string)node.Value}\" already exists in this NameScope", node);
            }
            var element = Values[parentNode] as Element;
            if (element != null)
                element.StyleId = element.StyleId ?? (string)node.Value;
        }

        public void Visit(MarkupNode node, INode parentNode)
        {
        }

        public void Visit(ElementNode node, INode parentNode)
        {
        }

        public void Visit(RootNode node, INode parentNode)
        {
        }

        public void Visit(ListNode node, INode parentNode)
        {
        }

        static bool IsXNameProperty(ValueNode node, INode parentNode)
        {
            var parentElement = parentNode as IElementNode;
            INode xNameNode;
            if (parentElement != null && parentElement.Properties.TryGetValue(XmlName.xName, out xNameNode) && xNameNode == node)
                return true;
            return false;
        }
    }
}
