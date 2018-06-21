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
        /// <param name="yaw">Pointer to store current value of direction of view angle around vertical axis.
        /// valid range is [-3.141593, 3.141593]. value will be rounded off to 6 decimal places.
        /// Default value is 0. </param>
        /// <param name="pitch">Pointer to store current value of direction of view angle around lateral axis.
        /// valid range is [-1.570796, 1.570796]. value will be rounded off to 6 decimal places.
        /// Default value is 0. </param>
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
        /// <returns>True if the current content is spherical; otherwise false.</returns>
        /// <remarks>
        /// The <see cref="Player"/> that owns this instance must be in the <see cref="PlayerState.Ready"/>,
        /// <see cref="PlayerState.Playing"/>, or <see cref="PlayerState.Paused"/> state.
        /// </remarks>
        /// <feature>http://tizen.org/feature/opengles.version.2_0</feature>
        /// <feature>http://tizen.org/feature/multimedia.player.spherical_video</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="Player"/> that this instance belongs to has been disposed of.</exception>
        /// <exception cref="InvalidOperationException">The <see cref="Player"/> that this instance belongs to is not in the valid state.</exception>
        /// <since_tizen> 5 </since_tizen>
        public bool IsSphericalContent()
        {
            ValidationUtil.ValidateFeatureSupported(PlayerFeatures.OpenGl);
            ValidationUtil.ValidateFeatureSupported(PlayerFeatures.SphericalVideo);

            Player.ValidatePlayerState(PlayerState.Ready, PlayerState.Playing, PlayerState.Paused);

            NativePlayer.IsSphericalContent(Player.Handle, out var value).
                ThrowIfFailed(Player, "Failed to get the spherical state of the content");

            return value;
        }

        /// <summary>
        /// Gets the level of the zoom of spherical video.
        /// </summary>
        /// <returns>The current zoom level of spherical video.</returns>
        /// <remarks>Remark.</remarks>
        /// <feature>http://tizen.org/feature/opengles.version.2_0</feature>
        /// <feature>http://tizen.org/feature/multimedia.player.spherical_video</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <exception cref="InvalidOperationException">The player is not in the valid state.</exception>
        /// <seealso cref="SetZoom(float)"/>
        /// <since_tizen> 5 </since_tizen>
        public float GetZoom()
        {
            ValidationUtil.ValidateFeatureSupported(PlayerFeatures.OpenGl);
            ValidationUtil.ValidateFeatureSupported(PlayerFeatures.SphericalVideo);

            Player.ValidateNotDisposed();

            NativePlayer.GetZoom(Player.Handle, out var value).
                ThrowIfFailed(Player, "Failed to get the level of the zoom");

            return value;
        }

        /// <summary>
        /// Sets the level of the zoom of spherical video.
        /// </summary>
        /// <param name="level">The zoom level.</param>
        /// <feature>http://tizen.org/feature/opengles.version.2_0</feature>
        /// <feature>http://tizen.org/feature/multimedia.player.spherical_video</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <exception cref="InvalidOperationException">The player is not in the valid state.</exception>
        /// <seealso cref="GetZoom()"/>
        /// <since_tizen> 5 </since_tizen>
        public void SetZoom(float level)
        {
            ValidationUtil.ValidateFeatureSupported(PlayerFeatures.OpenGl);
            ValidationUtil.ValidateFeatureSupported(PlayerFeatures.SphericalVideo);

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
        /// <feature>http://tizen.org/feature/opengles.version.2_0</feature>
        /// <feature>http://tizen.org/feature/multimedia.player.spherical_video</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <exception cref="InvalidOperationException">The player is not in the valid state.</exception>
        /// <since_tizen> 5 </since_tizen>
        public bool IsEnabled
        {
            get
            {
                ValidationUtil.ValidateFeatureSupported(PlayerFeatures.OpenGl);
                ValidationUtil.ValidateFeatureSupported(PlayerFeatures.SphericalVideo);

                Player.ValidateNotDisposed();
                NativePlayer.IsSphericalMode(Player.Handle, out var value).
                    ThrowIfFailed(Player, "Failed to get whether the spherical mode of the player is enabled or not");
                return value;
            }

            set
            {
                ValidationUtil.ValidateFeatureSupported(PlayerFeatures.OpenGl);
                ValidationUtil.ValidateFeatureSupported(PlayerFeatures.SphericalVideo);

                Player.ValidateNotDisposed();
                NativePlayer.SetSphericalMode(Player.Handle, value).
                    ThrowIfFailed(Player, "Failed to set the spherical mode of the player");
            }
        }


        /// <summary>
        /// Gets the direction of view for spherical video.
        /// </summary>
        /// <returns>The <see cref="DirectionOfView"/> containing the angle information.</returns>
        /// <feature>http://tizen.org/feature/opengles.version.2_0</feature>
        /// <feature>http://tizen.org/feature/multimedia.player.spherical_video</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="ObjectDisposedException">
        /// The <see cref="Multimedia.Player"/> that this instance belongs to has been disposed of.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// The <see cref="Multimedia.Player"/> that this instance belongs to is not in the valid state.
        /// </exception>
        /// <since_tizen> 5 </since_tizen>
        public DirectionOfView GetDirectionOfView()
        {
            ValidationUtil.ValidateFeatureSupported(PlayerFeatures.OpenGl);
            ValidationUtil.ValidateFeatureSupported(PlayerFeatures.SphericalVideo);

            Player.ValidateNotDisposed();

            NativePlayer.GetDirectionOfView(Player.Handle, out var yaw, out var pitch).
                ThrowIfFailed(Player, "Failed to get the direction of view");

            return new DirectionOfView(yaw, pitch);
        }

        /// <summary>
        /// Sets the direction of view for spherical video.
        /// </summary>
        /// <param name="directionOfView">The angle values around the vertical and lateral axis.</param>
        /// <feature>http://tizen.org/feature/opengles.version.2_0</feature>
        /// <feature>http://tizen.org/feature/multimedia.player.spherical_video</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="ObjectDisposedException">
        /// The <see cref="Multimedia.Player"/> that this instance belongs to has been disposed of.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// The <see cref="Multimedia.Player"/> that this instance belongs to is not in the valid state.
        /// </exception>
        /// <seealso cref="DirectionOfView"/>
        /// <since_tizen> 5 </since_tizen>
        public void SetDirectionOfView(DirectionOfView directionOfView)
        {
            ValidationUtil.ValidateFeatureSupported(PlayerFeatures.OpenGl);
            ValidationUtil.ValidateFeatureSupported(PlayerFeatures.SphericalVideo);

            Player.ValidateNotDisposed();

            if (directionOfView.Yaw > (float)Math.PI || directionOfView.Yaw < -(float)Math.PI)
            {
                throw new ArgumentOutOfRangeException(nameof(directionOfView.Yaw), directionOfView.Yaw,
                    $"Valid values are in range [-PI, PI] : " + directionOfView.Yaw);
            }

            if (directionOfView.Pitch > (float)Math.PI/2 || directionOfView.Pitch < -(float)Math.PI/2)
            {
                throw new ArgumentOutOfRangeException(nameof(directionOfView.Pitch), directionOfView.Pitch,
                    $"Valid values are in range [-PI/2, PI/2] : " + directionOfView.Pitch);
            }

            NativePlayer.SetDirectionOfView(Player.Handle, (float)directionOfView.Yaw, (float)directionOfView.Pitch).
                ThrowIfFailed(Player, "Failed to set the direction of the view.");
        }

        /// <summary>
        /// Gets the field of view for spherical video.
        /// </summary>
        /// <returns>The <see cref="FieldOfView"/> containing the degree information to display.</returns>
        /// <feature>http://tizen.org/feature/opengles.version.2_0</feature>
        /// <feature>http://tizen.org/feature/multimedia.player.spherical_video</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="ObjectDisposedException">
        /// The <see cref="Multimedia.Player"/> that this instance belongs to has been disposed of.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// The <see cref="Multimedia.Player"/> that this instance belongs to is not in the valid state.
        /// </exception>
        /// <since_tizen> 5 </since_tizen>
        public FieldOfView GetFieldOfView()
        {
            ValidationUtil.ValidateFeatureSupported(PlayerFeatures.OpenGl);
            ValidationUtil.ValidateFeatureSupported(PlayerFeatures.SphericalVideo);

            Player.ValidateNotDisposed();

            NativePlayer.GetFieldOfView(Player.Handle, out var horizontalDegrees, out var verticalDegrees).
                ThrowIfFailed(Player, "Failed to get the field of view");

            return new FieldOfView(horizontalDegrees, verticalDegrees);
        }

        /// <summary>
        /// Sets the field of view for spherical video.
        /// </summary>
        /// <param name="fieldOfView">The degree values to display.</param>
        /// <feature>http://tizen.org/feature/opengles.version.2_0</feature>
        /// <feature>http://tizen.org/feature/multimedia.player.spherical_video</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="ObjectDisposedException">
        /// The <see cref="Multimedia.Player"/> that this instance belongs to has been disposed of.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// The <see cref="Multimedia.Player"/> that this instance belongs to is not in the valid state.
        /// </exception>
        /// <seealso cref="FieldOfView"/>
        /// <since_tizen> 5 </since_tizen>
        public void SetFieldOfView(FieldOfView fieldOfView)
        {
            ValidationUtil.ValidateFeatureSupported(PlayerFeatures.OpenGl);
            ValidationUtil.ValidateFeatureSupported(PlayerFeatures.SphericalVideo);

            Player.ValidateNotDisposed();

            if (fieldOfView.HorizontalDegrees < 1 || fieldOfView.HorizontalDegrees > 360)
            {
                throw new ArgumentOutOfRangeException(nameof(fieldOfView.HorizontalDegrees), fieldOfView.HorizontalDegrees,
                    $"Valid range is 1-360 degrees. : " + fieldOfView.HorizontalDegrees);
            }

            if (fieldOfView.VerticalDegrees < 1 || fieldOfView.VerticalDegrees > 180)
            {
                throw new ArgumentOutOfRangeException(nameof(fieldOfView.VerticalDegrees), fieldOfView.VerticalDegrees,
                    $"Valid range is 1-180 degrees. : " + fieldOfView.VerticalDegrees);
            }

            NativePlayer.SetFieldOfView(Player.Handle, fieldOfView.HorizontalDegrees, fieldOfView.VerticalDegrees).
                ThrowIfFailed(Player, "Failed to set the field of the view.");
        }
    }
}
