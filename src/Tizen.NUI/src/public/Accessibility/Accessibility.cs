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

namespace Tizen.NUI.Accessibility
{
    /// <summary>
    /// Accessibility provides Dali-ATSPI interface which has functionality of Screen-Reader and general accessibility
    /// </summary>
    // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
    [SuppressMessage("Microsoft.Design", "CA1724: Type names should not match namespaces")]
    [SuppressMessage("Microsoft.Design", "CA1001:Types that own disposable fields should be disposable", Justification = "This is a singleton class and is not disposed")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class Accessibility
    {
        #region Constructor
        [SuppressMessage("Microsoft.Performance", "CA1810: Initialize reference type static fields inline", Justification = "Need to call native code")]
        static Accessibility()
        {
            enabledSignalHandler = () =>
            {
                Enabled?.Invoke(typeof(Accessibility), EventArgs.Empty);
            };

            disabledSignalHandler = () =>
            {
                Disabled?.Invoke(typeof(Accessibility), EventArgs.Empty);
            };

            Interop.Accessibility.RegisterEnabledDisabledSignalHandler(enabledSignalHandler, disabledSignalHandler);
        }
        #endregion Constructor

        #region Property
        /// <summary>
        /// Flag to check whether the state of Accessibility is enabled or not.
        /// </summary>
        /// <remarks>
        /// Getter returns true if Accessibility is enabled, false otherwise.
        /// </remarks>
        /// This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool IsEnabled
        {
            get
            {
                return (bool)Interop.Accessibility.IsEnabled();
            }
        }

        #endregion Property

        #region Method
        /// <summary>
        /// Start to speak
        /// </summary>
        /// <param name="sentence">Content to be spoken</param>
        /// <param name="discardable">true to be stopped and discarded when other Say is triggered</param>
        /// <returns></returns>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool Say(string sentence, bool discardable)
        {
            bool ret = Interop.Accessibility.Say(sentence, discardable, Marshal.GetFunctionPointerForDelegate<Delegate>(callback));

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// To make Say be paused or resumed
        /// </summary>
        /// <param name="pause">true to be paused, false to be resumed</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void PauseResume(bool pause)
        {
            Interop.Accessibility.PauseResume(pause);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Cancels anything screen-reader is reading / has queued to read
        /// </summary>
        /// <param name="alsoNonDiscardable">whether to cancel non-discardable readings as well</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void StopReading(bool alsoNonDiscardable)
        {
            Interop.Accessibility.StopReading(alsoNonDiscardable);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Suppress reading of screen-reader
        /// </summary>
        /// <param name="suppress">whether to suppress reading of screen-reader</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool SuppressScreenReader(bool suppress)
        {
            bool ret = Interop.Accessibility.SuppressScreenReader(suppress);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Re-enables auto-initialization of AT-SPI bridge
        /// </summary>
        /// <remarks>
        /// Normal applications do not have to call this function. The AT-SPI bridge is initialized on demand.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void BridgeEnableAutoInit()
        {
            Interop.Accessibility.BridgeEnableAutoInit();
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Blocks auto-initialization of AT-SPI bridge
        /// </summary>
        /// <remarks>
        /// Use this only if your application starts before DBus does, and call it early in Main().
        /// When DBus is ready, call BridgeEnableAutoInit().
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void BridgeDisableAutoInit()
        {
            Interop.Accessibility.BridgeDisableAutoInit();
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        ///  Get View that is used to highlight widget.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static View GetHighlightFrameView()
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
        public static void SetHighlightFrameView(View view)
        {
            Interop.ControlDevel.DaliAccessibilityAccessibleSetHighlightActor(View.getCPtr(view));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        ///  Get highligted View.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static View GetCurrentlyHighlightedView()
        {
            var ptr = Interop.ControlDevel.DaliAccessibilityAccessibleGetCurrentlyHighlightedActor();

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            return dummyHandle.GetInstanceSafely<View>(ptr);
        }

        /// <summary>
        ///  Clear highlight.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool ClearCurrentlyHighlightedView()
        {
            var view = GetCurrentlyHighlightedView();

            return view?.ClearAccessibilityHighlight() ?? false;
        }
        #endregion Method


        #region Event, Enum, Struct, ETC
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
        public static event EventHandler<SayFinishedEventArgs> SayFinished;

        /// <summary>
        /// Triggered whenever the value of IsEnabled would change from false to true
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static event EventHandler Enabled;

        /// <summary>
        /// Triggered whenever the value of IsEnabled would change from true to false
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static event EventHandler Disabled;

        #endregion Event, Enum, Struct, ETC

        #region Private

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void SayFinishedEventCallbackType(int result);

        private static SayFinishedEventCallbackType callback = SayFinishedEventCallback;

        private static Interop.Accessibility.EnabledDisabledSignalHandler enabledSignalHandler = null;

        private static Interop.Accessibility.EnabledDisabledSignalHandler disabledSignalHandler = null;

        private static void SayFinishedEventCallback(int result)
        {
            NUILog.Debug($"sayFinishedEventCallback(res={result}) called!");
            SayFinished?.Invoke(typeof(Accessibility), new SayFinishedEventArgs(result));
        }

        private static BaseHandle dummyHandle = new BaseHandle();

        #endregion Private
    }

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
        public Accessibility.SayFinishedState State
        {
            private set;
            get;
        }

        internal SayFinishedEventArgs(int result)
        {
            State = (Accessibility.SayFinishedState)(result);
            NUILog.Debug($"SayFinishedEventArgs Constructor! State={State}");
        }
    }
}
