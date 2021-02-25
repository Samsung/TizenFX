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

using Tizen.NUI.Binding.Internals;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Xaml
{
    /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    [ContentProperty("Name")]
    public class ReferenceExtension : IMarkupExtension
    {
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Name { get; set; }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (serviceProvider == null)
                throw new ArgumentNullException(nameof(serviceProvider));
            var valueProvider = serviceProvider.GetService(typeof(IProvideValueTarget)) as IProvideParentValues;
            if (valueProvider == null)
                throw new ArgumentException("serviceProvider does not provide an IProvideValueTarget");
            var namescopeprovider = serviceProvider.GetService(typeof(INameScopeProvider)) as INameScopeProvider;
            if (namescopeprovider != null && namescopeprovider.NameScope != null)
            {
                var value = namescopeprovider.NameScope.FindByName(Name);
                if (value != null)
                    return value;
            }

            foreach (var target in valueProvider.ParentObjects)
            {
                var bo = target as BindableObject;
                if (bo == null)
                    continue;
                var ns = NameScope.GetNameScope(bo) as INameScope;
                if (ns == null)
                    continue;
                var value = ns.FindByName(Name);
                if (value != null)
                    return value;
            }
            //foreach (var target in valueProvider.ParentObjects)
            //{
            //    var ns = target as INameScope;
            //    if (ns == null)
            //        continue;
            //    var value = ns.FindByName(Name);
            //    if (value != null)
            //        return value;
            //}

            var lineInfo = (serviceProvider?.GetService(typeof(IXmlLineInfoProvider)) as IXmlLineInfoProvider)?.XmlLineInfo ?? new XmlLineInfo();
            throw new XamlParseException($"Can not find the object referenced by `{Name}`", lineInfo);
        }
    }
}
