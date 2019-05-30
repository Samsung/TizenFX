﻿using System;

namespace Tizen.NUI.XamlBinding
{
    internal static class BindingBaseExtensions
    {
        public static BindingMode GetRealizedMode(this BindingBase self, BindableProperty property)
        {
            return self.Mode != BindingMode.Default ? self.Mode : property.DefaultBindingMode;
        }
    }
}