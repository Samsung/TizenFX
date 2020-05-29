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
using Tizen.NUI.Components;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Wearable
{
    /// <summary>
    /// ActivityIndicatorStyle is a class which saves ActivityIndicator's ux data.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ActivityIndicatorStyle : ControlStyle
    {
        #region Fields

        /// <summary>Bindable property of Thickness</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ThicknessProperty = BindableProperty.Create(nameof(Thickness), typeof(float?), typeof(ActivityIndicatorStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            ((ActivityIndicatorStyle)bindable).thickness = (float?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            return ((ActivityIndicatorStyle)bindable).thickness;
        });

        private float? thickness;

        #endregion Fields


        #region Constructors

        /// <summary>
        /// Creates a new instance of a ActivityIndicatorStyle.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ActivityIndicatorStyle() : base()
        {
            Initialize();
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="style">Create ActivityIndicatorStyle by style customized by user.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ActivityIndicatorStyle(ActivityIndicatorStyle style) : base(style)
        {
            this.CopyFrom(style);
        }

        /// <summary>
        /// Static constructor to initialize bindable properties when loading.
        /// </summary>
        static ActivityIndicatorStyle()
        {
        }

        #endregion Constructors


        #region Properties

        /// <summary>
        /// The thickness of the arcs.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? Thickness
        {
            get => (float?)GetValue(ThicknessProperty);
            set => SetValue(ThicknessProperty, value);
        }

        #endregion Properties


        #region Methods

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void CopyFrom(BindableObject bindableObject)
        {
            base.CopyFrom(bindableObject);

            var style = bindableObject as ActivityIndicatorStyle;

            if (null != style)
            {
                Thickness = style.Thickness;
            }
        }

        private void Initialize()
        {
            Size = new Size(64, 64);
            Thickness = 6.0f;
        }

        #endregion Methods
    }
}
