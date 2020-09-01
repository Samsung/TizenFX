/*
 * Copyright(c) 2019 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// ToastStyle is a class which saves Toast's ux data.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ToastStyle : ControlStyle
    {
        /// <summary>The Duration bindable property.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DurationProperty = BindableProperty.Create(nameof(Duration), typeof(uint?), typeof(ToastStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            ((ToastStyle)bindable).duration = (uint?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            return ((ToastStyle)bindable).duration;
        });

        private uint? duration;

        static ToastStyle() { }

        /// <summary>
        /// Creates a new instance of a ToastStyle.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ToastStyle() : base()
        {
        }

        /// <summary>
        /// Creates a new instance of a ToastStyle with Style.
        /// </summary>
        /// <param name="style">Create ToastStyle by Style customized by user.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ToastStyle(ToastStyle style) : base(style)
        {
        }

        /// <summary>
        /// Gets or sets toast show duration time.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint? Duration
        {
            get => (uint?)GetValue(DurationProperty);
            set => SetValue(DurationProperty, value);
        }

        /// <summary>
        /// Text's Style.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextLabelStyle Text { get; set; } = new TextLabelStyle();

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void CopyFrom(BindableObject bindableObject)
        {
            base.CopyFrom(bindableObject);

            if (bindableObject is ToastStyle toastStyle)
            {
                Text.CopyFrom(toastStyle.Text);
            }
        }
    }
}
