using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml;
using Tizen.NUI.Binding;
using Tizen.NUI.Binding.Internals;

namespace Tizen.NUI.Xaml
{
    internal interface INode
    {
        List<string> IgnorablePrefixes { get; set; }

        IXmlNamespaceResolver NamespaceResolver { get; }

        INode Parent { get; set; }

        void Accept(IXamlNodeVisitor visitor, INode parentNode);
        INode Clone();
    }

    internal interface IValueNode : INode
    {
    }

    internal interface IElementNode : INode, IListNode
    {
        Dictionary<XmlName, INode> Properties { get; }
        List<XmlName> SkipProperties { get; }
        INameScope Namescope { get; }
        XmlType XmlType { get; }
        string NamespaceURI { get; }
    }

    internal interface IListNode : INode
    {
        List<INode> CollectionItems { get; }
    }

    [DebuggerDisplay("{NamespaceUri}:{Name}")]
    internal class XmlType
    {
        public XmlType(string namespaceUri, string name, IList<XmlType> typeArguments)
        {
            NamespaceUri = namespaceUri;
            Name = name;
            TypeArguments = typeArguments;
        }

        public string NamespaceUri { get; }
        public string Name { get; }
        public IList<XmlType> TypeArguments { get; }
    }

    internal abstract class BaseNode : IXmlLineInfo, INode
    {
        protected BaseNode(IXmlNamespaceResolver namespaceResolver, int linenumber = -1, int lineposition = -1)
        {
            NamespaceResolver = namespaceResolver;
            LineNumber = linenumber;
            LinePosition = lineposition;
        }

        public IXmlNamespaceResolver NamespaceResolver { get; }
        public INode Parent { get; set; }
        public List<string> IgnorablePrefixes { get; set; }
        public int LineNumber { get; set; }
        public int LinePosition { get; set; }

        public bool HasLineInfo() => LineNumber >= 0 && LinePosition >= 0;

        public abstract void Accept(IXamlNodeVisitor visitor, INode parentNode);
        public abstract INode Clone();
    }

    [DebuggerDisplay("{Value}")]
    internal class ValueNode : BaseNode, IValueNode
    {
        public ValueNode(object value, IXmlNamespaceResolver namespaceResolver, int linenumber = -1, int lineposition = -1)
            : base(namespaceResolver, linenumber, lineposition)
        {
            Value = value;
        }

        public object Value { get; set; }

        public override void Accept(IXamlNodeVisitor visitor, INode parentNode)
        {
            visitor.Visit(this, parentNode);
        }

        public override INode Clone() => new ValueNode(Value, NamespaceResolver, LineNumber, LinePosition) {
            IgnorablePrefixes = IgnorablePrefixes
        };
    }

    [DebuggerDisplay("{MarkupString}")]
    internal class MarkupNode : BaseNode, IValueNode
    {
        public MarkupNode(string markupString, IXmlNamespaceResolver namespaceResolver, int linenumber = -1, int lineposition = -1)
            : base(namespaceResolver, linenumber, lineposition)
        {
            MarkupString = markupString;
        }

        public string MarkupString { get; }

        public override void Accept(IXamlNodeVisitor visitor, INode parentNode)
        {
            visitor.Visit(this, parentNode);
        }

        public override INode Clone() => new MarkupNode(MarkupString, NamespaceResolver, LineNumber, LinePosition) {
            IgnorablePrefixes = IgnorablePrefixes
        };
    }

    [DebuggerDisplay("{XmlType.Name}")]
    internal class ElementNode : BaseNode, IValueNode, IElementNode
    {
        public ElementNode(XmlType type, string namespaceURI, IXmlNamespaceResolver namespaceResolver, int linenumber = -1,
            int lineposition = -1)
            : base(namespaceResolver, linenumber, lineposition)
        {
            Properties = new Dictionary<XmlName, INode>();
            SkipProperties = new List<XmlName>();
            CollectionItems = new List<INode>();
            XmlType = type;
            NamespaceURI = namespaceURI;
        }

        public Dictionary<XmlName, INode> Properties { get; }
        public List<XmlName> SkipProperties { get; }
        public List<INode> CollectionItems { get; }
        public XmlType XmlType { get; }
        public string NamespaceURI { get; }
        public INameScope Namescope { get; set; }

        public override void Accept(IXamlNodeVisitor visitor, INode parentNode)
        {
            if (!SkipVisitNode(visitor, parentNode) && visitor.VisitingMode == TreeVisitingMode.TopDown)
                visitor.Visit(this, parentNode);

            if (!SkipChildren(visitor, this, parentNode)) {
                foreach (var node in Properties.Values.ToList())
                    node.Accept(visitor, this);
                foreach (var node in CollectionItems)
                    node.Accept(visitor, this);
            }

            if (!SkipVisitNode(visitor, parentNode) && visitor.VisitingMode == TreeVisitingMode.BottomUp)
                visitor.Visit(this, parentNode);

        }

        bool IsDataTemplate(INode parentNode)
        {
            var parentElement = parentNode as IElementNode;
            INode createContent;
            if (parentElement != null &&
                parentElement.Properties.TryGetValue(XmlName._CreateContent, out createContent) &&
                createContent == this)
                return true;
            return false;
        }

        protected bool SkipChildren(IXamlNodeVisitor visitor, INode node, INode parentNode) =>
               (visitor.StopOnDataTemplate && IsDataTemplate(parentNode))
            || (visitor.StopOnResourceDictionary && visitor.IsResourceDictionary(this))
            || visitor.SkipChildren(node, parentNode);

        protected bool SkipVisitNode(IXamlNodeVisitor visitor, INode parentNode) =>
            !visitor.VisitNodeOnDataTemplate && IsDataTemplate(parentNode);

        public override INode Clone()
        {
            var clone = new ElementNode(XmlType, NamespaceURI, NamespaceResolver, LineNumber, LinePosition) {
                IgnorablePrefixes = IgnorablePrefixes
            };
            foreach (var kvp in Properties)
                clone.Properties.Add(kvp.Key, kvp.Value.Clone());
            foreach (var p in SkipProperties)
                clone.SkipProperties.Add(p);
            foreach (var p in CollectionItems)
                clone.CollectionItems.Add(p.Clone());
            return clone;
        }
    }

    internal abstract class RootNode : ElementNode
    {
        protected RootNode(XmlType xmlType, IXmlNamespaceResolver nsResolver) : base(xmlType, xmlType.NamespaceUri, nsResolver)
        {
        }

        public override void Accept(IXamlNodeVisitor visitor, INode parentNode)
        {
            if (!SkipVisitNode(visitor, parentNode) && visitor.VisitingMode == TreeVisitingMode.TopDown)
                visitor.Visit(this, parentNode);

            if (!SkipChildren(visitor, this, parentNode)) {
                foreach (var node in Properties.Values.ToList())
                    node.Accept(visitor, this);
                foreach (var node in CollectionItems)
                    node.Accept(visitor, this);
            }

            if (!SkipVisitNode(visitor, parentNode) && visitor.VisitingMode == TreeVisitingMode.BottomUp)
                visitor.Visit(this, parentNode);
        }
    }

    internal class ListNode : BaseNode, IListNode, IValueNode
    {
        public ListNode(IList<INode> nodes, IXmlNamespaceResolver namespaceResolver, int linenumber = -1, int lineposition = -1)
            : base(namespaceResolver, linenumber, lineposition)
        {
            CollectionItems = nodes.ToList();
        }

        public XmlName XmlName { get; set; }
        public List<INode> CollectionItems { get; set; }

        public override void Accept(IXamlNodeVisitor visitor, INode parentNode)
        {
            if (visitor.VisitingMode == TreeVisitingMode.TopDown)
                visitor.Visit(this, parentNode);
            foreach (var node in CollectionItems)
                node.Accept(visitor, this);
            if (visitor.VisitingMode == TreeVisitingMode.BottomUp)
                visitor.Visit(this, parentNode);
        }

        public override INode Clone()
        {
            var items = new List<INode>();
            foreach (var p in CollectionItems)
                items.Add(p.Clone());
            return new ListNode(items, NamespaceResolver, LineNumber, LinePosition) {
                IgnorablePrefixes = IgnorablePrefixes
            };
        }
    }

    internal static class INodeExtensions
    {
        public static bool SkipPrefix(this INode node, string prefix)
        {
            do {
                if (node.IgnorablePrefixes != null && node.IgnorablePrefixes.Contains(prefix))
                    return true;
                node = node.Parent;
            } while (node != null);
            return false;
        }
    }
}