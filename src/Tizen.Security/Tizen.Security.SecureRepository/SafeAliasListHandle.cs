using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using static Interop;

namespace Tizen.Security.SecureRepository
{
    internal class SafeAliasListHandle : SafeHandle
    {
        public SafeAliasListHandle(IntPtr ptrAliases, bool ownsHandle = true) : base(IntPtr.Zero, ownsHandle)
        {
            base.SetHandle(ptrAliases);

            List<string> aliases = new List<string>();
            while (ptrAliases != IntPtr.Zero)
            {
                CkmcAliasList ckmcAliasList = (CkmcAliasList)Marshal.PtrToStructure(ptrAliases, typeof(CkmcAliasList));
                aliases.Add(Marshal.PtrToStringAuto(ckmcAliasList.alias));
                ptrAliases = ckmcAliasList.next;
            }

            this.Aliases = aliases;
        }

        public List<string> Aliases
        {
            get; set;
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

            Interop.CkmcTypes.CkmcAliasListAllFree(handle);
            this.SetHandle(IntPtr.Zero);
            return true;
        }
    }
}
