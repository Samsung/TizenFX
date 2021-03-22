/*
 * Copyright (c) 2021 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI
{
    /// <summary>
    /// [Draft] A MeasureSpecification is used during the Measure pass by a LayoutGroup to inform it's children how to be measured.
    /// For instance, it may measure a child with an exact width and an unspecified height in order to determine height for width.
    /// </summary>
    public struct MeasureSpecification
    {
        /// <summary>
        /// MeasureSpecification Size value.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// When deleting the field, change it to property.
        [Obsolete("Deprecated in API9, Will be removed in API11. Please use GetSize,SetSize instead!")]
        [SuppressMessage("Microsoft.Design", "CA1051:Do not declare visible instance fields")]
        public LayoutLength Size;

        /// <summary>
        /// MeasureSpecification Mode.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// When deleting the field, change it to property.
        [Obsolete("Deprecated in API9, Will be removed in API11. Please use GetMode,SetMode instead!")]
        [SuppressMessage("Microsoft.Design", "CA1051:Do not declare visible instance fields")]
        public MeasureSpecification.ModeType Mode;

        /// <summary>
        /// Constructor taking size and mode type.
        /// </summary>
        /// <param name="size">size value.</param>
        /// <param name="mode">mode value.</param>
        /// <since_tizen> 6 </since_tizen>
        public MeasureSpecification(LayoutLength size, MeasureSpecification.ModeType mode)
        {
            Size = size;
            Mode = mode;
        }

        /// <summary>
        /// Size mode for this MeasureSpecification
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public enum ModeType
        {
            /// <summary>
            /// This is used by a parent to determine the desired dimension of a child layout.
            /// </summary>
            Unspecified,
            /// <summary>
            /// This is used by a parent to impose an exact size on the child.
            /// The child must use this size, and guarantee that all of its descendants will fit within this size.
            /// </summary>
            Exactly,
            /// <summary>
            /// This is used by the parent to impose a maximum size on the child.
            /// The child must guarantee that it and all of it's descendants will fit within this size.
            /// </summary>
            AtMost
        }

        /// <summary>
        /// Set MeasureSpecification Size value.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetSize(LayoutLength size)
        {
            Size = size;
        }

        /// <summary>
        /// Get MeasureSpecification Size value.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public LayoutLength GetSize()
        {
            return Size;
        }

        /// <summary>
        /// Set MeasureSpecification Mode.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetMode(MeasureSpecification.ModeType mode)
        {
            Mode = mode;
        }

        /// <summary>
        /// Get MeasureSpecification Mode.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MeasureSpecification.ModeType GetMode()
        {
            return Mode;
        }
    }
}
