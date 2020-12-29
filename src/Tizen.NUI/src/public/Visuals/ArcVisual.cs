/*
 * Copyright(c) 2020 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */
using System.ComponentModel;

namespace Tizen.NUI
{
    /// <summary>
    /// A class encapsulating the property map of the arc visual.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ArcVisual : VisualMap
    {
        #region Fields

        private float thickness;
        private float startAngle;
        private float sweepAngle;
        private CapType cap;

        #endregion Fields


        #region Constructors

        /// <summary>
        /// Constructor.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ArcVisual() : base()
        {
        }

        #endregion Constructors


        #region Enums

        /// <summary>
        /// Enumeration for the cap style of the arc line.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum CapType
        {
            /// <summary>
            /// The arc does not extend beyond its two endpoints.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Butt,

            /// <summary>
            /// The arc will be extended by a half circle with the center at the end.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Round,
        }

        #endregion Enums


        #region Properties

        /// <summary>
        /// The thickness of the arc.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float Thickness
        {
            get => thickness;
            set
            {
                thickness = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// The start angle where the arc begins in degrees.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float StartAngle
        {
            get => startAngle;
            set
            {
                startAngle = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// The sweep angle of the arc in degrees.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float SweepAngle
        {
            get => sweepAngle;
            set
            {
                sweepAngle = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// The cap style of the arc.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CapType Cap
        {
            get => cap;
            set
            {
                cap = value;
                UpdateVisual();
            }
        }

        #endregion Properties


        #region Methods

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ComposingPropertyMap()
        {
            _outputVisualMap = null;

            base.ComposingPropertyMap();
            PropertyValue temp = new PropertyValue((int)Visual.Type.Arc);
            _outputVisualMap.Add(Visual.Property.Type, temp);
            temp.Dispose();

            temp = new PropertyValue(Thickness < 0.0f ? 0.0f : Thickness);
            _outputVisualMap.Add(ArcVisualProperty.Thickness, temp);
            temp.Dispose();

            temp = new PropertyValue(StartAngle);
            _outputVisualMap.Add(ArcVisualProperty.StartAngle, temp);
            temp.Dispose();

            temp = new PropertyValue(SweepAngle);
            _outputVisualMap.Add(ArcVisualProperty.SweepAngle, temp);
            temp.Dispose();

            temp = new PropertyValue((int)Cap);
            _outputVisualMap.Add(ArcVisualProperty.Cap, temp);
            temp.Dispose();
        }

        #endregion Methods
    }
}
