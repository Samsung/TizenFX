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
    /// Specifies whether a codec is an audio codec or a video codec.
    /// </summary>
    public enum CodecKind
    {
        /// <summary>
        /// Audio codec.
        /// </summary>
        Audio,

        /// <summary>
        /// Video codec.
        /// </summary>
        Video
    }

    /// <summary>
    /// The exception that is thrown when the codec for an input file or a data stream is not supported
    /// or the input is malformed.
    /// </summary>
    public class CodecNotSupportedException : InvalidOperationException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CodecNotSupportedException"/> class
        /// with <see cref="CodecKind"/> indicating which codec is not supported.
        /// </summary>
        public CodecNotSupportedException(CodecKind kind)
        {
            CodecKind = kind;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CodecNotSupportedException"/> class with
        /// <see cref="CodecKind"/> indicating which codec is not supported and a specified error message.
        /// </summary>
        public CodecNotSupportedException(CodecKind kind, string message) : base(message)
        {
            CodecKind = kind;
        }

        /// <summary>
        /// Gets the <see cref="CodecKind"/> of the exception.
        /// </summary>
        public CodecKind CodecKind { get; }
    }
}
