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

using System;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace Tizen.NUI
{
    ///<summary>
    /// Issues a notification upon a condition of the property being met.
    /// See PropertyCondition for available defined conditions.
    ///</summary>
    /// <since_tizen> 4 </since_tizen>
    public class PropertyNotification : BaseHandle
    {

        private DaliEventHandler<object, NotifyEventArgs> propertyNotificationNotifyEventHandler;
        private NotifyEventCallbackDelegate propertyNotificationNotifyEventCallback;

        /// <summary>
        /// Create a instance of PropertyNotification.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public PropertyNotification() : this(Interop.PropertyNotification.NewPropertyNotification(), true, false)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Create a instance of PropertyNotification.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public PropertyNotification(PropertyNotification handle) : this(Interop.PropertyNotification.NewPropertyNotification(PropertyNotification.getCPtr(handle)), true, false)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal PropertyNotification(global::System.IntPtr cPtr, bool cMemoryOwn) : this(cPtr, cMemoryOwn, cMemoryOwn)
        {
        }

        internal PropertyNotification(global::System.IntPtr cPtr, bool cMemoryOwn, bool cRegister) : base(cPtr, cMemoryOwn, cRegister)
        {
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void NotifyEventCallbackDelegate(IntPtr propertyNotification);

        ///<summary>
        /// Event for Notified signal which can be used to subscribe/unsubscribe the event handler
        /// Notified signal is emitted when the notification upon a condition of the property being met, has occurred.
        ///</summary>
        /// <since_tizen> 4 </since_tizen>
        public event DaliEventHandler<object, NotifyEventArgs> Notified
        {
            add
            {
                if (propertyNotificationNotifyEventHandler == null)
                {
                    propertyNotificationNotifyEventCallback = OnPropertyNotificationNotify;
                    using PropertyNotifySignal signal = new PropertyNotifySignal(Interop.PropertyNotification.NotifySignal(SwigCPtr), false);
                    signal?.Connect(propertyNotificationNotifyEventCallback);
                }
                propertyNotificationNotifyEventHandler += value;
            }
            remove
            {
                propertyNotificationNotifyEventHandler -= value;
                if (propertyNotificationNotifyEventHandler == null)
                {
                    using PropertyNotifySignal signal = new PropertyNotifySignal(Interop.PropertyNotification.NotifySignal(SwigCPtr), false);
                    if (signal?.Empty() == false)
                    {
                        signal?.Disconnect(propertyNotificationNotifyEventCallback);
                        if (signal?.Empty() == true)
                        {
                            propertyNotificationNotifyEventCallback = null;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Enumeration for description of how to check condition.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public enum NotifyMode
        {
            /// <summary>
            /// Don't notify, regardless of result of Condition
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            Disabled,
            /// <summary>
            /// Notify whenever condition changes from false to true.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            NotifyOnTrue,
            /// <summary>
            /// Notify whenever condition changes from true to false.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            NotifyOnFalse,
            /// <summary>
            /// Notify whenever condition changes (false to true, and true to false)
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            NotifyOnChanged
        }

        /// <summary>
        /// Get property notification from Intptr.<br/>
        /// This should be internal, do not use.
        /// </summary>
        /// <param name="cPtr">An object of IntPtr type.</param>
        /// <returns>An object of the PropertyNotification type.</returns>
        internal static PropertyNotification GetPropertyNotificationFromPtr(global::System.IntPtr cPtr)
        {
            PropertyNotification ret = new PropertyNotification(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Downcast a PropertyNotification instance.
        /// </summary>
        /// <param name="handle">Handle to an object of BaseHandle type.</param>
        /// <returns>Handle to an object of the PropertyNotification type.</returns>
        /// <exception cref="ArgumentNullException"> Thrown when handle is null. </exception>
        /// <since_tizen> 4 </since_tizen>
        public static PropertyNotification DownCast(BaseHandle handle)
        {
            if (null == handle)
            {
                throw new ArgumentNullException(nameof(handle));
            }
            PropertyNotification ret = Registry.GetManagedBaseHandleFromNativePtr(handle) as PropertyNotification;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Assign.
        /// </summary>
        /// <param name="rhs">A reference to the copied handle.</param>
        /// <returns>A reference to this.</returns>
        internal PropertyNotification Assign(PropertyNotification rhs)
        {
            PropertyNotification ret = new PropertyNotification(Interop.PropertyNotification.Assign(SwigCPtr, PropertyNotification.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets the condition of this notification.
        /// </summary>
        /// <returns>The condition is returned.</returns>
        /// <since_tizen> 4 </since_tizen>
        public PropertyCondition GetCondition()
        {
            global::System.IntPtr cPtr = Interop.PropertyNotification.GetCondition(SwigCPtr);

            PropertyCondition ret = Registry.GetManagedBaseHandleFromNativePtr(cPtr) as PropertyCondition;
            if (ret != null)
            {
                global::System.Runtime.InteropServices.HandleRef CPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
                Interop.BaseHandle.DeleteBaseHandle(CPtr);
                CPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
            else
            {
                ret = new PropertyCondition(cPtr, true);
                return ret;
            }
        }

        /// <summary>
        /// Gets the target handle that this notification is observing.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public Animatable GetTarget()
        {
            //to fix memory leak issue, match the handle count with native side.
            Animatable ret = this.GetInstanceSafely<Animatable>(Interop.PropertyNotification.GetTarget(SwigCPtr));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets the target handle's property index that this notification.
        /// </summary>
        /// <returns>The target property index.</returns>
        /// <since_tizen> 4 </since_tizen>
        public int GetTargetProperty()
        {
            int ret = Interop.PropertyNotification.GetTargetProperty(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets the Notification mode.
        /// </summary>
        /// <param name="mode">mode Notification mode (Default is PropertyNotification::NotifyOnTrue).</param>
        /// <since_tizen> 4 </since_tizen>
        public void SetNotifyMode(PropertyNotification.NotifyMode mode)
        {
            Interop.PropertyNotification.SetNotifyMode(SwigCPtr, (int)mode);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Retrieves the current Notification mode.
        /// </summary>
        /// <returns>Notification mode.</returns>
        /// <since_tizen> 4 </since_tizen>
        public PropertyNotification.NotifyMode GetNotifyMode()
        {
            PropertyNotification.NotifyMode ret = (PropertyNotification.NotifyMode)Interop.PropertyNotification.GetNotifyMode(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets the result of the last condition check that caused a signal emit,
        /// useful when using NotifyOnChanged mode and need to know what it changed to.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public bool GetNotifyResult()
        {
            bool ret = Interop.PropertyNotification.GetNotifyResult(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// override it to clean-up your own resources.
        /// </summary>
        /// <param name="type"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.

            if (HasBody())
            {
                if (propertyNotificationNotifyEventCallback != null)
                {
                    using PropertyNotifySignal signal = new PropertyNotifySignal(Interop.PropertyNotification.NotifySignal(SwigCPtr), false);
                    signal?.Disconnect(propertyNotificationNotifyEventCallback);
                    propertyNotificationNotifyEventCallback = null;
                }
            }
            base.Dispose(type);
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.PropertyNotification.DeletePropertyNotification(swigCPtr);
        }

        // Callback for PropertyNotification NotifySignal
        private void OnPropertyNotificationNotify(IntPtr propertyNotification)
        {
            if (IsNativeHandleInvalid())
            {
                if (this.Disposed)
                {
                    if (propertyNotificationNotifyEventHandler != null)
                    {
                        var process = global::System.Diagnostics.Process.GetCurrentProcess();
                        var processId = process?.Id ?? -1;
                        var thread = global::System.Threading.Thread.CurrentThread.ManagedThreadId;
                        var me = this.GetType().FullName;

                        Tizen.Log.Error("NUI", $"Error! NUI's native dali object is already disposed. " +
                            $"OR the native dali object handle of NUI becomes null! \n" +
                            $" process:{processId} thread:{thread}, isDisposed:{this.Disposed}, isDisposeQueued:{this.IsDisposeQueued}, me:{me}\n");

                        process?.Dispose();
                    }
                }
                else
                {
                    if (this.IsDisposeQueued)
                    {
                        var process = global::System.Diagnostics.Process.GetCurrentProcess();
                        var processId = process?.Id ?? -1;
                        var thread = global::System.Threading.Thread.CurrentThread.ManagedThreadId;
                        var me = this.GetType().FullName;

                        //in this case, this object is ready to be disposed waiting on DisposeQueue, so event callback should not be invoked!
                        Tizen.Log.Error("NUI", "in this case, the View object is ready to be disposed waiting on DisposeQueue, so event callback should not be invoked! just return here! \n" +
                            $"process:{processId} thread:{thread}, isDisposed:{this.Disposed}, isDisposeQueued:{this.IsDisposeQueued}, me:{me}\n");

                        process?.Dispose();
                        return;
                    }
                }
            }

            if (propertyNotificationNotifyEventHandler != null)
            {
                NotifyEventArgs e = new NotifyEventArgs();
                e.PropertyNotification = GetPropertyNotificationFromPtr(propertyNotification);

                //here we send all data to user event handlers
                propertyNotificationNotifyEventHandler(this, e);
            }
        }

        ///<summary>
        /// Event arguments that passed via Notify signal
        ///</summary>
        /// <since_tizen> 3 </since_tizen>
        public class NotifyEventArgs : EventArgs
        {
            private PropertyNotification propertyNotification;

            ///<summary>
            /// PropertyNotification - is the PropertyNotification handle that has the notification properties.
            ///</summary>
            /// <since_tizen> 3 </since_tizen>
            public PropertyNotification PropertyNotification
            {
                get
                {
                    return propertyNotification;
                }
                set
                {
                    propertyNotification = value;
                }
            }
        }
    }
}
