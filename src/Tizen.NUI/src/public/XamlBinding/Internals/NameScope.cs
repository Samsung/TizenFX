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
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml;
using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Binding.Internals
{
    /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class NameScope : INameScope
    {
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty NameScopeProperty = BindableProperty.CreateAttached("NameScope", typeof(INameScope), typeof(NameScope), default(INameScope));

        readonly Dictionary<string, object> names = new Dictionary<string, object>();

        object INameScope.FindByName(string name)
        {
            if (names.ContainsKey(name))
                return names[name];
            return null;
        }

        void INameScope.RegisterName(string name, object scopedElement)
        {
            if (names.ContainsKey(name))
                throw new ArgumentException("An element with the same key already exists in NameScope", nameof(name));

            names[name] = scopedElement;
        }

        [ObsoleteAttribute(" ", false)]
        void INameScope.RegisterName(string name, object scopedElement, IXmlLineInfo xmlLineInfo)
        {
            try
            {
                ((INameScope)this).RegisterName(name, scopedElement);
            }
            catch (ArgumentException)
            {
                throw new XamlParseException(string.Format("An element with the name \"{0}\" already exists in this NameScope", name), xmlLineInfo);
            }
        }

        void INameScope.UnregisterName(string name)
        {
            names.Remove(name);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static INameScope GetNameScope(BindableObject bindable)
        {
            return (INameScope)bindable?.GetValue(NameScopeProperty);
        }

        /// <exception cref="ArgumentNullException"> Thrown when bindable is null. </exception>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void SetNameScope(BindableObject bindable, INameScope value)
        {
            if (null == bindable)
            {
                throw new ArgumentNullException(nameof(bindable));
            }
            bindable.SetValue(NameScopeProperty, value);
        }
    }
}
