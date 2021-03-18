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
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using Tizen.NUI.Binding;

namespace Tizen.NUI
{
    /// <summary>
    /// KeyValue class.
    /// </summary>
    public class KeyValue : IDisposable
    {
        private bool disposed = false;
        /// <summary>
        /// Int key.
        /// </summary>
        /// When deleting the field, change it to property.
        [Obsolete("Deprecated in API9, Will be removed in API11. Please use IntegerKey instead.")]
        [SuppressMessage("Microsoft.Design", "CA1051:Do not declare visible instance fields")]
        public int? KeyInt = null;

        /// <summary>
        /// String key.
        /// </summary>
        /// When deleting the field, change it to property.
        [Obsolete("Deprecated in API9, Will be removed in API11. Please use StringKey instead.")]
        [SuppressMessage("Microsoft.Design", "CA1051:Do not declare visible instance fields")]
        public string KeyString = null;

        /// <summary>
        /// True value.
        /// </summary>
        /// When deleting the field, change it to property.
        [Obsolete("Deprecated in API9, Will be removed in API11. Please use PropertyValue instead.")]
        [SuppressMessage("Microsoft.Design", "CA1051:Do not declare visible instance fields")]
        public PropertyValue TrueValue = null;

        private string key = null;
        private object originalValue = null;
        private object originalKey = null;

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
                return key;
            }
            set
            {
                key = value;
                ParseKey(value);
            }
        }

        /// <summary>
        /// OriginalKey property.
        /// </summary>
        /// <exception cref="ArgumentNullException"> Thrown when value is null. </exception>
        public object OriginalKey
        {
            get
            {
                return originalKey;
            }
            set
            {
                if (null == value)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                originalKey = value;
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
                return originalValue;
            }
            set
            {
                originalValue = value;
                TrueValue = PropertyValue.CreateFromObject(value);
            }
        }

        /// <summary>
        /// Int key.
        /// </summary>
        /// When deleting the field, change it to property.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? IntegerKey
        {
            get
            {
                return KeyInt;
            }
            set
            {
                KeyInt = value;
            }
        }

        /// <summary>
        /// String key.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string StringKey
        {
            get
            {
                return KeyString;
            }
            set
            {
                KeyString = value;
            }
        }

        /// <summary>
        /// Property value.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyValue PropertyValue
        {
            get
            {
                return TrueValue;
            }
            set
            {
                TrueValue = value;
            }
        }

        /// <summary>
        /// IntergerValue property.
        /// </summary>
        public int IntergerValue
        {
            get
            {
                if (TrueValue.Get(out int retrivedValue))
                {
                    return retrivedValue;
                }
                NUILog.Error($"[ERROR] Fail to get IntergerValue from PropertyValue! Return ErrorValue(-1)!");
                return -1;
            }
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
            get
            {
                if (TrueValue.Get(out bool retrivedValue))
                {
                    return retrivedValue;
                }
                NUILog.Error($"[ERROR] Fail to get BooleanValue from PropertyValue! Return false!");
                return false;
            }
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
            get
            {
                if (TrueValue.Get(out float retrivedValue))
                {
                    return retrivedValue;
                }
                NUILog.Error($"[ERROR] Fail to get SingleValue from PropertyValue! Return ErrorValue(-1)!");
                return -1;
            }
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
            get
            {
                if (TrueValue.Get(out string retrivedValue))
                {
                    return retrivedValue;
                }
                NUILog.Error($"[ERROR] Fail to get SingleValue from PropertyValue! Return ErrorString(error to get StringValue)!");
                return "error to get StringValue";
            }
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
            get
            {
                Vector2 retrivedValue = new Vector2(0, 0);
                if (TrueValue.Get(retrivedValue))
                {
                    return retrivedValue;
                }
                NUILog.Error($"[ERROR] Fail to get Vector2Value from PropertyValue!");
                return retrivedValue;
            }
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
            get
            {
                Vector3 retrivedValue = new Vector3(0, 0, 0);
                if (TrueValue.Get(retrivedValue))
                {
                    return retrivedValue;
                }
                NUILog.Error($"[ERROR] Fail to get Vector3Value from PropertyValue!");
                return retrivedValue;
            }
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
            get
            {
                Vector4 retrivedValue = new Vector4(0, 0, 0, 0);
                if (TrueValue.Get(retrivedValue))
                {
                    return retrivedValue;
                }
                NUILog.Error($"[ERROR] Fail to get Vector4Value from PropertyValue!");
                return retrivedValue;
            }
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
            get
            {
                Position retrivedValue = new Position(0, 0, 0);
                if (TrueValue.Get(retrivedValue))
                {
                    return retrivedValue;
                }
                NUILog.Error($"[ERROR] Fail to get PositionValue from PropertyValue!");
                return retrivedValue;
            }
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
            get
            {
                Position2D retrivedValue = new Position2D(0, 0);
                if (TrueValue.Get(retrivedValue))
                {
                    return retrivedValue;
                }
                NUILog.Error($"[ERROR] Fail to get Position2DValue from PropertyValue!");
                return retrivedValue;
            }
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
            get
            {
                Size retrivedValue = new Size(0, 0, 0);
                if (TrueValue.Get(retrivedValue))
                {
                    return retrivedValue;
                }
                NUILog.Error($"[ERROR] Fail to get SizeValue from PropertyValue!");
                return retrivedValue;
            }
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
            get
            {
                Size2D retrivedValue = new Size2D(0, 0);
                if (TrueValue.Get(retrivedValue))
                {
                    return retrivedValue;
                }
                NUILog.Error($"[ERROR] Fail to get Size2DValue from PropertyValue!");
                return retrivedValue;
            }
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
            get
            {
                Color retrivedValue = new Color(0, 0, 0, 0);
                if (TrueValue.Get(retrivedValue))
                {
                    return retrivedValue;
                }
                NUILog.Error($"[ERROR] Fail to get ColorValue from PropertyValue!");
                return retrivedValue;
            }
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
            get
            {
                Rectangle retrivedValue = new Rectangle(0, 0, 0, 0);
                if (TrueValue.Get(retrivedValue))
                {
                    return retrivedValue;
                }
                NUILog.Error($"[ERROR] Fail to get RectangleValue from PropertyValue!");
                return retrivedValue;
            }
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
            get
            {
                Rotation retrivedValue = new Rotation();
                if (TrueValue.Get(retrivedValue))
                {
                    return retrivedValue;
                }
                NUILog.Error($"[ERROR] Fail to get RotationValue from PropertyValue!");
                return retrivedValue;
            }
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
            get
            {
                RelativeVector2 retrivedValue = new RelativeVector2(0, 0);
                if (TrueValue.Get(retrivedValue))
                {
                    return retrivedValue;
                }
                NUILog.Error($"[ERROR] Fail to get RelativeVector2Value from PropertyValue!");
                return retrivedValue;
            }
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
            get
            {
                RelativeVector3 retrivedValue = new RelativeVector3(0, 0, 0);
                if (TrueValue.Get(retrivedValue))
                {
                    return retrivedValue;
                }
                NUILog.Error($"[ERROR] Fail to get RelativeVector3Value from PropertyValue!");
                return retrivedValue;
            }
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
            get
            {
                RelativeVector4 retrivedValue = new RelativeVector4(0, 0, 0, 0);
                if (TrueValue.Get(retrivedValue))
                {
                    return retrivedValue;
                }
                NUILog.Error($"[ERROR] Fail to get RelativeVector4Value from PropertyValue!");
                return retrivedValue;
            }
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
            get
            {
                Extents retrivedValue = new Extents(0, 0, 0, 0);
                if (TrueValue.Get(retrivedValue))
                {
                    return retrivedValue;
                }
                NUILog.Error($"[ERROR] Fail to get ExtentsValue from PropertyValue!");
                return retrivedValue;
            }
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
            get
            {
                PropertyArray retrivedValue = new PropertyArray();
                if (TrueValue.Get(retrivedValue))
                {
                    return retrivedValue;
                }
                NUILog.Error($"[ERROR] Fail to get PropertyArrayValue from PropertyValue!");
                return retrivedValue;
            }
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
            get
            {
                PropertyMap retrivedValue = new PropertyMap();
                if (TrueValue.Get(retrivedValue))
                {
                    return retrivedValue;
                }
                NUILog.Error($"[ERROR] Fail to get PropertyMapValue from PropertyValue!");
                return retrivedValue;
            }
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

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                TrueValue?.Dispose();
            }
            disposed = true;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Dispose()
        {
            Dispose(true);
            global::System.GC.SuppressFinalize(this);
        }
    }
}
