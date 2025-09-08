/*
 * Copyright (c) 2020 Samsung Electronics Co., Ltd.
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
using System.ComponentModel;
using System.Collections.Generic;
using System.Reflection;

namespace Tizen.NUI
{
    /// <summary>
    /// The WeakEvent without holding strong reference of event handler.
    /// </summary>
    /// <since_tizen> 12 </since_tizen>
    public class WeakEvent<T> where T : Delegate
    {
        private const int addThreshold = 1000; // Experimetal constant
        private const int listLengthThreshold = 1000; // Experimetal constant
        private int cleanUpAddCount;
        private List<WeakHandler<T>> handlers = new List<WeakHandler<T>>();

        /// <summary>
        /// The count of currently stored event handlers.
        /// </summary>
        /// <since_tizen> 12 </since_tizen>
        protected int Count => handlers.Count;

        /// <summary>
        /// Adds an event handler to the list of weak references.
        /// </summary>
        /// <since_tizen> 12 </since_tizen>
        public virtual void Add(T handler)
        {
            if (handler == null)
            {
                // Do nothing.
                return;
            }
            handlers.Add(new WeakHandler<T>(handler));
            OnCountIncreased();

            CleanUpDeadHandlersIfNeeds();
        }

        /// <summary>
        /// Remove last stored event handler equal to <paramref name="handler"/>.
        /// </summary>
        /// <param name="handler">The event handler to remove.</param>
        /// <since_tizen> 12 </since_tizen>
        public virtual void Remove(T handler)
        {
            if (handler == null)
            {
                // Do nothing.
                return;
            }

            int lastIndex = handlers.FindLastIndex(item => item.Equals(handler));

            if (lastIndex >= 0)
            {
                handlers.RemoveAt(lastIndex);
                OnCountDecreased();
            }
        }

        /// <summary>
        /// Invoke event handlers.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">An object that contains event data.</param>
        /// <since_tizen> 12 </since_tizen>
        public void Invoke(object sender, object args)
        {
            // Iterate copied one to prevent addition/removal item in the handler call.
            var copiedArray = handlers.ToArray();
            foreach (var item in copiedArray)
            {
                item.Invoke(sender, args);
            }

            // Clean up GC items
            CleanUpDeadHandlers();
        }

        /// <summary>
        /// Invoked when the event handler count is increased - a new event handler has been added.
        /// </summary>
        /// <since_tizen> 12 </since_tizen>
        protected virtual void OnCountIncreased()
        {
        }

        /// <summary>
        /// Invoked when the event handler count is decreased.
        /// </summary>
        /// <remarks>
        /// The event handler count decreases when an event handler is removed
        ///  with <see cref="Remove(T)"/> or after detecting that it is no longer valid.
        /// </remarks>
        /// <since_tizen> 12 </since_tizen>
        protected virtual void OnCountDecreased()
        {
        }

        private void CleanUpDeadHandlersIfNeeds()
        {
            // Once the list count exceed 'listLengthThreshold', do the clean-up every 'addThreshold' add operations.
            // When list count go below `listLengthThreshold` before clean-up, pause operation counting.
            if (handlers.Count > listLengthThreshold && ++cleanUpAddCount > addThreshold)
            {
                CleanUpDeadHandlers();
            }
        }

        private void CleanUpDeadHandlers()
        {
            cleanUpAddCount = 0;
            int count = handlers.Count;
            handlers.RemoveAll(item => !item.IsAlive);
            if (count > handlers.Count) OnCountDecreased();
        }

        internal class WeakHandler<U> where U : Delegate
        {
            private WeakReference weakTarget; // Null value means the method is static.
            private MethodInfo methodInfo;

            public WeakHandler(U handler)
            {
                Delegate d = (Delegate)(object)handler;
                if (d.Target != null) weakTarget = new WeakReference(d.Target);
                methodInfo = d.Method;
            }

            private bool IsStatic => weakTarget == null;

            public bool IsAlive
            {
                get
                {
                    var rooting = weakTarget?.Target;

                    return IsStatic || !IsDisposed(rooting);
                }
            }

            private static bool IsDisposed(object target)
            {
                if (target == null) return true;

                if (target is BaseHandle basehandle) return basehandle.Disposed || basehandle.IsDisposeQueued;

                if (target is Disposable disposable) return disposable.Disposed || disposable.IsDisposeQueued;

                return false;
            }

            public bool Equals(U handler)
            {
                Delegate other = (Delegate)(object)handler;
                bool isOtherStatic = other.Target == null;
                return (isOtherStatic || weakTarget?.Target == other.Target) && methodInfo.Equals(other.Method);
            }

            public void Invoke(params object[] args)
            {
                if (IsStatic)
                {
                    Delegate.CreateDelegate(typeof(U), methodInfo).DynamicInvoke(args);
                }
                else
                {
                    // Because GC is done in other thread,
                    // it needs to check again that the reference is still alive before calling method.
                    // To do that, the reference should be assigned to the local variable first.
                    var rooting = weakTarget.Target;

                    if (IsAlive)
                    {
                        Delegate.CreateDelegate(typeof(U), rooting, methodInfo).DynamicInvoke(args);
                    }
                }
            }
        }
    }
}
