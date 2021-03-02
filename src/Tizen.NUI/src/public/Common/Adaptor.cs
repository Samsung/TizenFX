/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
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
    [Obsolete("Deprecated in API8, will be removed in API10. This is not used anymore, please do not use.")]
    public class Adaptor : Disposable
    {
        private static readonly Adaptor instance = Adaptor.Get();

        internal Adaptor(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// Returns a reference to the instance of the adaptor used by the current thread.
        /// </summary>
        /// <remarks>The adaptor has been initialized. This is only valid in the main thread.</remarks>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Deprecated in API8, will be removed in API10. This is not used anymore, please do not use.")]
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
        [Obsolete("Deprecated in API8, will be removed in API10. This is not used anymore, please do not use.")]
        public void FeedWheelEvent(Wheel wheelEvent)
        {
            Interop.Adaptor.FeedWheelEvent(SwigCPtr, Wheel.getCPtr(wheelEvent));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Feeds a key event to the adaptor.
        /// </summary>
        /// <param name="keyEvent">The key event holding the key information.</param>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Deprecated in API8, will be removed in API10. This is not used anymore, please do not use.")]
        public void FeedKeyEvent(Key keyEvent)
        {
            Interop.Adaptor.FeedKeyEvent(SwigCPtr, Key.getCPtr(keyEvent));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal static Adaptor Get()
        {
            Adaptor ret = new Adaptor(Interop.Adaptor.Get(), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
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
            Interop.Adaptor.SetRenderRefreshRate(SwigCPtr, numberOfVSyncsPerRender);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// ReleaseSwigCPtr
        /// </summary>
        /// <param name="swigCPtr"></param>
        [Obsolete("Deprecated in API8, will be removed in API10. This is not used anymore, please do not use.")]
        // This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Adaptor.DeleteAdaptor(swigCPtr);
        }
    }
}
