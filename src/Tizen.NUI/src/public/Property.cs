/** Copyright (c) 2017 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI
{

    internal class Property : global::System.IDisposable
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;
        protected bool swigCMemOwn;

        internal Property(global::System.IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Property obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        //A Flag to check who called Dispose(). (By User or DisposeQueue)
        private bool isDisposeQueued = false;
        //A Flat to check if it is already disposed.
        protected bool disposed = false;

        ~Property()
        {
            if(!isDisposeQueued)
            {
                isDisposeQueued = true;
                DisposeQueue.Instance.Add(this);
            }
        }

        public void Dispose()
        {
            //Throw excpetion if Dispose() is called in separate thread.
            if (!Window.IsInstalled())
            {
                throw new System.InvalidOperationException("This API called from separate thread. This API must be called from MainThread.");
            }

            if (isDisposeQueued)
            {
                Dispose(DisposeTypes.Implicit);
            }
            else
            {
                Dispose(DisposeTypes.Explicit);
                System.GC.SuppressFinalize(this);
            }
        }

        protected virtual void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if(type == DisposeTypes.Explicit)
            {
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.

            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;
                    NDalicPINVOKE.delete_Property(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }
            disposed = true;
        }


        internal static int INVALID_INDEX
        {
            get
            {
                int ret = NDalicPINVOKE.Property_INVALID_INDEX_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        internal static int INVALID_KEY
        {
            get
            {
                int ret = NDalicPINVOKE.Property_INVALID_KEY_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        internal static int INVALID_COMPONENT_INDEX
        {
            get
            {
                int ret = NDalicPINVOKE.Property_INVALID_COMPONENT_INDEX_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// Constructor. Create a Property instance.
        /// </summary>
        /// <param name="arg0">A valid handle to the target object</param>
        /// <param name="propertyIndex">The index of a property</param>
        public Property(Animatable arg0, int propertyIndex) : this(NDalicPINVOKE.new_Property__SWIG_0(Animatable.getCPtr(arg0), propertyIndex), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Constructor. Create a Property instance.
        /// </summary>
        /// <param name="arg0">A valid handle to the target object</param>
        /// <param name="propertyIndex">The index of a property</param>
        /// <param name="componentIndex">Index to a sub component of a property, for use with Vector2, Vector3 and Vector4. -1 for main property (default is -1)</param>
        public Property(Animatable arg0, int propertyIndex, int componentIndex) : this(NDalicPINVOKE.new_Property__SWIG_1(Animatable.getCPtr(arg0), propertyIndex, componentIndex), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Constructor. Create a Property instance.<br>
        /// This performs a property index query and is therefore slower than constructing a Property directly with the index.<br>
        /// </summary>
        /// <param name="arg0">A valid handle to the target object</param>
        /// <param name="propertyName">The property name</param>
        public Property(Animatable arg0, string propertyName) : this(NDalicPINVOKE.new_Property__SWIG_2(Animatable.getCPtr(arg0), propertyName), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Constructor. Create a Property instance.<br>
        /// This performs a property index query and is therefore slower than constructing a Property directly with the index.<br>
        /// </summary>
        /// <param name="arg0">A valid handle to the target object</param>
        /// <param name="propertyName">The property name</param>
        /// <param name="componentIndex">Index to a sub component of a property, for use with Vector2, Vector3 and Vector4. -1 for main property (default is -1)</param>
        public Property(Animatable arg0, string propertyName, int componentIndex) : this(NDalicPINVOKE.new_Property__SWIG_3(Animatable.getCPtr(arg0), propertyName, componentIndex), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Animatable _object
        {
            set
            {
                NDalicPINVOKE.Property__object_set(swigCPtr, Animatable.getCPtr(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                Animatable ret = new Animatable(NDalicPINVOKE.Property__object_get(swigCPtr), false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// Gets/Sets the index of the property.
        /// </summary>
        public int propertyIndex
        {
            set
            {
                NDalicPINVOKE.Property_propertyIndex_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                int ret = NDalicPINVOKE.Property_propertyIndex_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// Gets/Sets the componentIndex of the property.
        /// </summary>
        public int componentIndex
        {
            set
            {
                NDalicPINVOKE.Property_componentIndex_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                int ret = NDalicPINVOKE.Property_componentIndex_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

    }

    /// <summary>
    /// A Array of property values.
    /// </summary>
    public class PropertyArray : global::System.IDisposable
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;
        protected bool swigCMemOwn;

        internal PropertyArray(global::System.IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(PropertyArray obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        //A Flag to check who called Dispose(). (By User or DisposeQueue)
        private bool isDisposeQueued = false;
        //A Flat to check if it is already disposed.
        protected bool disposed = false;

        ~PropertyArray()
        {
            if(!isDisposeQueued)
            {
                isDisposeQueued = true;
                DisposeQueue.Instance.Add(this);
            }
        }

        public void Dispose()
        {
            //Throw excpetion if Dispose() is called in separate thread.
            if (!Window.IsInstalled())
            {
                throw new System.InvalidOperationException("This API called from separate thread. This API must be called from MainThread.");
            }

            if (isDisposeQueued)
            {
                Dispose(DisposeTypes.Implicit);
            }
            else
            {
                Dispose(DisposeTypes.Explicit);
                System.GC.SuppressFinalize(this);
            }
        }

        protected virtual void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if(type == DisposeTypes.Explicit)
            {
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.

            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;
                    NDalicPINVOKE.delete_Property_Array(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }
            disposed = true;
        }

        /// <summary>
        /// Operator to access an element.
        /// </summary>
        /// <param name="index">The element index to access. No bounds checking is performed</param>
        /// <returns>The a reference to the element</returns>
        public PropertyValue this[uint index]
        {
            get
            {
                return ValueOfIndex(index);
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public PropertyArray() : this(NDalicPINVOKE.new_Property_Array__SWIG_0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal PropertyArray(PropertyArray other) : this(NDalicPINVOKE.new_Property_Array__SWIG_1(PropertyArray.getCPtr(other)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Retrieves the number of elements in the array.
        /// </summary>
        /// <returns>The number of elements in the array</returns>
        public uint Size()
        {
            uint ret = NDalicPINVOKE.Property_Array_Size(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves the number of elements in the array.
        /// </summary>
        /// <returns>The number of elements in the array</returns>
        public uint Count()
        {
            uint ret = NDalicPINVOKE.Property_Array_Count(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Returns whether the array is empty.
        /// </summary>
        /// <returns>Return true if empty, false otherwise</returns>
        public bool Empty()
        {
            bool ret = NDalicPINVOKE.Property_Array_Empty(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Clears the array.
        /// </summary>
        public void Clear()
        {
            NDalicPINVOKE.Property_Array_Clear(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Increases the capacity of the array.
        /// </summary>
        /// <param name="size">The size to reserve</param>
        public void Reserve(uint size)
        {
            NDalicPINVOKE.Property_Array_Reserve(swigCPtr, size);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Resizes to size.
        /// </summary>
        /// <param name="size">The size to resize</param>
        public void Resize(uint size)
        {
            NDalicPINVOKE.Property_Array_Resize(swigCPtr, size);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Retrieves the capacity of the array.
        /// </summary>
        /// <returns>The allocated capacity of the array</returns>
        public uint Capacity()
        {
            uint ret = NDalicPINVOKE.Property_Array_Capacity(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Adds an element to the array.
        /// </summary>
        /// <param name="value">The value to add to the end of the array</param>
        public void PushBack(PropertyValue value)
        {
            NDalicPINVOKE.Property_Array_PushBack(swigCPtr, PropertyValue.getCPtr(value));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Add an element to the array.
        /// </summary>
        /// <param name="value">The value to add to the end of the array</param>
        public PropertyArray Add(PropertyValue value)
        {
            PropertyArray ret = new PropertyArray(NDalicPINVOKE.Property_Array_Add(swigCPtr, PropertyValue.getCPtr(value)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Access an element.
        /// </summary>
        /// <param name="index">The element index to access. No bounds checking is performed</param>
        /// <returns>The a reference to the element</returns>
        public PropertyValue GetElementAt(uint index)
        {
            PropertyValue ret = new PropertyValue(NDalicPINVOKE.Property_Array_GetElementAt__SWIG_0(swigCPtr, index), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves the value of elements in the array.
        /// </summary>
        /// <param name="index">The element index to retrieve.</param>
        /// <returns>The a reference to the element</returns>
        private PropertyValue ValueOfIndex(uint index)
        {
            PropertyValue ret = new PropertyValue(NDalicPINVOKE.Property_Array_ValueOfIndex__SWIG_0(swigCPtr, index), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
    }

    /// <summary>
    /// A key type which can be either a std::string or a Property::Index
    /// </summary>
    public class PropertyKey : global::System.IDisposable
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;
        protected bool swigCMemOwn;

        internal PropertyKey(global::System.IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(PropertyKey obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        //A Flag to check who called Dispose(). (By User or DisposeQueue)
        private bool isDisposeQueued = false;
        //A Flat to check if it is already disposed.
        protected bool disposed = false;

        ~PropertyKey()
        {
            if(!isDisposeQueued)
            {
                isDisposeQueued = true;
                DisposeQueue.Instance.Add(this);
            }
        }

        public void Dispose()
        {
            //Throw excpetion if Dispose() is called in separate thread.
            if (!Window.IsInstalled())
            {
                throw new System.InvalidOperationException("This API called from separate thread. This API must be called from MainThread.");
            }

            if (isDisposeQueued)
            {
                Dispose(DisposeTypes.Implicit);
            }
            else
            {
                Dispose(DisposeTypes.Explicit);
                System.GC.SuppressFinalize(this);
            }
        }

        protected virtual void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if(type == DisposeTypes.Explicit)
            {
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.

            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;
                    NDalicPINVOKE.delete_Property_Key(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }
            disposed = true;
        }

        /// <summary>
        /// The type of the key
        /// </summary>
        public PropertyKey.KeyType Type
        {
            set
            {
                NDalicPINVOKE.Property_Key_type_set(swigCPtr, (int)value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                PropertyKey.KeyType ret = (PropertyKey.KeyType)NDalicPINVOKE.Property_Key_type_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// The index key.
        /// </summary>
        public int IndexKey
        {
            set
            {
                NDalicPINVOKE.Property_Key_indexKey_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                int ret = NDalicPINVOKE.Property_Key_indexKey_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// The string key.
        /// </summary>
        public string StringKey
        {
            set
            {
                NDalicPINVOKE.Property_Key_stringKey_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                string ret = NDalicPINVOKE.Property_Key_stringKey_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="key">The string key</param>
        public PropertyKey(string key) : this(NDalicPINVOKE.new_Property_Key__SWIG_0(key), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="key">The index key</param>
        public PropertyKey(int key) : this(NDalicPINVOKE.new_Property_Key__SWIG_1(key), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Compare if rhs is equal to
        /// </summary>
        /// <param name="rhs">A string key to compare against</param>
        /// <returns>Returns true if the key compares, or false if it isn't equal or of the wrong type</returns>
        public bool EqualTo(string rhs)
        {
            bool ret = NDalicPINVOKE.Property_Key_EqualTo__SWIG_0(swigCPtr, rhs);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Compare if rhs is equal to
        /// </summary>
        /// <param name="rhs">A index key to compare against</param>
        /// <returns>Returns true if the key compares, or false if it isn't equal or of the wrong type</returns>
        public bool EqualTo(int rhs)
        {
            bool ret = NDalicPINVOKE.Property_Key_EqualTo__SWIG_1(swigCPtr, rhs);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Compare if rhs is equal to
        /// </summary>
        /// <param name="rhs">A key to compare against</param>
        /// <returns>Returns true if the keys are of the same type and have the same value</returns>
        public bool EqualTo(PropertyKey rhs)
        {
            bool ret = NDalicPINVOKE.Property_Key_EqualTo__SWIG_2(swigCPtr, PropertyKey.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Compare if rhs is not equal to
        /// </summary>
        /// <param name="rhs">An index key to compare against.</param>
        /// <returns>Returns true if the key is not equal or not a string key</returns>
        public bool NotEqualTo(string rhs)
        {
            bool ret = NDalicPINVOKE.Property_Key_NotEqualTo__SWIG_0(swigCPtr, rhs);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Compare if rhs is not equal to
        /// </summary>
        /// <param name="rhs">An index key to compare against.</param>
        /// <returns>Returns true if the key is not equal, or not an index key</returns>
        public bool NotEqualTo(int rhs)
        {
            bool ret = NDalicPINVOKE.Property_Key_NotEqualTo__SWIG_1(swigCPtr, rhs);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Compare if rhs is not equal to
        /// </summary>
        /// <param name="rhs">A key to compare against.</param>
        /// <returns>Returns true if the keys are not of the same type or are not equal</returns>
        public bool NotEqualTo(PropertyKey rhs)
        {
            bool ret = NDalicPINVOKE.Property_Key_NotEqualTo__SWIG_2(swigCPtr, PropertyKey.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// The type of key
        /// </summary>
        public enum KeyType
        {
            Index,
            String
        }

    }

    /// <summary>
    /// A Map of property values, the key type could be String or Property::Index.
    /// </summary>
    public class PropertyMap : global::System.IDisposable
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;
        protected bool swigCMemOwn;

        internal PropertyMap(global::System.IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(PropertyMap obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        //A Flag to check who called Dispose(). (By User or DisposeQueue)
        private bool isDisposeQueued = false;
        //A Flat to check if it is already disposed.
        protected bool disposed = false;

        ~PropertyMap()
        {
            if(!isDisposeQueued)
            {
                isDisposeQueued = true;
                DisposeQueue.Instance.Add(this);
            }
        }

        public void Dispose()
        {
            //Throw excpetion if Dispose() is called in separate thread.
            if (!Window.IsInstalled())
            {
                throw new System.InvalidOperationException("This API called from separate thread. This API must be called from MainThread.");
            }

            if (isDisposeQueued)
            {
                Dispose(DisposeTypes.Implicit);
            }
            else
            {
                Dispose(DisposeTypes.Explicit);
                System.GC.SuppressFinalize(this);
            }
        }

        protected virtual void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if(type == DisposeTypes.Explicit)
            {
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.

            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;
                    NDalicPINVOKE.delete_Property_Map(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }
            disposed = true;
        }

        /// <summary>
        /// Operator to access the element with the specified string key.<br>
        /// If an element with the key does not exist, then it is created.<br>
        /// </summary>
        /// <param name="key">The key whose value to access</param>
        /// <returns>A value for the element with the specified key</returns>
        public PropertyValue this[string key]
        {
            get
            {
                return ValueOfIndex(key);
            }
        }

        /// <summary>
        /// Operator to access the element with the specified index key.<br>
        /// If an element with the key does not exist, then it is created.<br>
        /// </summary>
        /// <param name="key">The key whose value to access</param>
        /// <returns>A value for the element with the specified key</returns>
        public PropertyValue this[int key]
        {
            get
            {
                return ValueOfIndex(key);
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public PropertyMap() : this(NDalicPINVOKE.new_Property_Map__SWIG_0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Copy Constructor
        /// </summary>
        /// <param name="other">The Map to copy from</param>
        public PropertyMap(PropertyMap other) : this(NDalicPINVOKE.new_Property_Map__SWIG_1(PropertyMap.getCPtr(other)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Retrieves the number of elements in the map.
        /// </summary>
        /// <returns>The number of elements in the map</returns>
        public uint Count()
        {
            uint ret = NDalicPINVOKE.Property_Map_Count(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Returns whether the map is empty.
        /// </summary>
        /// <returns>Returns true if empty, false otherwise</returns>
        public bool Empty()
        {
            bool ret = NDalicPINVOKE.Property_Map_Empty(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Inserts the key-value pair in the Map, with the key type as string.<br>
        /// Does not check for duplicates.<br>
        /// </summary>
        /// <param name="key">The key to insert</param>
        /// <param name="value">The value to insert</param>
        public void Insert(string key, PropertyValue value)
        {
            NDalicPINVOKE.Property_Map_Insert__SWIG_0(swigCPtr, key, PropertyValue.getCPtr(value));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Inserts the key-value pair in the Map, with the key type as index.<br>
        /// Does not check for duplicates.<br>
        /// </summary>
        /// <param name="key">The key to insert</param>
        /// <param name="value">The value to insert</param>
        public void Insert(int key, PropertyValue value)
        {
            NDalicPINVOKE.Property_Map_Insert__SWIG_2(swigCPtr, key, PropertyValue.getCPtr(value));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Inserts the key-value pair in the Map, with the key type as string.<br>
        /// Does not check for duplicates.<br>
        /// </summary>
        /// <param name="key">The key to insert</param>
        /// <param name="value">The value to insert</param>
        /// <returns>Returns a reference to this object</returns>
        public PropertyMap Add(string key, PropertyValue value)
        {
            PropertyMap ret = new PropertyMap(NDalicPINVOKE.Property_Map_Add__SWIG_0(swigCPtr, key, PropertyValue.getCPtr(value)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Inserts the key-value pair in the Map, with the key type as string.<br>
        /// Does not check for duplicates.<br>
        /// </summary>
        /// <param name="key">The key to insert</param>
        /// <param name="value">The value to insert</param>
        /// <returns>Returns a reference to this object</returns>
        public PropertyMap Add(int key, PropertyValue value)
        {
            PropertyMap ret = new PropertyMap(NDalicPINVOKE.Property_Map_Add__SWIG_2(swigCPtr, key, PropertyValue.getCPtr(value)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves the value at the specified position.
        /// </summary>
        /// <param name="position">The specified position</param>
        /// <returns>A reference to the value at the specified position</returns>
        public PropertyValue GetValue(uint position)
        {
            PropertyValue ret = new PropertyValue(NDalicPINVOKE.Property_Map_GetValue(swigCPtr, position), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        [Obsolete("Please do not use! this will be deprecated")]
        public string GetKey(uint position)
        {
            string ret = NDalicPINVOKE.Property_Map_GetKey(swigCPtr, position);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieve the key at the specified position.
        /// </summary>
        /// <param name="position">The specified position</param>
        /// <returns>A copy of the key at the specified position</returns>
        public PropertyKey GetKeyAt(uint position)
        {
            PropertyKey ret = new PropertyKey(NDalicPINVOKE.Property_Map_GetKeyAt(swigCPtr, position), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        [Obsolete("Please do not use! this will be deprecated")]
        public PropertyValue Find(string key)
        {
            global::System.IntPtr cPtr = NDalicPINVOKE.Property_Map_Find__SWIG_0(swigCPtr, key);
            PropertyValue ret = (cPtr == global::System.IntPtr.Zero) ? null : new PropertyValue(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Finds the value for the specified key if it exists.
        /// </summary>
        /// <param name="key">The key to find</param>
        /// <returns>The value if it exists, an empty object otherwise</returns>
        public PropertyValue Find(int key)
        {
            global::System.IntPtr cPtr = NDalicPINVOKE.Property_Map_Find__SWIG_2(swigCPtr, key);
            PropertyValue ret = (cPtr == global::System.IntPtr.Zero) ? null : new PropertyValue(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Finds the value for the specified keys if either exist.
        /// </summary>
        /// <param name="indexKey">The index key to find</param>
        /// <param name="stringKey">The string key to find</param>
        /// <returns>The value if it exists, an empty object otherwise</returns>
        public PropertyValue Find(int indexKey, string stringKey)
        {
            global::System.IntPtr cPtr = NDalicPINVOKE.Property_Map_Find__SWIG_3(swigCPtr, indexKey, stringKey);
            PropertyValue ret = (cPtr == global::System.IntPtr.Zero) ? null : new PropertyValue(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        [Obsolete("Please do not use! this will be deprecated")]
        public PropertyValue Find(string key, PropertyType type)
        {
            global::System.IntPtr cPtr = NDalicPINVOKE.Property_Map_Find__SWIG_4(swigCPtr, key, (int)type);
            PropertyValue ret = (cPtr == global::System.IntPtr.Zero) ? null : new PropertyValue(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        [Obsolete("Please do not use! this will be deprecated")]
        public PropertyValue Find(int key, PropertyType type)
        {
            global::System.IntPtr cPtr = NDalicPINVOKE.Property_Map_Find__SWIG_5(swigCPtr, key, (int)type);
            PropertyValue ret = (cPtr == global::System.IntPtr.Zero) ? null : new PropertyValue(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Clears the map.
        /// </summary>
        public void Clear()
        {
            NDalicPINVOKE.Property_Map_Clear(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Merges values from the map 'from' to the current.<br>
        /// Any values in 'from' will overwrite the values in the current map.<br>
        /// </summary>
        /// <param name="from">The map to merge from</param>
        public void Merge(PropertyMap from)
        {
            NDalicPINVOKE.Property_Map_Merge(swigCPtr, PropertyMap.getCPtr(from));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Retrieves the element with the specified string key.
        /// </summary>
        /// <param name="key">The key whose value to retrieve</param>
        /// <returns>The value for the element with the specified key</returns>
        internal PropertyValue ValueOfIndex(string key)
        {
            PropertyValue ret = new PropertyValue(NDalicPINVOKE.Property_Map_ValueOfIndex__SWIG_0(swigCPtr, key), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves the element with the specified index key.
        /// </summary>
        /// <param name="key">The key whose value to retrieve</param>
        /// <returns>The value for the element with the specified key</returns>
        internal PropertyValue ValueOfIndex(int key)
        {
            PropertyValue ret = new PropertyValue(NDalicPINVOKE.Property_Map_ValueOfIndex__SWIG_2(swigCPtr, key), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
    }

    /// <summary>
    /// A value-type representing a property value.
    /// </summary>
    public class PropertyValue : global::System.IDisposable
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;
        protected bool swigCMemOwn;

        internal PropertyValue(global::System.IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(PropertyValue obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        //A Flag to check who called Dispose(). (By User or DisposeQueue)
        private bool isDisposeQueued = false;
        //A Flat to check if it is already disposed.
        protected bool disposed = false;

        ~PropertyValue()
        {
            if(!isDisposeQueued)
            {
                isDisposeQueued = true;
                DisposeQueue.Instance.Add(this);
            }
        }

        public void Dispose()
        {
            //Throw excpetion if Dispose() is called in separate thread.
            if (!Window.IsInstalled())
            {
                throw new System.InvalidOperationException("This API called from separate thread. This API must be called from MainThread.");
            }

            if (isDisposeQueued)
            {
                Dispose(DisposeTypes.Implicit);
            }
            else
            {
                Dispose(DisposeTypes.Explicit);
                System.GC.SuppressFinalize(this);
            }
        }

        protected virtual void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if(type == DisposeTypes.Explicit)
            {
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.

            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;
                    NDalicPINVOKE.delete_Property_Value(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }
            disposed = true;
        }


        /// <summary>
        /// Extension to property value class that allows us to create a
        /// PropertyValue from a C# object, e.g. int, float, string.<br>
        /// </summary>
        /// <param name="obj">An object to create</param>
        /// <returns>The created value</returns>
        static public PropertyValue CreateFromObject(System.Object obj)
        {
            System.Type type = obj.GetType();

            PropertyValue value;

            if (type.Equals(typeof(int)))
            {
                value = new PropertyValue((int)obj);
            }
            if (type.Equals(typeof(System.Int32)))
            {
                value = new PropertyValue((int)obj);
            }
            else if (type.Equals(typeof(bool)))
            {
                value = new PropertyValue((bool)obj);
            }
            else if (type.Equals(typeof(float)))
            {
                value = new PropertyValue((float)obj);
            }
            else if (type.Equals(typeof(string)))
            {
                value = new PropertyValue((string)obj);
            }
            else if (type.Equals(typeof(Vector2)))
            {
                value = new PropertyValue((Vector2)obj);
            }
            else if (type.Equals(typeof(Vector3)))
            {
                value = new PropertyValue((Vector3)obj);
            }
            else if (type.Equals(typeof(Vector4)))
            {
                value = new PropertyValue((Vector4)obj);
            }
            else if (type.Equals(typeof(Position)))
            {
                value = new PropertyValue((Position)obj);
            }
            else if (type.Equals(typeof(Position2D)))
            {
                value = new PropertyValue((Position2D)obj);
            }
            else if (type.Equals(typeof(Size)))
            {
                value = new PropertyValue((Size)obj);
            }
            else if (type.Equals(typeof(Size2D)))
            {
                value = new PropertyValue((Size2D)obj);
            }
            else if (type.Equals(typeof(Color)))
            {
                value = new PropertyValue((Color)obj);
            }
            else if (type.Equals(typeof(Rotation)))
            {
                value = new PropertyValue((Rotation)obj);
            }
            else if (type.Equals(typeof(RelativeVector2)))
            {
                value = new PropertyValue((RelativeVector2)obj);
            }
            else if (type.Equals(typeof(RelativeVector3)))
            {
                value = new PropertyValue((RelativeVector3)obj);
            }
            else if (type.Equals(typeof(RelativeVector4)))
            {
                value = new PropertyValue((RelativeVector4)obj);
            }
            else
            {
                throw new global::System.InvalidOperationException("Unimplemented type for Property Value :" + type.Name);
            }
            NUILog.Debug(" got an property value of =" + type.Name);
            return value;
        }

        /// <summary>
        /// Creates a Size2D property value.
        /// </summary>
        /// <param name="vectorValue">A Size2D values</param>
        public PropertyValue(Size2D vectorValue) : this(NDalicPINVOKE.new_Property_Value__SWIG_4(Size2D.getCPtr(vectorValue)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Creates a Position2D property value.
        /// </summary>
        /// <param name="vectorValue">A Position2D values</param>
        public PropertyValue(Position2D vectorValue) : this(NDalicPINVOKE.new_Property_Value__SWIG_4(Position2D.getCPtr(vectorValue)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Creates a Size property value.
        /// </summary>
        /// <param name="vectorValue">A Size values</param>
        internal PropertyValue(Size vectorValue) : this(NDalicPINVOKE.new_Property_Value__SWIG_5(Size.getCPtr(vectorValue)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Creates a Position property value.
        /// </summary>
        /// <param name="vectorValue">A Position values</param>
        public PropertyValue(Position vectorValue) : this(NDalicPINVOKE.new_Property_Value__SWIG_5(Position.getCPtr(vectorValue)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Creates a Color property value.
        /// </summary>
        /// <param name="vectorValue">A Color values</param>
        public PropertyValue(Color vectorValue) : this(NDalicPINVOKE.new_Property_Value__SWIG_6(Color.getCPtr(vectorValue)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }


        /// <summary>
        /// Retrieves a Size2D value.
        /// </summary>
        /// <param name="vectorValue"> On return, a Size2D value</param>
        public bool Get(Size2D vectorValue)
        {
            bool ret = NDalicPINVOKE.Property_Value_Get__SWIG_5(swigCPtr, Size2D.getCPtr(vectorValue));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves a Position2D value.
        /// </summary>
        /// <param name="vectorValue"> On return, a Position2D value</param>
        public bool Get(Position2D vectorValue)
        {
            bool ret = NDalicPINVOKE.Property_Value_Get__SWIG_5(swigCPtr, Position2D.getCPtr(vectorValue));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves a Size value.
        /// </summary>
        /// <param name="vectorValue"> On return, a Size value</param>
        internal bool Get(Size vectorValue)
        {
            bool ret = NDalicPINVOKE.Property_Value_Get__SWIG_6(swigCPtr, Size.getCPtr(vectorValue));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves a Position value.
        /// </summary>
        /// <param name="vectorValue"> On return, a Position value</param>
        public bool Get(Position vectorValue)
        {
            bool ret = NDalicPINVOKE.Property_Value_Get__SWIG_6(swigCPtr, Position.getCPtr(vectorValue));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves a Color value.
        /// </summary>
        /// <param name="vectorValue"> On return, a Color value</param>
        public bool Get(Color vectorValue)
        {
            bool ret = NDalicPINVOKE.Property_Value_Get__SWIG_7(swigCPtr, Color.getCPtr(vectorValue));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }



        /// <summary>
        /// Default constructor.
        /// </summary>
        public PropertyValue() : this(NDalicPINVOKE.new_Property_Value__SWIG_0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Creates a boolean property value.
        /// </summary>
        /// <param name="boolValue">A boolean value</param>
        public PropertyValue(bool boolValue) : this(NDalicPINVOKE.new_Property_Value__SWIG_1(boolValue), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Creates an integer property value.
        /// </summary>
        /// <param name="integerValue">An integer value</param>
        public PropertyValue(int integerValue) : this(NDalicPINVOKE.new_Property_Value__SWIG_2(integerValue), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Creates a float property value.
        /// </summary>
        /// <param name="floatValue">A floating-point value</param>
        public PropertyValue(float floatValue) : this(NDalicPINVOKE.new_Property_Value__SWIG_3(floatValue), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Creates a Vector2 property value.
        /// </summary>
        /// <param name="vectorValue">A vector of 2 floating-point values</param>
        public PropertyValue(Vector2 vectorValue) : this(NDalicPINVOKE.new_Property_Value__SWIG_4(Vector2.getCPtr(vectorValue)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Creates a Vector3 property value.
        /// </summary>
        /// <param name="vectorValue">A vector of 3 floating-point values</param>
        public PropertyValue(Vector3 vectorValue) : this(NDalicPINVOKE.new_Property_Value__SWIG_5(Vector3.getCPtr(vectorValue)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Creates a Vector4 property value.
        /// </summary>
        /// <param name="vectorValue">A vector of 4 floating-point values</param>
        public PropertyValue(Vector4 vectorValue) : this(NDalicPINVOKE.new_Property_Value__SWIG_6(Vector4.getCPtr(vectorValue)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal PropertyValue(Matrix3 matrixValue) : this(NDalicPINVOKE.new_Property_Value__SWIG_7(Matrix3.getCPtr(matrixValue)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal PropertyValue(Matrix matrixValue) : this(NDalicPINVOKE.new_Property_Value__SWIG_8(Matrix.getCPtr(matrixValue)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Creates a Rectangle property value.
        /// </summary>
        /// <param name="vectorValue">A Rectangle values</param>
        public PropertyValue(Rectangle vectorValue) : this(NDalicPINVOKE.new_Property_Value__SWIG_9(Rectangle.getCPtr(vectorValue)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal PropertyValue(AngleAxis angleAxis) : this(NDalicPINVOKE.new_Property_Value__SWIG_10(AngleAxis.getCPtr(angleAxis)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Creates a Rotation property value.
        /// </summary>
        /// <param name="quaternion">A Rotation values</param>
        public PropertyValue(Rotation quaternion) : this(NDalicPINVOKE.new_Property_Value__SWIG_11(Rotation.getCPtr(quaternion)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Creates a string property value.
        /// </summary>
        /// <param name="stringValue">A string</param>
        public PropertyValue(string stringValue) : this(NDalicPINVOKE.new_Property_Value__SWIG_12(stringValue), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Creates an array property value.
        /// </summary>
        /// <param name="arrayValue">An array</param>
        public PropertyValue(PropertyArray arrayValue) : this(NDalicPINVOKE.new_Property_Value__SWIG_14(PropertyArray.getCPtr(arrayValue)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Creates a map property value.
        /// </summary>
        /// <param name="mapValue">An array</param>
        public PropertyValue(PropertyMap mapValue) : this(NDalicPINVOKE.new_Property_Value__SWIG_15(PropertyMap.getCPtr(mapValue)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Creates a PropertyType value.
        /// </summary>
        /// <param name="type">A PropertyType values</param>
        public PropertyValue(PropertyType type) : this(NDalicPINVOKE.new_Property_Value__SWIG_16((int)type), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Creates a PropertyValue value.
        /// </summary>
        /// <param name="value">A PropertyValue values</param>
        public PropertyValue(PropertyValue value) : this(NDalicPINVOKE.new_Property_Value__SWIG_17(PropertyValue.getCPtr(value)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Queries the type of this property value.
        /// </summary>
        /// <returns>The type ID</returns>
        public PropertyType GetType()
        {
            PropertyType ret = (PropertyType)NDalicPINVOKE.Property_Value_GetType(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves a boolean value.
        /// </summary>
        /// <param name="boolValue">On return, a boolean value</param>
        /// <returns>Returns true if the value is successfully retrieved, false if the type is not convertible</returns>
        public bool Get(out bool boolValue)
        {
            bool ret = NDalicPINVOKE.Property_Value_Get__SWIG_1(swigCPtr, out boolValue);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves a floating-point value.
        /// </summary>
        /// <param name="floatValue">On return, a floating-point value</param>
        /// <returns>Returns true if the value is successfully retrieved, false if the type is not convertible</returns>
        public bool Get(out float floatValue)
        {
            bool ret = NDalicPINVOKE.Property_Value_Get__SWIG_2(swigCPtr, out floatValue);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves a integer value.
        /// </summary>
        /// <param name="integerValue">On return, a integer value</param>
        /// <returns>Returns true if the value is successfully retrieved, false if the type is not convertible</returns>
        public bool Get(out int integerValue)
        {
            bool ret = NDalicPINVOKE.Property_Value_Get__SWIG_3(swigCPtr, out integerValue);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves an integer rectangle.
        /// </summary>
        /// <param name="rect">On return, an integer rectangle</param>
        /// <returns>Returns true if the value is successfully retrieved, false if the type is not convertible</returns>
        public bool Get(Rectangle rect)
        {
            bool ret = NDalicPINVOKE.Property_Value_Get__SWIG_4(swigCPtr, Rectangle.getCPtr(rect));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves a vector value.
        /// </summary>
        /// <param name="vectorValue">On return, a vector value</param>
        /// <returns>Returns true if the value is successfully retrieved, false if the type is not convertible</returns>
        public bool Get(Vector2 vectorValue)
        {
            bool ret = NDalicPINVOKE.Property_Value_Get__SWIG_5(swigCPtr, Vector2.getCPtr(vectorValue));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves a vector value.
        /// </summary>
        /// <param name="vectorValue">On return, a vector value</param>
        /// <returns>Returns true if the value is successfully retrieved, false if the type is not convertible</returns>
        public bool Get(Vector3 vectorValue)
        {
            bool ret = NDalicPINVOKE.Property_Value_Get__SWIG_6(swigCPtr, Vector3.getCPtr(vectorValue));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves a vector value.
        /// </summary>
        /// <param name="vectorValue">On return, a vector value</param>
        /// <returns>Returns true if the value is successfully retrieved, false if the type is not convertible</returns>
        public bool Get(Vector4 vectorValue)
        {
            bool ret = NDalicPINVOKE.Property_Value_Get__SWIG_7(swigCPtr, Vector4.getCPtr(vectorValue));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal bool Get(Matrix3 matrixValue)
        {
            bool ret = NDalicPINVOKE.Property_Value_Get__SWIG_8(swigCPtr, Matrix3.getCPtr(matrixValue));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal bool Get(Matrix matrixValue)
        {
            bool ret = NDalicPINVOKE.Property_Value_Get__SWIG_9(swigCPtr, Matrix.getCPtr(matrixValue));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal bool Get(AngleAxis angleAxisValue)
        {
            bool ret = NDalicPINVOKE.Property_Value_Get__SWIG_10(swigCPtr, AngleAxis.getCPtr(angleAxisValue));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves a Rotation value.
        /// </summary>
        /// <param name="quaternionValue">On return, a Rotation value</param>
        /// <returns>Returns true if the value is successfully retrieved, false if the type is not convertible</returns>
        public bool Get(Rotation quaternionValue)
        {
            bool ret = NDalicPINVOKE.Property_Value_Get__SWIG_11(swigCPtr, Rotation.getCPtr(quaternionValue));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves a string property value.
        /// </summary>
        /// <param name="stringValue">On return, a string</param>
        /// <returns>Returns true if the value is successfully retrieved, false if the type is not convertible</returns>
        public bool Get(out string stringValue)
        {
            bool ret = NDalicPINVOKE.Property_Value_Get__SWIG_12(swigCPtr, out stringValue);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves an array property value.
        /// </summary>
        /// <param name="arrayValue">On return, the array as a vector Property Values</param>
        /// <returns>Returns true if the value is successfully retrieved, false if the type is not convertible</returns>
        public bool Get(PropertyArray arrayValue)
        {
            bool ret = NDalicPINVOKE.Property_Value_Get__SWIG_13(swigCPtr, PropertyArray.getCPtr(arrayValue));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves an map property value.
        /// </summary>
        /// <param name="mapValue">On return, the map as vector of string and Property Value pairs</param>
        /// <returns>Returns true if the value is successfully retrieved, false if the type is not convertible</returns>
        public bool Get(PropertyMap mapValue)
        {
            bool ret = NDalicPINVOKE.Property_Value_Get__SWIG_14(swigCPtr, PropertyMap.getCPtr(mapValue));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
    }
}
