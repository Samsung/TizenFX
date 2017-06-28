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
        /// Overlay surface display
        /// </summary>
        Overlay,

        /// <summary>
        ///  Evas image object surface display
        /// </summary>
        Surface,

        /// <summary>
        /// This disposes off buffers
        /// </summary>
        None,
    }

    internal interface IDisplayable<ErrorType>
    {
        ErrorType ApplyEvasDisplay(DisplayType type, EvasObject evasObject);
    }

    /// <summary>
    /// Provides means to wrap various display types.
    /// </summary>
    /// <seealso cref="Player"/>
    /// <seealso cref="Camera"/>
    /// <seealso cref="ScreenMirroring"/>
    public class Display
    {
        private Display(DisplayType type, EvasObject target)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            if (target == IntPtr.Zero)
            {
                throw new ArgumentException("The evas object is not realized.");
            }

            Type = type;
            EvasObject = target;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Display"/> class with a <see cref="MediaView"/> class.
        /// </summary>
        /// <feature>http://tizen.org/feature/multimedia.raw_video</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        public Display(MediaView mediaView) : this(DisplayType.Surface, mediaView)
        {
            ValidationUtil.ValidateFeatureSupported(Features.RawVideo);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Display"/> class with a <see cref="Window"/> class.
        /// </summary>
        public Display(Window window) : this(DisplayType.Overlay, window)
        {
        }

        private EvasObject EvasObject { get; }

        private DisplayType Type { get; }

        private object _owner;

        internal object Owner => _owner;

        internal void SetOwner(object newOwner)
        {
            if (_owner != null && newOwner != null)
            {
                throw new ArgumentException("The display has already been assigned to another.");
            }

            _owner = newOwner;
        }

        internal ErrorType ApplyTo<ErrorType>(IDisplayable<ErrorType> target)
        {
            return target.ApplyEvasDisplay(Type, EvasObject);
        }
    }
}
