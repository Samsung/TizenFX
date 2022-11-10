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
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Devel.Tests
{
    public class FocusEffect
    {
        public FocusEffect() { }

#pragma warning disable Reflection // The code contains reflection
        public static readonly BindableProperty FocusableProperty = BindableProperty.CreateAttached("Focusable", typeof(bool), typeof(FocusEffect), false);
#pragma warning restore Reflection // The code contains reflection

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

    public partial class BaseXamlSample : View
    {
        public BaseXamlSample()
        {
#pragma warning disable Reflection // The code contains reflection
            global::Tizen.NUI.Xaml.Extensions.LoadFromXaml(this, typeof(BaseXamlSample));
#pragma warning restore Reflection // The code contains reflection
        }
    }
}