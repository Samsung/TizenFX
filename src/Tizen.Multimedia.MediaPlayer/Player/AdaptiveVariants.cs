/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Diagnostics;
using System.Collections.Generic;
using static Interop;

namespace Tizen.Multimedia
{
    /// <summary>
    /// Represents properties for the variant information
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public struct VariantInfo
    {
        /// <summary>
        /// Initializes a new instance of the VariantInfo struct.
        /// </summary>
        /// <param name="bandwidth">The bandwidth of the stream can be supportable, it must be set. (deafult: -1)</param>
        /// <param name="width">The width of the stream, this is optional parameter. (deafult: -1)</param>
        /// <param name="height">The height of the stream, this is optional parameter. (deafult: -1)</param>
        /// <since_tizen> 5 </since_tizen>
        public VariantInfo(int bandwidth, int width = -1, int height = -1)
        {
            Bandwidth = bandwidth;
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Gets or sets the maximum limit of the available bandwidth. (-1 = no limit)
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public int Bandwidth
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the maximum limit of the available width. (-1 = no limit)
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public int Width
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the maximum limit of the available height. (-1 = no limit)
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public int Height
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Provides the ability to control the maximum limit of the available streaming variant for <see cref="Multimedia.Player"/>.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public class AdaptiveVariants
    {
        private IList<VariantInfo> _adaptiveVariants;

        /// <summary>
        /// Gets the <see cref="Multimedia.Player"/> that owns this instance.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        private readonly Player Player;

        internal AdaptiveVariants(Player player)
        {
            Debug.Assert(player != null);
            Player = player;
        }

        /// <summary>
        /// Sets the maximum limit of the streaming variant.
        /// </summary>
        /// <exception cref="ObjectDisposedException">The <see cref="Player"/> has already been disposed of.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <pramref name="bandwidth"/> is less than -1.<br/>
        ///     -or-<br/>
        ///     <pramref name="width"/> is less than -1.<br/>
        ///     -or-<br/>
        ///     <pramref name="height"/> is less than -1.<br/>
        /// </exception>
        /// <seealso cref="GetMaxLimit()"/>
        /// <since_tizen> 5 </since_tizen>
        public void SetMaxLimit(int bandwidth, int width = -1, int height = -1)
        {
            Player.ValidateNotDisposed();

            if (bandwidth < -1 || width < -1 || height < -1)
            {
                throw new ArgumentOutOfRangeException("invalid range");
            }

            NativePlayer.SetMaxLimit(Player.Handle, bandwidth, width, height).
                    ThrowIfFailed(Player, "Failed to set the max limit to the player");
        }

        /// <summary>
        /// Gets the maximum limit of the streaming variant.
        /// </summary>
        /// <returns>The <see cref="VariantInfo"/> containing the variant information.</returns>
        /// <exception cref="ObjectDisposedException">The <see cref="Player"/> has already been disposed of.</exception>
        /// <seealso cref="SetMaxLimit(int, int, int)"/>
        /// <since_tizen> 5 </since_tizen>
        public VariantInfo GetMaxLimit()
        {
            Player.ValidateNotDisposed();

            NativePlayer.GetMaxLimit(Player.Handle, out var bandwidth, out var width, out var height).
                    ThrowIfFailed(Player, "Failed to get the max limit to the player");

            return new VariantInfo(bandwidth, width, height);
        }

        /// <summary>
        /// Retrieves all the available adaptive variants.
        /// </summary>
        /// <returns>
        /// It returns a list contained all the available adaptive variants.
        /// </returns>
        /// The <see cref="Player"/> must be in the <see cref="PlayerState.Ready"/>,
        /// <see cref="PlayerState.Playing"/>, or <see cref="PlayerState.Paused"/> state.
        /// <exception cref="InvalidOperationException">The player is not in the valid state.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="Player"/> has already been disposed of.</exception>
        /// <seealso cref="VariantInfo"/>
        /// <since_tizen> 5 </since_tizen>
        public IEnumerable<VariantInfo> AvailableAdaptiveVariants
        {
            get
            {
                if (_adaptiveVariants == null)
                {
                    _adaptiveVariants = GetAdaptiveVariants();
                }

                return _adaptiveVariants;
            }
        }

        private IList<VariantInfo> GetAdaptiveVariants()
        {
            List<VariantInfo> adaptiveVariants = new List<VariantInfo>();

            NativePlayer.AdaptiveVariantCallback callback = (int bandwidth, int width, int height, IntPtr userData) =>
            {
                adaptiveVariants.Add(new VariantInfo(bandwidth, width, height));
                return true;
            };

            NativePlayer.ForeachAdaptiveVariants(Player.Handle, callback, IntPtr.Zero).
                ThrowIfFailed(Player, "Failed to get the information of adaptive variants");

            return adaptiveVariants.AsReadOnly();
        }
    }
}
