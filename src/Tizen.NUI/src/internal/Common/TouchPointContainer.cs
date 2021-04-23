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

using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Tizen.NUI
{
    internal class TouchPointContainer : Disposable, IEnumerable, IEnumerable<TouchPoint>
    {
        internal TouchPointContainer(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        internal static HandleRef getCPtr(TouchPointContainer obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        protected override void ReleaseSwigCPtr(HandleRef swigCPtr)
        {
            Interop.TouchPointContainer.DeleteTouchPointContainer(swigCPtr);
        }

        public TouchPointContainer(ICollection c) : this()
        {
            if (c == null)
                throw new global::System.ArgumentNullException(nameof(c));
            foreach (TouchPoint element in c)
            {
                this.Add(element);
            }
        }

        public bool IsFixedSize
        {
            get
            {
                return false;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public TouchPoint this[int index]
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

        public int Count
        {
            get
            {
                return (int)size();
            }
        }

        public bool IsSynchronized
        {
            get
            {
                return false;
            }
        }

        public void CopyTo(TouchPoint[] array)
        {
            CopyTo(0, array, 0, this.Count);
        }

        public void CopyTo(TouchPoint[] array, int arrayIndex)
        {
            CopyTo(0, array, arrayIndex, this.Count);
        }

        public void CopyTo(int index, TouchPoint[] array, int arrayIndex, int count)
        {
            if (array == null)
                throw new global::System.ArgumentNullException(nameof(array));
            if (index < 0)
                throw new global::System.ArgumentOutOfRangeException(nameof(index), "Value is less than zero");
            if (arrayIndex < 0)
                throw new global::System.ArgumentOutOfRangeException(nameof(arrayIndex), "Value is less than zero");
            if (count < 0)
                throw new global::System.ArgumentOutOfRangeException(nameof(count), "Value is less than zero");
            if (array.Rank > 1)
                throw new global::System.ArgumentException("Multi dimensional array.", nameof(array));
            if (index + count > this.Count || arrayIndex + count > array.Length)
                throw new global::System.ArgumentException("Number of elements to copy is too large.");
            for (int i = 0; i < count; i++)
                array.SetValue(getitemcopy(index + i), arrayIndex + i);
        }

        IEnumerator<TouchPoint> IEnumerable<TouchPoint>.GetEnumerator()
        {
            return new TouchPointContainerEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new TouchPointContainerEnumerator(this);
        }

        public TouchPointContainerEnumerator GetEnumerator()
        {
            return new TouchPointContainerEnumerator(this);
        }

        // The type-safe enumerator.
        /// Note that the IEnumerator documentation requires an InvalidOperationException to be thrown
        /// whenever the collection is modified. This has been done for changes in the size of the
        /// collection, but not when one of the elements of the collection is modified as it is a bit
        /// tricky to detect unmanaged code that modifies the collection under our feet.
        public sealed class TouchPointContainerEnumerator : IEnumerator, IEnumerator<TouchPoint>
        {
            private TouchPointContainer collectionRef;
            private int currentIndex;
            private object currentObject;
            private int currentSize;

            public TouchPointContainerEnumerator(TouchPointContainer collection)
            {
                collectionRef = collection;
                currentIndex = -1;
                currentObject = null;
                currentSize = collectionRef.Count;
            }

            // Type-safe iterator Current
            public TouchPoint Current
            {
                get
                {
                    if (currentIndex == -1)
                        throw new global::System.InvalidOperationException("Enumeration not started.");
                    if (currentIndex > currentSize - 1)
                        throw new global::System.InvalidOperationException("Enumeration finished.");
                    if (currentObject == null)
                        throw new global::System.InvalidOperationException("Collection modified.");
                    return (TouchPoint)currentObject;
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

            public void Reset()
            {
                currentIndex = -1;
                currentObject = null;
                if (collectionRef.Count != currentSize)
                {
                    throw new global::System.InvalidOperationException("Collection modified.");
                }
            }

            public void Dispose()
            {
                currentIndex = -1;
                currentObject = null;
            }
        }

        public void Clear()
        {
            Interop.TouchPointContainer.Clear(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void Add(TouchPoint x)
        {
            Interop.TouchPointContainer.Add(SwigCPtr, TouchPoint.getCPtr(x));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        private uint size()
        {
            uint ret = Interop.TouchPointContainer.size(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private uint capacity()
        {
            uint ret = Interop.TouchPointContainer.capacity(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private void reserve(uint n)
        {
            Interop.TouchPointContainer.reserve(SwigCPtr, n);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public TouchPointContainer() : this(Interop.TouchPointContainer.NewTouchPointContainer(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public TouchPointContainer(TouchPointContainer other) : this(Interop.TouchPointContainer.NewTouchPointContainer(TouchPointContainer.getCPtr(other)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public TouchPointContainer(int capacity) : this(Interop.TouchPointContainer.NewTouchPointContainer(capacity), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        private TouchPoint getitemcopy(int index)
        {
            TouchPoint ret = new TouchPoint(Interop.TouchPointContainer.getitemcopy(SwigCPtr, index), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private TouchPoint getitem(int index)
        {
            TouchPoint ret = new TouchPoint(Interop.TouchPointContainer.getitem(SwigCPtr, index), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private void setitem(int index, TouchPoint val)
        {
            Interop.TouchPointContainer.setitem(SwigCPtr, index, TouchPoint.getCPtr(val));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void AddRange(TouchPointContainer values)
        {
            Interop.TouchPointContainer.AddRange(SwigCPtr, TouchPointContainer.getCPtr(values));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public TouchPointContainer GetRange(int index, int count)
        {
            global::System.IntPtr cPtr = Interop.TouchPointContainer.GetRange(SwigCPtr, index, count);
            TouchPointContainer ret = (cPtr == global::System.IntPtr.Zero) ? null : new TouchPointContainer(cPtr, true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void Insert(int index, TouchPoint x)
        {
            Interop.TouchPointContainer.Insert(SwigCPtr, index, TouchPoint.getCPtr(x));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void InsertRange(int index, TouchPointContainer values)
        {
            Interop.TouchPointContainer.InsertRange(SwigCPtr, index, TouchPointContainer.getCPtr(values));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void RemoveAt(int index)
        {
            Interop.TouchPointContainer.RemoveAt(SwigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void RemoveRange(int index, int count)
        {
            Interop.TouchPointContainer.RemoveRange(SwigCPtr, index, count);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public static TouchPointContainer Repeat(TouchPoint value, int count)
        {
            global::System.IntPtr cPtr = Interop.TouchPointContainer.Repeat(TouchPoint.getCPtr(value), count);
            TouchPointContainer ret = (cPtr == global::System.IntPtr.Zero) ? null : new TouchPointContainer(cPtr, true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void Reverse()
        {
            Interop.TouchPointContainer.Reverse(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void Reverse(int index, int count)
        {
            Interop.TouchPointContainer.Reverse(SwigCPtr, index, count);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void SetRange(int index, TouchPointContainer values)
        {
            Interop.TouchPointContainer.SetRange(SwigCPtr, index, TouchPointContainer.getCPtr(values));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
    }
}
