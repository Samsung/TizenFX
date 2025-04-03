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
using System.Runtime.CompilerServices;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    using OOConverter = Converter<object, object>;
    using PPConverter = Converter<PropertyValue, PropertyValue>;

    internal static class PropertyHelper
    {
        private static readonly Dictionary<string, VisualPropertyData> visualPropertyTable = new Dictionary<string, VisualPropertyData>()
        {
            { "backgroundColor",            new VisualPropertyData(View.Property.BACKGROUND, ColorVisualProperty.MixColor, ObjectColorToVector4, PropertyValueColorToVector4) },
            { "backgroundOpacity",          new VisualPropertyData(View.Property.BACKGROUND, Visual.Property.Opacity, ObjectIntToFloat) },
            { "boxShadow.BlurRadius",       new VisualPropertyData(View.Property.SHADOW, ColorVisualProperty.BlurRadius) },
            { "boxShadow.Color",            new VisualPropertyData(View.Property.SHADOW, ColorVisualProperty.MixColor, ObjectColorToVector4, PropertyValueColorToVector4) },
            { "boxShadow.CornerRadius",     new VisualPropertyData(View.Property.SHADOW, Visual.Property.CornerRadius, ObjectIntToFloat) },
            { "boxShadow.CornerSquareness", new VisualPropertyData(View.Property.SHADOW, Visual.Property.CornerSquareness, ObjectIntToFloat) },
            { "boxShadow.Offset",           new VisualPropertyData(View.Property.SHADOW, (int)VisualTransformPropertyType.Offset) },
            { "boxShadow.Opacity",          new VisualPropertyData(View.Property.SHADOW, Visual.Property.Opacity, ObjectIntToFloat) },
            { "cornerRadius",               new VisualPropertyData(ImageView.Property.IMAGE, Visual.Property.CornerRadius, null, null,
                                            new VisualPropertyData(View.Property.SHADOW, Visual.Property.CornerRadius, null, null,
                                            new VisualPropertyData(View.Property.BACKGROUND, Visual.Property.CornerRadius, null, null))) },
            { "cornerSquareness",           new VisualPropertyData(ImageView.Property.IMAGE, Visual.Property.CornerSquareness, null, null,
                                            new VisualPropertyData(View.Property.SHADOW, Visual.Property.CornerSquareness, null, null,
                                            new VisualPropertyData(View.Property.BACKGROUND, Visual.Property.CornerSquareness, null, null))) },
            { "borderlineWidth",            new VisualPropertyData(ImageView.Property.IMAGE, Visual.Property.BorderlineWidth, ObjectIntToFloat, null,
                                            new VisualPropertyData(View.Property.BACKGROUND, Visual.Property.BorderlineWidth, ObjectIntToFloat, null)) },
            { "borderlineColor",            new VisualPropertyData(ImageView.Property.IMAGE, Visual.Property.BorderlineColor, null, null,
                                            new VisualPropertyData(View.Property.BACKGROUND, Visual.Property.BorderlineColor, null, null)) },
            { "borderlineOffset",           new VisualPropertyData(ImageView.Property.IMAGE, Visual.Property.BorderlineOffset, null, null,
                                            new VisualPropertyData(View.Property.BACKGROUND, Visual.Property.BorderlineOffset, null, null)) },
            { "imageShadow.Offset",         new VisualPropertyData(View.Property.SHADOW, (int)VisualTransformPropertyType.Offset) },
            { "shadow.CornerRadius",        new VisualPropertyData(View.Property.SHADOW, Visual.Property.CornerRadius, ObjectIntToFloat) },
            { "shadow.CornerSquareness",    new VisualPropertyData(View.Property.SHADOW, Visual.Property.CornerSquareness, ObjectIntToFloat) },
        };

        static PropertyHelper() { }

        ///<summary>
        /// Returns a Property if stringProperty is a valid index
        ///</summary>
        internal static Property GetPropertyFromString(Animatable handle, string stringProperty)
        {
            Property property = new Property(handle, LowerFirstLetter(stringProperty));
            if (property.PropertyIndex == Property.InvalidIndex)
            {
                throw new System.ArgumentException("string property is invalid");
            }

            return property;
        }

        ///<summary>
        /// Returns a Property if stringProperty is a valid index
        ///</summary>
        internal static SearchResult Search(Animatable animatable, string stringProperty)
        {
            var propertyName = LowerFirstLetter(stringProperty);

            if (animatable is View)
            {
                View view = animatable as View;
                return SearchProperty(view, propertyName) ?? SearchVisualProperty(view, propertyName);
            }
            return SearchProperty(animatable, propertyName);
        }

        private static SearchResult SearchProperty(Animatable animatable, string lowercasePropertyString)
        {
            Property property = new Property(animatable, lowercasePropertyString);

            if (property.PropertyIndex == Property.InvalidIndex)
            {
                property.Dispose();
                return null;
            }

            OOConverter converter = null;
            if (animatable.GetPropertyType(property.PropertyIndex).Equals(PropertyType.Float))
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
            if (property.PropertyIndex == Property.InvalidIndex)
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

        private static unsafe string LowerFirstLetter(string original)
        {
            if (string.IsNullOrEmpty(original) || char.IsLower(original[0]))
                return original;

            fixed (char* chars = original)
            {
                chars[0] = char.ToLower(chars[0]);
            }

            return original;
        }

        private static object ObjectColorToVector4(object value)
        {
            if (value is Vector4)
            {
                var colorValue = value as Vector4;
                return new Vector4(colorValue.R, colorValue.G, colorValue.B, colorValue.A);
            }

            if (value is Color)
            {
                var colorValue = value as Color;
                return new Vector4(colorValue.R, colorValue.G, colorValue.B, colorValue.A);
            }

            return value is UIColor ? value : null;
        }

        private static PropertyValue PropertyValueColorToVector4(PropertyValue value)
        {
            var valueType = value.GetType();

            if (valueType != PropertyType.Vector4)
            {
                return null;
            }

            var colorValue = new Vector4();
            value.Get(colorValue);
            using (var v4 = new Vector4(colorValue.R, colorValue.G, colorValue.B, colorValue.A))
            {
                colorValue.Dispose();
                return new PropertyValue(v4);
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


            // Refine object as IntPtr of PropertyValue to optimize.
            // Warning : This API don't automatically release memory.
            internal global::System.IntPtr RefineValueIntPtr(object value)
            {
                Debug.Assert(Property != null && value != null);

                var refined = value;

                if (objectConverter != null)
                {
                    refined = objectConverter(value);
                }

                if (refined == null)
                {
                    return global::System.IntPtr.Zero;
                }

                return PropertyValue.CreateFromObjectIntPtr(refined);
            }

            internal KeyFrames RefineKeyFrames(KeyFrames keyFrames)
            {
                Debug.Assert(keyFrames != null);

                var refined = keyFrames;
                if (propertyValueConverter != null)
                {
                    uint keyFramesCount = keyFrames.GetKeyFrameCount();
                    float keyFrameProgress;
                    using PropertyValue keyFrameValue = new PropertyValue();

                    refined = new KeyFrames();

                    for (uint i = 0; i < keyFramesCount; i++)
                    {
                        keyFrames.GetKeyFrame(i, out keyFrameProgress, keyFrameValue);
                        using var newKeyFrameValue = propertyValueConverter(keyFrameValue);
                        if (newKeyFrameValue == null)
                        {
                            return null;
                        }
                        refined.Add(keyFrameProgress, newKeyFrameValue);
                    }
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
