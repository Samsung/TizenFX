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
    /// Enumeration for supported barcode types.
    /// </summary>
    /// <remarks>
    /// QR codes (versions 1 to 40) and set of 1D barcodes are supported
    /// </remarks>
    public enum BarcodeType
    {
        /// <summary>
        /// 2D barcode - Quick Response code
        /// </summary>
        QR,
        /// <summary>
        /// 1D barcode - Universal Product Code with 12-digit
        /// </summary>
        UPC_A,
        /// <summary>
        /// 1D barcode - Universal Product Code with 6-digit
        /// </summary>
        UPC_E,
        /// <summary>
        /// 1D barcode - International Article Number with 8-digit
        /// </summary>
        EAN_8,
        /// <summary>
        /// 1D barcode - International Article Number with 13-digit
        /// </summary>
        EAN_13,
        /// <summary>
        /// 1D barcode - Code 128
        /// </summary>
        CODE128,
        /// <summary>
        /// 1D barcode - Code 39
        /// </summary>
        CODE39,
        /// <summary>
        /// 1D barcode - Interleaved Two of Five
        /// </summary>
        I2_5,
        /// <summary>
        /// Undefined
        /// </summary>
        Undefined
    }
}
