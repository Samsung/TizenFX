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
            foreach (var xria in assembly.GetCustomAttributes<XamlResourceIdAttribute>())
            {
                if (xria.Type == type)
                    return xria.ResourceId;
            }
            return null;
        }

        internal static string GetPathForType(Type type)
        {
            var assembly = type.GetTypeInfo().Assembly;
            foreach (var xria in assembly.GetCustomAttributes<XamlResourceIdAttribute>())
            {
                if (xria.Type == type)
                    return xria.Path;
            }
            return null;
        }

        internal static string GetResourceIdForPath(Assembly assembly, string path)
        {
            foreach (var xria in assembly.GetCustomAttributes<XamlResourceIdAttribute>())
            {
                if (xria.Path == path)
                    return xria.ResourceId;
            }
            return null;
        }

        internal static Type GetTypeForResourceId(Assembly assembly, string resourceId)
        {
            foreach (var xria in assembly.GetCustomAttributes<XamlResourceIdAttribute>())
            {
                if (xria.ResourceId == resourceId)
                    return xria.Type;
            }
            return null;
        }

        internal static Type GetTypeForPath(Assembly assembly, string path)
        {
            foreach (var xria in assembly.GetCustomAttributes<XamlResourceIdAttribute>())
            {
                if (xria.Path == path)
                    return xria.Type;
            }
            return null;
        }
    }
}
