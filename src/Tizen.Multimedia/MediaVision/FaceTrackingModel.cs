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
    /// This class represents face tracking model interface
    /// </summary>
    public class FaceTrackingModel : IDisposable
    {
        internal IntPtr _trackingModelHandle = IntPtr.Zero;
        private bool _disposed = false;

        /// <summary>
        /// Construct of FaceTrackingModel class
        /// </summary>
        /// <code>
        /// var model = new FaceTrackingModel();
        /// </code>
        public FaceTrackingModel()
        {
            int ret = Interop.MediaVision.FaceTrackingModel.Create(out _trackingModelHandle);
            MediaVisionErrorFactory.CheckAndThrowException(ret, "Failed to create FaceTrackingModel.");
        }

        /// <summary>
        /// Construct of FaceTrackingModel class which creates and loads tracking model from file.
        /// </summary>
        /// <remarks>
        /// FaceTrackingModel is loaded from the absolute path directory.\n
        /// Models has been saved by <see cref="Save()"/> function can be loaded with this function
        /// </remarks>
        /// <param name="fileName">Name of path/file to load the model</param>
        /// <seealso cref="Save()"/>
        /// <seealso cref="Prepare()"/>
        /// <code>
        /// 
        /// </code>
        public FaceTrackingModel(string fileName)
        {
            int ret = Interop.MediaVision.FaceTrackingModel.Load(fileName, out _trackingModelHandle);
            MediaVisionErrorFactory.CheckAndThrowException(ret, "Failed to load FaceTrackingModel from file.");
        }

        /// <summary>
        /// Destructor of the FaceTrackingModel class.
        /// </summary>
        ~FaceTrackingModel()
        {
            Dispose(false);
        }

        /// <summary>
        /// Calls this function to initialize tracking model by the location of the face to be tracked.
        /// </summary>
        /// <param name="config">The configuration of engine will be used for model preparing. If NULL, then default settings will be used.</param>
        /// <param name="source">The source where face location is specified. Usually it is the first frame of the video or the first image in the continuous image sequence planned to be used for tracking</param>
        /// <param name="location">The quadrangle-shaped location determining position of the face to be tracked on the source. If NULL, then tracking model will try to find previously tracked face by itself. Don't set NULL when called first time for the tracking model.</param>
        public void Prepare(FaceEngineConfiguration config, MediaVisionSource source, Quadrangle location = null)
        {
            if (source == null)
            {
                throw new ArgumentException("Invalid source");
            }

            IntPtr ptr = IntPtr.Zero;
            if (location != null)
            {
                Interop.MediaVision.Quadrangle quadrangle = new Interop.MediaVision.Quadrangle()
                {
                    x1 = location.Points[0].X, y1 = location.Points[0].Y,
                    x2 = location.Points[1].X, y2 = location.Points[1].Y,
                    x3 = location.Points[2].X, y3 = location.Points[2].Y,
                    x4 = location.Points[3].X, y4 = location.Points[3].Y
                };
                ptr = Marshal.AllocHGlobal(Marshal.SizeOf(quadrangle));
                Marshal.StructureToPtr(quadrangle, ptr, false);
            }

            int ret = Interop.MediaVision.FaceTrackingModel.Prepare(_trackingModelHandle,
                                                                    (config != null) ? config._engineHandle : IntPtr.Zero,
                                                                    source._sourceHandle, ptr);
            MediaVisionErrorFactory.CheckAndThrowException(ret, "Failed to prepare tracking model.");
        }

        /// <summary>
        /// Calls this method to save tracking model to the file.
        /// </summary>
        /// <remarks>
        /// TrackingModel is saved to the absolute path directory.
        /// </remarks>
        /// <param name="fileName">Name of the path/file to save the model</param>
        public void Save(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("Invalid file name");
            }

            int ret = Interop.MediaVision.FaceTrackingModel.Save(fileName, _trackingModelHandle);
            MediaVisionErrorFactory.CheckAndThrowException(ret, "Failed to save tracking model to file");
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

            Interop.MediaVision.FaceTrackingModel.Destroy(_trackingModelHandle);
            _disposed = true;
        }
    }
}
