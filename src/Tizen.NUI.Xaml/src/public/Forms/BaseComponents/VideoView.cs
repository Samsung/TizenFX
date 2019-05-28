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
using Tizen.NUI;
using Tizen.NUI.Binding;
using static Tizen.NUI.BaseComponents.VideoView;

namespace Tizen.NUI.Xaml.Forms.BaseComponents
{
    /// <summary>
    /// VideoView is a control for video playback and display.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class VideoView : View
    {
        private Tizen.NUI.BaseComponents.VideoView _videoView;
        internal Tizen.NUI.BaseComponents.VideoView videoView
        {
            get
            {
                if (null == _videoView)
                {
                    _videoView = handleInstance as Tizen.NUI.BaseComponents.VideoView;
                }

                return _videoView;
            }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VideoView() : this(new Tizen.NUI.BaseComponents.VideoView())
        {
        }

        internal VideoView(Tizen.NUI.BaseComponents.VideoView nuiInstance) : base(nuiInstance)
        {
            SetNUIInstance(nuiInstance);
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty VideoProperty = Binding.BindableProperty.Create("Video", typeof(PropertyMap), typeof(VideoView), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var videoView = ((VideoView)bindable).videoView;
            videoView.Video = (PropertyMap)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var videoView = ((VideoView)bindable).videoView;
            return videoView.Video;
        });
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty LoopingProperty = Binding.BindableProperty.Create("Looping", typeof(bool), typeof(VideoView), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var videoView = ((VideoView)bindable).videoView;
            videoView.Looping = (bool)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var videoView = ((VideoView)bindable).videoView;
            return videoView.Looping;
        });
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty MutedProperty = Binding.BindableProperty.Create("Muted", typeof(bool), typeof(VideoView), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var videoView = ((VideoView)bindable).videoView;
            videoView.Muted = (bool)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var videoView = ((VideoView)bindable).videoView;
            return videoView.Muted;
        });
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty VolumeProperty = Binding.BindableProperty.Create("Volume", typeof(PropertyMap), typeof(VideoView), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var videoView = ((VideoView)bindable).videoView;
            videoView.Volume = (PropertyMap)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var videoView = ((VideoView)bindable).videoView;
            return videoView.Volume;
        });
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty UnderlayProperty = Binding.BindableProperty.Create("Underlay", typeof(bool), typeof(VideoView), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var videoView = ((VideoView)bindable).videoView;
            videoView.Underlay = (bool)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var videoView = ((VideoView)bindable).videoView;
            return videoView.Underlay;
        });
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty ResourceUrlProperty = Binding.BindableProperty.Create("ResourceUrl", typeof(string), typeof(VideoView), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var videoView = ((VideoView)bindable).videoView;
            videoView.ResourceUrl = (string)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var videoView = ((VideoView)bindable).videoView;
            return videoView.ResourceUrl;
        });

        /// <summary>
        /// Event for the finished signal which can be used to subscribe or unsubscribe the event handler
        /// The finished signal is emitted when a video playback has finished.<br />
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<FinishedEventArgs> Finished
        {
            add
            {
                videoView.Finished += value;
            }
            remove
            {
                videoView.Finished -= value;
            }
        }

        /// <summary>
        /// Starts the video playback.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Play()
        {
            videoView.Play();
        }

        /// <summary>
        /// Pauses the video playback.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Pause()
        {
            videoView.Pause();
        }

        /// <summary>
        /// Stops the video playback.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Stop()
        {
            videoView.Stop();
        }

        /// <summary>
        /// Seeks forward by the specified number of milliseconds.
        /// </summary>
        /// <param name="millisecond">The position for forward playback.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Forward(int millisecond)
        {
            videoView.Forward(millisecond);
        }

        /// <summary>
        /// Seeks backward by the specified number of milliseconds.
        /// </summary>
        /// <param name="millisecond">The position for backward playback.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Backward(int millisecond)
        {
            videoView.Backward(millisecond);
        }

        /// <summary>
        /// Video file setting type of PropertyMap.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyMap Video
        {
            get
            {
                return (PropertyMap)GetValue(VideoProperty);
            }
            set
            {
                SetValue(VideoProperty, value);
            }
        }

        /// <summary>
        /// The looping status, true or false.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Looping
        {
            get
            {
                return (bool)GetValue(LoopingProperty);
            }
            set
            {
                SetValue(LoopingProperty, value);
            }
        }

        /// <summary>
        /// The mute status, true or false.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Muted
        {
            get
            {
                return (bool)GetValue(MutedProperty);
            }
            set
            {
                SetValue(MutedProperty, value);
            }
        }

        /// <summary>
        /// The left and the right volume scalar as float type, PropertyMap with two values ( "left" and "right" ).
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyMap Volume
        {
            get
            {
                return (PropertyMap)GetValue(VolumeProperty);
            }
            set
            {
                SetValue(VolumeProperty, value);
            }
        }

        /// <summary>
        /// Video rendering by underlay, true or false.<br />
        /// This shows video composited underneath the window by the system. This means it may ignore rotation of the video-view.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Underlay
        {
            get
            {
                return (bool)GetValue(UnderlayProperty);
            }
            set
            {
                SetValue(UnderlayProperty, value);
            }
        }

        /// <summary>
        /// Video file URL as string type.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ResourceUrl
        {
            get
            {
                return (string)GetValue(ResourceUrlProperty);
            }
            set
            {
                SetValue(ResourceUrlProperty, value);
            }
        }
    }
}
