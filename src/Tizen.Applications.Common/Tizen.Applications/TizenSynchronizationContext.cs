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
using System.Collections.Concurrent;
using System.Threading;

namespace Tizen.Applications
{
    /// <summary>
    /// Provides a synchronization context for the Tizen application model.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class TizenSynchronizationContext : SynchronizationContext
    {
        /// <summary>
        /// Initilizes a new TizenSynchronizationContext and install into the current thread.
        /// </summary>
        /// <remarks>
        /// It is equivalent.
        /// <code>
        /// SetSynchronizationContext(new TizenSynchronizationContext());
        /// </code>
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public static void Initialize()
        {
            SetSynchronizationContext(new TizenSynchronizationContext());
        }

        /// <summary>
        /// Dispatches an asynchronous message to a Tizen main loop.
        /// </summary>
        /// <param name="d"><see cref="System.Threading.SendOrPostCallback"/>The SendOrPostCallback delegate to call.</param>
        /// <param name="state"><see cref="System.Object"/>The object passed to the delegate.</param>
        /// <remarks>
        /// The post method starts an asynchronous request to post a message.</remarks>
        /// <since_tizen> 3 </since_tizen>
        public override void Post(SendOrPostCallback d, object state)
        {
            GSourceManager.Post(() =>
            {
                d(state);
            });
        }

        /// <summary>
        /// Dispatches a synchronous message to a Tizen main loop.
        /// </summary>
        /// <param name="d"><see cref="System.Threading.SendOrPostCallback"/>The SendOrPostCallback delegate to call.</param>
        /// <param name="state"><see cref="System.Object"/>The object passed to the delegate.</param>
        /// <remarks>
        /// The send method starts a synchronous request to send a message.</remarks>
        /// <since_tizen> 3 </since_tizen>
        public override void Send(SendOrPostCallback d, object state)
        {
            var mre = new ManualResetEvent(false);
            Exception err = null;
            GSourceManager.Post(() =>
            {
                try
                {
                    d(state);
                }
                catch (Exception ex)
                {
                    err = ex;
                }
                finally
                {
                    mre.Set();
                }
            });
            mre.WaitOne();
            if (err != null)
            {
                throw err;
            }
        }

        private static class GSourceManager
        {
            private static Interop.Glib.GSourceFunc _wrapperHandler;
            private static Object _transactionLock;
            private static ConcurrentDictionary<int, Action> _handlerMap;
            private static int _transactionId;

            static GSourceManager()
            {
                _wrapperHandler = new Interop.Glib.GSourceFunc(Handler);
                _transactionLock = new Object();
                _handlerMap = new ConcurrentDictionary<int, Action>();
                _transactionId = 0;
            }

            public static void Post(Action action)
            {
                int id = 0;
                lock (_transactionLock)
                {
                    id = _transactionId++;
                }
                _handlerMap.TryAdd(id, action);
                Interop.Glib.IdleAdd(_wrapperHandler, (IntPtr)id);
            }

            private static bool Handler(IntPtr userData)
            {
                int key = (int)userData;
                if (_handlerMap.ContainsKey(key))
                {
                    Action action;
                    _handlerMap.TryRemove(key, out action);
                    action?.Invoke();
                }
                return false;
            }
        }
    }
}
