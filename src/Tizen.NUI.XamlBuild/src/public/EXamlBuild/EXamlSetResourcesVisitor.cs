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
using System.Collections;
using System.Linq;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Tizen.NUI.EXaml;
using Tizen.NUI.Xaml;
using Tizen.NUI.Xaml.Build.Tasks;

namespace Tizen.NUI.EXaml.Build.Tasks
{
    class EXamlSetResourcesVisitor : IXamlNodeVisitor
    {
        public EXamlSetResourcesVisitor(EXamlContext context)
        {
            Context = context;
            Module = context.Module;
        }

        public EXamlContext Context { get; }
        ModuleDefinition Module { get; }
        public TreeVisitingMode VisitingMode => TreeVisitingMode.TopDown;
        public bool StopOnDataTemplate => true;
        public bool StopOnResourceDictionary => false;
        public bool VisitNodeOnDataTemplate => false;

        public void Visit(ValueNode node, INode parentNode)
        {
            if (!IsResourceDictionary((IElementNode)parentNode))
                return;

            node.Accept(new EXamlSetPropertiesVisitor(Context, stopOnResourceDictionary: false), parentNode);
        }

        public void Visit(MarkupNode node, INode parentNode)
        {
        }


        public void Visit(ElementNode node, INode parentNode)
        {
            XmlName propertyName;
            //Set ResourcesDictionaries to their parents
            if (IsResourceDictionary(node) && EXamlSetPropertiesVisitor.TryGetPropertyName(node, parentNode, out propertyName))
            {
                string realPropertyName;
                if (propertyName.LocalName.EndsWith(".XamlResources", StringComparison.Ordinal))
                {
                    realPropertyName = propertyName.LocalName.Substring(propertyName.LocalName.Length - ".XamlResources".Length);
                }
                else
                {
                    realPropertyName = propertyName.LocalName;
                }

                if (realPropertyName == "XamlResources")
                {
                    new EXamlSetProperty(Context, Context.Values[parentNode] as EXamlCreateObject, realPropertyName, Context.Values[node]);
                    //Context.IL.Append(SetPropertiesVisitor.SetPropertyValue(Context.Variables[(IElementNode)parentNode], propertyName, node, Context, node));
                    return;
                }
            }

            //Only proceed further if the node is a keyless RD
            if (   parentNode is IElementNode
                && IsResourceDictionary((IElementNode)parentNode)
                && !((IElementNode)parentNode).Properties.ContainsKey(XmlName.xKey))
                node.Accept(new EXamlSetPropertiesVisitor(Context, stopOnResourceDictionary: false), parentNode);
            else if (   parentNode is ListNode
                     && IsResourceDictionary((IElementNode)parentNode.Parent)
                     && !((IElementNode)parentNode.Parent).Properties.ContainsKey(XmlName.xKey))
                node.Accept(new EXamlSetPropertiesVisitor(Context, stopOnResourceDictionary: false), parentNode);
        }

        public void Visit(RootNode node, INode parentNode)
        {
        }

        public void Visit(ListNode node, INode parentNode)
        {
        }

        public bool IsResourceDictionary(ElementNode node) => IsResourceDictionary((IElementNode)node);

        bool IsResourceDictionary(IElementNode node)
        {
            var instance = Context.Values[node] as EXamlCreateObject;

            if (null != instance)
            {
                return instance.Type.InheritsFromOrImplements("Tizen.NUI.Binding.ResourceDictionary");
            }
            else
            {
                return false;
            }
        }

        public bool SkipChildren(INode node, INode parentNode)
        {
            var enode = node as ElementNode;
            if (enode == null)
                return false;
            if (   parentNode is IElementNode
                && IsResourceDictionary((IElementNode)parentNode)
                && !((IElementNode)parentNode).Properties.ContainsKey(XmlName.xKey))
                return true;
            if (   parentNode is ListNode
                && IsResourceDictionary((IElementNode)parentNode.Parent)
                && !((IElementNode)parentNode.Parent).Properties.ContainsKey(XmlName.xKey))
                return true;
            return false;
        }
    }
}