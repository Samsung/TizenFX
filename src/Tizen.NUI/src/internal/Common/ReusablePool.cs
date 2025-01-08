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

namespace Tizen.NUI
{
    /// <summary>
    /// Provide methods to reuse `Disposable` primitive data such as Color and Size.
    /// Please be aware that this class is not thread-safe.
    /// </summary>
    internal static class ReusablePool<T> where T : Disposable, new()
    {
        private const int MaxPoolSize = 3;
        private static readonly Stack<T> pool = new ();

        /// <summary>
        /// Get available instance from pool or create new one.
        /// The passed instance only valid in action scope.
        /// </summary>
        public static void GetOne(Action<T> action)
        {
            if (!pool.TryPop(out T value))
            {
                value = new T();
            }
            action(value);
            Push(value);
        }

        /// <summary>
        /// Get available instance from pool or create new one.
        /// The passed instance only valid in action scope.
        /// </summary>
        /// <remarks>
        /// This method is to avoid generating closure and action instance every time when using lambda expression.
        /// It's better to use this method when possible.
        /// </remarks>
        public static void GetOne<TArg>(Action<T, TArg> action, TArg arg)
        {
            if (!pool.TryPop(out T value))
            {
                value = new T();
            }
            action(value, arg);
            Push(value);
        }

        /// <summary>
        /// Get available instance from pool or create new one.
        /// The passed instance only valid in action scope.
        /// </summary>
        /// <remarks>
        /// This method is to avoid generating closure and action instance every time when using lambda expression.
        /// It's better to use this method when possible.
        /// </remarks>
        public static void GetOne<TArg1, TArg2>(Action<T, TArg1, TArg2> action, TArg1 arg1, TArg2 arg2)
        {
            if (!pool.TryPop(out T value))
            {
                value = new T();
            }
            action(value, arg1, arg2);
            Push(value);
        }

        /// <summary>
        /// Get available instance from pool or create new one.
        /// The passed instance only valid in action scope.
        /// </summary>
        /// <remarks>
        /// This method is to avoid generating closure and action instance every time when using lambda expression.
        /// It's better to use this method when possible.
        /// </remarks>
        public static void GetOne<TArg1, TArg2, TArg3>(Action<T, TArg1, TArg2, TArg3> action, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        {
            if (!pool.TryPop(out T value))
            {
                value = new T();
            }
            action(value, arg1, arg2, arg3);
            Push(value);
        }

        /// <summary>
        /// Get available instance from pool or create new one.
        /// The passed instance only valid in action scope.
        /// </summary>
        public static R GetOne<R>(Func<T, R> action)
        {
            if (!pool.TryPop(out T value))
            {
                value = new T();
            }
            R result = action(value);
            Push(value);
            return result;
        }

        /// <summary>
        /// Get available instance from pool or create new one.
        /// The passed instance only valid in action scope.
        /// </summary>
        /// <remarks>
        /// This method is to avoid generating closure and action instance every time when using lambda expression.
        /// It's better to use this method when possible.
        /// </remarks>
        public static R GetOne<TArg, R>(Func<T, TArg, R> action, TArg arg)
        {
            if (!pool.TryPop(out T value))
            {
                value = new T();
            }
            R result = action(value, arg);
            Push(value);
            return result;
        }

        /// <summary>
        /// Get available instance from pool or create new one.
        /// The passed instance only valid in action scope.
        /// </summary>
        /// <remarks>
        /// This method is to avoid generating closure and action instance every time when using lambda expression.
        /// It's better to use this method when possible.
        /// </remarks>
        public static R GetOne<TArg1, TArg2, R>(Func<T, TArg1, TArg2, R> action, TArg1 arg1, TArg2 arg2)
        {
            if (!pool.TryPop(out T value))
            {
                value = new T();
            }
            R result = action(value, arg1, arg2);
            Push(value);
            return result;
        }

        /// <summary>
        /// Get available instance from pool or create new one.
        /// The passed instance only valid in action scope.
        /// </summary>
        /// <remarks>
        /// This method is to avoid generating closure and action instance every time when using lambda expression.
        /// It's better to use this method when possible.
        /// </remarks>
        public static R GetOne<TArg1, TArg2, TArg3, R>(Func<T, TArg1, TArg2, TArg3, R> action, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        {
            if (!pool.TryPop(out T value))
            {
                value = new T();
            }
            R result = action(value, arg1, arg2, arg3);
            Push(value);
            return result;
        }

        static void Push(T value)
        {
            if (value == null || value.IsDisposeQueued)
            {
                return;
            }

            if (pool.Count < MaxPoolSize)
            {
                pool.Push(value);
            }
            else
            {
                value.Dispose();
            }
        }
    }
}
