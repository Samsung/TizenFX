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
    internal enum DisplayType
    {
        /// <summary>
        /// Overlay surface display.
        /// </summary>
        Overlay,

        /// <summary>
        ///  Evas image object surface display.
        /// </summary>
        Surface,

        /// <summary>
        /// This disposes off buffers.
        /// </summary>
        None,
    }

    internal interface IDisplayable<TError>
    {
        TError ApplyEvasDisplay(DisplayType type, EvasObject evasObject);
        TError ApplyEcoreWindow(IntPtr windowHandle, Rectangle rect, Rotation rotation);
    }

    internal interface IDisplaySetter
    {
        TError SetDisplay<TError>(IDisplayable<TError> target);
    }

    internal class EvasDisplaySetter : IDisplaySetter
    {
        private readonly DisplayType _type;
        private readonly EvasObject _target;

        internal EvasDisplaySetter(DisplayType type, EvasObject target)
        {
            if (target == IntPtr.Zero)
            {
                throw new ArgumentException("The evas object is not realized.");
            }

            _type = type;
            _target = target;
        }

        public TError SetDisplay<TError>(IDisplayable<TError> target)
        {
            return target.ApplyEvasDisplay(_type, _target);
        }
    }

    internal class EcoreDisplaySetter : IDisplaySetter
    {
        private readonly IntPtr _windowHandle;
        private readonly Rectangle _rect;
        private readonly Rotation _rotation;

        internal EcoreDisplaySetter(IntPtr windowHandle, Rectangle rect, Rotation rotation)
        {
            _windowHandle = windowHandle;
            _rect = rect;
            _rotation = rotation;
        }

        public TError SetDisplay<TError>(IDisplayable<TError> target)
        {
            return target.ApplyEcoreWindow(_windowHandle, _rect, _rotation);
        }
    }

    /// <summary>
    /// Provides a means to wrap various display types.
    /// </summary>
    /// <seealso cref="T:Tizen.Multimedia.Player"/>
    /// <seealso cref="T:Tizen.Multimedia.Camera"/>
    /// <seealso cref="T:Tizen.Multimedia.Remoting.ScreenMirroring"/>
    /// <since_tizen> 3 </since_tizen>
    public class Display
    {
        private readonly IDisplaySetter _setter;

        /// <summary>
        /// Initializes a new instance of the <see cref="Display"/> class with a <see cref="MediaView"/> class.
        /// </summary>
        /// <param name="mediaView">A <see cref="MediaView"/> to display.</param>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated in API10; Will be removed in API12")]
        public Display(MediaView mediaView)
        {
            if (mediaView == null)
            {
                throw new ArgumentNullException(nameof(mediaView));
            }

            _setter = new EvasDisplaySetter(DisplayType.Surface, mediaView);

            HasMediaView = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Display"/> class with a <see cref="Window"/> class.
        /// </summary>
        /// <param name="window">A <see cref="Window"/> to display.</param>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated in API10; Will be removed in API12")]
        public Display(Window window)
        {
            if (window == null)
            {
                throw new ArgumentNullException(nameof(window));
            }

            _setter = new EvasDisplaySetter(DisplayType.Overlay, window);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Display"/> class with a <see cref="NUI.Window"/> class.
        /// </summary>
        /// <param name="window">A <see cref="NUI.Window"/> to display.</param>
        /// <remarks>
        /// The <see cref="NUI.Window.BackgroundColor"/> must be <see cref="NUI.Color.Transparent"/>
        /// for the <see cref="Display"/> to be rendered correctly.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public Display(NUI.Window window)
            : this (window, false)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Display"/> class with a <see cref="NUI.Window"/> class.
        /// </summary>
        /// <param name="window">A <see cref="NUI.Window"/> to display.</param>
        /// <param name="uiSync">A value indicates whether video and UI is in sync or not.</param>
        /// <remarks>
        /// The <see cref="NUI.Window.BackgroundColor"/> must be <see cref="NUI.Color.Transparent"/>
        /// for the <see cref="Display"/> to be rendered correctly.<br/>
        /// UI sync is only for <see cref="T:Tizen.Multimedia.Player"/> and
        /// <see cref="T:Tizen.Multimedia.Player.DisplaySettings"/> will not work in UI sync mode.
        /// </remarks>
        /// <since_tizen> 9 </since_tizen>
        public Display(NUI.Window window, bool uiSync)
        {
            if (window == null)
            {
                throw new ArgumentNullException(nameof(window));
            }

            var windowSize = new Rectangle(window.WindowPositionSize.X, window.WindowPositionSize.Y,
                window.WindowPositionSize.Width, window.WindowPositionSize.Height);

            _setter = new EcoreDisplaySetter(window.GetNativeWindowHandler(), windowSize, window.GetCurrentOrientation().ToMmRotation());

            UiSync = uiSync;
        }

        private EvasObject EvasObject { get; }

        private DisplayType Type { get; }

        private object _owner;

        internal bool HasMediaView { get; } = false;

        internal bool UiSync { get; } = false;

        internal object Owner => _owner;

        internal void SetOwner(object newOwner)
        {
            if (_owner != null && newOwner != null)
            {
                throw new ArgumentException("The display has already been assigned to another.");
            }

            _owner = newOwner;
        }

        internal TError ApplyTo<TError>(IDisplayable<TError> target)
        {
            return _setter.SetDisplay(target);
        }
    }

    internal static class WindowOrientationExtension
    {
        internal static Tizen.Multimedia.Rotation ToMmRotation(this NUI.Window.WindowOrientation rotation)
        {
            switch (rotation)
            {
                case NUI.Window.WindowOrientation.Portrait:
                    return Tizen.Multimedia.Rotation.Rotate0;
                case NUI.Window.WindowOrientation.Landscape:
                    return Tizen.Multimedia.Rotation.Rotate90;
                case NUI.Window.WindowOrientation.PortraitInverse:
                    return Tizen.Multimedia.Rotation.Rotate180;
                case NUI.Window.WindowOrientation.LandscapeInverse:
                    return Tizen.Multimedia.Rotation.Rotate270;
                default:
                    break;
            }

            return Tizen.Multimedia.Rotation.Rotate90;
        }
    }
}
