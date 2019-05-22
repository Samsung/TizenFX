/*
 * Copyright(c) 2018 Samsung Electronics Co., Ltd.
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
using static Tizen.NUI.BaseComponents.View;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Xaml.Forms.BaseComponents
{
    /// <summary>
    /// View is the base class for all views.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [ContentProperty("Content")]
    public class View : Tizen.NUI.Xaml.Forms.Container, IResourcesProvider
    {
        private Tizen.NUI.BaseComponents.View _view;
        internal Tizen.NUI.BaseComponents.View view
        {
            get
            {
                if (null == _view)
                {
                    _view = handleInstance as Tizen.NUI.BaseComponents.View;
                }

                return _view;
            }
        }

        /// <summary>
        /// Creates a new instance of a Xaml View.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public View() : this(new Tizen.NUI.BaseComponents.View())
        {
        }

        public Tizen.NUI.BaseComponents.View ViewInstance
        {
            get
            {
                return _view;
            }
        }

        internal View(Tizen.NUI.BaseComponents.View nuiInstance) : base(nuiInstance)
        {
            _view = nuiInstance;
            SetNUIInstance(nuiInstance);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        bool IResourcesProvider.IsResourcesCreated => _resources != null;

        ResourceDictionary _resources;

        public ResourceDictionary Resources
        {
            get
            {
                if (_resources != null)
                    return _resources;
                _resources = new ResourceDictionary();
                ((IResourceDictionary)_resources).ValuesChanged += OnResourcesChanged;
                return _resources;
            }
            set
            {
                if (_resources == value)
                    return;
                OnPropertyChanging();
                if (_resources != null)
                    ((IResourceDictionary)_resources).ValuesChanged -= OnResourcesChanged;
                _resources = value;
                OnResourcesChanged(value);
                if (_resources != null)
                    ((IResourceDictionary)_resources).ValuesChanged += OnResourcesChanged;
                OnPropertyChanged();
            }
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceDictionary XamlResources
        {
            get
            {
                if (_resources != null)
                    return _resources;

                _resources = new ResourceDictionary();
                ((IResourceDictionary)_resources).ValuesChanged += OnResourcesChanged;
                return _resources;
            }
            set
            {
                if (_resources == value)
                    return;
                OnPropertyChanging();
                if (_resources != null)
                    ((IResourceDictionary)_resources).ValuesChanged -= OnResourcesChanged;
                _resources = value;
                OnResourcesChanged(value);
                if (_resources != null)
                    ((IResourceDictionary)_resources).ValuesChanged += OnResourcesChanged;
                OnPropertyChanged();
            }
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty ContentProperty = Binding.BindableProperty.Create("Content", typeof(View), typeof(ContentPage), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var self = (View)bindable;
            if (newValue != null)
            {
                self.Add((View)newValue);
            }
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty StyleNameProperty = Binding.BindableProperty.Create("StyleName", typeof(string), typeof(View), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = ((View)bindable).view;
            view.StyleName = (string)newValue;
        },
        defaultValueCreator:(bindable) =>
        {
            var view = ((View)bindable).view;
            return view.StyleName;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty BackgroundColorProperty = Binding.BindableProperty.Create("BackgroundColor", typeof(Color), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = ((View)bindable).view;
            view.BackgroundColor = (Color)newValue;
        },
        defaultValueCreator:(bindable) =>
        {
            var view = ((View)bindable).view;
            return view.BackgroundColor;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty BackgroundImageProperty = Binding.BindableProperty.Create("BackgroundImage", typeof(string), typeof(View), default(string), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = ((View)bindable).view;
            view.BackgroundImage = (string)newValue;
        },
        defaultValueCreator:(bindable) =>
        {
            var view = ((View)bindable).view;
            return view.BackgroundImage;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty BackgroundProperty = Binding.BindableProperty.Create("Background", typeof(PropertyMap), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = ((View)bindable).view;
            view.Background = (PropertyMap)newValue;
        },
        defaultValueCreator:(bindable) =>
        {
            var view = ((View)bindable).view;
            return view.Background;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty StateProperty = Binding.BindableProperty.Create("State", typeof(States), typeof(View), States.Normal, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = ((View)bindable).view;
            view.State = (States)newValue;
        },
        defaultValueCreator:(bindable) =>
        {
            var view = ((View)bindable).view;
            return view.State;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty SubStateProperty = Binding.BindableProperty.Create("SubState", typeof(States), typeof(View), States.Normal, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = ((View)bindable).view;
            view.SubState = (States)newValue;
        },
        defaultValueCreator:(bindable) =>
        {
            var view = ((View)bindable).view;
            return view.SubState;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty TooltipProperty = Binding.BindableProperty.Create("Tooltip", typeof(PropertyMap), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = ((View)bindable).view;
            view.Tooltip = (PropertyMap)newValue;
        },
        defaultValueCreator:(bindable) =>
        {
            var view = ((View)bindable).view;
            return view.Tooltip;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty FlexProperty = Binding.BindableProperty.Create("Flex", typeof(float), typeof(View), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = ((View)bindable).view;
            view.Flex = (float)newValue;
        },
        defaultValueCreator:(bindable) =>
        {
            var view = ((View)bindable).view;
            return view.Flex;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty AlignSelfProperty = Binding.BindableProperty.Create("AlignSelf", typeof(int), typeof(View), default(int), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = ((View)bindable).view;
            view.AlignSelf = (int)newValue;
        },
        defaultValueCreator:(bindable) =>
        {
            var view = ((View)bindable).view;
            return view.AlignSelf;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty FlexMarginProperty = Binding.BindableProperty.Create("FlexMargin", typeof(Vector4), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = ((View)bindable).view;
            view.FlexMargin = (Vector4)newValue;
        },
        defaultValueCreator:(bindable) =>
        {
            var view = ((View)bindable).view;
            return view.FlexMargin;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty CellIndexProperty = Binding.BindableProperty.Create("CellIndex", typeof(Vector2), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = ((View)bindable).view;
            view.CellIndex = (Vector2)newValue;
        },
        defaultValueCreator:(bindable) =>
        {
            var view = ((View)bindable).view;
            return view.CellIndex;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty RowSpanProperty = Binding.BindableProperty.Create("RowSpan", typeof(float), typeof(View), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = ((View)bindable).view;
            view.RowSpan = (float)newValue;
        },
        defaultValueCreator:(bindable) =>
        {
            var view = ((View)bindable).view;
            return view.RowSpan;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty ColumnSpanProperty = Binding.BindableProperty.Create("ColumnSpan", typeof(float), typeof(View), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = ((View)bindable).view;
            view.ColumnSpan = (float)newValue;
        },
        defaultValueCreator:(bindable) =>
        {
            var view = ((View)bindable).view;
            return view.ColumnSpan;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty CellHorizontalAlignmentProperty = Binding.BindableProperty.Create("CellHorizontalAlignment", typeof(HorizontalAlignmentType), typeof(View), HorizontalAlignmentType.Left, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = ((View)bindable).view;
            view.CellHorizontalAlignment = (HorizontalAlignmentType)newValue;
        },
        defaultValueCreator:(bindable) =>
        {
            var view = ((View)bindable).view;
            return view.CellHorizontalAlignment;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty CellVerticalAlignmentProperty = Binding.BindableProperty.Create("CellVerticalAlignment", typeof(VerticalAlignmentType), typeof(View), VerticalAlignmentType.Top, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = ((View)bindable).view;
            view.CellVerticalAlignment = (VerticalAlignmentType)newValue;
        },
        defaultValueCreator:(bindable) =>
        {
            var view = ((View)bindable).view;
            return view.CellVerticalAlignment;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty LeftFocusableViewProperty = Binding.BindableProperty.Create(nameof(View.LeftFocusableView), typeof(Tizen.NUI.BaseComponents.View), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = ((View)bindable).view;
            view.LeftFocusableView = (Tizen.NUI.BaseComponents.View)newValue;
        },
        defaultValueCreator:(bindable) =>
        {
            var view = ((View)bindable).view;
            return view.LeftFocusableView;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty RightFocusableViewProperty = Binding.BindableProperty.Create(nameof(View.RightFocusableView), typeof(Tizen.NUI.BaseComponents.View), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = ((View)bindable).view;
            view.RightFocusableView = (Tizen.NUI.BaseComponents.View)newValue;
        },
        defaultValueCreator:(bindable) =>
        {
            var view = ((View)bindable).view;
            return view.RightFocusableView;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty UpFocusableViewProperty = Binding.BindableProperty.Create(nameof(View.UpFocusableView), typeof(Tizen.NUI.BaseComponents.View), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = ((View)bindable).view;
            view.UpFocusableView = (Tizen.NUI.BaseComponents.View)newValue;
        },
        defaultValueCreator:(bindable) =>
        {
            var view = ((View)bindable).view;
            return view.UpFocusableView;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty DownFocusableViewProperty = Binding.BindableProperty.Create(nameof(View.DownFocusableView), typeof(Tizen.NUI.BaseComponents.View), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = ((View)bindable).view;
            view.DownFocusableView = (Tizen.NUI.BaseComponents.View)newValue;
        },
        defaultValueCreator:(bindable) =>
        {
            var view = ((View)bindable).view;
            return view.DownFocusableView;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty FocusableProperty = Binding.BindableProperty.Create("Focusable", typeof(bool), typeof(View), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = ((View)bindable).view;
            view.Focusable = (bool)newValue;
        },
        defaultValueCreator:(bindable) =>
        {
            var view = ((View)bindable).view;
            return view.Focusable;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty Size2DProperty = Binding.BindableProperty.Create("Size2D", typeof(Size2D), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = ((View)bindable).view;
            view.Size2D = (Size2D)newValue;
        },
        defaultValueCreator:(bindable) =>
        {
            var view = ((View)bindable).view;
            return view.Size2D;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty OpacityProperty = Binding.BindableProperty.Create("Opacity", typeof(float), typeof(View), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = ((View)bindable).view;
            view.Opacity = (float)newValue;
        },
        defaultValueCreator:(bindable) =>
        {
            var view = ((View)bindable).view;
            return view.Opacity;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty Position2DProperty = Binding.BindableProperty.Create("Position2D", typeof(Position2D), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = ((View)bindable).view;
            view.Position2D = (Position2D)newValue;
        },
        defaultValueCreator:(bindable) =>
        {
            var view = ((View)bindable).view;
            return view.Position2D;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty PositionUsesPivotPointProperty = Binding.BindableProperty.Create("PositionUsesPivotPoint", typeof(bool), typeof(View), true, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = ((View)bindable).view;
            view.PositionUsesPivotPoint = (bool)newValue;
        },
        defaultValueCreator:(bindable) =>
        {
            var view = ((View)bindable).view;
            return view.PositionUsesPivotPoint;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty SiblingOrderProperty = Binding.BindableProperty.Create("SiblingOrder", typeof(int), typeof(View), default(int), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = ((View)bindable).view;
            view.SiblingOrder = (int)newValue;
        },
        defaultValueCreator:(bindable) =>
        {
            var view = ((View)bindable).view;
            var parentChildren = view.GetParent()?.Children;
            int currentOrder = 0;
            if (parentChildren != null)
            {
                currentOrder = parentChildren.IndexOf(view);

                if (currentOrder < 0) { return 0; }
                else if (currentOrder < parentChildren.Count) { return currentOrder; }
            }

            return 0;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty ParentOriginProperty = Binding.BindableProperty.Create("ParentOrigin", typeof(Position), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = ((View)bindable).view;
            view.ParentOrigin = (Position)newValue;
        },
        defaultValueCreator:(bindable) =>
        {
            var view = ((View)bindable).view;
            return view.ParentOrigin;
        }
        );
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty PivotPointProperty = Binding.BindableProperty.Create("PivotPoint", typeof(Position), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = ((View)bindable).view;
            view.PivotPoint = (Position)newValue;
        },
        defaultValueCreator:(bindable) =>
        {
            var view = ((View)bindable).view;
            return view.PivotPoint;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty SizeWidthProperty = Binding.BindableProperty.Create("SizeWidth", typeof(float), typeof(View), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = ((View)bindable).view;
            view.SizeWidth = (float)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var view = ((View)bindable).view;
            return view.SizeWidth;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty SizeHeightProperty = Binding.BindableProperty.Create("SizeHeight", typeof(float), typeof(View), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = ((View)bindable).view;
            view.SizeHeight = (float)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var view = ((View)bindable).view;
            return view.SizeHeight;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty PositionProperty = Binding.BindableProperty.Create("Position", typeof(Position), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = ((View)bindable).view;
            view.Position = (Position)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var view = ((View)bindable).view;
            return view.Position;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty PositionXProperty = Binding.BindableProperty.Create("PositionX", typeof(float), typeof(View), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = ((View)bindable).view;
            view.PositionX = (float)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var view = ((View)bindable).view;
            return view.PositionX;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty PositionYProperty = Binding.BindableProperty.Create("PositionY", typeof(float), typeof(View), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = ((View)bindable).view;
            view.PositionY = (float)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var view = ((View)bindable).view;
            return view.PositionY;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty PositionZProperty = Binding.BindableProperty.Create("PositionZ", typeof(float), typeof(View), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = ((View)bindable).view;
            view.PositionZ = (float)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var view = ((View)bindable).view;
            return view.PositionZ;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty OrientationProperty = Binding.BindableProperty.Create("Orientation", typeof(Rotation), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = ((View)bindable).view;
            view.Orientation = (Rotation)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var view = ((View)bindable).view;
            return view.Orientation;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty ScaleProperty = Binding.BindableProperty.Create("Scale", typeof(Vector3), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = ((View)bindable).view;
            view.Scale = (Vector3)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var view = ((View)bindable).view;
            return view.Scale;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty ScaleXProperty = Binding.BindableProperty.Create("ScaleX", typeof(float), typeof(View), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = ((View)bindable).view;
            view.ScaleX = (float)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var view = ((View)bindable).view;
            return view.ScaleX;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty ScaleYProperty = Binding.BindableProperty.Create("ScaleY", typeof(float), typeof(View), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = ((View)bindable).view;
            view.ScaleY = (float)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var view = ((View)bindable).view;
            return view.ScaleY;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty ScaleZProperty = Binding.BindableProperty.Create("ScaleZ", typeof(float), typeof(View), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = ((View)bindable).view;
            view.ScaleZ = (float)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var view = ((View)bindable).view;
            return view.ScaleZ;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty NameProperty = Binding.BindableProperty.Create("Name", typeof(string), typeof(View), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = ((View)bindable).view;
            view.Name = (string)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var view = ((View)bindable).view;
            return view.Name;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty SensitiveProperty = Binding.BindableProperty.Create("Sensitive", typeof(bool), typeof(View), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = ((View)bindable).view;
            view.Sensitive = (bool)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var view = ((View)bindable).view;
            return view.Sensitive;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty LeaveRequiredProperty = Binding.BindableProperty.Create("LeaveRequired", typeof(bool), typeof(View), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = ((View)bindable).view;
            view.LeaveRequired = (bool)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var view = ((View)bindable).view;
            return view.LeaveRequired;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty InheritOrientationProperty = Binding.BindableProperty.Create("InheritOrientation", typeof(bool), typeof(View), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = ((View)bindable).view;
            view.InheritOrientation = (bool)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var view = ((View)bindable).view;
            return view.InheritOrientation;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty InheritScaleProperty = Binding.BindableProperty.Create("InheritScale", typeof(bool), typeof(View), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = ((View)bindable).view;
            view.InheritScale = (bool)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var view = ((View)bindable).view;
            return view.InheritScale;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty DrawModeProperty = Binding.BindableProperty.Create("DrawMode", typeof(DrawModeType), typeof(View), DrawModeType.Normal, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = ((View)bindable).view;
            view.DrawMode = (DrawModeType)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var view = ((View)bindable).view;
            return view.DrawMode;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty SizeModeFactorProperty = Binding.BindableProperty.Create("SizeModeFactor", typeof(Vector3), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = ((View)bindable).view;
            view.SizeModeFactor = (Vector3)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var view = ((View)bindable).view;
            return view.SizeModeFactor;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty WidthResizePolicyProperty = Binding.BindableProperty.Create("WidthResizePolicy", typeof(ResizePolicyType), typeof(View), ResizePolicyType.Fixed, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = ((View)bindable).view;
            view.WidthResizePolicy = (ResizePolicyType)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var view = ((View)bindable).view;
            return view.WidthResizePolicy;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty HeightResizePolicyProperty = Binding.BindableProperty.Create("HeightResizePolicy", typeof(ResizePolicyType), typeof(View), ResizePolicyType.Fixed, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = ((View)bindable).view;
            view.HeightResizePolicy = (ResizePolicyType)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var view = ((View)bindable).view;
            return view.HeightResizePolicy;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty SizeScalePolicyProperty = Binding.BindableProperty.Create("SizeScalePolicy", typeof(SizeScalePolicyType), typeof(View), SizeScalePolicyType.UseSizeSet, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = ((View)bindable).view;
            view.SizeScalePolicy = (SizeScalePolicyType)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var view = ((View)bindable).view;
            return view.SizeScalePolicy;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty WidthForHeightProperty = Binding.BindableProperty.Create("WidthForHeight", typeof(bool), typeof(View), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = ((View)bindable).view;
            view.WidthForHeight = (bool)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var view = ((View)bindable).view;
            return view.WidthForHeight;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty HeightForWidthProperty = Binding.BindableProperty.Create("HeightForWidth", typeof(bool), typeof(View), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = ((View)bindable).view;
            view.HeightForWidth = (bool)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var view = ((View)bindable).view;
            return view.HeightForWidth;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty PaddingProperty = Binding.BindableProperty.Create("Padding", typeof(Extents), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = ((View)bindable).view;
            view.Padding = (Extents)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var view = ((View)bindable).view;
            return view.Padding;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty SizeProperty = Binding.BindableProperty.Create("Size", typeof(Size), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = ((View)bindable).view;
            view.Size = (Size)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var view = ((View)bindable).view;
            return view.Size;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty MinimumSizeProperty = Binding.BindableProperty.Create("MinimumSize", typeof(Size2D), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = ((View)bindable).view;
            view.MinimumSize = (Size2D)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var view = ((View)bindable).view;
            return view.MinimumSize;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty MaximumSizeProperty = Binding.BindableProperty.Create("MaximumSize", typeof(Size2D), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = ((View)bindable).view;
            view.MaximumSize = (Size2D)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var view = ((View)bindable).view;
            return view.MaximumSize;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty InheritPositionProperty = Binding.BindableProperty.Create("InheritPosition", typeof(bool), typeof(View), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = ((View)bindable).view;
            view.InheritPosition = (bool)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var view = ((View)bindable).view;
            return view.InheritPosition;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty ClippingModeProperty = Binding.BindableProperty.Create("ClippingMode", typeof(ClippingModeType), typeof(View), ClippingModeType.Disabled, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = ((View)bindable).view;
            view.ClippingMode = (ClippingModeType)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var view = ((View)bindable).view;
            return view.ClippingMode;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty InheritLayoutDirectionProperty = Binding.BindableProperty.Create("InheritLayoutDirection", typeof(bool), typeof(View), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = ((View)bindable).view;
            view.InheritLayoutDirection = (bool)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var view = ((View)bindable).view;
            return view.InheritLayoutDirection;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty LayoutDirectionProperty = Binding.BindableProperty.Create("LayoutDirection", typeof(ViewLayoutDirectionType), typeof(View), ViewLayoutDirectionType.LTR, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = ((View)bindable).view;
            view.LayoutDirection = (ViewLayoutDirectionType)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var view = ((View)bindable).view;
            return view.LayoutDirection;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty MarginProperty = Binding.BindableProperty.Create("Margin", typeof(Extents), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = ((View)bindable).view;
            view.Margin = (Extents)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var view = ((View)bindable).view;
            return view.Margin;
        });
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty StyleProperty = Binding.BindableProperty.Create("Style", typeof(Style), typeof(View), default(Style),
    propertyChanged: (bindable, oldvalue, newvalue) => ((View)bindable).mergedStyle.Style = (Style)newvalue);

        /// <summary>
        /// Event argument passed through the ChildAdded event.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public class ChildAddedEventArgs : EventArgs
        {
            /// <summary>
            /// Added child view at moment.
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            public View Added { get; set; }
        }

        /// <summary>
        /// Event when a child is added.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public new event EventHandler<ChildAddedEventArgs> ChildAdded;

        // From Container Base class
        /// <summary>
        /// Adds a child view to this view.
        /// </summary>
        /// <seealso cref="Container.Add" />
        /// <since_tizen> 4 </since_tizen>
        public override void Add(View child)
        {
            (child as IElement).Parent = this;
            view.Add(child.view);

            if (ChildAdded != null)
            {
                ChildAddedEventArgs e = new ChildAddedEventArgs
                {
                    Added = child
                };
                ChildAdded(this, e);
            }
        }

        /// <summary>
        /// Event argument passed through the ChildRemoved event.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public class ChildRemovedEventArgs : EventArgs
        {
            /// <summary>
            /// Removed child view at moment.
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            public View Removed { get; set; }
        }

        /// <summary>
        /// Event when a child is removed.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public new event EventHandler<ChildRemovedEventArgs> ChildRemoved;


        /// <summary>
        /// Removes a child view from this View. If the view was not a child of this view, this is a no-op.
        /// </summary>
        /// <seealso cref="Container.Remove" />
        /// <since_tizen> 4 </since_tizen>
        public override void Remove(View child)
        {
            (child as IElement).Parent = null;
            view.Remove(child.view);

            if (ChildRemoved != null)
            {
                ChildRemovedEventArgs e = new ChildRemovedEventArgs
                {
                    Removed = child
                };
                ChildRemoved(this, e);
            }
        }

        /// <summary>
        /// Retrieves a child view by index.
        /// </summary>
        /// <seealso cref="Container.GetChildAt" />
        /// <since_tizen> 4 </since_tizen>
        public override View GetChildAt(uint index)
        {
            if (index < view.Children.Count)
            {
                return BaseHandle.GetHandle(view.Children[Convert.ToInt32(index)]) as View;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Retrieves the number of children held by the view.
        /// </summary>
        /// <seealso cref="Container.GetChildCount" />
        /// <since_tizen> 4 </since_tizen>
        public override uint GetChildCount()
        {
            return Convert.ToUInt32(view.Children.Count);
        }

        /// <summary>
        /// Gets the views parent.
        /// </summary>
        /// <seealso cref="Container.GetParent()" />
        /// <since_tizen> 4 </since_tizen>
        public override Container GetParent()
        {
            return BaseHandle.GetHandle(view.GetParent()) as Container;
        }

        /// <summary>
        /// An event for the KeyInputFocusGained signal which can be used to subscribe or unsubscribe the event handler provided by the user.<br />
        /// The KeyInputFocusGained signal is emitted when the control gets the key input focus.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler FocusGained
        {
            add
            {
                view.FocusGained += value;
            }

            remove
            {
                view.FocusGained -= value;
            }
        }

        /// <summary>
        /// An event for the KeyInputFocusLost signal which can be used to subscribe or unsubscribe the event handler provided by the user.<br />
        /// The KeyInputFocusLost signal is emitted when the control loses the key input focus.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler FocusLost
        {
            add
            {
                view.FocusLost += value;
            }

            remove
            {
                view.FocusLost -= value;
            }
        }

        /// <summary>
        /// An event for the KeyPressed signal which can be used to subscribe or unsubscribe the event handler provided by the user.<br />
        /// The KeyPressed signal is emitted when the key event is received.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandlerWithReturnType<object, KeyEventArgs, bool> KeyEvent
        {
            add
            {
                view.KeyEvent += value;
            }

            remove
            {
                view.KeyEvent -= value;
            }
        }

        /// <summary>
        /// An event for the OnRelayout signal which can be used to subscribe or unsubscribe the event handler.<br />
        /// The OnRelayout signal is emitted after the size has been set on the view during relayout.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler Relayout
        {
            add
            {
                view.Relayout += value;
            }

            remove
            {
                view.Relayout -= value;
            }
        }

        /// <summary>
        /// An event for the touched signal which can be used to subscribe or unsubscribe the event handler provided by the user.<br />
        /// The touched signal is emitted when the touch input is received.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandlerWithReturnType<object, TouchEventArgs, bool> TouchEvent
        {
            add
            {
                view.TouchEvent += value;
            }

            remove
            {
                view.TouchEvent -= value;
            }
        }

        /// <summary>
        /// An event for the hovered signal which can be used to subscribe or unsubscribe the event handler provided by the user.<br />
        /// The hovered signal is emitted when the hover input is received.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandlerWithReturnType<object, HoverEventArgs, bool> HoverEvent
        {
            add
            {
                view.HoverEvent += value;
            }

            remove
            {
                view.HoverEvent -= value;
            }
        }

        /// <summary>
        /// An event for the WheelMoved signal which can be used to subscribe or unsubscribe the event handler provided by the user.<br />
        /// The WheelMoved signal is emitted when the wheel event is received.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandlerWithReturnType<object, WheelEventArgs, bool> WheelEvent
        {
            add
            {
                view.WheelEvent += value;
            }

            remove
            {
                view.WheelEvent -= value;
            }
        }

        /// <summary>
        /// An event for the OnWindow signal which can be used to subscribe or unsubscribe the event handler.<br />
        /// The OnWindow signal is emitted after the view has been connected to the window.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler AddedToWindow
        {
            add
            {
                view.AddedToWindow += value;
            }

            remove
            {
                view.AddedToWindow -= value;
            }
        }

        /// <summary>
        /// An event for the OffWindow signal, which can be used to subscribe or unsubscribe the event handler.<br />
        /// OffWindow signal is emitted after the view has been disconnected from the window.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler RemovedFromWindow
        {
            add
            {
                view.RemovedFromWindow += value;
            }

            remove
            {
                view.RemovedFromWindow -= value;
            }
        }

        /// <summary>
        /// An event for visibility change which can be used to subscribe or unsubscribe the event handler.<br />
        /// This signal is emitted when the visible property of this or a parent view is changed.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<VisibilityChangedEventArgs> VisibilityChanged
        {
            add
            {
                view.VisibilityChanged += value;
            }

            remove
            {
                view.VisibilityChanged -= value;
            }
        }

        /// <summary>
        /// Event for layout direction change which can be used to subscribe/unsubscribe the event handler.<br />
        /// This signal is emitted when the layout direction property of this or a parent view is changed.<br />
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public event EventHandler<LayoutDirectionChangedEventArgs> LayoutDirectionChanged
        {
            add
            {
                view.LayoutDirectionChanged += value;
            }

            remove
            {
                view.LayoutDirectionChanged -= value;
            }
        }

        /// <summary>
        /// An event for the ResourcesLoadedSignal signal which can be used to subscribe or unsubscribe the event handler provided by the user.<br />
        /// This signal is emitted after all resources required by a view are loaded and ready.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler ResourcesLoaded
        {
            add
            {
                view.ResourcesLoaded += value;
            }

            remove
            {
                view.ResourcesLoaded -= value;
            }
        }

        /// <summary>
        /// Queries whether the view has a focus.
        /// </summary>
        /// <returns>True if this view has a focus.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool HasFocus()
        {
            return view.HasFocus();
        }

        /// <summary>
        /// Sets the name of the style to be applied to the view.
        /// </summary>
        /// <param name="styleName">A string matching a style described in a stylesheet.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetStyleName(string styleName)
        {
            view.SetStyleName(styleName);
        }

        /// <summary>
        /// Retrieves the name of the style to be applied to the view (if any).
        /// </summary>
        /// <returns>A string matching a style, or an empty string.</returns>
        /// <since_tizen> 3 </since_tizen>
        public string GetStyleName()
        {
            return view.GetStyleName();
        }

        /// <summary>
        /// Clears the background.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void ClearBackground()
        {
            view.ClearBackground();
        }

        /// <summary>
        /// The contents of ContentPage can be added into it.
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public View Content
        {
            get { return (View)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }

        /// <summary>
        /// The StyleName, type string.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string StyleName
        {
            get
            {
                return (string)GetValue(StyleNameProperty);
            }
            set
            {
                SetValue(StyleNameProperty, value);
            }
        }

        /// <summary>
        /// The mutually exclusive with BACKGROUND_IMAGE and BACKGROUND type Vector4.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Color BackgroundColor
        {
            get
            {
                return (Color)GetValue(BackgroundColorProperty);
            }
            set
            {
                SetValue(BackgroundColorProperty, value);
            }
        }

        /// <summary>
        /// Creates an animation to animate the background color visual. If there is no
        /// background visual, creates one with transparent black as it's mixColor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Animation AnimateBackgroundColor(object destinationValue,
                                                 int startTime,
                                                 int endTime,
                                                 AlphaFunction.BuiltinFunctions? alphaFunction = null,
                                                 object initialValue = null)
        {
            return view.AnimateBackgroundColor(destinationValue, startTime, endTime, alphaFunction, initialValue);
        }

        /// <summary>
        /// Creates an animation to animate the mixColor of the named visual.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Animation AnimateColor(string targetVisual, object destinationColor, int startTime, int endTime, AlphaFunction.BuiltinFunctions? alphaFunction = null, object initialColor = null)
        {
            return view.AnimateColor(targetVisual, destinationColor, startTime, endTime, alphaFunction, initialColor);
        }

        /// <summary>
        /// The mutually exclusive with BACKGROUND_COLOR and BACKGROUND type Map.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string BackgroundImage
        {
            get
            {
                return (string)GetValue(BackgroundImageProperty);
            }
            set
            {
                SetValue(BackgroundImageProperty, value);
            }
        }

        /// <summary>
        /// The background of view.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Tizen.NUI.PropertyMap Background
        {
            get
            {
                return (PropertyMap)GetValue(BackgroundProperty);
            }
            set
            {
                SetValue(BackgroundProperty, value);
            }
        }

        /// <summary>
        /// The current state of the view.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public States State
        {
            get
            {
                return (States)GetValue(StateProperty);
            }
            set
            {
                SetValue(StateProperty, value);
            }
        }

        /// <summary>
        /// The current sub state of the view.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public States SubState
        {
            get
            {
                return (States)GetValue(SubStateProperty);
            }
            set
            {
                SetValue(SubStateProperty, value);
            }
        }

        /// <summary>
        /// Displays a tooltip
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Tizen.NUI.PropertyMap Tooltip
        {
            get
            {
                return (PropertyMap)GetValue(TooltipProperty);
            }
            set
            {
                SetValue(TooltipProperty, value);
            }
        }

        /// <summary>
        /// Displays a tooltip as a text.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string TooltipText
        {
            set
            {
                view.TooltipText = value;
            }
        }

        /// <summary>
        /// The Child property of FlexContainer.<br />
        /// The proportion of the free space in the container, the flex item will receive.<br />
        /// If all items in the container set this property, their sizes will be proportional to the specified flex factor.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float Flex
        {
            get
            {
                return (float)GetValue(FlexProperty);
            }
            set
            {
                SetValue(FlexProperty, value);
            }
        }

        /// <summary>
        /// The Child property of FlexContainer.<br />
        /// The alignment of the flex item along the cross axis, which, if set, overides the default alignment for all items in the container.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int AlignSelf
        {
            get
            {
                return (int)GetValue(AlignSelfProperty);
            }
            set
            {
                SetValue(AlignSelfProperty, value);
            }
        }

        /// <summary>
        /// The Child property of FlexContainer.<br />
        /// The space around the flex item.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector4 FlexMargin
        {
            get
            {
                return (Vector4)GetValue(FlexMarginProperty);
            }
            set
            {
                SetValue(FlexMarginProperty, value);
            }
        }

        /// <summary>
        /// The top-left cell this child occupies, if not set, the first available cell is used.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector2 CellIndex
        {
            get
            {
                return (Vector2)GetValue(CellIndexProperty);
            }
            set
            {
                SetValue(CellIndexProperty, value);
            }
        }

        /// <summary>
        /// The number of rows this child occupies, if not set, the default value is 1.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float RowSpan
        {
            get
            {
                return (float)GetValue(RowSpanProperty);
            }
            set
            {
                SetValue(RowSpanProperty, value);
            }
        }

        /// <summary>
        /// The number of columns this child occupies, if not set, the default value is 1.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float ColumnSpan
        {
            get
            {
                return (float)GetValue(ColumnSpanProperty);
            }
            set
            {
                SetValue(ColumnSpanProperty, value);
            }
        }

        /// <summary>
        /// The horizontal alignment of this child inside the cells, if not set, the default value is 'left'.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Tizen.NUI.HorizontalAlignmentType CellHorizontalAlignment
        {
            get
            {
                return (HorizontalAlignmentType)GetValue(CellHorizontalAlignmentProperty);
            }
            set
            {
                SetValue(CellHorizontalAlignmentProperty, value);
            }
        }

        /// <summary>
        /// The vertical alignment of this child inside the cells, if not set, the default value is 'top'.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Tizen.NUI.VerticalAlignmentType CellVerticalAlignment
        {
            get
            {
                return (VerticalAlignmentType)GetValue(CellVerticalAlignmentProperty);
            }
            set
            {
                SetValue(CellVerticalAlignmentProperty, value);
            }
        }

        /// <summary>
        /// The left focusable view.<br />
        /// This will return null if not set.<br />
        /// This will also return null if the specified left focusable view is not on a window.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public View LeftFocusableView
        {
            // As native side will be only storing IDs so need a logic to convert View to ID and vice-versa.
            get
            {
                return (View)GetValue(LeftFocusableViewProperty);
            }
            set
            {
                SetValue(LeftFocusableViewProperty, value);
            }
        }

        /// <summary>
        /// The right focusable view.<br />
        /// This will return null if not set.<br />
        /// This will also return null if the specified right focusable view is not on a window.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public View RightFocusableView
        {
            // As native side will be only storing IDs so need a logic to convert View to ID and vice-versa.
            get
            {
                return (View)GetValue(RightFocusableViewProperty);
            }
            set
            {
                SetValue(RightFocusableViewProperty, value);
            }
        }

        /// <summary>
        /// The up focusable view.<br />
        /// This will return null if not set.<br />
        /// This will also return null if the specified up focusable view is not on a window.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public View UpFocusableView
        {
            // As native side will be only storing IDs so need a logic to convert View to ID and vice-versa.
            get
            {
                return (View)GetValue(UpFocusableViewProperty);
            }
            set
            {
                SetValue(UpFocusableViewProperty, value);
            }
        }

        /// <summary>
        /// The down focusable view.<br />
        /// This will return null if not set.<br />
        /// This will also return null if the specified down focusable view is not on a window.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public View DownFocusableView
        {
            // As native side will be only storing IDs so need a logic to convert View to ID and vice-versa.
            get
            {
                return (View)GetValue(DownFocusableViewProperty);
            }
            set
            {
                SetValue(DownFocusableViewProperty, value);
            }
        }

        /// <summary>
        /// Whether the view should be focusable by keyboard navigation.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool Focusable
        {
            set
            {
                SetValue(FocusableProperty, value);
            }
            get
            {
                return (bool)GetValue(FocusableProperty);
            }
        }

        /// <summary>
        ///  Retrieves the position of the view.<br />
        ///  The coordinates are relative to the view's parent.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Position CurrentPosition
        {
            get
            {
                return view.CurrentPosition;
            }
        }

        /// <summary>
        /// Sets the size of a view for the width and the height.<br />
        /// Geometry can be scaled to fit within this area.<br />
        /// This does not interfere with the view's scale factor.<br />
        /// The views default depth is the minimum of width and height.<br />
        /// </summary>
        /// <remarks>
        /// This NUI object (Size2D) typed property can be configured by multiple cascade setting. <br />
        /// For example, this code ( view.Size2D.Width = 100; view.Size2D.Height = 100; ) is equivalent to this ( view.Size2D = new Size2D(100, 100); ). <br />
        /// Please note that this multi-cascade setting is especially possible for this NUI object (Size2D). <br />
        /// This means by default others are impossible so it is recommended that NUI object typed properties are configured by their constructor with parameters. <br />
        /// For example, this code is working fine : view.Scale = new Vector3( 2.0f, 1.5f, 0.0f); <br />
        /// but this will not work! : view.Scale.X = 2.0f; view.Scale.Y = 1.5f; <br />
        /// It may not match the current value in some cases, i.e. when the animation is progressing or the maximum or minimu size is set. <br />
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public Size2D Size2D
        {
            get
            {
                return (Size2D)GetValue(Size2DProperty);
            }
            set
            {
                SetValue(Size2DProperty, value);
            }
        }

        private void OnSize2DChanged(int width, int height)
        {
            Size2D = new Size2D(width, height);
        }

        /// <summary>
        ///  Retrieves the size of the view.<br />
        ///  The coordinates are relative to the view's parent.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Size2D CurrentSize
        {
            get
            {
                return view.CurrentSize;
            }
        }

        /// <summary>
        /// Retrieves and sets the view's opacity.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float Opacity
        {
            get
            {
                return (float)GetValue(OpacityProperty);
            }
            set
            {
                SetValue(OpacityProperty, value);
            }
        }

        /// <summary>
        /// Sets the position of the view for X and Y.<br />
        /// By default, sets the position vector between the parent origin and the pivot point (default).<br />
        /// If the position inheritance is disabled, sets the world position.<br />
        /// </summary>
        /// <remarks>
        /// This NUI object (Position2D) typed property can be configured by multiple cascade setting. <br />
        /// For example, this code ( view.Position2D.X = 100; view.Position2D.Y = 100; ) is equivalent to this ( view.Position2D = new Position2D(100, 100); ). <br />
        /// Please note that this multi-cascade setting is especially possible for this NUI object (Position2D). <br />
        /// This means by default others are impossible so it is recommended that NUI object typed properties are configured by their constructor with parameters. <br />
        /// For example, this code is working fine : view.Scale = new Vector3( 2.0f, 1.5f, 0.0f); <br />
        /// but this will not work! : view.Scale.X = 2.0f; view.Scale.Y = 1.5f; <br />
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public Position2D Position2D
        {
            get
            {
                return (Position2D)GetValue(Position2DProperty);
            }
            set
            {
                SetValue(Position2DProperty, value);
            }
        }

        private void OnPosition2DChanged(int x, int y)
        {
            Position2D = new Position2D(x, y);
        }

        /// <summary>
        /// Retrieves the screen postion of the view.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector2 ScreenPosition
        {
            get
            {
                return view.ScreenPosition;
            }
        }

        /// <summary>
        /// Determines whether the pivot point should be used to determine the position of the view.
        /// This is true by default.
        /// </summary>
        /// <remarks>If false, then the top-left of the view is used for the position.
        /// Setting this to false will allow scaling or rotation around the anchor-point without affecting the view's position.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public bool PositionUsesPivotPoint
        {
            get
            {
                return (bool)GetValue(PositionUsesPivotPointProperty);
            }
            set
            {
                SetValue(PositionUsesPivotPointProperty, value);
            }
        }

        /// <summary>
        /// Please do not use! this will be deprecated.
        /// </summary>
        /// Please do not use! this will be deprecated!
        /// Instead please use PositionUsesPivotPoint.
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Please do not use! This will be deprecated! Please use PositionUsesPivotPoint instead! " +
            "Like: " +
            "View view = new View(); " +
            "view.PivotPoint = PivotPoint.Center; " +
            "view.PositionUsesPivotPoint = true;")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool PositionUsesAnchorPoint
        {
            get
            {
                return view.PositionUsesPivotPoint;
            }
            set
            {
                view.PositionUsesPivotPoint = value;
            }
        }

        /// <summary>
        /// Queries whether the view is connected to the stage.<br />
        /// When a view is connected, it will be directly or indirectly parented to the root view.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool IsOnWindow
        {
            get
            {
                return view.IsOnWindow;
            }
        }

        /// <summary>
        /// Gets the depth in the hierarchy for the view.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int HierarchyDepth
        {
            get
            {
                return view.HierarchyDepth;
            }
        }

        /// <summary>
        /// Sets the sibling order of the view so the depth position can be defined within the same parent.
        /// </summary>
        /// <remarks>
        /// Note the initial value is 0. SiblingOrder should be bigger than 0 or equal to 0.
        /// Raise, Lower, RaiseToTop, LowerToBottom, RaiseAbove, and LowerBelow will override the sibling order.
        /// The values set by this property will likely change.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public int SiblingOrder
        {
            get
            {
                return (int)GetValue(SiblingOrderProperty);
            }
            set
            {
                SetValue(SiblingOrderProperty, value);
            }
        }

        /// <summary>
        /// Returns the natural size of the view.
        /// </summary>
        /// <remarks>
        /// Deriving classes stipulate the natural size and by default a view has a zero natural size.
        /// </remarks>
        /// <since_tizen> 5 </since_tizen>
        public Vector3 NaturalSize
        {
            get
            {
                return view.NaturalSize;
            }
        }

        /// <summary>
        /// Returns the natural size (Size2D) of the view.
        /// </summary>
        /// <remarks>
        /// Deriving classes stipulate the natural size and by default a view has a zero natural size.
        /// </remarks>
        /// <since_tizen> 4 </since_tizen>
        public Size2D NaturalSize2D
        {
            get
            {
                return view.NaturalSize2D;
            }
        }

        /// <summary>
        /// Shows the view.
        /// </summary>
        /// <remarks>
        /// This is an asynchronous method.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public void Show()
        {
            view.Show();
        }

        /// <summary>
        /// Hides the view.
        /// </summary>
        /// <remarks>
        /// This is an asynchronous method.
        /// If the view is hidden, then the view and its children will not be rendered.
        /// This is regardless of the individual visibility of the children, i.e., the view will only be rendered if all of its parents are shown.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public void Hide()
        {
            view.Hide();
        }

        /// <summary>
        /// Raises the view above all other views.
        /// </summary>
        /// <remarks>
        /// Sibling order of views within the parent will be updated automatically.
        /// Once a raise or lower API is used, that view will then have an exclusive sibling order independent of insertion.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public void RaiseToTop()
        {
            view.RaiseToTop();
        }

        /// <summary>
        /// Lowers the view to the bottom of all views.
        /// </summary>
        /// <remarks>
        /// The sibling order of views within the parent will be updated automatically.
        /// Once a raise or lower API is used that view will then have an exclusive sibling order independent of insertion.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public void LowerToBottom()
        {
            view.LowerToBottom();
        }

        /// <summary>
        /// Queries if all resources required by a view are loaded and ready.
        /// </summary>
        /// <remarks>Most resources are only loaded when the control is placed on the stage.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public bool IsResourceReady()
        {
            return view.IsResourceReady();
        }

        /// <summary>
        /// Gets the parent layer of this view.If a view has no parent, this method does not do anything.
        /// </summary>
        /// <pre>The view has been initialized. </pre>
        /// <returns>The parent layer of view </returns>
        /// <since_tizen> 5 </since_tizen>
        public Layer GetLayer()
        {
            return BaseHandle.GetHandle(view.GetLayer()) as Layer;
        }

        /// <summary>
        /// Removes a view from its parent view or layer. If a view has no parent, this method does nothing.
        /// </summary>
        /// <pre>The (child) view has been initialized. </pre>
        /// <since_tizen> 4 </since_tizen>
        public void Unparent()
        {
            view.GetParent()?.Remove(view);
        }

        /// <summary>
        /// Search through this view's hierarchy for a view with the given name.
        /// The view itself is also considered in the search.
        /// </summary>
        /// <pre>The view has been initialized.</pre>
        /// <param name="viewName">The name of the view to find.</param>
        /// <returns>A handle to the view if found, or an empty handle if not.</returns>
        /// <since_tizen> 3 </since_tizen>
        public View FindChildByName(string viewName)
        {
            return BaseHandle.GetHandle(view.FindChildByName(viewName)) as View;
        }

        /// <summary>
        /// Converts screen coordinates into the view's coordinate system using the default camera.
        /// </summary>
        /// <pre>The view has been initialized.</pre>
        /// <remarks>The view coordinates are relative to the top-left(0.0, 0.0, 0.5).</remarks>
        /// <param name="localX">On return, the X-coordinate relative to the view.</param>
        /// <param name="localY">On return, the Y-coordinate relative to the view.</param>
        /// <param name="screenX">The screen X-coordinate.</param>
        /// <param name="screenY">The screen Y-coordinate.</param>
        /// <returns>True if the conversion succeeded.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool ScreenToLocal(out float localX, out float localY, float screenX, float screenY)
        {
            return view.ScreenToLocal(out localX, out localY, screenX, screenY);
        }

        /// <summary>
        /// Sets the relative to parent size factor of the view.<br />
        /// This factor is only used when ResizePolicy is set to either:
        /// ResizePolicy::SIZE_RELATIVE_TO_PARENT or ResizePolicy::SIZE_FIXED_OFFSET_FROM_PARENT.<br />
        /// This view's size is set to the view's size multiplied by or added to this factor, depending on ResizePolicy.<br />
        /// </summary>
        /// <pre>The view has been initialized.</pre>
        /// <param name="factor">A Vector3 representing the relative factor to be applied to each axis.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetSizeModeFactor(Vector3 factor)
        {
            view.SetSizeModeFactor(factor);
        }

        /// <summary>
        /// Calculates the height of the view given a width.<br />
        /// The natural size is used for default calculation.<br />
        /// Size 0 is treated as aspect ratio 1:1.<br />
        /// </summary>
        /// <param name="width">The width to use.</param>
        /// <returns>The height based on the width.</returns>
        /// <since_tizen> 3 </since_tizen>
        public float GetHeightForWidth(float width)
        {
            return view.GetHeightForWidth(width);
        }

        /// <summary>
        /// Calculates the width of the view given a height.<br />
        /// The natural size is used for default calculation.<br />
        /// Size 0 is treated as aspect ratio 1:1.<br />
        /// </summary>
        /// <param name="height">The height to use.</param>
        /// <returns>The width based on the height.</returns>
        /// <since_tizen> 3 </since_tizen>
        public float GetWidthForHeight(float height)
        {
            return view.GetWidthForHeight(height);
        }

        /// <summary>
        /// Return the amount of size allocated for relayout.
        /// </summary>
        /// <param name="dimension">The dimension to retrieve.</param>
        /// <returns>Return the size.</returns>
        /// <since_tizen> 3 </since_tizen>
        public float GetRelayoutSize(DimensionType dimension)
        {
            return view.GetRelayoutSize(dimension);
        }

        /// <summary>
        /// Set the padding for the view.
        /// </summary>
        /// <param name="padding">Padding for the view.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetPadding(PaddingType padding)
        {
            view.SetPadding(padding);
        }

        /// <summary>
        /// Return the value of padding for the view.
        /// </summary>
        /// <param name="paddingOut">the value of padding for the view</param>
        /// <since_tizen> 3 </since_tizen>
        public void GetPadding(PaddingType paddingOut)
        {
            view.GetPadding(paddingOut);
        }

        /// <since_tizen> 3 </since_tizen>
        public uint AddRenderer(Renderer renderer)
        {
            return view.AddRenderer(renderer);
        }

        /// <since_tizen> 3 </since_tizen>
        public Renderer GetRendererAt(uint index)
        {
            return view.GetRendererAt(index);
        }

        /// <since_tizen> 3 </since_tizen>
        public void RemoveRenderer(Renderer renderer)
        {
            view.RemoveRenderer(renderer);
        }

        /// <since_tizen> 3 </since_tizen>
        public void RemoveRenderer(uint index)
        {
            view.RemoveRenderer(index);
        }

        /// <summary>
        /// Gets or sets the origin of a view within its parent's area.<br />
        /// This is expressed in unit coordinates, such that (0.0, 0.0, 0.5) is the top-left corner of the parent, and (1.0, 1.0, 0.5) is the bottom-right corner.<br />
        /// The default parent-origin is ParentOrigin.TopLeft (0.0, 0.0, 0.5).<br />
        /// A view's position is the distance between this origin and the view's anchor-point.<br />
        /// </summary>
        /// <pre>The view has been initialized.</pre>
        /// <since_tizen> 3 </since_tizen>
        public Position ParentOrigin
        {
            get
            {
                return (Position)GetValue(ParentOriginProperty);
            }
            set
            {
                SetValue(ParentOriginProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the anchor-point of a view.<br />
        /// This is expressed in unit coordinates, such that (0.0, 0.0, 0.5) is the top-left corner of the view, and (1.0, 1.0, 0.5) is the bottom-right corner.<br />
        /// The default pivot point is PivotPoint.Center (0.5, 0.5, 0.5).<br />
        /// A view position is the distance between its parent-origin and this anchor-point.<br />
        /// A view's orientation is the rotation from its default orientation, the rotation is centered around its anchor-point.<br />
        /// <pre>The view has been initialized.</pre>
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Position PivotPoint
        {
            get
            {
                return (Position)GetValue(PivotPointProperty);
            }
            set
            {
                SetValue(PivotPointProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the size width of the view.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float SizeWidth
        {
            get
            {
                return (float)GetValue(SizeWidthProperty);
            }
            set
            {
                SetValue(SizeWidthProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the size height of the view.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float SizeHeight
        {
            get
            {
                return (float)GetValue(SizeHeightProperty);
            }
            set
            {
                SetValue(SizeHeightProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the position of the view.<br />
        /// By default, sets the position vector between the parent origin and pivot point (default).<br />
        /// If the position inheritance is disabled, sets the world position.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Position Position
        {
            get
            {
                return (Position)GetValue(PositionProperty);
            }
            set
            {
                SetValue(PositionProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the position X of the view.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float PositionX
        {
            get
            {
                return (float)GetValue(PositionXProperty);
            }
            set
            {
                SetValue(PositionXProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the position Y of the view.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float PositionY
        {
            get
            {
                return (float)GetValue(PositionYProperty);
            }
            set
            {
                SetValue(PositionYProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the position Z of the view.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float PositionZ
        {
            get
            {
                return (float)GetValue(PositionZProperty);
            }
            set
            {
                SetValue(PositionZProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the world position of the view.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector3 WorldPosition
        {
            get
            {
                return view.WorldPosition;
            }
        }

        /// <summary>
        /// Gets or sets the orientation of the view.<br />
        /// The view's orientation is the rotation from its default orientation, and the rotation is centered around its anchor-point.<br />
        /// </summary>
        /// <remarks>This is an asynchronous method.</remarks>
        /// <since_tizen> 3 </since_tizen>
        public Rotation Orientation
        {
            get
            {
                return (Rotation)GetValue(OrientationProperty);
            }
            set
            {
                SetValue(OrientationProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the world orientation of the view.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Rotation WorldOrientation
        {
            get
            {
                return view.WorldOrientation;
            }
        }

        /// <summary>
        /// Gets or sets the scale factor applied to the view.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector3 Scale
        {
            get
            {
                return (Vector3)GetValue(ScaleProperty);
            }
            set
            {
                SetValue(ScaleProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the scale X factor applied to the view.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float ScaleX
        {
            get
            {
                return (float)GetValue(ScaleXProperty);
            }
            set
            {
                SetValue(ScaleXProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the scale Y factor applied to the view.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float ScaleY
        {
            get
            {
                return (float)GetValue(ScaleYProperty);
            }
            set
            {
                SetValue(ScaleYProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the scale Z factor applied to the view.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float ScaleZ
        {
            get
            {
                return (float)GetValue(ScaleZProperty);
            }
            set
            {
                SetValue(ScaleZProperty, value);
            }
        }

        /// <summary>
        /// Gets the world scale of the view.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector3 WorldScale
        {
            get
            {
                return view.WorldScale;
            }
        }

        /// <summary>
        /// Retrieves the visibility flag of the view.
        /// </summary>
        /// <remarks>
        /// If the view is not visible, then the view and its children will not be rendered.
        /// This is regardless of the individual visibility values of the children, i.e., the view will only be rendered if all of its parents have visibility set to true.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public bool Visibility
        {
            get
            {
                return view.Visibility;
            }
        }

        /// <summary>
        /// Gets the view's world color.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector4 WorldColor
        {
            get
            {
                return view.WorldColor;
            }
        }

        /// <summary>
        /// Gets or sets the view's name.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Name
        {
            get
            {
                return (string)GetValue(NameProperty);
            }
            set
            {
                SetValue(NameProperty, value);
            }
        }

        /// <summary>
        /// Get the number of children held by the view.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public new uint ChildCount
        {
            get
            {
                return GetChildCount();
            }
        }

        /// <summary>
        /// Gets the view's ID.
        /// Readonly
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public uint ID
        {
            get
            {
                return view.ID;
            }
        }

        /// <summary>
        /// Gets or sets the status of whether the view should emit touch or hover signals.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool Sensitive
        {
            get
            {
                return (bool)GetValue(SensitiveProperty);
            }
            set
            {
                SetValue(SensitiveProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the status of whether the view should receive a notification when touch or hover motion events leave the boundary of the view.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool LeaveRequired
        {
            get
            {
                return (bool)GetValue(LeaveRequiredProperty);
            }
            set
            {
                SetValue(LeaveRequiredProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the status of whether a child view inherits it's parent's orientation.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool InheritOrientation
        {
            get
            {
                return (bool)GetValue(InheritOrientationProperty);
            }
            set
            {
                SetValue(InheritOrientationProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the status of whether a child view inherits it's parent's scale.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool InheritScale
        {
            get
            {
                return (bool)GetValue(InheritScaleProperty);
            }
            set
            {
                SetValue(InheritScaleProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the status of how the view and its children should be drawn.<br />
        /// Not all views are renderable, but DrawMode can be inherited from any view.<br />
        /// If an object is in a 3D layer, it will be depth-tested against other objects in the world, i.e., it may be obscured if other objects are in front.<br />
        /// If DrawMode.Overlay2D is used, the view and its children will be drawn as a 2D overlay.<br />
        /// Overlay views are drawn in a separate pass, after all non-overlay views within the layer.<br />
        /// For overlay views, the drawing order is with respect to tree levels of views, and depth-testing will not be used.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public DrawModeType DrawMode
        {
            get
            {
                return (DrawModeType)GetValue(DrawModeProperty);
            }
            set
            {
                SetValue(DrawModeProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the relative to parent size factor of the view.<br />
        /// This factor is only used when ResizePolicyType is set to either: ResizePolicyType.SizeRelativeToParent or ResizePolicyType.SizeFixedOffsetFromParent.<br />
        /// This view's size is set to the view's size multiplied by or added to this factor, depending on ResizePolicyType.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector3 SizeModeFactor
        {
            get
            {
                return (Vector3)GetValue(SizeModeFactorProperty);
            }
            set
            {
                SetValue(SizeModeFactorProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the width resize policy to be used.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public ResizePolicyType WidthResizePolicy
        {
            get
            {
                return (ResizePolicyType)GetValue(WidthResizePolicyProperty);
            }
            set
            {
                SetValue(WidthResizePolicyProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the height resize policy to be used.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public ResizePolicyType HeightResizePolicy
        {
            get
            {
                return (ResizePolicyType)GetValue(HeightResizePolicyProperty);
            }
            set
            {
                SetValue(HeightResizePolicyProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the policy to use when setting size with size negotiation.<br />
        /// Defaults to SizeScalePolicyType.UseSizeSet.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public SizeScalePolicyType SizeScalePolicy
        {
            get
            {
                return (SizeScalePolicyType)GetValue(SizeScalePolicyProperty);
            }
            set
            {
                SetValue(SizeScalePolicyProperty, value);
            }
        }

        /// <summary>
        ///  Gets or sets the status of whether the width size is dependent on the height size.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool WidthForHeight
        {
            get
            {
                return (bool)GetValue(WidthForHeightProperty);
            }
            set
            {
                SetValue(WidthForHeightProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the status of whether the height size is dependent on the width size.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool HeightForWidth
        {
            get
            {
                return (bool)GetValue(HeightForWidthProperty);
            }
            set
            {
                SetValue(HeightForWidthProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the padding for use in layout.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public Extents Padding
        {
            get
            {
                return (Extents)GetValue(PaddingProperty);
            }
            set
            {
                SetValue(PaddingProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the minimum size the view can be assigned in size negotiation.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Size2D MinimumSize
        {
            get
            {
                return (Size2D)GetValue(MinimumSizeProperty);
            }
            set
            {
                SetValue(MinimumSizeProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the maximum size the view can be assigned in size negotiation.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Size2D MaximumSize
        {
            get
            {
                return (Size2D)GetValue(MaximumSizeProperty);
            }
            set
            {
                // We don't have Layout.Maximum(Width|Height) so we cannot apply it to layout.
                // MATCH_PARENT spec + parent container size can be used to limit
                SetValue(MaximumSizeProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets whether a child view inherits it's parent's position.<br />
        /// Default is to inherit.<br />
        /// Switching this off means that using position sets the view's world position, i.e., translates from the world origin (0,0,0) to the pivot point of the view.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool InheritPosition
        {
            get
            {
                return (bool)GetValue(InheritPositionProperty);
            }
            set
            {
                SetValue(InheritPositionProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the clipping behavior (mode) of it's children.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public ClippingModeType ClippingMode
        {
            get
            {
                return (ClippingModeType)GetValue(ClippingModeProperty);
            }
            set
            {
                SetValue(ClippingModeProperty, value);
            }
        }

        /// <summary>
        /// Gets the number of renderers held by the view.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public uint RendererCount
        {
            get
            {
                return view.RendererCount;
            }
        }

        /// <summary>
        /// [Obsolete("Please do not use! this will be deprecated")]
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// Please do not use! this will be deprecated!
        /// Instead please use PivotPoint.
        [Obsolete("Please do not use! This will be deprecated! Please use PivotPoint instead! " +
            "Like: " +
            "View view = new View(); " +
            "view.PivotPoint = PivotPoint.Center; " +
            "view.PositionUsesPivotPoint = true;")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Position AnchorPoint
        {
            get
            {
                return view.AnchorPoint;
            }
            set
            {
                view.AnchorPoint = value;
            }
        }

        /// <summary>
        /// Sets the size of a view for the width, the height and the depth.<br />
        /// Geometry can be scaled to fit within this area.<br />
        /// This does not interfere with the view's scale factor.<br />
        /// The views default depth is the minimum of width and height.<br />
        /// </summary>
        /// <remarks>
        /// Please note that multi-cascade setting is not possible for this NUI object. <br />
        /// It is recommended that NUI object typed properties are configured by their constructor with parameters. <br />
        /// For example, this code is working fine : view.Size = new Size( 1.0f, 1.0f, 0.0f); <br />
        /// but this will not work! : view.Size.Width = 2.0f; view.Size.Height = 2.0f; <br />
        /// It may not match the current value in some cases, i.e. when the animation is progressing or the maximum or minimu size is set. <br />
        /// </remarks>
        /// <since_tizen> 5 </since_tizen>
        public Size Size
        {
            get
            {
                return (Size)GetValue(SizeProperty);
            }
            set
            {
                SetValue(SizeProperty, value);
            }
        }

        /// <summary>
        /// "Please DO NOT use! This will be deprecated! Please use 'Container GetParent() for derived class' instead!"
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Please do not use! This will be deprecated! Please use 'Container GetParent() for derived class' instead! " +
            "Like: " +
            "Container parent =  view.GetParent(); " +
            "View view = parent as View;")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new View Parent
        {
            get
            {
                return BaseHandle.GetHandle(view.Parent) as View;
            }
        }

        /// <summary>
        /// Gets/Sets whether inherit parent's the layout Direction.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public bool InheritLayoutDirection
        {
            get
            {
                return (bool)GetValue(InheritLayoutDirectionProperty);
            }
            set
            {
                SetValue(InheritLayoutDirectionProperty, value);
            }
        }

        /// <summary>
        /// Gets/Sets the layout Direction.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public Tizen.NUI.BaseComponents.ViewLayoutDirectionType LayoutDirection
        {
            get
            {
                return (Tizen.NUI.BaseComponents.ViewLayoutDirectionType)GetValue(LayoutDirectionProperty);
            }
            set
            {
                SetValue(LayoutDirectionProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the Margin for use in layout.
        /// </summary>
        /// <remarks>
        /// Margin property is supported by Layout algorithms and containers.
        /// Please Set Layout if you want to use Margin property.
        /// </remarks>
        /// <since_tizen> 4 </since_tizen>
        public Extents Margin
        {
            get
            {
                return (Extents)GetValue(MarginProperty);
            }
            set
            {
                SetValue(MarginProperty, value);
            }
        }

        private MergedStyle _mergedStyle = null;
        internal MergedStyle mergedStyle
        {
            get
            {
                if (_mergedStyle == null)
                {
                    _mergedStyle = new MergedStyle(GetType(), this);
                }

                return _mergedStyle;
            }
        }
        public Style Style
        {
            get
            {
                return (Style)GetValue(StyleProperty);
            }
            set
            {
                SetValue(StyleProperty, value);
            }
        }

        /// <summary>
        /// [Obsolete("Please do not use! this will be deprecated")]
        /// </summary>
        /// Please do not use! this will be deprecated!
        /// Instead please use Padding.
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Please do not use! this will be deprecated, instead please use Padding.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Extents PaddingEX
        {
            get
            {
                return view.PaddingEX;
            }
            set
            {
                view.PaddingEX = value;
            }
        }

        /// <summary>
        /// Perform an action on a visual registered to this view. <br />
        /// Visuals will have actions. This API is used to perform one of these actions with the given attributes.
        /// </summary>
        /// <param name="propertyIndexOfVisual">The Property index of the visual.</param>
        /// <param name="propertyIndexOfActionId">The action to perform. See Visual to find the supported actions.</param>
        /// <param name="attributes">Optional attributes for the action.</param>
        /// <since_tizen> 5 </since_tizen>
        public void DoAction(int propertyIndexOfVisual, int propertyIndexOfActionId, PropertyValue attributes)
        {
            view.DoAction(propertyIndexOfVisual, propertyIndexOfActionId, attributes);
        }
    }
}
