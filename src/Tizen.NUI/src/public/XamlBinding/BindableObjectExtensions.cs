﻿using System;
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
