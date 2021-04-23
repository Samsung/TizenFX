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

namespace Tizen.NUI
{
    /// <summary>
    /// AutofillContainer controls several text input boxes.
    /// </summary>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class AutofillContainer : BaseHandle
    {
        private AuthenticationEventCallbackType authenticationCallback;
        private ListEventCallbackType listCallback;

        private event EventHandler<AuthenticationEventArgs> authenticationEventHandler;
        private event EventHandler<ListEventArgs> listEventHandler;

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
                if (authenticationEventHandler == null)
                {
                    authenticationCallback = OnServiceEvent;
                    AutofillServiceEventSignal().Connect(authenticationCallback);
                }

                authenticationEventHandler += value;
            }
            remove
            {
                authenticationEventHandler -= value;

                if (authenticationEventHandler == null && authenticationCallback != null)
                {
                    AutofillServiceEventSignal().Disconnect(authenticationCallback);
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
                if (listEventHandler == null)
                {
                    listCallback = OnListEvent;
                    AutofillListEventSignal().Connect(listCallback);
                }

                listEventHandler += value;
            }
            remove
            {
                listEventHandler -= value;

                if (listEventHandler == null && listCallback != null)
                {
                    AutofillListEventSignal().Disconnect(listCallback);
                }
            }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name"> The AutofillContainer name</param>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AutofillContainer(string name) : this(Interop.AutofillContainer.New(name), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal AutofillContainer(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }


        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(AutofillContainer obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        internal AutofillContainer(AutofillContainer autofillContainer) : this(Interop.AutofillContainer.NewAutofillContainer(AutofillContainer.getCPtr(autofillContainer)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal AutofillContainer Assign(AutofillContainer autofillContainer)
        {
            AutofillContainer ret = new AutofillContainer(Interop.AutofillContainer.Assign(SwigCPtr, AutofillContainer.getCPtr(autofillContainer)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static AutofillContainer DownCast(BaseHandle handle)
        {
            AutofillContainer ret = new AutofillContainer(Interop.AutofillContainer.DownCast(BaseHandle.getCPtr(handle)), true);
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
            Interop.AutofillContainer.AddAutofillView(SwigCPtr, BaseComponents.View.getCPtr(view), propertyIndex, id, label, (uint)hint, isSensitive);
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
            Interop.AutofillContainer.RemoveAutofillItem(SwigCPtr, BaseComponents.View.getCPtr(view));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Stores autofill data.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SaveAutofillData()
        {
            Interop.AutofillContainer.SaveAutofillData(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sends a request for filling the data.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RequestFillData()
        {
            Interop.AutofillContainer.RequestFillData(SwigCPtr);
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
            string ret = Interop.AutofillContainer.GetAutofillServiceName(SwigCPtr);
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
            string ret = Interop.AutofillContainer.GetAutofillServiceMessage(SwigCPtr);
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
            string ret = Interop.AutofillContainer.GetAutofillServiceImagePath(SwigCPtr);
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
            uint ret = Interop.AutofillContainer.GetListItemCount(SwigCPtr);
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
            string ret = Interop.AutofillContainer.GetListItem(SwigCPtr, index);
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
            Interop.AutofillContainer.SetSelectedItem(SwigCPtr, selected);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal AuthenticationSignalType AutofillServiceEventSignal()
        {

            AuthenticationSignalType ret = new AuthenticationSignalType(Interop.AutofillContainer.AutofillServiceEventSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ListEventSignalType AutofillListEventSignal()
        {
            ListEventSignalType ret = new ListEventSignalType(Interop.AutofillContainer.AutofillListEventSignal(SwigCPtr), false);
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
                if (authenticationCallback != null)
                {
                    AutofillServiceEventSignal().Disconnect(authenticationCallback);
                }

                if (listCallback != null)
                {
                    AutofillListEventSignal().Disconnect(listCallback);
                }
            }

            base.Dispose(type);
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.AutofillContainer.DeleteAutofillContainer(swigCPtr);
        }

        private void OnServiceEvent(IntPtr autofillContainer)
        {
            AuthenticationEventArgs e = new AuthenticationEventArgs();
            e.AutofillContainer = Registry.GetManagedBaseHandleFromNativePtr(autofillContainer) as AutofillContainer;

            if (authenticationEventHandler != null)
            {
                authenticationEventHandler(this, e);
            }
        }

        private void OnListEvent(IntPtr control)
        {
            ListEventArgs e = new ListEventArgs();
            e.Control = Registry.GetManagedBaseHandleFromNativePtr(control) as BaseComponents.View;

            if (listEventHandler != null)
            {
                listEventHandler(this, e);
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
