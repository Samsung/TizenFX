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

namespace Tizen.NUI.PenWave
{
    /// <summary>
    /// The base class for all tools in the PenWave.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class ToolBase
    {
        /// <summary>
        /// Events that are triggered when the tool starts an action.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler ActionStarted;

        /// <summary>
        /// Events that are triggered when the tool finishes an action.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler ActionFinished;

        /// <summary>
        /// Handles input events such as touch events and updates the state of the tool accordingly.
        /// </summary>
        /// <param name="touch">The touch event data.</param>
        /// <returns>True if the input was handled by the tool, false otherwise.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public abstract bool HandleInput(Touch touch);

        /// <summary>
        /// Handles input events such as wheel events and updates the state of the tool accordingly.
        /// </summary>
        /// <param name="wheel">The wheel event data.</param>
        /// <returns>True if the input was handled by the tool, false otherwise.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public abstract bool HandleInput(Wheel wheel);

        /// <summary>
        /// Activates the tool, making it ready to receive input and perform its functionality.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public abstract void Activate();

        /// <summary>
        /// Deactivates the tool, stopping it from receiving input and performing its functionality.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public abstract void Deactivate();

        /// <summary>
        /// Notifies that the tool has started an action.
        /// </summary>
        protected void NotifyActionStarted()
        {
            ActionStarted?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Notifies that the tool has finished an action.
        /// </summary>
        protected void NotifyActionFinished()
        {
            ActionFinished?.Invoke(this, EventArgs.Empty);
        }

    }
}

