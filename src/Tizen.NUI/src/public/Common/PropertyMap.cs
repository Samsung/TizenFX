/*
 * Copyright(c) 2019 Samsung Electronics Co., Ltd.
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
using System.ComponentModel;

namespace Tizen.NUI
{
    /// <summary>
    /// A map of property values, the key type could be string or Property::Index.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class PropertyMap : Disposable
    {

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap() : this(Interop.PropertyMap.NewPropertyMap(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The copy constructor.
        /// </summary>
        /// <param name="other">The map to copy from.</param>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap(PropertyMap other) : this(Interop.PropertyMap.NewPropertyMap(PropertyMap.getCPtr(other)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal PropertyMap(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// The operator to access the element with the specified string key.<br />
        /// If an element with the key does not exist, then it is created.<br />
        /// </summary>
        /// <param name="key">The key whose value to access.</param>
        /// <returns>A value for the element with the specified key.</returns>
        /// <since_tizen> 3 </since_tizen>
        public PropertyValue this[string key]
        {
            get
            {
                return ValueOfIndex(key);
            }
            internal set
            {
                SetValue(key, value);
            }
        }

        /// <summary>
        /// The operator to access the element with the specified index key.<br />
        /// If an element with the key does not exist, then it is created.<br />
        /// </summary>
        /// <param name="key">The key whose value to access.</param>
        /// <returns>A value for the element with the specified key.</returns>
        /// <since_tizen> 3 </since_tizen>
        public PropertyValue this[int key]
        {
            get
            {
                return ValueOfIndex(key);
            }
            internal set
            {
                SetValue(key, value);
            }
        }

        /// <summary>
        /// Retrieves the number of elements in the map.
        /// </summary>
        /// <returns>The number of elements in the map.</returns>
        /// <since_tizen> 3 </since_tizen>
        public uint Count()
        {
            uint ret = Interop.PropertyMap.Count(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Returns whether the map is empty.
        /// </summary>
        /// <returns>Returns true if empty, false otherwise.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool Empty()
        {
            bool ret = Interop.PropertyMap.Empty(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Inserts the key-value pair in the map, with the key type as string.<br />
        /// Does not check for duplicates.<br />
        /// </summary>
        /// <param name="key">The key to insert.</param>
        /// <param name="value">The value to insert.</param>
        /// <since_tizen> 3 </since_tizen>
        public void Insert(string key, PropertyValue value)
        {
            Interop.PropertyMap.Insert(SwigCPtr, key, PropertyValue.getCPtr(value));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Inserts the key-value pair in the map, with the key type as index.<br />
        /// Does not check for duplicates.<br />
        /// </summary>
        /// <param name="key">The key to insert.</param>
        /// <param name="value">The value to insert.</param>
        /// <since_tizen> 3 </since_tizen>
        public void Insert(int key, PropertyValue value)
        {
            Interop.PropertyMap.Insert(SwigCPtr, key, PropertyValue.getCPtr(value));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Inserts the key-value pair in the map, with the key type as string.<br />
        /// Does not check for duplicates.<br />
        /// </summary>
        /// <param name="key">The key to insert.</param>
        /// <param name="value">The value to insert.</param>
        /// <returns>Returns a reference to this object.</returns>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap Add(string key, PropertyValue value)
        {
            Interop.PropertyMap.Add(SwigCPtr, key, PropertyValue.getCPtr(value));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return this;
        }

        /// <summary>
        /// Inserts the key-value pair in the map, with the key type as string.<br />
        /// Does not check for duplicates.<br />
        /// </summary>
        /// <param name="key">The key to insert.</param>
        /// <param name="value">The value to insert.</param>
        /// <returns>Returns a reference to this object.</returns>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap Add(int key, PropertyValue value)
        {
            Interop.PropertyMap.Add(SwigCPtr, key, PropertyValue.getCPtr(value));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return this;
        }

        /// <summary>
        /// Inserts the keyvalue to the map.<br />
        /// Does not check for duplicates.<br />
        /// </summary>
        /// <param name="keyValue">The keyvalue to insert.</param>
        /// <returns>Returns a reference to this object.</returns>
        /// <exception cref="global::System.ArgumentNullException"> Thrown when keyValue is null. </exception>
        public PropertyMap Add(KeyValue keyValue)
        {
            if (null == keyValue)
            {
                throw new global::System.ArgumentNullException(nameof(keyValue));
            }
            if (keyValue.KeyInt != null)
            {
                Interop.PropertyMap.Add(SwigCPtr, (int)keyValue.KeyInt, PropertyValue.getCPtr(keyValue.TrueValue));
            }
            else if (keyValue.KeyString != null)
            {
                Interop.PropertyMap.Add(SwigCPtr, keyValue.KeyString, PropertyValue.getCPtr(keyValue.TrueValue));
            }
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            return this;
        }

        /// <summary>
        /// Retrieves the value at the specified position.
        /// </summary>
        /// <param name="position">The specified position.</param>
        /// <returns>A reference to the value at the specified position.</returns>
        /// <since_tizen> 3 </since_tizen>
        public PropertyValue GetValue(uint position)
        {
            PropertyValue ret = new PropertyValue(Interop.PropertyMap.GetValue(SwigCPtr, position), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves the key at the specified position.
        /// </summary>
        /// <param name="position">The specified position.</param>
        /// <returns>A copy of the key at the specified position.</returns>
        /// <since_tizen> 3 </since_tizen>
        public PropertyKey GetKeyAt(uint position)
        {
            PropertyKey ret = new PropertyKey(Interop.PropertyMap.GetKeyAt(SwigCPtr, position), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Finds the value for the specified key if it exists.
        /// </summary>
        /// <param name="key">The key to find.</param>
        /// <returns>The value if it exists, an empty object otherwise.</returns>
        /// <since_tizen> 3 </since_tizen>
        public PropertyValue Find(int key)
        {
            global::System.IntPtr cPtr = Interop.PropertyMap.Find(SwigCPtr, key);
            PropertyValue ret = (cPtr == global::System.IntPtr.Zero) ? null : new PropertyValue(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Finds the value for the specified keys if either exist.
        /// </summary>
        /// <param name="indexKey">The index key to find.</param>
        /// <param name="stringKey">The string key to find.</param>
        /// <returns>The value if it exists, an empty object otherwise.</returns>
        /// <since_tizen> 3 </since_tizen>
        public PropertyValue Find(int indexKey, string stringKey)
        {
            global::System.IntPtr cPtr = Interop.PropertyMap.Find(SwigCPtr, indexKey, stringKey);
            PropertyValue ret = (cPtr == global::System.IntPtr.Zero) ? null : new PropertyValue(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Clears the map.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Clear()
        {
            Interop.PropertyMap.Clear(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Merges values from the map 'from' to the current.<br />
        /// Any values in 'from' will overwrite the values in the current map.<br />
        /// </summary>
        /// <param name="from">The map to merge from.</param>
        /// <since_tizen> 3 </since_tizen>
        public void Merge(PropertyMap from)
        {
            Interop.PropertyMap.Merge(SwigCPtr, PropertyMap.getCPtr(from));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Retrieves the element with the specified string key.
        /// </summary>
        /// <param name="key">The key whose value to retrieve.</param>
        /// <returns>The value for the element with the specified key.</returns>
        internal PropertyValue ValueOfIndex(string key)
        {
            PropertyValue ret = new PropertyValue(Interop.PropertyMap.ValueOfIndex(SwigCPtr, key), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves the element with the specified index key.
        /// </summary>
        /// <param name="key">The key whose value to retrieve.</param>
        /// <returns>The value for the element with the specified key.</returns>
        internal PropertyValue ValueOfIndex(int key)
        {
            PropertyValue ret = new PropertyValue(Interop.PropertyMap.ValueOfIndex(SwigCPtr, key), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(PropertyMap obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        internal void SetValue(int key, PropertyValue value)
        {
            Interop.PropertyMap.SetValueIntKey(SwigCPtr, key, PropertyValue.getCPtr(value));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetValue(string key, PropertyValue value)
        {
            Interop.PropertyMap.SetValueStringKey(SwigCPtr, key, PropertyValue.getCPtr(value));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.PropertyMap.DeletePropertyMap(swigCPtr);
        }
    }

    internal static class PropertyMapSetterHelper
    {
        internal static PropertyMap Add<T>(this PropertyMap propertyMap, int key, T value)
        {
            using (var pv = PropertyValue.CreateFromObject(value))
            {
                propertyMap.Add(key, pv);
            }
            return propertyMap;
        }

        internal static PropertyMap Add<T>(this PropertyMap propertyMap, string key, T value)
        {
            using (var pv = PropertyValue.CreateFromObject(value))
            {
                propertyMap.Add(key, pv);
            }
            return propertyMap;
        }
    }
}
