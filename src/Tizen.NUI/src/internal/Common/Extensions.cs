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
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using Tizen.NUI.Binding;

namespace Tizen.NUI
{
    internal static class Extensions
    {
        public static T GetInstanceSafely<T>(this object wrapper, IntPtr cPtr) where T : BaseHandle
        {
            HandleRef CPtr = new HandleRef(wrapper, cPtr);
            T ret = Registry.GetManagedBaseHandleFromNativePtr(CPtr.Handle) as T;
            Interop.BaseHandle.DeleteBaseHandle(CPtr);
            CPtr = new HandleRef(null, IntPtr.Zero);
            return ret;
        }

        public static string GetValueString(this PropertyInfo property, object obj, Type propertyType)
        {
            string ret = "";
            object value = property.GetValue(obj);
            if (null == value) return ret;

            TypeConverter typeConverter;
            if (WellKnownConvertTypes.TryGetValue(propertyType, out typeConverter))
            {
                ret = typeConverter.ConvertToString(value);
            }
            else
            {
                ret = value.ToString();
            }
            return ret;
        }

        static readonly Dictionary<Type, TypeConverter> WellKnownConvertTypes = new Dictionary<Type, TypeConverter>
        {
            //{ typeof(Uri), new UriTypeConverter() },
            { typeof(Color), new ColorTypeConverter() },
            { typeof(Size2D), new Size2DTypeConverter() },
            { typeof(Position2D), new Position2DTypeConverter() },
            { typeof(Size), new SizeTypeConverter() },
            { typeof(Position), new PositionTypeConverter() },
            { typeof(Rectangle), new RectangleTypeConverter() },
            { typeof(Rotation), new RotationTypeConverter() },
            { typeof(Vector2), new Vector2TypeConverter() },
            { typeof(Vector3), new Vector3TypeConverter() },
            { typeof(Vector4), new Vector4TypeConverter() },
            { typeof(RelativeVector2), new RelativeVector2TypeConverter() },
            { typeof(RelativeVector3), new RelativeVector3TypeConverter() },
            { typeof(RelativeVector4), new RelativeVector4TypeConverter() },
        };
    }
}
