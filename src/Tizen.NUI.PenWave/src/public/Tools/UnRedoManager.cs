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
    public class UnRedoManager
    {
        // Stacks to store undo and redo commands
        private readonly Stack<ICommand> undoStack = new Stack<ICommand>();
        private readonly Stack<ICommand> redoStack = new Stack<ICommand>();

        /// <summary>
        /// Executes a command and clears the redo stack.
        /// </summary>
        /// <param name="command">The command to be executed.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Execute(ICommand command)
        {
            command.Execute();
            undoStack.Push(command);
            redoStack.Clear(); // Clear redo stack after executing a new command
        }

        /// <summary>
        /// Undoes the last executed command and pushes it to the redo stack.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Undo()
        {
            if (undoStack.Count > 0)
            {
                ICommand command = undoStack.Pop();
                PenWave.Instance.Undo();
                redoStack.Push(command);
            }
        }

        /// <summary>
        /// Redoes the last undone command and pushes it to the undo stack.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Redo()
        {
            if (redoStack.Count > 0)
            {
                ICommand command = redoStack.Pop();
                PenWave.Instance.Redo();
                undoStack.Push(command);
            }
        }

        /// <summary>
        /// Determines whether an undo operation is possible.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool CanUndo => undoStack.Count > 0;

        /// <summary>
        /// Determines whether a redo operation is possible.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool CanRedo => redoStack.Count > 0;
    }
}
