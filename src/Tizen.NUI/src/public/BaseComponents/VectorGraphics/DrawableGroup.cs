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
using System.Collections.Generic;
using System.ComponentModel;

namespace Tizen.NUI.BaseComponents.VectorGraphics
{
    /// <summary>
    /// A class enabling to hold many Drawable objects. As a whole they can be transformed, their transparency can be changed.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class DrawableGroup : Drawable
    {
        private List<Drawable> drawables; //The list of added drawables

        /// <summary>
        /// Creates an initialized DrawableGroup.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DrawableGroup() : this(Interop.DrawableGroup.New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal DrawableGroup(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
            drawables = new List<Drawable>();
        }

        /// <summary>
        /// Add drawable object to the DrawableGroup. This method is similar to registration.
        /// </summary>
        /// <param name="drawable">Drawable object</param>
        /// <exception cref="ArgumentNullException"> Thrown when drawable is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AddDrawable(Drawable drawable)
        {
            if (drawable == null)
            {
                throw new ArgumentNullException(nameof(drawable));
            }
            Interop.DrawableGroup.AddDrawable(View.getCPtr(this), BaseHandle.getCPtr(drawable));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            if (!drawables.Contains(drawable))
            {
                drawables.Add(drawable);
            }
        }

        /// <summary>
        /// Clears the drawable object added to the DrawableGroup. 
        /// This method does not free the memory of the added drawable object.
        /// </summary>
        /// <returns>True when it's successful. False otherwise.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Clear()
        {
            bool ret = Interop.DrawableGroup.Clear(BaseHandle.getCPtr(this));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            if (ret)
            {
                drawables.Clear();
            }
            return ret;
        }
    }
}
