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
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Accessibility
{
    /// <summary>
    /// Accessibility provides Dali-ATSPI interface which has functionality of Screen-Reader and general accessibility.
    /// </summary>
    // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
    [SuppressMessage("Microsoft.Design", "CA1724: Type names should not match namespaces")]
    [SuppressMessage("Microsoft.Design", "CA1001: Types that own disposable fields should be disposable", Justification = "This is a singleton class and is not disposed")]
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

            screenReaderEnabledSignalHandler = () =>
            {
                ScreenReaderEnabled?.Invoke(typeof(Accessibility), EventArgs.Empty);
            };

            screenReaderDisabledSignalHandler = () =>
            {
                ScreenReaderDisabled?.Invoke(typeof(Accessibility), EventArgs.Empty);
            };

            Interop.Accessibility.RegisterEnabledDisabledSignalHandler(enabledSignalHandler, disabledSignalHandler);
            Interop.Accessibility.RegisterScreenReaderEnabledDisabledSignalHandler(screenReaderEnabledSignalHandler, screenReaderDisabledSignalHandler);
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

        /// <summary>
        /// Flag to check whether the state of Screen Reader is enabled or not.
        /// </summary>
        /// <remarks>
        /// Getter returns true if Screen Reader is enabled, false otherwise.
        /// </remarks>
        /// This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool IsScreenReaderEnabled
        {
            get
            {
                return (bool)Interop.Accessibility.IsScreenReaderEnabled();
            }
        }

        #endregion Property

        #region Method

        /// <summary>
        /// Sets up the accessibility initialization signal handler.
        /// This method ensures that the accessibility request handler is registered only once.
        /// The handler is responsible for registering the accessibility delegate when an accessibility request is received.
        /// </summary>
        public static void SetupAccessibilityInitSignal()
        {
            if (accessibilityRequestHandler == null)
            {
                // Create a new handler for accessibility requests.
                // This handler will register the View's accessibility delegate, which is necessary
                // for Views to interact with the accessibility system.
                accessibilityRequestHandler = () =>
                {
                    View.RegisterAccessibilityDelegate();
                };

                // Register the handler with the native accessibility interop layer.
                // This connects the managed code handler to the underlying native accessibility events.
                Interop.Accessibility.RegisterAccessibilityRequestHandler(accessibilityRequestHandler);
            }
        }

        /// <summary>
        /// Start to speak.
        /// </summary>
        /// <param name="sentence">Content to be spoken.</param>
        /// <param name="discardable">true to be stopped and discarded when other Say is triggered.</param>
        /// <returns></returns>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void Say(string sentence, bool discardable)
        {
            Interop.Accessibility.Say(sentence, discardable, SayFinishedEventCallback);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// To make Say be paused or resumed.
        /// </summary>
        /// <param name="pause">true to be paused, false to be resumed.</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void PauseResume(bool pause)
        {
            Interop.Accessibility.PauseResume(pause);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Cancels anything screen-reader is reading / has queued to read.
        /// </summary>
        /// <param name="alsoNonDiscardable">whether to cancel non-discardable readings as well.</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void StopReading(bool alsoNonDiscardable)
        {
            Interop.Accessibility.StopReading(alsoNonDiscardable);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Suppress reading of screen-reader.
        /// </summary>
        /// <param name="suppress">whether to suppress reading of screen-reader.</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool SuppressScreenReader(bool suppress)
        {
            bool ret = Interop.Accessibility.SuppressScreenReader(suppress);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Re-enables auto-initialization of AT-SPI bridge.
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
        /// Blocks auto-initialization of AT-SPI bridge.
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
        /// Sets a custom highlight overlay at the specified position and size.
        /// This functionality is only applicable when the CustomHighlight Overlay is a child of the scene-view.
        /// In other words, the position and size of the highlight indicator can only be set if the CustomHighlight Overlay is part of the scene-view.
        /// </summary>
        /// <param name="view">The view to set the overlay</param>
        /// <param name="position">A Position2D representing the position of the overlay</param>
        /// <param name="size">A Size2D representing the size of the overlay</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void SetCustomHighlightOverlay(View view, Position2D position, Size2D size)
        {
            Interop.ControlDevel.SetCustomHighlightOverlay(View.getCPtr(view), Position2D.getCPtr(position), Position2D.getCPtr(size));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Resets the custom highlight overlay
        /// This functionality is only applicable when the CustomHighlight Overlay is a child of the scene-view.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void ResetCustomHighlightOverlay(View view)
        {
            Interop.ControlDevel.ResetCustomHighlightOverlay(View.getCPtr(view));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
        /// <summary>
        ///  Get highligted View.
        /// </summary>
        /// <returns>The currently highlighted view.</returns>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static View GetCurrentlyHighlightedView()
        {
            var ptr = Interop.ControlDevel.DaliAccessibilityAccessibleGetCurrentlyHighlightedActor();

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            return dummyObject.GetInstanceSafely<View>(ptr);
        }

        /// <summary>
        ///  Clear highlight.
        /// </summary>
        /// <returns>true if the highlight was cleared successfully, otherwise false.</returns>
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

        /// <summary>
        /// Triggered whenever the value of IsScreenReaderEnabled would change from false to true
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static event EventHandler ScreenReaderEnabled;

        /// <summary>
        /// Triggered whenever the value of IsScreenReaderEnabled would change from true to false
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static event EventHandler ScreenReaderDisabled;

        #endregion Event, Enum, Struct, ETC

        #region Private
        private static Interop.Accessibility.EnabledDisabledSignalHandler enabledSignalHandler;

        private static Interop.Accessibility.EnabledDisabledSignalHandler disabledSignalHandler;

        private static Interop.Accessibility.EnabledDisabledSignalHandler screenReaderEnabledSignalHandler;

        private static Interop.Accessibility.EnabledDisabledSignalHandler screenReaderDisabledSignalHandler;

        private static Interop.Accessibility.AccessibilityRequestHandler accessibilityRequestHandler;

        private static readonly IReadOnlyDictionary<string, SayFinishedState> sayFinishedStateDictionary = new Dictionary<string, SayFinishedState>
        {
            ["ReadingCancelled"] = SayFinishedState.Cancelled,
            ["ReadingStopped"] = SayFinishedState.Stopped,
            ["ReadingSkipped"] = SayFinishedState.Skipped,
            ["ReadingPaused"] = SayFinishedState.Paused,
            ["ReadingResumed"] = SayFinishedState.Resumed,
        };

        private static void SayFinishedEventCallback(string status)
        {
            SayFinishedState result;
            if (!sayFinishedStateDictionary.TryGetValue(status, out result))
            {
                result = SayFinishedState.Invalid;
            }
            NUILog.Debug($"sayFinishedEventCallback(res={result}) called!");

            SayFinished?.Invoke(typeof(Accessibility), new SayFinishedEventArgs(result));
        }

        private static readonly object dummyObject = new object();

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

        internal SayFinishedEventArgs(Accessibility.SayFinishedState state)
        {
            State = state;
            NUILog.Debug($"SayFinishedEventArgs Constructor! State={State}");
        }
    }
}
