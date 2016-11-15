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
using ElmSharp;

namespace Tizen.Multimedia
{
    //TODO reimplementation needed
    /// <summary>
    /// Provides means to configure display settings for video <see cref="Player"/>.
    /// </summary>
    public class PlayerDisplay
    {
        private readonly EvasObject _evasObject;

        private PlayerDisplay(PlayerDisplayType type, EvasObject evasObject)
        {
            if (evasObject == null)
            {
                throw new ArgumentNullException(nameof(evasObject));
            }

            if (evasObject == IntPtr.Zero)
            {
                throw new ArgumentException("The evas object is not realized.");
            }

            Type = type;
            _evasObject = evasObject;
        }

        public PlayerDisplay(Window window) : this(PlayerDisplayType.Overlay, window)
        {
        }

        public PlayerDisplay(ElmSharp.Image image) : this(PlayerDisplayType.Surface, image)
        {
        }

        public EvasObject EvasObject
        {
            get
            {
                return _evasObject;
            }
        }

        internal PlayerDisplayType Type { get; }

        /// <summary>
        /// Gets the player that the display is assigned to.
        /// </summary>
        public Player Player
        {
            get;
            internal set;
        }

        private void ValidatePlayer()
        {
            if (Player == null)
            {
                throw new InvalidOperationException("The display is not assigned, yet.");
            }

            Player.ValidateNotDisposed();
        }

        private PlayerDisplayMode _displayMode = PlayerDisplayMode.LetterBox;

        /// <summary>
        /// Set/Get Display mode.
        /// </summary>
        /// <value> LetterBox, OriginalSize, FullScreen, CroppedFull, OriginalOrFull, DstRoi </value>
        /// <exception cref="InvalidOperationException">
        /// The display is not assigned.
        /// <para>-or-</para>
        /// Operation failed; internal error.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The player already has been disposed of.</exception>
        /// <exception cref="ArgumentException">The specified value to set is invalid.</exception>
        public PlayerDisplayMode Mode
        {
            get
            {
                return _displayMode;
            }
            set
            {
                ValidatePlayer();

                if (_displayMode == value)
                {
                    return;
                }

                ValidationUtil.ValidateEnum(typeof(PlayerDisplayMode), value);

                int ret = Interop.Player.SetDisplayMode(Player.GetHandle(), (int)value);
                PlayerErrorConverter.ThrowIfError(ret, "Failed to set display mode");

                _displayMode = value;
            }
        }

        private bool _isVisible = true;

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        /// <exception cref="InvalidOperationException">
        /// The display is not assigned.
        /// <para>-or-</para>
        /// Operation failed; internal error.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The player already has been disposed of.</exception>
        public bool IsVisible
        {
            get
            {
                return _isVisible;
            }
            set
            {
                ValidatePlayer();

                if (_isVisible == value)
                {
                    return;
                }

                int ret = Interop.Player.SetDisplayVisible(Player.GetHandle(), value);
                PlayerErrorConverter.ThrowIfError(ret, "Failed to set the visible state of the display");

                _isVisible = value;
            }
        }

        private PlayerDisplayRotation _rotation = PlayerDisplayRotation.RotationNone;

        /// <summary>
        /// Set/Get Display rotation.
        /// </summary>
        /// <value> RotationNone, Rotation90, Rotation180, Rotation270 </value>
        /// <exception cref="InvalidOperationException">
        /// The display is not assigned.
        /// <para>-or-</para>
        /// Operation failed; internal error.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The player already has been disposed of.</exception>
        /// <exception cref="ArgumentException">The specified value to set is invalid.</exception>
        public PlayerDisplayRotation Rotation
        {
            get
            {
                return _rotation;
            }
            set
            {
                ValidatePlayer();

                if (_rotation == value)
                {
                    return;
                }

                ValidationUtil.ValidateEnum(typeof(PlayerDisplayRotation), value);

                int ret = Interop.Player.SetDisplayRotation(Player.GetHandle(), (int)value);
                PlayerErrorConverter.ThrowIfError(ret, "Failed to set the rotation state of the display");

                _rotation = value;
            }
        }
    }
}
