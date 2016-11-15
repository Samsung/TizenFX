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
    /// This class represents an interface for image recognition functionality.
    /// </summary>
    public static class ImageRecognizer
    {
        /// <summary>
        /// Recognizes the given image objects on the source image.\n
        /// Use this function to launch image recognition algorithm configured by @a config configuration.
        /// </summary>
        /// <param name="source">The source image on which image objects will be recognized</param>
        /// <param name="imageObjects">The array of image objects which will be processed as targets of recognition</param>
        /// <param name="config">The configuration of engine which will be used for recognition. If NULL, then default settings will be used.</param>
        /// <returns>Returns ImageRecognitionResult asynchronously</returns>
        public static async Task<ImageRecognitionResult> RecognizeAsync(MediaVisionSource source, Image[] imageObjects, ImageEngineConfiguration config = null)
        {
            if (source == null || imageObjects.Length == 0)
            {
                throw new ArgumentException("Invalid parameter");
            }

            IntPtr[] ptrArray = new IntPtr[imageObjects.Length];
            for (int i = 0; i < imageObjects.Length; i++)
            {
                if (imageObjects[i] == null)
                {
                    throw new ArgumentException("Invalid parameter");
                }

                ptrArray[i] = imageObjects[i]._imageObjectHandle;
            }

            int size = Marshal.SizeOf(typeof(IntPtr)) * ptrArray.Length;
            IntPtr imageObjectsPtr = Marshal.AllocHGlobal(size);

            Marshal.Copy(ptrArray, 0, imageObjectsPtr, ptrArray.Length);

            TaskCompletionSource<ImageRecognitionResult> tcsResult = new TaskCompletionSource<ImageRecognitionResult>();

            // Define native callback
            Interop.MediaVision.Image.MvImageRecognizedCallback imageRecognizedCb = (IntPtr sourceHandle, IntPtr engineCfgHandle, IntPtr imageObjectsHandle, IntPtr locationsPtr, uint numberOfObjects, IntPtr userData) =>
            {
                try
                {
                    List<Tuple<int, Quadrangle>> recognitionResults = new List<Tuple<int, Quadrangle>>();
                    if (numberOfObjects > 0)
                    {
                        IntPtr[] imageLocationsPtr = new IntPtr[numberOfObjects];
                        Marshal.Copy(locationsPtr, imageLocationsPtr, 0, (int)numberOfObjects);

                        // Prepare list of locations and its indexes
                        for (int i = 0; i < numberOfObjects; i++)
                        {
                            if (imageLocationsPtr[i] == null)
                            {
                                continue;
                            }

                            Interop.MediaVision.Quadrangle location = (Interop.MediaVision.Quadrangle)Marshal.PtrToStructure(imageLocationsPtr[i], typeof(Interop.MediaVision.Quadrangle));
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
                            Log.Info(MediaVisionLog.Tag, String.Format("Image recognized, Location : {0}", quadrangle.ToString()));
                            recognitionResults.Add(Tuple.Create(i, quadrangle));
                        }
                    }

                    ImageRecognitionResult result = new ImageRecognitionResult()
                    {
                        Results = recognitionResults
                    };

                    if (!tcsResult.TrySetResult(result))
                    {
                        Log.Info(MediaVisionLog.Tag, "Failed to set result");
                        tcsResult.TrySetException(new InvalidOperationException("Failed to set result"));
                    }
                }
                catch (Exception ex)
                {
                    Log.Info(MediaVisionLog.Tag, "exception :" + ex.ToString());
                    tcsResult.TrySetException(ex);
                }
            };

            int ret = Interop.MediaVision.Image.Recognize(source._sourceHandle, imageObjectsPtr, ptrArray.Length, (config != null) ? config._engineHandle : IntPtr.Zero, imageRecognizedCb, IntPtr.Zero);
            MediaVisionErrorFactory.CheckAndThrowException(ret, "Failed to perform image recognition.");

            return await tcsResult.Task;
        }
    }
}
