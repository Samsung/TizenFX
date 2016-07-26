using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using static Interop;

namespace Tizen.Security.SecureRepository
{
    internal class SafeCertificateListHandle : SafeHandle
    {
        private IEnumerable<Certificate> _certificates;

        public SafeCertificateListHandle(IEnumerable<Certificate> certs) : base(IntPtr.Zero, true)
        {
            this.SetHandle(IntPtr.Zero);
            _certificates = certs;
        }

        public SafeCertificateListHandle(IntPtr ptrCerts, bool ownsHandle = true) : base(IntPtr.Zero, ownsHandle)
        {
            this.SetHandle(ptrCerts);

            List<Certificate> certs = new List<Certificate>();
            IntPtr ptrCurr = handle;
            while (ptrCurr != IntPtr.Zero)
            {
                CkmcCertList ckmcCertList = (CkmcCertList)Marshal.PtrToStructure(ptrCurr, typeof(CkmcCertList));
                certs.Add(new Certificate(ckmcCertList.cert, false));
                ptrCurr = ckmcCertList.next;
            }

            _certificates = certs;
        }

        public IEnumerable<Certificate> Certificates
        {
            get { return _certificates; }
        }

        internal IntPtr ToCkmcCertificateListPtr()
        {
            if (_certificates == null)
                return IntPtr.Zero;

            if (!IsInvalid)
                return handle;

            IntPtr first = IntPtr.Zero;
            IntPtr previous = IntPtr.Zero;

            int ret;
            foreach (Certificate cert in _certificates)
            {
                IntPtr certPtr;
                ret = Interop.CkmcTypes.CkmcCertNew(cert.Binary, (uint)cert.Binary.Length, (int)cert.Format, out certPtr);
                Interop.KeyManagerExceptionFactory.CheckNThrowException(ret, "Failed to create new Certificate.");

                IntPtr outCertList;
                if (previous == IntPtr.Zero)
                {
                    ret = Interop.CkmcTypes.CkmcCertListNew(certPtr, out outCertList);
                    Interop.KeyManagerExceptionFactory.CheckNThrowException(ret, "Failed to create new CertificateList.");
                    first = outCertList;
                    previous = outCertList;
                }
                else
                {
                    ret = Interop.CkmcTypes.CkmcCertListAdd(previous, certPtr, out outCertList);
                    Interop.KeyManagerExceptionFactory.CheckNThrowException(ret, "Failed to add Certificate to CertificateList.");
                    previous = outCertList;
                }
            }

            this.SetHandle(first);
            return first;
        }

        /// <summary>
        /// Gets a value that indicates whether the handle is invalid.
        /// </summary>
        public override bool IsInvalid
        {
            get { return (handle == IntPtr.Zero); }
        }

        /// <summary>
        /// When overridden in a derived class, executes the code required to free the handle.
        /// </summary>
        /// <returns>true if the handle is released successfully</returns>
        protected override bool ReleaseHandle()
        {
            if (handle == IntPtr.Zero) // do not release
                return true;

            Interop.CkmcTypes.CkmcCertListAllFree(handle);
            this.SetHandle(IntPtr.Zero);
            return true;
        }
    }
}
