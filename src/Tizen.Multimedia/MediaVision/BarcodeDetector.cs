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
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using static Interop.MediaVision;

namespace Tizen.Multimedia
{
    /// <summary>
    /// This class contains the Media Vision barcode detect API.\n
    /// These APIs can be used for detecting barcodes on image sources, reading encoded messages, getting barcode types.
    /// </summary>
    public static class BarcodeDetector
    {
        /// <summary>
        /// Detects barcode(s) on source and reads message from it.
        /// </summary>
        /// <param name="source">The media vision source object</param>
        /// <param name="config">The configuration of the barcode detector engine </param>
        /// <param name="roi">Region of interest - rectangular area on the source which will be used for barcode detection Note that roi should be inside area on the source.</param>
        /// <returns>Returns list of barcode detected asynchronously</returns>
        /// <code>
        ///
        /// </code>
        public static async Task<List<Barcode>> DetectAsync(MediaVisionSource source, BarcodeDetectorEngineConfiguration config, Rectangle roi)
        {
            TaskCompletionSource<List<Barcode>> tcsBarcodeList = new TaskCompletionSource<List<Barcode>>();
            Interop.MediaVision.Rectangle rectangle = new Interop.MediaVision.Rectangle()
            {
                x = roi.Point.X,
                y = roi.Point.Y,
                width = roi.Width,
                height = roi.Height
            };

            // Define native callback
            Interop.MediaVision.BarCodeDetector.MvBarcodeDetectedCallback detectedCb = (IntPtr mvSource, IntPtr engineCfg, IntPtr barcodeLocations, IntPtr messages, IntPtr types, int numberOfBarcodes, IntPtr userData) =>
            {
                try
                {
                    Log.Info(MediaVisionLog.Tag, String.Format("Barcodes detected, count : {0}", numberOfBarcodes));
                    List<Barcode> barcodes = new List<Barcode>();
                    if (numberOfBarcodes > 0)
                    {
                        IntPtr[] msgPtr = new IntPtr[numberOfBarcodes];
                        Marshal.Copy(messages, msgPtr, 0, numberOfBarcodes);

                        // Prepare list of barcodes
                        for (int i = 0; i < numberOfBarcodes; i++)
                        {
                            Interop.MediaVision.Quadrangle location = (Interop.MediaVision.Quadrangle)Marshal.PtrToStructure(barcodeLocations, typeof(Interop.MediaVision.Quadrangle));
                            string message = Marshal.PtrToStringAnsi(msgPtr[i]);
                            BarcodeType type = (BarcodeType)Marshal.ReadInt32(types);
                            Quadrangle quadrangle = new Quadrangle()
                            {
                                Points = new Point[4]
                                {
                                    new Point(location.x1, location.y1),
                                    new Point(location.x2, location.y2),
                                    new Point(location.x3, location.y3),
                                    new Point(location.x4, location.y4)
                                }
                            };
                            Log.Info(MediaVisionLog.Tag, String.Format("Location : {0}, Message : {1}, Type : {2}", quadrangle.ToString(), message, type));
                            Barcode barcode = new Barcode()
                            {
                                Location = quadrangle,
                                Message = message,
                                Type = type
                            };
                            barcodes.Add(barcode);
                            barcodeLocations = IntPtr.Add(barcodeLocations, sizeof(int) * 8);
                            types = IntPtr.Add(barcodeLocations, sizeof(BarcodeType));
                        }
                    }

                    if (!tcsBarcodeList.TrySetResult(barcodes))
                    {
                        Log.Info(MediaVisionLog.Tag, "Failed to set result");
                        tcsBarcodeList.TrySetException(new InvalidOperationException("Failed to set result"));
                    }
                }
                catch (Exception ex)
                {
                    Log.Info(MediaVisionLog.Tag, "exception :" + ex.ToString());
                    tcsBarcodeList.TrySetException(ex);
                }
            };
            int ret = Interop.MediaVision.BarCodeDetector.Detect(source._sourceHandle, config._engineHandle, rectangle, detectedCb, IntPtr.Zero);
            MediaVisionErrorFactory.CheckAndThrowException(ret, "Failed to detect barcode.");
            return await tcsBarcodeList.Task;
        }
    }
}
