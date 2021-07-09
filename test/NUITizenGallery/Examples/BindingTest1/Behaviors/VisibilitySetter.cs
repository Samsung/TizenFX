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
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace NUITizenGallery.Behaviors
{
    public static class VisibilitySetter
    {
        public static readonly BindableProperty IsVisibleProperty =
            BindableProperty.CreateAttached(
                "IsVisible",
                typeof(bool),
                typeof(VisibilitySetter),
                true,
                propertyChanged: OnVisibilityChanged);


        public static bool GetIsVisible(BindableObject view) => (bool)view.GetValue(IsVisibleProperty);
        public static void SetIsVisible(BindableObject view, bool value) => view.SetValue(IsVisibleProperty, value);

        public static void OnVisibilityChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue is bool isVisible && bindable is View view)
            {
                if (isVisible)
                {
                    view.Show();
                }
                else
                {
                    view.Hide();
                }
            }
        }
    }
}
