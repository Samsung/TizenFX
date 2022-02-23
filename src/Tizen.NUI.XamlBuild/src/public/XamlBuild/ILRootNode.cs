using System.Xml;
using Mono.Cecil;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Xaml.Build.Tasks
{
    class ILRootNode : RootNode
    {
        public ILRootNode(XmlType xmlType, TypeReference typeReference, IXmlNamespaceResolver nsResolver) : base(xmlType, nsResolver)
        {
            TypeReference = typeReference;
        }

        public TypeReference TypeReference { get; private set; }
    }
}