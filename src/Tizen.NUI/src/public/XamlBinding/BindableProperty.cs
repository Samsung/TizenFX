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
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;
using System.ComponentModel;
using Tizen.NUI.Binding.Internals;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Binding
{
    /// <summary>
    /// A BindableProperty is a backing store for properties allowing bindings on BindableObject.
    /// </summary>
    [DebuggerDisplay("{PropertyName}")]
    [TypeConverter(typeof(BindablePropertyConverter))]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public sealed class BindableProperty
    {
        /// <summary>
        /// Delegate for BindableProperty.PropertyChanged.
        /// </summary>
        /// <param name="bindable">The bindable object that contains the property.</param>
        /// <param name="oldValue">The old property value.</param>
        /// <param name="newValue">The new property value.</param>
        public delegate void BindingPropertyChangedDelegate(BindableObject bindable, object oldValue, object newValue);

        /// <summary>
        /// Strongly-typed delegate for BindableProperty.PropertyChanged.
        /// </summary>
        /// <typeparam name="TPropertyType">The type of the bound property.</typeparam>
        /// <param name="bindable">The bindable object that contains the property.</param>
        /// <param name="oldValue">The old property value.</param>
        /// <param name="newValue">The new property value.</param>
        public delegate void BindingPropertyChangedDelegate<in TPropertyType>(BindableObject bindable, TPropertyType oldValue, TPropertyType newValue);

        /// <summary>
        /// Delegate for BindableProperty.PropertyChanging.
        /// </summary>
        /// <param name="bindable">The bindable object that contains the property.</param>
        /// <param name="oldValue">The old property value.</param>
        /// <param name="newValue">The new property value.</param>
        public delegate void BindingPropertyChangingDelegate(BindableObject bindable, object oldValue, object newValue);

        /// <summary>
        /// Strongly-typed delegate for BindableProperty.PropertyChanging.
        /// </summary>
        /// <typeparam name="TPropertyType">The type of the bound property.</typeparam>
        /// <param name="bindable">The bindable object that contains the property.</param>
        /// <param name="oldValue">The old property value.</param>
        /// <param name="newValue">The new property value.</param>
        public delegate void BindingPropertyChangingDelegate<in TPropertyType>(BindableObject bindable, TPropertyType oldValue, TPropertyType newValue);

        /// <summary>
        /// Delegate for BindableProperty.CoerceValue.
        /// </summary>
        /// <param name="bindable">The bindable object that contains the property.</param>
        /// <param name="value">The value to coerce.</param>
        /// <returns>System.Object</returns>
        public delegate object CoerceValueDelegate(BindableObject bindable, object value);

        /// <summary>
        /// Strongly-typed delegate for BindableProperty.CoerceValue.
        /// </summary>
        /// <typeparam name="TPropertyType">The type of the bound property.</typeparam>
        /// <param name="bindable">The bindable object that contains the property.</param>
        /// <param name="value">The value to coerce.</param>
        /// <returns>TPropertyType</returns>
        public delegate TPropertyType CoerceValueDelegate<TPropertyType>(BindableObject bindable, TPropertyType value);

        /// <summary>
        /// Delegate for BindableProperty.DefaultValueCreator.
        /// </summary>
        /// <param name="bindable">The bindable object that contains the property.</param>
        /// <returns>System.Object</returns>
        public delegate object CreateDefaultValueDelegate(BindableObject bindable);

        /// <summary>
        /// Strongly-typed delegate for BindableProperty.DefaultValueCreator.
        /// </summary>
        /// <typeparam name="TDeclarer">The type of the object that delared the property.</typeparam>
        /// <typeparam name="TPropertyType">The type of the bound property.</typeparam>
        /// <param name="bindable">The bindable object that contains the property.</param>
        /// <returns>TPropertyType</returns>
        public delegate TPropertyType CreateDefaultValueDelegate<in TDeclarer, out TPropertyType>(TDeclarer bindable);

        /// <summary>
        /// Delegate for BindableProperty.ValidateValue.
        /// </summary>
        /// <param name="bindable">The bindable object that contains the property.</param>
        /// <param name="value">The default value.</param>
        /// <returns>System.Boolean</returns>
        public delegate bool ValidateValueDelegate(BindableObject bindable, object value);

        /// <summary>
        /// Strongly-typed delegate for BindableProperty.ValidateValue.
        /// </summary>
        /// <typeparam name="TPropertyType">The type of the bound property.</typeparam>
        /// <param name="bindable">The bindable object that contains the property.</param>
        /// <param name="value">The default value.</param>
        /// <returns>System.Boolean</returns>
        public delegate bool ValidateValueDelegate<in TPropertyType>(BindableObject bindable, TPropertyType value);

        //To confirm the static dictionary will be created before the constructor is called.
        static BindableProperty()
        {
        }

        static readonly Dictionary<Type, TypeConverter> WellKnownConvertTypes = new Dictionary<Type, TypeConverter>
        {
            { typeof(Uri), new UriTypeConverter() },
            { typeof(Color), new ColorTypeConverter() },
            { typeof(Size2D), new Size2DTypeConverter() },
            { typeof(Position2D), new Position2DTypeConverter() },
            { typeof(Size), new SizeTypeConverter() },
            { typeof(Position), new PositionTypeConverter() },
            { typeof(Rectangle), new RectangleTypeConverter() },
            { typeof(Rotation), new RotationTypeConverter() },
            { typeof(Vector2), new Vector2TypeConverter() },
            { typeof(Vector3), new Vector3TypeConverter() },
            { typeof(Vector4), new Vector4TypeConverter() },
            { typeof(RelativeVector2), new RelativeVector2TypeConverter() },
            { typeof(RelativeVector3), new RelativeVector3TypeConverter() },
            { typeof(RelativeVector4), new RelativeVector4TypeConverter() },
        };

        //Modification for NUI XAML : user defined converter for DynamicResource can be added
        static internal Dictionary<Type, TypeConverter> UserCustomConvertTypes = new Dictionary<Type, TypeConverter>
        {
        };

        // more or less the encoding of this, without the need to reflect
        // http://msdn.microsoft.com/en-us/library/y5b434w4.aspx
        static readonly Dictionary<Type, Type[]> SimpleConvertTypes = new Dictionary<Type, Type[]>
        {
            { typeof(sbyte), new[] { typeof(string), typeof(short), typeof(int), typeof(long), typeof(float), typeof(double), typeof(decimal) } },
            { typeof(byte), new[] { typeof(string), typeof(short), typeof(ushort), typeof(int), typeof(uint), typeof(ulong), typeof(float), typeof(double), typeof(decimal) } },
            { typeof(short), new[] { typeof(string), typeof(int), typeof(long), typeof(float), typeof(double), typeof(decimal) } },
            { typeof(ushort), new[] { typeof(string), typeof(int), typeof(uint), typeof(long), typeof(ulong), typeof(float), typeof(double), typeof(decimal) } },
            { typeof(int), new[] { typeof(string), typeof(long), typeof(float), typeof(double), typeof(decimal) } },
            { typeof(uint), new[] { typeof(string), typeof(long), typeof(ulong), typeof(float), typeof(double), typeof(decimal) } },
            { typeof(long), new[] { typeof(string), typeof(float), typeof(double), typeof(decimal) } },
            { typeof(char), new[] { typeof(string), typeof(ushort), typeof(int), typeof(uint), typeof(long), typeof(ulong), typeof(float), typeof(double), typeof(decimal) } },
            { typeof(float), new[] { typeof(string), typeof(double) } },
            { typeof(ulong), new[] { typeof(string), typeof(float), typeof(double), typeof(decimal) } }
        };

        BindableProperty(string propertyName, Type returnType, Type declaringType, object defaultValue, BindingMode defaultBindingMode = BindingMode.OneWay,
                                 ValidateValueDelegate validateValue = null, BindingPropertyChangedDelegate propertyChanged = null, BindingPropertyChangingDelegate propertyChanging = null,
                                 CoerceValueDelegate coerceValue = null, BindablePropertyBindingChanging bindingChanging = null, bool isReadOnly = false, CreateDefaultValueDelegate defaultValueCreator = null)
        {
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName));
            if (ReferenceEquals(returnType, null))
                throw new ArgumentNullException(nameof(returnType));
            if (ReferenceEquals(declaringType, null))
                throw new ArgumentNullException(nameof(declaringType));

            // don't use Enum.IsDefined as its redonkulously expensive for what it does
            if (defaultBindingMode != BindingMode.Default && defaultBindingMode != BindingMode.OneWay && defaultBindingMode != BindingMode.OneWayToSource && defaultBindingMode != BindingMode.TwoWay && defaultBindingMode != BindingMode.OneTime)
                throw new ArgumentException("Not a valid type of BindingMode", nameof(defaultBindingMode));
            if (defaultValue == null && Nullable.GetUnderlyingType(returnType) == null && returnType.GetTypeInfo().IsValueType)
                throw new ArgumentException("Not a valid default value", nameof(defaultValue));
            if (defaultValue != null && !returnType.IsInstanceOfType(defaultValue))
                throw new ArgumentException("Default value did not match return type", nameof(defaultValue));
            if (defaultBindingMode == BindingMode.Default)
                defaultBindingMode = BindingMode.OneWay;

            PropertyName = propertyName;
            ReturnType = returnType;
            ReturnTypeInfo = returnType.GetTypeInfo();
            DeclaringType = declaringType;
            DefaultValue = defaultValue;
            DefaultBindingMode = defaultBindingMode;
            PropertyChanged = propertyChanged;
            PropertyChanging = propertyChanging;
            ValidateValue = validateValue;
            CoerceValue = coerceValue;
            BindingChanging = bindingChanging;
            IsReadOnly = isReadOnly;
            DefaultValueCreator = defaultValueCreator;

            Dictionary<string, BindableProperty> nameToBindableProperty;
            bindablePropertyOfType.TryGetValue(declaringType, out nameToBindableProperty);
            if (null == nameToBindableProperty)
            {
                nameToBindableProperty = new Dictionary<string, BindableProperty>();
                bindablePropertyOfType.Add(declaringType, nameToBindableProperty);
            }

            if (!nameToBindableProperty.ContainsKey(propertyName))
            {
                nameToBindableProperty.Add(propertyName, this);
            }
            else
            {
                nameToBindableProperty[propertyName] = this;
            }
        }

        private static bool AddParentTypeProperty(Type type, Dictionary<string, BindableProperty> propertyDict)
        {
            bool ret = false;

            if (null != type)
            {
                Dictionary<string, BindableProperty> nameToBindableProperty;
                bindablePropertyOfType.TryGetValue(type, out nameToBindableProperty);

                if (null != nameToBindableProperty)
                {
                    ret = true;

                    foreach (KeyValuePair<string, BindableProperty> keyValuePair in nameToBindableProperty)
                    {
                        if (!propertyDict.ContainsKey(keyValuePair.Key))
                        {
                            propertyDict.Add(keyValuePair.Key, keyValuePair.Value);
                        }
                    }
                }

                if (true == AddParentTypeProperty(type.BaseType, propertyDict))
                {
                    ret = true;
                }
            }

            return ret;
        }

        static internal Dictionary<Type, Dictionary<string, BindableProperty>> bindablePropertyOfType = new Dictionary<Type, Dictionary<string, BindableProperty>>();
        static private HashSet<Type> baseTypePropertyHasBeenAdded = new HashSet<Type>();

        static internal void GetBindablePropertysOfType(Type type, out Dictionary<string, BindableProperty> dictionary)
        {
            dictionary = null;

            bindablePropertyOfType.TryGetValue(type, out dictionary);

            if (!baseTypePropertyHasBeenAdded.Contains(type))
            {
                bool isCurDictNull = false;

                if (null == dictionary)
                {
                    isCurDictNull = true;
                    dictionary = new Dictionary<string, BindableProperty>();
                }

                if (true == AddParentTypeProperty(type.BaseType, dictionary) && true == isCurDictNull)
                {
                    bindablePropertyOfType.Add(type, dictionary);
                }

                baseTypePropertyHasBeenAdded.Add(type);
            }
        }

        /// <summary>
        /// Gets the type declaring the BindableProperty.
        /// </summary>
        public Type DeclaringType { get; private set; }

        /// <summary>
        /// Gets the default BindingMode.
        /// </summary>
        public BindingMode DefaultBindingMode { get; private set; }

        /// <summary>
        /// Gets the default value for the BindableProperty.
        /// </summary>
        public object DefaultValue { get; }

        /// <summary>
        /// Gets a value indicating if the BindableProperty is created form a BindablePropertyKey.
        /// </summary>
        public bool IsReadOnly { get; private set; }

        /// <summary>
        /// Gets the property name.
        /// </summary>
        public string PropertyName { get; }

        /// <summary>
        /// Gets the type of the BindableProperty.
        /// </summary>
        public Type ReturnType { get; }

        internal BindablePropertyBindingChanging BindingChanging { get; private set; }

        internal CoerceValueDelegate CoerceValue { get; private set; }

        internal CreateDefaultValueDelegate DefaultValueCreator { get; }

        internal BindingPropertyChangedDelegate PropertyChanged { get; private set; }

        internal BindingPropertyChangingDelegate PropertyChanging { get; private set; }

        internal System.Reflection.TypeInfo ReturnTypeInfo { get; }

        internal ValidateValueDelegate ValidateValue { get; private set; }

        /// <summary>
        /// Deprecated. Do not use.
        /// </summary>
        /// <typeparam name="TDeclarer">The type of the declaring object.</typeparam>
        /// <typeparam name="TPropertyType">The type of the property.</typeparam>
        /// <param name="getter">An expression identifying the getter for the property using this BindableProperty as backing store.</param>
        /// <param name="defaultValue">The default value for the property.</param>
        /// <param name="defaultBindingMode">The BindingMode to use on SetBinding() if no BindingMode is given. This parameter is optional. Default is BindingMode.OneWay.</param>
        /// <param name="validateValue">A delegate to be run when a value is set. This parameter is optional. Default is null.</param>
        /// <param name="propertyChanged">A delegate to be run when the value has changed. This parameter is optional. Default is null.</param>
        /// <param name="propertyChanging">A delegate to be run when the value will change. This parameter is optional. Default is null.</param>
        /// <param name="coerceValue">A delegate used to coerce the range of a value. This parameter is optional. Default is null.</param>
        /// <param name="defaultValueCreator">A Func used to initialize default value for reference types.</param>
        /// <returns>A newly created BindableProperty.</returns>
        [Obsolete("Create<> (generic) is obsolete as of version 2.1.0 and is no longer supported.")]
        public static BindableProperty Create<TDeclarer, TPropertyType>(Expression<Func<TDeclarer, TPropertyType>> getter, TPropertyType defaultValue, BindingMode defaultBindingMode = BindingMode.OneWay,
                                                                        ValidateValueDelegate<TPropertyType> validateValue = null, BindingPropertyChangedDelegate<TPropertyType> propertyChanged = null,
                                                                        BindingPropertyChangingDelegate<TPropertyType> propertyChanging = null, CoerceValueDelegate<TPropertyType> coerceValue = null,
                                                                        CreateDefaultValueDelegate<TDeclarer, TPropertyType> defaultValueCreator = null) where TDeclarer : BindableObject
        {
            return Create(getter, defaultValue, defaultBindingMode, validateValue, propertyChanged, propertyChanging, coerceValue, null, defaultValueCreator: defaultValueCreator);
        }

        /// <summary>
        /// Creates a new instance of the BindableProperty class.
        /// </summary>
        /// <param name="propertyName">The name of the BindableProperty.</param>
        /// <param name="returnType">The type of the property.</param>
        /// <param name="declaringType">The type of the declaring object.</param>
        /// <param name="defaultValue">The default value for the property.</param>
        /// <param name="defaultBindingMode">The BindingMode to use on SetBinding() if no BindingMode is given. This parameter is optional. Default is BindingMode.OneWay.</param>
        /// <param name="validateValue">A delegate to be run when a value is set. This parameter is optional. Default is null.</param>
        /// <param name="propertyChanged">A delegate to be run when the value has changed. This parameter is optional. Default is null.</param>
        /// <param name="propertyChanging">A delegate to be run when the value will change. This parameter is optional. Default is null.</param>
        /// <param name="coerceValue">A delegate used to coerce the range of a value. This parameter is optional. Default is null.</param>
        /// <param name="defaultValueCreator">A Func used to initialize default value for reference types.</param>
        /// <returns>A newly created BindableProperty.</returns>
        public static BindableProperty Create(string propertyName, Type returnType, Type declaringType, object defaultValue = null, BindingMode defaultBindingMode = BindingMode.OneWay,
                                              ValidateValueDelegate validateValue = null, BindingPropertyChangedDelegate propertyChanged = null, BindingPropertyChangingDelegate propertyChanging = null,
                                              CoerceValueDelegate coerceValue = null, CreateDefaultValueDelegate defaultValueCreator = null)
        {
            return new BindableProperty(propertyName, returnType, declaringType, defaultValue, defaultBindingMode, validateValue, propertyChanged, propertyChanging, coerceValue,
                defaultValueCreator: defaultValueCreator);
        }

        /// <summary>
        /// Deprecated. Do not use.
        /// </summary>
        /// <typeparam name="TDeclarer">The type of the declaring object.</typeparam>
        /// <typeparam name="TPropertyType">The type of the property.</typeparam>
        /// <param name="staticgetter">An expression identifying a static method returning the value of the property using this BindableProperty as backing store.</param>
        /// <param name="defaultValue">The default value for the property.</param>
        /// <param name="defaultBindingMode">The BindingMode to use on SetBinding() if no BindingMode is given. This parameter is optional. Default is BindingMode.OneWay.</param>
        /// <param name="validateValue">A delegate to be run when a value is set. This parameter is optional. Default is null.</param>
        /// <param name="propertyChanged">A delegate to be run when the value has changed. This parameter is optional. Default is null.</param>
        /// <param name="propertyChanging">A delegate to be run when the value will change. This parameter is optional. Default is null.</param>
        /// <param name="coerceValue">A delegate used to coerce the range of a value. This parameter is optional. Default is null.</param>
        /// <param name="defaultValueCreator">A Func used to initialize default value for reference types.</param>
        [Obsolete("CreateAttached<> (generic) is obsolete as of version 2.1.0 and is no longer supported.")]
        public static BindableProperty CreateAttached<TDeclarer, TPropertyType>(Expression<Func<BindableObject, TPropertyType>> staticgetter, TPropertyType defaultValue,
                                                                                BindingMode defaultBindingMode = BindingMode.OneWay, ValidateValueDelegate<TPropertyType> validateValue = null, BindingPropertyChangedDelegate<TPropertyType> propertyChanged = null,
                                                                                BindingPropertyChangingDelegate<TPropertyType> propertyChanging = null, CoerceValueDelegate<TPropertyType> coerceValue = null,
                                                                                CreateDefaultValueDelegate<BindableObject, TPropertyType> defaultValueCreator = null)
        {
            return CreateAttached<TDeclarer, TPropertyType>(staticgetter, defaultValue, defaultBindingMode, validateValue, propertyChanged, propertyChanging, coerceValue, null,
                defaultValueCreator: defaultValueCreator);
        }

        /// <summary>
        /// Creates a new instance of the BindableProperty class for an attached property.
        /// </summary>
        /// <param name="propertyName">The name of the BindableProperty.</param>
        /// <param name="returnType">The type of the property.</param>
        /// <param name="declaringType">The type of the declaring object.</param>
        /// <param name="defaultValue">The default value for the property.</param>
        /// <param name="defaultBindingMode">The BindingMode to use on SetBinding() if no BindingMode is given. This parameter is optional. Default is BindingMode.OneWay.</param>
        /// <param name="validateValue">A delegate to be run when a value is set. This parameter is optional. Default is null.</param>
        /// <param name="propertyChanged">A delegate to be run when the value has changed. This parameter is optional. Default is null.</param>
        /// <param name="propertyChanging">A delegate to be run when the value will change. This parameter is optional. Default is null.</param>
        /// <param name="coerceValue">A delegate used to coerce the range of a value. This parameter is optional. Default is null.</param>
        /// <param name="defaultValueCreator">A Func used to initialize default value for reference types.</param>
        /// <returns>A newly created BindableProperty.</returns>
        public static BindableProperty CreateAttached(string propertyName, Type returnType, Type declaringType, object defaultValue, BindingMode defaultBindingMode = BindingMode.OneWay,
                                                      ValidateValueDelegate validateValue = null, BindingPropertyChangedDelegate propertyChanged = null, BindingPropertyChangingDelegate propertyChanging = null,
                                                      CoerceValueDelegate coerceValue = null, CreateDefaultValueDelegate defaultValueCreator = null)
        {
            return CreateAttached(propertyName, returnType, declaringType, defaultValue, defaultBindingMode, validateValue, propertyChanged, propertyChanging, coerceValue, null, false, defaultValueCreator);
        }

        /// <summary>
        /// Deprecated. Do not use.
        /// </summary>
        /// <typeparam name="TDeclarer">The type of the declaring object.</typeparam>
        /// <typeparam name="TPropertyType">The type of the property.</typeparam>
        /// <param name="staticgetter">An expression identifying a static method returning the value of the property using this BindableProperty as backing store.</param>
        /// <param name="defaultValue">The default value for the property.</param>
        /// <param name="defaultBindingMode">The BindingMode to use on SetBinding() if no BindingMode is given. This parameter is optional. Default is BindingMode.OneWay.</param>
        /// <param name="validateValue">A delegate to be run when a value is set. This parameter is optional. Default is null.</param>
        /// <param name="propertyChanged">A delegate to be run when the value has changed. This parameter is optional. Default is null.</param>
        /// <param name="propertyChanging">A delegate to be run when the value will change. This parameter is optional. Default is null.</param>
        /// <param name="coerceValue">A delegate used to coerce the range of a value. This parameter is optional. Default is null.</param>
        /// <param name="defaultValueCreator">A Func used to initialize default value for reference types.</param>
        /// <returns>A newly created attached read-only BindablePropertyKey.</returns>
        [Obsolete("CreateAttachedReadOnly<> (generic) is obsolete as of version 2.1.0 and is no longer supported.")]
        public static BindablePropertyKey CreateAttachedReadOnly<TDeclarer, TPropertyType>(Expression<Func<BindableObject, TPropertyType>> staticgetter, TPropertyType defaultValue,
                                                                                           BindingMode defaultBindingMode = BindingMode.OneWayToSource, ValidateValueDelegate<TPropertyType> validateValue = null,
                                                                                           BindingPropertyChangedDelegate<TPropertyType> propertyChanged = null, BindingPropertyChangingDelegate<TPropertyType> propertyChanging = null,
                                                                                           CoerceValueDelegate<TPropertyType> coerceValue = null, CreateDefaultValueDelegate<BindableObject, TPropertyType> defaultValueCreator = null)

        {
            return
                new BindablePropertyKey(CreateAttached<TDeclarer, TPropertyType>(staticgetter, defaultValue, defaultBindingMode, validateValue, propertyChanged, propertyChanging, coerceValue, null, true,
                    defaultValueCreator));
        }

        /// <summary>
        /// Creates a new instance of the BindableProperty class for attached read-only properties.
        /// </summary>
        /// <param name="propertyName">The name of the BindableProperty.</param>
        /// <param name="returnType">The type of the property.</param>
        /// <param name="declaringType">The type of the declaring object.</param>
        /// <param name="defaultValue">The default value for the property.</param>
        /// <param name="defaultBindingMode">The BindingMode to use on SetBinding() if no BindingMode is given. This parameter is optional. Default is BindingMode.OneWay.</param>
        /// <param name="validateValue">A delegate to be run when a value is set. This parameter is optional. Default is null.</param>
        /// <param name="propertyChanged">A delegate to be run when the value has changed. This parameter is optional. Default is null.</param>
        /// <param name="propertyChanging">A delegate to be run when the value will change. This parameter is optional. Default is null.</param>
        /// <param name="coerceValue">A delegate used to coerce the range of a value. This parameter is optional. Default is null.</param>
        /// <param name="defaultValueCreator">A Func used to initialize default value for reference types.</param>
        /// <returns>A newly created attached read-only BindablePropertyKey.</returns>
        public static BindablePropertyKey CreateAttachedReadOnly(string propertyName, Type returnType, Type declaringType, object defaultValue, BindingMode defaultBindingMode = BindingMode.OneWayToSource,
                                                                 ValidateValueDelegate validateValue = null, BindingPropertyChangedDelegate propertyChanged = null, BindingPropertyChangingDelegate propertyChanging = null,
                                                                 CoerceValueDelegate coerceValue = null, CreateDefaultValueDelegate defaultValueCreator = null)
        {
            return
                new BindablePropertyKey(CreateAttached(propertyName, returnType, declaringType, defaultValue, defaultBindingMode, validateValue, propertyChanged, propertyChanging, coerceValue, null, true,
                    defaultValueCreator));
        }

        /// <summary>
        /// Deprecated. Do not use.
        /// </summary>
        /// <typeparam name="TDeclarer">The type of the declaring object.</typeparam>
        /// <typeparam name="TPropertyType">The type of the property.</typeparam>
        /// <param name="getter">An expression identifying the getter for the property using this BindableProperty as backing store.</param>
        /// <param name="defaultValue">The default value for the property.</param>
        /// <param name="defaultBindingMode">The BindingMode to use on SetBinding() if no BindingMode is given. This parameter is optional. Default is BindingMode.OneWay.</param>
        /// <param name="validateValue">A delegate to be run when a value is set. This parameter is optional. Default is null.</param>
        /// <param name="propertyChanged">A delegate to be run when the value has changed. This parameter is optional. Default is null.</param>
        /// <param name="propertyChanging">A delegate to be run when the value will change. This parameter is optional. Default is null.</param>
        /// <param name="coerceValue">A delegate used to coerce the range of a value. This parameter is optional. Default is null.</param>
        /// <param name="defaultValueCreator">A Func used to initialize default value for reference types.</param>
        /// <returns>A newly created BindablePropertyKey.</returns>
        [Obsolete("CreateReadOnly<> (generic) is obsolete as of version 2.1.0 and is no longer supported.")]
        public static BindablePropertyKey CreateReadOnly<TDeclarer, TPropertyType>(Expression<Func<TDeclarer, TPropertyType>> getter, TPropertyType defaultValue,
                                                                                   BindingMode defaultBindingMode = BindingMode.OneWayToSource, ValidateValueDelegate<TPropertyType> validateValue = null,
                                                                                   BindingPropertyChangedDelegate<TPropertyType> propertyChanged = null, BindingPropertyChangingDelegate<TPropertyType> propertyChanging = null,
                                                                                   CoerceValueDelegate<TPropertyType> coerceValue = null, CreateDefaultValueDelegate<TDeclarer, TPropertyType> defaultValueCreator = null) where TDeclarer : BindableObject
        {
            return new BindablePropertyKey(Create(getter, defaultValue, defaultBindingMode, validateValue, propertyChanged, propertyChanging, coerceValue, null, true, defaultValueCreator));
        }

        /// <summary>
        /// Creates a new instance of the BindablePropertyKey class.
        /// </summary>
        /// <param name="propertyName">The name of the BindableProperty.</param>
        /// <param name="returnType">The type of the property.</param>
        /// <param name="declaringType">The type of the declaring object.</param>
        /// <param name="defaultValue">The default value for the property.</param>
        /// <param name="defaultBindingMode">The BindingMode to use on SetBinding() if no BindingMode is given. This parameter is optional. Default is BindingMode.OneWay.</param>
        /// <param name="validateValue">A delegate to be run when a value is set. This parameter is optional. Default is null.</param>
        /// <param name="propertyChanged">A delegate to be run when the value has changed. This parameter is optional. Default is null.</param>
        /// <param name="propertyChanging">A delegate to be run when the value will change. This parameter is optional. Default is null.</param>
        /// <param name="coerceValue">A delegate used to coerce the range of a value. This parameter is optional. Default is null.</param>
        /// <param name="defaultValueCreator">A Func used to initialize default value for reference types.</param>
        /// <returns>A newly created BindablePropertyKey.</returns>
        public static BindablePropertyKey CreateReadOnly(string propertyName, Type returnType, Type declaringType, object defaultValue, BindingMode defaultBindingMode = BindingMode.OneWayToSource,
                                                         ValidateValueDelegate validateValue = null, BindingPropertyChangedDelegate propertyChanged = null, BindingPropertyChangingDelegate propertyChanging = null,
                                                         CoerceValueDelegate coerceValue = null, CreateDefaultValueDelegate defaultValueCreator = null)
        {
            return
                new BindablePropertyKey(new BindableProperty(propertyName, returnType, declaringType, defaultValue, defaultBindingMode, validateValue, propertyChanged, propertyChanging, coerceValue,
                    isReadOnly: true, defaultValueCreator: defaultValueCreator));
        }

        [Obsolete("Create<> (generic) is obsolete as of version 2.1.0 and is no longer supported.")]
        internal static BindableProperty Create<TDeclarer, TPropertyType>(Expression<Func<TDeclarer, TPropertyType>> getter, TPropertyType defaultValue, BindingMode defaultBindingMode,
                                                                          ValidateValueDelegate<TPropertyType> validateValue, BindingPropertyChangedDelegate<TPropertyType> propertyChanged, BindingPropertyChangingDelegate<TPropertyType> propertyChanging,
                                                                          CoerceValueDelegate<TPropertyType> coerceValue, BindablePropertyBindingChanging bindingChanging, bool isReadOnly = false,
                                                                          CreateDefaultValueDelegate<TDeclarer, TPropertyType> defaultValueCreator = null) where TDeclarer : BindableObject
        {
            if (getter == null)
                throw new ArgumentNullException(nameof(getter));

            Expression expr = getter.Body;

            var unary = expr as UnaryExpression;
            if (unary != null)
                expr = unary.Operand;

            var member = expr as MemberExpression;
            if (member == null)
                throw new ArgumentException("getter must be a MemberExpression", nameof(getter));

            var property = (PropertyInfo)member.Member;

            ValidateValueDelegate untypedValidateValue = null;
            BindingPropertyChangedDelegate untypedBindingPropertyChanged = null;
            BindingPropertyChangingDelegate untypedBindingPropertyChanging = null;
            CoerceValueDelegate untypedCoerceValue = null;
            CreateDefaultValueDelegate untypedDefaultValueCreator = null;
            if (validateValue != null)
                untypedValidateValue = (bindable, value) => validateValue(bindable, (TPropertyType)value);
            if (propertyChanged != null)
                untypedBindingPropertyChanged = (bindable, oldValue, newValue) => propertyChanged(bindable, (TPropertyType)oldValue, (TPropertyType)newValue);
            if (propertyChanging != null)
                untypedBindingPropertyChanging = (bindable, oldValue, newValue) => propertyChanging(bindable, (TPropertyType)oldValue, (TPropertyType)newValue);
            if (coerceValue != null)
                untypedCoerceValue = (bindable, value) => coerceValue(bindable, (TPropertyType)value);
            if (defaultValueCreator != null)
                untypedDefaultValueCreator = o => defaultValueCreator((TDeclarer)o);

            return new BindableProperty(property.Name, property.PropertyType, typeof(TDeclarer), defaultValue, defaultBindingMode, untypedValidateValue, untypedBindingPropertyChanged,
                untypedBindingPropertyChanging, untypedCoerceValue, bindingChanging, isReadOnly, untypedDefaultValueCreator);
        }

        internal static BindableProperty Create(string propertyName, Type returnType, Type declaringType, object defaultValue, BindingMode defaultBindingMode, ValidateValueDelegate validateValue,
                                                BindingPropertyChangedDelegate propertyChanged, BindingPropertyChangingDelegate propertyChanging, CoerceValueDelegate coerceValue, BindablePropertyBindingChanging bindingChanging,
                                                CreateDefaultValueDelegate defaultValueCreator = null)
        {
            return new BindableProperty(propertyName, returnType, declaringType, defaultValue, defaultBindingMode, validateValue, propertyChanged, propertyChanging, coerceValue, bindingChanging,
                defaultValueCreator: defaultValueCreator);
        }

        [Obsolete("CreateAttached<> (generic) is obsolete as of version 2.1.0 and is no longer supported.")]
        internal static BindableProperty CreateAttached<TDeclarer, TPropertyType>(Expression<Func<BindableObject, TPropertyType>> staticgetter, TPropertyType defaultValue, BindingMode defaultBindingMode,
                                                                                  ValidateValueDelegate<TPropertyType> validateValue, BindingPropertyChangedDelegate<TPropertyType> propertyChanged, BindingPropertyChangingDelegate<TPropertyType> propertyChanging,
                                                                                  CoerceValueDelegate<TPropertyType> coerceValue, BindablePropertyBindingChanging bindingChanging, bool isReadOnly = false,
                                                                                  CreateDefaultValueDelegate<BindableObject, TPropertyType> defaultValueCreator = null)
        {
            if (staticgetter == null)
                throw new ArgumentNullException(nameof(staticgetter));

            Expression expr = staticgetter.Body;

            var unary = expr as UnaryExpression;
            if (unary != null)
                expr = unary.Operand;

            var methodcall = expr as MethodCallExpression;
            if (methodcall == null)
                throw new ArgumentException("staticgetter must be a MethodCallExpression", nameof(staticgetter));

            MethodInfo method = methodcall.Method;
            if (!method.Name.StartsWith("Get", StringComparison.Ordinal))
                throw new ArgumentException("staticgetter name must start with Get", nameof(staticgetter));

            string propertyname = method.Name.Substring(3);

            ValidateValueDelegate untypedValidateValue = null;
            BindingPropertyChangedDelegate untypedBindingPropertyChanged = null;
            BindingPropertyChangingDelegate untypedBindingPropertyChanging = null;
            CoerceValueDelegate untypedCoerceValue = null;
            CreateDefaultValueDelegate untypedDefaultValueCreator = null;
            if (validateValue != null)
                untypedValidateValue = (bindable, value) => validateValue(bindable, (TPropertyType)value);
            if (propertyChanged != null)
                untypedBindingPropertyChanged = (bindable, oldValue, newValue) => propertyChanged(bindable, (TPropertyType)oldValue, (TPropertyType)newValue);
            if (propertyChanging != null)
                untypedBindingPropertyChanging = (bindable, oldValue, newValue) => propertyChanging(bindable, (TPropertyType)oldValue, (TPropertyType)newValue);
            if (coerceValue != null)
                untypedCoerceValue = (bindable, value) => coerceValue(bindable, (TPropertyType)value);
            if (defaultValueCreator != null)
                untypedDefaultValueCreator = o => defaultValueCreator(o);

            return new BindableProperty(propertyname, method.ReturnType, typeof(TDeclarer), defaultValue, defaultBindingMode, untypedValidateValue, untypedBindingPropertyChanged, untypedBindingPropertyChanging,
                untypedCoerceValue, bindingChanging, isReadOnly, untypedDefaultValueCreator);
        }

        internal static BindableProperty CreateAttached(string propertyName, Type returnType, Type declaringType, object defaultValue, BindingMode defaultBindingMode, ValidateValueDelegate validateValue,
                                                        BindingPropertyChangedDelegate propertyChanged, BindingPropertyChangingDelegate propertyChanging, CoerceValueDelegate coerceValue, BindablePropertyBindingChanging bindingChanging,
                                                        bool isReadOnly, CreateDefaultValueDelegate defaultValueCreator = null)
        {
            return new BindableProperty(propertyName, returnType, declaringType, defaultValue, defaultBindingMode, validateValue, propertyChanged, propertyChanging, coerceValue, bindingChanging, isReadOnly,
                defaultValueCreator);
        }

        internal object GetDefaultValue(BindableObject bindable)
        {
            if (DefaultValueCreator != null)
                return DefaultValueCreator(bindable);

            return DefaultValue;
        }

        internal bool TryConvert(ref object value)
        {
            if (value == null)
            {
                return !ReturnTypeInfo.IsValueType || ReturnTypeInfo.IsGenericType && ReturnTypeInfo.GetGenericTypeDefinition() == typeof(Nullable<>);
            }

            Type valueType = value.GetType();
            Type type = ReturnType;

            // Dont support arbitrary IConvertible by limiting which types can use this
            Type[] convertableTo;
            TypeConverter typeConverterTo;
            if (SimpleConvertTypes.TryGetValue(valueType, out convertableTo) && Array.IndexOf(convertableTo, type) != -1)
            {
                value = Convert.ChangeType(value, type);
            }
            else if (WellKnownConvertTypes.TryGetValue(type, out typeConverterTo) && typeConverterTo.CanConvertFrom(valueType))
            {
                value = typeConverterTo.ConvertFromInvariantString(value.ToString());
            }
            else if (UserCustomConvertTypes.TryGetValue(type, out typeConverterTo) && typeConverterTo.CanConvertFrom(valueType))
            {
                //Modification for NUI XAML : user defined converter for DynamicResource can be added
                value = typeConverterTo.ConvertFromInvariantString(value.ToString());
            }
            else if (!ReturnTypeInfo.IsAssignableFrom(valueType.GetTypeInfo()))
            {
                var cast = type.GetImplicitConversionOperator(fromType: valueType, toType: type)
                        ?? valueType.GetImplicitConversionOperator(fromType: valueType, toType: type);

                if (cast == null)
                    return false;

                value = cast.Invoke(null, new[] { value });
            }

            return true;
        }

        internal delegate void BindablePropertyBindingChanging(BindableObject bindable, BindingBase oldValue, BindingBase newValue);
    }
}
