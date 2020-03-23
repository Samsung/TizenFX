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

using global::System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Tizen.NUI.BaseComponents;
#if (NUI_DEBUG_ON)
using tlog = Tizen.Log;
#endif

namespace Tizen.NUI.Accessibility
{
    /// <summary>
    /// Accessibility provides Dali-ATSPI interface which has funtionality of Screen-Reader and general accessibility
    /// </summary>
    // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Accessibility
    {
        #region Constructor, Distructor, Dispose
        private Accessibility()
        {
            dummy = new View();
            dummy.Name = "dali-atspi-singleton";
        }
        /// <summary>
        /// destructor. This is HiddenAPI. recommended not to use in public.
        /// </summary>
        ~Accessibility()
        {
        }
        #endregion Constructor, Distructor, Dispose


        #region Property
        /// <summary>
        /// Instance for singleton
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Accessibility Instance
        {
            get => _accessibility;
        }
        #endregion Property


        #region Method
        /// <summary>
        /// Get the current status
        /// </summary>
        /// <returns>Current enabled status</returns>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        static public bool GetStatus()
        {
            return true;
        }

        /// <summary>
        /// Start to speak
        /// </summary>
        /// <param name="sentence">Content to be spoken</param>
        /// <param name="discardable">true to be stopped and discarded when other Say is triggered</param>
        /// <returns></returns>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Say(string sentence, bool discardable)
        {
            IntPtr callbackIntPtr = IntPtr.Zero;
            if (_sayFinishedEventHandler != null)
            {
                callback = _sayFinishedEventCallback;
                callbackIntPtr = Marshal.GetFunctionPointerForDelegate<Delegate>(callback);
            }
            bool ret = Interop.Accessibility.accessibility_say(View.getCPtr(dummy), sentence, discardable, callbackIntPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// To make Say be paused or resumed
        /// </summary>
        /// <param name="pause">true to be paused, false to be resumed</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void PauseResume(bool pause)
        {
            Interop.Accessibility.accessibility_pause_resume(View.getCPtr(dummy), pause);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
        #endregion Method


        #region Event, Enum, Struct, ETC
        /// <summary>
        ///  Say Finished event arguments
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class SayFinishedEventArgs : EventArgs
        {
            /// <summary>
            /// The state of Say finished
            /// </summary>
            // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
            [EditorBrowsable(EditorBrowsableState.Never)]
            public SayFinishedStates State
            {
                private set;
                get;
            }

            internal SayFinishedEventArgs(int result)
            {
                State = (SayFinishedStates)(result);
                tlog.Fatal(tag, $"SayFinishedEventArgs Constructor! State={State}");
            }
        }

        /// <summary>
        /// Enum of Say finished event argument status
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum SayFinishedStates
        {
            /// <summary>
            /// Invalid
            /// </summary>
            // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
            [EditorBrowsable(EditorBrowsableState.Never)]
            Invalid = -1,
            /// <summary>
            /// Cancelled
            /// </summary>
            // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
            [EditorBrowsable(EditorBrowsableState.Never)]
            Cancelled = 1,
            /// <summary>
            /// Stopped
            /// </summary>
            // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
            [EditorBrowsable(EditorBrowsableState.Never)]
            Stopped = 2,
            /// <summary>
            /// Skipped
            /// </summary>
            // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
            [EditorBrowsable(EditorBrowsableState.Never)]
            Skipped = 3
        }

        /// <summary>
        /// When Say is finished, this event is triggered
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<SayFinishedEventArgs> SayFinished
        {
            add => _sayFinishedEventHandler += value;
            remove => _sayFinishedEventHandler -= value;
        }
        #endregion Event, Enum, Struct, ETC


        #region Internal
        internal void PauseResume(View target, bool pause)
        {
            Interop.Accessibility.accessibility_pause_resume(View.getCPtr(target), pause);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal bool Say(View target, string sentence, bool discardable)
        {
            IntPtr callbackIntPtr = IntPtr.Zero;
            if (_sayFinishedEventHandler != null)
            {
                callback = _sayFinishedEventCallback;
                callbackIntPtr = Marshal.GetFunctionPointerForDelegate<Delegate>(callback);
            }
            bool ret = Interop.Accessibility.accessibility_say(View.getCPtr(target), sentence, discardable, callbackIntPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
        #endregion Internal


        #region Private
        private static readonly Accessibility _accessibility = new Accessibility();

        private event EventHandler<SayFinishedEventArgs> _sayFinishedEventHandler;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void _sayFinishedEventCallbackType(int result);

        private _sayFinishedEventCallbackType callback = null;

        private void _sayFinishedEventCallback(int result)
        {
            tlog.Fatal(tag, $"_sayFinishedEventCallback(res={result}) called!");
            _sayFinishedEventHandler?.Invoke(this, new SayFinishedEventArgs(result));
        }

        private View dummy;

        private static string tag = "NUITEST";
        #endregion Private
    }
}
