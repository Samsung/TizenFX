/*
 * Copyright(c) 2023 Samsung Electronics Co., Ltd.
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
using System.Collections.Generic;
using Tizen.NUI;

namespace Tizen.NUI.Scene3D
{
    /// <summary>
    /// Target value of motion. It can be define as specific PropertyValue, or KeyFrames
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class MotionValue : IDisposable
    {
        private IDisposable internalValue = null;

        /// <summary>
        /// Determine whether current stored value is PropertyValue, or KeyFrames.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum ValueType
        {
            /// <summary>
            /// Value is null, or invalid class.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Invalid,

            /// <summary>
            /// Value is PropertyValue.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Property,

            /// <summary>
            /// Value is KeyFrames.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            KeyFrames,
        }

        /// <summary>
        /// Create an initialized motion value with invalid.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MotionValue()
        {
        }

        /// <summary>
        /// Get or set the value as PropertyValue type.
        /// It will return null if value is not PropertyValue.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyValue Value
        {
            get
            {
                return internalValue as PropertyValue;
            }
            set
            {
                internalValue = (Disposable)value;
            }
        }

        /// <summary>
        /// Get or set the value as KeyFrames type.
        /// It will return null if value is not KeyFrames.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public KeyFrames KeyFramesValue
        {
            get
            {
                return internalValue as KeyFrames;
            }
            set
            {
                internalValue = (BaseHandle)value;
            }
        }

        /// <summary>
        /// Get the type of value what we setted.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ValueType Type
        {
            get
            {
                if (internalValue is KeyFrames)
                {
                    return ValueType.KeyFrames;
                }
                if (internalValue is PropertyValue)
                {
                    return ValueType.Property;
                }
                return ValueType.Invalid;
            }
        }

        /// <summary>
        /// IDisposable.Dipsose.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Dispose()
        {
            internalValue?.Dispose();
        }
    }
}
