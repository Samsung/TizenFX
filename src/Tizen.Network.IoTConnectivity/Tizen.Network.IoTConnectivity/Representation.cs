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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

namespace Tizen.Network.IoTConnectivity
{
    /// <summary>
    /// This class provides APIs to manage representation.
    /// A representation is a payload of a request or a response.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [Obsolete("Deprecated since API level 13")]
    public class Representation : IDisposable
    {
        internal IntPtr _representationHandle = IntPtr.Zero;

        private bool _disposed = false;
        private ObservableCollection<Representation> _children = new ObservableCollection<Representation>();

        /// <summary>
        /// The Representation constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <feature>http://tizen.org/feature/iot.ocf</feature>
        /// <exception cref="NotSupportedException">Thrown when the iotcon is not supported.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when there is not enough memory.</exception>
        /// <exception cref="ArgumentException">Thrown when there is an invalid parameter.</exception>
        /// <example><code>
        /// Representation repr = new Representation();
        /// </code></example>
        [Obsolete("Deprecated since API level 13")]
        public Representation()
        {
            int ret = Interop.IoTConnectivity.Common.Representation.Create(out _representationHandle);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to create representation");
                throw IoTConnectivityErrorFactory.GetException(ret);
            }

            _children.CollectionChanged += ChildrenCollectionChanged;
        }

        // Constructor for cloning native representation object
        internal Representation(IntPtr handleToClone)
        {
            int ret = (int)IoTConnectivityError.InvalidParameter;
            if (handleToClone != IntPtr.Zero)
            {
                ret = Interop.IoTConnectivity.Common.Representation.Clone(handleToClone, out _representationHandle);
            }
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to create representation");
                throw IoTConnectivityErrorFactory.GetException(ret);
            }

            _children.CollectionChanged += ChildrenCollectionChanged;
        }

        /// <summary>
        /// Destructor of the Representation class.
        /// </summary>
        ~Representation()
        {
            Dispose(false);
        }

        /// <summary>
        /// The URI path of resource.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>
        /// The URI path of resource.
        /// Setter can throw exceptions.
        /// </value>
        /// <exception cref="NotSupportedException">Thrown when the iotcon is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when there is an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid.</exception>
        /// <example><code>
        /// Representation repr = new Representation();
        /// repr.UriPath = "/a/light";
        /// Console.WriteLine("URI is {0}", repr.UriPath);  //Getter
        /// </code></example>
        [Obsolete("Deprecated since API level 13")]
        public string UriPath
        {
            get
            {
                IntPtr path;
                int ret = Interop.IoTConnectivity.Common.Representation.GetUriPath(_representationHandle, out path);
                if (ret != (int)IoTConnectivityError.None)
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to Get uri");
                    throw IoTConnectivityErrorFactory.GetException(ret);
                }
                return (path != IntPtr.Zero) ? Marshal.PtrToStringAnsi(path) : string.Empty;
            }
            set
            {
                int ret = (int)IoTConnectivityError.InvalidParameter;
                if (value != null)
                    ret = Interop.IoTConnectivity.Common.Representation.SetUriPath(_representationHandle, value);
                if (ret != (int)IoTConnectivityError.None)
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to set uri");
                    throw IoTConnectivityErrorFactory.GetException(ret);
                }
            }
        }

        /// <summary>
        /// The type of resource.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>The type of resource.</value>
        /// <seealso cref="ResourceTypes"/>
        /// <exception cref="NotSupportedException">Thrown when the iotcon is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when there is an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid.</exception>
        /// <example><code><![CDATA[
        /// Representation repr = new Representation();
        /// ResourceTypes types = new ResourceTypes (new List<string>(){ "org.tizen.light" });
        /// repr.Type = types;
        /// var type = repr.Type;   // Getter
        /// foreach (string item in type)
        /// {
        ///     Console.WriteLine("Type is {0}", item);
        /// }
        /// ]]></code></example>
        [Obsolete("Deprecated since API level 13")]
        public ResourceTypes Type
        {
            get
            {
                IntPtr typeHandle;
                int ret = Interop.IoTConnectivity.Common.Representation.GetResourceTypes(_representationHandle, out typeHandle);
                if (ret != (int)IoTConnectivityError.None)
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to get type");
                    return null;
                }
                return (typeHandle == IntPtr.Zero) ? null : new ResourceTypes(typeHandle);
            }
            set
            {
                int ret = (int)IoTConnectivityError.InvalidParameter;
                if (value != null)
                    ret = Interop.IoTConnectivity.Common.Representation.SetResourceTypes(_representationHandle, value._resourceTypeHandle);
                if (ret != (int)IoTConnectivityError.None)
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to set type");
                    throw IoTConnectivityErrorFactory.GetException(ret);
                }
            }
        }

        /// <summary>
        /// The interface of the resource.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>The interface of the resource.</value>
        /// <seealso cref="ResourceInterfaces"/>
        /// <exception cref="NotSupportedException">Thrown when the iotcon is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when there is an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid.</exception>
        /// <example><code><![CDATA[
        /// Representation repr = new Representation();
        /// ResourceInterfaces ifaces = new ResourceInterfaces (new List<string>(){ ResourceInterfaces.DefaultInterface });
        /// repr.Interface = ifaces;
        /// var iface = repr.Interface;   // Getter
        /// foreach (string item in iface)
        /// {
        ///     Console.WriteLine("Interface is {0}", iface);
        /// }
        /// ]]></code></example>
        [Obsolete("Deprecated since API level 13")]
        public ResourceInterfaces Interface
        {
            get
            {
                IntPtr interfaceHandle;
                int ret = Interop.IoTConnectivity.Common.Representation.GetResourceInterfaces(_representationHandle, out interfaceHandle);
                if (ret != (int)IoTConnectivityError.None)
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to get interface");
                    return null;
                }
                return (interfaceHandle == IntPtr.Zero) ? null : new ResourceInterfaces(interfaceHandle);
            }
            set
            {
                int ret = (int)IoTConnectivityError.InvalidParameter;
                if (value != null)
                    ret = Interop.IoTConnectivity.Common.Representation.SetResourceInterfaces(_representationHandle, value.ResourceInterfacesHandle);
                if (ret != (int)IoTConnectivityError.None)
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to set interface");
                    throw IoTConnectivityErrorFactory.GetException(ret);
                }
            }
        }

        /// <summary>
        /// Current attributes of the resource.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>Current attributes of the resource.</value>
        /// <seealso cref="Attributes"/>
        /// <exception cref="NotSupportedException">Thrown when the iotcon is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when there is an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid.</exception>
        /// <example><code>
        /// Representation repr = new Representation();
        /// Attributes attributes = new Attributes() {
        ///     { "state", "ON" },
        ///     { "dim", 10 }
        /// };
        /// repr.Attributes = attributes;
        /// var newAttributes = repr.Attributes;   // Getter
        /// string strval = newAttributes["state"] as string;
        /// int intval = (int)newAttributes["dim"];
        /// Console.WriteLine("attributes are {0} and {1}", strval, intval);
        /// </code></example>
        [Obsolete("Deprecated since API level 13")]
        public Attributes Attributes
        {
            get
            {
                IntPtr attributeHandle;
                int ret = Interop.IoTConnectivity.Common.Representation.GetAttributes(_representationHandle, out attributeHandle);
                if (ret != (int)IoTConnectivityError.None)
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to get attributes");
                    throw IoTConnectivityErrorFactory.GetException(ret);
                }
                return (attributeHandle == IntPtr.Zero) ? null : new Attributes(attributeHandle);
            }
            set
            {
                int ret = (int)IoTConnectivityError.InvalidParameter;
                if (value != null)
                {
                    ret = Interop.IoTConnectivity.Common.Representation.SetAttributes(_representationHandle, value._resourceAttributesHandle);
                    if (ret != (int)IoTConnectivityError.None)
                    {
                        Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to set attributes");
                        throw IoTConnectivityErrorFactory.GetException(ret);
                    }
                }
            }
        }

        /// <summary>
        /// List of Child resource representation.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>List of Child resource representation.</value>
        /// <example><code><![CDATA[
        /// Representation repr = new Representation();
        /// Representation child1 = new Representation();
        /// ResourceTypes types1 = new ResourceTypes(new List<string>() { "org.tizen.light" });
        /// child1.Type = types1;
        /// ResourceInterfaces ifaces1 = new ResourceInterfaces(new List<string>() { ResourceInterfaces.DefaultInterface });
        /// child1.Interface = ifaces1;
        /// try
        /// {
        ///     repr.Children.Add(child1);
        ///     Console.WriteLine("Number of children : {0}", repr.Children.Count);
        ///     Representation firstChild = repr.Children.ElementAt(0);
        /// } catch(Exception ex)
        /// {
        ///     Console.WriteLine("Exception caught : " + ex.Message);
        /// }
        /// ]]></code></example>
        [Obsolete("Deprecated since API level 13")]
        public ICollection<Representation> Children
        {
            get
            {
                return _children;
            }
        }

        /// <summary>
        /// Releases any unmanaged resources used by this object.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <feature>http://tizen.org/feature/iot.ocf</feature>
        [Obsolete("Deprecated since API level 13")]
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases any unmanaged resources used by this object. Can also dispose any other disposable objects.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="disposing">If true, disposes any disposable objects. If false, does not dispose disposable objects.</param>
        /// <feature>http://tizen.org/feature/iot.ocf</feature>
        [Obsolete("Deprecated since API level 13")]
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                // Free managed objects
                Type?.Dispose();
                Interface?.Dispose();
                Attributes?.Dispose();
                foreach(var child in Children)
                {
                    child.Dispose();
                }
            }

            Interop.IoTConnectivity.Common.Representation.Destroy(_representationHandle);
            _disposed = true;
        }

        private void ChildrenCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                foreach (Representation r in e.NewItems)
                {
                    int ret = Interop.IoTConnectivity.Common.Representation.AddChild(_representationHandle, r._representationHandle);
                    if (ret != (int)IoTConnectivityError.None)
                    {
                        Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to add child");
                        throw IoTConnectivityErrorFactory.GetException(ret);
                    }
                }
            }
            else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                foreach (Representation r in e.NewItems)
                {
                    int ret = Interop.IoTConnectivity.Common.Representation.RemoveChild(_representationHandle, r._representationHandle);
                    if (ret != (int)IoTConnectivityError.None)
                    {
                        Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to remove child");
                        throw IoTConnectivityErrorFactory.GetException(ret);
                    }
                }
            }
        }
    }
}
