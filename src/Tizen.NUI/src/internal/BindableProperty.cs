using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;
using System.ComponentModel;

namespace Tizen.NUI.Binding
{
    /// <summary>
    /// A BindableProperty is a backing store for properties allowing bindings on BindableObject.
    /// </summary>
    /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public sealed class BindableProperty
    {
        /// <summary>
        /// Delegate for BindableProperty.PropertyChanged.
        /// </summary>
        /// <param name="bindable">The bindable object that contains the property.</param>
        /// <param name="oldValue">The old property value.</param>
        /// <param name="newValue">The new property value.</param>
        public delegate void BindingPropertyChangedDelegate(BaseHandle bindable, object oldValue, object newValue);

        /// <summary>
        /// Delegate for BindableProperty.DefaultValueCreator.
        /// </summary>
        /// <param name="bindable">The bindable object that contains the property.</param>
        /// <returns>System.Object</returns>
        public delegate object CreateDefaultValueDelegate(BaseHandle bindable);

        BindableProperty(string propertyName, Type returnType, Type declaringType, object defaultValue, BindingPropertyChangedDelegate propertyChanged, CreateDefaultValueDelegate defaultValueCreator)
        {
            PropertyName = propertyName;
            ReturnType = returnType;
            DeclaringType = declaringType;
            DefaultValue = defaultValue;
            PropertyChanged = propertyChanged;
            DefaultValueCreator = defaultValueCreator;
        }

        /// <summary>
        /// Gets the type declaring the BindableProperty.
        /// </summary>
        public Type DeclaringType { get; private set; }

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

        internal CreateDefaultValueDelegate DefaultValueCreator { get; }

        internal BindingPropertyChangedDelegate PropertyChanged { get; private set; }

        /// <summary>
        /// Creates a new instance of the BindableProperty class.
        /// </summary>
        /// <param name="propertyName">The name of the BindableProperty.</param>
        /// <param name="returnType">The type of the property.</param>
        /// <param name="declaringType">The type of the declaring object.</param>
        /// <param name="defaultValue">The default value for the property.</param>
        /// <param name="propertyChanged">A delegate to be run when the value has changed. This parameter is optional. Default is null.</param>
        /// <param name="defaultValueCreator">A Func used to initialize default value for reference types.</param>
        /// <returns>A newly created BindableProperty.</returns>
        public static BindableProperty Create(string propertyName, Type returnType, Type declaringType, object defaultValue = null,
                                              BindingPropertyChangedDelegate propertyChanged = null,
                                              CreateDefaultValueDelegate defaultValueCreator = null)
        {
            return new BindableProperty(propertyName, returnType, declaringType, defaultValue, propertyChanged:propertyChanged, defaultValueCreator: defaultValueCreator);
        }

    }
}
