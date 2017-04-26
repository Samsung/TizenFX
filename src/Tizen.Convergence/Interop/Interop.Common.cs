// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal abstract class TizenSafeHandle : SafeHandle
    {
        public abstract void Destroy();

        public TizenSafeHandle() : base(IntPtr.Zero, true)
        {
        }

        public TizenSafeHandle(IntPtr handle) : base(handle, true)
        {
        }

        public override bool IsInvalid
        {
            get
            {
                return handle == IntPtr.Zero;
            }
        }

        protected override bool ReleaseHandle()
        {
            Destroy();
            SetHandle(IntPtr.Zero);
            return true;
        }
    }
}
