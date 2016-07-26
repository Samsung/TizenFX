using System;
using System.Runtime.InteropServices;
using static Interop;

namespace Tizen.Security.SecureRepository
{
    /// <summary>
    /// Class that represents a key.
    /// </summary>
    public class Key : SafeHandle
    {
        /// <summary>
        /// A constructor of Key that takes the binary, its type, and optional password of binary.
        /// </summary>
        /// <param name="binary">The binary value of a key. This binary may be encrypted with binaryPassword.</param>
        /// <param name="type">The key's type.</param>
        /// <param name="binaryPassword">The password used to decrypt binary when binary is encrypted.</param>
        public Key(byte[] binary, KeyType type, string binaryPassword) : base(IntPtr.Zero, true)
        {
            this.SetHandle(IntPtr.Zero);
            Binary = binary;
            Type = type;
            BinaryPassword = binaryPassword;
        }

        internal Key(IntPtr ptr, bool ownsHandle = true) : base(IntPtr.Zero, ownsHandle)
        {
            base.SetHandle(ptr);

            CkmcKey ckmcKey = (CkmcKey)Marshal.PtrToStructure(handle, typeof(CkmcKey));
            Binary = new byte[ckmcKey.size];
            Marshal.Copy(ckmcKey.rawKey, Binary, 0, Binary.Length);
            Type = (KeyType)ckmcKey.keyType;
            BinaryPassword = Marshal.PtrToStringAuto(ckmcKey.password);
        }

        /// <summary>
        /// The binary value of a key.
        /// </summary>
        public byte[] Binary
        {
            get; set;
        }

        /// <summary>
        /// The key's type.
        /// </summary>
        public KeyType Type
        {
            get; set;
        }

        /// <summary>
        /// The password used to decrypt binary when binary is encrypted. It's optional.
        /// </summary>
        public string BinaryPassword
        {
            get; set;
        }

        internal CkmcKey ToCkmcKey()
        {
            return new Interop.CkmcKey(new PinnedObject(Binary),
                                            Binary.Length,
                                            (int)Type,
                                            new PinnedObject(BinaryPassword));
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

            Interop.CkmcTypes.CkmcKeyFree(handle);
            this.SetHandle(IntPtr.Zero);
            return true;
        }
    }
}
