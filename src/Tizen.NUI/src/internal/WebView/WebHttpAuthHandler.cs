/*
 * Copyright (c) 2021 Samsung Electronics Co., Ltd.
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

using System.ComponentModel;

namespace Tizen.NUI
{
    /// <summary>
    /// It is a class for http authencation handler of web view.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class WebHttpAuthHandler : Disposable
    {
        internal WebHttpAuthHandler(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// Gets the realm of authentication challenge received.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Realm
        {
            get
            {
                string result = Interop.WebHttpAuthHandler.GetRealm(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) return null;
                return result;
            }
        }

        /// <summary>
        /// Suspends the operation for authentication challenge.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Suspend()
        {
            Interop.WebHttpAuthHandler.Suspend(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sends credential for authentication challenge.
        /// <param name="userId">user id from user input.</param>
        /// <param name="password">user password from user input.</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void UseCredential(string userId, string password)
        {
            Interop.WebHttpAuthHandler.UseCredential(SwigCPtr, userId, password);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sends cancellation notification for authentication challenge.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void CancelCredential()
        {
            Interop.WebHttpAuthHandler.CancelCredential(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
    }
}
