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
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using static Interop.MediaVision;

namespace Tizen.Multimedia
{
    /// <summary>
    /// This class represents an interface for Face recognition functionalities.
    /// It also contains APIs which perform facial expression recognition and eye condition recognition.
    /// </summary>
    public static class FaceRecognizer
    {
        /// <summary>
        /// Performs face recognition on the source image synchronously.
        /// </summary>
        /// <param name="source">The source of the media to recognize face(s) for</param>
        /// <param name="recognitionModel">The model to be used for recognition</param>
        /// <param name="config">The configuration of engine will be used for recognition. If NULL, then default settings will be used</param>
        /// <param name="location">Rectangular box bounding face image on the source. If NULL, then full source will be analyzed</param>
        /// <returns>Returns the FaceRecognitionResult asynchronously</returns>
        /// <code>
        /// 
        /// </code>
        public static async Task<FaceRecognitionResult> RecognizeAsync(MediaVisionSource source, FaceRecognitionModel recognitionModel, FaceEngineConfiguration config = null, Rectangle location = null)
        {
            if (source == null || recognitionModel == null)
            {
                throw new ArgumentException("Invalid parameter");
            }

            IntPtr locationPtr = IntPtr.Zero;
            if (location != null)
            {
                Interop.MediaVision.Rectangle rectangle = new Interop.MediaVision.Rectangle()
                {
                    width = location.Width,
                    height = location.Height,
                    x = location.Point.X,
                    y = location.Point.Y
                };
                locationPtr = Marshal.AllocHGlobal(Marshal.SizeOf(rectangle));
                Marshal.StructureToPtr(rectangle, locationPtr, false);
            }

            TaskCompletionSource<FaceRecognitionResult> tcsResult = new TaskCompletionSource<FaceRecognitionResult>();

            // Define native callback
            Interop.MediaVision.Face.MvFaceRecognizedCallback faceRecognizedCb = (IntPtr sourceHandle, IntPtr recognitionModelHandle, IntPtr engineCfgHandle, IntPtr faceLocationPtr, IntPtr faceLabelPtr, double confidence, IntPtr userData) =>
            {
                try
                {
                    int faceLabel = 0;
                    if (faceLabelPtr != IntPtr.Zero)
                    {
                        faceLabel = Marshal.ReadInt32(faceLabelPtr);
                    }

                    Rectangle faceLocation = null;
                    if (faceLocationPtr != IntPtr.Zero)
                    {
                        Interop.MediaVision.Rectangle loc = (Interop.MediaVision.Rectangle)Marshal.PtrToStructure(faceLocationPtr, typeof(Interop.MediaVision.Rectangle));
                        faceLocation = new Rectangle()
                        {
                            Width = loc.width,
                            Height = loc.height,
                            Point = new Point(loc.x, loc.y)
                        };
                        Log.Info(MediaVisionLog.Tag, String.Format("Face label {0} recognized at : ({1}, {2}), Width : {3}, Height : {4}, confidence : {5}", faceLabel, faceLocation.Point.X, faceLocation.Point.Y, faceLocation.Width, faceLocation.Height, confidence));
                    }

                    FaceRecognitionResult result = new FaceRecognitionResult()
                    {
                        Location = faceLocation,
                        Label = faceLabel,
                        Confidence = confidence
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


            int ret = Interop.MediaVision.Face.Recognize(source._sourceHandle, recognitionModel._recognitionModelHandle,
                            (config != null) ? config._engineHandle : IntPtr.Zero, locationPtr, faceRecognizedCb, IntPtr.Zero);
            MediaVisionErrorFactory.CheckAndThrowException(ret, "Failed to perform face recognition.");

            return await tcsResult.Task;
        }

        /// <summary>
        /// Determines eye-blink condition for @a location on media source.
        /// </summary>
        /// <param name="source">The source of the media to recognize eye-blink condition for</param>
        /// <param name="location">The location bounding the face at the source</param>
        /// <param name="config">The configuration of engine will be used for eye-blink condition recognition. If NULL, the default configuration will be used</param>
        /// <returns>Returns the EyeCondition asynchronously</returns>
        public static async Task<EyeCondition> RecognizeEyeConditionAsync(MediaVisionSource source, Rectangle location, FaceEngineConfiguration config = null)
        {
            if (source == null || location == null)
            {
                throw new ArgumentException("Invalid parameter");
            }

            Interop.MediaVision.Rectangle rectangle = new Interop.MediaVision.Rectangle()
            {
                width = location.Width,
                height = location.Height,
                x = location.Point.X,
                y = location.Point.Y
            };

            TaskCompletionSource<EyeCondition> tcsResult = new TaskCompletionSource<EyeCondition>();

            // Define native callback
            Interop.MediaVision.Face.MvFaceEyeConditionRecognizedCallback eyeConditionRecognizedCb = (IntPtr sourceHandle, IntPtr engineCfgHandle, Interop.MediaVision.Rectangle faceLocation, EyeCondition eyeCondition, IntPtr userData) =>
            {
                Log.Info(MediaVisionLog.Tag, String.Format("Eye condition recognized, eye condition : {0}", eyeCondition));
                if (!tcsResult.TrySetResult(eyeCondition))
                {
                    Log.Info(MediaVisionLog.Tag, "Failed to set result");
                    tcsResult.TrySetException(new InvalidOperationException("Failed to set result"));
                }
            };

            int ret = Interop.MediaVision.Face.RecognizeEyeCondition(source._sourceHandle, (config != null) ? config._engineHandle : IntPtr.Zero,
                             rectangle, eyeConditionRecognizedCb, IntPtr.Zero);
            MediaVisionErrorFactory.CheckAndThrowException(ret, "Failed to perform eye condition recognition.");

            return await tcsResult.Task;
        }

        /// <summary>
        /// Determines facial expression for @a location on media source.
        /// </summary>
        /// <param name="source">The source of the media to recognize facial expression for</param>
        /// <param name="location">The location bounding the face at the source</param>
        /// <param name="config">The configuration of engine to be used for expression recognition</param>
        /// <returns>Returns the FacialExpression asynchronously</returns>
        public static async Task<FacialExpression> RecognizeFacialExpressionAsync(MediaVisionSource source, Rectangle location, FaceEngineConfiguration config = null)
        {
            if (source == null || location == null)
            {
                throw new ArgumentException("Invalid parameter");
            }

            Interop.MediaVision.Rectangle rectangle = new Interop.MediaVision.Rectangle()
            {
                width = location.Width,
                height = location.Height,
                x = location.Point.X,
                y = location.Point.Y
            };

            TaskCompletionSource<FacialExpression> tcsResult = new TaskCompletionSource<FacialExpression>();

            // Define native callback
            Interop.MediaVision.Face.MvFaceFacialExpressionRecognizedCallback facialExpressionRecognizedCb = (IntPtr sourceHandle, IntPtr engineCfgHandle, Interop.MediaVision.Rectangle faceLocation, FacialExpression facialExpression, IntPtr userData) =>
            {
                Log.Info(MediaVisionLog.Tag, String.Format("Facial expression recognized, expression : {0}", facialExpression));
                if (!tcsResult.TrySetResult(facialExpression))
                {
                    Log.Info(MediaVisionLog.Tag, "Failed to set result");
                    tcsResult.TrySetException(new InvalidOperationException("Failed to set result"));
                }
            };

            int ret = Interop.MediaVision.Face.RecognizeFacialExpression(source._sourceHandle, (config != null) ? config._engineHandle : IntPtr.Zero,
                             rectangle, facialExpressionRecognizedCb, IntPtr.Zero);
            MediaVisionErrorFactory.CheckAndThrowException(ret, "Failed to perform facial expression recognition.");

            return await tcsResult.Task;
        }
    }
}
