/*
 * Copyright(c) 2024 Samsung Electronics Co., Ltd.
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
using System.ComponentModel;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IStyleProperty
    {
        void ApplyTo(View view, object value);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public class StyleProperty<TView, TValue> : IStyleProperty where TView : View
    {
        private Action<TView, TValue> viewPropertySetter;

        public StyleProperty(Action<TView, TValue> viewPropertySetter)
        {
            this.viewPropertySetter = viewPropertySetter;
        }

        public void ApplyTo(View view, object obj)
        {
            if (view is TView tView)
            {
                viewPropertySetter(tView, (TValue)obj);
            }
        }
    }
}

