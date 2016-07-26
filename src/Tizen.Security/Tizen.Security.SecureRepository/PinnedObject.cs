using System;
using System.Runtime.InteropServices;

namespace Tizen.Security.SecureRepository
{
    internal class PinnedObject : IDisposable
    {
        private bool _disposed = false;
        private GCHandle _pinnedObj;

        public PinnedObject(Object obj)
        {
            _pinnedObj = GCHandle.Alloc(obj, GCHandleType.Pinned);
        }

        ~PinnedObject()
        {
            Dispose(false);
        }

        public static implicit operator IntPtr(PinnedObject pinned)
        {
            return pinned._pinnedObj.AddrOfPinnedObject();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;
            _pinnedObj.Free();
            _disposed = true;
        }
    }
}
