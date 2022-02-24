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
using System.Linq;
using System.Reflection;
using System.Xml;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Xaml
{
    [ContentProperty(nameof(Member))]
    [ProvideCompiled("Tizen.NUI.Xaml.Build.Tasks.StaticExtension")]
    internal class StaticExtension : IMarkupExtension
    {
        public string Member { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            IXmlLineInfoProvider lineInfoProvider;
            IXmlLineInfo lineInfo;

            if (serviceProvider == null)
                throw new ArgumentNullException(nameof(serviceProvider));
            var typeResolver = serviceProvider.GetService(typeof (IXamlTypeResolver)) as IXamlTypeResolver;
            if (typeResolver == null)
                throw new ArgumentException("No IXamlTypeResolver in IServiceProvider");

            if (string.IsNullOrEmpty(Member) || !Member.Contains("."))
            {
                lineInfoProvider = serviceProvider.GetService(typeof (IXmlLineInfoProvider)) as IXmlLineInfoProvider;
                lineInfo = (lineInfoProvider != null) ? lineInfoProvider.XmlLineInfo : new XmlLineInfo();
                throw new XamlParseException("Syntax for x:Static is [Member=][prefix:]typeName.staticMemberName", lineInfo);
            }

            var dotIdx = Member.LastIndexOf('.');
            var typename = Member.Substring(0, dotIdx);
            var membername = Member.Substring(dotIdx + 1);

            var type = typeResolver.Resolve(typename, serviceProvider);

            var pinfo = type.GetRuntimeProperties().FirstOrDefault(pi => pi.Name == membername && pi.GetMethod.IsStatic);
            if (pinfo != null)
                return pinfo.GetMethod.Invoke(null, new object[] { });

            var finfo = type.GetRuntimeFields().FirstOrDefault(fi => fi.Name == membername && fi.IsStatic);
            if (finfo != null)
                return finfo.GetValue(null);

            lineInfoProvider = serviceProvider.GetService(typeof (IXmlLineInfoProvider)) as IXmlLineInfoProvider;
            lineInfo = (lineInfoProvider != null) ? lineInfoProvider.XmlLineInfo : new XmlLineInfo();
            throw new XamlParseException($"No static member found for {Member}", lineInfo);
        }
    }
}
 
