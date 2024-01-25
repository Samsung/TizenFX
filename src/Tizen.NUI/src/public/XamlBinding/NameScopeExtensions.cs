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

using System.Collections.Generic;
using System.ComponentModel;
using Tizen.NUI.Binding.Internals;

namespace Tizen.NUI.Binding
{
    /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class NameScopeExtensions
    {
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static T FindByName<T>(this Element element, string name)
        {
            return ((INameScope)element).FindByName<T>(name);
        }

        internal static T FindByName<T>(this INameScope namescope, string name)
        {
            return (T)namescope?.FindByName(name);
        }

        private static Stack<Element> elementStack = new Stack<Element>();

        internal static void PushElement(object element)
        {
            elementStack.Push((Element)element);
        }

        internal static void PopElement()
        {
            elementStack.Pop();
        }

        /// <summary>
        /// Used to find the object defined in Xaml file.
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static T FindByNameInCurrentNameScope<T>(string name)
        {
            return FindByName<T>(elementStack.Peek(), name);
        }
    }
}
