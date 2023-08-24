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

namespace Tizen.Multimedia.Vision
{
    /// <summary>
    /// Specifies the supported barcode types.
    /// </summary>
    /// <remarks>
    /// QR codes (versions 1 to 40) and set of 1D barcodes are supported.
    /// </remarks>
    /// <seealso cref="BarcodeDetector"/>
    /// <seealso cref="BarcodeGenerator"/>
    /// <since_tizen> 4 </since_tizen>
    public enum BarcodeType
    {
        /// <summary>
        /// 2D barcode - Quick Response code.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        QR,
        /// <summary>
        /// 1D barcode - Universal Product Code with 12-digit.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        UpcA,
        /// <summary>
        /// 1D barcode - Universal Product Code with 6-digit.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        UpcE,
        /// <summary>
        /// 1D barcode - International Article Number with 8-digit.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Ean8,
        /// <summary>
        /// 1D barcode - International Article Number with 13-digit.
        /// </summary>
        /// <since_tizen> 3</since_tizen>
        Ean13,
        /// <summary>
        /// 1D barcode - Code 128.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Code128,
        /// <summary>
        /// 1D barcode - Code 39.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Code39,
        /// <summary>
        /// 1D barcode - Interleaved Two of Five.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        I25,
        /// <summary>
        /// 1D barcode - International Article Number with 2-digit.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        Ean2 = 9,
        /// <summary>
        /// 1D barcode - International Article Number with 5-digit.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        Ean5,
        /// <summary>
        /// 1D barcode - Code 93.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        Code93,
        /// <summary>
        /// 1D barcode - Codabar
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        Codabar,
        /// <summary>
        /// 1D barcode - Databar
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        Databar,
        /// <summary>
        /// 1D barcode - Databar expand
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        DataBarExpand
    }
}
