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

namespace Tizen.Multimedia
{
    /// <summary>
    /// This class represents concrete EngineConfig for BarcodeGenerator
    /// </summary>
    public class BarcodeGeneratorEngineConfiguration : EngineConfiguration
    {
        private const string _textAttributeKey = "MV_BARCODE_GENERATE_ATTR_TEXT";
        private const string _frontColorAttributeKey = "MV_BARCODE_GENERATE_ATTR_COLOR_FRONT";
        private const string _backColorAttributeKey = "MV_BARCODE_GENERATE_ATTR_COLOR_BACK";
        private TextAttribute _textAttr = TextAttribute.Invisible;
        private string _frontColor = "000000";
        private string _backColor = "ffffff";

        /// <summary>
        /// The default constructor of BarcodeGeneratorEngineConfig class
        /// </summary>
        /// <code>
        /// 
        /// </code>
        public BarcodeGeneratorEngineConfiguration()
            : base()
        {
            TextAttribute = _textAttr;
            FrontColor = _frontColor;
            BackColor = _backColor;
        }

        /// <summary>
        /// Sets and gets text attribute of the engine configuration
        /// </summary>
        public TextAttribute TextAttribute
        {
            get
            {
                return _textAttr;
            }

            set
            {
                if (!IsValid(value))
                {
                    throw new ArgumentException("TextAttribute value is invalid");
                }

                Add<int>(_textAttributeKey, (int)value);
                _textAttr = value;
            }
        }

        /// <summary>
        /// Sets and gets barcode's foreground color attribute of the engine configuration.
        /// </summary>
        /// <remarks>
        /// This attribute represents RGB color as a hex triplet with six digits.
        /// </remarks>
        public string FrontColor
        {
            get
            {
                return _frontColor;
            }

            set
            {
                Add<string>(_frontColorAttributeKey, value);
                _frontColor = value;
            }
        }

        /// <summary>
        /// Sets and gets barcode's background color attribute of the engine configuration.
        /// </summary>
        /// <remarks>
        /// This property represents RGB color as a hex triplet with six digits.
        /// </remarks>
        public string BackColor
        {
            get
            {
                return _backColor;
            }

            set
            {
                Add<string>(_backColorAttributeKey, value);
                _backColor = value;
            }
        }

        private bool IsValid(TextAttribute value)
        {
            if (value == TextAttribute.Unavailable)
            {
                Log.Error(MediaVisionLog.Tag, "Invalid TextAttribute");
                return false;
            }

            return true;
        }
    }
}
