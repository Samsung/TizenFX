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

using Tizen.Common;

namespace Tizen.Multimedia
{
    /// <summary>
    /// Represents a configuration of <see cref="BarcodeGenerator"/> instances.
    /// </summary>
    /// <seealso cref="BarcodeGenerator"/>
    public class BarcodeGenerationConfiguration : EngineConfiguration
    {
        private const string KeyTextAttr = "MV_BARCODE_GENERATE_ATTR_TEXT";
        private const string KeyForegroundColorAttr = "MV_BARCODE_GENERATE_ATTR_COLOR_FRONT";
        private const string KeyBackgroundColorAttr = "MV_BARCODE_GENERATE_ATTR_COLOR_BACK";

        /// <summary>
        /// Initializes a new instance of the <see cref="BarcodeGenerationConfiguration"/> class.
        /// </summary>
        /// <exception cref="System.NotSupportedException">The feature is not supported.</exception>
        public BarcodeGenerationConfiguration() : base("barcode_generation")
        {
        }

        /// <summary>
        /// Gets or sets the text visibility of the barcode to be generated.
        /// </summary>
        /// <exception cref="System.ArgumentException"><paramref name="value"/> is not valid.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="BarcodeGenerationConfiguration"/> already has been disposed of.</exception>
        public Visibility TextVisibility
        {
            get
            {
                return (Visibility)GetInt(KeyTextAttr);
            }
            set
            {
                ValidationUtil.ValidateEnum(typeof(Visibility), value);
                Set(KeyTextAttr, (int)value);
            }
        }

        private Color _foregroundColor = Color.Black;

        /// <summary>
        /// Sets or gets the foreground color of the barcode to be generated.
        /// </summary>
        /// <remarks>
        /// The alpha value of the color will be ignored.
        /// </remarks>
        /// <exception cref="ObjectDisposedException">The <see cref="BarcodeGenerationConfiguration"/> already has been disposed of.</exception>
        public Color ForegroundColor
        {
            get
            {
                return _foregroundColor;
            }
            set
            {
                Set(KeyForegroundColorAttr, string.Format("{0:x2}{1:x2}{2:x2}", value.R, value.G, value.B));
                _foregroundColor = value;
            }
        }

        private Color _backgroundColor = Color.White;

        /// <summary>
        /// Sets or gets the background color of the barcode to be generated.
        /// </summary>
        /// <remarks>
        /// The alpha value of the color will be ignored.
        /// </remarks>
        /// <exception cref="ObjectDisposedException">The <see cref="BarcodeGenerationConfiguration"/> already has been disposed of.</exception>
        public Color BackgroundColor
        {
            get
            {
                return _backgroundColor;
            }
            set
            {
                Set(KeyBackgroundColorAttr, string.Format("{0:x2}{1:x2}{2:x2}", value.R, value.G, value.B));
                _backgroundColor = value;
            }
        }
    }
}
