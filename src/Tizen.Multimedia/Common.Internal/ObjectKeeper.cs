/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
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
    internal abstract class ObjectKeeper : IDisposable
    {
        private ObjectKeeper()
        {
        }

        public abstract void Dispose();

        public static ObjectKeeperImpl<T> Get<T>(T target)
        {
            return new ObjectKeeperImpl<T>(target);
        }

        internal class ObjectKeeperImpl<T> : ObjectKeeper
        {
            private readonly GCHandle _handle;

            internal ObjectKeeperImpl(T obj)
            {
                Target = obj;
                _handle = GCHandle.Alloc(obj);
                Tizen.Log.Info("Tizen.Multimedia", "GCHandle is allocated.");
            }

            ~ObjectKeeperImpl()
            {
                Dispose(false);
            }

            private bool disposedValue = false;

            protected virtual void Dispose(bool disposing)
            {
                if (!disposedValue)
                {
                    _handle.Free();

                    disposedValue = true;
                }
            }

            public override void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
                Tizen.Log.Warn("Tizen.Multimedia", "GCHandle is disposed.");
            }

            public T Target
            {
                get;
            }
        }
    }
}
