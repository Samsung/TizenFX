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
    /// The WindowDimInfo structure contains information for dimming effect applied for window or related region.
    ///
    /// This structure is used to configure dimming effects when WindowBlurType.BEHIND is applied.
    /// Behind blur affects the area behind the window (excluding the window region itself), and this
    /// structure allows additional dimming to be applied to that blurred area for better visual contrast
    /// and user experience.
    ///
    /// The dimming effect uses a color overlay with alpha transparency to darken the blurred background.
    /// This is particularly useful when the blurred background content is too bright or distracting,
    /// making it difficult to see the foreground window content clearly.
    ///
    /// Common usage examples:
    /// - Subtle darkening: new WindowDimInfo(1, new Color(0.0f, 0.0f, 0.0f, 0.3f))
    /// - Strong darkening: new WindowDimInfo(1, new Color(0.0f, 0.0f, 0.0f, 0.7f))
    /// - Reddish tint: new WindowDimInfo(1, new Color(1.0f, 0.0f, 0.0f, 0.2f))
    /// - Disabled: new WindowDimInfo(0, new Color(0.0f, 0.0f, 0.0f, 0.0f))
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public struct WindowDimInfo : IEquatable<WindowDimInfo>
    {
        /// <summary>
        /// Constructor with enable flag and dim color.
        /// </summary>
        /// <param name="enable">True to enable dimming effect, false to disable</param>
        /// <param name="dim">The dimming color (RGBA) to apply. The alpha component controls the dimming intensity.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WindowDimInfo(int enable, Color dim)
        {
            IsEnabled = enable;
            DimColor = dim;
        }

        /// <summary>
        /// Gets or sets the flag to enable or disable the dimming effect.
        ///
        /// When true (1), the dimming effect is applied to the related region.
        /// When false (0), no dimming is applied and only the blur effect is visible.
        ///
        /// Default value: 0 (disabled)
        /// </summary>
        /// <value>The enable state for dimming effect (0 = disabled, 1 = enabled)</value>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int IsEnabled {get; set;}

        /// <summary>
        /// Gets or sets the dimming color to apply to the related region.
        ///
        /// This is an RGBA color value where:
        /// - RGB components define the dimming color (typically black for darkening)
        /// - Alpha component controls the dimming intensity (0.0 = transparent, 1.0 = fully opaque)
        ///
        /// Common usage examples:
        /// - Color(0.0f, 0.0f, 0.0f, 0.3f) for subtle darkening
        /// - Color(0.0f, 0.0f, 0.0f, 0.7f) for strong darkening
        /// - Color(1.0f, 0.0f, 0.0f, 0.2f) for reddish tint
        ///
        /// Default value: Color(0.0f, 0.0f, 0.0f, 0.0f) (fully transparent)
        /// </summary>
        /// <value>The dimming color with alpha transparency</value>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color DimColor {get; set;}

        /// <summary>
        /// Whether this is equivalent to other.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Equals(WindowDimInfo other)
        {
            return IsEnabled == other.IsEnabled &&
                   DimColor.Equals(other.DimColor);
        }

        ///  <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj)
        {
            if (obj is WindowDimInfo other)
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
                int hashcode = IsEnabled.GetHashCode();
                hashcode = hashcode * 397 ^ DimColor.GetHashCode();
                return hashcode;
            }
        }

        /// <summary>
        /// Compares two WindowDimInfo for equality.
        /// </summary>
        /// <param name="operand1">The first operand object.</param>
        /// <param name="operand2">The second operand object.</param>
        /// <returns>True if both are equal, otherwise false.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator ==(WindowDimInfo operand1, WindowDimInfo operand2)
        {
            return operand1.Equals(operand2);
        }

        /// <summary>
        /// Compares two WindowDimInfo for inequality.
        /// </summary>
        /// <param name="operand1">The first operand object.</param>
        /// <param name="operand2">The second operand object.</param>
        /// <returns>True if both are not equal, otherwise false.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator !=(WindowDimInfo operand1, WindowDimInfo operand2)
        {
            return !operand1.Equals(operand2);
        }
    }

    /// <summary>
    /// WindowBlurInfo is a struct designed to encapsulate the information required to apply a blur effect to a window.
    /// It contains four properties that define how the blur effect is applied to the window,
    /// including the type of blur, its intensity, the corner rounding for the background blur,
    /// and the dimming information for behind blur effect.
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
            BehindBlurDimInfo = new WindowDimInfo(0, new Color(0.0f, 0.0f, 0.0f, 0.0f));
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
            BehindBlurDimInfo = new WindowDimInfo(0, new Color(0.0f, 0.0f, 0.0f, 0.0f));
        }

        /// <summary>
        /// The construct with blur type, radius, corner radius, and dimming information.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WindowBlurInfo(WindowBlurType blurType, int blurRadius, int cornerRadius, WindowDimInfo behindBlurDimInfo)
        {
            BlurType = blurType;
            BlurRadius = blurRadius;
            BackgroundCornerRadius = cornerRadius;
            BehindBlurDimInfo = behindBlurDimInfo;
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
        /// Gets or sets the dimming information for behind blur effect.
        ///
        /// This property contains the configuration for dimming effect that is applied to the behind blur region
        /// when WindowBlurType.BEHIND is used. The dimming effect helps improve visual contrast
        /// between the blurred background and the foreground window content.
        ///
        /// The dimming effect is only applied when the window blur type is set to BEHIND.
        /// For other blur types (NONE or BACKGROUND), this setting has no visual effect.
        ///
        /// Default value: WindowDimInfo(0, new Color(0.0f, 0.0f, 0.0f, 0.0f)) (disabled)
        /// </summary>
        /// <value>The dimming configuration for behind blur effect</value>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WindowDimInfo BehindBlurDimInfo {get; set;}

        /// <summary>
        /// Whether this is equivalent to other.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Equals(WindowBlurInfo other)
        {
            return BlurType == other.BlurType &&
                   BlurRadius == other.BlurRadius &&
                   BackgroundCornerRadius == other.BackgroundCornerRadius &&
                   BehindBlurDimInfo.Equals(other.BehindBlurDimInfo);
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
                hashcode = hashcode * 397 ^ BehindBlurDimInfo.GetHashCode();
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
