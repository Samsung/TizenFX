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

namespace Tizen.Multimedia
{
    /// <summary>
    /// Represents a detected barcode.
    /// </summary>
    /// <since_tizen> 3</since_tizen>
    public class Barcode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Barcode"/> class.
        /// </summary>
        /// <since_tizen> 3</since_tizen>
        public Barcode(Quadrangle region, string message, BarcodeType type)
        {
            Region = region;
            Message = message;
            Type = type;
        }

        /// <summary>
        /// The quadrangle location of detected barcode.
        /// </summary>
        /// <since_tizen> 3</since_tizen>
        public Quadrangle Region { get; }

        /// <summary>
        /// The decoded message of barcode.
        /// </summary>
        /// <since_tizen> 3</since_tizen>
        public string Message { get; }

        /// <summary>
        /// The type of detected barcode.
        /// </summary>
        /// <since_tizen> 3</since_tizen>
        public BarcodeType Type { get; }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <value>A string that represents the current object.</value>
        public override string ToString() =>
            $"Region={Region}, Message={Message}, Type={Type.ToString()}";
    }
}
