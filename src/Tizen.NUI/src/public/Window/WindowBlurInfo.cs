/*
 * Copyright (c) 2023 Samsung Electronics Co., Ltd.
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
    /// WindowBlurInfo is a struct designed to encapsulate the information required to apply a blur effect to a window. 
    /// It contains three properties that define how the blur effect is applied to the window, 
    /// including the type of blur, its intensity, and the corner rounding for the background blur.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public struct WindowBlurInfo : IEquatable<WindowBlurInfo>
    {
        /// <summary>
        /// The construct with blur type, radius and corner radius for background type.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WindowBlurInfo(WindowBlurType blurType, int blurRadius, int cornerRadius)
        {
            BlurType = blurType;
            BlurRadius = blurRadius;
            BackgroundCornerRadius = cornerRadius;
        }

        /// <summary>
        /// The construct with blur type and radius.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WindowBlurInfo(WindowBlurType blurType, int blurRadius)
        {
            BlurType = blurType;
            BlurRadius = blurRadius;
            BackgroundCornerRadius = 0;            
        }

        /// <summary>
        /// Gets or sets the blur type of the window.
        /// </summary>
        /// <value>The window blur type of the window.</value>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WindowBlurType BlurType {get; set;}

        /// <summary>
        /// Gets or sets the blur radius of the window.
        /// </summary>
        /// <value>The blur radius of the window.</value>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int BlurRadius {get; set;}

        /// <summary>
        /// Gets or sets the corner radius of the window.
        /// It is only useful when window blur type is background.
        /// 
        /// When applying the background corner radius, ensure that the window's own corner radius is applied first. 
        /// The blur effect will respect the window's pre-defined corner radius settings 
        /// before applying the specified background corner radius.
        /// </summary>
        /// <value>The corner radius of the window.</value>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int BackgroundCornerRadius {get; set;}
        
        /// <summary>
        /// Whether this is equivalent to other.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Equals(WindowBlurInfo other)
        {
            return BlurType == other.BlurType &&
                   BlurRadius == other.BlurRadius &&
                   BackgroundCornerRadius == other.BackgroundCornerRadius;
        }

        ///  <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj)
        {
            if (obj is WindowBlurInfo other)
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
                int hashcode = ((int)BlurType).GetHashCode();
                hashcode = hashcode * 397 ^ BlurRadius.GetHashCode();
                hashcode = hashcode * 397 ^ BackgroundCornerRadius.GetHashCode();
                return hashcode;
            }
        }

        /// <summary>
        /// Compares two WindowBlurInfo for equality.
        /// </summary>
        /// <param name="operand1">The first operand object.</param>
        /// <param name="operand2">The second operand object.</param>
        /// <returns>True if both are equal, otherwise false.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator ==(WindowBlurInfo operand1, WindowBlurInfo operand2)
        {
            return operand1.Equals(operand2);
        }

        /// <summary>
        /// Compares two WindowBlurInfo for inequality.
        /// </summary>
        /// <param name="operand1">The first operand object.</param>
        /// <param name="operand2">The second operand object.</param>
        /// <returns>True if both are not equal, otherwise false.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator !=(WindowBlurInfo operand1, WindowBlurInfo operand2)
        {
            return !operand1.Equals(operand2);
        }
    }
}
