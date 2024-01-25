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
using System.Globalization;
using Tizen.NUI.Binding;
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
            global::Tizen.NUI.EXaml.EXamlExtensions.RemoveEventsInXaml(eXamlData);
            global::Tizen.NUI.EXaml.EXamlExtensions.DisposeXamlElements(this);
        }

        private void UIElementEvent(object sender, EventArgs e)
        {
        }

        private void StaticUIElementEvent(object sender, EventArgs e)
        {
        }

        private void LoadXaml()
        {
#pragma warning disable Reflection // The code contains reflection
            global::Tizen.NUI.Xaml.Extensions.LoadFromXaml(this, typeof(TotalSample));
#pragma warning restore Reflection // The code contains reflection
        }

        public TotalSample(bool examl = false)
        {
            if (!examl)
            {
                LoadXaml();
            }
            else
            {
                InitializeComponent();
            }
        }
    }
}