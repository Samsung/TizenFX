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

using System;
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

        private static IntPtr NewPropertyValueCPtrByPosition(Position position)
        {
            if (null == position)
            {
                throw new ArgumentNullException(nameof(position));
            }

            return Interop.PropertyValue.NewPropertyValueVector3Componentwise(position.X, position.Y, position.Z);
        }

        /// <summary>
        /// Creates a Position property value.
        /// </summary>
        /// <param name="vectorValue">Position values.</param>
        /// <since_tizen> 3 </since_tizen>
        public PropertyValue(Position vectorValue) : this(NewPropertyValueCPtrByPosition(vectorValue), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        private static IntPtr NewPropertyValueCPtrByColor(Color color)
        {
            if (null == color)
            {
                throw new ArgumentNullException(nameof(color));
            }

            return Interop.PropertyValue.NewPropertyValueVector4Componentwise(color.R, color.G, color.B, color.A);
        }
        /// <summary>
        /// Creates a Color property value.
        /// </summary>
        /// <param name="vectorValue">Color values.</param>
        /// <since_tizen> 3 </since_tizen>
        public PropertyValue(Color vectorValue) : this(NewPropertyValueCPtrByColor(vectorValue), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The default constructor of PropertyValue class.
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
        internal PropertyValue(Size vectorValue) : this(vectorValue.Width, vectorValue.Height, vectorValue.Depth)
        {
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
        /// Creates a Vector2 property value componentwise.
        /// </summary>
        /// <param name="xValue">X value of Vector2.</param>
        /// <param name="yValue">Y value of Vector2.</param>
        internal PropertyValue(float xValue, float yValue) : this(Interop.PropertyValue.NewPropertyValueVector2Componentwise(xValue, yValue), true)
        {
            NDalicPINVOKE.ThrowExceptionIfExists();
        }

        /// <summary>
        /// Creates a Vector3 property value componentwise.
        /// </summary>
        /// <param name="xValue">X value of Vector3.</param>
        /// <param name="yValue">Y value of Vector3.</param>
        /// <param name="zValue">Z value of Vector3.</param>
        internal PropertyValue(float xValue, float yValue, float zValue) : this(Interop.PropertyValue.NewPropertyValueVector3Componentwise(xValue, yValue, zValue), true)
        {
            NDalicPINVOKE.ThrowExceptionIfExists();
        }

        /// <summary>
        /// Creates a Vector4 property value componentwise.
        /// </summary>
        /// <param name="xValue">X value of Vector4.</param>
        /// <param name="yValue">Y value of Vector4.</param>
        /// <param name="zValue">Z value of Vector4.</param>
        /// <param name="wValue">W value of Vector4.</param>
        internal PropertyValue(float xValue, float yValue, float zValue, float wValue) : this(Interop.PropertyValue.NewPropertyValueVector4Componentwise(xValue, yValue, zValue, wValue), true)
        {
            NDalicPINVOKE.ThrowExceptionIfExists();
        }

        /// <summary>
        /// Determines whether the ProperyValue has equal value with the current ProperyValue.
        /// </summary>
        /// <remarks>
        /// Equal only if same type.
        /// PropertyArray and PropertyMap don't have EqaulTo method. In that case, always return false.
        /// EqualTo API consider absolute/relative error internally.
        /// </remarks>
        /// <param name="rhs">The ProperyValue to compare with the current ProperyValue.</param>
        /// <returns>true if the specified ProperyValue is equal to the current ProperyValue; otherwise, false.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool EqualTo(PropertyValue rhs)
        {
            bool ret = Interop.PropertyValue.EqualTo(SwigCPtr, PropertyValue.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Determines whether the ProperyValue doesn't have equal value with the current ProperyValue.
        /// </summary>
        /// <remarks>
        /// Same as !EqualTo(rhs);
        /// </remarks>
        /// <param name="rhs">The ProperyValue to compare with the current ProperyValue.</param>
        /// <returns>true if the specified ProperyValue is not equal to the current ProperyValue; otherwise, false.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool NotEqualTo(PropertyValue rhs)
        {
            bool ret = Interop.PropertyValue.NotEqualTo(SwigCPtr, PropertyValue.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Hidden API (Inhouse API).
        /// Dispose.
        /// </summary>
        /// <remarks>
        /// Following the guide of https://docs.microsoft.com/en-us/dotnet/standard/garbage-collection/implementing-dispose.
        /// This will replace "protected virtual void Dispose(DisposeTypes type)" which is exactly same in functionality.
        /// </remarks>
        /// <param name="disposing">true in order to free managed objects</param>
        // Protected implementation of Dispose pattern.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            //perform dipose here without being added to DisposeQueue.
            if (SwigCMemOwn && SwigCPtr.Handle != IntPtr.Zero)
            {
                if (disposing)
                {
                    base.Dispose(DisposeTypes.Explicit);
                }
                else
                {
                    base.Dispose(DisposeTypes.Implicit);
                }
            }

            base.Dispose(disposing);
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
            if (type.IsEnum)
            {
                PropertyValue value = new PropertyValue((int)obj);//Enum.Parse(type, str);
                return value;
            }
            else if (type.Equals(typeof(int)))
            {
                PropertyValue value = new PropertyValue((int)obj);
                return value;
            }
            else if (type.Equals(typeof(System.Int32)))
            {
                PropertyValue value = new PropertyValue((int)obj);
                return value;
            }
            else if (type.Equals(typeof(bool)))
            {
                PropertyValue value = new PropertyValue((bool)obj);
                return value;
            }
            else if (type.Equals(typeof(float)))
            {
                PropertyValue value = new PropertyValue((float)obj);
                return value;
            }
            else if (type.Equals(typeof(string)))
            {
                PropertyValue value = new PropertyValue((string)obj);
                return value;
            }
            else if (type.Equals(typeof(Vector2)))
            {
                PropertyValue value = new PropertyValue((Vector2)obj);
                return value;
            }
            else if (type.Equals(typeof(Vector3)))
            {
                PropertyValue value = new PropertyValue((Vector3)obj);
                return value;
            }
            else if (type.Equals(typeof(Vector4)))
            {
                PropertyValue value = new PropertyValue((Vector4)obj);
                return value;
            }
            else if (type.Equals(typeof(Position)))
            {
                PropertyValue value = new PropertyValue((Position)obj);
                return value;
            }
            else if (type.Equals(typeof(Position2D)))
            {
                PropertyValue value = new PropertyValue((Position2D)obj);
                return value;
            }
            else if (type.Equals(typeof(Size)))
            {
                PropertyValue value = new PropertyValue((Size)obj);
                return value;
            }
            else if (type.Equals(typeof(Size2D)))
            {
                PropertyValue value = new PropertyValue((Size2D)obj);
                return value;
            }
            else if (type.Equals(typeof(Color)))
            {
                PropertyValue value = new PropertyValue((Color)obj);
                return value;
            }
            else if (type.Equals(typeof(Rotation)))
            {
                PropertyValue value = new PropertyValue((Rotation)obj);
                return value;
            }
            else if (type.Equals(typeof(RelativeVector2)))
            {
                PropertyValue value = new PropertyValue((RelativeVector2)obj);
                return value;
            }
            else if (type.Equals(typeof(RelativeVector3)))
            {
                PropertyValue value = new PropertyValue((RelativeVector3)obj);
                return value;
            }
            else if (type.Equals(typeof(RelativeVector4)))
            {
                PropertyValue value = new PropertyValue((RelativeVector4)obj);
                return value;
            }
            else if (type.Equals(typeof(Extents)))
            {
                PropertyValue value = new PropertyValue((Extents)obj);
                return value;
            }
            else if (type.Equals(typeof(Rectangle)))
            {
                PropertyValue value = new PropertyValue((Rectangle)obj);
                return value;
            }
            else if (type.Equals(typeof(PropertyArray)))
            {
                PropertyValue value = new PropertyValue((PropertyArray)obj);
                return value;
            }
            else if (type.Equals(typeof(PropertyMap)))
            {
                PropertyValue value = new PropertyValue((PropertyMap)obj);
                return value;
            }
            else if (type.Equals(typeof(UIColor)))
            {
                UIColor color = ((UIColor)obj);
                PropertyValue value = new PropertyValue(color.R, color.G, color.B, color.A);
                return value;
            }
            else if (type.Equals(typeof(UICorner)))
            {
                UICorner corner = ((UICorner)obj);
                PropertyValue value = new PropertyValue(corner.TopLeft, corner.TopRight, corner.BottomRight, corner.BottomLeft);
                return value;
            }
            else if (type.Equals(typeof(UIExtents)))
            {
                // TODO Do not create Extents instance
                using Extents extents = ((UIExtents)obj).ToReferenceType();
                PropertyValue value = new PropertyValue(extents);
                return value;
            }
            else if (type.Equals(typeof(UIVector2)))
            {
                UIVector2 vector2 = ((UIVector2)obj);
                PropertyValue value = new PropertyValue(vector2.X, vector2.Y);
                return value;
            }
            else if (type.Equals(typeof(UIVector3)))
            {
                UIVector3 vector3 = ((UIVector3)obj);
                PropertyValue value = new PropertyValue(vector3.X, vector3.Y, vector3.Z);
                return value;
            }
            else
            {
                throw new global::System.InvalidOperationException("Unimplemented type for Property Value :" + type.Name);
            }
        }


        /// <summary>
        /// An extension to the property value class that allows us to create a
        /// Property value from a C# object, for example, integer, float, or string.<br />
        /// Warning : This API don't automatically release memory.
        /// </summary>
        /// <param name="obj">An object to create.</param>
        /// <returns>The created value's IntPtr.</returns>
        /// <exception cref="global::System.ArgumentNullException"> Thrown when obj is null. </exception>
        static internal global::System.IntPtr CreateFromObjectIntPtr(System.Object obj)
        {
            if (null == obj)
            {
                throw new global::System.ArgumentNullException(nameof(obj));
            }

            System.Type type = obj.GetType();
            global::System.IntPtr value = global::System.IntPtr.Zero;
            if (type.IsEnum)
            {
                value = Interop.PropertyValue.NewPropertyValue((int)obj);//Enum.Parse(type, str);
            }
            else if (type.Equals(typeof(int)))
            {
                value = Interop.PropertyValue.NewPropertyValue((int)obj);
            }
            else if (type.Equals(typeof(System.Int32)))
            {
                value = Interop.PropertyValue.NewPropertyValue((int)obj);
            }
            else if (type.Equals(typeof(bool)))
            {
                value = Interop.PropertyValue.NewPropertyValue((bool)obj);
            }
            else if (type.Equals(typeof(float)))
            {
                value = Interop.PropertyValue.NewPropertyValue((float)obj);
            }
            else if (type.Equals(typeof(string)))
            {
                value = Interop.PropertyValue.NewPropertyValueString((string)obj);
            }
            else if (type.Equals(typeof(Vector2)))
            {
                value = Interop.PropertyValue.NewPropertyValueVector2(Vector2.getCPtr((Vector2)obj));
            }
            else if (type.Equals(typeof(Vector3)))
            {
                value = Interop.PropertyValue.NewPropertyValueVector3(Vector3.getCPtr((Vector3)obj));
            }
            else if (type.Equals(typeof(Vector4)))
            {
                value = Interop.PropertyValue.NewPropertyValueVector4(Vector4.getCPtr((Vector4)obj));
            }
            else if (type.Equals(typeof(Position)))
            {
                var position = obj as Position;
                value = Interop.PropertyValue.NewPropertyValueVector3Componentwise(position.X, position.Y, position.Z);
            }
            else if (type.Equals(typeof(Position2D)))
            {
                value = Interop.PropertyValue.NewPropertyValueVector2(Position2D.getCPtr((Position2D)obj));
            }
            else if (type.Equals(typeof(Size)))
            {
                var size = obj as Size;
                value = Interop.PropertyValue.NewPropertyValueVector3Componentwise(size.Width, size.Height, size.Depth);
            }
            else if (type.Equals(typeof(Size2D)))
            {
                value = Interop.PropertyValue.NewPropertyValueVector2(Size2D.getCPtr((Size2D)obj));
            }
            else if (type.Equals(typeof(Color)))
            {
                var color = obj as Color;
                value = Interop.PropertyValue.NewPropertyValueVector4Componentwise(color.R, color.G, color.B, color.A);
            }
            else if (type.Equals(typeof(Rotation)))
            {
                value = Interop.PropertyValue.NewPropertyValueQuaternion(Rotation.getCPtr((Rotation)obj));
            }
            else if (type.Equals(typeof(RelativeVector2)))
            {
                value = Interop.PropertyValue.NewPropertyValueVector2(RelativeVector2.getCPtr((RelativeVector2)obj));
            }
            else if (type.Equals(typeof(RelativeVector3)))
            {
                value = Interop.PropertyValue.NewPropertyValueVector3(RelativeVector3.getCPtr((RelativeVector3)obj));
            }
            else if (type.Equals(typeof(RelativeVector4)))
            {
                value = Interop.PropertyValue.NewPropertyValueVector4(RelativeVector4.getCPtr((RelativeVector4)obj));
            }
            else if (type.Equals(typeof(Extents)))
            {
                value = Interop.PropertyValue.NewPropertyValueExtents(Extents.getCPtr((Extents)obj));
            }
            else if (type.Equals(typeof(Rectangle)))
            {
                value = Interop.PropertyValue.NewPropertyValueRect(Rectangle.getCPtr((Rectangle)obj));
            }
            else if (type.Equals(typeof(PropertyArray)))
            {
                value = Interop.PropertyValue.NewPropertyValueArray(PropertyArray.getCPtr((PropertyArray)(obj)));
            }
            else if (type.Equals(typeof(PropertyMap)))
            {
                value = Interop.PropertyValue.NewPropertyValueMap(PropertyMap.getCPtr((PropertyMap)(obj)));
            }
            else if (type.Equals(typeof(UIColor)))
            {
                UIColor color = ((UIColor)obj);
                value = Interop.PropertyValue.NewPropertyValueVector4Componentwise(color.R, color.G, color.B, color.A);
            }
            else if (type.Equals(typeof(UICorner)))
            {
                UICorner corner = ((UICorner)obj);
                value = Interop.PropertyValue.NewPropertyValueVector4Componentwise(corner.TopLeft, corner.TopRight, corner.BottomRight, corner.BottomLeft);
            }
            else if (type.Equals(typeof(UIExtents)))
            {
                // TODO Do not create Extents instance
                using Extents extents = ((UIExtents)obj).ToReferenceType();
                value = Interop.PropertyValue.NewPropertyValueExtents(Extents.getCPtr(extents));
            }
            else if (type.Equals(typeof(UIVector2)))
            {
                UIVector2 vector2 = ((UIVector2)obj);
                value = Interop.PropertyValue.NewPropertyValueVector2Componentwise(vector2.X, vector2.Y);
            }
            else if (type.Equals(typeof(UIVector3)))
            {
                UIVector3 vector3 = ((UIVector3)obj);
                value = Interop.PropertyValue.NewPropertyValueVector3Componentwise(vector3.X, vector3.Y, vector3.Z);
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
            if (null == vectorValue)
            {
                throw new ArgumentNullException(nameof(vectorValue));
            }

            var ret = GetVector3Component(out var w, out var h, out var d);
            vectorValue.ResetValue(w, h, d);

            return ret;
        }

        /// <summary>
        /// Retrieves a Position value.
        /// </summary>
        /// <param name="vectorValue"> On return, a position value.</param>
        /// <since_tizen> 3 </since_tizen>
        public bool Get(Position vectorValue)
        {
            if (null == vectorValue)
            {
                throw new ArgumentNullException(nameof(vectorValue));
            }

            bool ret = Interop.PropertyValue.PropertyValueGetVector3Componentwise(SwigCPtr, out var x, out var y, out var z);
            vectorValue.ResetValue(x, y, z);

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
            if (null == vectorValue)
            {
                throw new ArgumentNullException(nameof(vectorValue));
            }

            bool ret = Interop.PropertyValue.PropertyValueGetVector4Componentwise(SwigCPtr, out var r, out var g, out var b, out var a);
            vectorValue.ResetValue(r, g, b, a);

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
        /// Retrieves a map property value.
        /// </summary>
        /// <param name="mapValue">On return, the map as vector of string and property value pairs.</param>
        /// <returns>Returns true if the value is successfully retrieved, false if the type is not convertible.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Get(ref PropertyMap mapValue)
        {
            if (mapValue == null)
            {
                return false;
            }
            bool ret = Interop.PropertyValue.GetMap(SwigCPtr, mapValue.SwigCPtr);
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

        /// <summary>
        /// Get each components of Vector2. It will be failed if the type is not Vector2.
        /// </summary>
        /// <param name="xValue">X value of Vector2 component</param>
        /// <param name="yValue">Y value of Vector2 component</param>
        /// <returns>Returns true if the value is successfully retrieved, false if the type is not convertible.</returns>
        internal bool GetVector2Component(out float xValue, out float yValue)
        {
            bool ret = Interop.PropertyValue.PropertyValueGetVector2Componentwise(SwigCPtr, out xValue, out yValue);
            NDalicPINVOKE.ThrowExceptionIfExists();
            return ret;
        }

        /// <summary>
        /// Get each components of Vector3. It will be failed if the type is not Vector3.
        /// </summary>
        /// <param name="xValue">X value of Vector3 component</param>
        /// <param name="yValue">Y value of Vector3 component</param>
        /// <param name="zValue">Z value of Vector3 component</param>
        /// <returns>Returns true if the value is successfully retrieved, false if the type is not convertible.</returns>
        internal bool GetVector3Component(out float xValue, out float yValue, out float zValue)
        {
            bool ret = Interop.PropertyValue.PropertyValueGetVector3Componentwise(SwigCPtr, out xValue, out yValue, out zValue);
            NDalicPINVOKE.ThrowExceptionIfExists();
            return ret;
        }

        /// <summary>
        /// Get each components of Vector4. It will be failed if the type is not Vector4.
        /// </summary>
        /// <param name="xValue">X value of Vector4 component</param>
        /// <param name="yValue">Y value of Vector4 component</param>
        /// <param name="zValue">Z value of Vector4 component</param>
        /// <param name="wValue">W value of Vector4 component</param>
        /// <returns>Returns true if the value is successfully retrieved, false if the type is not convertible.</returns>
        internal bool GetVector4Component(out float xValue, out float yValue, out float zValue, out float wValue)
        {
            bool ret = Interop.PropertyValue.PropertyValueGetVector4Componentwise(SwigCPtr, out xValue, out yValue, out zValue, out wValue);
            NDalicPINVOKE.ThrowExceptionIfExists();
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
