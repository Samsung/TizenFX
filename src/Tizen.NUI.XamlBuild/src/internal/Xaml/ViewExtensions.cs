/*
 * Copyright(c) 2022 Samsung Electronics Co., Ltd.
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
using System.Reflection;
using System.ComponentModel;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Xaml
{
    /// <summary>
    /// Extension class for View defining Tizen.NUI.Xaml.Extensions.LoadFromXaml{TView} method.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal static class Extensions
    {
        /// <summary>
        /// Returns a TXaml with the properties that are defined in the application manifest for callingType.
        /// </summary>
        /// <typeparam name="TXaml">The type of view to initialize with state from XAML.</typeparam>
        /// <param name="view">The view on which this method operates.</param>
        /// <param name="xaml">The XAML that encodes the view state.</param>
        /// <returns>A TXaml with the properties that are defined in the application manifest for callingType.</returns>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static TXaml LoadFromXaml<TXaml>(this TXaml view, string xaml)
        {
            if (view is Element)
            {
                NameScopeExtensions.PushElement(view);
            }

            XamlLoader.Load(view, xaml);

            if (view is Element)
            {
                NameScopeExtensions.PopElement();
            }

            return view;
        }
    }
}
 
