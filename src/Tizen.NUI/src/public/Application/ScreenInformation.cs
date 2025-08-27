/*
 * Copyright (c) 2025 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.Binding;

namespace Tizen.NUI
{
    /// <summary>
    /// ScreenInformation is a struct designed to encapsulate the information of screen. 
    /// It contains three properties as screen name, width and hegiht.
    /// The ScreenInformation is especially used to support multiple screen.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public struct ScreenInformation : IEquatable<ScreenInformation>
    {
        /// <summary>
        /// The construct with name, width and height for screen.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ScreenInformation(string name, int width, int height)
        {
            Name = name;
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Gets or sets the name of the screen.
        /// </summary>
        /// <value>The name of the screen.</value>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Name {get; set;}

        /// <summary>
        /// Gets or sets the width of the screen.
        /// </summary>
        /// <value>The width of the screen.</value>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int Width {get; set;}

        /// <summary>
        /// Gets or sets the height of the screen.
        /// 
        /// </summary>
        /// <value>The height of the screen.</value>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int Height {get; set;}
        
        /// <summary>
        /// Whether this is equivalent to other.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Equals(ScreenInformation other)
        {
            return Name == other.Name &&
                   Width == other.Width &&
                   Height == other.Height;
        }

        ///  <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj)
        {
            if (obj is ScreenInformation other)
            {
                return Equals(other);
            }
            return base.Equals(obj);
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            unchecked
            {
                int hashcode = Width.GetHashCode();
                hashcode = hashcode * 397 ^ Height.GetHashCode();
                return hashcode;
            }
        }

        /// <summary>
        /// Compares two ScreenInformation for equality.
        /// </summary>
        /// <param name="operand1">The first operand object.</param>
        /// <param name="operand2">The second operand object.</param>
        /// <returns>True if both are equal, otherwise false.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator ==(ScreenInformation operand1, ScreenInformation operand2)
        {
            return operand1.Equals(operand2);
        }

        /// <summary>
        /// Compares two ScreenInformation for inequality.
        /// </summary>
        /// <param name="operand1">The first operand object.</param>
        /// <param name="operand2">The second operand object.</param>
        /// <returns>True if both are not equal, otherwise false.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator !=(ScreenInformation operand1, ScreenInformation operand2)
        {
            return !operand1.Equals(operand2);
        }
    }
}
