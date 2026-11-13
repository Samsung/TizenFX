/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Multimedia
{
    internal sealed class TcoreVideoShellSurface : IDisposable
    {
        private IntPtr _surface;
        internal IntPtr Handle { get; private set; }

        internal TcoreVideoShellSurface(IntPtr window)
        {
            try
            {
                Check(Interop.TcoreVideoShell.Create(window, out _surface), "create");
                if (_surface == IntPtr.Zero)
                    throw new InvalidOperationException("TCORE video shell returned an empty surface.");
                Check(Interop.TcoreVideoShell.PlaceBelow(_surface, IntPtr.Zero), "place below");
                Check(Interop.TcoreVideoShell.Map(_surface), "map");
                Check(Interop.TcoreVideoShell.GetHandle(_surface, out var handle), "get handle");
                if (handle == IntPtr.Zero)
                    throw new InvalidOperationException("TCORE video shell returned an empty handle.");
                Handle = handle;
            }
            catch
            {
                Dispose();
                throw;
            }
        }

        private static void Check(int error, string operation)
        {
            if (error != 0)
                throw new InvalidOperationException($"Failed to {operation} the TCORE video shell: {error}.");
        }

        public void Dispose()
        {
            var surface = _surface;
            _surface = IntPtr.Zero;
            Handle = IntPtr.Zero;
            if (surface != IntPtr.Zero)
            {
                var error = Interop.TcoreVideoShell.Destroy(surface);
                if (error != 0)
                    Tizen.Log.Error("Tizen.Multimedia", $"Failed to destroy the TCORE video shell: {error}.");
            }
        }
    }
}
