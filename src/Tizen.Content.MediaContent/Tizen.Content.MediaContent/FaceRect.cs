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
