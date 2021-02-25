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

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ObsoleteAttribute(" ", false)]
        public static Binding Create<TSource>(Expression<Func<TSource, object>> propertyGetter, BindingMode mode = BindingMode.Default, IValueConverter converter = null, object converterParameter = null,
                                              string stringFormat = null)
        {
            if (propertyGetter == null)
                throw new ArgumentNullException(nameof(propertyGetter));

            return new Binding(GetBindingPath(propertyGetter), mode, converter, converterParameter, stringFormat);
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

        [Obsolete]
        static string GetBindingPath<TSource>(Expression<Func<TSource, object>> propertyGetter)
        {
            Expression expr = propertyGetter.Body;

            var unary = expr as UnaryExpression;
            if (unary != null)
                expr = unary.Operand;

            var builder = new StringBuilder();

            var indexed = false;

            var member = expr as MemberExpression;
            if (member == null)
            {
                var methodCall = expr as MethodCallExpression;
                if (methodCall != null)
                {
                    if (methodCall.Arguments.Count == 0)
                        throw new ArgumentException("Method calls are not allowed in binding expression");

                    var arguments = new List<string>(methodCall.Arguments.Count);
                    foreach (Expression arg in methodCall.Arguments)
                    {
                        if (arg.NodeType != ExpressionType.Constant)
                            throw new ArgumentException("Only constants can be used as indexer arguments");

                        object value = ((ConstantExpression)arg).Value;
                        arguments.Add(value != null ? value.ToString() : "null");
                    }

                    Type declarerType = methodCall.Method.DeclaringType;
                    DefaultMemberAttribute defaultMember = declarerType.GetTypeInfo().GetCustomAttributes(typeof(DefaultMemberAttribute), true).OfType<DefaultMemberAttribute>().FirstOrDefault();
                    string indexerName = defaultMember != null ? defaultMember.MemberName : "Item";

                    MethodInfo getterInfo =
                        declarerType.GetProperties().Where(pi => (pi.GetMethod != null) && pi.Name == indexerName && pi.CanRead && pi.GetMethod.IsPublic && !pi.GetMethod.IsStatic).Select(pi => pi.GetMethod).FirstOrDefault();
                    if (getterInfo != null)
                    {
                        if (getterInfo == methodCall.Method)
                        {
                            indexed = true;
                            builder.Append("[");

                            var first = true;
                            foreach (string argument in arguments)
                            {
                                if (!first)
                                    builder.Append(",");

                                builder.Append(argument);
                                first = false;
                            }

                            builder.Append("]");

                            member = methodCall.Object as MemberExpression;
                        }
                        else
                            throw new ArgumentException("Method calls are not allowed in binding expressions");
                    }
                    else
                        throw new ArgumentException("Public indexer not found");
                }
                else
                    throw new ArgumentException("Invalid expression type");
            }

            while (member != null)
            {
                var property = (PropertyInfo)member.Member;
                if (builder.Length != 0)
                {
                    if (!indexed)
                        builder.Insert(0, ".");
                    else
                        indexed = false;
                }

                builder.Insert(0, property.Name);

                //				member = member.Expression as MemberExpression ?? (member.Expression as UnaryExpression)?.Operand as MemberExpression;
                member = member.Expression as MemberExpression ?? (member.Expression is UnaryExpression ? (member.Expression as UnaryExpression).Operand as MemberExpression : null);
            }

            return builder.ToString();
        }
    }
}
