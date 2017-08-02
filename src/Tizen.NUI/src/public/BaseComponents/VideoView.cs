/** Copyright (c) 2017 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI.BaseComponents
{

    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// VideoView is a control for video playback and display.
    /// </summary>
    public class VideoView : View
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal VideoView(global::System.IntPtr cPtr, bool cMemoryOwn) : base(NDalicPINVOKE.VideoView_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(VideoView obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        protected override void Dispose(DisposeTypes type)
        {
            if(disposed)
            {
                return;
            }

            if(type == DisposeTypes.Explicit)
            {
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.

            if (_videoViewFinishedCallbackDelegate != null)
            {
                FinishedSignal().Disconnect(_videoViewFinishedCallbackDelegate);
            }

            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;
                    NDalicPINVOKE.delete_VideoView(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }

        /// <summary>
        /// Event arguments that passed via Finished signal
        /// </summary>
        public class FinishedEventArgs : EventArgs
        {
            private VideoView _videoView;

            /// <summary>
            /// The view for video playback and display.
            /// </summary>
            public VideoView VideoView
            {
                get
                {
                    return _videoView;
                }
                set
                {
                    _videoView = value;
                }
            }
        }


        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void FinishedCallbackDelegate(IntPtr data);
        private EventHandler<FinishedEventArgs> _videoViewFinishedEventHandler;
        private FinishedCallbackDelegate _videoViewFinishedCallbackDelegate;


        /// <summary>
        /// Event for Finished signal which can be used to subscribe/unsubscribe the event handler
        /// (in the type of FinishedEventHandler-DaliEventHandler<object,FinishedEventArgs>) provided by the user.<br>
        /// Finished signal is emitted when a video playback have finished.<br>
        /// </summary>
        public event EventHandler<FinishedEventArgs> Finished
        {
            add
            {
                if (_videoViewFinishedEventHandler == null)
                {
                    _videoViewFinishedCallbackDelegate = (OnFinished);
                    FinishedSignal().Connect(_videoViewFinishedCallbackDelegate);
                }
                _videoViewFinishedEventHandler += value;
            }
            remove
            {
                _videoViewFinishedEventHandler -= value;
                if (_videoViewFinishedEventHandler == null && FinishedSignal().Empty() == false)
                {
                    FinishedSignal().Disconnect(_videoViewFinishedCallbackDelegate);
                }
            }
        }

        // Callback for VideoView Finished signal
        private void OnFinished(IntPtr data)
        {
            FinishedEventArgs e = new FinishedEventArgs();

            // Populate all members of "e" (FinishedEventArgs) with real data
            e.VideoView = Registry.GetManagedBaseHandleFromNativePtr(data) as VideoView;

            if (_videoViewFinishedEventHandler != null)
            {
                //here we send all data to user event handlers
                _videoViewFinishedEventHandler(this, e);
            }
        }

        internal class Property
        {
            internal static readonly int VIDEO = NDalicPINVOKE.VideoView_Property_VIDEO_get();
            internal static readonly int LOOPING = NDalicPINVOKE.VideoView_Property_LOOPING_get();
            internal static readonly int MUTED = NDalicPINVOKE.VideoView_Property_MUTED_get();
            internal static readonly int VOLUME = NDalicPINVOKE.VideoView_Property_VOLUME_get();
        }

        /// <summary>
        /// Creates an initialized VideoView.
        /// </summary>
        public VideoView() : this(NDalicPINVOKE.VideoView_New__SWIG_0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }

        /// <summary>
        /// Creates an initialized VideoView.<br>
        /// If the string is empty, VideoView will not display anything.<br>
        /// </summary>
        /// <param name="url">The url of the video resource to display</param>
        public VideoView(string url) : this(NDalicPINVOKE.VideoView_New__SWIG_1(url), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }
        internal VideoView(VideoView videoView) : this(NDalicPINVOKE.new_VideoView__SWIG_1(VideoView.getCPtr(videoView)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        [Obsolete("Please do not use! this will be deprecated")]
        public new static VideoView DownCast(BaseHandle handle)
        {
            VideoView ret =  Registry.GetManagedBaseHandleFromNativePtr(handle) as VideoView;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Starts the video playback.
        /// </summary>
        public void Play()
        {
            NDalicPINVOKE.VideoView_Play(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Pauses the video playback.
        /// </summary>
        public void Pause()
        {
            NDalicPINVOKE.VideoView_Pause(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Stops the video playback.
        /// </summary>
        public void Stop()
        {
            NDalicPINVOKE.VideoView_Stop(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Seeks forward by the specified number of milliseconds.
        /// </summary>
        /// <param name="millisecond">The position for forward playback</param>
        public void Forward(int millisecond)
        {
            NDalicPINVOKE.VideoView_Forward(swigCPtr, millisecond);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Seeks backward by the specified number of milliseconds.
        /// </summary>
        /// <param name="millisecond">The position for backward playback</param>
        public void Backward(int millisecond)
        {
            NDalicPINVOKE.VideoView_Backward(swigCPtr, millisecond);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal VideoViewSignal FinishedSignal()
        {
            VideoViewSignal ret = new VideoViewSignal(NDalicPINVOKE.VideoView_FinishedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// video file url as string type or PropertyMap.
        /// </summary>
        public PropertyMap Video
        {
            get
            {
                PropertyMap temp = new PropertyMap();
                GetProperty(VideoView.Property.VIDEO).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(VideoView.Property.VIDEO, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// looping status, true or false.
        /// </summary>
        public bool Looping
        {
            get
            {
                bool temp = false;
                GetProperty(VideoView.Property.LOOPING).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(VideoView.Property.LOOPING, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// mute status, true or false.
        /// </summary>
        public bool Muted
        {
            get
            {
                bool temp = false;
                GetProperty(VideoView.Property.MUTED).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(VideoView.Property.MUTED, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// left and right volume scalar as float type, PropertyMap with two values ( "left" and "right" ).
        /// </summary>
        public PropertyMap Volume
        {
            get
            {
                PropertyMap temp = new PropertyMap();
                GetProperty(VideoView.Property.VOLUME).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(VideoView.Property.VOLUME, new PropertyValue(value));
            }
        }

    }

}
