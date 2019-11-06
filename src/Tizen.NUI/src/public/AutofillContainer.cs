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
    /// <summary>
    /// AutofillContainer controls several text input boxes.
    /// </summary>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class AutofillContainer : BaseHandle
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        private AuthenticationEventCallbackType _authenticationCallback;
        private ListEventCallbackType _listCallback;

        private event EventHandler<AuthenticationEventArgs> _authenticationEventHandler;
        private event EventHandler<ListEventArgs> _listEventHandler;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void AuthenticationEventCallbackType(IntPtr autofillContainer);
        private delegate void ListEventCallbackType(IntPtr control);

        /// <summary>
        /// AutofillContainer Authentication Service Event.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<AuthenticationEventArgs> ServiceEvent
        {
            add
            {
                if (_authenticationEventHandler == null)
                {
                    _authenticationCallback = OnServiceEvent;
                    AutofillServiceEventSignal().Connect(_authenticationCallback);
                }

                _authenticationEventHandler += value;
            }
            remove
            {
                _authenticationEventHandler -= value;

                if (_authenticationEventHandler == null && _authenticationCallback != null)
                {
                    AutofillServiceEventSignal().Disconnect(_authenticationCallback);
                }
            }
        }

        /// <summary>
        /// AutofillContainer Fill List Event.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<ListEventArgs> ListEvent
        {
            add
            {
                if (_listEventHandler == null)
                {
                    _listCallback = OnListEvent;
                    AutofillListEventSignal().Connect(_listCallback);
                }

                _listEventHandler += value;
            }
            remove
            {
                _listEventHandler -= value;

                if (_listEventHandler == null && _listCallback != null)
                {
                    AutofillListEventSignal().Disconnect(_listCallback);
                }
            }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name"> The AutofillContainer name</param>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AutofillContainer(string name) : this(Interop.AutofillContainer.AutofillContainer_New( name ), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }

        internal AutofillContainer(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.AutofillContainer.AutofillContainer_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }


        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(AutofillContainer obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        internal AutofillContainer(AutofillContainer autofillContainer) : this(Interop.AutofillContainer.new_AutofillContainer__SWIG_1(AutofillContainer.getCPtr(autofillContainer)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal AutofillContainer Assign(AutofillContainer autofillContainer)
        {
            AutofillContainer ret = new AutofillContainer(Interop.AutofillContainer.AutofillContainer_Assign(swigCPtr, AutofillContainer.getCPtr(autofillContainer)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static AutofillContainer DownCast(BaseHandle handle)
        {
            AutofillContainer ret = new AutofillContainer(Interop.AutofillContainer.AutofillContainer_DownCast(BaseHandle.getCPtr(handle)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Adds View and its Autofill item information to Autofill Container.
        /// </summary>
        /// <param name="view"> The view to be added to Autofill Container</param>
        /// <param name="propertyIndex">The Property to be filled automatically of each View</param>
        /// <param name="id"> A unique ID that does not always change on each launching</param>
        /// <param name="label"> An auxiliary means to guess heuristically what data is</param>
        /// <param name="hint"> The Hint - id (username), name, password, phone, credit card number, organization, and so on</param>
        /// <param name="isSensitive"> Whether this information is a sensitive data or not</param>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AddAutofillView(BaseComponents.View view, int propertyIndex, string id, string label, AutofillContainer.ItemHint hint, bool isSensitive)
        {
            Interop.AutofillContainer.AutofillContainer_AddAutofillView(swigCPtr, BaseComponents.View.getCPtr(view), propertyIndex, id, label, (uint)hint, isSensitive);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Removes View and its AutofillItem information to Autofill Container.
        /// </summary>
        /// <param name="view"> The view to be removed to Autofill Container</param>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RemoveAutofillItem(BaseComponents.View view)
        {
            Interop.AutofillContainer.AutofillContainer_RemoveAutofillItem(swigCPtr, BaseComponents.View.getCPtr(view));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Stores autofill data.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SaveAutofillData()
        {
            Interop.AutofillContainer.AutofillContainer_SaveAutofillData(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sends a request for filling the data.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RequestFillData()
        {
            Interop.AutofillContainer.AutofillContainer_RequestFillData(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the Autofill Service Name.
        /// </summary>
        /// <returns>Autofill Service Name</returns>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string GetAutofillServiceName()
        {
            string ret = Interop.AutofillContainer.AutofillContainer_GetAutofillServiceName(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets the Autofill Service Message.
        /// </summary>
        /// <returns>Autofill Service Message</returns>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string GetAutofillServiceMessage()
        {
            string ret = Interop.AutofillContainer.AutofillContainer_GetAutofillServiceMessage(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets the Autofill Service Image Path.
        /// </summary>
        /// <returns>Autofill Service Image Path</returns>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string GetAutofillServiceImagePath()
        {
            string ret = Interop.AutofillContainer.AutofillContainer_GetAutofillServiceImagePath(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets the number of list items. (The presentation text of Autofill)
        /// </summary>
        /// <returns>The number of list items</returns>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint GetListItemCount()
        {
            uint ret = Interop.AutofillContainer.AutofillContainer_GetListItemCount(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets the list item of the index.
        /// </summary>
        /// <param name="index">The index for the list</param>
        /// <returns>The list item of the index</returns>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string GetListItem(uint index)
        {
            string ret = Interop.AutofillContainer.AutofillContainer_GetListItem(swigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets the selected item to fill out.
        /// </summary>
        /// <param name="selected">The selected item</param>
        /// <since_tizen> 5 </since_tizen>
        public void SetSelectedItem(string selected)
        {
            Interop.AutofillContainer.AutofillContainer_SetSelectedItem(swigCPtr, selected);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal AuthenticationSignalType AutofillServiceEventSignal()
        {

            AuthenticationSignalType ret = new AuthenticationSignalType(Interop.AutofillContainer.AutofillContainer_AutofillServiceEventSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ListEventSignalType AutofillListEventSignal()
        {
            ListEventSignalType ret = new ListEventSignalType(Interop.AutofillContainer.AutofillContainer_AutofillListEventSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.

            if (this != null)
            {
                if (_authenticationCallback != null)
                {
                    AutofillServiceEventSignal().Disconnect(_authenticationCallback);
                }

                if (_listCallback != null)
                {
                    AutofillListEventSignal().Disconnect(_listCallback);
                }
            }

            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;
                    Interop.AutofillContainer.delete_AutofillContainer(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }

        private void OnServiceEvent(IntPtr autofillContainer)
        {
            AuthenticationEventArgs e = new AuthenticationEventArgs();
            e.AutofillContainer = Registry.GetManagedBaseHandleFromNativePtr(autofillContainer) as AutofillContainer;

            if (_authenticationEventHandler != null)
            {
                _authenticationEventHandler(this, e);
            }
        }

        private void OnListEvent(IntPtr control)
        {
            ListEventArgs e = new ListEventArgs();
            e.Control = Registry.GetManagedBaseHandleFromNativePtr(control) as BaseComponents.View;

            if (_listEventHandler != null)
            {
                _listEventHandler(this, e);
            }
        }

        /// <summary>
        /// Event arguments that passed via the Authentication event.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class AuthenticationEventArgs : EventArgs
        {
            /// <summary>
            /// The instance of AutofillContainer
            /// </summary>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public AutofillContainer AutofillContainer
            {
                get;
                set;
            }
        }

        /// <summary>
        /// AutofillContainer list event arguments.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class ListEventArgs : EventArgs
        {
            /// <summary>
            /// The instance of AutofillContainer
            /// </summary>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public BaseComponents.View Control
            {
                get;
                set;
            }

        }

        /// <summary>
        /// Enumeration for hint of the autofill item.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum ItemHint
        {
            /// <summary>
            /// Autofill hint for a credit card expiration date
            /// </summary>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            CreditCardExpirationData,
            /// <summary>
            /// Autofill hint for a credit card expiration day
            /// </summary>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            CreditCardExpirationDay,
            /// <summary>
            /// Autofill hint for a credit card expiration month
            /// </summary>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            CreditCardExpirationMonth,
            /// <summary>
            /// Autofill hint for a credit card expiration year
            /// </summary>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            CreditCardExpirationYear,
            /// <summary>
            /// Autofill hint for a credit card number
            /// </summary>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            CreditCardNumber,
            /// <summary>
            /// Autofill hint for an email address
            /// </summary>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            EmailAddress,
            /// <summary>
            /// Autofill hint for a user's real name
            /// </summary>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            Name,
            /// <summary>
            /// Autofill hint for a phone number
            /// </summary>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            Phone,
            /// <summary>
            /// Autofill hint for a postal address
            /// </summary>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            PostalAddress,
            /// <summary>
            /// Autofill hint for a postal code
            /// </summary>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            PostalCode,
            /// <summary>
            /// Autofill hint for a user's ID
            /// </summary>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            Id,
            /// <summary>
            /// Autofill hint for password
            /// </summary>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            Password,
            /// <summary>
            /// Autofill hint for a credit card security code
            /// </summary>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            CreditCardSecurityCode
        }
    }

}