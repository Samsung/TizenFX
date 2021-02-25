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
    [Flags]
    public enum XamlCompilationOptions
    {
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        Skip = 1 << 0,

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        Compile = 1 << 1
    }

    /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    [AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Module | AttributeTargets.Class, Inherited = false)]
    public sealed class XamlCompilationAttribute : Attribute
    {
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public XamlCompilationAttribute(XamlCompilationOptions xamlCompilationOptions)
        {
            XamlCompilationOptions = xamlCompilationOptions;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public XamlCompilationOptions XamlCompilationOptions { get; set; }
    }

    internal static class XamlCExtensions
    {
        public static bool IsCompiled(this Type type)
        {
            var attr = type.GetTypeInfo().GetCustomAttribute<XamlCompilationAttribute>();
            if (attr != null)
                return attr.XamlCompilationOptions == XamlCompilationOptions.Compile;
            attr = type.GetTypeInfo().Module.GetCustomAttribute<XamlCompilationAttribute>();
            if (attr != null)
                return attr.XamlCompilationOptions == XamlCompilationOptions.Compile;
            attr = type.GetTypeInfo().Assembly.GetCustomAttribute<XamlCompilationAttribute>();
            if (attr != null)
                return attr.XamlCompilationOptions == XamlCompilationOptions.Compile;

            return false;
        }
    }
}
