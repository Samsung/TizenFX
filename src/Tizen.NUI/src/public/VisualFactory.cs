/*
 * Copyright(c) 2018 Samsung Electronics Co., Ltd.
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
        private static VisualFactory instance;

        internal VisualFactory(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.VisualFactory.VisualFactory_SWIGUpcast(cPtr), cMemoryOwn)
        {
        }

        internal VisualFactory() : this(Interop.VisualFactory.new_VisualFactory__SWIG_0(), true)
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
                if (!instance)
                {
                    instance = new VisualFactory(Interop.VisualFactory.VisualFactory_Get(), true);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return instance;
            }
        }

        /// <summary>
        /// Please do not use! this will be deprecated, please use VisualFactory.Instance instead.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Please do not use! This will be deprecated! Please use VisualFactory.Instance instead! " +
            "Like: " +
            "VisualFactory visualFactory = VisualFactory.Instance; " +
            "visualFactory.CreateVisual(visualMap);")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static VisualFactory Get()
        {
            return VisualFactory.Instance;
        }

        /// <summary>
        /// Request the visual.
        /// </summary>
        /// <param name="propertyMap">The map contains the properties required by the visual. The content of the map determines the type of visual that will be returned.</param>
        /// <returns>The handle to the created visual.</returns>
        /// <since_tizen> 3 </since_tizen>
        public VisualBase CreateVisual(PropertyMap propertyMap)
        {
            VisualBase ret = new VisualBase(Interop.VisualFactory.VisualFactory_CreateVisual__SWIG_0(swigCPtr, PropertyMap.getCPtr(propertyMap)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

    }

}