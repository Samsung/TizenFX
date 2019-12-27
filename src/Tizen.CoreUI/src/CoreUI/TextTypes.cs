/*
 * Copyright 2019 by its authors. See AUTHORS.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
namespace CoreUI {
    /// <summary>Bidirectionaltext type</summary>
    /// <since_tizen> 6 </since_tizen>
    
    [CoreUI.Wrapper.BindingEntity]
    public enum TextBidirectionalType
    {
        /// <summary>Natural text type, same as neutral</summary>
        /// <since_tizen> 6 </since_tizen>
        Natural = 0,
        /// <summary>Neutral text type, same as natural</summary>
        /// <since_tizen> 6 </since_tizen>
        Neutral = 0,
        /// <summary>Left to right text type</summary>
        /// <since_tizen> 6 </since_tizen>
        Ltr = 1,
        /// <summary>Right to left text type</summary>
        /// <since_tizen> 6 </since_tizen>
        Rtl = 2,
        /// <summary>Inherit text type</summary>
        /// <since_tizen> 6 </since_tizen>
        Inherit = 3,
        /// <summary>internal EVAS_BIDI_DIRECTION_ANY_RTL is not made for public. It should be opened to public when it is accepted to EFL upstream.</summary>
        /// <since_tizen> 6 </since_tizen>
        AnyRtl = 4,
    }
}

namespace CoreUI {
    /// <summary>This structure includes all the information about content changes.
    /// 
    /// It&apos;s meant to be used to implement undo/redo.</summary>
    /// <since_tizen> 6 </since_tizen>
    [StructLayout(LayoutKind.Sequential)]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public struct TextChangeInfo : IEquatable<TextChangeInfo>
    {
        /// <summary>Internal wrapper for field content</summary>
        private System.IntPtr content;
        
        private uint position;
        
        private uint length;
        /// <summary>Internal wrapper for field insertion</summary>
        private System.Byte insertion;
        /// <summary>Internal wrapper for field mergeable</summary>
        private System.Byte mergeable;

        /// <summary>The content added/removed</summary>
        /// <since_tizen> 6 </since_tizen>
        public System.String Content { get => CoreUI.DataTypes.StringConversion.NativeUtf8ToManagedString(content); }
        /// <summary>The position where it was added/removed</summary>
        /// <since_tizen> 6 </since_tizen>
        public uint Position { get => position; }
        /// <summary>The length of content in characters (not bytes, actual unicode characters)</summary>
        /// <since_tizen> 6 </since_tizen>
        public uint Length { get => length; }
        /// <summary><c>true</c> if the content was inserted, <c>false</c> if removed</summary>
        /// <since_tizen> 6 </since_tizen>
        public bool Insertion { get => insertion != 0; }
        /// <summary><c>true</c> if can be merged with the previous one. Used for example with insertion when something is already selected</summary>
        /// <since_tizen> 6 </since_tizen>
        public bool Mergeable { get => mergeable != 0; }
        /// <summary>Constructor for TextChangeInfo.
        /// </summary>
        /// <param name="content">The content added/removed</param>
        /// <param name="position">The position where it was added/removed</param>
        /// <param name="length">The length of content in characters (not bytes, actual unicode characters)</param>
        /// <param name="insertion"><c>true</c> if the content was inserted, <c>false</c> if removed</param>
        /// <param name="mergeable"><c>true</c> if can be merged with the previous one. Used for example with insertion when something is already selected</param>
        /// <since_tizen> 6 </since_tizen>
        public TextChangeInfo(
            System.String content = default(System.String),
            uint position = default(uint),
            uint length = default(uint),
            bool insertion = default(bool),
            bool mergeable = default(bool))
        {
            this.content = CoreUI.DataTypes.MemoryNative.StrDup(content);
            this.position = position;
            this.length = length;
            this.insertion = insertion ? (byte)1 : (byte)0;
            this.mergeable = mergeable ? (byte)1 : (byte)0;
        }

        /// <summary>Unpacks TextChangeInfo into tuple.
        /// <para>Since EFL 1.24.</para>
        /// </summary>
        public void Deconstruct(
            out System.String content,
            out uint position,
            out uint length,
            out bool insertion,
            out bool mergeable
        )
        {
            content = this.Content;
            position = this.Position;
            length = this.Length;
            insertion = this.Insertion;
            mergeable = this.Mergeable;
        }
        /// <summary>Get a hash code for this item.
        /// </summary>
        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + Content.GetHashCode(StringComparison.Ordinal);
            hash = hash * 23 + Position.GetHashCode();
            hash = hash * 23 + Length.GetHashCode();
            hash = hash * 23 + Insertion.GetHashCode();
            hash = hash * 23 + Mergeable.GetHashCode();
            return hash;
        }
        /// <summary>Equality comparison.
        /// </summary>
        public bool Equals(TextChangeInfo other)
        {
            return Content == other.Content && Position == other.Position && Length == other.Length && Insertion == other.Insertion && Mergeable == other.Mergeable;
        }
        /// <summary>Equality comparison.
        /// </summary>
        public override bool Equals(object other)
            => ((other is TextChangeInfo) ? Equals((TextChangeInfo)other) : false);
        /// <summary>Equality comparison.
        /// </summary>
        public static bool operator ==(TextChangeInfo lhs, TextChangeInfo rhs)
            => lhs.Equals(rhs);        /// <summary>Equality comparison.
        /// </summary>
        public static bool operator !=(TextChangeInfo lhs, TextChangeInfo rhs)
            => !lhs.Equals(rhs);        /// <summary>Implicit conversion to the managed representation from a native pointer.
        /// </summary>
        /// <param name="ptr">Native pointer to be converted.</param>
        public static implicit operator TextChangeInfo(IntPtr ptr)
        {
            return (TextChangeInfo)Marshal.PtrToStructure(ptr, typeof(TextChangeInfo));
        }

        /// <summary>Conversion to the managed representation from a native pointer.
        /// </summary>
        /// <param name="ptr">Native pointer to be converted.</param>
        public static TextChangeInfo FromIntPtr(IntPtr ptr)
        {
            return ptr;
        }

    }

}

