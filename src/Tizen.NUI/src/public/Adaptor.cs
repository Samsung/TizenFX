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
using System.Runtime.InteropServices;

namespace Tizen.NUI
{
    /// <summary>
    /// An Adaptor object is used to initialize and control how Dali runs.
    ///
    /// It provides the lifecycle interface that allows the application
    /// writer to provide their own main loop and other platform related
    /// features.
    ///
    /// The Adaptor class provides a means for initialising the resources required by the Dali::Core.
    ///
    /// When dealing with platform events, the application writer must ensure that DALi is called in a
    /// thread-safe manner.
    ///
    /// As soon as the Adaptor class is created and started, the application writer can initialise their
    /// view objects straight away or as required by the main loop they intend to use (there is no
    /// need to wait for an initialize signal as per the Tizen.NUI.Application class).
    ///
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class Adaptor : Disposable
    {
        /// <summary>swigCMemOwn.</summary>
        /// <since_tizen> 4 </since_tizen>
        protected bool swigCMemOwn;

        private static readonly Adaptor instance = Adaptor.Get();
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        private EventHandler<ResizedEventArgs> _resizedEventHandler;
        private ResizedCallbackDelegate _resizedCallbackDelegate;

        private EventHandler<LanguageChangedEventArgs> _languageChangedEventHandler;
        private LanguageChangedCallbackDelegate _languageChangedCallbackDelegate;

        internal Adaptor(global::System.IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void ResizedCallbackDelegate(IntPtr adaptor);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void LanguageChangedCallbackDelegate(IntPtr adaptor);

        /// <summary>
        /// An event for the Resized signal which can be used to subscribe or unsubscribe the event handler
        /// provided by the user. The Resized signal is emitted when the size changes.<br />
        /// </summary>
        internal event EventHandler<ResizedEventArgs> Resized
        {
            add
            {
                if (_resizedEventHandler == null)
                {
                    _resizedCallbackDelegate = (OnResized);
                    ResizedSignal().Connect(_resizedCallbackDelegate);
                }
                _resizedEventHandler += value;
            }
            remove
            {
                _resizedEventHandler -= value;
                if (_resizedEventHandler == null && ResizedSignal().Empty() == false)
                {
                    ResizedSignal().Disconnect(_resizedCallbackDelegate);
                }
            }
        }

        /// <summary>
        /// An event for LanguageChanged signal which can be used to subscribe or unsubscribe the event handler
        /// provided by the user. The LanguageChanged signal is emitted when the language changes.<br />
        /// </summary>
        internal event EventHandler<LanguageChangedEventArgs> LanguageChanged
        {
            add
            {
                if (_languageChangedEventHandler == null)
                {
                    _languageChangedCallbackDelegate = (OnLanguageChanged);
                    LanguageChangedSignal().Connect(_languageChangedCallbackDelegate);
                }
                _languageChangedEventHandler += value;
            }
            remove
            {
                _languageChangedEventHandler -= value;
                if (_languageChangedEventHandler == null && LanguageChangedSignal().Empty() == false)
                {
                    LanguageChangedSignal().Disconnect(_languageChangedCallbackDelegate);
                }
            }
        }

        /// <summary>
        /// Returns a reference to the instance of the adaptor used by the current thread.
        /// </summary>
        /// <remarks>The adaptor has been initialized. This is only valid in the main thread.</remarks>
        /// <since_tizen> 4 </since_tizen>
        public static Adaptor Instance
        {
            get
            {
                return instance;
            }
        }

        /// <summary>
        /// Feeds a wheel event to the adaptor.
        /// </summary>
        /// <param name="wheelEvent">The wheel event.</param>
        /// <since_tizen> 4 </since_tizen>
        public void FeedWheelEvent(Wheel wheelEvent)
        {
            Interop.Adaptor.Adaptor_FeedWheelEvent(swigCPtr, Wheel.getCPtr(wheelEvent));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Feeds a key event to the adaptor.
        /// </summary>
        /// <param name="keyEvent">The key event holding the key information.</param>
        /// <since_tizen> 4 </since_tizen>
        public void FeedKeyEvent(Key keyEvent)
        {
            Interop.Adaptor.Adaptor_FeedKeyEvent(swigCPtr, Key.getCPtr(keyEvent));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Adaptor obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        internal static Adaptor GetAdaptorFromPtr(global::System.IntPtr cPtr)
        {
            Adaptor ret = new Adaptor(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static Adaptor New(Window window)
        {
            Adaptor ret = new Adaptor(Interop.Adaptor.Adaptor_New__SWIG_0(Window.getCPtr(window)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static Adaptor New(Window window, SWIGTYPE_p_Configuration__ContextLoss configuration)
        {
            Adaptor ret = new Adaptor(Interop.Adaptor.Adaptor_New__SWIG_1(Window.getCPtr(window), SWIGTYPE_p_Configuration__ContextLoss.getCPtr(configuration)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static Adaptor New(Any nativeWindow, SWIGTYPE_p_Dali__RenderSurface surface)
        {
            Adaptor ret = new Adaptor(Interop.Adaptor.Adaptor_New__SWIG_2(Any.getCPtr(nativeWindow), SWIGTYPE_p_Dali__RenderSurface.getCPtr(surface)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static Adaptor New(Any nativeWindow, SWIGTYPE_p_Dali__RenderSurface surface, SWIGTYPE_p_Configuration__ContextLoss configuration)
        {
            Adaptor ret = new Adaptor(Interop.Adaptor.Adaptor_New__SWIG_3(Any.getCPtr(nativeWindow), SWIGTYPE_p_Dali__RenderSurface.getCPtr(surface), SWIGTYPE_p_Configuration__ContextLoss.getCPtr(configuration)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static Adaptor Get()
        {
            Adaptor ret = new Adaptor(Interop.Adaptor.Adaptor_Get(), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Checks whether the adaptor is available.
        /// </summary>
        /// <returns>True if it is available, false otherwise.</returns>
        internal static bool IsAvailable()
        {
            bool ret = Interop.Adaptor.Adaptor_IsAvailable();
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Starts the adaptor.
        /// </summary>
        internal void Start()
        {
            Interop.Adaptor.Adaptor_Start(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Pauses the adaptor.
        /// </summary>
        internal void Pause()
        {
            Interop.Adaptor.Adaptor_Pause(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Resumes the adaptor, if previously paused.
        /// </summary>
        /// <remarks>If the adaptor is not paused, this does not do anything.</remarks>
        internal void Resume()
        {
            Interop.Adaptor.Adaptor_Resume(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Stops the adaptor.
        /// </summary>
        internal void Stop()
        {
            Interop.Adaptor.Adaptor_Stop(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal bool AddIdle(SWIGTYPE_p_Dali__CallbackBase callback)
        {
            bool ret = Interop.Adaptor.Adaptor_AddIdle(swigCPtr, SWIGTYPE_p_Dali__CallbackBase.getCPtr(callback));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void RemoveIdle(SWIGTYPE_p_Dali__CallbackBase callback)
        {
            Interop.Adaptor.Adaptor_RemoveIdle(swigCPtr, SWIGTYPE_p_Dali__CallbackBase.getCPtr(callback));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void ReplaceSurface(Any nativeWindow, SWIGTYPE_p_Dali__RenderSurface surface)
        {
            Interop.Adaptor.Adaptor_ReplaceSurface(swigCPtr, Any.getCPtr(nativeWindow), SWIGTYPE_p_Dali__RenderSurface.getCPtr(surface));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal SWIGTYPE_p_Dali__RenderSurface GetSurface()
        {
            SWIGTYPE_p_Dali__RenderSurface ret = new SWIGTYPE_p_Dali__RenderSurface(Interop.Adaptor.Adaptor_GetSurface(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal Any GetNativeWindowHandle()
        {
            Any ret = new Any(Interop.Adaptor.Adaptor_GetNativeWindowHandle(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Releases any locks the surface may hold.
        /// </summary>
        /// <remarks>
        /// For example, after compositing an offscreen surface, use this method to allow rendering to continue.
        /// </remarks>
        internal void ReleaseSurfaceLock()
        {
            Interop.Adaptor.Adaptor_ReleaseSurfaceLock(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets the number of frames per render.
        /// </summary>
        /// <param name="numberOfVSyncsPerRender">The number of vsyncs between successive renders.</param>
        /// <remarks>
        /// Suggest this is a power of two:
        /// 1 - render each vsync frame.
        /// 2 - render every other vsync frame.
        /// 4 - render every fourth vsync frame.
        /// 8 - render every eighth vsync frame.
        ///</remarks>
        internal void SetRenderRefreshRate(uint numberOfVSyncsPerRender)
        {
            Interop.Adaptor.Adaptor_SetRenderRefreshRate(swigCPtr, numberOfVSyncsPerRender);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Calls this method to notify DALi when a scene is created and initialized.
        /// Notify the adaptor that the scene has been created.
        /// </summary>
        internal void NotifySceneCreated()
        {
            Interop.Adaptor.Adaptor_NotifySceneCreated(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Calls this method to notify DALi when the system language changes.
        ///
        /// Use this only when not using Dali::Application. As the application is created, using the
        /// application will automatically receive notification of the language change.
        /// When Dali::Application is not used, the application developer should
        /// use app-core to receive the language change notifications and should update DALi
        /// by calling this method.
        /// </summary>
        internal void NotifyLanguageChanged()
        {
            Interop.Adaptor.Adaptor_NotifyLanguageChanged(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void FeedTouchPoint(TouchPoint point, int timeStamp)
        {
            Interop.Adaptor.Adaptor_FeedTouchPoint(swigCPtr, TouchPoint.getCPtr(point), timeStamp);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Notifies core that the scene has been created.
        /// </summary>
        internal void SceneCreated()
        {
            Interop.Adaptor.Adaptor_SceneCreated(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal AdaptorSignalType ResizedSignal()
        {
            AdaptorSignalType ret = new AdaptorSignalType(Interop.Adaptor.Adaptor_ResizedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal AdaptorSignalType LanguageChangedSignal()
        {
            AdaptorSignalType ret = new AdaptorSignalType(Interop.Adaptor.Adaptor_LanguageChangedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.

            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                swigCMemOwn = false;
                Interop.Adaptor.delete_Adaptor(swigCPtr);
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }

        private void OnResized(IntPtr adaptor)
        {
            ResizedEventArgs e = new ResizedEventArgs();
            if (adaptor != null)
            {
                e.Adaptor = Adaptor.GetAdaptorFromPtr(adaptor);
            }

            if (_resizedEventHandler != null)
            {
                //here we send all data to user event handlers
                _resizedEventHandler(this, e);
            }
        }

        private void OnLanguageChanged(IntPtr adaptor)
        {
            LanguageChangedEventArgs e = new LanguageChangedEventArgs();
            e.Adaptor = Adaptor.GetAdaptorFromPtr(adaptor);

            if (_languageChangedEventHandler != null)
            {
                //here we send all data to user event handlers
                _languageChangedEventHandler(this, e);
            }
        }

        /// <summary>
        /// Event arguments that passed via the Resized signal.
        /// </summary>
        internal class ResizedEventArgs : EventArgs
        {

            /// <summary>
            /// Adaptor - is the adaptor which has size changed.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public Adaptor Adaptor
            {
                get;
                set;
            }
        }

        /// <summary>
        /// Event arguments that passed via the LanguageChanged signal.
        /// </summary>
        internal class LanguageChangedEventArgs : EventArgs
        {

            /// <summary>
            /// Adaptor - is the adaptor which has language changed.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public Adaptor Adaptor
            {
                get;
                set;
            }
        }

    }

}