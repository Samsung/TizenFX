 /*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */


using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Tizen.Network.IoTConnectivity
{
    /// <summary>
    /// This class contains resource types and provides APIs to manage, add, remove those types.
    /// A resource type indicates a class or category of resources.
    /// </summary>
    public class ResourceTypes : IEnumerable<string>, IDisposable
    {
        internal const int MaxLength = 61;
        internal IntPtr _resourceTypeHandle = IntPtr.Zero;
        private readonly HashSet<string> _resourceTypes = new HashSet<string>();
        private bool _disposed = false;

        /// <summary>
        /// Constructor of ResourceTypes
        /// </summary>
        /// <seealso cref="Add()"/>
        /// <seealso cref="Remove()"/>
        /// <exception cref="NotSupportedException">Thrown when the iotcon is not supported</exception>
        /// <exception cref="OutOfMemoryException">Thrown when there is not enough memory</exception>
        /// <code>
        /// ResourceTypes types = new ResourceTypes();
        /// </code>
        public ResourceTypes()
        {
            int ret = Interop.IoTConnectivity.Common.ResourceTypes.Create(out _resourceTypeHandle);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to create type");
                throw IoTConnectivityErrorFactory.GetException(ret);
            }
        }

        /// <summary>
        /// Constructor of ResourceTypes using list of types
        /// </summary>
        /// <param name="types">List of resource types</param>
        /// <exception cref="ArgumentException">Thrown when there is an invalid parameter</exception>
        /// <code>
        /// ResourceTypes types = new ResourceTypes(new List<string>() { "org.tizen.light", "oic.if.room" });
        /// </code>
        public ResourceTypes(IEnumerable<string> types)
        {
            int ret = Interop.IoTConnectivity.Common.ResourceTypes.Create(out _resourceTypeHandle);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to create type");
                throw IoTConnectivityErrorFactory.GetException(ret);
            }

            foreach (string type in types)
            {
                Add(type);
            }
        }

        internal ResourceTypes(IntPtr typesHandleToClone)
        {
            int ret = Interop.IoTConnectivity.Common.ResourceTypes.Clone(typesHandleToClone, out _resourceTypeHandle);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to create type");
                throw IoTConnectivityErrorFactory.GetException(ret);
            }

            Interop.IoTConnectivity.Common.ResourceTypes.ForeachCallback cb = (string type, IntPtr data) =>
            {
                _resourceTypes.Add(type);
                return true;
            };

            ret = Interop.IoTConnectivity.Common.ResourceTypes.Foreach(typesHandleToClone, cb, IntPtr.Zero);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to create type");
                throw IoTConnectivityErrorFactory.GetException(ret);
            }
        }

        /// <summary>
        /// Destructor of the ResourceTypes class.
        /// </summary>
        ~ResourceTypes()
        {
            Dispose(false);
        }

        /// <summary>
        /// Indicates count of types in the list
        /// </summary>
        /// <code>
        /// ResourceTypes types = new ResourceTypes(new List<string>() { "org.tizen.light", "oic.if.room" });
        /// Console.WriteLine("There are {0} items", types.Count);
        /// </code>
        public int Count
        {
            get
            {
                return _resourceTypes.Count;
            }
        }

        /// <summary>
        /// Adds a resource type into the list.
        /// </summary>
        /// <remarks>
        /// The length of @a item should be less than or equal to 61.\n
        /// The @a item must start with a lowercase alphabetic character, followed by a sequence
        /// of lowercase alphabetic, numeric, ".", or "-" characters, and contains no white space.\n
        /// Duplicate strings are not allowed.
        /// </remarks>
        /// <param name="item">The string data to insert into the resource types</param>
        /// <seealso cref="Remove()"/>
        /// <exception cref="NotSupportedException">Thrown when the iotcon is not supported</exception>
        /// <exception cref="ArgumentException">Thrown when there is an invalid parameter</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid</exception>
        /// <code>
        /// ResourceTypes resourceTypes = new ResourceTypes();
        /// resourceTypes.Add("org.tizen.light");
        /// </code>
        public void Add(string item)
        {
            if (IsValid(item))
            {
                int ret = Interop.IoTConnectivity.Common.ResourceTypes.Add(_resourceTypeHandle, item);
                if (ret != (int)IoTConnectivityError.None)
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to add type");
                    throw IoTConnectivityErrorFactory.GetException(ret);
                }
                _resourceTypes.Add(item);
            }
            else
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Invalid type");
                throw IoTConnectivityErrorFactory.GetException((int)IoTConnectivityError.InvalidParameter);
            }
        }

        /// <summary>
        /// Removes a resource type from the list
        /// </summary>
        /// <param name="item">The string data to delete from the resource types</param>
        /// <seealso cref="Add()"/>
        /// <exception cref="NotSupportedException">Thrown when the iotcon is not supported</exception>
        /// <exception cref="ArgumentException">Thrown when there is an invalid parameter</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid</exception>
        /// <code>
        /// ResourceTypes resourceTypes = new ResourceTypes(new List<string>() { "org.tizen.light", "oic.if.room" });
        /// resourceTypes.Remove("oic.if.room");
        /// </code>
        public void Remove(string item)
        {
            int ret = Interop.IoTConnectivity.Common.ResourceTypes.Remove(_resourceTypeHandle, item);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to remove type");
                throw IoTConnectivityErrorFactory.GetException(ret);
            }

            _resourceTypes.Remove(item);
        }

        /// <summary>
        /// Return enumerator for the list of types
        /// </summary>
        /// <returns>The enumerator</returns>
        /// <code>
        /// ResourceTypes resourceTypes = new ResourceTypes(new List<string>() { "org.tizen.light", "oic.if.room" });
        /// foreach(string item in resourceTypes)
        /// {
        ///     Console.WriteLine("Type : {0}", item);
        /// }
        /// </code>
        public IEnumerator<string> GetEnumerator()
        {
            return _resourceTypes.GetEnumerator();
        }

        /// <summary>
        /// Return enumerator for the list of types
        /// </summary>
        /// <returns>The enumerator</returns>
        /// <code>
        /// ResourceTypes resourceTypes = new ResourceTypes(new List<string>() { "org.tizen.light", "oic.if.room" });
        /// foreach(string item in resourceTypes)
        /// {
        ///     Console.WriteLine("Type : {0}", item);
        /// }
        /// </code>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _resourceTypes.GetEnumerator();
        }

        /// <summary>
        /// Releases any unmanaged resources used by this object.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        internal static bool IsValid(string type)
        {
            Regex r = new Regex("^[a-zA-Z0-9.-]+$");
            return (type.Length <= MaxLength && type.Length > 0 && char.IsLower(type[0]) && r.IsMatch(type));
        }

        /// <summary>
        /// Releases any unmanaged resources used by this object. Can also dispose any other disposable objects.
        /// </summary>
        /// <param name="disposing">If true, disposes any disposable objects. If false, does not dispose disposable objects.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                // Free managed objects
            }

            Interop.IoTConnectivity.Common.ResourceTypes.Destroy(_resourceTypeHandle);
            _disposed = true;
        }
    }
}
