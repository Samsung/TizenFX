/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.ComponentModel;
using System.Diagnostics;
using Native = Interop.Display;

namespace Tizen.Multimedia
{
    /// <summary>
    /// Provides a means to configure display settings for video <see cref="Player"/>.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class PlayerDisplaySettings
    {
        /// <summary>
        /// This constructor supports the product infrastructure and is not intended to be used directly from application code.
        /// </summary>
        /// <param name="player"> The handle for the media player </param>
        /// <since_tizen> 4 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected PlayerDisplaySettings(Player player)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            Player = player;
        }

        internal static PlayerDisplaySettings Create(Player player) => new PlayerDisplaySettings(player);

        /// <summary>
        /// Gets the player of this instance.
        /// </summary>
        /// <value>The <see cref="Player"/> of this <see cref="PlayerDisplaySettings"/> instance.</value>
        /// <since_tizen> 4 </since_tizen>
        protected Player Player { get; }

        /// <summary>
        /// Gets or sets the <see cref="PlayerDisplayMode"/> of the player.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        ///     Operation failed; internal error.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <exception cref="ArgumentException">The specified value to set is invalid.</exception>
        /// <since_tizen> 3 </since_tizen>
        public PlayerDisplayMode Mode
        {
            get
            {
                Native.GetMode(Player.Handle, out var value).
                    ThrowIfFailed(Player, "Failed to get display mode");

                return value;
            }
            set
            {
                ValidationUtil.ValidateEnum(typeof(PlayerDisplayMode), value, nameof(value));

                Native.SetMode(Player.Handle, value).
                    ThrowIfFailed(Player, "Failed to set display mode");
            }
        }

        /// <summary>
        /// Gets or sets the value indicating whether the display is visible.
        /// </summary>
        /// <value>true if the display is visible; otherwise false.</value>
        /// <exception cref="InvalidOperationException">
        ///     Operation failed; internal error.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <since_tizen> 3 </since_tizen>
        public bool IsVisible
        {
            get
            {
                Native.IsVisible(Player.Handle, out var value).
                    ThrowIfFailed(Player, "Failed to get the visible state of the display");

                return value;
            }
            set
            {
                Native.SetVisible(Player.Handle, value).ThrowIfFailed(
                    Player, "Failed to set the visible state of the display");
            }
        }

        /// <summary>
        /// Gets or sets the rotation of the display.
        /// </summary>
        /// <value><see cref="Rotation.Rotate0"/>, <see cref="Rotation.Rotate90"/>, <see cref="Rotation.Rotate180"/>,
        ///     <see cref="Rotation.Rotate270"/>.</value>
        /// <exception cref="InvalidOperationException">
        ///     Operation failed; internal error.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <exception cref="ArgumentException">The specified value to set is invalid.</exception>
        /// <since_tizen> 3 </since_tizen>
        public Rotation Rotation
        {
            get
            {
                Native.GetRotation(Player.Handle, out var value).
                    ThrowIfFailed(Player, "Failed to get the rotation state of the display");

                return value;
            }
            set
            {
                ValidationUtil.ValidateEnum(typeof(Rotation), value, nameof(value));

                Native.SetRotation(Player.Handle, value).
                    ThrowIfFailed(Player, "Failed to set the rotation state of the display");
            }
        }

        /// <summary>
        /// Sets the ROI(Region Of Interest) for the video display.
        /// </summary>
        /// <param name="roi">The region.</param>
        /// <remarks>
        /// the roi can be set before setting <see cref="PlayerDisplayMode.Roi"/>. (since 4.0)
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        ///     Operation failed; internal error.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The width or the height is less than or equal to zero.</exception>
        /// <since_tizen> 3 </since_tizen>
        public void SetRoi(Rectangle roi)
        {
            if (roi.Width <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(roi), roi.Width,
                    $"The width of the roi can't be less than or equal to zero.");
            }

            if (roi.Height <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(roi), roi.Height,
                    $"The height of the roi can't be less than or equal to zero.");
            }

            Native.SetRoi(Player.Handle, roi.X, roi.Y, roi.Width, roi.Height).
                ThrowIfFailed(Player, "Failed to set the roi");
        }
    }
}
