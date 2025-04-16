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
using static Tizen.NUI.Shader.Hint;

namespace Tizen.NUI
{
    /// <summary>
    /// Provides a pool of objects that can be reused to improve performance and reduce memory usage.
    /// It is used for the object that is not Disposable.
    /// </summary>
    /// <typeparam name="T">The type of object to pool.</typeparam>
    internal class ObjectPool<T>
    {
        private readonly int MaxPoolSize;
        private readonly Func<T> objectCreator;
        private readonly Stack<T> pool;

        public ObjectPool(Func<T> creator, int size)
        {
            objectCreator = creator ?? throw new ArgumentNullException(nameof(creator));
            MaxPoolSize = size;
            pool = new Stack<T>();
        }

        public void Get(Action<T> action)
        {
            if (!pool.TryPop(out T value))
            {
                value = objectCreator();
            }
            action(value);
            Push(value);
        }

        public R Get<TArg1, R>(Func<T, TArg1, R> action, TArg1 arg1)
        {
            if (!pool.TryPop(out T value))
            {
                value = objectCreator();
            }
            R result = action(value, arg1);
            Push(value);
            return result;
        }

        public R Get<TArg1, TArg2, R>(Func<T, TArg1, TArg2, R> action, TArg1 arg1, TArg2 arg2)
        {
            if (!pool.TryPop(out T value))
            {
                value = objectCreator();
            }
            R result = action(value, arg1, arg2);
            Push(value);
            return result;
        }

        private void Push(T value)
        {
            if (value == null)
            {
                return;
            }
            if (pool.Count < MaxPoolSize)
            {
                pool.Push(value);
            }
        }
    }
}
