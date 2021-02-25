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
        private static readonly TTSPlayer instance = TTSPlayer.Get();
        private StateChangedEventCallbackType stateChangedEventCallback;

        internal TTSPlayer(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.TtsPlayer.Upcast(cPtr), cMemoryOwn)
        {
        }

        internal TTSPlayer() : this(Interop.TtsPlayer.NewTtsPlayer(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal TTSPlayer(TTSPlayer handle) : this(Interop.TtsPlayer.NewTtsPlayer(TTSPlayer.getCPtr(handle)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void StateChangedEventCallbackType(TTSState prevState, TTSState nextState);
        private event EventHandler<StateChangedEventArgs> stateChangedEventHandler;

        /// <summary>
        /// State changed event.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<StateChangedEventArgs> StateChanged
        {
            add
            {
                if (stateChangedEventHandler == null)
                {
                    stateChangedEventCallback = OnStateChanged;
                    StateChangedSignal().Connect(stateChangedEventCallback);
                }

                stateChangedEventHandler += value;
            }
            remove
            {
                stateChangedEventHandler -= value;

                if (stateChangedEventHandler == null && StateChangedSignal().Empty() == false && stateChangedEventCallback != null)
                {
                    StateChangedSignal().Disconnect(stateChangedEventCallback);
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
                return instance;
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
            TTSPlayer ret = new TTSPlayer(Interop.TtsPlayer.Get((int)mode), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets the singleton of the TTS player for the default mode.
        /// </summary>
        /// <returns> A handle of the TTS player for the default mode.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static TTSPlayer Get()
        {
            TTSPlayer ret = new TTSPlayer(Interop.TtsPlayer.Get(), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
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

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(TTSPlayer obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
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
        /// State changed argument.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public class StateChangedEventArgs : EventArgs
        {
            /// <summary>
            /// PrevState.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public TTSState PrevState
            {
                get;
                set;
            }

            /// <summary>
            /// NextState.
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
