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
    /// Represents an exception that is thrown when there is a violation of the sound system policy.
    /// This exception indicates that an operation has attempted to perform an action that
    /// is not compliant with the established audio policies, which may affect audio playback or
    /// manipulation within the application.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class AudioPolicyException : InvalidOperationException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AudioPolicyException"/> class
        /// without any error message. This constructor is typically used when the
        /// exception is thrown without specific details about the error.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public AudioPolicyException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AudioPolicyException"/> class
        /// with a specified error message. This message provides additional context
        /// regarding the reason for the exception, which can be useful for debugging
        /// and logging purposes.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <since_tizen> 4 </since_tizen>
        public AudioPolicyException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AudioPolicyException"/> class
        /// with a specified error message and a reference to the inner exception
        /// that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception..</param>
        /// <since_tizen> 4 </since_tizen>
        public AudioPolicyException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
