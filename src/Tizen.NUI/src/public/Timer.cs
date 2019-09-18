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
using System.Threading;

namespace Tizen.NUI
{
    /// <summary>
    /// Mechanism to issue simple periodic or one-shot events.<br />
    /// Timer is provided for application developers to be able to issue
    /// simple periodic or one-shot events. Please note that the timer
    /// callback functions should return as soon as possible because they
    /// block the next SignalTick. Please note that timer signals are not
    /// in sync with DALi's render timer.<br />
    /// This class is a handle class so it can be stack allocated and used
    /// as a member.<br />
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class Timer : BaseHandle
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;
        private bool played = false;
        private EventHandlerWithReturnType<object, TickEventArgs, bool> _timerTickEventHandler;
        private TickCallbackDelegate _timerTickCallbackDelegate;

        private System.IntPtr _timerTickCallbackOfNative;

        /// <summary>
        /// Creates a tick timer that emits periodic signal.
        /// </summary>
        /// <param name="milliSec">Interval in milliseconds.</param>
        /// <returns>A new timer.</returns>
        /// <since_tizen> 3 </since_tizen>
        public Timer(uint milliSec) : this(Interop.Timer.Timer_New(milliSec), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            NUILog.Debug($"(0x{swigCPtr.Handle:X})  Timer({milliSec}) Constructor!");
        }
        internal Timer(Timer timer) : this(Interop.Timer.new_Timer__SWIG_1(Timer.getCPtr(timer)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Timer(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.Timer.Timer_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);

            _timerTickCallbackDelegate = OnTick;
            _timerTickCallbackOfNative = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate<System.Delegate>(_timerTickCallbackDelegate);

            NUILog.Debug($"(0x{swigCPtr.Handle:X})Timer() contructor!");
        }

        /// <summary>
        /// Destructor.
        /// </summary>
        ~Timer()
        {
            NUILog.Debug($"(0x{swigCPtr.Handle:X})Timer() distructor!, disposed={disposed}");
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool TickCallbackDelegate();

        /// <summary>
        /// @brief Event for the ticked signal, which can be used to subscribe or unsubscribe the event handler
        /// provided by the user. The ticked signal is emitted after specified time interval.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandlerWithReturnType<object, TickEventArgs, bool> Tick
        {
            add
            {
                if (_timerTickEventHandler == null && disposed == false)
                {
                    TickSignal().Connect(_timerTickCallbackOfNative);
                }
                _timerTickEventHandler += value;
            }
            remove
            {
                _timerTickEventHandler -= value;
                if (_timerTickEventHandler == null && TickSignal().Empty() == false)
                {
                    TickSignal().Disconnect(_timerTickCallbackOfNative);
                }
            }
        }

        /// <summary>
        /// Gets/Sets the interval of the timer.
        /// </summary>
        /// <remarks>For setter, this sets a new interval on the timer and starts the timer. <br />
        /// Cancels the previous timer.
        /// </remarks>
        /// <since_tizen> 4 </since_tizen>
        public uint Interval
        {
            get
            {
                return GetInterval();
            }
            set
            {
                SetInterval(value);
            }
        }

        /// <summary>
        /// Starts the timer.<br />
        /// In case a timer is already running, its time is reset and the timer is restarted.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Start()
        {
            played = true;
            Interop.Timer.Timer_Start(swigCPtr);

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Stops the timer.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Stop()
        {
            played = false;
            Interop.Timer.Timer_Stop(swigCPtr);

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Tells whether the timer is running.
        /// </summary>
        /// <returns>Whether the timer is started or not.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool IsRunning()
        {
            bool ret = Interop.Timer.Timer_IsRunning(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Timer obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        /// <summary>
        /// Sets a new interval on the timer and starts the timer.<br />
        /// Cancels the previous timer.<br />
        /// </summary>
        /// <param name="milliSec">MilliSec interval in milliseconds.</param>
        internal void SetInterval(uint milliSec)
        {
            NUILog.Debug($"(0x{swigCPtr.Handle:X})SetInterval({milliSec})");

            played = true;

            Interop.Timer.Timer_SetInterval(swigCPtr, milliSec);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal uint GetInterval()
        {
            uint ret = Interop.Timer.Timer_GetInterval(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal TimerSignalType TickSignal()
        {
            TimerSignalType ret = new TimerSignalType(Interop.Timer.Timer_TickSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected override void Dispose(DisposeTypes type)
        {
            NUILog.Debug($"(0x{swigCPtr.Handle:X}) Timer.Dispose(type={type}, disposed={disposed})");

            if (this != null && _timerTickCallbackDelegate != null)
            {
                TickSignal().Disconnect(_timerTickCallbackOfNative);
            }

            if (disposed)
            {
                return;
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.

            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;
                    Interop.Timer.delete_Timer(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            played = false;
            base.Dispose(type);
        }

        private bool OnTick()
        {
            TickEventArgs e = new TickEventArgs();

            if (played == false)
            {
                Tizen.Log.Fatal("NUI", $"(0x{swigCPtr.Handle:X}) OnTick() is called even played is false!");
                //throw new System.InvalidOperationException($"OnTick() excpetion!");
            }

            if (_timerTickEventHandler != null && played == true)
            {
                //here we send all data to user event handlers
                return _timerTickEventHandler(this, e);
            }
            return false;
        }

        /// <summary>
        /// Event arguments that passed via the tick event.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public class TickEventArgs : EventArgs
        {
        }
    }

}

