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
using System.Xml;
using System.Reflection;
using System.Linq;
using Tizen.NUI.Binding;
using System.ComponentModel;

namespace Tizen.NUI.Xaml
{
    /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    [ContentProperty("Key")]
    public sealed class StaticResourceExtension : IMarkupExtension
    {
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Key { get; set; }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (serviceProvider == null)
                throw new ArgumentNullException(nameof(serviceProvider));
            if (Key == null)
            {
                var lineInfoProvider = serviceProvider.GetService(typeof(IXmlLineInfoProvider)) as IXmlLineInfoProvider;
                var lineInfo = (lineInfoProvider != null) ? lineInfoProvider.XmlLineInfo : new XmlLineInfo();
                throw new XamlParseException("you must specify a key in {StaticResource}", lineInfo);
            }
            var valueProvider = serviceProvider.GetService(typeof(IProvideValueTarget)) as IProvideParentValues;
            if (valueProvider == null)
                throw new ArgumentException(nameof(valueProvider));
            var xmlLineInfoProvider = serviceProvider.GetService(typeof(IXmlLineInfoProvider)) as IXmlLineInfoProvider;
            var xmlLineInfo = xmlLineInfoProvider != null ? xmlLineInfoProvider.XmlLineInfo : null;
            object resource = null;

            foreach (var p in valueProvider.ParentObjects)
            {
                var irp = p as IResourcesProvider;
                var resDict = irp != null && irp.IsResourcesCreated ? irp.XamlResources : p as ResourceDictionary;
                if (resDict == null)
                    continue;
                if (resDict.TryGetValue(Key, out resource))
                    break;
            }
            resource = resource ?? GetApplicationLevelResource(Key, xmlLineInfo);

            var bp = valueProvider.TargetProperty as BindableProperty;
            var pi = valueProvider.TargetProperty as PropertyInfo;
            var propertyType = bp?.ReturnType ?? pi?.PropertyType;
            if (propertyType == null)
            {
                if (resource != null)
                {
                    if (resource.GetType().GetTypeInfo().IsGenericType && (resource.GetType().GetGenericTypeDefinition() == typeof(OnPlatform<>) || resource.GetType().GetGenericTypeDefinition() == typeof(OnIdiom<>)))
                    {
                        // This is only there to support our backward compat story with pre 2.3.3 compiled Xaml project who was not providing TargetProperty
                        var method = resource.GetType().GetRuntimeMethod("op_Implicit", new[] { resource.GetType() });
                        if (method != null)
                        {
                            resource = method.Invoke(null, new[] { resource });
                        }
                    }
                }
                return resource;
            }
            if (propertyType.IsAssignableFrom(resource?.GetType()))
                return resource;
            var implicit_op = resource?.GetType().GetImplicitConversionOperator(fromType: resource?.GetType(), toType: propertyType)
                            ?? propertyType.GetImplicitConversionOperator(fromType: resource?.GetType(), toType: propertyType);
            if (implicit_op != null)
                return implicit_op.Invoke(resource, new[] { resource });

            if (resource != null)
            {
                //Special case for https://bugzilla.xamarin.com/show_bug.cgi?id=59818
                //On OnPlatform, check for an opImplicit from the targetType
                if (Device.Flags != null
                    && Device.Flags.Contains("xamlDoubleImplicitOpHack")
                    && resource.GetType().GetTypeInfo().IsGenericType
                    && (resource.GetType().GetGenericTypeDefinition() == typeof(OnPlatform<>)))
                {
                    var tType = resource.GetType().GenericTypeArguments[0];
                    var opImplicit = tType.GetImplicitConversionOperator(fromType: tType, toType: propertyType)
                                    ?? propertyType.GetImplicitConversionOperator(fromType: tType, toType: propertyType);

                    if (opImplicit != null)
                    {
                        //convert the OnPlatform<T> to T
                        var opPlatformImplicitConversionOperator = resource?.GetType().GetImplicitConversionOperator(fromType: resource?.GetType(), toType: tType);
                        resource = opPlatformImplicitConversionOperator?.Invoke(null, new[] { resource });

                        //and convert to toType
                        resource = opImplicit.Invoke(null, new[] { resource });
                        return resource;
                    }
                }
            }
            return resource;
        }

        internal object GetApplicationLevelResource(string key, IXmlLineInfo xmlLineInfo)
        {
            object resource = null;
            if (Application.Current == null || !((IResourcesProvider)Application.Current).IsResourcesCreated || !Application.Current.XamlResources.TryGetValue(Key, out resource))
                throw new XamlParseException($"StaticResource not found for key {key}", xmlLineInfo);
            return resource;
        }
    }
}
