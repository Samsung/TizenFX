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

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    using OOConverter = Converter<object, object>;
    using PPConverter = Converter<PropertyValue, PropertyValue>;

    internal static class PropertyHelper
    {
        private static readonly Dictionary<string, VisualPropertyData> visualPropertyTable = new Dictionary<string, VisualPropertyData>()
        {
            { "backgroundColor",        new VisualPropertyData(View.Property.BACKGROUND, ColorVisualProperty.MixColor, ObjectColorToVector3, PropertyValueColorToVector3,
                                        new VisualPropertyData(View.Property.BACKGROUND, Visual.Property.Opacity, ObjectColorToAlpha, PropertyValueColorToAlpha)) },
            { "backgroundOpacity",      new VisualPropertyData(View.Property.BACKGROUND, Visual.Property.Opacity, ObjectIntToFloat) },
            { "boxShadow.BlurRadius",   new VisualPropertyData(View.Property.SHADOW, ColorVisualProperty.BlurRadius) },
            { "boxShadow.Color",        new VisualPropertyData(View.Property.SHADOW, ColorVisualProperty.MixColor, ObjectColorToVector3, PropertyValueColorToVector3,
                                        new VisualPropertyData(View.Property.SHADOW, Visual.Property.Opacity, ObjectColorToAlpha, PropertyValueColorToAlpha)) },
            { "boxShadow.CornerRadius", new VisualPropertyData(View.Property.SHADOW, Visual.Property.CornerRadius, ObjectIntToFloat) },
            { "boxShadow.Offset",       new VisualPropertyData(View.Property.SHADOW, (int)VisualTransformPropertyType.Offset) },
            { "boxShadow.Opacity",      new VisualPropertyData(View.Property.SHADOW, Visual.Property.Opacity, ObjectIntToFloat) },
            { "cornerRadius",           new VisualPropertyData(ImageView.Property.IMAGE, Visual.Property.CornerRadius, null, null,
                                        new VisualPropertyData(View.Property.SHADOW, Visual.Property.CornerRadius, null, null,
                                        new VisualPropertyData(View.Property.BACKGROUND, Visual.Property.CornerRadius, null, null))) },
            { "imageShadow.Offset",     new VisualPropertyData(View.Property.SHADOW, (int)VisualTransformPropertyType.Offset) },
            { "shadow.CornerRadius",    new VisualPropertyData(View.Property.SHADOW, Visual.Property.CornerRadius, ObjectIntToFloat) },
        };

        static PropertyHelper() { }

        ///<summary>
        /// Returns a Property if stringProperty is a valid index
        ///</summary>
        internal static Property GetPropertyFromString(Animatable handle, string stringProperty)
        {
            Property property = new Property(handle, LowerFirstLetter(stringProperty));
            if (property.propertyIndex == Property.InvalidIndex)
            {
                throw new System.ArgumentException("string property is invalid");
            }

            return property;
        }

        ///<summary>
        /// Returns a Property if stringProperty is a valid index
        ///</summary>
        internal static SearchResult Search(View view, string stringProperty)
        {
            var propertyName = LowerFirstLetter(stringProperty);

            return SearchProperty(view, propertyName) ?? SearchVisualProperty(view, propertyName);
        }

        private static SearchResult SearchProperty(View view, string lowercasePropertyString)
        {
            Property property = new Property(view, lowercasePropertyString);

            if (property.propertyIndex == Property.InvalidIndex)
            {
                property.Dispose();
                return null;
            }

            OOConverter converter = null;
            if (view.GetPropertyType(property.propertyIndex).Equals(PropertyType.Float))
            {
                converter = ObjectIntToFloat;
            }

            return new SearchResult(property, converter);
        }

        private static SearchResult SearchVisualProperty(View view, string lowercasePropertyString)
        {
            if (visualPropertyTable.TryGetValue(lowercasePropertyString, out var found))
            {
                return GenerateVisualPropertySearchResult(view, found);
            }

            return null;
        }

        private static SearchResult GenerateVisualPropertySearchResult(View view, VisualPropertyData data)
        {
            var propertyIntPtr = Interop.View.GetVisualProperty(view.SwigCPtr, data.ViewPropertyIndex, data.VisualPropertyIndex);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            var property = new Property(propertyIntPtr, true);
            if (property.propertyIndex == Property.InvalidIndex)
            {
                property.Dispose();
                return data.RelatedData == null ? null : GenerateVisualPropertySearchResult(view, data.RelatedData);
            }

            SearchResult result = new SearchResult(property, data.ObjectConverter, data.PropertyValueConverter);

            if (data.RelatedData != null)
            {
                result.NextResult = GenerateVisualPropertySearchResult(view, data.RelatedData);
            }

            return result;
        }

        private static string LowerFirstLetter(string original)
        {
            StringBuilder sb = new StringBuilder(original);
            sb[0] = (char)(sb[0] | 0x20);
            return sb.ToString();
        }

        private static object ObjectColorToVector3(object value)
        {
            if (value is Vector4)
            {
                var colorValue = value as Vector4;
                return new Vector3(colorValue.R, colorValue.G, colorValue.B);
            }

            if (value is Color)
            {
                var colorValue = value as Color;
                return new Vector3(colorValue.R, colorValue.G, colorValue.B);
            }

            return null;
        }

        private static PropertyValue PropertyValueColorToVector3(PropertyValue value)
        {
            var valueType = value.GetType();

            if (valueType != PropertyType.Vector4)
            {
                return null;
            }

            var colorValue = new Vector4();
            value.Get(colorValue);
            using (var v3 = new Vector3(colorValue.R, colorValue.G, colorValue.B))
            {
                colorValue.Dispose();
                return new PropertyValue(v3);
            }
        }

        private static object ObjectColorToAlpha(object value)
        {
            if (value is Vector4)
            {
                var colorValue = value as Vector4;
                return colorValue.A;
            }

            if (value is Color)
            {
                var colorValue = value as Color;
                return colorValue.A;
            }

            return null;
        }

        private static PropertyValue PropertyValueColorToAlpha(PropertyValue value)
        {
            var valueType = value.GetType();

            if (valueType != PropertyType.Vector4)
            {
                return null;
            }

            using (var colorValue = new Vector4())
            {
                value.Get(colorValue);
                return new PropertyValue(colorValue.A);
            }
        }

        private static object ObjectIntToFloat(object value)
        {
            Type type = value.GetType();
            if (type.Equals(typeof(System.Int32)) || type.Equals(typeof(int)))
            {
                return (float)((int)value);
            }

            return value;
        }

        private static object ObjectVector4ToFloat(object value)
        {
            if (value is Vector4 vector)
            {
                return vector.X;
            }

            return value;
        }

        internal class SearchResult : Disposable
        {
            private readonly OOConverter objectConverter;
            private readonly PPConverter propertyValueConverter;

            internal SearchResult(Property property, OOConverter objectConverter = null, PPConverter propertyValueConverter = null)
            {
                this.objectConverter = objectConverter;
                this.propertyValueConverter = propertyValueConverter;
                Property = property;
            }

            internal Property Property { get; }

            internal SearchResult NextResult { get; set; }

            internal PropertyValue RefineValue(object value)
            {
                Debug.Assert(Property != null && value != null);

                var refined = value;

                if (objectConverter != null)
                {
                    refined = objectConverter(value);
                }

                if (refined == null)
                {
                    return null;
                }

                return PropertyValue.CreateFromObject(refined);
            }

            internal KeyFrames RefineKeyFrames(KeyFrames keyFrames)
            {
                Debug.Assert(keyFrames != null);

                var refined = keyFrames;
                if (propertyValueConverter != null)
                {
                    // TODO Enable this code when csharp-binder is ready
                    // refined = new KeyFrames();
                    // for (uint i = 0; i < keyFrames.Count; i++)
                    // {
                    //     var keyFrame = keyFrames.GetKeyFrame(i);
                    //     var newKeyFrame = propertyValueConverter(keyFrame);
                    //     if (newKeyFrame == null)
                    //     {
                    //         return null;
                    //     }
                    //     refined.Add(newKeyFrame);
                    // }
                }

                return refined;
            }

            /// <summary>
            /// Dispose
            /// </summary>
            protected override void Dispose(DisposeTypes type)
            {
                if (disposed)
                {
                    return;
                }

                if (type == DisposeTypes.Explicit)
                {
                    Property.Dispose();
                    NextResult?.Dispose();
                }

                base.Dispose(type);
            }
        }

        private class VisualPropertyData
        {
            internal VisualPropertyData(int viewPropertyIndex, int visualPropertyIndex, OOConverter objectConverter = null, PPConverter propertyValueConverter = null, VisualPropertyData relatedData = null)
            {
                ViewPropertyIndex = viewPropertyIndex;
                VisualPropertyIndex = visualPropertyIndex;
                ObjectConverter = objectConverter;
                PropertyValueConverter = propertyValueConverter;
                RelatedData = relatedData;
            }

            internal int ViewPropertyIndex { get; }

            internal int VisualPropertyIndex { get; }

            internal OOConverter ObjectConverter { get; }

            internal PPConverter PropertyValueConverter { get; }

            internal VisualPropertyData RelatedData { get; }
        }
    }
}
