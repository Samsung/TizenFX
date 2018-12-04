/*
* Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
*
* Licensed under the Apache License, Version 2.0 (the License);
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an AS IS BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/

using System;
using System.Collections.Generic;
using static Interop.VoiceControlWidget;
using static Interop.VoiceControlCommand;

namespace Tizen.Uix.VoiceControlWidget
{
    /// <summary>
    /// This class represents a list of the voice commands.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class VoiceCommandList
    {
        internal SafeCommandListHandle _handle;
        private List<VoiceCommand> _list;
        private VcCmdListCb _callback;
        private int _index;

        /// <summary>
        /// The public constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="OutOfMemoryException">This exception can be due to out of memory.</exception>
        /// <exception cref="ArgumentException">This exception can be due to an invalid parameter.</exception>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <exception cref="NotSupportedException">This exception can be due to not supported.</exception>
        public VoiceCommandList()
        {
            SafeCommandListHandle handle;
            ErrorCode error = VcCmdListCreate(out handle);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "Create Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
            _handle = handle;
            _list = new List<VoiceCommand>();
            _index = 0;
        }

        internal VoiceCommandList(SafeCommandListHandle handle)
        {
            _handle = handle;
            _index = 0;

            _list = new List<VoiceCommand>();
            _callback = (IntPtr vcCommand, IntPtr userData) =>
            {
                SafeCommandHandle cmdHandle = new SafeCommandHandle(vcCommand);
                cmdHandle._ownership = false;
                _list.Add(new VoiceCommand(cmdHandle));
                return true;
            };
            ErrorCode error = VcCmdListForeachCommands(_handle, _callback, IntPtr.Zero);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "GetAllCommands Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Gets a command count of the list.
        /// -1 is returned in case of an internal failure.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>
        /// Command count of the list.
        /// </value>
        public int Count
        {
            get
            {
                int count;
                ErrorCode error = VcCmdListGetCount(_handle, out count);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "Count Failed with error " + error);
                    return -1;
                }

                return count;
            }
        }

        /// <summary>
        /// Gets the current command from the command list by index.
        /// Null will be returned in case of an empty list.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>
        /// Current command from the command list.
        /// </value>
        public VoiceCommand Current
        {
            get
            {
                SafeCommandHandle current;
                ErrorCode error = VcCmdListGetCurrent(_handle, out current);
                if (ErrorCode.None != error)
                {
                    Log.Error(LogTag, "Current Failed with error " + error);
                    return null;
                }

                current._ownership = false;
                return _list[_index];
            }
        }

        /// <summary>
        /// Adds a command to the command list.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="command">The command</param>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <exception cref="NotSupportedException">This exception can be due to not supported.</exception>
        /// <exception cref="NullReferenceException">This will occur if the provided parameter is null.</exception>
        public void Add(VoiceCommand command)
        {
            ErrorCode error = VcCmdListAdd(_handle, command._handle);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "Add Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }

            _list.Add(command);
        }

        /// <summary>
        /// Removes a command from the command list.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="command">The command</param>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <exception cref="NotSupportedException">This exception can be due to not supported.</exception>
        /// <exception cref="NullReferenceException">This will occur if the provided parameter is null.</exception>
        public void Remove(VoiceCommand command)
        {
            ErrorCode error = VcCmdListRemove(_handle, command._handle);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "Remove Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }

            _list.Remove(command);
        }

        /// <summary>
        /// Retrieves all commands from the command list.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <exception cref="NotSupportedException">This exception can be due to not supported.</exception>
        public IEnumerable<VoiceCommand> GetAllCommands()
        {
            _callback = (IntPtr vcCommand, IntPtr userData) =>
            {
                if (IntPtr.Zero == vcCommand) {
                    Log.Error(LogTag, "Invalid command pointer");
                    return false;
                }
                return true;
            };
            ErrorCode error = VcCmdListForeachCommands(_handle, _callback, IntPtr.Zero);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "GetAllCommands Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }

            return _list;
        }

        /// <summary>
        /// Moves an index to the first command.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="InvalidOperationException">This exception can be due to list empty.</exception>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <exception cref="NotSupportedException">This exception can be due to not supported.</exception>
        public void First()
        {
            ErrorCode error = VcCmdListFirst(_handle);
            if (ErrorCode.None != error)
            {
                Log.Error(LogTag, "First Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
            _index = 0;
        }

        /// <summary>
        /// Moves an index to the last command.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="InvalidOperationException">This exception can be due to list empty.</exception>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <exception cref="NotSupportedException">This exception can be due to not supported.</exception>
        public void Last()
        {
            ErrorCode error = VcCmdListLast(_handle);
            if (ErrorCode.None != error)
            {
                Log.Error(LogTag, "Last Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
            _index = Count - 1;
        }

        /// <summary>
        /// Moves an index to the next command.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="InvalidOperationException">This exception can be due to list empty or list end.</exception>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <exception cref="NotSupportedException">This exception can be due to not supported.</exception>
        public void Next()
        {
            ErrorCode error = VcCmdListNext(_handle);
            if (ErrorCode.None != error)
            {
                Log.Error(LogTag, "Next Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
           _index++;
        }

        /// <summary>
        /// Moves an index to the previous command.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="InvalidOperationException">This exception can be due to list empty or list end.</exception>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <exception cref="NotSupportedException">This exception can be due to not supported.</exception>
        public void Previous()
        {
            ErrorCode error = VcCmdListPrev(_handle);
            if (ErrorCode.None != error)
            {
                Log.Error(LogTag, "Previous Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
            _index--;
        }
    }
}
