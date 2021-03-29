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
using System.Linq.Expressions;

namespace Tizen.NUI.Binding
{
    /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class BindableObjectExtensions
    {
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void SetBinding(this BindableObject self, BindableProperty targetProperty, string path, BindingMode mode = BindingMode.Default, IValueConverter converter = null,
                                      string stringFormat = null)
        {
            if (self == null)
                throw new ArgumentNullException(nameof(self));
            if (targetProperty == null)
                throw new ArgumentNullException(nameof(targetProperty));

            var binding = new Binding(path, mode, converter, stringFormat: stringFormat);
            self.SetBinding(targetProperty, binding);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ObsoleteAttribute(" ", false)]
        public static void SetBinding<TSource>(this BindableObject self, BindableProperty targetProperty, Expression<Func<TSource, object>> sourceProperty, BindingMode mode = BindingMode.Default,
                                               IValueConverter converter = null, string stringFormat = null)
        {
            if (self == null)
                throw new ArgumentNullException(nameof(self));
            if (targetProperty == null)
                throw new ArgumentNullException(nameof(targetProperty));
            if (sourceProperty == null)
                throw new ArgumentNullException(nameof(sourceProperty));

            Binding binding = Binding.Create(sourceProperty, mode, converter, stringFormat: stringFormat);
            self.SetBinding(targetProperty, binding);
        }
    }
}
