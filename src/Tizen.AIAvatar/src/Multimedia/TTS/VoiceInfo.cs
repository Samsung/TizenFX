/*
 * Copyright(c) 2024 Samsung Electronics Co., Ltd.
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

using System;
using System.ComponentModel;

namespace Tizen.AIAvatar
{
    /// <summary>
    /// VoiceInfo stores information about a voice. 
    /// The 'Language' field stores the language of the voice
    /// The 'Type' field stores the type of the voice. 
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public struct VoiceInfo : IEquatable<VoiceInfo>
    {
        private string language;
        private VoiceType type;

        /// <summary>  
        /// Gets or sets the language of the voice.  
        /// </summary>  
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Language { get => language; set => language = value; }

        /// <summary>  
        /// Gets or sets the type of the voice.  
        /// </summary>  
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VoiceType Type { get => type; set => type = value; }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if equal VoiceInfo, else false.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is VoiceInfo other && this.Equals(other);

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The VoiceInfo to compare with the current VoiceInfo.</param>
        /// <returns>true if equal VoiceInfo, else false.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Equals(VoiceInfo other) => Language == other.Language && Type == other.Type;

        /// <summary>
        /// The == operator.
        /// </summary>
        /// <param name="lhsVoiceInfo">VoiceInfo to compare</param>
        /// <param name="rhsVoiceInfo">VoiceInfo to be compared</param>
        /// <returns>true if VoiceInfo are equal</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator ==(VoiceInfo lhsVoiceInfo, VoiceInfo rhsVoiceInfo) => lhsVoiceInfo.Equals(rhsVoiceInfo);

        /// <summary>
        /// The != operator.
        /// </summary>
        /// <param name="lhsVoiceInfo">VoiceInfo to compare</param>
        /// <param name="rhsVoiceInfo">VoiceInfo to be compared</param>
        /// <returns>true if VoiceInfo are not equal</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator !=(VoiceInfo lhsVoiceInfo, VoiceInfo rhsVoiceInfo) => !lhsVoiceInfo.Equals(rhsVoiceInfo);

        /// <summary>
        /// Gets the hash code of this VoiceInfo.
        /// </summary>
        /// <returns>The hash code.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => (Language, Type).GetHashCode();
    }
}
