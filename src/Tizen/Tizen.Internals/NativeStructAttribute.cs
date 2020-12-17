/*
 * Copyright (c) 2020 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.ComponentModel;

namespace Tizen.Internals
{
    /// <summary>
    /// Architecture types for mapping struct with unmanaged. 
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum NativeStructArch
    {
        /// Managed struct can be mapped for all architectures.
        All = 0,
        /// Managed struct can only be mapped in 32 bits runtime.
        Only32Bits = 1,
        /// Managed struct can only be mapped in 64 bits runtime.
        Only64Bits = 2
    }

    /// <summary>
    /// Indicates that the attributed struct maps an unmanaged struct.
    /// </summary>
    /// <remarks>
    /// The <see cref="NativeStructAttribute"/> attribute provides the information needed to verify that tue struct is correctly mapped.
    /// </remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class, AllowMultiple = true)]
    public class NativeStructAttribute : Attribute
    {
        private readonly string _structName;

        /// <summary>
        /// Initializes a new instance of the <see cref="NativeStructAttribute"/> class with the native struct information.
        /// </summary>
        /// <param name="structName">The name of structure to test the size.</param>
        public NativeStructAttribute(string structName)
        {
            _structName = structName;
        }

        /// <summary>
        /// The name of structure to test the size.
        /// </summary>
        public string StructName => _structName;

        /// <summary>
        /// The name of pkg-config that provides the header file location.
        /// </summary>
        public string PkgConfig { get; set; }

        /// <summary>
        /// The name of C header file(.h) that contains the struct to test.
        /// </summary>
        public string Include { get; set; }

        /// <summary>
        /// Runtime architecture to specify mapping.
        /// </summary>
        public NativeStructArch Arch { get; set; }
    }
}
