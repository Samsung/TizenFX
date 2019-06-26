using System;
using System.ComponentModel;
using System.Reflection;

namespace Tizen.NUI.Xaml
{
    /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    [AttributeUsage(AttributeTargets.Assembly, Inherited = false, AllowMultiple = true)]
    public sealed class XamlResourceIdAttribute : Attribute
    {
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ResourceId { get; set; }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Path { get; set; }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Type Type { get; set; }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public XamlResourceIdAttribute(string resourceId, string path, Type type)
        {
            ResourceId = resourceId;
            Path = path;
            Type = type;
        }

        internal static string GetResourceIdForType(Type type)
        {
            var assembly = type.GetTypeInfo().Assembly;
            foreach (var xria in assembly.GetCustomAttributes<XamlResourceIdAttribute>()) {
                if (xria.Type == type)
                    return xria.ResourceId;
            }
            return null;
        }

        internal static string GetPathForType(Type type)
        {
            var assembly = type.GetTypeInfo().Assembly;
            foreach (var xria in assembly.GetCustomAttributes<XamlResourceIdAttribute>()) {
                if (xria.Type == type)
                    return xria.Path;
            }
            return null;
        }

        internal static string GetResourceIdForPath(Assembly assembly, string path)
        {
            foreach (var xria in assembly.GetCustomAttributes<XamlResourceIdAttribute>()) {
                if (xria.Path == path)
                    return xria.ResourceId;
            }
            return null;
        }

        internal static Type GetTypeForResourceId(Assembly assembly, string resourceId)
        {
            foreach (var xria in assembly.GetCustomAttributes<XamlResourceIdAttribute>()) {
                if (xria.ResourceId == resourceId)
                    return xria.Type;
            }
            return null;
        }

        internal static Type GetTypeForPath(Assembly assembly, string path)
        {
            foreach (var xria in assembly.GetCustomAttributes<XamlResourceIdAttribute>()) {
                if (xria.Path == path)
                    return xria.Type;
            }
            return null;
        }
    }
}