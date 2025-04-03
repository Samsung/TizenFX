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
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace Tizen.NUI
{
    /// <summary>
    /// The Text-to-speech (TTS) player.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class TTSPlayer : BaseHandle
    {
        private static readonly TTSPlayer[] instance = {TTSPlayer.GetInternal(TTSMode.Default), TTSPlayer.GetInternal(TTSMode.Notification), TTSPlayer.GetInternal(TTSMode.ScreenReader)};
        private StateChangedEventCallbackType stateChangedEventCallback;

        internal TTSPlayer(global::System.IntPtr cPtr, bool cMemoryOwn) : this(cPtr, cMemoryOwn, cMemoryOwn)
        {
        }

        internal TTSPlayer(global::System.IntPtr cPtr, bool cMemoryOwn, bool cRegister) : base(cPtr, cMemoryOwn, cRegister)
        {
        }

        internal TTSPlayer() : this(Interop.TtsPlayer.NewTtsPlayer(), true, false)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal TTSPlayer(TTSPlayer handle) : this(Interop.TtsPlayer.NewTtsPlayer(TTSPlayer.getCPtr(handle)), true, false)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void StateChangedEventCallbackType(TTSState prevState, TTSState nextState);
        private event EventHandler<StateChangedEventArgs> stateChangedEventHandler;

        /// <summary>
        /// The StateChanged event is triggered when the state of the TTS player changes.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<StateChangedEventArgs> StateChanged
        {
            add
            {
                if (stateChangedEventHandler == null)
                {
                    stateChangedEventCallback = OnStateChanged;
                    using var signal = StateChangedSignal();
                    signal.Connect(stateChangedEventCallback);
                }

                stateChangedEventHandler += value;
            }
            remove
            {
                stateChangedEventHandler -= value;
                using var signal = StateChangedSignal();
                if (stateChangedEventHandler == null && signal.Empty() == false && stateChangedEventCallback != null)
                {
                    signal.Disconnect(stateChangedEventCallback);
                }
            }
        }

        /// <summary>
        /// Enumeration for the instance of TTS mode.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public enum TTSMode
        {
            /// <summary>
            /// Default mode for normal application.
            /// </summary>
            Default = 0,
            /// <summary>
            /// Notification mode, such as playing utterance is started or completed.
            /// </summary>
            Notification,
            /// <summary>
            /// Screen reader mode. <br />
            /// To help visually impaired users interact with their devices,<br />
            /// screen reader reads text or graphic elements on the screen using the TTS engine.
            /// </summary>
            ScreenReader,
            /// <summary>
            /// Number of mode.
            /// </summary>
            ModeNum
        }

        /// <summary>
        /// Enumeration for the instance of TTS state.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public enum TTSState
        {
            /// <summary>
            /// Player is not available.
            /// </summary>
            Unavailable = 0,
            /// <summary>
            /// Player is ready to play.
            /// </summary>
            Ready,
            /// <summary>
            /// Player is playing.
            /// </summary>
            Playing,
            /// <summary>
            /// Player is paused.
            /// </summary>
            Paused
        }

        /// <summary>
        /// Gets the singleton of the TTSPlayer object.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public static TTSPlayer Instance
        {
            get
            {
                return instance[(int)TTSMode.Default];
            }
        }

        /// <summary>
        /// Gets the singleton of the TTS player for the given mode.
        /// </summary>
        /// <param name="mode"> The mode of TTS player.</param>
        /// <returns> A handle of the TTS player for the given mode.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static TTSPlayer Get(TTSMode mode)
        {
            return instance[(int)mode];
        }

        /// <summary>
        /// Gets the singleton of the TTS player for the default mode.
        /// </summary>
        /// <returns> A handle of the TTS player for the default mode.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static TTSPlayer Get()
        {
            return TTSPlayer.Instance;
        }

        private static TTSPlayer GetInternal(TTSMode mode)
        {
            global::System.IntPtr cPtr = Interop.TtsPlayer.Get((int) mode);

            if(cPtr == global::System.IntPtr.Zero)
            {
                NUILog.ErrorBacktrace("TTSPlayer.Instance called before Application created, or after Application terminated!");
            }

            TTSPlayer ret = Registry.GetManagedBaseHandleFromNativePtr(cPtr) as TTSPlayer;
            if (ret != null)
            {
                NUILog.ErrorBacktrace("TTSPlayer.GetInternal() Should be called only one time!");
                object dummyObect = new object();

                HandleRef CPtr = new HandleRef(dummyObect, cPtr);
                Interop.BaseHandle.DeleteBaseHandle(CPtr);
                CPtr = new HandleRef(null, global::System.IntPtr.Zero);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
            else
            {
                ret = new TTSPlayer(cPtr, true);
                return ret;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                NUILog.ErrorBacktrace("We should not manually dispose for singleton class!");
            }
            else
            {
                base.Dispose(disposing);
            }
        }

        /// <summary>
        /// Starts playing the audio data synthesized from the specified text.
        /// </summary>
        /// <param name="text"> The text to play.</param>
        /// <remarks>The TTS player needs to be initialized.</remarks>
        /// <since_tizen> 3 </since_tizen>
        public void Play(string text)
        {
            Interop.TtsPlayer.Play(SwigCPtr, text);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Stops playing the utterance.
        /// </summary>
        /// <remarks>The TTS player needs to be initialized.</remarks>
        /// <since_tizen> 3 </since_tizen>
        public void Stop()
        {
            Interop.TtsPlayer.Stop(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Pauses the currently playing utterance.
        /// </summary>
        /// <remarks>The TTS player needs to be initialized.</remarks>
        /// <since_tizen> 3 </since_tizen>
        public void Pause()
        {
            Interop.TtsPlayer.Pause(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Resumes the previously paused utterance.
        /// </summary>
        /// <remarks>The TTS player needs to be initialized.</remarks>
        /// <since_tizen> 3 </since_tizen>
        public void Resume()
        {
            Interop.TtsPlayer.Resume(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the current state of the player.
        /// </summary>
        /// <returns> The current TTS state. </returns>
        /// <remarks>The TTS player needs to be initialized.</remarks>
        /// <since_tizen> 3 </since_tizen>
        public TTSState GetState()
        {
            TTSState ret = (TTSState)Interop.TtsPlayer.GetState(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal StateChangedSignalType StateChangedSignal()
        {
            StateChangedSignalType ret = new StateChangedSignalType(Interop.TtsPlayer.StateChangedSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal TTSPlayer Assign(TTSPlayer rhs)
        {
            TTSPlayer ret = new TTSPlayer(Interop.TtsPlayer.Assign(SwigCPtr, TTSPlayer.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private void OnStateChanged(TTSState prevState, TTSState nextState)
        {
            if (stateChangedEventHandler != null)
            {
                StateChangedEventArgs e = new StateChangedEventArgs();

                e.PrevState = prevState;
                e.NextState = nextState;
                stateChangedEventHandler(this, e);
            }
        }

        /// <summary>
        /// This class represents the event arguments used when the state of the TTS player changes.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public class StateChangedEventArgs : EventArgs
        {
            /// <summary>
            /// The previous state of the TTS player before the change.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public TTSState PrevState
            {
                get;
                set;
            }

            /// <summary>
            /// The new state of the TTS player after the change.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public TTSState NextState
            {
                get;
                set;
            }
        }
    }
}
