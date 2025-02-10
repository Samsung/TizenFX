/*
 * Copyright(c) 2025 Samsung Electronics Co., Ltd.
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
using System.ComponentModel;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Extension
{
    internal static class ViewPropertySetters
    {
        public static readonly PropertySetter<View, UIColor> BackgroundColor = new ("_background", (view, value) => view.SetBackgroundColor(value));

        public static readonly PropertySetter<View, UIColor> BorderlineColor = new (nameof(View.BorderlineColor), (view, value) =>
        {
            //FIXME: we need to set UI value type directly without converting reference value.
            view.BorderlineColor = value.ToReferenceType();
        });

        public static readonly PropertySetter<View, UIColor> Color = new (nameof(View.Color), (view, value) =>
        {
            //FIXME: we need to set UI value type directly without converting reference value.
            view.Color = value.ToReferenceType();
        });
    }
}
