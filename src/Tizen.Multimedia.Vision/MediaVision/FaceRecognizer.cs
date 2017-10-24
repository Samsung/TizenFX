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
using InteropFace = Interop.MediaVision.Face;

namespace Tizen.Multimedia.Vision
{
    /// <summary>
    /// Provides the ability to recognize faces, face expressions, and eye condition on image sources.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public static class FaceRecognizer
    {

        /// <summary>
        /// Performs face recognition on the source with <see cref="FaceRecognitionModel"/>.
        /// </summary>
        /// <param name="source">The <see cref="MediaVisionSource"/> of the media to recognize faces for.</param>
        /// <param name="recognitionModel">The <see cref="FaceRecognitionConfiguration"/> to be used for recognition.</param>
        /// <returns>A task that represents the asynchronous recognition operation.</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="source"/> is null.<br/>
        ///     -or-<br/>
        ///     <paramref name="recognitionModel"/> is null.
        /// </exception>
        /// <exception cref="NotSupportedException">The feature is not supported.</exception>
        /// <exception cref="ObjectDisposedException"><paramref name="source"/> has already been disposed of.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="recognitionModel"/> is untrained model.</exception>
        /// <feature>http://tizen.org/feature/vision.face_recognition</feature>
        /// <since_tizen> 3 </since_tizen>
        public static async Task<FaceRecognitionResult> RecognizeAsync(MediaVisionSource source,
            FaceRecognitionModel recognitionModel)
        {
            return await InvokeRecognizeAsync(source, recognitionModel, null, null);
        }

        /// <summary>
        /// Performs face recognition on the source with <see cref="FaceRecognitionModel"/> and a bounding box.
        /// </summary>
        /// <param name="source">The <see cref="MediaVisionSource"/> of the media to recognize faces for.</param>
        /// <param name="recognitionModel">The <see cref="FaceRecognitionModel"/> to be used for recognition.</param>
        /// <param name="bound">Rectangular box bounding face image on the source.</param>
        /// <returns>A task that represents the asynchronous recognition operation.</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="source"/> is null.<br/>
        ///     -or-<br/>
        ///     <paramref name="recognitionModel"/> is null.
        /// </exception>
        /// <exception cref="NotSupportedException">The feature is not supported.</exception>
        /// <exception cref="ObjectDisposedException"><paramref name="source"/> has already been disposed of.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="recognitionModel"/> is untrained model.</exception>
        /// <feature>http://tizen.org/feature/vision.face_recognition</feature>
        /// <since_tizen> 3 </since_tizen>
        public static async Task<FaceRecognitionResult> RecognizeAsync(MediaVisionSource source,
            FaceRecognitionModel recognitionModel, Rectangle bound)
        {
            return await InvokeRecognizeAsync(source, recognitionModel, bound, null);
        }

        /// <summary>
        /// Performs face recognition on the source with <see cref="FaceRecognitionModel"/> and <see cref="FaceRecognitionConfiguration"/>.
        /// </summary>
        /// <param name="source">The <see cref="MediaVisionSource"/> of the media to recognize faces for.</param>
        /// <param name="recognitionModel">The <see cref="FaceRecognitionModel"/> to be used for recognition.</param>
        /// <param name="config">The configuration used for recognition. This value can be null.</param>
        /// <returns>A task that represents the asynchronous recognition operation.</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="source"/> is null.<br/>
        ///     -or-<br/>
        ///     <paramref name="recognitionModel"/> is null.
        /// </exception>
        /// <exception cref="NotSupportedException">The feature is not supported.</exception>
        /// <exception cref="ObjectDisposedException">
        ///     <paramref name="source"/> has already been disposed of.<br/>
        ///     -or-<br/>
        ///     <paramref name="config"/> has already been disposed of.
        /// </exception>
        /// <exception cref="InvalidOperationException"><paramref name="recognitionModel"/> is untrained model.</exception>
        /// <feature>http://tizen.org/feature/vision.face_recognition</feature>
        /// <since_tizen> 3 </since_tizen>
        public static async Task<FaceRecognitionResult> RecognizeAsync(MediaVisionSource source,
            FaceRecognitionModel recognitionModel, FaceRecognitionConfiguration config)
        {
            return await InvokeRecognizeAsync(source, recognitionModel, null, config);
        }

        /// <summary>
        /// Performs face recognition on the source with <see cref="FaceRecognitionModel"/>, <see cref="FaceRecognitionConfiguration"/>
        /// and a bounding box.
        /// </summary>
        /// <param name="source">The <see cref="MediaVisionSource"/> of the media to recognize faces for.</param>
        /// <param name="recognitionModel">The <see cref="FaceRecognitionModel"/> to be used for recognition.</param>
        /// <param name="bound">Rectangular box bounding face image on the source.</param>
        /// <param name="config">The <see cref="FaceRecognitionConfiguration"/> used for recognition. This value can be null.</param>
        /// <returns>A task that represents the asynchronous recognition operation.</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="source"/> is null.<br/>
        ///     -or-<br/>
        ///     <paramref name="recognitionModel"/> is null.
        /// </exception>
        /// <exception cref="NotSupportedException">The feature is not supported.</exception>
        /// <exception cref="ObjectDisposedException">
        ///     <paramref name="source"/> has already been disposed of.<br/>
        ///     -or-<br/>
        ///     <paramref name="config"/> has already been disposed of.
        /// </exception>
        /// <exception cref="InvalidOperationException"><paramref name="recognitionModel"/> is untrained model.</exception>
        /// <feature>http://tizen.org/feature/vision.face_recognition</feature>
        /// <since_tizen> 3 </since_tizen>
        public static async Task<FaceRecognitionResult> RecognizeAsync(MediaVisionSource source,
            FaceRecognitionModel recognitionModel, Rectangle bound, FaceRecognitionConfiguration config)
        {
            return await InvokeRecognizeAsync(source, recognitionModel, bound, config);
        }

        private static MediaVisionError InvokeRecognize(IntPtr sourceHandle, IntPtr modelHandle,
            IntPtr configHandle, InteropFace.RecognizedCallback cb, Rectangle? area)
        {
            if (area == null)
            {
                return InteropFace.Recognize(sourceHandle, modelHandle, configHandle, IntPtr.Zero, cb);
            }

            var rect = area.Value.ToMarshalable();
            return InteropFace.Recognize(sourceHandle, modelHandle, configHandle, ref rect, cb);
        }

        private static async Task<FaceRecognitionResult> InvokeRecognizeAsync(MediaVisionSource source,
            FaceRecognitionModel recognitionModel, Rectangle? area,
            FaceRecognitionConfiguration config)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (recognitionModel == null)
            {
                throw new ArgumentNullException(nameof(recognitionModel));
            }

            TaskCompletionSource<FaceRecognitionResult> tcs = new TaskCompletionSource<FaceRecognitionResult>();

            using (var cb = ObjectKeeper.Get(GetRecognizedCallback(tcs)))
            {
                InvokeRecognize(source.Handle, recognitionModel.Handle, EngineConfiguration.GetHandle(config),
                    cb.Target, area).Validate("Failed to perform face recognition.");

                return await tcs.Task;
            }
        }

        private static FaceRecognitionResult CreateRecognitionResult(
             IntPtr faceLocationPtr, IntPtr faceLabelPtr, double confidence)
        {
            int faceLabel = 0;
            if (faceLabelPtr != IntPtr.Zero)
            {
                faceLabel = Marshal.ReadInt32(faceLabelPtr);
            }

            Rectangle? faceLocation = null;
            if (faceLocationPtr != IntPtr.Zero)
            {
                var area = Marshal.PtrToStructure<global::Interop.MediaVision.Rectangle>(faceLocationPtr);
                faceLocation = area.ToApiStruct();
            }

            return new FaceRecognitionResult(faceLabelPtr != IntPtr.Zero, confidence, faceLabel, faceLocation);
        }

        private static InteropFace.RecognizedCallback GetRecognizedCallback(
            TaskCompletionSource<FaceRecognitionResult> tcs)
        {
            return (IntPtr sourceHandle, IntPtr recognitionModelHandle,
                IntPtr engineCfgHandle, IntPtr faceLocationPtr, IntPtr faceLabelPtr, double confidence, IntPtr _) =>
            {
                try
                {
                    if (!tcs.TrySetResult(CreateRecognitionResult(faceLocationPtr, faceLabelPtr, confidence)))
                    {
                        Log.Error(MediaVisionLog.Tag, "Failed to set result");
                    }
                }
                catch (Exception e)
                {
                    MultimediaLog.Error(MediaVisionLog.Tag, "Setting recognition result failed.", e);
                    tcs.TrySetException(e);
                }
            };
        }

        /// <summary>
        /// Determines eye-blink condition on media source.
        /// </summary>
        /// <param name="source">The source of the media to recognize eye-blink condition for.</param>
        /// <param name="bound">The bounding the face at the source.</param>
        /// <returns>A task that represents the asynchronous recognition operation.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        /// <exception cref="ObjectDisposedException"><paramref name="source"/> has already been disposed of.</exception>
        /// <exception cref="NotSupportedException">The feature is not supported.</exception>
        /// <feature>http://tizen.org/feature/vision.face_recognition</feature>
        /// <since_tizen> 3 </since_tizen>
        public static async Task<EyeCondition> RecognizeEyeConditionAsync(MediaVisionSource source,
            Rectangle bound)
        {
            return await RecognizeEyeConditionAsync(source, bound, null);
        }

        /// <summary>
        /// Determines eye-blink condition on the media source.
        /// </summary>
        /// <param name="source">The source of the media to recognize eye-blink condition for.</param>
        /// <param name="bound">The bounding the face at the source.</param>
        /// <param name="config">The configuration used for eye-blink condition recognition. This value can be null.</param>
        /// <returns>A task that represents the asynchronous recognition operation.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        /// <exception cref="ObjectDisposedException">
        ///     <paramref name="source"/> has already been disposed of.<br/>
        ///     -or-<br/>
        ///     <paramref name="config"/> has already been disposed of.
        /// </exception>
        /// <exception cref="NotSupportedException">The feature is not supported.</exception>
        /// <feature>http://tizen.org/feature/vision.face_recognition</feature>
        /// <since_tizen> 3 </since_tizen>
        public static async Task<EyeCondition> RecognizeEyeConditionAsync(MediaVisionSource source,
            Rectangle bound, FaceRecognitionConfiguration config)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            TaskCompletionSource<EyeCondition> tcs = new TaskCompletionSource<EyeCondition>();

            InteropFace.EyeConditionRecognizedCallback cb = (IntPtr sourceHandle, IntPtr engineCfgHandle,
                global::Interop.MediaVision.Rectangle faceLocation, EyeCondition eyeCondition, IntPtr _) =>
            {
                Log.Info(MediaVisionLog.Tag, $"Eye condition recognized, eye condition : {eyeCondition}");
                if (!tcs.TrySetResult(eyeCondition))
                {
                    Log.Error(MediaVisionLog.Tag, "Failed to set eye condition result");
                }
            };

            using (var cbKeeper = ObjectKeeper.Get(cb))
            {
                InteropFace.RecognizeEyeCondition(source.Handle, EngineConfiguration.GetHandle(config),
                    bound.ToMarshalable(), cb).Validate("Failed to perform eye condition recognition.");

                return await tcs.Task;
            }
        }

        /// <summary>
        /// Determines facial expression on media source.
        /// </summary>
        /// <param name="source">The source of the media to recognize facial expression for.</param>
        /// <param name="bound">The location bounding the face at the source.</param>
        /// <returns>A task that represents the asynchronous recognition operation.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        /// <exception cref="ObjectDisposedException"><paramref name="source"/> has already been disposed of.</exception>
        /// <exception cref="NotSupportedException">The feature is not supported.</exception>
        /// <feature>http://tizen.org/feature/vision.face_recognition</feature>
        /// <since_tizen> 3 </since_tizen>
        public static async Task<FacialExpression> RecognizeFacialExpressionAsync(MediaVisionSource source,
            Rectangle bound)
        {
            return await RecognizeFacialExpressionAsync(source, bound, null);
        }

        /// <summary>
        /// Determines facial expression on media source.
        /// </summary>
        /// <param name="source">The source of the media to recognize facial expression for.</param>
        /// <param name="bound">The location bounding the face at the source.</param>
        /// <param name="config">The configuration used for expression recognition. This value can be null.</param>
        /// <returns>A task that represents the asynchronous recognition operation.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        /// <exception cref="ObjectDisposedException">
        ///     <paramref name="source"/> has already been disposed of.<br/>
        ///     -or-<br/>
        ///     <paramref name="config"/> has already been disposed of.
        /// </exception>
        /// <exception cref="NotSupportedException">The feature is not supported.</exception>
        /// <feature>http://tizen.org/feature/vision.face_recognition</feature>
        /// <since_tizen> 3 </since_tizen>
        public static async Task<FacialExpression> RecognizeFacialExpressionAsync(MediaVisionSource source,
            Rectangle bound, FaceRecognitionConfiguration config)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            TaskCompletionSource<FacialExpression> tcsResult = new TaskCompletionSource<FacialExpression>();

            InteropFace.MvFaceFacialExpressionRecognizedCallback cb = (IntPtr sourceHandle, IntPtr engineCfgHandle,
                global::Interop.MediaVision.Rectangle faceLocation, FacialExpression facialExpression, IntPtr _) =>
             {
                 Log.Info(MediaVisionLog.Tag, $"Facial expression recognized, expression : {facialExpression}");
                 if (!tcsResult.TrySetResult(facialExpression))
                 {
                     Log.Error(MediaVisionLog.Tag, "Failed to set facial result");
                 }
             };

            using (var cbKeeper = ObjectKeeper.Get(cb))
            {
                InteropFace.RecognizeFacialExpression(source.Handle, EngineConfiguration.GetHandle(config),
                    bound.ToMarshalable(), cb).
                    Validate("Failed to perform facial expression recognition.");

                return await tcsResult.Task;
            }
        }
    }
}

