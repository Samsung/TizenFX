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
using static Interop;

namespace Tizen.Multimedia
{
    /// <summary>
    /// Represents properties for the spherical video direction of view
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public struct DirectionOfView
    {
        /// <summary>
        /// Initializes a new instance of the struct with the specified direction of view for the spherical video.
        /// </summary>
        /// <param name="yaw">Pointer to store current value of direction of view angle around vertical axis.</param>
        /// <param name="pitch">Pointer to store current value of direction of view angle around lateral axis.</param>
        /// <since_tizen> 5 </since_tizen>
        public DirectionOfView(float yaw, float pitch)
        {
            Yaw = yaw;
            Pitch = pitch;

            Log.Debug(PlayerLog.Tag, $"yaw={yaw}, pitch={pitch}");
        }

        /// <summary>
        /// Gets or sets the Yaw.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public float Yaw
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Pitch.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public float Pitch
        {
            get;
            set;
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        /// <since_tizen> 5 </since_tizen>
        public override string ToString() =>
            $"Yaw={ Yaw.ToString() }, Pitch={ Pitch.ToString() }";
    }

    /// <summary>
    /// Represents properties for the spherical video field of view
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public struct FieldOfView
    {
        /// <summary>
        /// Initializes a new instance of the struct with the specified field of view for the spherical video.
        /// </summary>
        /// <param name="horizontalDegrees">The horizontal field of view to display in degrees.</param>
        /// <remarks>
        /// Valid range is 1-360 degrees. Default value is 120 degrees.
        /// </remarks>
        /// <param name="verticalDegrees">The vertical  field of view to display in degrees.</param>
        /// <remarks>
        /// Valid range is 1-180 degrees. Default value is 67 degrees.
        /// </remarks>
        /// <since_tizen> 5 </since_tizen>
        public FieldOfView(int horizontalDegrees, int verticalDegrees)
        {
            HorizontalDegrees = horizontalDegrees;
            VerticalDegrees = verticalDegrees;

            Log.Debug(PlayerLog.Tag, $"horizontalDegrees={horizontalDegrees}, verticalDegrees={verticalDegrees}");
        }

        /// <summary>
        /// Gets or sets the HorizontalDegrees.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public int HorizontalDegrees
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the VerticalDegrees.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public int VerticalDegrees
        {
            get;
            set;
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        /// <since_tizen> 5 </since_tizen>
        public override string ToString() =>
            $"HorizontalDegrees={ HorizontalDegrees.ToString() }, VerticalDegrees={ VerticalDegrees.ToString() }";
    }

    /// <summary>
    /// Provides the ability to control the spherical video for <see cref="Multimedia.Player"/>.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public class SphericalVideo
    {
        /// <summary>
        /// Gets the <see cref="Multimedia.Player"/> that owns this instance.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public Player Player { get; }

        /// <summary>
        /// Provides a means to retrieve spherical video information.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        internal SphericalVideo(Player player)
        {
            Debug.Assert(player != null);
            Player = player;
        }

        /// <summary>
        /// Gets information whether the current content of the player is spherical.
        /// </summary>
        /// <returns>true if the current content is spherical; otherwise false.</returns>
        /// <remarks>
        /// The <see cref="Player"/> that owns this instance must be in the <see cref="PlayerState.Ready"/>,
        /// <see cref="PlayerState.Playing"/>, or <see cref="PlayerState.Paused"/> state.
        /// </remarks>
        /// <exception cref="ObjectDisposedException">The <see cref="Player"/> that this instance belongs to has been disposed of.</exception>
        /// <exception cref="InvalidOperationException">The <see cref="Player"/> that this instance belongs to is not in the valid state.</exception>
        /// <since_tizen> 5 </since_tizen>
        public bool IsSphericalContent()
        {
            Player.ValidatePlayerState(PlayerState.Ready, PlayerState.Playing, PlayerState.Paused);

            NativePlayer.IsSphericalContent(Player.Handle, out var value).
                ThrowIfFailed(Player, "Failed to get the spherical state of the content");

            return value;
        }

        /// <summary>
        /// Gets the level of the zoom when it is spherical.
        /// </summary>
        /// <remarks>Remark.</remarks>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <exception cref="InvalidOperationException">The player is not in the valid state.</exception>
        /// <seealso cref="SetZoom(float)"/>
        /// <since_tizen> 5 </since_tizen>
        public float GetZoom()
        {
            Player.ValidateNotDisposed();

            NativePlayer.GetZoom(Player.Handle, out var value).
                ThrowIfFailed(Player, "Failed to get the level of the zoom");

            return value;
        }

        /// <summary>
        /// Gets the level of the zoom when it is spherical .
        /// </summary>
        /// <remarks>Remark.</remarks>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <exception cref="InvalidOperationException">The player is not in the valid state.</exception>
        /// <seealso cref="GetZoom()"/>
        /// <since_tizen> 5 </since_tizen>
        public void SetZoom(float level)
        {
            Player.ValidateNotDisposed();

            if (level < 1.0F || 10.0F < level)
            {
                throw new ArgumentOutOfRangeException(nameof(level), level, "Valid level is 1.0 to 10.0");
            }

            NativePlayer.SetZoom(Player.Handle, level).ThrowIfFailed(Player, "Failed to set the level of the zoom.");
        }

        /// <summary>
        /// Gets or sets the spherical mode.
        /// </summary>
        /// <remarks>The player must be in the <see cref="PlayerState.Ready"/>, <see cref="PlayerState.Playing"/>,
        /// or <see cref="PlayerState.Paused"/> state.</remarks>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <exception cref="InvalidOperationException">The player is not in the valid state.</exception>
        /// <since_tizen> 5 </since_tizen>
        public bool Mode
        {
            get
            {
                NativePlayer.IsSphericalMode(Player.Handle, out var value).
                    ThrowIfFailed(Player, "Failed to get whether the spherical mode of the player is enabled or not");
                return value;
            }

            set
            {
                Player.ValidateNotDisposed();
                NativePlayer.SetSphericalMode(Player.Handle, value).
                    ThrowIfFailed(Player, "Failed to set the spherical mode of the player");
            }
        }


        /// <summary>
        /// Gets the properties of the audio.
        /// </summary>
        /// <returns>A <see cref="DirectionOfView"/> that contains the audio stream information.</returns>
        /// <remarks>
        /// Remark
        /// </remarks>
        /// <exception cref="ObjectDisposedException">
        /// The <see cref="Multimedia.Player"/> that this instance belongs to has been disposed of.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// The <see cref="Multimedia.Player"/> that this instance belongs to is not in the valid state.
        /// </exception>
        /// <seealso cref="DirectionOfView"/>
        /// <since_tizen> 5 </since_tizen>
        public DirectionOfView GetDirectionOfView()
        {
            Player.ValidateNotDisposed();

            NativePlayer.GetDirectionOfView(Player.Handle, out var yaw, out var pitch).
                ThrowIfFailed(Player, "Failed to get the direction of view");

            return new DirectionOfView(yaw, pitch);
        }

        /// <summary>
        /// Sets the properties of the video.
        /// </summary>
        public void SetDirectionOfView(DirectionOfView directionofview)
        {
            Player.ValidateNotDisposed();

            if (directionofview.Yaw > Math.PI || directionofview.Yaw < -Math.PI)
            {
                throw new ArgumentOutOfRangeException(nameof(directionofview.Yaw), directionofview.Yaw,
                    $"Valid values are in range [-PI, PI].");
            }

            if (directionofview.Pitch > Math.PI/2 || directionofview.Pitch < -Math.PI/2)
            {
                throw new ArgumentOutOfRangeException(nameof(directionofview.Pitch), directionofview.Pitch,
                    $"Valid values are in range [-PI/2, PI/2].");
            }

            NativePlayer.SetDirectionOfView(Player.Handle, directionofview.Yaw, directionofview.Pitch).
                ThrowIfFailed(Player, "Failed to set the direction of the view.");
        }

        /// <summary>
        /// Gets the properties of the video.
        /// </summary>
        /// <returns>A <see cref="VideoStreamProperties"/> that contains the video stream information.</returns>
        /// <remarks>
        /// Remark
        /// </remarks>
        /// <exception cref="ObjectDisposedException">
        /// The <see cref="Multimedia.Player"/> that this instance belongs to has been disposed of.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// The <see cref="Multimedia.Player"/> that this instance belongs to is not in the valid state.
        /// </exception>
        /// <seealso cref="FieldOfView"/>
        /// <since_tizen> 5 </since_tizen>
        public FieldOfView GetFieldOfView()
        {
            Player.ValidateNotDisposed();

            NativePlayer.GetFieldOfView(Player.Handle, out var horizontalDegrees, out var verticalDegrees).
                ThrowIfFailed(Player, "Failed to get the field of view");

            return new FieldOfView(horizontalDegrees, verticalDegrees);
        }

        /// <summary>
        /// Sets the properties of the video.
        /// </summary>
        public void SetFieldOfView(FieldOfView fieldofview)
        {
            Player.ValidateNotDisposed();

            if (fieldofview.HorizontalDegrees < 1 || fieldofview.HorizontalDegrees > 360)
            {
                throw new ArgumentOutOfRangeException(nameof(fieldofview.HorizontalDegrees), fieldofview.HorizontalDegrees,
                    $"Valid range is 1-360 degrees.");
            }

            if (fieldofview.VerticalDegrees < 1 || fieldofview.VerticalDegrees > 180)
            {
                throw new ArgumentOutOfRangeException(nameof(fieldofview.VerticalDegrees), fieldofview.VerticalDegrees,
                    $"Valid range is 1-180 degrees.");
            }

            NativePlayer.SetFieldOfView(Player.Handle, fieldofview.HorizontalDegrees, fieldofview.VerticalDegrees).
                ThrowIfFailed(Player, "Failed to set the field of the view.");
        }
    }
}
