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
using System.Runtime.InteropServices;
using Tizen.NUI.Binding;

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// VideoView is a control for video playback and display.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class VideoView : View
    {
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty VideoProperty = BindableProperty.Create(nameof(Video), typeof(PropertyMap), typeof(VideoView), null, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var videoView = (VideoView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)videoView.SwigCPtr, VideoView.Property.VIDEO, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var videoView = (VideoView)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty((HandleRef)videoView.SwigCPtr, VideoView.Property.VIDEO).Get(temp);
            return temp;
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LoopingProperty = BindableProperty.Create(nameof(Looping), typeof(bool), typeof(VideoView), false, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var videoView = (VideoView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)videoView.SwigCPtr, VideoView.Property.LOOPING, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var videoView = (VideoView)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty((HandleRef)videoView.SwigCPtr, VideoView.Property.LOOPING).Get(out temp);
            return temp;
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MutedProperty = BindableProperty.Create(nameof(Muted), typeof(bool), typeof(VideoView), false, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var videoView = (VideoView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)videoView.SwigCPtr, VideoView.Property.MUTED, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var videoView = (VideoView)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty((HandleRef)videoView.SwigCPtr, VideoView.Property.MUTED).Get(out temp);
            return temp;
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty VolumeProperty = BindableProperty.Create(nameof(Volume), typeof(PropertyMap), typeof(VideoView), null, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var videoView = (VideoView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)videoView.SwigCPtr, VideoView.Property.VOLUME, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var videoView = (VideoView)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty((HandleRef)videoView.SwigCPtr, VideoView.Property.VOLUME).Get(temp);
            return temp;
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty UnderlayProperty = BindableProperty.Create(nameof(Underlay), typeof(bool), typeof(VideoView), false, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var videoView = (VideoView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)videoView.SwigCPtr, VideoView.Property.UNDERLAY, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var videoView = (VideoView)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty((HandleRef)videoView.SwigCPtr, VideoView.Property.UNDERLAY).Get(out temp);
            return temp;
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ResourceUrlProperty = BindableProperty.Create(nameof(ResourceUrl), typeof(string), typeof(VideoView), string.Empty, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var videoView = (VideoView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)videoView.SwigCPtr, VideoView.Property.VIDEO, new Tizen.NUI.PropertyValue((string)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var videoView = (VideoView)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty((HandleRef)videoView.SwigCPtr, VideoView.Property.VIDEO).Get(out temp);
            return temp;
        }));

        private FinishedCallbackDelegate videoViewFinishedCallbackDelegate;
        private EventHandler<FinishedEventArgs> videoViewFinishedEventHandler;

        /// <summary>
        /// Creates an initialized VideoView.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public VideoView() : this(Interop.VideoView.New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Creates an initialized VideoView.<br />
        /// If the string is empty, VideoView will not display anything.<br />
        /// </summary>
        /// <param name="url">The URL of the video resource to display.</param>
        /// <since_tizen> 3 </since_tizen>
        public VideoView(string url) : this(Interop.VideoView.New(url), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Creates an initialized VideoView.<br />
        /// If the string is empty, VideoView will not display anything.<br />
        /// </summary>
        /// <param name="swCodec">Video rendering by H/W codec if false.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VideoView(bool swCodec) : this(Interop.VideoView.New(swCodec), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Creates an initialized VideoView.<br />
        /// If the string is empty, VideoView will not display anything.<br />
        /// </summary>
        /// <param name="url">The URL of the video resource to display.</param>
        /// <param name="swCodec">Video rendering by H/W codec if false.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VideoView(string url, bool swCodec) : this(Interop.VideoView.New(url, swCodec), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Hidden API (Inhouse API).
        /// Using Uri class to provide safe service and secure API.
        /// Creates an initialized VideoView.
        /// If the string is empty, VideoView will not display anything.
        /// </summary>
        /// <param name="uri">The URI of the video resource to display.</param>
        /// <param name="swCodec">Video rendering by H/W codec if false.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VideoView(Uri uri, bool swCodec) : this(Interop.VideoView.New((uri == null) ? String.Empty : uri.AbsoluteUri, swCodec), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal VideoView(VideoView videoView) : this(Interop.VideoView.NewVideoView(VideoView.getCPtr(videoView)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal VideoView(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void FinishedCallbackDelegate(IntPtr data);

        /// <summary>
        /// Event for the finished signal which can be used to subscribe or unsubscribe the event handler
        /// The finished signal is emitted when a video playback has finished.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<FinishedEventArgs> Finished
        {
            add
            {
                if (videoViewFinishedEventHandler == null)
                {
                    videoViewFinishedCallbackDelegate = (OnFinished);
                    FinishedSignal().Connect(videoViewFinishedCallbackDelegate);
                }
                videoViewFinishedEventHandler += value;
            }
            remove
            {
                videoViewFinishedEventHandler -= value;
                if (videoViewFinishedEventHandler == null && FinishedSignal().Empty() == false)
                {
                    FinishedSignal().Disconnect(videoViewFinishedCallbackDelegate);
                }
            }
        }

        /// <summary>
        /// Video file setting type of PropertyMap.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap Video
        {
            get
            {
                return (PropertyMap)GetValue(VideoProperty);
            }
            set
            {
                SetValue(VideoProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The looping status, true or false.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool Looping
        {
            get
            {
                return (bool)GetValue(LoopingProperty);
            }
            set
            {
                SetValue(LoopingProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The mute status, true or false.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool Muted
        {
            get
            {
                return (bool)GetValue(MutedProperty);
            }
            set
            {
                SetValue(MutedProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The left and the right volume scalar as float type, PropertyMap with two values ( "left" and "right" ).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap Volume
        {
            get
            {
                return (PropertyMap)GetValue(VolumeProperty);
            }
            set
            {
                SetValue(VolumeProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Video rendering by underlay, true or false.<br />
        /// This shows video composited underneath the window by the system. This means it may ignore rotation of the video-view.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public bool Underlay
        {
            get
            {
                return (bool)GetValue(UnderlayProperty);
            }
            set
            {
                SetValue(UnderlayProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Video file URL as string type.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public string ResourceUrl
        {
            get
            {
                return (string)GetValue(ResourceUrlProperty);
            }
            set
            {
                SetValue(ResourceUrlProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Starts the video playback.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Play()
        {
            Interop.VideoView.Play(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Pauses the video playback.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Pause()
        {
            Interop.VideoView.Pause(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Stops the video playback.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Stop()
        {
            Interop.VideoView.Stop(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Seeks forward by the specified number of milliseconds.
        /// </summary>
        /// <param name="millisecond">The position for forward playback.</param>
        /// <since_tizen> 3 </since_tizen>
        public void Forward(int millisecond)
        {
            Interop.VideoView.Forward(SwigCPtr, millisecond);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Seeks backward by the specified number of milliseconds.
        /// </summary>
        /// <param name="millisecond">The position for backward playback.</param>
        /// <since_tizen> 3 </since_tizen>
        public void Backward(int millisecond)
        {
            Interop.VideoView.Backward(SwigCPtr, millisecond);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal VideoViewSignal FinishedSignal()
        {
            VideoViewSignal ret = new VideoViewSignal(Interop.VideoView.FinishedSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(VideoView obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        /// <param name="type">DisposeTypes</param>
        /// <since_tizen> 3 </since_tizen>
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.

            if (this != null && videoViewFinishedCallbackDelegate != null)
            {
                FinishedSignal().Disconnect(videoViewFinishedCallbackDelegate);
            }

            base.Dispose(type);
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.VideoView.DeleteVideoView(swigCPtr);
        }

        // Callback for VideoView Finished signal
        private void OnFinished(IntPtr data)
        {
            if (videoViewFinishedEventHandler != null)
            {
                FinishedEventArgs e = new FinishedEventArgs();

                // Populate all members of "e" (FinishedEventArgs) with real data
                e.VideoView = Registry.GetManagedBaseHandleFromNativePtr(data) as VideoView;
                //here we send all data to user event handlers
                videoViewFinishedEventHandler(this, e);
            }
        }

        /// <summary>
        /// Event arguments that passed via the finished signal.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public class FinishedEventArgs : EventArgs
        {
            private VideoView videoView;

            /// <summary>
            /// The view for video playback and display.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public VideoView VideoView
            {
                get
                {
                    return videoView;
                }
                set
                {
                    videoView = value;
                }
            }
        }

        internal new class Property
        {
            internal static readonly int VIDEO = Interop.VideoView.VideoGet();
            internal static readonly int LOOPING = Interop.VideoView.LoopingGet();
            internal static readonly int MUTED = Interop.VideoView.MutedGet();
            internal static readonly int VOLUME = Interop.VideoView.VolumeGet();
            internal static readonly int UNDERLAY = Interop.VideoView.UnderlayGet();
        }

        internal System.IntPtr GetNativePlayerHandle()
        {
            var ret = Interop.VideoView.GetNativePlayerHandle(SwigCPtr);
            NUILog.Debug($"NativePlayerHandle=0x{ret:X}");
            return ret;
        }
    }

    /// <summary>
    /// Contains and encapsulates Native Player handle.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class SafeNativePlayerHandle : SafeHandle
    {
        /// <summary>
        /// Constructor, null handle is set.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SafeNativePlayerHandle() : base(global::System.IntPtr.Zero, false)
        {
        }

        /// <summary>
        /// Constructor, Native player handle is set to handle.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SafeNativePlayerHandle(VideoView videoView) : base(global::System.IntPtr.Zero, false)
        {
            if (videoView != null)
            {
                SetHandle(videoView.GetNativePlayerHandle());
            }
        }

        /// <summary>
        /// Null check if the handle is valid or not.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool IsInvalid
        {
            get
            {
                return handle == global::System.IntPtr.Zero;
            }
        }
        /// <summary>
        /// Release handle itself.
        /// </summary>
        /// <returns>true when released successfully.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override bool ReleaseHandle()
        {
            SetHandle(global::System.IntPtr.Zero);
            return true;
        }
    }
}
