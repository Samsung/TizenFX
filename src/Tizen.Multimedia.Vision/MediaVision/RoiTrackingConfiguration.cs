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
using InteropRoi = Interop.MediaVision.RoiTracker;

namespace Tizen.Multimedia.Vision
{
    /// <summary>
    /// Represents a configuration of <see cref="RoiTracker"/> instances.
    /// </summary>
    /// <feature>http://tizen.org/feature/vision.roi_tracking</feature>
    /// <exception cref="NotSupportedException">The required features are not supported.</exception>
    /// <since_tizen> 10 </since_tizen>
    public class RoiTrackingConfiguration : EngineConfiguration
    {
        private IntPtr _handle;
        private const string KeyTrackerType = "MV_ROI_TRACKER_TYPE";

        internal bool IsApplied { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RoiTrackingConfiguration"/> class.
        /// </summary>
        /// <exception cref="NotSupportedException">The feature is not supported.</exception>
        /// <since_tizen> 10 </since_tizen>
        public RoiTrackingConfiguration() : base("roi_tracking")
        {
            InteropRoi.Create(out _handle).Validate("Failed to create roi tracking configuration");
        }

        internal IntPtr GetRoiConfigHandle()
        {
            return _handle;
        }

        /// <summary>
        /// Gets or sets the type of ROI tracker.<br/>
        /// Default value is <see cref="RoiTrackerType.Balance"/>.
        /// </summary>
        /// <exception cref="ArgumentException"><paramref name="value"/> is not valid.</exception>
        /// <since_tizen> 10 </since_tizen>
        public RoiTrackerType TrackerType
        {
            get
            {
                return (RoiTrackerType)GetInt(KeyTrackerType);
            }
            set
            {
                ValidationUtil.ValidateEnum(typeof(RoiTrackerType), value, nameof(value));

                Set(KeyTrackerType, (int)value);
            }
        }

        internal Rectangle? _roi;

        /// <summary>
        /// Gets or sets the ROI(Region Of Interest) of <see cref="RoiTracker"/>.
        /// </summary>
        /// <remarks>
        /// The default value is Rectangle(0, 0, 0, 0) but it's meaningless.<br/>
        /// The user should set this to correct value for <see cref="RoiTracker.TrackAsync"/>.
        /// </remarks>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     The width of <paramref name="value"/> is less than or equal to zero.<br/>
        ///     -or-<br/>
        ///     The height of <paramref name="value"/> is less than or equal to zero.<br/>
        ///     -or-<br/>
        ///     The x position of <paramref name="value"/> is less than zero.<br/>
        ///     -or-<br/>
        ///     The y position of <paramref name="value"/> is less than zero.
        /// </exception>
        /// <since_tizen> 10 </since_tizen>
        public Rectangle Roi
        {
            get
            {
                return _roi.HasValue ? _roi.Value : new Rectangle(0, 0, 0, 0);
            }
            set
            {
                ValidateRoi(value);
                _roi = value;
            }
        }

        internal static void ValidateRoi(Rectangle roi)
        {
            if (roi.Width <= 0)
            {
                throw new ArgumentOutOfRangeException("roi.Width", roi.Width,
                    "The width of roi can't be less than or equal to zero.");
            }

            if (roi.Height <= 0)
            {
                throw new ArgumentOutOfRangeException("roi.Height", roi.Height,
                    "The height of roi can't be less than or equal to zero.");
            }

            if (roi.X < 0)
            {
                throw new ArgumentOutOfRangeException("roi.X", roi.X,
                    "The x position of roi can't be less than zero.");
            }

            if (roi.Y < 0)
            {
                throw new ArgumentOutOfRangeException("roi.Y", roi.Y,
                    "The y position of roi can't be less than zero.");
            }
        }

        /// <summary>
        /// Releases the resources used by the <see cref="RoiTrackingConfiguration"/> object.
        /// </summary>
        /// <param name="disposing">
        /// true to release both managed and unmanaged resources, otherwise false to release only unmanaged resources.
        /// </param>
        /// <since_tizen> 10 </since_tizen>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (_handle != IntPtr.Zero)
            {
                InteropRoi.Destroy(_handle).Validate("Failed to destroy roi tracking configuration");
                _handle = IntPtr.Zero;
            }
        }
    }

    /// <summary>
    /// Specifies the type of ROI tracker.
    /// </summary>
    /// <since_tizen> 10 </since_tizen>
    public enum RoiTrackerType
    {
        /// <summary>
        /// ROI tracker focuses on accuracy
        /// </summary>
        Accuracy = 1,

        /// <summary>
        /// ROI tracker focuses on both accuracy and speed
        /// </summary>
        Balance,

        /// <summary>
        /// ROI tracker focuses on speed
        /// </summary>
        Speed
    }
}
