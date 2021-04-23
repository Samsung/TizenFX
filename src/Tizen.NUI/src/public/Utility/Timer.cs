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
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Threading;
using System.Diagnostics;

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
        private bool played = false;
        private EventHandlerWithReturnType<object, TickEventArgs, bool> timerTickEventHandler;
        private TickCallbackDelegate timerTickCallbackDelegate;

        private System.IntPtr timerTickCallbackOfNative;

        /// <summary>
        /// Creates a tick timer that emits periodic signal.
        /// </summary>
        /// <param name="milliSec">Interval in milliseconds.</param>
        /// <returns>A new timer.</returns>
        /// <since_tizen> 3 </since_tizen>
        public Timer(uint milliSec) : this(Interop.Timer.New(milliSec), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            NUILog.Debug($"(0x{SwigCPtr.Handle:X})  Timer({milliSec}) Constructor!");
        }
        internal Timer(Timer timer) : this(Interop.Timer.NewTimer(Timer.getCPtr(timer)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Timer(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
            timerTickCallbackDelegate = OnTick;
            timerTickCallbackOfNative = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate<System.Delegate>(timerTickCallbackDelegate);

            NUILog.Debug($"(0x{SwigCPtr.Handle:X})Timer() constructor!");
        }

        /// <summary>
        /// Destructor.
        /// </summary>
        ~Timer()
        {
            Tizen.Log.Debug("NUI", $"(0x{SwigCPtr.Handle:X})Timer() destructor!, disposed={disposed}");
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
                if (timerTickEventHandler == null && disposed == false)
                {
                    TickSignal().Connect(timerTickCallbackOfNative);
                }
                timerTickEventHandler += value;
            }
            remove
            {
                timerTickEventHandler -= value;
                if (timerTickEventHandler == null && TickSignal().Empty() == false)
                {
                    TickSignal().Disconnect(timerTickCallbackOfNative);
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
            if (Thread.CurrentThread.ManagedThreadId != 1)
            {
                Tizen.Log.Error("NUI", "current threadID : " + Thread.CurrentThread.ManagedThreadId);

                StackTrace st = new StackTrace(true);
                for (int i = 0; i < st.FrameCount; i++)
                {
                    StackFrame sf = st.GetFrame(i);
                    Tizen.Log.Error("NUI", " Method " + sf.GetMethod());
                }
            }

            if (SwigCPtr.Handle == global::System.IntPtr.Zero || disposed)
            {
                NUILog.Error("[ERR] already disposed! can not get this done! just return here! please make sure that the handle gets free when using explicit Dispose()! For example, timer.Dispose(); timer = null; this must be done!");
                return;
            }

            played = true;
            Interop.Timer.Start(SwigCPtr);

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Stops the timer.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Stop()
        {
            if (Thread.CurrentThread.ManagedThreadId != 1)
            {
                Tizen.Log.Error("NUI", "current threadID : " + Thread.CurrentThread.ManagedThreadId);

                StackTrace st = new StackTrace(true);
                for (int i = 0; i < st.FrameCount; i++)
                {
                    StackFrame sf = st.GetFrame(i);
                    Tizen.Log.Error("NUI", " Method " + sf.GetMethod());
                }
            }

            if (SwigCPtr.Handle == global::System.IntPtr.Zero || disposed)
            {
                NUILog.Error("[ERR] already disposed! can not get this done! just return here! please make sure that the handle gets free when using explicit Dispose()! For example, timer.Dispose(); timer = null; this must be done!");
                return;
            }

            played = false;
            Interop.Timer.Stop(SwigCPtr);

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Tells whether the timer is running.
        /// </summary>
        /// <returns>Whether the timer is started or not.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool IsRunning()
        {
            if (Thread.CurrentThread.ManagedThreadId != 1)
            {
                Tizen.Log.Error("NUI", "current threadID : " + Thread.CurrentThread.ManagedThreadId);

                StackTrace st = new StackTrace(true);
                for (int i = 0; i < st.FrameCount; i++)
                {
                    StackFrame sf = st.GetFrame(i);
                    Tizen.Log.Error("NUI", " Method " + sf.GetMethod());
                }
            }

            if (SwigCPtr.Handle == global::System.IntPtr.Zero || disposed)
            {
                NUILog.Error("[ERR] already disposed! can not get this done! just return here! please make sure that the handle gets free when using explicit Dispose()! For example, timer.Dispose(); timer = null; this must be done!");
                return false;
            }

            bool ret = Interop.Timer.IsRunning(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Timer obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        /// <summary>
        /// Sets a new interval on the timer and starts the timer.<br />
        /// Cancels the previous timer.<br />
        /// </summary>
        /// <param name="milliSec">MilliSec interval in milliseconds.</param>
        internal void SetInterval(uint milliSec)
        {
            NUILog.Debug($"(0x{SwigCPtr.Handle:X})SetInterval({milliSec})");

            if (SwigCPtr.Handle == global::System.IntPtr.Zero || disposed)
            {
                NUILog.Error("[ERR] already disposed! can not get this done! just return here! please make sure that the handle gets free when using explicit Dispose()! For example, timer.Dispose(); timer = null; this must be done!");
                return;
            }

            played = true;

            Interop.Timer.SetInterval(SwigCPtr, milliSec);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal uint GetInterval()
        {
            if (SwigCPtr.Handle == global::System.IntPtr.Zero || disposed)
            {
                NUILog.Error("[ERR] already disposed! can not get this done! just return here! please make sure that the handle gets free when using explicit Dispose()! For example, timer.Dispose(); timer = null; this must be done!");
                return 0;
            }

            uint ret = Interop.Timer.GetInterval(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal TimerSignalType TickSignal()
        {
            TimerSignalType ret = new TimerSignalType(Interop.Timer.TickSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected override void Dispose(DisposeTypes type)
        {
            NUILog.Debug($"(0x{SwigCPtr.Handle:X}) Timer.Dispose(type={type}, disposed={disposed})");

            if (this != null && timerTickCallbackDelegate != null)
            {
                TickSignal().Disconnect(timerTickCallbackOfNative);
            }

            if (disposed)
            {
                return;
            }

            played = false;
            base.Dispose(type);
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Timer.DeleteTimer(swigCPtr);
        }

        private bool OnTick()
        {
            TickEventArgs e = new TickEventArgs();

            if (played == false)
            {
                Tizen.Log.Fatal("NUI", $"(0x{SwigCPtr.Handle:X}) OnTick() is called even played is false!");
                //throw new System.InvalidOperationException($"OnTick() exception!");
            }

            if (timerTickEventHandler != null && played == true)
            {
                //here we send all data to user event handlers
                return timerTickEventHandler(this, e);
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
