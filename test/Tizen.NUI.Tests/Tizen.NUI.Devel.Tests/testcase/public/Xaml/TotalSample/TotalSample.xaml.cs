/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd.
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
using System.Globalization;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Components;
using Tizen.NUI.Xaml;
//using static Tizen.NUI.Xaml.VisualStateManager;

namespace Tizen.NUI.Devel.Tests
{
    public class FloatToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return String.Format("Value is {0}", (float)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //return (bool)value ? 1 : 0;
            return null;
        }
    }

    public partial class TotalSample : UIElement
    {
		private void LoadEXaml()
        {
            eXamlData = global::Tizen.NUI.EXaml.EXamlExtensions.LoadFromEXamlByRelativePath(this, @"examl/Tizen.NUI.Devel.Tests.TotalSample.examl");
            t1 = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<global::Tizen.NUI.Devel.Tests.UIElement>(this, "t1");
            t2 = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<global::Tizen.NUI.Devel.Tests.UIElement>(this, "t2");
            t3 = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<global::Tizen.NUI.Devel.Tests.UIElement>(this, "t3");
        }
		
		private void UIElementEvent(object sender, EventArgs e)
        {
        }

        private void StaticUIElementEvent(object sender, EventArgs e)
        {
        }

        private void LoadXaml()
        {
            global::Tizen.NUI.Xaml.Extensions.LoadFromXaml(this, typeof(TotalSample));
        }
		
        public TotalSample(bool examl = false)
        {
            if (examl)
            {
                LoadEXaml();
				global::Tizen.NUI.EXaml.EXamlExtensions.RemoveEventsInXaml(eXamlData);
            }
            else
            {
                InitializeComponent();
            }
        }
    }
}