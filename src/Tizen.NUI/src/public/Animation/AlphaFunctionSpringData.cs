/*
 * Copyright(c) 2025 Samsung Electronics Co., Ltd.
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

using System.ComponentModel;

namespace Tizen.NUI
{
    /// <summary>
    /// Enumeration for predefined spring animation types.
    /// This presets are based on typical spring behavior tuned for different motion effects.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class AlphaFunctionSpringData
    {
        /// <summary>
        /// Spring stiffness(Hooke's constant). Higher values make the spring snap back faster. Minimum value is 0.1.
        /// Default Value is 1.0.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float Stiffness { set; get; } = 1.0f;

        /// <summary>
        /// Damping coefficient. Controls oscillation and settling. Minimum value is 0.1.
        /// Default Value is 1.0.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float Damping { set; get; } = 1.0f;

        /// <summary>
        /// Mass of the object. Affects inertia and the duration of the motion. Minimum value is 0.1.
        /// Default Value is 1.0.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float Mass { set; get; } = 1.0f;

        public AlphaFunctionSpringData(float stiffness, float damping, float mass)
        {
            Stiffness = stiffness;
            Damping = damping;
            Mass = mass;
        }

        /// <summary>
        /// Returns the time in milliseconds it takes for a Spring Animation to converge based on the AlphaFunctionSpringData.
        /// The maximum value for the returned duration is 100000 milliseconds(100 seconds).
        /// Since this value is calculated in an incremental manner, it may take longer if used frequently.
        /// </summary>
        /// <returns>Expected duration for input springData.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int GetDuration()
        {
            int duration = (int)(Interop.AlphaFunctionSpringData.GetDuration(Stiffness, Damping, Mass) * 1000.0f);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return duration;
        }
    }
}