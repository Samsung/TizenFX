/*
 * Copyright(c) 2017 Samsung Electronics Co., Ltd.
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
    /// Shader.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class Shader : Animatable
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        /// <summary>
        /// Creates Shader object.
        /// </summary>
        /// <param name="vertexShader">The vertex shader code for the effect.</param>
        /// <param name="fragmentShader">The fragment Shader code for the effect.</param>
        /// <param name="hints">The hints to define the geometry of the rendered object.</param>
        /// <since_tizen> 3 </since_tizen>
        public Shader(string vertexShader, string fragmentShader, Shader.Hint.Value hints) : this(Interop.Shader.Shader_New__SWIG_0(vertexShader, fragmentShader, (int)hints), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Creates Shader object.
        /// </summary>
        /// <param name="vertexShader">The vertex shader code for the effect.</param>
        /// <param name="fragmentShader">The fragment Shader code for the effect.</param>
        /// <since_tizen> 3 </since_tizen>
        public Shader(string vertexShader, string fragmentShader) : this(Interop.Shader.Shader_New__SWIG_1(vertexShader, fragmentShader), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
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
                Tizen.NUI.Object.GetProperty(swigCPtr, Shader.Property.PROGRAM).Get(temp);
                return temp;
            }
            set
            {
                Tizen.NUI.Object.SetProperty(swigCPtr, Shader.Property.PROGRAM, new Tizen.NUI.PropertyValue(value));
            }
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Shader obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        internal Shader(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.Shader.Shader_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.

            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;
                    Interop.Shader.delete_Shader(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }

        /// <summary>
        /// Hint.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public class Hint
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
        /// <since_tizen> 3 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Deprecated in API6; Will be removed in API9.")]
        public class Property
        {
            /// <summary>
            /// The default value is empty.
            /// Format: {"vertex":"","fragment":"",hints:"","vertexPrefix":"","fragmentPrefix":""}
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Deprecated in API6; Will be removed in API9.")]
            public static readonly int PROGRAM = Interop.Shader.Shader_Property_PROGRAM_get();
        }
    }
}