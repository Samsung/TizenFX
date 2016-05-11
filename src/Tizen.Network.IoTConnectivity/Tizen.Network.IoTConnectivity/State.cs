/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Tizen.Network.IoTConnectivity
{
    /// <summary>
    /// State represents current state of a resource
    /// </summary>
    public class State : IDictionary<string, object>, IDisposable
    {
        internal IntPtr _resourceStateHandle = IntPtr.Zero;
        private readonly IDictionary<string, object> _state = new Dictionary<string, object>();
        private bool _disposed = false;

        /// <summary>
        /// Constructor
        /// </summary>
        public State()
        {
            int ret = Interop.IoTConnectivity.Common.State.Create(out _resourceStateHandle);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to create state handle");
                throw IoTConnectivityErrorFactory.GetException(ret);
            }
        }

        internal State(IntPtr stateHandleToClone)
        {
            int ret = Interop.IoTConnectivity.Common.State.Clone(stateHandleToClone, out _resourceStateHandle);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to create state handle");
                throw IoTConnectivityErrorFactory.GetException(ret);
            }

            SetState(stateHandleToClone);
        }

        ~State()
        {
            Dispose(false);
        }

        /// <summary>
        /// Gets the number of status elements
        /// </summary>
        public int Count
        {
            get
            {
                return _state.Count;
            }
        }

        /// <summary>
        /// Represents whether State is readonly
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                return _state.IsReadOnly;
            }
        }

        /// <summary>
        /// Contains all the status keys
        /// </summary>
        public ICollection<string> Keys
        {
            get
            {
                return _state.Keys;
            }
        }

        /// <summary>
        /// Contains all the status values
        /// </summary>
        public ICollection<object> Values
        {
            get
            {
                return _state.Values;
            }
        }

        /// <summary>
        /// Gets or sets the status with the specified key.
        /// </summary>
        /// <param name="key">The key of the status to get or set.</param>
        /// <returns>The element with the specified key.</returns>
        public object this[string key]
        {
            get
            {
                return _state[key];
            }

            set
            {
                Add(key, value);
            }
        }

        /// <summary>
        /// Adds status key and value as a key value pair
        /// </summary>
        /// <param name="item">The item to add</param>
        public void Add(KeyValuePair<string, object> item)
        {
            Add(item.Key, item.Value);
        }

        /// <summary>
        /// Adds status element
        /// </summary>
        /// <param name="key">The key representing the state</param>
        /// <param name="value">The value representing the state</param>
        public void Add(string key, object value)
        {
            int ret = 0;
            if (value is int)
            {
                ret = Interop.IoTConnectivity.Common.State.AddInt(_resourceStateHandle, key, (int)value);
                if (ret != (int)IoTConnectivityError.None)
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to add int");
                    throw IoTConnectivityErrorFactory.GetException(ret);
                }
            }
            else if (value is State)
            {
                State state = (State)value;
                ret = Interop.IoTConnectivity.Common.State.AddState(_resourceStateHandle, key, state._resourceStateHandle);
                if (ret != (int)IoTConnectivityError.None)
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to add state");
                    throw IoTConnectivityErrorFactory.GetException(ret);
                }
            }
            else if (value is string)
            {
                ret = Interop.IoTConnectivity.Common.State.AddStr(_resourceStateHandle, key, (string)value);
                if (ret != (int)IoTConnectivityError.None)
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to add string");
                    throw IoTConnectivityErrorFactory.GetException(ret);
                }
            }
            else if (value is double)
            {
                ret = Interop.IoTConnectivity.Common.State.AddDouble(_resourceStateHandle, key, (double)value);
                if (ret != (int)IoTConnectivityError.None)
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to add double");
                    throw IoTConnectivityErrorFactory.GetException(ret);
                }
            }
            else if (value is bool)
            {
                ret = Interop.IoTConnectivity.Common.State.AddBool(_resourceStateHandle, key, (bool)value);
                if (ret != (int)IoTConnectivityError.None)
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to add bool");
                    throw IoTConnectivityErrorFactory.GetException(ret);
                }
            }
            else if (value is byte[])
            {
                byte[] val = value as byte[];
                if (val == null)
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to get byte[] val");
                    throw new ArgumentException("Invalid Parameter");
                }
                ret = Interop.IoTConnectivity.Common.State.AddByteStr(_resourceStateHandle, key, val, val.Length);
                if (ret != (int)IoTConnectivityError.None)
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to add bool");
                    throw IoTConnectivityErrorFactory.GetException(ret);
                }
            }
            else if (value is IEnumerable)
            {
                IntPtr listHandle = List.GetListHandle(value);
                ret = Interop.IoTConnectivity.Common.State.AddList(_resourceStateHandle, key, listHandle);
                Interop.IoTConnectivity.Common.State.Destroy(listHandle);
                if (ret != (int)IoTConnectivityError.None)
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to add state");
                    throw IoTConnectivityErrorFactory.GetException(ret);
                }
            }
            else
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to Add");
                throw IoTConnectivityErrorFactory.GetException((int)IoTConnectivityError.InvalidParameter);
            }
            _state.Add(key, value);
        }

        /// <summary>
        /// Clears state collection
        /// </summary>
        public void Clear()
        {
            foreach (string key in _state.Keys)
            {
                int ret = Interop.IoTConnectivity.Common.State.Remove(_resourceStateHandle, key);
                if (ret != (int)IoTConnectivityError.None)
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to clear state");
                    throw IoTConnectivityErrorFactory.GetException(ret);
                }
            }
            _state.Clear();
        }

        /// <summary>
        /// Checks the given key value pair exists in state collection
        /// </summary>
        /// <param name="item">The status key value pair</param>
        /// <returns>true if exists. Otherwise, false</returns>
        public bool Contains(KeyValuePair<string, object> item)
        {
            return _state.Contains(item);
        }

        /// <summary>
        /// Checks the given key exists in state collection
        /// </summary>
        /// <param name="key">The status key</param>
        /// <returns>true if exists. Otherwise, false</returns>
        public bool ContainsKey(string key)
        {
            return _state.ContainsKey(key);
        }

        /// <summary>
        /// Copies the elements of the state to an Array, starting at a particular index.
        /// </summary>
        /// <param name="array">The destination array</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
        {
            _state.CopyTo(array, arrayIndex);
        }

        /// <summary>
        ///   Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns> An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            return _state.GetEnumerator();
        }

        /// <summary>
        /// Removes a state element from collection
        /// </summary>
        /// <param name="item">The state element to remove</param>
        /// <returns>true if operation is success. Otherwise, false</returns>
        public bool Remove(KeyValuePair<string, object> item)
        {
            int ret = Interop.IoTConnectivity.Common.State.Remove(_resourceStateHandle, item.Key);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to remove state");
                throw IoTConnectivityErrorFactory.GetException(ret);
            }

            return _state.Remove(item);
        }

        /// <summary>
        ///  Removes a state element from collection using key
        /// </summary>
        /// <param name="key">The state element to remove</param>
        /// <returns>true if operation is success. Otherwise, false</returns>
        public bool Remove(string key)
        {
            int ret = Interop.IoTConnectivity.Common.State.Remove(_resourceStateHandle, key);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to remove state");
                throw IoTConnectivityErrorFactory.GetException(ret);
            }

            return _state.Remove(key);
        }

        /// <summary>
        /// Gets the value associated with the specified key.
        /// </summary>
        /// <param name="key">The key whose value to get.</param>
        /// <param name="value"> The value associated with the specified key</param>
        /// <returns> true if the state collection contains an element with the specified key; otherwise, false.</returns>
        public bool TryGetValue(string key, out object value)
        {
            return _state.TryGetValue(key, out value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _state.GetEnumerator();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                // Free managed objects
            }

            Interop.IoTConnectivity.Common.State.Destroy(_resourceStateHandle);
            _disposed = true;
        }

        private void SetState(IntPtr stateHandle)
        {
            Interop.IoTConnectivity.Common.State.StateCallback cb = (IntPtr state, string key, IntPtr userData) =>
            {
                Interop.IoTConnectivity.Common.DataType type = 0;
                int ret = Interop.IoTConnectivity.Common.State.GetType(state, key, out type);
                if (ret != (int)IoTConnectivityError.None)
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to get type");
                    throw IoTConnectivityErrorFactory.GetException(ret);
                }
                switch (type)
                {
                    case Interop.IoTConnectivity.Common.DataType.Int:
                        {
                            int value;
                            ret = Interop.IoTConnectivity.Common.State.GetInt(state, key, out value);
                            if (ret != (int)IoTConnectivityError.None)
                            {
                                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to get state");
                                throw IoTConnectivityErrorFactory.GetException(ret);
                            }
                            Add(key, value);
                            break;
                        }
                    case Interop.IoTConnectivity.Common.DataType.Bool:
                        {
                            bool value;
                            ret = Interop.IoTConnectivity.Common.State.GetBool(state, key, out value);
                            if (ret != (int)IoTConnectivityError.None)
                            {
                                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to get state");
                                throw IoTConnectivityErrorFactory.GetException(ret);
                            }
                            Add(key, value);
                            break;
                        }
                    case Interop.IoTConnectivity.Common.DataType.Double:
                        {
                            double value;
                            ret = Interop.IoTConnectivity.Common.State.GetDouble(state, key, out value);
                            if (ret != (int)IoTConnectivityError.None)
                            {
                                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to get state");
                                throw IoTConnectivityErrorFactory.GetException(ret);
                            }
                            Add(key, value);
                            break;
                        }
                    case Interop.IoTConnectivity.Common.DataType.String:
                        {
                            string value;
                            ret = Interop.IoTConnectivity.Common.State.GetStr(state, key, out value);
                            if (ret != (int)IoTConnectivityError.None)
                            {
                                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to get state");
                                throw IoTConnectivityErrorFactory.GetException(ret);
                            }
                            Add(key, value);
                            break;
                        }
                    case Interop.IoTConnectivity.Common.DataType.ByteStr:
                        {
                            IntPtr byteStrPtr;
                            int byteStrSize;
                            ret = Interop.IoTConnectivity.Common.State.GetByteStr(state, key, out byteStrPtr, out byteStrSize);
                            if (ret != (int)IoTConnectivityError.None)
                            {
                                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to get state");
                                throw IoTConnectivityErrorFactory.GetException(ret);
                            }
                            byte[] byteStr = new byte[byteStrSize];
                            Marshal.Copy(byteStrPtr, byteStr, 0, byteStrSize);
                            Add(key, byteStr);
                            break;
                        }
                    case Interop.IoTConnectivity.Common.DataType.Null:
                        {
                            Add(key, null);
                            break;
                        }
                    case Interop.IoTConnectivity.Common.DataType.List:
                        {
                            IntPtr listHandle;
                            ret = Interop.IoTConnectivity.Common.State.GetList(state, key, out listHandle);
                            if (ret != (int)IoTConnectivityError.None)
                            {
                                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to get state");
                                throw IoTConnectivityErrorFactory.GetException(ret);
                            }
                            Add(key, List.GetList(listHandle));
                            break;
                        }
                    case Interop.IoTConnectivity.Common.DataType.State:
                        {
                            IntPtr stateHndle;
                            ret = Interop.IoTConnectivity.Common.State.GetState(state, key, out stateHndle);
                            if (ret != (int)IoTConnectivityError.None)
                            {
                                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to get state");
                                throw IoTConnectivityErrorFactory.GetException(ret);
                            }
                            Add(key, new State(stateHndle));
                            break;
                        }
                    default:
                        break;
                }

                return true;
            };

            int res = Interop.IoTConnectivity.Common.State.Foreach(stateHandle, cb, IntPtr.Zero);
            if (res != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to remove state");
                throw IoTConnectivityErrorFactory.GetException(res);
            }
        }
    }

    internal static class List
    {
        internal static IntPtr GetListHandle(object list)
        {
            IntPtr listHandle = IntPtr.Zero;
            int ret;
            int pos = 0;

            if (list is IEnumerable<IEnumerable>)
            {
                ret = Interop.IoTConnectivity.Common.List.Create(Interop.IoTConnectivity.Common.DataType.List, out listHandle);
                pos = 0;
                foreach (IEnumerable val in (IEnumerable<IEnumerable>)list)
                {
                    IntPtr childList = GetListHandle(val);
                    ret = Interop.IoTConnectivity.Common.List.AddList(listHandle, childList, pos++);
                    if (ret != (int)IoTConnectivityError.None)
                    {
                        Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to add state");
                        Interop.IoTConnectivity.Common.List.Destroy(childList);
                        throw IoTConnectivityErrorFactory.GetException(ret);
                    }
                }
            }
            else if (list is IEnumerable<int>)
            {
                ret = Interop.IoTConnectivity.Common.List.Create(Interop.IoTConnectivity.Common.DataType.Int, out listHandle);
                pos = 0;
                foreach (int val in (IEnumerable<int>)list)
                {
                    ret = Interop.IoTConnectivity.Common.List.AddInt(listHandle, val, pos++);
                    if (ret != (int)IoTConnectivityError.None)
                    {
                        Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to add state");
                        throw IoTConnectivityErrorFactory.GetException(ret);
                    }
                }
            }
            else if (list is IEnumerable<string>)
            {
                ret = Interop.IoTConnectivity.Common.List.Create(Interop.IoTConnectivity.Common.DataType.String, out listHandle);
                pos = 0;
                foreach (string val in (IEnumerable<string>)list)
                {
                    ret = Interop.IoTConnectivity.Common.List.AddStr(listHandle, val, pos++);
                    if (ret != (int)IoTConnectivityError.None)
                    {
                        Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to add state");
                        throw IoTConnectivityErrorFactory.GetException(ret);
                    }
                }
            }
            else if (list is IEnumerable<double>)
            {
                ret = Interop.IoTConnectivity.Common.List.Create(Interop.IoTConnectivity.Common.DataType.Double, out listHandle);
                pos = 0;
                foreach (double val in (IEnumerable<double>)list)
                {
                    ret = Interop.IoTConnectivity.Common.List.AddDouble(listHandle, val, pos++);
                    if (ret != (int)IoTConnectivityError.None)
                    {
                        Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to add state");
                        throw IoTConnectivityErrorFactory.GetException(ret);
                    }
                }
            }
            else if (list is IEnumerable<bool>)
            {
                ret = Interop.IoTConnectivity.Common.List.Create(Interop.IoTConnectivity.Common.DataType.Bool, out listHandle);
                pos = 0;
                foreach (bool val in (IEnumerable<bool>)list)
                {
                    ret = Interop.IoTConnectivity.Common.List.AddBool(listHandle, val, pos++);
                    if (ret != (int)IoTConnectivityError.None)
                    {
                        Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to add state");
                        throw IoTConnectivityErrorFactory.GetException(ret);
                    }
                }
            }
            else if (list is IEnumerable<State>)
            {
                ret = Interop.IoTConnectivity.Common.List.Create(Interop.IoTConnectivity.Common.DataType.State, out listHandle);
                pos = 0;
                foreach (State val in (IEnumerable<State>)list)
                {
                    ret = Interop.IoTConnectivity.Common.List.AddState(listHandle, val._resourceStateHandle, pos++);
                    if (ret != (int)IoTConnectivityError.None)
                    {
                        Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to add state");
                        throw IoTConnectivityErrorFactory.GetException(ret);
                    }
                }
            }
            else if (list is IEnumerable<byte[]>)
            {
                ret = Interop.IoTConnectivity.Common.List.Create(Interop.IoTConnectivity.Common.DataType.ByteStr, out listHandle);
                pos = 0;
                foreach (byte[] val in (IEnumerable<byte[]>)list)
                {
                    ret = Interop.IoTConnectivity.Common.List.AddByteStr(listHandle, val, val.Length, pos++);
                    if (ret != (int)IoTConnectivityError.None)
                    {
                        Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to add byte[]");
                        throw IoTConnectivityErrorFactory.GetException(ret);
                    }
                }
            }
            else
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to GetListHandle");
                throw IoTConnectivityErrorFactory.GetException((int)IoTConnectivityError.InvalidParameter);
            }
            return listHandle;
        }

        internal static object GetList(IntPtr listHandle)
        {
            IList list = null;
            int type;
            int ret = Interop.IoTConnectivity.Common.List.GetType(listHandle, out type);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to get type");
                throw IoTConnectivityErrorFactory.GetException(ret);
            }
            switch ((Interop.IoTConnectivity.Common.DataType)type)
            {
                case Interop.IoTConnectivity.Common.DataType.Int:
                    {
                        list = new List<int>();
                        Interop.IoTConnectivity.Common.List.IntCallback cb = (int pos, int value, IntPtr userData) =>
                        {
                            list.Add(value);
                            return true;
                        };
                        ret = Interop.IoTConnectivity.Common.List.ForeachInt(listHandle, cb, IntPtr.Zero);
                        break;
                    }
                case Interop.IoTConnectivity.Common.DataType.Bool:
                    {
                        list = new List<bool>();
                        Interop.IoTConnectivity.Common.List.BoolCallback cb = (int pos, bool value, IntPtr userData) =>
                        {
                            list.Add(value);
                            return true;
                        };
                        ret = Interop.IoTConnectivity.Common.List.ForeachBool(listHandle, cb, IntPtr.Zero);
                        break;
                    }
                case Interop.IoTConnectivity.Common.DataType.Double:
                    {
                        list = new List<double>();
                        Interop.IoTConnectivity.Common.List.DoubleCallback cb = (int pos, double value, IntPtr userData) =>
                        {
                            list.Add(value);
                            return true;
                        };
                        ret = Interop.IoTConnectivity.Common.List.ForeachDouble(listHandle, cb, IntPtr.Zero);
                        break;
                    }
                case Interop.IoTConnectivity.Common.DataType.String:
                    {
                        list = new List<string>();
                        Interop.IoTConnectivity.Common.List.StrCallback cb = (int pos, string value, IntPtr userData) =>
                        {
                            list.Add(value);
                            return true;
                        };
                        ret = Interop.IoTConnectivity.Common.List.ForeachStr(listHandle, cb, IntPtr.Zero);
                        break;
                    }
                case Interop.IoTConnectivity.Common.DataType.State:
                    {
                        list = new List<State>();
                        Interop.IoTConnectivity.Common.List.StateCallback cb = (int pos, IntPtr value, IntPtr userData) =>
                        {
                            list.Add(new State(value));
                            return true;
                        };
                        ret = Interop.IoTConnectivity.Common.List.ForeachState(listHandle, cb, IntPtr.Zero);
                        break;
                    }
                case Interop.IoTConnectivity.Common.DataType.ByteStr:
                    {
                        list = new List<byte[]>();
                        Interop.IoTConnectivity.Common.List.ByteStrCallback cb = (int pos, byte[] value, int len, IntPtr userData) =>
                        {
                            list.Add(value);
                            return true;
                        };
                        ret = Interop.IoTConnectivity.Common.List.ForeachByteStr(listHandle, cb, IntPtr.Zero);
                        break;
                    }
                case Interop.IoTConnectivity.Common.DataType.List:
                    {
                        list = new List<List<object>>();
                        Interop.IoTConnectivity.Common.List.ListCallback cb = (int pos, IntPtr value, IntPtr userData) =>
                        {
                            object childList = GetList(value);
                            list.Add(childList);
                            return true;
                        };
                        ret = Interop.IoTConnectivity.Common.List.ForeachList(listHandle, cb, IntPtr.Zero);
                        break;
                    }
                default:
                    break;
            }
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to get state");
                throw IoTConnectivityErrorFactory.GetException(ret);
            }
            return list;
        }
    }
}
