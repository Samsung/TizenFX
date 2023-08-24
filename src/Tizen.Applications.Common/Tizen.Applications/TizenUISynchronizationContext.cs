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
using System.ComponentModel;
using System.Threading;

namespace Tizen.Applications
{
    /// <summary>
    /// Provides a synchronization context for the Tizen thread application model.
    /// </summary>
    /// <since_tizen> 10 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class TizenUISynchronizationContext : SynchronizationContext
    {
        /// <summary>
        /// Initilizes a new TizenUISynchronizationContext and install into the current thread.
        /// </summary>
        /// <remarks>
        /// It is equivalent.
        /// <code>
        /// SetSynchronizationContext(new TizenUISynchronizationContext());
        /// </code>
        /// </remarks>
        /// <since_tizen> 10 </since_tizen>
        public static void Initialize()
        {
            SetSynchronizationContext(new TizenUISynchronizationContext());
        }

        /// <summary>
        /// Dispatches an asynchronous message to a Tizen main loop of the UI thread.
        /// </summary>
        /// <param name="d"><see cref="System.Threading.SendOrPostCallback"/>The SendOrPostCallback delegate to call.</param>
        /// <param name="state"><see cref="System.Object"/>The object passed to the delegate.</param>
        /// <remarks>
        /// The post method starts an asynchronous request to post a message.</remarks>
        /// <since_tizen> 10 </since_tizen>
        public override void Post(SendOrPostCallback d, object state)
        {
            GSourceManager.Post(() =>
            {
                d(state);
            }, true);
        }

        /// <summary>
        /// Dispatches a synchronous message to a Tizen main loop of the UI thread.
        /// </summary>
        /// <param name="d"><see cref="System.Threading.SendOrPostCallback"/>The SendOrPostCallback delegate to call.</param>
        /// <param name="state"><see cref="System.Object"/>The object passed to the delegate.</param>
        /// <remarks>
        /// The send method starts a synchronous request to send a message.</remarks>
        /// <since_tizen> 10 </since_tizen>
        public override void Send(SendOrPostCallback d, object state)
        {
            using (var mre = new ManualResetEvent(false))
            {
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
                }, true);
                mre.WaitOne();
                if (err != null)
                {
                    throw err;
                }
            }
        }
    }
}