/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    /// <summary>
    /// [Draft] This class represents a layout size (width and height), non mutable.
    /// </summary>
    internal class LayoutSizeEx : IEquatable<LayoutSizeEx>
    {
        /// <summary>
        /// [Draft] Constructor from width and height
        /// </summary>
        /// <param name="width">Int to initialize with.</param>
        /// <param name="height">Int to initialize with.</param>
        public LayoutSizeEx(int width, int height)
        {
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Computes a hash code for this LayoutSize for use in hash based collections.
        /// </summary>
        /// <returns>A non unique hash code .</returns>
        public override int GetHashCode()
        {
            return Width ^ Height;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if equal LayoutSize, else false.</returns>
        public override bool Equals(object obj)
        {
            LayoutSizeEx layoutSizeEx = (LayoutSizeEx)obj;
            if (layoutSizeEx != null)
            {
                return this.Equals(layoutSizeEx);
            }
            return false;
        }

        /// <summary>
        /// Whether the values of two LayoutSize objects are equals
        /// </summary>
        /// <param name="obj">Object to be compared against.</param>
        /// <returns>true if obj is equal to this LayoutSize.</returns>
        public bool Equals(LayoutSizeEx obj)
        {
            LayoutSizeEx layoutSize = obj;
            return ((layoutSize.Width == Width) && (layoutSize.Height == Height));
        }

        /// <summary>
        /// [Draft] Get the width value of this layout
        /// </summary>
        public int Width{ get; private set; }

        /// <summary>
        /// [Draft] Get the height value of this layout
        /// </summary>
        public int Height{ get; private set; }

    }
}
