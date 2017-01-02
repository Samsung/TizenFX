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
using static Interop.MediaVision;

namespace Tizen.Multimedia
{
    /// <summary>
    /// This class represents face recognition model interface
    /// </summary>
    public class FaceRecognitionModel : IDisposable
    {
        internal IntPtr _recognitionModelHandle = IntPtr.Zero;
        private bool _disposed = false;

        /// <summary>
        /// Construct of FaceRecognitionModel class
        /// </summary>
        public FaceRecognitionModel()
        {
            int ret = Interop.MediaVision.FaceRecognitionModel.Create(out _recognitionModelHandle);
            MediaVisionErrorFactory.CheckAndThrowException(ret, "Failed to create FaceRecognitionModel.");
        }

        /// <summary>
        /// Construct of FaceRecognitionModel class which creates and loads recognition model from file.
        /// </summary>
        /// <remarks>
        /// FaceRecognitionModel is loaded from the absolute path directory.\n
        /// Models has been saved by <see cref="Save()"/> function can be loaded with this function
        /// </remarks>
        /// <param name="fileName">Name of path/file to load the model</param>
        /// <seealso cref="Save()"/>
        /// <code>
        /// 
        /// </code>
        public FaceRecognitionModel(string fileName)
        {
            int ret = Interop.MediaVision.FaceRecognitionModel.Load(fileName, out _recognitionModelHandle);
            MediaVisionErrorFactory.CheckAndThrowException(ret, "Failed to load FaceRecognitionModel from file.");
        }

        /// <summary>
        /// Destructor of the FaceRecognitionModel class.
        /// </summary>
        ~FaceRecognitionModel()
        {
            Dispose(false);
        }

        /// <summary>
        /// Gets labels list
        /// </summary>
        public int[] FaceLabels
        {
            get
            {
                IntPtr labelsArrayPtr;
                uint numOfLabels = 0;
                int ret = Interop.MediaVision.FaceRecognitionModel.QueryLabels(_recognitionModelHandle, out labelsArrayPtr, out numOfLabels);
                if (ret != 0)
                {
                    Tizen.Log.Error(MediaVisionLog.Tag, "Failed to get face labels");
                    return null;
                }

                int[] labels = new int[numOfLabels];
                for (int i = 0; i < numOfLabels; i++)
                {
                    labels[i] = Marshal.ReadInt32(labelsArrayPtr);
                    labelsArrayPtr = IntPtr.Add(labelsArrayPtr, sizeof(int));
                }

                return labels;
            }
        }

        /// <summary>
        /// Calls this method to save recognition model to the file.
        /// </summary>
        /// <remarks>
        /// RecognitionModel is saved to the absolute path directory.
        /// </remarks>
        /// <param name="fileName">Name of the path/file to save the model</param>
        /// <code>
        /// 
        /// </code>
        public void Save(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("Invalid file name");
            }

            int ret = Interop.MediaVision.FaceRecognitionModel.Save(fileName, _recognitionModelHandle);
            MediaVisionErrorFactory.CheckAndThrowException(ret, "Failed to save recognition model to file");
        }

        /// <summary>
        /// Adds face image example to be used for face recognition model learning with <see cref="Learn()"/>.
        /// </summary>
        /// <param name="source">Source that contains face image</param>
        /// <param name="faceLabel">The label that identifies face for which example is adding. Specify the same labels for the face images of a single person when calling this method. Has to be unique for each face</param>
        /// <param name="location">The rectangular location of the face image at the source image.</param>
        /// <code>
        /// 
        /// </code>
        public void Add(MediaVisionSource source, int faceLabel, Rectangle location = null)
        {
            if (source == null)
            {
                throw new ArgumentException("Invalid source");
            }

            IntPtr ptr = IntPtr.Zero;
            if (location != null)
            {
                Interop.MediaVision.Rectangle rectangle = new Interop.MediaVision.Rectangle()
                {
                    width = location.Width,
                    height = location.Height,
                    x = location.Point.X,
                    y = location.Point.Y
                };
                ptr = Marshal.AllocHGlobal(Marshal.SizeOf(rectangle));
                Marshal.StructureToPtr(rectangle, ptr, false);
            }

            int ret = Interop.MediaVision.FaceRecognitionModel.Add(source._sourceHandle, _recognitionModelHandle, ptr, faceLabel);
            MediaVisionErrorFactory.CheckAndThrowException(ret, "Failed to add face example image");
        }

        /// <summary>
        /// Removes from RecognitionModel all collected with <see cref="Add()"/> function face examples labeled with faceLabel.
        /// </summary>
        /// <param name="faceLabel">The label that identifies face for which examples will be removed from the RecognitionModel.</param>
        /// <code>
        /// 
        /// </code>
        public void Remove(int faceLabel)
        {
            int ret = Interop.MediaVision.FaceRecognitionModel.Remove(_recognitionModelHandle, ref faceLabel);
            MediaVisionErrorFactory.CheckAndThrowException(ret, "Failed to remove image example");
        }

        /// <summary>
        /// Removes all image examples known by RecognitionModel.
        /// </summary>
        /// <code>
        /// 
        /// </code>
        public void Reset()
        {
            int ret = Interop.MediaVision.FaceRecognitionModel.Reset(_recognitionModelHandle, IntPtr.Zero);
            MediaVisionErrorFactory.CheckAndThrowException(ret, "Failed to remove image example");
        }

        /// <summary>
        /// Learns face recognition model.
        /// </summary>
        /// <remarks>
        /// Before you start learning process, face recognition models has to be filled with training data - face image examples.
        /// These examples has to be provided by <see cref="Add()"/> function. Usually, recognition accuracy is increased
        /// when number of not identical examples is large. But it depends on the used learning algorithm.
        /// </remarks>
        /// <param name="config">The configuration of engine will be used for learning of the recognition models. If NULL, then default settings will be used</param>
        /// <code>
        /// 
        /// </code>
        public void Learn(FaceEngineConfiguration config = null)
        {
            int ret = Interop.MediaVision.FaceRecognitionModel.Learn((config != null) ? config._engineHandle : IntPtr.Zero, _recognitionModelHandle);
            MediaVisionErrorFactory.CheckAndThrowException(ret, "Failed to learn");
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                // Free managed objects
            }

            Interop.MediaVision.FaceRecognitionModel.Destroy(_recognitionModelHandle);
            _disposed = true;
        }
    }
}
