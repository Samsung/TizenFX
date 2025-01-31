/*
 * Copyright(c) 2025 Samsung Electronics Co., Ltd.
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
    /// Defines a value type of corner radius.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public struct UICorner
    {
        /// <summary>
        /// The default corner. (This is to distinguish from zero corners)
        /// </summary>
        public static readonly UICorner Default = new (-1, -1, -1, -1);

        /// <summary>
        /// The zero corner.
        /// </summary>
        public static readonly UICorner Zero = new (0.0f, 0.0f, 0.0f, 0.0f);

        /// <summary>
        /// Initializes a new instance of the <see cref="UICorner"/> struct.
        /// </summary>
        /// <param name="uniform">The uniform corner value.</param>
        public UICorner(float uniform) : this(uniform, false)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UICorner"/> struct.
        /// </summary>
        /// <param name="uniform">The uniform corner value.</param>
        /// <param name="isRelative">Whether the values should be considered as relative to target box size.</param>
        public UICorner(float uniform, bool isRelative) : this(uniform, uniform, uniform, uniform, isRelative)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UICorner"/> struct.
        /// </summary>
        /// <param name="topLeft">The top-left value.</param>
        /// <param name="topRight">The top-right value.</param>
        /// <param name="bottomRight">The bottom-right value.</param>
        /// <param name="bottomLeft">The bottom-left value.</param>
        public UICorner(float topLeft, float topRight, float bottomRight, float bottomLeft) : this(topLeft, topRight, bottomRight, bottomLeft, false)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UICorner"/> struct.
        /// </summary>
        /// <param name="topLeft">The top-left value.</param>
        /// <param name="topRight">The top-right value.</param>
        /// <param name="bottomRight">The bottom-right value.</param>
        /// <param name="bottomLeft">The bottom-left value.</param>
        /// <param name="isRelative">Whether the values should be considered as relative to target box size.</param>
        public UICorner(float topLeft, float topRight, float bottomRight, float bottomLeft, bool isRelative)
        {
            TopLeft = topLeft;
            TopRight = topRight;
            BottomRight = bottomRight;
            BottomLeft = bottomLeft;
            IsRelative = isRelative;
        }

        /// <summary>
        /// Gets a value indicating whether this is default.
        /// </summary>
        public readonly bool IsDefault => TopLeft == -1 && TopRight == -1 && BottomRight == -1 && BottomLeft == -1;

        /// <summary>
        /// Gets a value indicating whether this is zero.
        /// </summary>
        public readonly bool IsZero => TopLeft == 0 && TopRight == 0 && BottomRight == 0 && BottomLeft == 0;

        /// <summary>
        /// The radius of the top left corner of the rectangle.
        /// </summary>
        public float TopLeft { get; }

        /// <summary>
        /// The radius of the top right corner of the rectangle.
        /// </summary>
        public float TopRight { get; }

        /// <summary>
        /// The radius of the bottom right corner of the rectangle.
        /// </summary>
        public float BottomRight { get; }

        /// <summary>
        /// The radius of the bottom left corner of the rectangle.
        /// </summary>
        public float BottomLeft { get; }

        /// <summary>
        /// Gets a value indicating whether the values are relative to target box size.
        /// </summary>
        public bool IsRelative { get; }

        internal readonly NUI.Vector4 ToReferenceType() => new NUI.Vector4(TopLeft, TopRight, BottomRight, BottomLeft);
    }
}
