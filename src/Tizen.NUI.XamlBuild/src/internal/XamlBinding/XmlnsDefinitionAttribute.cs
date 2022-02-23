using System;
using System.Diagnostics;
using System.ComponentModel;

namespace Tizen.NUI
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    [DebuggerDisplay("{XmlNamespace}, {ClrNamespace}, {AssemblyName}")]
    /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal sealed class XmlnsDefinitionAttribute : Attribute
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

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int Level { get; set; }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public XmlnsDefinitionAttribute(string xmlNamespace, string clrNamespace, int level)
        {
            if (xmlNamespace == null)
                throw new ArgumentNullException(nameof(xmlNamespace));
            if (clrNamespace == null)
                throw new ArgumentNullException(nameof(clrNamespace));

            ClrNamespace = clrNamespace;
            XmlNamespace = xmlNamespace;
            Level = level;
        }
    }
}