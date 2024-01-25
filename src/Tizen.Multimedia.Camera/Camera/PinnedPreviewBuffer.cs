/*
 * Copyright (c) 2022 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Runtime.InteropServices;

namespace Tizen.Multimedia
{
    internal class PinnedPreviewBuffer<T> : IDisposable
    {
        private readonly GCHandle[] _gcHandles;
        private readonly T[][] _buffers;

        internal PinnedPreviewBuffer(params uint[] sizes)
        {
            _buffers = new T[sizes.Length][];
            _gcHandles = new GCHandle[sizes.Length];

            for (int i = 0 ; i < sizes.Length; i++)
            {
                _buffers[i] = new T[sizes[i]];
                _gcHandles[i] = GCHandle.Alloc(_buffers[i], GCHandleType.Pinned);
            }
        }

        ~PinnedPreviewBuffer()
        {
            Dispose(false);
        }

        internal T[] this[int index] => _buffers[index];

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                foreach (var gcHandle in _gcHandles)
                {
                    gcHandle.Free();
                }

                Log.Info(CameraLog.Tag, $"Disposed : {disposing}");
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
