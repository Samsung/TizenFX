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
using System.Collections.Generic;
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
        /// Default constructor of PropertyMap class.
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
        /// Retrieves all keys.
        /// </summary>
        /// <returns>A list of keys.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<PropertyKey> Keys
        {
            get
            {
                List<PropertyKey> keys = new List<PropertyKey>();
                for (uint i = 0; i < Count(); i++)
                {
                    keys.Add(GetKeyAt(i));
                }
                return keys;
            }
        }

        /// <summary>
        /// Retrieves all values.
        /// </summary>
        /// <returns>A list of values.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<PropertyValue> Values
        {
            get
            {
                List<PropertyValue> values = new List<PropertyValue>();
                for (uint i = 0; i < Count(); i++)
                {
                    values.Add(GetValue(i));
                }
                return values;
            }
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
            set
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
            set
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
        /// The error message would be shown if the pair with the same key already exists.
        /// </summary>
        /// <param name="key">The key to insert.</param>
        /// <param name="value">The value to insert.</param>
        /// <since_tizen> 3 </since_tizen>
        public void Insert(string key, PropertyValue value)
        {
            global::System.IntPtr cPtr = Interop.PropertyMap.Find(SwigCPtr, key);
            if (cPtr != global::System.IntPtr.Zero)
            {
                Tizen.Log.Error("NUI", $"The key {key} already exists. please do not use duplicate key");
            }
            Interop.PropertyMap.Insert(SwigCPtr, key, PropertyValue.getCPtr(value));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Inserts the key-value pair in the map, with the key type as index.<br />
        /// The error message would be shown if the pair with the same key already exists.
        /// </summary>
        /// <param name="key">The key to insert.</param>
        /// <param name="value">The value to insert.</param>
        /// <since_tizen> 3 </since_tizen>
        public void Insert(int key, PropertyValue value)
        {
            global::System.IntPtr cPtr = Interop.PropertyMap.Find(SwigCPtr, key);
            if (cPtr != global::System.IntPtr.Zero)
            {
                Tizen.Log.Error("NUI", $"The key {key} already exists. please do not use duplicate key");
            }
            Interop.PropertyMap.Insert(SwigCPtr, key, PropertyValue.getCPtr(value));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Inserts the key-value pair in the map, with the key type as string.<br />
        /// The error message would be shown if the pair with the same key already exists.
        /// </summary>
        /// <param name="key">The key to insert.</param>
        /// <param name="value">The value to insert.</param>
        /// <returns>Returns a reference to this object.</returns>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap Add(string key, PropertyValue value)
        {
            global::System.IntPtr cPtr = Interop.PropertyMap.Find(SwigCPtr, key);
            if (cPtr != global::System.IntPtr.Zero)
            {
                Tizen.Log.Error("NUI", $"The key {key} already exists. please do not use duplicate key");
            }
            Interop.PropertyMap.Add(SwigCPtr, key, PropertyValue.getCPtr(value));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return this;
        }

        /// <summary>
        /// Inserts the key-value pair in the map, with the key type as string.<br />
        /// The error message would be shown if the pair with the same key already exists.
        /// </summary>
        /// <param name="key">The key to insert.</param>
        /// <param name="value">The value to insert.</param>
        /// <returns>Returns a reference to this object.</returns>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap Add(int key, PropertyValue value)
        {
            global::System.IntPtr cPtr = Interop.PropertyMap.Find(SwigCPtr, key);
            if (cPtr != global::System.IntPtr.Zero)
            {
                Tizen.Log.Error("NUI", $"The key {key} already exists. please do not use duplicate key");
            }
            Interop.PropertyMap.Add(SwigCPtr, key, PropertyValue.getCPtr(value));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return this;
        }

        /// <summary>
        /// Inserts the keyvalue to the map.<br />
        /// The exception would be thrown if the pair with the same key already exists.
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
            if (keyValue.IntegerKey != null)
            {
                Add((int)keyValue.IntegerKey, keyValue.PropertyValue);
            }
            else if (keyValue.StringKey != null)
            {
                Add(keyValue.StringKey, keyValue.PropertyValue);
            }

            return this;
        }

        /// <summary>
        /// Append the key-value pair to the map.
        /// Does not check for duplicates.
        /// </summary>
        /// <param name="key">The key to insert.</param>
        /// <param name="value">The value to insert.</param>
        /// <returns>Returns a reference to this object.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyMap Append(int key, bool value)
        {
            Interop.PropertyMap.AddBool(SwigCPtr, key, value);
            NDalicPINVOKE.ThrowExceptionIfExists();
            return this;
        }

        /// <summary>
        /// Append the key-value pair to the map.
        /// Does not check for duplicates.
        /// </summary>
        /// <param name="key">The key to insert.</param>
        /// <param name="value">The value to insert.</param>
        /// <returns>Returns a reference to this object.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyMap Append(int key, int value)
        {
            Interop.PropertyMap.AddInt(SwigCPtr, key, value);
            NDalicPINVOKE.ThrowExceptionIfExists();
            return this;
        }

        /// <summary>
        /// Append the key-value pair to the map.
        /// Does not check for duplicates.
        /// </summary>
        /// <param name="key">The key to insert.</param>
        /// <param name="value">The value to insert.</param>
        /// <returns>Returns a reference to this object.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyMap Append(int key, float value)
        {
            Interop.PropertyMap.AddFloat(SwigCPtr, key, value);
            NDalicPINVOKE.ThrowExceptionIfExists();
            return this;
        }

        /// <summary>
        /// Append the key-value pair to the map.
        /// Does not check for duplicates.
        /// </summary>
        /// <param name="key">The key to insert.</param>
        /// <param name="value">The value to insert.</param>
        /// <returns>Returns a reference to this object.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyMap Append(int key, string value)
        {
            if (AppendNoneIfNull(key, value))
            {
                return this;
            }
            Interop.PropertyMap.AddString(SwigCPtr, key, value);
            NDalicPINVOKE.ThrowExceptionIfExists();
            return this;
        }

        /// <summary>
        /// Append the key-value pair to the map.
        /// Does not check for duplicates.
        /// </summary>
        /// <param name="key">The key to insert.</param>
        /// <param name="value">The value to insert.</param>
        /// <returns>Returns a reference to this object.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyMap Append(int key, Vector2 value)
        {
            if (AppendNoneIfNull(key, value))
            {
                return this;
            }
            Interop.PropertyMap.AddVector2(SwigCPtr, key, getCPtr(value));
            NDalicPINVOKE.ThrowExceptionIfExists();
            return this;
        }

        /// <summary>
        /// Append the key-value pair to the map.
        /// Does not check for duplicates.
        /// </summary>
        /// <param name="key">The key to insert.</param>
        /// <param name="value">The value to insert.</param>
        /// <returns>Returns a reference to this object.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyMap Append(int key, UIVector2 value)
        {
            Interop.PropertyMap.AddVector2(SwigCPtr, key, value.X, value.Y);
            NDalicPINVOKE.ThrowExceptionIfExists();
            return this;
        }

        /// <summary>
        /// Append the key-value pair to the map.
        /// Does not check for duplicates.
        /// </summary>
        /// <param name="key">The key to insert.</param>
        /// <param name="value">The value to insert.</param>
        /// <returns>Returns a reference to this object.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyMap Append(int key, Vector3 value)
        {
            if (AppendNoneIfNull(key, value))
            {
                return this;
            }
            Interop.PropertyMap.AddVector3(SwigCPtr, key, getCPtr(value));
            NDalicPINVOKE.ThrowExceptionIfExists();
            return this;
        }

        /// <summary>
        /// Append the key-value pair to the map.
        /// Does not check for duplicates.
        /// </summary>
        /// <param name="key">The key to insert.</param>
        /// <param name="value">The value to insert.</param>
        /// <returns>Returns a reference to this object.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyMap Append(int key, Vector4 value)
        {
            if (AppendNoneIfNull(key, value))
            {
                return this;
            }
            Interop.PropertyMap.AddVector4(SwigCPtr, key, getCPtr(value));
            NDalicPINVOKE.ThrowExceptionIfExists();
            return this;
        }

        /// <summary>
        /// Append the key-value pair to the map.
        /// Does not check for duplicates.
        /// </summary>
        /// <param name="key">The key to insert.</param>
        /// <param name="value">The value to insert.</param>
        /// <returns>Returns a reference to this object.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyMap Append(int key, UIColor value)
        {
            Interop.PropertyMap.AddVector4(SwigCPtr, key, value.R, value.G, value.B, value.A);
            NDalicPINVOKE.ThrowExceptionIfExists();
            return this;
        }

        /// <summary>
        /// Append the key-value pair to the map.
        /// Does not check for duplicates.
        /// </summary>
        /// <param name="key">The key to insert.</param>
        /// <param name="value">The value to insert.</param>
        /// <returns>Returns a reference to this object.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyMap Append(int key, UICorner value)
        {
            Interop.PropertyMap.AddVector4(SwigCPtr, key, value.TopLeft, value.TopRight, value.BottomRight, value.BottomLeft);
            NDalicPINVOKE.ThrowExceptionIfExists();
            return this;
        }

        /// <summary>
        /// Append the key-value pair to the map.
        /// Does not check for duplicates.
        /// </summary>
        /// <param name="key">The key to insert.</param>
        /// <param name="value">The value to insert.</param>
        /// <returns>Returns a reference to this object.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyMap Append(int key, PropertyMap value)
        {
            if (AppendNoneIfNull(key, value))
            {
                return this;
            }
            Interop.PropertyMap.AddPropertyMap(SwigCPtr, key, getCPtr(value));
            NDalicPINVOKE.ThrowExceptionIfExists();
            return this;
        }


        /// <summary>
        /// Removes the element by the specified key.
        /// </summary>
        /// <param name="key">The index key to find.</param>
        /// <returns>True if the element is removed, false otherwise.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Remove(PropertyKey key)
        {
            if (null == key)
            {
                throw new global::System.ArgumentNullException(nameof(key));
            }
            bool isRemoved = false;
            if (key.Type == PropertyKey.KeyType.Index)
            {
                isRemoved = Interop.PropertyMap.Remove(SwigCPtr, key.IndexKey);
            }
            else if(key.Type == PropertyKey.KeyType.String)
            {
                isRemoved = Interop.PropertyMap.Remove(SwigCPtr, key.StringKey);
            }
            return isRemoved;
        }

        /// <summary>
        /// Removes the element by the specified integer key.
        /// </summary>
        /// <param name="key">The index key to find.</param>
        /// <returns>True if the element is removed, false otherwise.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Remove(int key)
        {
            return Interop.PropertyMap.Remove(SwigCPtr, key);
        }

        /// <summary>
        /// Determines whether the PropertyMap contains the specified key.
        /// </summary>
        /// <param name="key">The index key to find.</param>
        /// <returns>True if it exists, false otherwise.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Contains(PropertyKey key)
        {
            if (null == key)
            {
                throw new global::System.ArgumentNullException(nameof(key));
            }
            global::System.IntPtr cPtr = global::System.IntPtr.Zero;
            if (key.Type == PropertyKey.KeyType.Index)
            {
                cPtr = Interop.PropertyMap.Find(SwigCPtr, key.IndexKey);
            }
            else if (key.Type == PropertyKey.KeyType.String)
            {
                cPtr = Interop.PropertyMap.Find(SwigCPtr, key.StringKey);
            }
            return cPtr != global::System.IntPtr.Zero;
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
        /// Finds the value for the specified string key if it exists.
        /// </summary>
        /// <param name="stringKey">The string key to find.</param>
        /// <returns>The value if it exists, an empty object otherwise.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyValue Find(string stringKey)
        {
            global::System.IntPtr cPtr = Interop.PropertyMap.Find(SwigCPtr, stringKey);
            PropertyValue ret = (cPtr == global::System.IntPtr.Zero) ? null : new PropertyValue(cPtr, false);
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
        /// This method removes all key-value pairs from the PropertyMap.
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
            if (from == null)
            {
                throw new global::System.ArgumentNullException(nameof(from));
            }
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

        internal void SetValue(PropertyKey key, PropertyValue value)
        {
            if (key.Type == PropertyKey.KeyType.Index)
            {
                Interop.PropertyMap.SetValueIntKey(SwigCPtr, key.IndexKey, PropertyValue.getCPtr(value));
            }
            else if (key.Type == PropertyKey.KeyType.String)
            {
                Interop.PropertyMap.SetValueStringKey(SwigCPtr, key.StringKey, PropertyValue.getCPtr(value));
            }
            NDalicPINVOKE.ThrowExceptionIfExists();
        }

        internal void SetValue(int key, PropertyValue value)
        {
            Interop.PropertyMap.SetValueIntKey(SwigCPtr, key, PropertyValue.getCPtr(value));
            NDalicPINVOKE.ThrowExceptionIfExists();
        }

        internal void SetValue(string key, PropertyValue value)
        {
            Interop.PropertyMap.SetValueStringKey(SwigCPtr, key, PropertyValue.getCPtr(value));
            NDalicPINVOKE.ThrowExceptionIfExists();
        }

        internal PropertyMap Add(string key, PropertyMap propertyMapValue)
        {
            using var propertyValue = new PropertyValue(propertyMapValue);
            return Add(key, propertyValue);
        }

        internal PropertyMap Add(int key, PropertyMap propertyMapValue)
        {
            using var propertyValue = new PropertyValue(propertyMapValue);
            return Add(key, propertyValue);
        }

        internal PropertyMap Add(string key, PropertyArray propertyArrayValue)
        {
            using var propertyValue = new PropertyValue(propertyArrayValue);
            return Add(key, propertyValue);
        }

        internal PropertyMap Add(int key, PropertyArray propertyArrayValue)
        {
            using var propertyValue = new PropertyValue(propertyArrayValue);
            return Add(key, propertyValue);
        }

        #region Add Vector2 value
        internal PropertyMap Add(int key, Vector2 value)
        {
            global::System.IntPtr cPtr = Interop.PropertyMap.Find(SwigCPtr, key);
            if (cPtr != global::System.IntPtr.Zero)
            {
                Tizen.Log.Error("NUI", $"The key {key} already exists. please do not use duplicate key");
            }

            if (null == value)
            {
                Interop.PropertyMap.AddNone(SwigCPtr, key);
            }
            else
            {
                Interop.PropertyMap.AddVector2(SwigCPtr, key, value.X, value.Y);
            }

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return this;
        }

        internal PropertyMap Add(string key, Vector2 value)
        {
            global::System.IntPtr cPtr = Interop.PropertyMap.Find(SwigCPtr, key);
            if (cPtr != global::System.IntPtr.Zero)
            {
                Tizen.Log.Error("NUI", $"The key {key} already exists. please do not use duplicate key");
            }

            if (null == value)
            {
                Interop.PropertyMap.AddNone(SwigCPtr, key);
            }
            else
            {
                Interop.PropertyMap.AddVector2(SwigCPtr, key, value.X, value.Y);
            }

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return this;
        }

        internal PropertyMap Set(int key, Vector2 value)
        {
            if (null == value)
            {
                Interop.PropertyMap.SetNone(SwigCPtr, key);
            }
            else
            {
                Interop.PropertyMap.SetVector2(SwigCPtr, key, value.X, value.Y);
            }

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return this;
        }

        internal PropertyMap Set(string key, Vector2 value)
        {
            if (null == value)
            {
                Interop.PropertyMap.SetNone(SwigCPtr, key);
            }
            else
            {
                Interop.PropertyMap.SetVector2(SwigCPtr, key, value.X, value.Y);
            }

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return this;
        }
        #endregion

        #region Add Vector3 value
        internal PropertyMap Add(int key, Vector3 value)
        {
            global::System.IntPtr cPtr = Interop.PropertyMap.Find(SwigCPtr, key);
            if (cPtr != global::System.IntPtr.Zero)
            {
                Tizen.Log.Error("NUI", $"The key {key} already exists. please do not use duplicate key");
            }

            if (null == value)
            {
                Interop.PropertyMap.AddNone(SwigCPtr, key);
            }
            else
            {
                Interop.PropertyMap.AddVector3(SwigCPtr, key, getCPtr(value));
            }

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return this;
        }
        #endregion

        #region Add/Set Vector4 value
        internal PropertyMap Add(int key, Vector4 value)
        {
            global::System.IntPtr cPtr = Interop.PropertyMap.Find(SwigCPtr, key);
            if (cPtr != global::System.IntPtr.Zero)
            {
                Tizen.Log.Error("NUI", $"The key {key} already exists. please do not use duplicate key");
            }

            if (null == value)
            {
                Interop.PropertyMap.AddNone(SwigCPtr, key);
            }
            else
            {
                Interop.PropertyMap.AddVector4(SwigCPtr, key, value.X, value.Y, value.Z, value.W);
            }

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return this;
        }

        internal PropertyMap Add(string key, Vector4 value)
        {
            global::System.IntPtr cPtr = Interop.PropertyMap.Find(SwigCPtr, key);
            if (cPtr != global::System.IntPtr.Zero)
            {
                Tizen.Log.Error("NUI", $"The key {key} already exists. please do not use duplicate key");
            }

            if (null == value)
            {
                Interop.PropertyMap.AddNone(SwigCPtr, key);
            }
            else
            {
                Interop.PropertyMap.AddVector4(SwigCPtr, key, value.X, value.Y, value.Z, value.W);
            }

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return this;
        }

        internal PropertyMap Set(int key, Vector4 value)
        {
            if (null == value)
            {
                Interop.PropertyMap.SetNone(SwigCPtr, key);
            }
            else
            {
                Interop.PropertyMap.SetVector4(SwigCPtr, key, value.X, value.Y, value.Z, value.W);
            }

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return this;
        }

        internal PropertyMap Set(string key, Vector4 value)
        {
            if (null == value)
            {
                Interop.PropertyMap.SetNone(SwigCPtr, key);
            }
            else
            {
                Interop.PropertyMap.SetVector4(SwigCPtr, key, value.X, value.Y, value.Z, value.W);
            }

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return this;
        }

        internal PropertyMap Set(int key, UIColor value)
        {
            Interop.PropertyMap.SetVector4(SwigCPtr, key, value.R, value.G, value.B, value.A);
            NDalicPINVOKE.ThrowExceptionIfExists();
            return this;
        }
        #endregion

        #region Add/Set Rectangle value
        internal PropertyMap Add(int key, Rectangle value)
        {
            global::System.IntPtr cPtr = Interop.PropertyMap.Find(SwigCPtr, key);
            if (cPtr != global::System.IntPtr.Zero)
            {
                Tizen.Log.Error("NUI", $"The key {key} already exists. please do not use duplicate key");
            }

            if (null == value)
            {
                Interop.PropertyMap.AddNone(SwigCPtr, key);
            }
            else
            {
                Interop.PropertyMap.AddRectangle(SwigCPtr, key, value.SwigCPtr);
            }

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return this;
        }

        internal PropertyMap Set(int key, Rectangle value)
        {
            if (null == value)
            {
                Interop.PropertyMap.SetNone(SwigCPtr, key);
            }
            else
            {
                Interop.PropertyMap.SetRectangle(SwigCPtr, key, value.SwigCPtr);
            }

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return this;
        }
        #endregion

        #region Add/Set string value
        internal PropertyMap Add(int key, string value)
        {
            global::System.IntPtr cPtr = Interop.PropertyMap.Find(SwigCPtr, key);
            if (cPtr != global::System.IntPtr.Zero)
            {
                Tizen.Log.Error("NUI", $"The key {key} already exists. please do not use duplicate key");
            }

            Interop.PropertyMap.AddString(SwigCPtr, key, value);

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return this;
        }

        internal PropertyMap Add(string key, string value)
        {
            global::System.IntPtr cPtr = Interop.PropertyMap.Find(SwigCPtr, key);
            if (cPtr != global::System.IntPtr.Zero)
            {
                Tizen.Log.Error("NUI", $"The key {key} already exists. please do not use duplicate key");
            }

            Interop.PropertyMap.AddString(SwigCPtr, key, value);

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return this;
        }

        internal PropertyMap Set(int key, string value)
        {
            Interop.PropertyMap.SetString(SwigCPtr, key, value);

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return this;
        }

        internal PropertyMap Set(string key, string value)
        {
            Interop.PropertyMap.SetString(SwigCPtr, key, value);

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return this;
        }
        #endregion

        #region Add/Set bool value
        internal PropertyMap Add(int key, bool value)
        {
            global::System.IntPtr cPtr = Interop.PropertyMap.Find(SwigCPtr, key);
            if (cPtr != global::System.IntPtr.Zero)
            {
                Tizen.Log.Error("NUI", $"The key {key} already exists. please do not use duplicate key");
            }

            Interop.PropertyMap.AddBool(SwigCPtr, key, value);

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return this;
        }

        internal PropertyMap Add(string key, bool value)
        {
            global::System.IntPtr cPtr = Interop.PropertyMap.Find(SwigCPtr, key);
            if (cPtr != global::System.IntPtr.Zero)
            {
                Tizen.Log.Error("NUI", $"The key {key} already exists. please do not use duplicate key");
            }

            Interop.PropertyMap.AddBool(SwigCPtr, key, value);

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return this;
        }

        internal PropertyMap Set(int key, bool value)
        {
            Interop.PropertyMap.SetBool(SwigCPtr, key, value);

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return this;
        }

        internal PropertyMap Set(string key, bool value)
        {
            Interop.PropertyMap.SetBool(SwigCPtr, key, value);

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return this;
        }
        #endregion

        #region Add/Set int value
        internal PropertyMap Add(int key, int value)
        {
            global::System.IntPtr cPtr = Interop.PropertyMap.Find(SwigCPtr, key);
            if (cPtr != global::System.IntPtr.Zero)
            {
                Tizen.Log.Error("NUI", $"The key {key} already exists. please do not use duplicate key");
            }

            Interop.PropertyMap.AddInt(SwigCPtr, key, value);

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return this;
        }

        internal PropertyMap Add(string key, int value)
        {
            global::System.IntPtr cPtr = Interop.PropertyMap.Find(SwigCPtr, key);
            if (cPtr != global::System.IntPtr.Zero)
            {
                Tizen.Log.Error("NUI", $"The key {key} already exists. please do not use duplicate key");
            }

            Interop.PropertyMap.AddInt(SwigCPtr, key, value);

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return this;
        }

        internal PropertyMap Set(int key, int value)
        {
            Interop.PropertyMap.SetInt(SwigCPtr, key, value);

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return this;
        }

        internal PropertyMap Set(string key, int value)
        {
            Interop.PropertyMap.SetInt(SwigCPtr, key, value);

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return this;
        }
        #endregion

        #region Add/Set float value
        internal PropertyMap Add(int key, float value)
        {
            global::System.IntPtr cPtr = Interop.PropertyMap.Find(SwigCPtr, key);
            if (cPtr != global::System.IntPtr.Zero)
            {
                Tizen.Log.Error("NUI", $"The key {key} already exists. please do not use duplicate key");
            }

            Interop.PropertyMap.AddFloat(SwigCPtr, key, value);

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return this;
        }

        internal PropertyMap Add(string key, float value)
        {
            global::System.IntPtr cPtr = Interop.PropertyMap.Find(SwigCPtr, key);
            if (cPtr != global::System.IntPtr.Zero)
            {
                Tizen.Log.Error("NUI", $"The key {key} already exists. please do not use duplicate key");
            }

            Interop.PropertyMap.AddFloat(SwigCPtr, key, value);

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return this;
        }

        internal PropertyMap Set(int key, float value)
        {
            Interop.PropertyMap.SetFloat(SwigCPtr, key, value);

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return this;
        }

        internal PropertyMap Set(string key, float value)
        {
            Interop.PropertyMap.SetFloat(SwigCPtr, key, value);

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return this;
        }
        #endregion

        internal PropertyMap SetNone(int key)
        {
            Interop.PropertyMap.SetNone(SwigCPtr, key);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return this;
        }

        internal PropertyMap SetNone(string key)
        {
            Interop.PropertyMap.SetNone(SwigCPtr, key);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return this;
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.PropertyMap.DeletePropertyMap(swigCPtr);
        }

        private bool AppendNoneIfNull(int key, object value)
        {
            if (value == null)
            {
                Interop.PropertyMap.AddNone(SwigCPtr, key);
                return true;
            }
            return false;
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
