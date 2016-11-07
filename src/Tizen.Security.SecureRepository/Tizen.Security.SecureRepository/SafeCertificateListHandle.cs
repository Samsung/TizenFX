/*
 *  Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 *  Licensed under the Apache License, Version 2.0 (the "License");
 *  you may not use this file except in compliance with the License.
 *  You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 *  Unless required by applicable law or agreed to in writing, software
 *  distributed under the License is distributed on an "AS IS" BASIS,
 *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *  See the License for the specific language governing permissions and
 *  limitations under the License
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using static Interop;

namespace Tizen.Security.SecureRepository
{
    internal class SafeCertificateListHandle : SafeHandle
    {
        private IEnumerable<Certificate> _certificates;

        public SafeCertificateListHandle(IEnumerable<Certificate> certs) :
            base(IntPtr.Zero, true)
        {
            _certificates = certs;
        }

        public SafeCertificateListHandle(IntPtr ptr, bool ownsHandle = true) :
            base(ptr, ownsHandle)
        {
            var cur = ptr;
            var certs = new List<Certificate>();
            while (cur != IntPtr.Zero)
            {
                var ckmcCertList = Marshal.PtrToStructure<CkmcCertList>(cur);
                certs.Add(new Certificate(ckmcCertList.cert, false));
                cur = ckmcCertList.next;
            }

            this._certificates = certs;
        }

        public IEnumerable<Certificate> Certificates
        {
            get { return _certificates; }
        }

        internal IntPtr GetHandle(bool updateHandle = true)
        {
            if (_certificates == null)
                return IntPtr.Zero;

            if (!IsInvalid)
                return this.handle;

            IntPtr first = IntPtr.Zero;
            IntPtr previous = IntPtr.Zero;
            IntPtr certPtr = IntPtr.Zero;

            try
            {
                foreach (var cert in this._certificates)
                {
                    // initialize local variables to release memory safely for
                    // in case of exception occured
                    certPtr = IntPtr.Zero;

                    certPtr = cert.GetHandle(false);

                    IntPtr outCertList;
                    if (previous == IntPtr.Zero)
                    {
                        Interop.CheckNThrowException(
                            Interop.CkmcTypes.CertListNew(certPtr, out outCertList),
                            "Failed to create new CertificateList.");
                        first = outCertList;
                    }
                    else
                    {
                        Interop.CheckNThrowException(
                            Interop.CkmcTypes.CertListAdd(previous, certPtr,
                                                          out outCertList),
                            "Failed to add Certificate to CertificateList.");
                    }
                    previous = outCertList;
                }

                if (updateHandle)
                    this.SetHandle(first);

                return first;
            }
            catch
            {
                if (first != IntPtr.Zero)
                    Interop.CkmcTypes.CertListAllFree(this.handle);
                if (certPtr != IntPtr.Zero)
                    Interop.CkmcTypes.CertFree(certPtr);

                throw;
            }
        }

        /// <summary>
        /// Gets a value that indicates whether the handle is invalid.
        /// </summary>
        public override bool IsInvalid
        {
            get { return this.handle == IntPtr.Zero; }
        }

        /// <summary>
        /// When overridden in a derived class, executes the code required to free
        /// the handle.
        /// </summary>
        /// <returns>true if the handle is released successfully</returns>
        protected override bool ReleaseHandle()
        {
            Interop.CkmcTypes.CertListAllFree(this.handle);
            this.SetHandle(IntPtr.Zero);
            return true;
        }
    }
}
