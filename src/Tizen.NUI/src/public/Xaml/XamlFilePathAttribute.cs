using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Tizen.NUI.Xaml
{
    /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class XamlFilePathAttribute : Attribute
    {
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public XamlFilePathAttribute([CallerFilePath] string filePath = "")
        {
        }
    }
}