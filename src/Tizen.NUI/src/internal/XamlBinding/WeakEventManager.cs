/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
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
using static System.String;

namespace Tizen.NUI.Binding
{
    internal class WeakEventManager
    {
        readonly Dictionary<string, List<Subscription>> eventHandlers = new Dictionary<string, List<Subscription>>();

        public void AddEventHandler<TEventArgs>(string eventName, EventHandler<TEventArgs> handler)
            where TEventArgs : EventArgs
        {
            if (IsNullOrEmpty(eventName))
            {
                throw new ArgumentNullException(nameof(eventName));
            }

            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            AddEventHandler(eventName, handler.Target, handler.GetMethodInfo());
        }

        public void AddEventHandler(string eventName, EventHandler handler)
        {
            if (IsNullOrEmpty(eventName))
            {
                throw new ArgumentNullException(nameof(eventName));
            }

            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            AddEventHandler(eventName, handler.Target, handler.GetMethodInfo());
        }

        public void HandleEvent(object sender, object args, string eventName)
        {
            var toRaise = new List<Tuple<object, MethodInfo>>();
            var toRemove = new List<Subscription>();

            List<Subscription> target;
            if (eventHandlers.TryGetValue(eventName, out target))
            {
                foreach (Subscription subscription in target)
                {
                    bool isStatic = subscription.Subscriber == null;
                    if (isStatic)
                    {
                        // For a static method, we'll just pass null as the first parameter of MethodInfo.Invoke
                        toRaise.Add(Tuple.Create<object, MethodInfo>(null, subscription.Handler));
                        continue;
                    }

                    object subscriber = subscription.Subscriber.Target;

                    if (subscriber == null)
                    {
                        // The subscriber was collected, so there's no need to keep this subscription around
                        toRemove.Add(subscription);
                    }
                    else
                    {
                        toRaise.Add(Tuple.Create(subscriber, subscription.Handler));
                    }
                }

                foreach (Subscription subscription in toRemove)
                {
                    target.Remove(subscription);
                }
            }

            foreach (Tuple<object, MethodInfo> tuple in toRaise)
            {
                tuple.Item2.Invoke(tuple.Item1, new[] { sender, args });
            }
        }

        public void RemoveEventHandler<TEventArgs>(string eventName, EventHandler<TEventArgs> handler)
            where TEventArgs : EventArgs
        {
            if (IsNullOrEmpty(eventName))
            {
                throw new ArgumentNullException(nameof(eventName));
            }

            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            RemoveEventHandler(eventName, handler.Target, handler.GetMethodInfo());
        }

        public void RemoveEventHandler(string eventName, EventHandler handler)
        {
            if (IsNullOrEmpty(eventName))
            {
                throw new ArgumentNullException(nameof(eventName));
            }

            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            RemoveEventHandler(eventName, handler.Target, handler.GetMethodInfo());
        }

        void AddEventHandler(string eventName, object handlerTarget, MethodInfo methodInfo)
        {
            List<Subscription> targets;
            if (!eventHandlers.TryGetValue(eventName, out targets))
            {
                targets = new List<Subscription>();
                eventHandlers.Add(eventName, targets);
            }

            if (handlerTarget == null)
            {
                // This event handler is a static method
                targets.Add(new Subscription(null, methodInfo));
                return;
            }

            targets.Add(new Subscription(new WeakReference(handlerTarget), methodInfo));
        }

        void RemoveEventHandler(string eventName, object handlerTarget, MemberInfo methodInfo)
        {
            List<Subscription> subscriptions;
            if (!eventHandlers.TryGetValue(eventName, out subscriptions))
            {
                return;
            }

            for (int n = subscriptions.Count; n > 0; n--)
            {
                Subscription current = subscriptions[n - 1];

                if (current.Subscriber != handlerTarget
                    || current.Handler.Name != methodInfo.Name)
                {
                    continue;
                }

                subscriptions.Remove(current);
            }
        }

        struct Subscription
        {
            public Subscription(WeakReference subscriber, MethodInfo handler)
            {
                if (handler == null)
                {
                    throw new ArgumentNullException(nameof(handler));
                }

                Subscriber = subscriber;
                Handler = handler;
            }

            public readonly WeakReference Subscriber;
            public readonly MethodInfo Handler;
        }
    }
}
