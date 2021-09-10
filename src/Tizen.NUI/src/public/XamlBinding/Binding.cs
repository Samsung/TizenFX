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
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Diagnostics.CodeAnalysis;

namespace Tizen.NUI.Binding
{
    /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [SuppressMessage("Microsoft.Design", "CA1724: Type names should not match namespaces")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public sealed class Binding : BindingBase
    {
        internal const string SelfPath = ".";
        IValueConverter converter;
        object converterParameter;

        BindingExpression expression;
        string path;
        object source;
        string updateSourceEventName;

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Binding()
        {
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Binding(string path, BindingMode mode = BindingMode.Default, IValueConverter converter = null, object converterParameter = null, string stringFormat = null, object source = null)
        {
            if (path == null)
                throw new ArgumentNullException(nameof(path));
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentException("path can not be an empty string", nameof(path));

            Path = path;
            Converter = converter;
            ConverterParameter = converterParameter;
            Mode = mode;
            StringFormat = stringFormat;
            Source = source;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IValueConverter Converter
        {
            get { return converter; }
            set
            {
                ThrowIfApplied();

                converter = value;
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public object ConverterParameter
        {
            get { return converterParameter; }
            set
            {
                ThrowIfApplied();

                converterParameter = value;
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Path
        {
            get { return path; }
            set
            {
                ThrowIfApplied();

                path = value;
                expression = new BindingExpression(this, !string.IsNullOrWhiteSpace(value) ? value : SelfPath);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public object Source
        {
            get { return source; }
            set
            {
                ThrowIfApplied();
                source = value;

                if (source is BindableObject bindableObject)
                {
                    bindableObject.IsBinded = true;
                }
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string UpdateSourceEventName
        {
            get { return updateSourceEventName; }
            set
            {
                ThrowIfApplied();
                updateSourceEventName = value;
            }
        }

        internal override void Apply(bool fromTarget)
        {
            base.Apply(fromTarget);

            if (expression == null)
                expression = new BindingExpression(this, SelfPath);

            expression.Apply(fromTarget);
        }

        internal override void Apply(object newContext, BindableObject bindObj, BindableProperty targetProperty, bool fromBindingContextChanged = false)
        {
            object src = source;
            var isApplied = IsApplied;

            base.Apply(src ?? newContext, bindObj, targetProperty, fromBindingContextChanged: fromBindingContextChanged);

            if (src != null && isApplied && fromBindingContextChanged)
                return;

            object bindingContext = src ?? Context ?? newContext;
            if (expression == null && bindingContext != null)
                expression = new BindingExpression(this, SelfPath);

            expression?.Apply(bindingContext, bindObj, targetProperty);
        }

        internal override BindingBase Clone()
        {
            return new Binding(Path, Mode) { Converter = Converter, ConverterParameter = ConverterParameter, StringFormat = StringFormat, Source = Source, UpdateSourceEventName = UpdateSourceEventName };
        }

        internal override object GetSourceValue(object value, Type targetPropertyType)
        {
            if (Converter != null)
                value = Converter.Convert(value, targetPropertyType, ConverterParameter, CultureInfo.CurrentUICulture);

            return base.GetSourceValue(value, targetPropertyType);
        }

        internal override object GetTargetValue(object value, Type sourcePropertyType)
        {
            if (Converter != null)
                value = Converter.ConvertBack(value, sourcePropertyType, ConverterParameter, CultureInfo.CurrentUICulture);

            return base.GetTargetValue(value, sourcePropertyType);
        }

        internal override void Unapply(bool fromBindingContextChanged = false)
        {
            if (Source != null && fromBindingContextChanged && IsApplied)
                return;

            base.Unapply(fromBindingContextChanged: fromBindingContextChanged);

            if (expression != null)
                expression.Unapply();
        }
    }
}
