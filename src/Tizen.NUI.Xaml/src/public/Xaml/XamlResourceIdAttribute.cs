using System;
using System.Reflection;

namespace Tizen.NUI.Xaml
{
    /// <summary>
    /// The class XamlResourceIdAttribute.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    [AttributeUsage(AttributeTargets.Assembly, Inherited = false, AllowMultiple = true)]
    public sealed class XamlResourceIdAttribute : Attribute
    {
        /// <summary>
        /// Attribute ResourceId
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public string ResourceId { get; set; }

        /// <summary>
        /// Attribute Path
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public string Path { get; set; }

        /// <summary>
        /// Attribute Type
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public Type Type { get; set; }

        /// <summary>
        /// Create a new XamlResourceIdAttribute
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
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