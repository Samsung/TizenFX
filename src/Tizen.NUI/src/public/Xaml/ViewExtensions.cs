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

//
// ViewExtensions.cs
//
// Author:
//       Stephane Delcroix <stephane@mi8.be>
//
// Copyright (c) 2013 Mobile Inception
// Copyright (c) 2013 Xamarin, Inc
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Tizen.NUI.Xaml
{
    /// <summary>
    /// Extension class for View defining Tizen.NUI.Xaml.Extensions.LoadFromXaml{TView} method.
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1724: Type names should not match namespaces")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class Extensions
    {
        /// <summary>
        /// Returns an initialized view by loading the specified xaml.
        /// </summary>
        /// <typeparam name="TXaml">The type of view to initialize with state from XAML.</typeparam>
        /// <param name="view">The view on which this method operates.</param>
        /// <param name="callingType">The type of the caller.</param>
        /// <returns>A TXaml with the properties that are defined in the application manifest for callingType.</returns>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static TXaml LoadFromXaml<TXaml>(this TXaml view, Type callingType)
        {
            XamlLoader.Load(view, callingType);
            return view;
        }

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
            XamlLoader.Load(view, xaml);
            return view;
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static T LoadObject<T>(string path)
        {
            return XamlLoader.LoadObject<T>(path);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static TXaml LoadFromXamlFile<TXaml>(this TXaml view, string nameOfXamlFile)
        {
            NUILog.Debug($"LoadFromXamlFile(nameOfXamlFile={nameOfXamlFile})");

            string xamlScript = XamlLoader.GetXamlForName(nameOfXamlFile);
            XamlLoader.Load(view, xamlScript);
            return view;
        }
    }
}
