/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc.("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tizen.Content.MediaContent
{
    /// <summary>
    /// FaceRect represents a rectangle dimension to create a Face in an image.
    /// It is used to create or tag a MediaFace in an image file.
    /// </summary>
    public class FaceRect
    {
        public FaceRect(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        /// <summary>
        /// X coordinate of the FaceRect
        /// </summary>
        public readonly int X;

        /// <summary>
        /// Y coordinate of the FaceRect
        /// </summary>
        public readonly int Y;

        /// <summary>
        /// Width of the FaceRect
        /// </summary>
        public readonly int Width;

        /// <summary>
        /// Height of the FaceRect
        /// </summary>
        public readonly int Height;
    }
}
