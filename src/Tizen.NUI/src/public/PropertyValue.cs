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
    /// A value-type representing a property value.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class PropertyValue : Disposable
    {

        /// <summary>
        /// Creates a Size2D property value.
        /// </summary>
        /// <param name="vectorValue">Size2D values.</param>
        /// <since_tizen> 3 </since_tizen>
        public PropertyValue(Size2D vectorValue) : this(Interop.PropertyValue.NewPropertyValueVector2(Size2D.getCPtr(vectorValue)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Creates a Position2D property value.
        /// </summary>
        /// <param name="vectorValue">Position2D values.</param>
        /// <since_tizen> 3 </since_tizen>
        public PropertyValue(Position2D vectorValue) : this(Interop.PropertyValue.NewPropertyValueVector2(Position2D.getCPtr(vectorValue)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Creates a Position property value.
        /// </summary>
        /// <param name="vectorValue">Position values.</param>
        /// <since_tizen> 3 </since_tizen>
        public PropertyValue(Position vectorValue) : this(Interop.PropertyValue.NewPropertyValueVector3(Position.getCPtr(vectorValue)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Creates a Color property value.
        /// </summary>
        /// <param name="vectorValue">Color values.</param>
        /// <since_tizen> 3 </since_tizen>
        public PropertyValue(Color vectorValue) : this(Interop.PropertyValue.NewPropertyValueVector4(Color.getCPtr(vectorValue)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The default constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyValue() : this(Interop.PropertyValue.NewPropertyValue(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Creates a boolean property value.
        /// </summary>
        /// <param name="boolValue">A boolean value.</param>
        /// <since_tizen> 3 </since_tizen>
        public PropertyValue(bool boolValue) : this(Interop.PropertyValue.NewPropertyValue(boolValue), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Creates an integer property value.
        /// </summary>
        /// <param name="integerValue">An integer value.</param>
        /// <since_tizen> 3 </since_tizen>
        public PropertyValue(int integerValue) : this(Interop.PropertyValue.NewPropertyValue(integerValue), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Creates a float property value.
        /// </summary>
        /// <param name="floatValue">A floating-point value.</param>
        /// <since_tizen> 3 </since_tizen>
        public PropertyValue(float floatValue) : this(Interop.PropertyValue.NewPropertyValue(floatValue), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Creates a Vector2 property value.
        /// </summary>
        /// <param name="vectorValue">A vector of 2 floating-point values.</param>
        /// <since_tizen> 3 </since_tizen>
        public PropertyValue(Vector2 vectorValue) : this(Interop.PropertyValue.NewPropertyValueVector2(Vector2.getCPtr(vectorValue)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Creates a Vector3 property value.
        /// </summary>
        /// <param name="vectorValue">A vector of 3 floating-point values.</param>
        /// <since_tizen> 3 </since_tizen>
        public PropertyValue(Vector3 vectorValue) : this(Interop.PropertyValue.NewPropertyValueVector3(Vector3.getCPtr(vectorValue)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Creates a Vector4 property value.
        /// </summary>
        /// <param name="vectorValue">A vector of 4 floating-point values.</param>
        /// <since_tizen> 3 </since_tizen>
        public PropertyValue(Vector4 vectorValue) : this(Interop.PropertyValue.NewPropertyValueVector4(Vector4.getCPtr(vectorValue)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Creates a Rectangle property value.
        /// </summary>
        /// <param name="vectorValue">Rectangle values.</param>
        /// <since_tizen> 3 </since_tizen>
        public PropertyValue(Rectangle vectorValue) : this(Interop.PropertyValue.NewPropertyValueRect(Rectangle.getCPtr(vectorValue)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Creates a Rotation property value.
        /// </summary>
        /// <param name="quaternion">Rotation values.</param>
        /// <since_tizen> 3 </since_tizen>
        public PropertyValue(Rotation quaternion) : this(Interop.PropertyValue.NewPropertyValueQuaternion(Rotation.getCPtr(quaternion)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Creates a string property value.
        /// </summary>
        /// <param name="stringValue">A string.</param>
        /// <since_tizen> 3 </since_tizen>
        public PropertyValue(string stringValue) : this(Interop.PropertyValue.NewPropertyValueString(stringValue), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Creates an array property value.
        /// </summary>
        /// <param name="arrayValue">An array.</param>
        /// <since_tizen> 3 </since_tizen>
        public PropertyValue(PropertyArray arrayValue) : this(Interop.PropertyValue.NewPropertyValueArray(PropertyArray.getCPtr(arrayValue)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Creates a map property value.
        /// </summary>
        /// <param name="mapValue">An array.</param>
        /// <since_tizen> 3 </since_tizen>
        public PropertyValue(PropertyMap mapValue) : this(Interop.PropertyValue.NewPropertyValueMap(PropertyMap.getCPtr(mapValue)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Creates a Extents value.
        /// </summary>
        /// <param name="extentsValue">A Extents value.</param>
        /// <since_tizen> 4 </since_tizen>
        public PropertyValue(Extents extentsValue) : this(Interop.PropertyValue.NewPropertyValueExtents(Extents.getCPtr(extentsValue)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Creates a PropertyType value.
        /// </summary>
        /// <param name="type">A PropertyType value.</param>
        /// <since_tizen> 3 </since_tizen>
        public PropertyValue(PropertyType type) : this(Interop.PropertyValue.NewPropertyValueType((int)type), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Creates a PropertyValue value.
        /// </summary>
        /// <param name="value">A PropertyValue value.</param>
        /// <since_tizen> 3 </since_tizen>
        public PropertyValue(PropertyValue value) : this(Interop.PropertyValue.NewPropertyValueValue(PropertyValue.getCPtr(value)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Creates a Size property value.
        /// </summary>
        /// <param name="vectorValue">Size values.</param>
        internal PropertyValue(Size vectorValue) : this(Interop.PropertyValue.NewPropertyValueVector3(Size.getCPtr(vectorValue)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal PropertyValue(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        internal PropertyValue(Matrix3 matrixValue) : this(Interop.PropertyValue.NewPropertyValueMatrix3(Matrix3.getCPtr(matrixValue)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal PropertyValue(Matrix matrixValue) : this(Interop.PropertyValue.NewPropertyValueMatrix(Matrix.getCPtr(matrixValue)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal PropertyValue(AngleAxis angleAxis) : this(Interop.PropertyValue.NewPropertyValueAngleAxis(AngleAxis.getCPtr(angleAxis)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// An extension to the property value class that allows us to create a
        /// Property value from a C# object, for example, integer, float, or string.<br />
        /// </summary>
        /// <param name="obj">An object to create.</param>
        /// <returns>The created value.</returns>
        /// <exception cref="global::System.ArgumentNullException"> Thrown when obj is null. </exception>
        /// <since_tizen> 3 </since_tizen>
        static public PropertyValue CreateFromObject(System.Object obj)
        {
            if (null == obj)
            {
                throw new global::System.ArgumentNullException(nameof(obj));
            }

            System.Type type = obj.GetType();
            PropertyValue value;
            if (type.IsEnum)
            {
                value = new PropertyValue((int)obj);//Enum.Parse(type, str);
            }
            else if (type.Equals(typeof(int)))
            {
                value = new PropertyValue((int)obj);
            }
            else if (type.Equals(typeof(System.Int32)))
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
            else if (type.Equals(typeof(Extents)))
            {
                value = new PropertyValue((Extents)obj);
            }
            else if (type.Equals(typeof(Rectangle)))
            {
                value = new PropertyValue((Rectangle)obj);
            }
            else
            {
                throw new global::System.InvalidOperationException("Unimplemented type for Property Value :" + type.Name);
            }
            return value;
        }

        /// <summary>
        /// Retrieves a Size2D value.
        /// </summary>
        /// <param name="vectorValue"> On return, a Size2D value.</param>
        /// <since_tizen> 3 </since_tizen>
        public bool Get(Size2D vectorValue)
        {
            bool ret = Interop.PropertyValue.GetVector2(SwigCPtr, Size2D.getCPtr(vectorValue));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves a Position2D value.
        /// </summary>
        /// <param name="vectorValue"> On return, a Position2D value.</param>
        /// <since_tizen> 3 </since_tizen>
        public bool Get(Position2D vectorValue)
        {
            bool ret = Interop.PropertyValue.GetVector2(SwigCPtr, Position2D.getCPtr(vectorValue));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves a Size value.
        /// </summary>
        /// <param name="vectorValue"> On return, a size value.</param>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Get(Size vectorValue)
        {
            bool ret = Interop.PropertyValue.GetVector3(SwigCPtr, Size.getCPtr(vectorValue));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves a Position value.
        /// </summary>
        /// <param name="vectorValue"> On return, a position value.</param>
        /// <since_tizen> 3 </since_tizen>
        public bool Get(Position vectorValue)
        {
            bool ret = Interop.PropertyValue.GetVector3(SwigCPtr, Position.getCPtr(vectorValue));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves a Color value.
        /// </summary>
        /// <param name="vectorValue"> On return, a color value.</param>
        /// <since_tizen> 3 </since_tizen>
        public bool Get(Color vectorValue)
        {
            bool ret = Interop.PropertyValue.GetVector4(SwigCPtr, Color.getCPtr(vectorValue));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Queries the type of this property value.
        /// </summary>
        /// <returns>The type ID</returns>
        /// <since_tizen> 3 </since_tizen>
        public new PropertyType GetType()
        {
            PropertyType ret = (PropertyType)Interop.PropertyValue.PropertyValueGetType(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves a boolean value.
        /// </summary>
        /// <param name="boolValue">On return, a boolean value.</param>
        /// <returns>Returns true if the value is successfully retrieved, false if the type is not convertible.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool Get(out bool boolValue)
        {
            bool ret = Interop.PropertyValue.PropertyValueGet(SwigCPtr, out boolValue);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves a floating-point value.
        /// </summary>
        /// <param name="floatValue">On return, a floating-point value.</param>
        /// <returns>Returns true if the value is successfully retrieved, false if the type is not convertible.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool Get(out float floatValue)
        {
            bool ret = Interop.PropertyValue.PropertyValueGet(SwigCPtr, out floatValue);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves an integer value.
        /// </summary>
        /// <param name="integerValue">On return, an integer value.</param>
        /// <returns>Returns true if the value is successfully retrieved, false if the type is not convertible.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool Get(out int integerValue)
        {
            bool ret = Interop.PropertyValue.PropertyValueGet(SwigCPtr, out integerValue);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves an integer rectangle.
        /// </summary>
        /// <param name="rect">On return, an integer rectangle.</param>
        /// <returns>Returns true if the value is successfully retrieved, false if the type is not convertible.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool Get(Rectangle rect)
        {
            bool ret = Interop.PropertyValue.GetRect(SwigCPtr, Rectangle.getCPtr(rect));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves a vector value.
        /// </summary>
        /// <param name="vectorValue">On return, a vector value.</param>
        /// <returns>Returns true if the value is successfully retrieved, false if the type is not convertible.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool Get(Vector2 vectorValue)
        {
            bool ret = Interop.PropertyValue.GetVector2(SwigCPtr, Vector2.getCPtr(vectorValue));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves a vector value.
        /// </summary>
        /// <param name="vectorValue">On return, a vector value.</param>
        /// <returns>Returns true if the value is successfully retrieved, false if the type is not convertible.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool Get(Vector3 vectorValue)
        {
            bool ret = Interop.PropertyValue.GetVector3(SwigCPtr, Vector3.getCPtr(vectorValue));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves a vector value.
        /// </summary>
        /// <param name="vectorValue">On return, a vector value.</param>
        /// <returns>Returns true if the value is successfully retrieved, false if the type is not convertible.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool Get(Vector4 vectorValue)
        {
            bool ret = Interop.PropertyValue.GetVector4(SwigCPtr, Vector4.getCPtr(vectorValue));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves a vector value.
        /// </summary>
        /// <param name="vectorValue">On return, a vector value.</param>
        /// <returns>Returns true if the value is successfully retrieved, false if the type is not convertible.</returns>
        /// <since_tizen> 5 </since_tizen>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Get(RelativeVector2 vectorValue)
        {
            bool ret = Interop.PropertyValue.GetVector2(SwigCPtr, RelativeVector2.getCPtr(vectorValue));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves a vector value.
        /// </summary>
        /// <param name="vectorValue">On return, a vector value.</param>
        /// <returns>Returns true if the value is successfully retrieved, false if the type is not convertible.</returns>
        /// <since_tizen> 5 </since_tizen>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Get(RelativeVector3 vectorValue)
        {
            bool ret = Interop.PropertyValue.GetVector3(SwigCPtr, RelativeVector3.getCPtr(vectorValue));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves a vector value.
        /// </summary>
        /// <param name="vectorValue">On return, a vector value.</param>
        /// <returns>Returns true if the value is successfully retrieved, false if the type is not convertible.</returns>
        /// <since_tizen> 5 </since_tizen>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Get(RelativeVector4 vectorValue)
        {
            bool ret = Interop.PropertyValue.GetVector4(SwigCPtr, RelativeVector4.getCPtr(vectorValue));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves a rotation value.
        /// </summary>
        /// <param name="quaternionValue">On return, a rotation value.</param>
        /// <returns>Returns true if the value is successfully retrieved, false if the type is not convertible.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool Get(Rotation quaternionValue)
        {
            bool ret = Interop.PropertyValue.GetQuaternion(SwigCPtr, Rotation.getCPtr(quaternionValue));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves a string property value.
        /// </summary>
        /// <param name="stringValue">On return, a string.</param>
        /// <returns>Returns true if the value is successfully retrieved, false if the type is not convertible.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool Get(out string stringValue)
        {
            bool ret = Interop.PropertyValue.GetString(SwigCPtr, out stringValue);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves an array property value.
        /// </summary>
        /// <param name="arrayValue">On return, the array as a vector property values.</param>
        /// <returns>Returns true if the value is successfully retrieved, false if the type is not convertible.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool Get(PropertyArray arrayValue)
        {
            bool ret = Interop.PropertyValue.GetArray(SwigCPtr, PropertyArray.getCPtr(arrayValue));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves a map property value.
        /// </summary>
        /// <param name="mapValue">On return, the map as vector of string and property value pairs.</param>
        /// <returns>Returns true if the value is successfully retrieved, false if the type is not convertible.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool Get(PropertyMap mapValue)
        {
            bool ret = Interop.PropertyValue.GetMap(SwigCPtr, PropertyMap.getCPtr(mapValue));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves a Extents value.
        /// </summary>
        /// <param name="extentsValue">On return, a extents.</param>
        /// <returns>Returns true if the value is successfully retrieved, false if the type is not convertible.</returns>
        /// <since_tizen> 4 </since_tizen>
        public bool Get(Extents extentsValue)
        {
            bool ret = Interop.PropertyValue.GetExtents(SwigCPtr, Extents.getCPtr(extentsValue));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(PropertyValue obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        internal bool Get(Matrix3 matrixValue)
        {
            bool ret = Interop.PropertyValue.GetMatrix3(SwigCPtr, Matrix3.getCPtr(matrixValue));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal bool Get(Matrix matrixValue)
        {
            bool ret = Interop.PropertyValue.GetMatrix(SwigCPtr, Matrix.getCPtr(matrixValue));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal bool Get(AngleAxis angleAxisValue)
        {
            bool ret = Interop.PropertyValue.GetAngleAxis(SwigCPtr, AngleAxis.getCPtr(angleAxisValue));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.PropertyValue.DeletePropertyValue(swigCPtr);
        }

        internal static PropertyValue CreateWithGuard(string value)
        {
            return value == null ? new PropertyValue() : new PropertyValue(value);
        }

        internal static PropertyValue CreateWithGuard(Vector2 value)
        {
            return value == null ? new PropertyValue() : new PropertyValue(value);
        }

        internal static PropertyValue CreateWithGuard(Rectangle value)
        {
            return value == null ? new PropertyValue() : new PropertyValue(value);
        }

        internal static PropertyValue CreateWithGuard(Color value)
        {
            return value == null ? new PropertyValue() : new PropertyValue(value);
        }
    }
}
