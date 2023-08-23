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
using System.Collections.Generic;
using System.Reflection;

namespace Tizen.NUI
{
    internal class WeakEvent<T>
    {
        private List<WeakHandler<T>> handlers = new List<WeakHandler<T>>();

        protected int Count => handlers.Count;

        public virtual void Add(T handler)
        {
            if (handlers == null)
            {
                handlers = new List<WeakHandler<T>>();
            }

            handlers.Add(new WeakHandler<T>(handler));

            OnCountIncreased();
        }

        public virtual void Remove(T handler)
        {
            if (handlers == null)
            {
                return;
            }

            int count = handlers.Count;

            handlers.RemoveAll(item => !item.IsAlive || item.Equals(handler));

            if (count > handlers.Count)
            {
                OnCountDicreased();
            }
        }

        public void Invoke(object sender, EventArgs args)
        {
            if (handlers == null)
            {
                return;
            }

            var disposed = new HashSet<WeakHandler<T>>();

            int count = handlers.Count;

            foreach (var item in handlers)
            {
                if (item.IsAlive)
                {
                    item.Invoke(sender, args);
                    continue;
                }
                disposed.Add(item);
            }

            handlers.RemoveAll(disposed.Contains);

            if (count > handlers.Count)
            {
                OnCountDicreased();
            }
        }

        protected virtual void OnCountIncreased()
        {
        }


        protected virtual void OnCountDicreased()
        {
        }

        internal class WeakHandler<U>
        {
            private WeakReference weakReference;
            private MethodInfo methodInfo;

            public WeakHandler(U handler)
            {
                Delegate d = (Delegate)(object)handler;
                if (d.Target != null) weakReference = new WeakReference(d.Target);
                methodInfo = d.Method;
            }

            public bool Equals(U handler)
            {
                Delegate other = (Delegate)(object)handler;
                return other != null && other.Target == weakReference?.Target && other.Method.Equals(methodInfo);
            }

            public bool IsAlive => weakReference == null || weakReference.IsAlive;

            public void Invoke(params object[] args)
            {
                if (weakReference == null)
                {
                    Delegate.CreateDelegate(typeof(U), methodInfo).DynamicInvoke(args);
                }
                else
                {
                    // Because GC is done in other thread,
                    // it needs to check again that the reference is still alive before calling method.
                    // To do that, the reference should be assigned to the local variable first.
                    var localRefCopied = weakReference.Target;

                    // Do not change this to if (weakReference.Target != null)
                    if (localRefCopied != null) Delegate.CreateDelegate(typeof(U), localRefCopied, methodInfo).DynamicInvoke(args);
                }
            }
        }
    }
}
