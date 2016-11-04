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

namespace Tizen.Multimedia
{
    /// <summary>
    /// The class contains the details of the detected face.
    /// </summary>
    public class FaceDetectedData
    {
        private int _id;
        private int _score;
        private int _x;
        private int _y;
        private int _width;
        private int _height;

        internal FaceDetectedData(int id, int score, int x, int y, int width, int height)
        {
	        _id = id;
            _score = score;
            _x = x;
            _y = y;
            _width = width;
            _height = height;
        }

        /// <summary>
        /// The Id of each face.
        /// </summary>
        public int Id
        {
            get
            {
                return _id;
            }
        }

        /// <summary>
        /// The confidence level for the detection of the face.
        /// </summary>
        public int Score
        {
            get
            {
                return _score;
            }
        }

        /// <summary>
        /// The X co-ordinate of the face.
        /// </summary>
        public int X
        {
            get
            {
                return _x;
            }
        }

        /// <summary>
        /// The Y co-ordinate of the face.
        /// </summary>
        public int Y
        {
            get
            {
                return _y;
            }
        }

        /// <summary>
        /// The width of the face.
        /// </summary>
        public int Width
        {
            get
            {
                return _width;
            }
        }

        /// <summary>
        /// The height of the face.
        /// </summary>
        public int Height
        {
            get
            {
                return _height;
            }
        }
    }
}

