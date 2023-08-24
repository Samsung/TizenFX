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

namespace Tizen.NUI.Xaml
{
    internal interface IXamlNodeVisitor
    {
        TreeVisitingMode VisitingMode { get; }
        bool StopOnDataTemplate { get; }
        bool VisitNodeOnDataTemplate { get; }
        bool StopOnResourceDictionary { get; }

        void Visit(ValueNode node, INode parentNode);
        void Visit(MarkupNode node, INode parentNode);
        void Visit(ElementNode node, INode parentNode);
        void Visit(RootNode node, INode parentNode);
        void Visit(ListNode node, INode parentNode);
        bool SkipChildren(INode node, INode parentNode);
        bool IsResourceDictionary(ElementNode node);
    }

    internal enum TreeVisitingMode
    {
        TopDown,
        BottomUp
    }

    internal class XamlNodeVisitor : IXamlNodeVisitor
    {
        readonly Action<INode, INode> action;

        public XamlNodeVisitor(Action<INode, INode> action, TreeVisitingMode visitingMode = TreeVisitingMode.TopDown, bool stopOnDataTemplate = false, bool visitNodeOnDataTemplate = true)
        {
            this.action = action;
            VisitingMode = visitingMode;
            StopOnDataTemplate = stopOnDataTemplate;
            VisitNodeOnDataTemplate = visitNodeOnDataTemplate;
        }

        public TreeVisitingMode VisitingMode { get; }
        public bool StopOnDataTemplate { get; }
        public bool StopOnResourceDictionary { get; }
        public bool VisitNodeOnDataTemplate { get; }

        public void Visit(ValueNode node, INode parentNode) => action(node, parentNode);
        public void Visit(MarkupNode node, INode parentNode) => action(node, parentNode);
        public void Visit(ElementNode node, INode parentNode) => action(node, parentNode);
        public void Visit(RootNode node, INode parentNode) => action(node, parentNode);
        public void Visit(ListNode node, INode parentNode) => action(node, parentNode);
        public bool SkipChildren(INode node, INode parentNode) => false;
        public bool IsResourceDictionary(ElementNode node) => false;
    }
}
