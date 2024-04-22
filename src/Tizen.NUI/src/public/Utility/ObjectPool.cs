/*
 * Copyright(c) 2024 Samsung Electronics Co., Ltd.
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
#if OBJECT_POOL

using System;
using System.ComponentModel;
using System.Collections.Generic;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    /// <summary>
    /// Provides a pool of objects that can be reused to improve performance and reduce memory usage.
    /// </summary>
    /// <typeparam name="T">The type of object to pool.</typeparam>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class ObjectPool<T> : IDisposable
    {
        private static Stack<T> s_pool = new Stack<T>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectPool{T}"/> class.
        /// </summary>
        /// <param name="value">The initial value of the object.</param>
        public ObjectPool(T value) 
        {
            Value = value;
        }

        /// <summary>
        /// Gets the current value of the object.
        /// </summary>
        public T Value { get; }

        /// <summary>
        /// Releases the object back into the pool.
        /// </summary>
        public void Dispose()
        {
            if (Value != null)
            {
                s_pool.Push(Value);
            }
        }

        /// <summary>
        /// Creates a new object from the pool or creates a new instance if the pool is empty.
        /// </summary>
        /// <returns>A new object from the pool or a new instance if the pool is empty.</returns>
        public static ObjectPool<T> New()
        {
            if (s_pool.Count > 0 && s_pool.TryPop(out T value))
            {
                return new ObjectPool<T>(value);
            }
            return null;
        }

        /// <summary>
        /// Implicitly converts the object pool to its underlying value.
        /// </summary>
        /// <param name="obj">The object pool to convert.</param>
        public static implicit operator T(ObjectPool<T> obj)
        {
            return obj.Value;
        }

        /// <summary>
        /// Gets the number of objects currently in the pool.
        /// </summary>
        public static int Count => s_pool.Count;
    }

    /// <summary>
    /// Provides a set of static methods for creating new object pools.
    /// </summary>
    internal static class ObjectPool
    {
        /// <summary>
        /// Creates a new object pool for KeyEventArgs objects.
        /// </summary>
        /// <returns>A new object pool.</returns>
        public static ObjectPool<View.KeyEventArgs> NewKeyEventArgs()
        {
            return ObjectPool<View.KeyEventArgs>.New() ?? new ObjectPool<View.KeyEventArgs>(new View.KeyEventArgs());
        }

        /// <summary>
        /// Creates a new object pool for KeyEventArgs objects with the specified values.
        /// </summary>
        /// <param name="nativeHandle">The native handle for Key instance.</param>
        /// <returns>A new object pool.</returns>
        public static ObjectPool<View.KeyEventArgs> NewKeyEventArgs(IntPtr nativeHandle)
        {
            var obj = NewKeyEventArgs();
            NUILog.Debug($"ObjectPool<View.KeyEventArgs>NewKeyEventArgs() Count={ObjectPool<View.KeyEventArgs>.Count}");
            obj.Value.Key = Key.NewKey(nativeHandle);
            return obj;
        }

        /// <summary>
        /// Creates a new object pool for PropertyValue objects.
        /// </summary>
        /// <returns>A new object pool.</returns>
        public static ObjectPool<PropertyValue> NewPropertyValue()
        {
            return ObjectPool<PropertyValue>.New() ?? new ObjectPool<PropertyValue>(new PropertyValue());
        }

        /// <summary>
        /// Creates a new object pool for PropertyValue objects.
        /// </summary>
        /// <returns>A new object pool.</returns>
        public static ObjectPool<PropertyMap> NewPropertyMap()
        {
            var tmp = ObjectPool<PropertyMap>.New();
            if(tmp == null)
            {
                tmp = new ObjectPool<PropertyMap>(new PropertyMap());
            }
            else
            {
                tmp.Value.Clear();
            }
            NUILog.Debug($"ObjectPool<PropertyMap> NewPropertyMap() Count={ObjectPool<PropertyMap>.Count}");
            return tmp;
        }

    }
}
#endif

