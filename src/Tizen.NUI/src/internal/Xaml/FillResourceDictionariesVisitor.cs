using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Xaml
{
    internal class FillResourceDictionariesVisitor : IXamlNodeVisitor
    {
        public FillResourceDictionariesVisitor(HydrationContext context)
        {
            Context = context;
        }

        HydrationContext Context { get; }
        Dictionary<INode, object> Values => Context.Values;

        public TreeVisitingMode VisitingMode => TreeVisitingMode.TopDown;
        public bool StopOnDataTemplate => true;
        public bool StopOnResourceDictionary => false;
        public bool VisitNodeOnDataTemplate => false;

        public bool IsResourceDictionary(ElementNode node) => typeof(ResourceDictionary).IsAssignableFrom(Context.Types[node]);

        public void Visit(ValueNode node, INode parentNode)
        {
            if (!typeof(ResourceDictionary).IsAssignableFrom(Context.Types[((IElementNode)parentNode)]))
                return;

            node.Accept(new ApplyPropertiesVisitor(Context, stopOnResourceDictionary: false), parentNode);
        }

        public void Visit(MarkupNode node, INode parentNode)
        {
        }

        public void Visit(ElementNode node, INode parentNode)
        {
            var value = Values[node];
            XmlName propertyName;
            //Set RD to VE
            if (typeof(ResourceDictionary).IsAssignableFrom(Context.Types[node]) && ApplyPropertiesVisitor.TryGetPropertyName(node, parentNode, out propertyName)) {
                if ((propertyName.LocalName == "Resources" ||
                     propertyName.LocalName.EndsWith(".Resources", StringComparison.Ordinal)) && value is ResourceDictionary) {
                    var source = Values[parentNode];
                    ApplyPropertiesVisitor.SetPropertyValue(source, propertyName, value, Context.RootElement, node, Context, node);
                    return;
                }
            }

            //Only proceed further if the node is a keyless RD
            if (   parentNode is IElementNode
                && typeof(ResourceDictionary).IsAssignableFrom(Context.Types[((IElementNode)parentNode)])
                && !((IElementNode)parentNode).Properties.ContainsKey(XmlName.xKey))
                node.Accept(new ApplyPropertiesVisitor(Context, stopOnResourceDictionary: false), parentNode);
            else if (   parentNode is ListNode
                     && typeof(ResourceDictionary).IsAssignableFrom(Context.Types[((IElementNode)parentNode.Parent)])
                     && !((IElementNode)parentNode.Parent).Properties.ContainsKey(XmlName.xKey))
                node.Accept(new ApplyPropertiesVisitor(Context, stopOnResourceDictionary: false), parentNode);
        }

        public void Visit(RootNode node, INode parentNode)
        {
        }

        public void Visit(ListNode node, INode parentNode)
        {
        }

        public bool SkipChildren(INode node, INode parentNode)
        {
            var enode = node as ElementNode;
            if (enode is null)
                return false;
            if (   parentNode is IElementNode
                && typeof(ResourceDictionary).IsAssignableFrom(Context.Types[((IElementNode)parentNode)])
                && !((IElementNode)parentNode).Properties.ContainsKey(XmlName.xKey))
                return true;
            if (   parentNode is ListNode
                && typeof(ResourceDictionary).IsAssignableFrom(Context.Types[((IElementNode)parentNode.Parent)])
                && !((IElementNode)parentNode.Parent).Properties.ContainsKey(XmlName.xKey))
                return true;
            return false;
        }
    }
}