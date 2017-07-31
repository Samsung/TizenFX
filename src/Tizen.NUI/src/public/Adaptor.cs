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
using System;
using System.Runtime.InteropServices;

namespace Tizen.NUI
{
    /// <summary>
    /// An Adaptor object is used to initialize and control how Dali runs.
    ///
    /// It provides a lifecycle interface that allows the application
    /// writer to provide their own main loop and other platform related
    /// features.
    ///
    /// The Adaptor class provides a means for initialising the resources required by the Dali::Core.
    ///
    /// When dealing with platform events, the application writer MUST ensure that Dali is called in a
    /// thread-safe manner.
    ///
    /// As soon as the Adaptor class is created and started, the application writer can initialise their
    /// View objects straight away or as required by the main loop they intend to use (there is no
    /// need to wait for an initialise signal as per the Tizen.NUI.Application class).
    ///
    /// </summary>
    public class Adaptor : global::System.IDisposable
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;
        protected bool swigCMemOwn;

        internal Adaptor(global::System.IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Adaptor obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        //A Flag to check who called Dispose(). (By User or DisposeQueue)
        private bool isDisposeQueued = false;
        //A Flat to check if it is already disposed.
        protected bool disposed = false;

        ~Adaptor()
        {
            if (!isDisposeQueued)
            {
                isDisposeQueued = true;
                DisposeQueue.Instance.Add(this);
            }
        }

        public void Dispose()
        {
            //Throw excpetion if Dispose() is called in separate thread.
            if (!Window.IsInstalled())
            {
                throw new System.InvalidOperationException("This API called from separate thread. This API must be called from MainThread.");
            }

            if (isDisposeQueued)
            {
                Dispose(DisposeTypes.Implicit);
            }
            else
            {
                Dispose(DisposeTypes.Explicit);
                System.GC.SuppressFinalize(this);
            }
        }

        protected virtual void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.

            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.

            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                swigCMemOwn = false;
                NDalicManualPINVOKE.delete_Adaptor(swigCPtr);
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            disposed = true;
        }

        internal static Adaptor GetAdaptorFromPtr(global::System.IntPtr cPtr)
        {
            Adaptor ret = new Adaptor(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static Adaptor New(Window window)
        {
            Adaptor ret = new Adaptor(NDalicManualPINVOKE.Adaptor_New__SWIG_0(Window.getCPtr(window)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static Adaptor New(Window window, SWIGTYPE_p_Configuration__ContextLoss configuration)
        {
            Adaptor ret = new Adaptor(NDalicManualPINVOKE.Adaptor_New__SWIG_1(Window.getCPtr(window), SWIGTYPE_p_Configuration__ContextLoss.getCPtr(configuration)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static Adaptor New(Any nativeWindow, SWIGTYPE_p_Dali__RenderSurface surface)
        {
            Adaptor ret = new Adaptor(NDalicManualPINVOKE.Adaptor_New__SWIG_2(Any.getCPtr(nativeWindow), SWIGTYPE_p_Dali__RenderSurface.getCPtr(surface)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static Adaptor New(Any nativeWindow, SWIGTYPE_p_Dali__RenderSurface surface, SWIGTYPE_p_Configuration__ContextLoss configuration)
        {
            Adaptor ret = new Adaptor(NDalicManualPINVOKE.Adaptor_New__SWIG_3(Any.getCPtr(nativeWindow), SWIGTYPE_p_Dali__RenderSurface.getCPtr(surface), SWIGTYPE_p_Configuration__ContextLoss.getCPtr(configuration)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Starts the Adaptor.
        /// </summary>
        internal void Start()
        {
            NDalicManualPINVOKE.Adaptor_Start(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Pauses the Adaptor.
        /// </summary>
        internal void Pause()
        {
            NDalicManualPINVOKE.Adaptor_Pause(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Resumes the Adaptor, if previously paused.
        /// </summary>
        /// <remarks>If the adaptor is not paused, this does not do anything.</remarks>
        internal void Resume()
        {
            NDalicManualPINVOKE.Adaptor_Resume(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Stops the Adaptor.
        /// </summary>
        internal void Stop()
        {
            NDalicManualPINVOKE.Adaptor_Stop(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal bool AddIdle(SWIGTYPE_p_Dali__CallbackBase callback)
        {
            bool ret = NDalicManualPINVOKE.Adaptor_AddIdle(swigCPtr, SWIGTYPE_p_Dali__CallbackBase.getCPtr(callback));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void RemoveIdle(SWIGTYPE_p_Dali__CallbackBase callback)
        {
            NDalicManualPINVOKE.Adaptor_RemoveIdle(swigCPtr, SWIGTYPE_p_Dali__CallbackBase.getCPtr(callback));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void ReplaceSurface(Any nativeWindow, SWIGTYPE_p_Dali__RenderSurface surface)
        {
            NDalicManualPINVOKE.Adaptor_ReplaceSurface(swigCPtr, Any.getCPtr(nativeWindow), SWIGTYPE_p_Dali__RenderSurface.getCPtr(surface));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal SWIGTYPE_p_Dali__RenderSurface GetSurface()
        {
            SWIGTYPE_p_Dali__RenderSurface ret = new SWIGTYPE_p_Dali__RenderSurface(NDalicManualPINVOKE.Adaptor_GetSurface(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal Any GetNativeWindowHandle()
        {
            Any ret = new Any(NDalicManualPINVOKE.Adaptor_GetNativeWindowHandle(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Release any locks the surface may hold.
        /// </summary>
        /// <remarks>
        /// For example, after compositing an offscreen surface, use this method to allow rendering to continue.
        /// </remarks>
        internal void ReleaseSurfaceLock()
        {
            NDalicManualPINVOKE.Adaptor_ReleaseSurfaceLock(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Set the number of frames per render.
        /// </summary>
        /// <param name="numberOfVSyncsPerRender">The number of vsyncs between successive renders.. </param>
        /// <remarks>
        /// Suggest this is a power of two:
        /// 1 - render each vsync frame
        /// 2 - render every other vsync frame
        /// 4 - render every fourth vsync frame
        /// 8 - render every eighth vsync frame
        ///</remarks>
        internal void SetRenderRefreshRate(uint numberOfVSyncsPerRender)
        {
            NDalicManualPINVOKE.Adaptor_SetRenderRefreshRate(swigCPtr, numberOfVSyncsPerRender);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Set whether the frame count per render is managed using the hardware VSync or manually timed.
        /// </summary>
        /// <param name="useHardware">True if the hardware VSync should be used. </param>
        internal void SetUseHardwareVSync(bool useHardware)
        {
            NDalicManualPINVOKE.Adaptor_SetUseHardwareVSync(swigCPtr, useHardware);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        private static readonly Adaptor instance = Adaptor.Get();

        internal static Adaptor Get()
        {
            Adaptor ret = new Adaptor(NDalicManualPINVOKE.Adaptor_Get(), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Returns a reference to the instance of the adaptor used by the current thread.
        /// </summary>
        /// <remarks>The adaptor has been initialised.This is only valid in the main thread.</remarks>
        public static Adaptor Instance
        {
            get
            {
                return instance;
            }
        }

        /// <summary>
        /// Checks whether the adaptor is available.
        /// </summary>
        /// <returns>true, if it is available, false otherwise.</returns>
        internal static bool IsAvailable()
        {
            bool ret = NDalicManualPINVOKE.Adaptor_IsAvailable();
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Call this method to notify Dali when scene is created and initialized.
        /// Notify Adaptor that the scene has been created.
        /// </summary>
        internal void NotifySceneCreated()
        {
            NDalicManualPINVOKE.Adaptor_NotifySceneCreated(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Call this method to notify Dali when the system language changes.
        ///
        /// Use this only when NOT using Dali::Application, As Application created using
        /// Application will automatically receive notification of language change.
        /// When Dali::Application is not used, the application developer should
        /// use app-core to receive language change notifications and should update Dali
        /// by calling this method.
        /// </summary>
        internal void NotifyLanguageChanged()
        {
            NDalicManualPINVOKE.Adaptor_NotifyLanguageChanged(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets minimum distance in pixels that the fingers must move towards/away from each other in order to trigger a pinch gesture.
        /// </summary>
        /// <param name="distance">The minimum pinch distance in pixels. </param>
        internal void SetMinimumPinchDistance(float distance)
        {
            NDalicManualPINVOKE.Adaptor_SetMinimumPinchDistance(swigCPtr, distance);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void FeedTouchPoint(TouchPoint point, int timeStamp)
        {
            NDalicManualPINVOKE.Adaptor_FeedTouchPoint(swigCPtr, TouchPoint.getCPtr(point), timeStamp);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Feed a wheel event to the adaptor.
        /// </summary>
        /// <param name="wheelEvent">wheel event. </param>
        public void FeedWheelEvent(Wheel wheelEvent)
        {
            NDalicManualPINVOKE.Adaptor_FeedWheelEvent(swigCPtr, Wheel.getCPtr(wheelEvent));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Feed a key event to the adaptor.
        /// </summary>
        /// <param name="keyEvent">The key event holding the key information. </param>
        public void FeedKeyEvent(Key keyEvent)
        {
            NDalicManualPINVOKE.Adaptor_FeedKeyEvent(swigCPtr, Key.getCPtr(keyEvent));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Notify Core that the scene has been created.
        /// </summary>
        internal void SceneCreated()
        {
            NDalicManualPINVOKE.Adaptor_SceneCreated(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetViewMode(ViewMode viewMode)
        {
            NDalicManualPINVOKE.Adaptor_SetViewMode(swigCPtr, (int)viewMode);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets the stereo base (eye separation) for Stereoscopic 3D.
        /// The stereo base is the distance in millimetres between the eyes. Typical values are
        /// between 50mm and 70mm. The default value is 65mm.
        /// </summary>
        /// <param name="stereoBase">The stereo base (eye separation) for Stereoscopic 3D.</param>
        internal void SetStereoBase(float stereoBase)
        {
            NDalicManualPINVOKE.Adaptor_SetStereoBase(swigCPtr, stereoBase);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Event arguments that passed via Resized signal.
        /// </summary>
        internal class ResizedEventArgs : EventArgs
        {

            /// <summary>
            /// Adaptor - is the adaptor which has size changed.
            /// </summary>
            public Adaptor Adaptor
            {
                get;
                set;
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void ResizedCallbackDelegate(IntPtr adaptor);
        private EventHandler<ResizedEventArgs> _resizedEventHandler;
        private ResizedCallbackDelegate _resizedCallbackDelegate;

        /// <summary>
        /// Event for Resized signal which can be used to subscribe/unsubscribe the event handler
        /// provided by the user. Resized signal is emitted when the size changes.<br>
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

        internal AdaptorSignalType ResizedSignal()
        {
            AdaptorSignalType ret = new AdaptorSignalType(NDalicManualPINVOKE.Adaptor_ResizedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Event arguments that passed via LanguageChanged signal.
        /// </summary>
        internal class LanguageChangedEventArgs : EventArgs
        {

            /// <summary>
            /// Adaptor - is the adaptor which has language changed.
            /// </summary>
            public Adaptor Adaptor
            {
                get;
                set;
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void LanguageChangedCallbackDelegate(IntPtr adaptor);
        private EventHandler<LanguageChangedEventArgs> _languageChangedEventHandler;
        private LanguageChangedCallbackDelegate _languageChangedCallbackDelegate;

        /// <summary>
        /// Event for LanguageChanged signal which can be used to subscribe/unsubscribe the event handler
        /// provided by the user. LanguageChanged signal is emitted when the language changes.<br>
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

        private void OnLanguageChanged(IntPtr adaptor)
        {
            LanguageChangedEventArgs e = new LanguageChangedEventArgs();
            if (adaptor != null)
            {
                e.Adaptor = Adaptor.GetAdaptorFromPtr(adaptor);
            }

            if (_languageChangedEventHandler != null)
            {
                //here we send all data to user event handlers
                _languageChangedEventHandler(this, e);
            }
        }

        internal AdaptorSignalType LanguageChangedSignal()
        {
            AdaptorSignalType ret = new AdaptorSignalType(NDalicManualPINVOKE.Adaptor_LanguageChangedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

    }

}
