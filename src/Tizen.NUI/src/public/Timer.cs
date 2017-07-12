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

namespace Tizen.NUI
{

    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Mechanism to issue simple periodic or one-shot events.<br>
    /// Timer is provided for application developers to be able to issue
    /// simple periodic or one-shot events.  Please note that timer
    /// callback functions should return as soon as possible, because they
    /// block the next SignalTick.  Please note that timer signals are not
    /// in sync with Dali's render timer.<br>
    /// This class is a handle class so it can be stack allocated and used
    /// as a member.<br>
    /// </summary>
    public class Timer : BaseHandle
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal Timer(global::System.IntPtr cPtr, bool cMemoryOwn) : base(NDalicPINVOKE.Timer_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Timer obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        protected override void Dispose(DisposeTypes type)
        {
            if(disposed)
            {
                return;
            }

            if(type == DisposeTypes.Explicit)
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
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;

                    //Unreference this instance from Registry.
                    Registry.Unregister(this);

                    NDalicPINVOKE.delete_Timer(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }


        /// <summary>
        /// Event arguments that passed via Tick event.
        /// </summary>
        public class TickEventArgs : EventArgs
        {
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool TickCallbackDelegate(IntPtr data);
        private EventHandlerWithReturnType<object, TickEventArgs, bool> _timerTickEventHandler;
        private TickCallbackDelegate _timerTickCallbackDelegate;

        /// <summary>
        /// brief Event for Ticked signal which can be used to subscribe/unsubscribe the event handler
        /// (in the type of TickEventHandler-DaliEventHandlerWithReturnType<object,TickEventArgs,bool>).<br>
        /// provided by the user. Ticked signal is emitted after specified time interval.<br>
        /// </summary>
        public event EventHandlerWithReturnType<object, TickEventArgs, bool> Tick
        {
            add
            {
                if (_timerTickEventHandler == null)
                {
                    _timerTickCallbackDelegate = (OnTick);
                    TickSignal().Connect(_timerTickCallbackDelegate);
                }
                _timerTickEventHandler += value;
            }
            remove
            {
                _timerTickEventHandler -= value;
                if (_timerTickEventHandler == null && TickSignal().Empty() == false)
                {
                    TickSignal().Disconnect(_timerTickCallbackDelegate);
                }
            }
        }

        private bool OnTick(IntPtr data)
        {
            TickEventArgs e = new TickEventArgs();

            if (_timerTickEventHandler != null)
            {
                //here we send all data to user event handlers
                return _timerTickEventHandler(this, e);
            }
            return false;
        }

        /// <summary>
        /// Creates a tick Timer that emits periodic signal.
        /// </summary>
        /// <param name="milliSec">Interval in milliseconds</param>
        /// <returns>A new timer</returns>
        public Timer(uint milliSec) : this(NDalicPINVOKE.Timer_New(milliSec), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }
        internal Timer(Timer timer) : this(NDalicPINVOKE.new_Timer__SWIG_1(Timer.getCPtr(timer)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }


        [Obsolete("Please do not use! this will be deprecated")]
        public static Timer DownCast(BaseHandle handle)
        {
            Timer ret = new Timer(NDalicPINVOKE.Timer_DownCast(BaseHandle.getCPtr(handle)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Starts timer.<br>
        /// In case a Timer is already running, its time is reset and timer is restarted.<br>
        /// </summary>
        public void Start()
        {
            NDalicPINVOKE.Timer_Start(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Stops timer.
        /// </summary>
        public void Stop()
        {
            NDalicPINVOKE.Timer_Stop(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets a new interval on the timer and starts the timer.<br>
        /// Cancels the previous timer.<br>
        /// </summary>
        /// <param name="milliSec">milliSec Interval in milliseconds</param>
        internal void SetInterval(uint milliSec)
        {
            NDalicPINVOKE.Timer_SetInterval(swigCPtr, milliSec);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal uint GetInterval()
        {
            uint ret = NDalicPINVOKE.Timer_GetInterval(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Tells whether timer is running.
        /// </summary>
        /// <returns>Whether Timer is started or not</returns>
        public bool IsRunning()
        {
            bool ret = NDalicPINVOKE.Timer_IsRunning(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal TimerSignalType TickSignal()
        {
            TimerSignalType ret = new TimerSignalType(NDalicPINVOKE.Timer_TickSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

    }

}
