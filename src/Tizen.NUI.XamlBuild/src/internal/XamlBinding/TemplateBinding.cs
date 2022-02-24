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
using System.Globalization;

namespace Tizen.NUI.Binding
{
    internal class TemplateBinding : BindingBase
    {
        internal const string SelfPath = ".";
        IValueConverter _converter;
        object _converterParameter;

        BindingExpression _expression;
        string _path;

        public TemplateBinding()
        {
        }

        public TemplateBinding(string path, BindingMode mode = BindingMode.Default, IValueConverter converter = null, object converterParameter = null, string stringFormat = null)
        {
            if (path == null)
                throw new ArgumentNullException("path");
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentException("path can not be an empty string", "path");

            AllowChaining = true;
            Path = path;
            Converter = converter;
            ConverterParameter = converterParameter;
            Mode = mode;
            StringFormat = stringFormat;
        }

        public IValueConverter Converter
        {
            get { return _converter; }
            set
            {
                ThrowIfApplied();

                _converter = value;
            }
        }

        public object ConverterParameter
        {
            get { return _converterParameter; }
            set
            {
                ThrowIfApplied();

                _converterParameter = value;
            }
        }

        public string Path
        {
            get { return _path; }
            set
            {
                ThrowIfApplied();

                _path = value;
                _expression = GetBindingExpression(value);
            }
        }

        internal override void Apply(bool fromTarget)
        {
            base.Apply(fromTarget);

            if (_expression == null)
                _expression = new BindingExpression(this, SelfPath);

            _expression.Apply(fromTarget);
        }

        internal override async void Apply(object newContext, BindableObject bindObj, BindableProperty targetProperty, bool fromBindingContextChanged = false)
        {
            var view = bindObj as Element;
            if (view == null)
                throw new InvalidOperationException();

            base.Apply(newContext, bindObj, targetProperty, fromBindingContextChanged);

            Element templatedParent = await TemplateUtilities.FindTemplatedParentAsync(view);
            ApplyInner(templatedParent, bindObj, targetProperty);
        }

        internal override BindingBase Clone()
        {
            return new TemplateBinding(Path, Mode) { Converter = Converter, ConverterParameter = ConverterParameter, StringFormat = StringFormat };
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
            base.Unapply(fromBindingContextChanged: fromBindingContextChanged);

            if (_expression != null)
                _expression.Unapply();
        }

        void ApplyInner(Element templatedParent, BindableObject bindableObject, BindableProperty targetProperty)
        {
            if (_expression == null && templatedParent != null)
                _expression = new BindingExpression(this, SelfPath);

            _expression?.Apply(templatedParent, bindableObject, targetProperty);
        }

        BindingExpression GetBindingExpression(string path)
        {
            return new BindingExpression(this, !string.IsNullOrWhiteSpace(path) ? path : SelfPath);
        }
    }
}
 
