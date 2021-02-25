/*
 * Copyright (c) 2021 Samsung Electronics Co., Ltd.
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
using System.Reflection;

namespace Tizen.NUI
{
    internal sealed class WeakEventHandler<TEventArgs> where TEventArgs : EventArgs
    {
        private readonly WeakReference targetReference;
        private readonly MethodInfo method;

        public WeakEventHandler(EventHandler<TEventArgs> callback)
        {
            method = callback.GetMethodInfo();
            targetReference = new WeakReference(callback.Target, true);
        }

        public void Handler(object sender, TEventArgs e)
        {
            var target = targetReference.Target;
            if (target != null)
            {
                var callback = (Action<object, TEventArgs>)method.CreateDelegate(typeof(Action<object, TEventArgs>), target);
                if (callback != null)
                {
                    callback(sender, e);
                }
            }
        }
    }
}

