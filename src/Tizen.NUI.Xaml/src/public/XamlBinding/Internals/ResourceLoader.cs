using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Binding.Internals
{
    /// <summary>
    /// The class ResourceLoader.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class ResourceLoader
    {
        static Func<AssemblyName, string, string> resourceProvider = (asmName, path) =>
        {
            return null;
            //string resource = Tizen.Applications.Application.Current.DirectoryInfo.Resource;
            //path = resource + path;

            //string ret = File.ReadAllText(path);
            //return ret;
        };

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        //takes a resource path, returns string content
        public static Func<AssemblyName, string, string> ResourceProvider123
        {
            get => resourceProvider;
            internal set
            {
                DesignMode.IsDesignModeEnabled = true;
                resourceProvider = value;
            }
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        //takes a resource path, returns string content
        public static Func<AssemblyName, string, string> ResourceProvider {
            get => resourceProvider;
            internal set {
                DesignMode.IsDesignModeEnabled = true;
                resourceProvider = value;
            }
        }

        internal static Action<Exception> ExceptionHandler { get; set; }
    }
}