using System;
using System.Diagnostics;
using System.ComponentModel;

namespace Tizen.NUI
{
    /// <summary>
    /// Specifies a mapping on a per-assembly basis between a XAML namespace and a CLR namespace,<br />
    /// which is then used for type resolution by a XAML object writer or XAML schema context.
    /// </summary>
    /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    [DebuggerDisplay("{XmlNamespace}, {ClrNamespace}, {AssemblyName}")]
    public sealed class XmlnsDefinitionAttribute : Attribute
    {
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string XmlNamespace { get; }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ClrNamespace { get; }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string AssemblyName { get; set; }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int Level { get; set; }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public XmlnsDefinitionAttribute(string xmlNamespace, string clrNamespace)
        {
            if (xmlNamespace == null)
                throw new ArgumentNullException(nameof(xmlNamespace));
            if (clrNamespace == null)
                throw new ArgumentNullException(nameof(clrNamespace));

            ClrNamespace = clrNamespace;
            XmlNamespace = xmlNamespace;
            Level = 0;
        }
    }
}