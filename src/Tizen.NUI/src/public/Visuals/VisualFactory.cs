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
    /// The VisualFactory is a singleton object that provides and shares visuals between views.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class VisualFactory : BaseHandle
    {
        /// <summary>
        /// Instance of the VisualFactory singleton.
        /// </summary>
        private static readonly VisualFactory instance = VisualFactory.GetInternal();

        private VisualFactory(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        private VisualFactory() : this(Interop.VisualFactory.NewVisualFactory(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Retrieves the VisualFactory singleton.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static VisualFactory Instance
        {
            get
            {
                return instance;
            }
        }

        /// <summary>
        /// Do not use this, that will be deprecated. Use VisualFactory.Instance instead.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Do not use this, that will be deprecated. Use VisualFactory.Instance instead. " +
            "Like: " +
            "VisualFactory visualFactory = VisualFactory.Instance; " +
            "visualFactory.CreateVisual(visualMap);")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static VisualFactory Get()
        {
            return VisualFactory.Instance;
        }

        private static VisualFactory GetInternal()
        {
            global::System.IntPtr cPtr = Interop.VisualFactory.Get();

            if(cPtr == global::System.IntPtr.Zero)
            {
                NUILog.ErrorBacktrace("VisualFactory.Instance called before Application created, or after Application terminated!");
            }

            VisualFactory ret = Registry.GetManagedBaseHandleFromNativePtr(cPtr) as VisualFactory;
            if (ret != null)
            {
                NUILog.ErrorBacktrace("VisualFactory.GetInternal() Should be called only one time!");
                object dummyObect = new object();

                global::System.Runtime.InteropServices.HandleRef CPtr = new global::System.Runtime.InteropServices.HandleRef(dummyObect, cPtr);
                Interop.BaseHandle.DeleteBaseHandle(CPtr);
                CPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
            else
            {
                ret = new VisualFactory(cPtr, true);
                return ret;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                NUILog.ErrorBacktrace("We should not manually dispose for singleton class!");
            }
            else
            {
                base.Dispose(disposing);
            }
        }

        /// <summary>
        /// Request the visual.
        /// </summary>
        /// <param name="propertyMap">The map contains the properties required by the visual. The content of the map determines the type of visual that will be returned.</param>
        /// <returns>The handle to the created visual.</returns>
        /// <since_tizen> 3 </since_tizen>
        public VisualBase CreateVisual(PropertyMap propertyMap)
        {
            VisualBase ret = new VisualBase(Interop.VisualFactory.CreateVisual(SwigCPtr, PropertyMap.getCPtr(propertyMap)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Compile the visual shader in advance. Afterwards,
        /// when a visual using a new shader is requested, the pre-compiled shader is used.
        /// </summary>
        /// <remarks> It is recommended that this method be called at the top of the application code.</remarks>
        /// <remarks>
        /// Using precompiled shaders is helpful when the application is complex and uses
        /// many different styles of visual options. On the other hand,if most visuals are the same
        /// and the application is simple, it may use memory unnecessarily or slow down the application launching speed.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void UsePreCompiledShader()
        {
            Interop.VisualFactory.UsePreCompiledShader(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Adds a list of pre-compiled shaders to the visual factory.
        /// </summary>
        ///
        /// This API allows you to add the desired precompile shader to the list.
        /// you can set it through PropertyMap.
        /// you need to know the values for setting well to use them, so please refer to the explanation below.
        ///
        /// The property map consists of string keys.
        ///
        /// - shaderType: Set the desired shader type. we provides these type: "image","text","color","3d" and "custom"
        /// - shaderOption(propertyMap): Set the desired shader option. we provides these flag: we provides a lot of shader options, so user need to check proper shader option.
        /// - vertexShader: Set the vertext shader that user want. this is for custom shader.
        /// - fragmentShader: Set the fragment shader that user want. this is for custom shader.
        /// - shaderName: if user want to set shader name, use this. this is for custom shader.(optional)
        ///
        /// (example)
        /// PropertyMap imageShader = new PropertyMap();
        /// imageShader.Add("shaderType", new PropertyValue("image"));
        /// imageShader.Add("shaderOption", new PropertyValue(new PropertyMap().Add("ROUNDED_CORNER", new PropertyValue(true))
        ///                                                                     .Add("MASKING", new PropertyValue(true))));
        ///
        /// PropertyMap textShader = new PropertyMap();
        /// textShader.Add("shaderType", new PropertyValue("text"));
        ///
        /// VisualFactory.Instance.AddPrecompileShader(imageShader);
        /// VisualFactory.Instance.AddPrecompileShader(textShader);
        /// VisualFactory.Instance.UsePreCompiledShader();
        ///
        /// <param name="option">The map contains the shader option for precompiling.</param>
        /// <return>True if the pre-compiled shader is added, otherwise false.</return>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool AddPrecompileShader(PropertyMap option)
        {
            bool result = false;
            result = Interop.VisualFactory.AddPrecompileShader(SwigCPtr, PropertyMap.getCPtr(option));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }
    }
}
