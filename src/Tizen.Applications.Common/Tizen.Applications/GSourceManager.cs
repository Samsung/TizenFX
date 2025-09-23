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
using System.Collections.Concurrent;

namespace Tizen.Applications
{
    internal static class GSourceManager
    {
        private static readonly GSourceContext _tizenContext = new GSourceContext();
        private static readonly GSourceContext _tizenUIContext = new GSourceContext();
        private static readonly Interop.Glib.GSourceFunc _wrapperHandler = new Interop.Glib.GSourceFunc(Handler);

        public static void Post(Action action, bool useTizenGlibContext = false)
        {
            IntPtr context = useTizenGlibContext ? Interop.AppCoreUI.GetTizenGlibContext() : IntPtr.Zero;
            var sourceContext = context == IntPtr.Zero ? _tizenContext : _tizenUIContext;
            sourceContext.Post(action, context, _wrapperHandler);
        }

        private static bool Handler(IntPtr userData)
        {
            var sourceContext = userData == IntPtr.Zero ? _tizenContext : _tizenUIContext;
            return sourceContext.ProcessQueue();
        }
    }

    internal class GSourceContext
    {
        private readonly ConcurrentQueue<Action> _actionQueue = new ConcurrentQueue<Action>();
        private readonly object _lock = new object();
        private IntPtr _source = IntPtr.Zero;

        public void Post(Action action, IntPtr context, Interop.Glib.GSourceFunc handler)
        {
            _actionQueue.Enqueue(action);

            lock (_lock)
            {
                if (_source != IntPtr.Zero)
                {
                    return;
                }

                _source = Interop.Glib.IdleSourceNew();
                Interop.Glib.SourceSetCallback(_source, handler, context, IntPtr.Zero);
                _ = Interop.Glib.SourceAttach(_source, context);
                Interop.Glib.SourceUnref(_source);
            }
        }

        public bool ProcessQueue()
        {
            if (_actionQueue.TryDequeue(out var action))
            {
                action?.Invoke();
            }

            lock (_lock)
            {
                if (!_actionQueue.IsEmpty)
                {
                    return true;
                }

                _source = IntPtr.Zero;
            }

            return false;
        }
    }
}