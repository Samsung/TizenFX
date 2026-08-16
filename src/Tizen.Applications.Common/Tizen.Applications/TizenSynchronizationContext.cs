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
using System.Runtime.ExceptionServices;
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
            SynchronizationContextDispatcher.Post(d, state, useTizenGlibContext: false);
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
            SynchronizationContextDispatcher.Send(d, state, useTizenGlibContext: false);
        }
    }

    internal static class SynchronizationContextDispatcher
    {
        public static void Post(SendOrPostCallback d, object state, bool useTizenGlibContext)
        {
            GSourceManager.Post(() =>
            {
                d(state);
            }, useTizenGlibContext);
        }

        public static void Send(SendOrPostCallback d, object state, bool useTizenGlibContext)
        {
            using (var mre = new ManualResetEventSlim(false))
            {
                ExceptionDispatchInfo edi = null;
                GSourceManager.Post(() =>
                {
#pragma warning disable CA1031
                    try
                    {
                        d(state);
                    }
                    catch (Exception ex)
                    {
                        edi = ExceptionDispatchInfo.Capture(ex);
                    }
                    finally
                    {
                        mre.Set();
                    }
#pragma warning restore CA1031
                }, useTizenGlibContext);
                mre.Wait();
                edi?.Throw();
            }
        }
    }
}