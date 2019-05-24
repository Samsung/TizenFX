/*
 * Copyright(c) 2017 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.Binding;
using static Tizen.NUI.BaseComponents.FlexContainer;

namespace Tizen.NUI.Xaml.Forms.BaseComponents
{
    /// <summary>
    /// FlexContainer implements a subset of the flexbox spec (defined by W3C):https://www.w3.org/TR/css3-flexbox/<br />
    /// It aims at providing a more efficient way to layout, align, and distribute space among items in the container, even when their size is unknown or dynamic.<br />
    /// FlexContainer has the ability to alter the width and the height of its children (i.e., flex items) to fill the available space in the best possible way on different screen sizes.<br />
    /// FlexContainer can expand items to fill available free space, or shrink them to prevent overflow.<br />
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class FlexContainer : View
    {
        private Tizen.NUI.BaseComponents.FlexContainer _flexContainer;
        internal Tizen.NUI.BaseComponents.FlexContainer flexContainer
        {
            get
            {
                if (null == _flexContainer)
                {
                    _flexContainer = handleInstance as Tizen.NUI.BaseComponents.FlexContainer;
                }

                return _flexContainer;
            }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public FlexContainer() : this(new Tizen.NUI.BaseComponents.FlexContainer())
        {
        }

        internal FlexContainer(Tizen.NUI.BaseComponents.FlexContainer nuiInstance) : base(nuiInstance)
        {
            SetNUIInstance(nuiInstance);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty ContentDirectionProperty = Binding.BindableProperty.Create("ContentDirection", typeof(ContentDirectionType), typeof(FlexContainer), ContentDirectionType.Inherit, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var flexContainer = ((FlexContainer)bindable).flexContainer;
            flexContainer.ContentDirection = (ContentDirectionType)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var flexContainer = ((FlexContainer)bindable).flexContainer;
            return flexContainer.ContentDirection;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty FlexDirectionProperty = Binding.BindableProperty.Create("FlexDirection", typeof(FlexDirectionType), typeof(FlexContainer), FlexDirectionType.Column, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var flexContainer = ((FlexContainer)bindable).flexContainer;
            flexContainer.FlexDirection = (FlexDirectionType)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var flexContainer = ((FlexContainer)bindable).flexContainer;
            return flexContainer.FlexDirection;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty FlexWrapProperty = Binding.BindableProperty.Create("FlexWrap", typeof(WrapType), typeof(FlexContainer), WrapType.NoWrap, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var flexContainer = ((FlexContainer)bindable).flexContainer;
            flexContainer.FlexWrap = (WrapType)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var flexContainer = ((FlexContainer)bindable).flexContainer;
            return flexContainer.FlexWrap;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty JustifyContentProperty = Binding.BindableProperty.Create("JustifyContent", typeof(Justification), typeof(FlexContainer), Justification.JustifyFlexStart, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var flexContainer = ((FlexContainer)bindable).flexContainer;
            flexContainer.JustifyContent = (Justification)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var flexContainer = ((FlexContainer)bindable).flexContainer;
            return flexContainer.JustifyContent;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty AlignItemsProperty = Binding.BindableProperty.Create("AlignItems", typeof(Tizen.NUI.BaseComponents.FlexContainer.Alignment), typeof(FlexContainer), Tizen.NUI.BaseComponents.FlexContainer.Alignment.AlignAuto, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var flexContainer = ((FlexContainer)bindable).flexContainer;
            flexContainer.AlignItems = (Tizen.NUI.BaseComponents.FlexContainer.Alignment)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var flexContainer = ((FlexContainer)bindable).flexContainer;
            return flexContainer.AlignItems;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty AlignContentProperty = Binding.BindableProperty.Create("AlignContent", typeof(Tizen.NUI.BaseComponents.FlexContainer.Alignment), typeof(FlexContainer), Tizen.NUI.BaseComponents.FlexContainer.Alignment.AlignAuto, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var flexContainer = ((FlexContainer)bindable).flexContainer;
            flexContainer.AlignContent = (Tizen.NUI.BaseComponents.FlexContainer.Alignment)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var flexContainer = ((FlexContainer)bindable).flexContainer;
            return flexContainer.AlignContent;
        });

        /// <summary>
        /// The primary direction in which content is ordered.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public ContentDirectionType ContentDirection
        {
            get
            {
                return (ContentDirectionType)GetValue(ContentDirectionProperty);
            }
            set
            {
                SetValue(ContentDirectionProperty, value);
            }
        }

        /// <summary>
        /// The direction of the main axis which determines the direction that flex items are laid out.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public FlexDirectionType FlexDirection
        {
            get
            {
                return (FlexDirectionType)GetValue(FlexDirectionProperty);
            }
            set
            {
                SetValue(FlexDirectionProperty, value);
            }
        }

        /// <summary>
        /// Whether the flex items should wrap or not if there is no enough room for them on one flex line.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public WrapType FlexWrap
        {
            get
            {
                return (WrapType)GetValue(FlexWrapProperty);
            }
            set
            {
                SetValue(FlexWrapProperty, value);
            }
        }

        /// <summary>
        /// The alignment of flex items when the items do not use all available space on the main axis.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Justification JustifyContent
        {
            get
            {
                return (Justification)GetValue(JustifyContentProperty);
            }
            set
            {
                SetValue(JustifyContentProperty, value);
            }
        }

        /// <summary>
        /// The alignment of flex items when the items do not use all available space on the cross axis.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Tizen.NUI.BaseComponents.FlexContainer.Alignment AlignItems
        {
            get
            {
                return (Tizen.NUI.BaseComponents.FlexContainer.Alignment)GetValue(AlignItemsProperty);
            }
            set
            {
                SetValue(AlignItemsProperty, value);
            }
        }

        /// <summary>
        /// Similar to "alignItems", but it aligns flex lines; so only works when there are multiple lines.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Tizen.NUI.BaseComponents.FlexContainer.Alignment AlignContent
        {
            get
            {
                return (Tizen.NUI.BaseComponents.FlexContainer.Alignment)GetValue(AlignContentProperty);
            }
            set
            {
                SetValue(AlignContentProperty, value);
            }
        }
    }
}