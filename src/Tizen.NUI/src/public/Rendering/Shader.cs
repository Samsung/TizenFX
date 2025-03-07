/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI
{
    /// <summary>
    /// Shader allows custom vertex and color transformations in the GPU.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class Shader : Animatable
    {

        /// <summary>
        /// Creates Shader object.
        /// </summary>
        /// <param name="vertexShader">The vertex shader code for the effect.</param>
        /// <param name="fragmentShader">The fragment Shader code for the effect.</param>
        /// <param name="hints">The hints to define the geometry of the rendered object.</param>
        /// <since_tizen> 3 </since_tizen>
        public Shader(string vertexShader, string fragmentShader, Shader.Hint.Value hints) : this(vertexShader, fragmentShader, hints, "")
        {
        }

        /// <summary>
        /// Creates Shader object.
        /// </summary>
        /// <param name="vertexShader">The vertex shader code for the effect.</param>
        /// <param name="fragmentShader">The fragment Shader code for the effect.</param>
        /// <since_tizen> 3 </since_tizen>
        public Shader(string vertexShader, string fragmentShader) : this(vertexShader, fragmentShader, Shader.Hint.Value.NONE, "")
        {
        }

        /// <summary>
        /// Creates Shader object with name
        /// </summary>
        /// <param name="vertexShader">The vertex shader code for the effect.</param>
        /// <param name="fragmentShader">The fragment Shader code for the effect.</param>
        /// <param name="shaderName">The name of this shader object.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Shader(string vertexShader, string fragmentShader, string shaderName) : this(vertexShader, fragmentShader, Shader.Hint.Value.NONE, shaderName)
        {
        }

        /// <summary>
        /// Gets and Sets the program property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Tizen.NUI.PropertyMap Program
        {
            get
            {
                Tizen.NUI.PropertyMap temp = new Tizen.NUI.PropertyMap();
                var pValue = Tizen.NUI.Object.GetProperty(SwigCPtr, Shader.Property.PROGRAM);
                pValue.Get(temp);
                pValue.Dispose();
                return temp;
            }
            set
            {
                var temp = new Tizen.NUI.PropertyValue(value);
                Tizen.NUI.Object.SetProperty(SwigCPtr, Shader.Property.PROGRAM, temp);

                // Update shader name
                Name = "";
                if (value != null)
                {
                    using var nameValue = value.Find("name");
                    if (nameValue?.Get(out string name) ?? false)
                    {
                        Name = name ?? "";
                    }
                }
                temp.Dispose();
            }
        }

        /// <summary>
        /// Gets the name of program.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Name { get; private set; }

        internal Shader(string vertexShader, string fragmentShader, Shader.Hint.Value hints, string shaderName) : this(Interop.Shader.New(vertexShader, fragmentShader, (int)hints, shaderName ?? ""), true)
        {
            Name = shaderName ?? "";
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Shader(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Shader.DeleteShader(swigCPtr);
        }

        /// <summary>
        /// The Hint class is used to provide additional information to the shader.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public sealed class Hint
        {
            /// <summary>
            /// Enumeration for the hint value.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public enum Value
            {
                /// <summary>
                /// No hints.
                /// </summary>
                /// <since_tizen> 3 </since_tizen>
                NONE = 0x00,

                /// <summary>
                /// Might generate transparent alpha from opaque inputs
                /// </summary>
                /// <since_tizen> 3 </since_tizen>
                OUTPUT_IS_TRANSPARENT = 0x01,

                /// <summary>
                /// Might change position of vertices, this option disables any culling optimizations
                /// </summary>
                /// <since_tizen> 3 </since_tizen>
                MODIFIES_GEOMETRY = 0x02
            }
        }

        /// <summary>
        /// Enumeration for instances of properties belonging to the Shader class.
        /// </summary>
        internal class Property
        {
            /// <summary>
            /// The default value is empty.
            /// Format: {"vertex":"","fragment":"",hints:"","vertexPrefix":"","fragmentPrefix":""}
            /// </summary>
            internal static readonly int PROGRAM = Interop.Shader.ProgramGet();
        }
    }
}
