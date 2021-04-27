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
using System.Runtime.InteropServices;
using Tizen.NUI.BaseComponents;
using System.Diagnostics.CodeAnalysis;
#if (NUI_DEBUG_ON)
using tlog = Tizen.Log;
#endif

namespace Tizen.NUI.Accessibility
{
    /// <summary>
    /// Accessibility provides Dali-ATSPI interface which has functionality of Screen-Reader and general accessibility
    /// </summary>
    // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
    [SuppressMessage("Microsoft.Design", "CA1724: Type names should not match namespaces")]
    [SuppressMessage("Microsoft.Design", "CA1001:Types that own disposable fields should be disposable", Justification = "This is a singleton class and is not disposed")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Accessibility
    {
        #region Constructor, Destructor, Dispose
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
            Tizen.Log.Debug("NUI", $"Accessibility is destroyed\n");
        }
        #endregion Constructor, Destructor, Dispose


        #region Property
        /// <summary>
        /// Instance for singleton
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Accessibility Instance
        {
            get => accessibility;
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
            if (sayFinishedEventHandler != null)
            {
                callback = SayFinishedEventCallback;
                callbackIntPtr = Marshal.GetFunctionPointerForDelegate<Delegate>(callback);
            }
            bool ret = Interop.Accessibility.Say(View.getCPtr(dummy), sentence, discardable, callbackIntPtr);
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
            Interop.Accessibility.PauseResume(View.getCPtr(dummy), pause);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Cancels anything screen-reader is reading / has queued to read
        /// </summary>
        /// <param name="alsoNonDiscardable">whether to cancel non-discardable readings as well</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void StopReading(bool alsoNonDiscardable)
        {
            Interop.Accessibility.StopReading(View.getCPtr(dummy), alsoNonDiscardable);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        ///  Get View that is used to highlight widget.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public View GetHighlightFrameView()
        {
            var ptr = Interop.ControlDevel.DaliAccessibilityAccessibleGetHighlightActor();
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            if (ptr == IntPtr.Zero)
                return null;
            return new View(ptr, true);
        }

        /// <summary>
        ///  Set view that will be used to highlight widget.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetHighlightFrameView(View view)
        {
            Interop.ControlDevel.DaliAccessibilityAccessibleSetHighlightActor(View.getCPtr(view));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        ///  Get highligted View.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public View GetCurrentlyHighlightedView()
        {
            var ptr = Interop.ControlDevel.DaliAccessibilityAccessibleGetCurrentlyHighlightedActor();
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            if (ptr == IntPtr.Zero)
                return null;
            return new View(ptr, true);
        }

        /// <summary>
        ///  Clear highlight.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ClearCurrentlyHighlightedView()
        {
            using (View view = GetCurrentlyHighlightedView())
            {
                return view?.ClearAccessibilityHighlight() ?? false;
            }
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
            public SayFinishedState State
            {
                private set;
                get;
            }

            internal SayFinishedEventArgs(int result)
            {
                State = (SayFinishedState)(result);
                tlog.Fatal(tag, $"SayFinishedEventArgs Constructor! State={State}");
            }
        }

        /// <summary>
        /// Enum of Say finished event argument status
        /// </summary>
        [Obsolete("Please do not use! This will be removed. Please use Accessibility.SayFinishedState instead!")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum SayFinishedStates
        {
            /// <summary>
            /// Invalid
            /// </summary>
            [Obsolete("Please do not use! This will be removed. Please use Accessibility.SayFinishedState.Invalid instead!")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            Invalid = -1,
            /// <summary>
            /// Cancelled
            /// </summary>
            [Obsolete("Please do not use! This will be removed. Please use Accessibility.SayFinishedState.Invalid instead!")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            Cancelled = 1,
            /// <summary>
            /// Stopped
            /// </summary>
            [Obsolete("Please do not use! This will be removed. Please use Accessibility.SayFinishedState.Invalid instead!")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            Stopped = 2,
            /// <summary>
            /// Skipped
            /// </summary>
            [Obsolete("Please do not use! This will be removed. Please use Accessibility.SayFinishedState.Invalid instead!")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            Skipped = 3
        }

        /// <summary>
        /// Enum of Say finished event argument status
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum SayFinishedState
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
            Skipped = 3,
            /// <summary>
            /// Paused
            /// </summary>
            // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
            [EditorBrowsable(EditorBrowsableState.Never)]
            Paused = 4,
            /// <summary>
            /// Resumed
            /// </summary>
            // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
            [EditorBrowsable(EditorBrowsableState.Never)]
            Resumed = 5
        }

        /// <summary>
        /// When Say is finished, this event is triggered
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<SayFinishedEventArgs> SayFinished
        {
            add => sayFinishedEventHandler += value;
            remove => sayFinishedEventHandler -= value;
        }
        #endregion Event, Enum, Struct, ETC


        #region Internal
        internal void PauseResume(View target, bool pause)
        {
            Interop.Accessibility.PauseResume(View.getCPtr(target), pause);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal bool Say(View target, string sentence, bool discardable)
        {
            IntPtr callbackIntPtr = IntPtr.Zero;
            if (sayFinishedEventHandler != null)
            {
                callback = SayFinishedEventCallback;
                callbackIntPtr = Marshal.GetFunctionPointerForDelegate<Delegate>(callback);
            }
            bool ret = Interop.Accessibility.Say(View.getCPtr(target), sentence, discardable, callbackIntPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
        #endregion Internal


        #region Private
        private static readonly Accessibility accessibility = new Accessibility();

        private event EventHandler<SayFinishedEventArgs> sayFinishedEventHandler;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void SayFinishedEventCallbackType(int result);

        private SayFinishedEventCallbackType callback = null;

        private void SayFinishedEventCallback(int result)
        {
            tlog.Fatal(tag, $"sayFinishedEventCallback(res={result}) called!");
            sayFinishedEventHandler?.Invoke(this, new SayFinishedEventArgs(result));
        }

        private View dummy;

        private static string tag = "NUITEST";
        #endregion Private
    }
}
