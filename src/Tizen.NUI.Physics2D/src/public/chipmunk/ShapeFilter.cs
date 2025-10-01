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
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Tizen.NUI.Physics2D.Chipmunk
{
    /// <summary>
    /// Fast collision filtering type that is used to determine if two objects collide before calling collision or query callbacks.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [StructLayout(LayoutKind.Sequential)]
    public struct ShapeFilter
    {
        private static readonly UIntPtr no_group = (UIntPtr)0;
        private static readonly uint all_categories = (~(uint)0);

        private static readonly ShapeFilter filter_all = new ShapeFilter(no_group, all_categories, all_categories);
        private static readonly ShapeFilter filter_none = new ShapeFilter(no_group, ~all_categories, ~all_categories);

        private UIntPtr group;
        private uint categories;
        private uint mask;

        /// <summary>
        /// Group value
        /// Two objects with the same non-zero group value do not collide.
        /// This is generally used to group objects in a composite object together to disable self collisions.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public UIntPtr Group
        {
            get => group;
            set => group = value;
        }

        /// <summary>
        /// Categories value
        /// A bitmask of user definable categories that this object belongs to.
        /// The category/mask combinations of both objects in a collision must agree for a collision to occur.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint Categories
        {
            get => categories;
            set => categories = value;
        }

        /// <summary>
        /// Mask value
        /// A bitmask of user definable category types that this object object collides with.
        /// The category/mask combinations of both objects in a collision must agree for a collision to occur.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint Mask
        {
            get => mask;
            set => mask = value;
        }

        /// <summary>
        /// Create a shape filter.
        /// </summary>
        /// <param name="group"></param>
        /// <param name="categories"></param>
        /// <param name="mask"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ShapeFilter(UIntPtr group, uint categories, uint mask)
        {
            this.group = group;
            this.categories = categories;
            this.mask = mask;
        }

        /// <summary>
        /// Value for signifying that a shape is in no group.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static UIntPtr NO_GROUP => no_group;

        /// <summary>
        /// Value for signifying that a shape is in every layer.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static uint ALL_CATEGORIES => all_categories;

        /// <summary>
        /// Collision filter value for a shape that will collide with anything except FILTER_NONE.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ShapeFilter FILTER_ALL => filter_all;

        /// <summary>
        /// Collision filter value for a shape that does not collide with anything.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ShapeFilter FILTER_NONE => filter_none;
    }
}
