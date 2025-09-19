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
        private static Interop.Glib.GSourceFunc _wrapperHandler = new Interop.Glib.GSourceFunc(Handler);
        private static Object _transactionLock = new Object();
        private static ConcurrentDictionary<int, Action> _handlerMap = new ConcurrentDictionary<int, Action>();
        private static int _transactionId = 0;

        public static void Post(Action action, bool useTizenGlibContext = false)
        {
            int id = 0;
            lock (_transactionLock)
            {
                id = _transactionId++;
            }
            _handlerMap.TryAdd(id, action);
            IntPtr source = Interop.Glib.IdleSourceNew();
            Interop.Glib.SourceSetCallback(source, _wrapperHandler, (IntPtr)id, IntPtr.Zero);
            _ = Interop.Glib.SourceAttach(source, useTizenGlibContext ? Interop.AppCoreUI.GetTizenGlibContext() : IntPtr.Zero);
            Interop.Glib.SourceUnref(source);
        }

        public static void PostDelayed(Action action, uint delay, bool useTizenGlibContext = false)
        {
            int id = 0;
            lock (_transactionLock)
            {
                id = _transactionId++;
            }
            _handlerMap.TryAdd(id, action);
            IntPtr source = Interop.Glib.TimeoutSourceNew(delay);
            Interop.Glib.SourceSetCallback(source, _wrapperHandler, (IntPtr)id, IntPtr.Zero);
            _ = Interop.Glib.SourceAttach(source, useTizenGlibContext ? Interop.AppCoreUI.GetTizenGlibContext() : IntPtr.Zero);
            Interop.Glib.SourceUnref(source);
        }

        private static bool Handler(IntPtr userData)
        {
            int key = (int)userData;
            if (_handlerMap.TryRemove(key, out Action action))
            {
                action?.Invoke();
            }
            return false;
        }
    }
}