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
    /// This class represents concrete EngineConfig for BarcodeDetector
    /// </summary>
    public class BarcodeDetectorEngineConfiguration : EngineConfiguration
    {
        private const string _targetAttributeKey = "MV_BARCODE_DETECT_ATTR_TARGET";
        private TargetAttribute _targetAttr = TargetAttribute.All;

        /// <summary>
        /// The default constructor of BarcodeDetectorEngineConfig class
        /// </summary>
        /// <code>
        /// 
        /// </code>
        public BarcodeDetectorEngineConfiguration()
            : base()
        {
        }

        /// <summary>
        /// Sets and gets target attribute of the engine configuration
        /// </summary>
        public TargetAttribute TargetAttribute
        {
            get
            {
                return _targetAttr;
            }

            set
            {
                if (!IsValid(value))
                {
                    throw new ArgumentException("TargetAttribute value is invalid");
                }

                Add<int>(_targetAttributeKey, (int)value);
                _targetAttr = value;
            }
        }

        private bool IsValid(TargetAttribute value)
        {
            if (value == TargetAttribute.Unavailable)
            {
                Log.Error(MediaVisionLog.Tag, "Invalid TargetAttribute");
                return false;
            }

            return true;
        }
    }
}
