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
