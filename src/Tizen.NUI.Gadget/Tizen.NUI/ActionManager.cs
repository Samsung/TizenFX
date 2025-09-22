/*
 * Copyright (c) 2025 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.NUI
{
    internal static class ActionManager
    {
        private static Interop.Glib.GSourceFunc _wrapperHandler = new Interop.Glib.GSourceFunc(Handler);
        private static ConcurrentQueue<Action> _handlerQueue = new ConcurrentQueue<Action>();
        private static object _sourceLock = new object();
        private static uint _sourceId = 0;

        public static void Post(Action action)
        {
            _handlerQueue.Enqueue(action);
            lock (_sourceLock)
            {
                if (_sourceId == 0)
                {
                    _sourceId = Interop.Glib.IdleAdd(_wrapperHandler, IntPtr.Zero);
                }
            }
        }

        private static bool Handler(IntPtr userData)
        {
            if (_handlerQueue.TryDequeue(out var action))
            {
                action?.Invoke();
            }

            lock (_sourceLock)
            {
                if (!_handlerQueue.IsEmpty)
                {
                    return true;
                }
                _sourceId = 0;
            }

            return false;
        }
    }
}