/*
 * Copyright (c) 2022 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Threading.Tasks;
using InteropRoi = Interop.MediaVision.RoiTracker;

namespace Tizen.Multimedia.Vision
{
    /// <summary>
    /// Provides the ability to track ROI(Region Of Interest) area on image source.
    /// </summary>
    /// <since_tizen> 10 </since_tizen>
    public static class RoiTracker
    {
        /// <summary>Tracks ROI(Region Of Interest) on the source image.</summary>
        /// <remarks><see cref="RoiTrackingConfiguration.Roi"/> should be set first correctly.</remarks>
        /// <feature>http://tizen.org/feature/vision.roi_tracking</feature>
        /// <param name="source">The source of the media user wants to track.</param>
        /// <param name="config">The engine's configuration that will be used for tracking.</param>
        /// <returns>A task that represents the asynchronous tracking operation.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="config"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="config.Roi"/> is not set correctly.</exception>
        /// <exception cref="InvalidOperationException">Internal error.</exception>
        /// <seealso cref="RoiTrackingConfiguration"/>
        /// <since_tizen> 10 </since_tizen>
        public static async Task<Rectangle> TrackAsync(MediaVisionSource source, RoiTrackingConfiguration config)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (config == null)
            {
                throw new ArgumentNullException(nameof(config));
            }
            if (config._roi == null)
            {
                throw new ArgumentException(nameof(config.Roi));
            }

            if (!config.IsApplied)
            {
                // Configure() and Prepare() can be called every time but it's useless, because Native Vision FW can accept it once.
                InteropRoi.Configure(config.GetRoiConfigHandle(), config.Handle).
                    Validate("Failed to configure roi tracking");

                var initialRoi = config.Roi;
                InteropRoi.Prepare(config.GetRoiConfigHandle(), initialRoi.X, initialRoi.Y, initialRoi.Width, initialRoi.Height).
                    Validate("Failed to prepare roi tracking");

                config.IsApplied = true;
            }

            var tcs = new TaskCompletionSource<Rectangle>();

            InteropRoi.RoiTrackedCallback callback = (handle, roi_, _) => tcs.TrySetResult(roi_.ToApiStruct());

            using (var cb = ObjectKeeper.Get(callback))
            {
                InteropRoi.TrackRoi(config.GetRoiConfigHandle(), source.Handle, cb.Target).
                    Validate("Failed to track roi");

                return await tcs.Task;
            }
        }
    }
}
