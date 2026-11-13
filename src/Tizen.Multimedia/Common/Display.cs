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
using Tizen.Common;

namespace Tizen.Multimedia
{
    internal enum DisplayType
    {
        // /// <summary>
        // /// Overlay surface display.
        // /// </summary>
        // Overlay,

        // /// <summary>
        // ///  Evas image object surface display.
        // /// </summary>
        // Surface,

        /// <summary>
        /// This disposes off buffers.
        /// </summary>
        None = 2,

        /// <summary>
        /// TCore overlay surface display.
        /// </summary>
        Overlay2 = 3,
    }

    internal interface IDisplayable<TError>
    {
        TError ApplyTcoreWindow(IntPtr windowHandle);
    }

    internal sealed class TcoreDisplaySetter : IDisplaySetter
    {
        private readonly IntPtr _windowHandle;

        internal TcoreDisplaySetter(IntPtr windowHandle) => _windowHandle = windowHandle;

        public TError SetDisplay<TError>(IDisplayable<TError> target)
        {
            return target.ApplyTcoreWindow(_windowHandle);
        }
    }

    internal interface IDisplaySetter
    {
        TError SetDisplay<TError>(IDisplayable<TError> target);
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

            _setter = new TcoreDisplaySetter(((IWindowProvider)window).WindowHandle);

            UiSync = uiSync;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Display"/> class with an <see cref="Tizen.Common.IWindowProvider"/> interface.
        /// </summary>
        /// <param name="window">An <see cref="Tizen.Common.IWindowProvider"/> object whose WindowHandle provides a TCORE window handle.</param>
        /// <since_tizen> 12 </since_tizen>
        public Display(IWindowProvider window)
            : this(window, false)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Display"/> class with an <see cref="Tizen.Common.IWindowProvider"/> interface.
        /// </summary>
        /// <param name="window">An <see cref="Tizen.Common.IWindowProvider"/> object whose WindowHandle provides a TCORE window handle.</param>
        /// <param name="uiSync">A value indicating whether video and UI are in sync or not.</param>
        /// <remarks>
        /// UI sync is only for <see cref="T:Tizen.Multimedia.Player"/> and
        /// <see cref="T:Tizen.Multimedia.Player.DisplaySettings"/> will not work in UI sync mode.
        /// </remarks>
        /// <since_tizen> 12 </since_tizen>
        public Display(IWindowProvider window, bool uiSync)
        {
            if (window == null)
            {
                throw new ArgumentNullException(nameof(window));
            }

            _setter = new TcoreDisplaySetter(window.WindowHandle);

            UiSync = uiSync;
        }

        private DisplayType Type { get; }

        private object _owner;

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
}
