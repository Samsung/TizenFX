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
using System.Collections.Generic;
using System.Threading.Tasks;
using InteropBarcode = Interop.MediaVision.BarcodeDetector;
using Unmanaged = Interop.MediaVision;

namespace Tizen.Multimedia
{
    /// <summary>
    /// Provides the ability to detect barcodes on image sources.
    /// </summary>
    public static class BarcodeDetector
    {
        /// <summary>
        /// Detects barcodes on source and reads message from it.
        /// </summary>
        /// <param name="source">The <see cref="MediaVisionSource"/> instance.</param>
        /// <param name="roi">Region of interest - rectangular area on the source which will be used for
        ///     barcode detection. Note that roi should be inside area on the source.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        /// <exception cref="NotSupportedException">The feature is not supported.</exception>
        /// <exception cref="ObjectDisposedException"><paramref name="source"/> already has been disposed of.</exception>
        /// <returns>A task that represents the asynchronous detect operation.</returns>
        /// <seealso cref="Barcode"/>
        public static async Task<IEnumerable<Barcode>> DetectAsync(MediaVisionSource source,
            Rectangle roi)
        {
            return await DetectAsync(source, roi, null);
        }

        /// <summary>
        /// Detects barcodes on source and reads message from it with <see cref="BarcodeDetectionConfiguration"/>.
        /// </summary>
        /// <param name="source">The <see cref="MediaVisionSource"/> instance.</param>
        /// <param name="roi">Region of interest - rectangular area on the source which will be used for
        ///     barcode detection. Note that roi should be inside area on the source.</param>
        /// <param name="config">The configuration of the barcode detector. This value can be null.</param>
        /// <returns>A task that represents the asynchronous detect operation.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        /// <exception cref="NotSupportedException">The feature is not supported.</exception>
        /// <exception cref="ObjectDisposedException">
        ///     <paramref name="source"/> already has been disposed of.\n
        ///     -or-\n
        ///     <paramref name="config"/> already has been disposed of.
        /// </exception>
        /// <seealso cref="Barcode"/>
        public static async Task<IEnumerable<Barcode>> DetectAsync(MediaVisionSource source,
            Rectangle roi, BarcodeDetectionConfiguration config)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var tcs = new TaskCompletionSource<IEnumerable<Barcode>>();

            using (var cb = ObjectKeeper.Get(GetCallback(tcs)))
            {
                InteropBarcode.Detect(source.Handle, EngineConfiguration.GetHandle(config),
                    roi.ToMarshalable(), cb.Target).Validate("Failed to detect barcode.");

                return await tcs.Task;
            }
        }

        private static Barcode[] CreateBarcodes(Unmanaged.Quadrangle[] locations, string[] messages,
            BarcodeType[] types, int numberOfBarcodes)
        {
            Barcode[] barcodes = new Barcode[numberOfBarcodes];

            for (int i = 0; i < numberOfBarcodes; i++)
            {
                barcodes[i] = new Barcode(locations[i].ToApiStruct(), messages[i], types[i]);

                Log.Info(MediaVisionLog.Tag, barcodes[i].ToString());
            }

            return barcodes;
        }

        private static InteropBarcode.DetectedCallback GetCallback(TaskCompletionSource<IEnumerable<Barcode>> tcs)
        {
            return (IntPtr mvSource, IntPtr engineCfg, Unmanaged.Quadrangle[] locations, string[] messages,
                BarcodeType[] types, int numberOfBarcodes, IntPtr userData) =>
            {
                Log.Info(MediaVisionLog.Tag, $"Barcodes detected, count : {numberOfBarcodes}");

                try
                {
                    tcs.TrySetResult(CreateBarcodes(locations, messages, types, numberOfBarcodes));
                }
                catch (Exception e)
                {
                    MultimediaLog.Error(MediaVisionLog.Tag, "Failed to handle barcode detection callback", e);
                    tcs.TrySetException(e);
                }
            };
        }
    }
}
