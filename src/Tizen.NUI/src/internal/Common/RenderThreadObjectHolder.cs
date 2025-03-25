/*
 * Copyright(c) 2025 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.ComponentModel;

namespace Tizen.NUI
{
    /// <summary>
    /// This is used to store a object reference until render thread rendered at least 1 times.
    /// Note that Register itself should be called at main thread!
    /// </summary>
    internal sealed class RenderThreadObjectHolder : global::System.IDisposable
    {
        private static readonly RenderThreadObjectHolder renderThreadObjectHolder = new RenderThreadObjectHolder();

        /// <summary>
        /// static initialization singleton
        /// </summary>
        internal static RenderThreadObjectHolder Instance
        {
            get { return renderThreadObjectHolder; }
        }

        /// <summary>
        /// Strong holder for the System.Delegate.
        /// </summary>
        private HashSet<System.Delegate> delegateSet;

        private Animation threadCheckingAnimation;

        private bool animationTriggered;

        private RenderThreadObjectHolder()
        {
            delegateSet = new HashSet<System.Delegate>();
        }

        ~RenderThreadObjectHolder() => Dispose(false);

        internal static void RegisterDelegates(List<System.Delegate> disposedDelgates)
        {
            if (disposedDelgates == null)
            {
                return;
            }

            foreach (var disposedDelgate in disposedDelgates)
            {
                RegisterDelegate(disposedDelgate);
            }
        }

        internal static void RegisterDelegate(System.Delegate disposedDelgate)
        {
            var holder = Instance;

            if (holder == null)
            {
                // Maybe applicatoin terminated case. We should ignore it.
                return;
            }

            if (disposedDelgate == null)
            {
                return;
            }

            holder.delegateSet.Add(disposedDelgate);

            if (!holder.animationTriggered)
            {
                if (holder.threadCheckingAnimation == null)
                {
                    // Make 0ms animation, and Play + Stop.
                    holder.threadCheckingAnimation = new Animation(0);
                    holder.threadCheckingAnimation.Finished += OnFinished;
                }
                holder.animationTriggered = true;
                holder.threadCheckingAnimation.Play();
                holder.threadCheckingAnimation.Stop();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                threadCheckingAnimation?.Dispose();
                NUILog.ErrorBacktrace("We should not manually dispose for singleton class!");
            }
        }

        private static void OnFinished(object o, EventArgs e)
        {
            var holder = Instance;

            if (holder == null)
            {
                // Maybe applicatoin terminated case. We should ignore it.
                return;
            }

            // Clear objects now.
            holder.delegateSet.Clear();

            holder.animationTriggered = false;
        }
    }
}
