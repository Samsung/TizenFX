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

namespace Tizen.NUI
{
    /// <summary>
    /// TransitionSet is used to control lifetime of multiple Transitions.
    /// For the one page transition, may multiple transitions are played coincidently.
    /// Every transitions added on a TransitionSet have same play lifetime. And emit a single Finished signal.
    /// </summary>
    internal class TransitionSet : BaseHandle
    {
        private TransitionSetFinishedEventCallbackType transitionSetFinishedEventCallback;
        private System.IntPtr finishedCallbackOfNative;

        /// <summary>
        /// Creates an initialized transitionSet.<br />
        /// </summary>
        /// <remarks>DurationmSeconds must be greater than zero.</remarks>
        public TransitionSet() : this(Interop.TransitionSet.New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal TransitionSet(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
            transitionSetFinishedEventCallback = OnFinished;
            finishedCallbackOfNative = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate<System.Delegate>(transitionSetFinishedEventCallback);
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void TransitionSetFinishedEventCallbackType(IntPtr data);

        private event EventHandler transitionSetFinishedEventHandler;

        /**
        * @brief Event for the finished signal which can be used to subscribe or unsubscribe the event handler.
        * The finished signal is emitted when an transitionSet's transitionSets have finished.
        */
        public event EventHandler Finished
        {
            add
            {
                if (transitionSetFinishedEventHandler == null && disposed == false)
                {
                    TransitionSetFinishedSignal finishedSignal = FinishedSignal();
                    finishedSignal.Connect(finishedCallbackOfNative);
                    finishedSignal.Dispose();
                }
                transitionSetFinishedEventHandler += value;
            }
            remove
            {
                transitionSetFinishedEventHandler -= value;

                TransitionSetFinishedSignal finishedSignal = FinishedSignal();
                if (transitionSetFinishedEventHandler == null && finishedSignal.Empty() == false)
                {
                    finishedSignal.Disconnect(finishedCallbackOfNative);
                }
                finishedSignal.Dispose();
            }
        }

        /// <summary>
        /// Downcasts a handle to transitionSet handle.<br />
        /// If handle points to an transitionSet object, the downcast produces a valid handle.<br />
        /// If not, the returned handle is left uninitialized.<br />
        /// </summary>
        /// <param name="handle">Handle to an object.</param>
        /// <returns>Handle to an transitionSet object or an uninitialized handle.</returns>
        /// <exception cref="ArgumentNullException"> Thrown when handle is null. </exception>
        internal static TransitionSet DownCast(BaseHandle handle)
        {
            if (handle == null)
            {
                throw new ArgumentNullException(nameof(handle));
            }
            TransitionSet ret = Registry.GetManagedBaseHandleFromNativePtr(handle) as TransitionSet;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void AddTransition(TransitionItemBase transition)
        {
            if (transition is TransitionGroupItem)
            {
                TransitionGroupItem transitionGroup = transition as TransitionGroupItem;
                for (int index = 0; index < transitionGroup.TransitionCount; ++index)
                {
                    this.AddTransition(transitionGroup.GetTransitionAt(index));
                }
            }
            else
            {
                Interop.TransitionSet.AddTransition(SwigCPtr, transition.SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public TransitionItemBase GetTransitionAt(uint index)
        {
            IntPtr cPtr = Interop.TransitionSet.GetTransitionAt(SwigCPtr, index);
            TransitionItemBase ret = Registry.GetManagedBaseHandleFromNativePtr(cPtr) as TransitionItemBase;
            if (ret != null)
            {
                Interop.BaseHandle.DeleteBaseHandle(new HandleRef(this, cPtr));
                NDalicPINVOKE.ThrowExceptionIfExists();
                return ret;
            }
            else
            {
                ret = new TransitionItemBase(cPtr, true);
                return ret;
            }
        }

        public uint GetTransitionCount()
        {
            uint ret = Interop.TransitionSet.GetTransitionCount(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Plays the transitionSet.
        /// </summary>
        public void Play()
        {
            Interop.TransitionSet.Play(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal TransitionSet(TransitionSet handle) : this(Interop.TransitionSet.NewTransitionSet(TransitionSet.getCPtr(handle)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal TransitionSet Assign(TransitionSet rhs)
        {
            TransitionSet ret = new TransitionSet(Interop.TransitionSet.Assign(SwigCPtr, TransitionSet.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal TransitionSetFinishedSignal FinishedSignal()
        {
            TransitionSetFinishedSignal ret = new TransitionSetFinishedSignal(Interop.TransitionSet.FinishedSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// To make transitionSet instance be disposed.
        /// </summary>
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (transitionSetFinishedEventHandler != null)
            {
                TransitionSetFinishedSignal finishedSignal = FinishedSignal();
                finishedSignal?.Disconnect(finishedCallbackOfNative);
                finishedSignal?.Dispose();
                transitionSetFinishedEventHandler = null;
            }

            base.Dispose(type);
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            if (swigCPtr.Handle == IntPtr.Zero || Disposed)
            {
                Tizen.Log.Fatal("NUI", $"[ERROR] TransitionSet ReleaseSwigCPtr()! IntPtr=0x{swigCPtr.Handle:X} Disposed={Disposed}");
                return;
            }
            Interop.TransitionSet.Delete(swigCPtr);
        }

        private void OnFinished(IntPtr data)
        {
            if (transitionSetFinishedEventHandler != null)
            {
                //here we send all data to user event handlers
                transitionSetFinishedEventHandler(this, null);
            }
        }
    }
}
