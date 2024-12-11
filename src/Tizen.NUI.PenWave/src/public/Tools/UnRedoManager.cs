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
using System.Collections.Generic;

namespace Tizen.NUI.PenWave
{
    /// <summary>
    /// The UnRedoManager class manages undo and redo operations for commands.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class UnRedoManager
    {
        // Stacks to store undo and redo commands
        private uint _undoStack = 0;
        private uint _redoStack = 0;

        /// <summary>
        /// Registers a new command to the undo stack and clears the redo stack.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal void RegisterUndo()
        {
            _undoStack++; // Push command to undo stack
            _redoStack = 0; // Clear redo stack after executing a new command
        }

        /// <summary>
        /// Undoes the last executed command and pushes it to the redo stack.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal void Undo()
        {
            if (_undoStack > 0)
            {
                _undoStack--; // Pop command from undo stack
                PenWaveRenderer.Instance.Undo();
                _redoStack++; // Push command to redo stack
            }
        }

        /// <summary>
        /// Redoes the last undone command and pushes it to the undo stack.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal void Redo()
        {
            if (_redoStack > 0)
            {
                _redoStack--; // Pop command from redo stack
                PenWaveRenderer.Instance.Redo();
                _undoStack++; // Push command to undo stack
            }
        }

        /// <summary>
        /// Determines whether an undo operation is possible.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal bool CanUndo => _undoStack > 0;

        /// <summary>
        /// Determines whether a redo operation is possible.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal bool CanRedo => _redoStack > 0;
    }
}
