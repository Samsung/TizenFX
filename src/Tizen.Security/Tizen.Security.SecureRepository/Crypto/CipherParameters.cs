using System;
using System.Runtime.InteropServices;

namespace Tizen.Security.SecureRepository.Crypto
{
    /// <summary>
    /// A abstract class holding parameters for encryption and decryption.
    /// </summary>
    abstract public class CipherParameters : SafeHandle
    {
        /// <summary>
        /// A constructor with algorithm
        /// </summary>
        /// <param name="algorithm">An algorithm that this parameters are prepared for.</param>
        public CipherParameters(CipherAlgorithmType algorithm) : base(IntPtr.Zero, true)
        {
            IntPtr ptrParams;
            Interop.CkmcTypes.CkmcGenerateNewParam((int)algorithm, out ptrParams);
            this.SetHandle(ptrParams);
        }

        /// <summary>
        /// Adds integer parameter.
        /// </summary>
        /// <param name="name">Parameter name.</param>
        /// <param name="value">Parameter value.</param>
        protected void Add(CipherParameterName name, long value)
        {
            int ret = Interop.CkmcTypes.CkmcParamListSetInteger(PtrCkmcParamList, (int)name, value);
            Interop.KeyManagerExceptionFactory.CheckNThrowException(ret, "Failed to add parameter.");
        }

        /// <summary>
        /// Adds byte array parameter.
        /// </summary>
        /// <param name="name">Parameter name.</param>
        /// <param name="value">Parameter value.</param>
        protected void Add(CipherParameterName name, byte[] value)
        {
            Interop.CkmcRawBuffer rawBuff = new Interop.CkmcRawBuffer(new PinnedObject(value), value.Length);
            int ret = Interop.CkmcTypes.CkmcParamListSetBuffer(PtrCkmcParamList, (int)name, new PinnedObject(rawBuff));
            Interop.KeyManagerExceptionFactory.CheckNThrowException(ret, "Failed to add parameter.");
        }

        /// <summary>
        /// Gets integer parameter.
        /// </summary>
        /// <param name="name">Parameter name.</param>
        protected long GetInteger(CipherParameterName name)
        {
            long value = 0;
            int ret = Interop.CkmcTypes.CkmcParamListGetInteger(PtrCkmcParamList, (int)name, out value);
            Interop.KeyManagerExceptionFactory.CheckNThrowException(ret, "Failed to get parameter.");
            return value;
        }

        /// <summary>
        /// Gets byte array parameter.
        /// </summary>
        /// <param name="name">Parameter name.</param>
        protected byte[] GetBuffer(CipherParameterName name)
        {
            IntPtr ptr = new IntPtr();

            int ret = Interop.CkmcTypes.CkmcParamListGetBuffer(PtrCkmcParamList, (int)name, out ptr);
            Interop.KeyManagerExceptionFactory.CheckNThrowException(ret, "Failed to get parameter.");

            return new SafeRawBufferHandle(ptr).Data;
        }

        /// <summary>
        /// Cipher algorithm type.
        /// </summary>
        public CipherAlgorithmType Algorithm
        {
            get { return (CipherAlgorithmType)GetInteger(CipherParameterName.AlgorithmType); }
        }

        internal IntPtr PtrCkmcParamList
        {
            get { return handle; }
        }

        /// <summary>
        /// Gets a value that indicates whether the handle is invalid.
        /// </summary>
        public override bool IsInvalid
        {
            get { return handle == IntPtr.Zero; }
        }

        /// <summary>
        /// When overridden in a derived class, executes the code required to free the handle.
        /// </summary>
        /// <returns>true if the handle is released successfully</returns>
        protected override bool ReleaseHandle()
        {
            if (IsInvalid) // do not release
                return true;
            Interop.CkmcTypes.CkmcParamListFree(handle);
            this.SetHandle(IntPtr.Zero);
            return true;
        }
    }
}
