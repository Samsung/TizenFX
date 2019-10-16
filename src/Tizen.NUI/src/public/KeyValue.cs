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
using Tizen.NUI.Binding;

namespace Tizen.NUI
{
    /// <summary>
    /// KeyValue class.
    /// </summary>
    public class KeyValue
    {
        /// <summary>
        /// Int key.
        /// </summary>
        public int? KeyInt = null;

        /// <summary>
        /// String key.
        /// </summary>
        public string KeyString = null;

        /// <summary>
        /// True value.
        /// </summary>
        public PropertyValue TrueValue = null;

        private string _key = null;
        private object _originalValue = null;
        private object _originalKey = null;

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public KeyValue()
        { }

        /// <summary>
        /// Key property.
        /// </summary>
        public string Key
        {
            get
            {
                return _key;
            }
            set
            {
                _key = value;
                ParseKey(value);
            }
        }

        /// <summary>
        /// OriginalKey property.
        /// </summary>
        public object OriginalKey
        {
            get
            {
                return _originalKey;
            }
            set
            {
                _originalKey = value;
                if (value is int || value is Int32)
                {
                    KeyInt = (int)value;
                }
                else if (value is string)
                {
                    KeyString = value.ToString();
                }
                else if (value.GetType().Equals(typeof(int)) || value.GetType().Equals(typeof(Int32)))
                {
                    KeyInt = (int)value;
                }
                else if (value.GetType().Equals(typeof(string)))
                {
                    KeyString = value.ToString();
                }
            }
        }

        /// <summary>
        /// Value property.
        /// </summary>
        public object Value
        {
            get
            {
                return _originalValue;
            }
            set
            {
                _originalValue = value;
                TrueValue = PropertyValue.CreateFromObject(value);
            }
        }

        /// <summary>
        /// IntergerValue property.
        /// </summary>
        public int IntergerValue
        {
            set
            {
                TrueValue = new PropertyValue(value);
            }
        }

        /// <summary>
        /// BooleanValue property.
        /// </summary>
        public bool BooleanValue
        {
            set
            {
                TrueValue = new PropertyValue(value);
            }
        }

        /// <summary>
        /// SingleValue property.
        /// </summary>
        public float SingleValue
        {
            set
            {
                TrueValue = new PropertyValue(value);
            }
        }

        /// <summary>
        /// StringValue property.
        /// </summary>
        public string StringValue
        {
            set
            {
                TrueValue = new PropertyValue(value);
            }
        }

        /// <summary>
        /// Vector2Value property.
        /// </summary>
        public Vector2 Vector2Value
        {
            set
            {
                TrueValue = new PropertyValue(value);
            }
        }

        /// <summary>
        /// Vector3Value property.
        /// </summary>
        public Vector3 Vector3Value
        {
            set
            {
                TrueValue = new PropertyValue(value);
            }
        }

        /// <summary>
        /// Vector4Value property.
        /// </summary>
        public Vector4 Vector4Value
        {
            set
            {
                TrueValue = new PropertyValue(value);
            }
        }

        /// <summary>
        /// PositionValue property.
        /// </summary>
        public Position PositionValue
        {
            set
            {
                TrueValue = new PropertyValue(value);
            }
        }

        /// <summary>
        /// Position2DValue property.
        /// </summary>
        public Position2D Position2DValue
        {
            set
            {
                TrueValue = new PropertyValue(value);
            }
        }

        /// <summary>
        /// SizeValue property.
        /// </summary>
        public Size SizeValue
        {
            set
            {
                TrueValue = new PropertyValue(value);
            }
        }

        /// <summary>
        /// Size2DValue property.
        /// </summary>
        public Size2D Size2DValue
        {
            set
            {
                TrueValue = new PropertyValue(value);
            }
        }

        /// <summary>
        /// ColorValue property.
        /// </summary>
        public Color ColorValue
        {
            set
            {
                TrueValue = new PropertyValue(value);
            }
        }

        /// <summary>
        /// RectangleValue property.
        /// </summary>
        public Rectangle RectangleValue
        {
            set
            {
                TrueValue = new PropertyValue(value);
            }
        }

        /// <summary>
        /// RotationValue property.
        /// </summary>
        public Rotation RotationValue
        {
            set
            {
                TrueValue = new PropertyValue(value);
            }
        }

        /// <summary>
        /// RelativeVector2Value property.
        /// </summary>
        public RelativeVector2 RelativeVector2Value
        {
            set
            {
                TrueValue = new PropertyValue(value);
            }
        }

        /// <summary>
        /// RelativeVector3Value property.
        /// </summary>
        public RelativeVector3 RelativeVector3Value
        {
            set
            {
                TrueValue = new PropertyValue(value);
            }
        }

        /// <summary>
        /// RelativeVector4Value property.
        /// </summary>
        public RelativeVector4 RelativeVector4Value
        {
            set
            {
                TrueValue = new PropertyValue(value);
            }
        }

        /// <summary>
        /// ExtentsValue property.
        /// </summary>
        public Extents ExtentsValue
        {
            set
            {
                TrueValue = new PropertyValue(value);
            }
        }

        /// <summary>
        /// PropertyArrayValue property.
        /// </summary>
        public PropertyArray PropertyArrayValue
        {
            set
            {
                TrueValue = new PropertyValue(value);
            }
        }

        /// <summary>
        /// PropertyMapValue property.
        /// </summary>
        public PropertyMap PropertyMapValue
        {
            set
            {
                TrueValue = new PropertyValue(value);
            }
        }

        private void ParseKey(string key)
        {
            int v = -1;
            if (VisualExtension.KeyDictionary.ContainsKey(key))
            {
                VisualExtension.KeyDictionary.TryGetValue(key, out v);
                KeyInt = v;
            }
            else
            {
                KeyString = Key;
            }
        }
    }
}
