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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Tizen.NUI;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Xaml.Forms
{
    /// <summary>
    /// BaseHandle is a handle to an internal Dali resource.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class BaseHandle : Element, global::System.IDisposable
    {
        static private Dictionary<Tizen.NUI.BaseHandle, BaseHandle> nuiInstanceToInstanceDict = new Dictionary<Tizen.NUI.BaseHandle, BaseHandle>();

        static public BaseHandle GetHandle(Tizen.NUI.BaseHandle nuiInstance)
        {
            BaseHandle ret;
            nuiInstanceToInstanceDict.TryGetValue(nuiInstance, out ret);

            return ret;
        }

        static private void RemoveHandle(Tizen.NUI.BaseHandle nuiInstance)
        {
            nuiInstanceToInstanceDict.Remove(nuiInstance);
        }

        private Tizen.NUI.BaseHandle handle;
        public Tizen.NUI.BaseHandle handleInstance
        {
            get
            {
                return handle;
            }
        }

        protected void SetNUIInstance(Tizen.NUI.BaseHandle _handle)
        {
            if (handle != _handle)
            {
                handle = _handle;

                if (null != handle)
                {
                    nuiInstanceToInstanceDict.Add(handle, this);
                    handle.DisposeEvent += (object obj, Tizen.NUI.BaseHandle.DisposeEventArgs arg) =>
                    {
                        Dispose(arg.type);
                    };
                }
            }
        }

        internal BaseHandle(Tizen.NUI.BaseHandle nuiInstance)
        {
            SetNUIInstance(nuiInstance);
        }

        /// <summary>
        /// Event when a property is set.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public event PropertyChangedEventHandler PropertySet
        {
            add
            {
                handle.PropertySet += value;
            }
            remove
            {
                handle.PropertySet -= value;
            }
        }

        /// <summary>
        /// Returns the bool value true to indicate that an operand is true and returns false otherwise.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static bool operator true(BaseHandle handle)
        {
            if (BaseHandle.ReferenceEquals(handle, null))
            {
                return false;
            }
            else
            {
                return handle.handle.HasBody();
            }
        }

        /// <summary>
        /// Returns the bool false  to indicate that an operand is false and returns true otherwise.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static bool operator false(BaseHandle handle)
        {
            if (BaseHandle.ReferenceEquals(handle, null))
            {
                return true;
            }
            else
            {
                return !handle.handle.HasBody();
            }
        }

        /// <summary>
        /// Explicit conversion from Handle to bool.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static explicit operator bool(BaseHandle handle)
        {
            if (BaseHandle.ReferenceEquals(handle, null))
            {
                return false;
            }
            else
            {
                return handle.handle.HasBody();
            }
        }

        /// <summary>
        /// Equality operator
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static bool operator ==(BaseHandle x, BaseHandle y)
        {
            if (BaseHandle.ReferenceEquals(x, null) && BaseHandle.ReferenceEquals(y, null))
            {
                return true;
            }
            else if (BaseHandle.ReferenceEquals(x, null) || BaseHandle.ReferenceEquals(y, null))
            {
                return false;
            }
            else
            {
                return x.handle == y.handle;
            }
        }

        /// <summary>
        /// Inequality operator. Returns Null if either operand is Null
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static bool operator !=(BaseHandle x, BaseHandle y)
        {
            return !(x == y);
        }

        /// <summary>
        /// Logical AND operator.<br />
        /// It's possible when doing a  operator this function (opBitwiseAnd) is never called due to short circuiting.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static BaseHandle operator &(BaseHandle x, BaseHandle y)
        {
            if (x == y)
            {
                return x;
            }
            return null;
        }

        /// <summary>
        /// Logical OR operator for ||.<br />
        /// It's possible when doing a || this function (opBitwiseOr) is never called due to short circuiting.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static BaseHandle operator |(BaseHandle x, BaseHandle y)
        {
            if (!BaseHandle.ReferenceEquals(x, null) || !BaseHandle.ReferenceEquals(y, null))
            {
                if (x.HasBody())
                {
                    return x;
                }
                if (y.HasBody())
                {
                    return y;
                }
                return null;
            }
            return null;
        }

        /// <summary>
        /// Logical ! operator
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static bool operator !(BaseHandle x)
        {
            // if the C# object is null, return true
            if (BaseHandle.ReferenceEquals(x, null))
            {
                return true;
            }
            if (x.HasBody())
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="o">The object should be compared.</param>
        /// <returns>True if equal.</returns>
        /// <since_tizen> 5 </since_tizen>
        public override bool Equals(object o)
        {
            return base.Equals(o);
        }

        /// <summary>
        /// Gets the the hash code of this baseHandle.
        /// </summary>
        /// <returns>The hash code.</returns>
        /// <since_tizen> 5 </since_tizen>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Dispose()
        {
            BaseHandle.RemoveHandle(handle);
            handle.Dispose();
        }

        protected virtual void Dispose(DisposeTypes type)
        {

        }

        /// <summary>
        /// Performs an action on this object with the given action name and attributes.
        /// </summary>
        /// <param name="actionName">The command for the action.</param>
        /// <param name="attributes">The list of attributes for the action.</param>
        /// <returns>The action is performed by the object or not.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool DoAction(string actionName, PropertyMap attributes)
        {
            return handle.DoAction(actionName, attributes);
        }

        /// <summary>
        /// Returns the type name for the Handle.<br />
        /// Will return an empty string if the typename does not exist. This will happen for types that
        /// have not registered with type-registry.
        /// </summary>
        /// <returns>The type name. Empty string if the typename does not exist.</returns>
        /// <since_tizen> 3 </since_tizen>
        public string GetTypeName()
        {
            return handle.GetTypeName();
        }

        /// <summary>
        /// Returns the type info for the Handle.<br />
        /// </summary>
        /// <param name="info">The type information.</param>
        /// <returns>True If get the type info.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool GetTypeInfo(TypeInfo info)
        {
            return handle.GetTypeInfo(info);
        }

        /// <summary>
        /// Resets the handle.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Reset()
        {
            handle.Reset();
        }

        /// <summary>
        /// To check the BaseHandle instance is equal or not.
        /// </summary>
        /// <param name="rhs">The baseHandle instance.</param>
        /// <returns>True If equal.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool EqualTo(BaseHandle rhs)
        {
            return handle.EqualTo(rhs.handle);
        }

        /// <summary>
        /// To check the BaseHandle instance is equal or not.
        /// </summary>
        /// <param name="rhs">The baseHandle instance.</param>
        /// <returns>True If not equal.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool NotEqualTo(BaseHandle rhs)
        {
            return handle.NotEqualTo(rhs.handle);
        }

        /// <summary>
        /// To check the BaseHandle instance has body or not.
        /// </summary>
        /// <returns>True If the baseHandle instance has body.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool HasBody()
        {
            if (BaseHandle.ReferenceEquals(handle, null))
            {
                return false;
            }
            else
            {
                return handle.HasBody();
            }
        }

        /// <summary>
        /// To check the BaseHandle instance is equal or not.
        /// </summary>
        /// <param name="rhs">The baseHandle instance.</param>
        /// <returns>True If equal.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool IsEqual(BaseHandle rhs)
        {
            return handle.IsEqual(rhs.handle);
        }
    }
}
