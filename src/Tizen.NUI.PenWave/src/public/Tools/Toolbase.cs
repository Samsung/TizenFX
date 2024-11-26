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

namespace Tizen.NUI.PenWave
{
    /// <summary>
    /// The base class for all tools in the PenWave.
    /// </summary>
    public abstract class ToolBase
    {
        /// <summary>
        /// Handles input events such as touch events and updates the state of the tool accordingly.
        /// </summary>
        /// <param name="touch">The touch event data.</param>
        /// <param name="unredoManager">The manager responsible for handling undo and redo operations.</param>
        public virtual void HandleInput(Touch touch, UnRedoManager unredoManager) {}

        /// <summary>
        /// Activates the tool, making it ready to receive input and perform its functionality.
        /// </summary>
        public abstract void Activate();

        /// <summary>
        /// Deactivates the tool, stopping it from receiving input and performing its functionality.
        public abstract void Deactivate();

    }
}

