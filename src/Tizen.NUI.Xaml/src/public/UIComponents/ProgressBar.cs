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
using System.Runtime.InteropServices;
using Tizen.NUI;
using Tizen.NUI.Binding;
using Tizen.NUI.Xaml.Forms.BaseComponents;
using static Tizen.NUI.UIComponents.ProgressBar;

namespace Tizen.NUI.Xaml.UIComponents
{
    /// <summary>
    /// The ProgressBar is a control to give the user an indication of the progress of an operation.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class ProgressBar : View
    {
        private Tizen.NUI.UIComponents.ProgressBar _progressBar;
        internal Tizen.NUI.UIComponents.ProgressBar progressBar
        {
            get
            {
                if (null == _progressBar)
                {
                    _progressBar = handleInstance as Tizen.NUI.UIComponents.ProgressBar;
                }

                return _progressBar;
            }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public ProgressBar() : this(new Tizen.NUI.UIComponents.ProgressBar())
        {
        }

        internal ProgressBar(Tizen.NUI.UIComponents.ProgressBar nuiInstance) : base(nuiInstance)
        {
            SetNUIInstance(nuiInstance);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty ProgressValueProperty = Binding.BindableProperty.Create("ProgressValue", typeof(float), typeof(ProgressBar), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var progressBar = ((ProgressBar)bindable).progressBar;
            progressBar.ProgressValue = (float)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var progressBar = ((ProgressBar)bindable).progressBar;
            return progressBar.ProgressValue;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty SecondaryProgressValueProperty = Binding.BindableProperty.Create("SecondaryProgressValue", typeof(float), typeof(ProgressBar), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var progressBar = ((ProgressBar)bindable).progressBar;
            progressBar.SecondaryProgressValue = (float)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var progressBar = ((ProgressBar)bindable).progressBar;
            return progressBar.SecondaryProgressValue;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty IndeterminateProperty = Binding.BindableProperty.Create("Indeterminate", typeof(bool), typeof(ProgressBar), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var progressBar = ((ProgressBar)bindable).progressBar;
            progressBar.Indeterminate = (bool)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var progressBar = ((ProgressBar)bindable).progressBar;
            return progressBar.Indeterminate;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty TrackVisualProperty = Binding.BindableProperty.Create("TrackVisual", typeof(PropertyMap), typeof(ProgressBar), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var progressBar = ((ProgressBar)bindable).progressBar;
            progressBar.TrackVisual = (PropertyMap)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var progressBar = ((ProgressBar)bindable).progressBar;
            return progressBar.TrackVisual;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty ProgressVisualProperty = Binding.BindableProperty.Create("ProgressVisual", typeof(PropertyMap), typeof(ProgressBar), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var progressBar = ((ProgressBar)bindable).progressBar;
            progressBar.ProgressVisual = (PropertyMap)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var progressBar = ((ProgressBar)bindable).progressBar;
            return progressBar.ProgressVisual;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty SecondaryProgressVisualProperty = Binding.BindableProperty.Create("SecondaryProgressVisual", typeof(PropertyMap), typeof(ProgressBar), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var progressBar = ((ProgressBar)bindable).progressBar;
            progressBar.SecondaryProgressVisual = (PropertyMap)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var progressBar = ((ProgressBar)bindable).progressBar;
            return progressBar.SecondaryProgressVisual;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty IndeterminateVisualProperty = Binding.BindableProperty.Create("IndeterminateVisual", typeof(PropertyMap), typeof(ProgressBar), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var progressBar = ((ProgressBar)bindable).progressBar;
            progressBar.IndeterminateVisual = (PropertyMap)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var progressBar = ((ProgressBar)bindable).progressBar;
            return progressBar.IndeterminateVisual;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty IndeterminateVisualAnimationProperty = Binding.BindableProperty.Create("IndeterminateVisualAnimation", typeof(PropertyArray), typeof(ProgressBar), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var progressBar = ((ProgressBar)bindable).progressBar;
            progressBar.IndeterminateVisualAnimation = (PropertyArray)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var progressBar = ((ProgressBar)bindable).progressBar;
            return progressBar.IndeterminateVisualAnimation;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty LabelVisualProperty = Binding.BindableProperty.Create("LabelVisual", typeof(PropertyMap), typeof(ProgressBar), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var progressBar = ((ProgressBar)bindable).progressBar;
            progressBar.LabelVisual = (PropertyMap)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var progressBar = ((ProgressBar)bindable).progressBar;
            return progressBar.LabelVisual;
        });

        /// <summary>
        /// The event is sent when the ProgressBar value changes.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<ValueChangedEventArgs> ValueChanged
        {
            add
            {
                progressBar.ValueChanged += value;
            }
            remove
            {
                progressBar.ValueChanged -= value;
            }
        }

        /// <summary>
        /// The progress value of the progress bar, the progress runs from 0 to 1.<br />
        /// If the value is set to 0, then the progress bar will be set to beginning.<br />
        /// If the value is set to 1, then the progress bar will be set to end.<br />
        /// Any value outside the range is ignored.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float ProgressValue
        {
            get
            {
                return (float)GetValue(ProgressValueProperty);
            }
            set
            {
                SetValue(ProgressValueProperty, value);
            }
        }

        /// <summary>
        /// The secondary progress value of the progress bar, the secondary progress runs from 0 to 1.<br />
        /// Optional. If not supplied, the default is 0.<br />
        /// If the value is set to 0, then the progress bar will be set secondary progress to beginning.<br />
        /// If the value is set to 1, then the progress bar will be set secondary progress to end.<br />
        /// Any value outside of the range is ignored.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float SecondaryProgressValue
        {
            get
            {
                return (float)GetValue(SecondaryProgressValueProperty);
            }
            set
            {
                SetValue(SecondaryProgressValueProperty, value);
            }
        }

        /// <summary>
        /// Sets the progress bar as \e indeterminate state.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool Indeterminate
        {
            get
            {
                return (bool)GetValue(IndeterminateProperty);
            }
            set
            {
                SetValue(IndeterminateProperty, value);
            }
        }

        /// <summary>
        /// The track visual value of progress bar, it's full progress area, and it's shown behind the PROGRESS_VISUAL.<br />
        /// Optional. If not supplied, the default track visual will be shown.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap TrackVisual
        {
            get
            {
                return (PropertyMap)GetValue(TrackVisualProperty);
            }
            set
            {
                SetValue(TrackVisualProperty, value);
            }
        }

        /// <summary>
        /// The progress visual value of the progress bar, the size of the progress visual is changed based on the PROGRESS_VALUE.<br />
        /// Optional. If not supplied, then the default progress visual will be shown.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap ProgressVisual
        {
            get
            {
                return (PropertyMap)GetValue(ProgressVisualProperty);
            }
            set
            {
                SetValue(ProgressVisualProperty, value);
            }
        }

        /// <summary>
        /// The secondary progress visual of the progress bar, the size of the secondary progress visual is changed based on the SECONDARY_PROGRESS_VALUE.<br />
        /// Optional. If not supplied, then the secondary progress visual will not be shown.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap SecondaryProgressVisual
        {
            get
            {
                return (PropertyMap)GetValue(SecondaryProgressVisualProperty);
            }
            set
            {
                SetValue(SecondaryProgressVisualProperty, value);
            }
        }

        /// <summary>
        /// The indeterminate visual of the progress bar.<br />
        /// Optional. If not supplied, then the default indeterminate visual will be shown.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap IndeterminateVisual
        {
            get
            {
                return (PropertyMap)GetValue(IndeterminateVisualProperty);
            }
            set
            {
                SetValue(IndeterminateVisualProperty, value);
            }
        }

        /// <summary>
        /// The transition data for the indeterminate visual animation.<br />
        /// Optional. If not supplied, then the default animation will be played.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyArray IndeterminateVisualAnimation
        {
            get
            {
                return (PropertyArray)GetValue(IndeterminateVisualAnimationProperty);
            }
            set
            {
                SetValue(IndeterminateVisualAnimationProperty, value);
            }
        }

        /// <summary>
        /// The label visual of the progress bar.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap LabelVisual
        {
            get
            {
                return (PropertyMap)GetValue(LabelVisualProperty);
            }
            set
            {
                SetValue(LabelVisualProperty, value);
            }
        }
    }
}
