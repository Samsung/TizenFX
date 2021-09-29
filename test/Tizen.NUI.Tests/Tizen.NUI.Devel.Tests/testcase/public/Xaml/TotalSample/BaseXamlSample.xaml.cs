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
using System.ComponentModel;
using System.Globalization;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Components;
using Tizen.NUI.Xaml;

[assembly: global::Tizen.NUI.Xaml.XamlResourceIdAttribute("Tizen.NUI.Devel.Tests.res.layout.MyResourceDictionary.xaml",
    "res.layout.MyResourceDictionary.xaml",
    typeof(ResourceDictionary))]

namespace Tizen.NUI.Devel.Tests
{
    public class FocusEffect
    {
        public FocusEffect() { }

        public static readonly BindableProperty FocusableProperty = BindableProperty.CreateAttached("Focusable", typeof(bool), typeof(FocusEffect), false);

        public static bool GetFocusable(View view)
        {
            return (bool)view.GetValue(FocusableProperty);
        }

        public static void SetFocusable(View view, bool value)
        {
            view.SetValue(FocusableProperty, value);
        }
    }

    public class MyView : View
    {
        public MyView() { }

        public string[] Array { get; set; }
    }
    [Tizen.NUI.Xaml.XamlFilePathAttribute("res/layout/MyResourceDictionary.xaml")]
    [Tizen.NUI.Xaml.XamlCompilationAttribute(global::Tizen.NUI.Xaml.XamlCompilationOptions.Compile)]
    public partial class BaseXamlSample : View
    {
        public BaseXamlSample()
        {
            global::Tizen.NUI.Xaml.Extensions.LoadFromXaml(this, typeof(BaseXamlSample));
        }
    }
}