/*
 * Copyright(c) 2017 Samsung Electronics Co., Ltd.
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
    /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ItemIdContainer : Disposable, global::System.Collections.IEnumerable,
        global::System.Collections.Generic.IList<uint>
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        /// <summary>swigCMemOwn.</summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        protected bool swigCMemOwn;

        internal ItemIdContainer(global::System.IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(ItemIdContainer obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.

            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;
                    Interop.ItemIdContainer.delete_ItemIdContainer(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ItemIdContainer(global::System.Collections.ICollection c) : this()
        {
            if (c == null)
                throw new global::System.ArgumentNullException("c");
            foreach (uint element in c)
            {
                this.Add(element);
            }
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsFixedSize
        {
            get
            {
                return false;
            }
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint this[int index]
        {
            get
            {
                return getitem(index);
            }
            set
            {
                setitem(index, value);
            }
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int Capacity
        {
            get
            {
                return (int)capacity();
            }
            set
            {
                if (value < size())
                    throw new global::System.ArgumentOutOfRangeException("Capacity");
                reserve((uint)value);
            }
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int Count
        {
            get
            {
                return (int)size();
            }
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsSynchronized
        {
            get
            {
                return false;
            }
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void CopyTo(uint[] array)
        {
            CopyTo(0, array, 0, this.Count);
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void CopyTo(uint[] array, int arrayIndex)
        {
            CopyTo(0, array, arrayIndex, this.Count);
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void CopyTo(int index, uint[] array, int arrayIndex, int count)
        {
            if (array == null)
                throw new global::System.ArgumentNullException("array");
            if (index < 0)
                throw new global::System.ArgumentOutOfRangeException("index", "Value is less than zero");
            if (arrayIndex < 0)
                throw new global::System.ArgumentOutOfRangeException("arrayIndex", "Value is less than zero");
            if (count < 0)
                throw new global::System.ArgumentOutOfRangeException("count", "Value is less than zero");
            if (array.Rank > 1)
                throw new global::System.ArgumentException("Multi dimensional array.", "array");
            if (index + count > this.Count || arrayIndex + count > array.Length)
                throw new global::System.ArgumentException("Number of elements to copy is too large.");
            for (int i = 0; i < count; i++)
                array.SetValue(getitemcopy(index + i), arrayIndex + i);
        }

        global::System.Collections.Generic.IEnumerator<uint> global::System.Collections.Generic.IEnumerable<uint>.GetEnumerator()
        {
            return new ItemIdContainerEnumerator(this);
        }

        global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
        {
            return new ItemIdContainerEnumerator(this);
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ItemIdContainerEnumerator GetEnumerator()
        {
            return new ItemIdContainerEnumerator(this);
        }

        // The type-safe enumerator.
        /// Note that the IEnumerator documentation requires an InvalidOperationException to be thrown
        /// whenever the collection is modified. This has been done for changes in the size of the
        /// collection, but not when one of the elements of the collection is modified as it is a bit
        /// tricky to detect unmanaged code that modifies the collection under our feet.
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public sealed class ItemIdContainerEnumerator : global::System.Collections.IEnumerator
          , global::System.Collections.Generic.IEnumerator<uint>
        {
            private ItemIdContainer collectionRef;
            private int currentIndex;
            private object currentObject;
            private int currentSize;

            /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public ItemIdContainerEnumerator(ItemIdContainer collection)
            {
                collectionRef = collection;
                currentIndex = -1;
                currentObject = null;
                currentSize = collectionRef.Count;
            }

            // Type-safe iterator Current
            /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public uint Current
            {
                get
                {
                    if (currentIndex == -1)
                        throw new global::System.InvalidOperationException("Enumeration not started.");
                    if (currentIndex > currentSize - 1)
                        throw new global::System.InvalidOperationException("Enumeration finished.");
                    if (currentObject == null)
                        throw new global::System.InvalidOperationException("Collection modified.");
                    return (uint)currentObject;
                }
            }

            // Type-unsafe IEnumerator.Current
            object global::System.Collections.IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public bool MoveNext()
            {
                int size = collectionRef.Count;
                bool moveOkay = (currentIndex + 1 < size) && (size == currentSize);
                if (moveOkay)
                {
                    currentIndex++;
                    currentObject = collectionRef[currentIndex];
                }
                else
                {
                    currentObject = null;
                }
                return moveOkay;
            }

            /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void Reset()
            {
                currentIndex = -1;
                currentObject = null;
                if (collectionRef.Count != currentSize)
                {
                    throw new global::System.InvalidOperationException("Collection modified.");
                }
            }

            /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void Dispose()
            {
                currentIndex = -1;
                currentObject = null;
            }
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Clear()
        {
            Interop.ItemIdContainer.ItemIdContainer_Clear(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Add(uint x)
        {
            Interop.ItemIdContainer.ItemIdContainer_Add(swigCPtr, x);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        private uint size()
        {
            uint ret = Interop.ItemIdContainer.ItemIdContainer_size(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private uint capacity()
        {
            uint ret = Interop.ItemIdContainer.ItemIdContainer_capacity(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private void reserve(uint n)
        {
            Interop.ItemIdContainer.ItemIdContainer_reserve(swigCPtr, n);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ItemIdContainer() : this(Interop.ItemIdContainer.new_ItemIdContainer__SWIG_0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ItemIdContainer(ItemIdContainer other) : this(Interop.ItemIdContainer.new_ItemIdContainer__SWIG_1(ItemIdContainer.getCPtr(other)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ItemIdContainer(int capacity) : this(Interop.ItemIdContainer.new_ItemIdContainer__SWIG_2(capacity), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        private uint getitemcopy(int index)
        {
            uint ret = Interop.ItemIdContainer.ItemIdContainer_getitemcopy(swigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private uint getitem(int index)
        {
            uint ret = Interop.ItemIdContainer.ItemIdContainer_getitem(swigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private void setitem(int index, uint val)
        {
            Interop.ItemIdContainer.ItemIdContainer_setitem(swigCPtr, index, val);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AddRange(ItemIdContainer values)
        {
            Interop.ItemIdContainer.ItemIdContainer_AddRange(swigCPtr, ItemIdContainer.getCPtr(values));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ItemIdContainer GetRange(int index, int count)
        {
            global::System.IntPtr cPtr = Interop.ItemIdContainer.ItemIdContainer_GetRange(swigCPtr, index, count);
            ItemIdContainer ret = (cPtr == global::System.IntPtr.Zero) ? null : new ItemIdContainer(cPtr, true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Insert(int index, uint x)
        {
            Interop.ItemIdContainer.ItemIdContainer_Insert(swigCPtr, index, x);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void InsertRange(int index, ItemIdContainer values)
        {
            Interop.ItemIdContainer.ItemIdContainer_InsertRange(swigCPtr, index, ItemIdContainer.getCPtr(values));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RemoveAt(int index)
        {
            Interop.ItemIdContainer.ItemIdContainer_RemoveAt(swigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RemoveRange(int index, int count)
        {
            Interop.ItemIdContainer.ItemIdContainer_RemoveRange(swigCPtr, index, count);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ItemIdContainer Repeat(uint value, int count)
        {
            global::System.IntPtr cPtr = Interop.ItemIdContainer.ItemIdContainer_Repeat(value, count);
            ItemIdContainer ret = (cPtr == global::System.IntPtr.Zero) ? null : new ItemIdContainer(cPtr, true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Reverse()
        {
            Interop.ItemIdContainer.ItemIdContainer_Reverse__SWIG_0(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Reverse(int index, int count)
        {
            Interop.ItemIdContainer.ItemIdContainer_Reverse__SWIG_1(swigCPtr, index, count);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetRange(int index, ItemIdContainer values)
        {
            Interop.ItemIdContainer.ItemIdContainer_SetRange(swigCPtr, index, ItemIdContainer.getCPtr(values));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Contains(uint value)
        {
            bool ret = Interop.ItemIdContainer.ItemIdContainer_Contains(swigCPtr, value);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int IndexOf(uint value)
        {
            int ret = Interop.ItemIdContainer.ItemIdContainer_IndexOf(swigCPtr, value);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int LastIndexOf(uint value)
        {
            int ret = Interop.ItemIdContainer.ItemIdContainer_LastIndexOf(swigCPtr, value);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Remove(uint value)
        {
            bool ret = Interop.ItemIdContainer.ItemIdContainer_Remove(swigCPtr, value);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
    }
}
