/*
 * Copyright (c) 2023 Codefoco (codefoco@codefoco.com)
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

using System;
using System.ComponentModel;

namespace Tizen.NUI.Physics2D.Chipmunk
{
    /// <summary>
    /// March data used for <see cref="AutoGeometry"/>.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class MarchData
    {
        /// <summary>
        /// The bounding box.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BoundingBox BoundingBox { get; set; }

        /// <summary>
        /// The number of horizontal samples.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int XSamples { get; set; }

        /// <summary>
        /// The number of vertical samples.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int YSamples { get; set; }

        /// <summary>
        /// The threshold.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double Threshold { get; set; }

        /// <summary>
        /// Callback for sampling/
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Func<Vect, object, double> SampleFunction { get; set; }

        /// <summary>
        /// Callback for segmentation.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Action<Vect, Vect, object> SegmentFunction { get; set; }

        /// <summary>
        /// User sample data.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public object SampleData { get; set; }

        /// <summary>
        /// User segmentation data.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public object SegmentData { get; set; }
    }
}
