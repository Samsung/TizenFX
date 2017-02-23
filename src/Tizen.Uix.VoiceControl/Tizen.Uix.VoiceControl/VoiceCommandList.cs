/*
* Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
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
using static Interop.VoiceControl;
using static Interop.VoiceControlCommand;

namespace Tizen.Uix.VoiceControl
{
    /// <summary>
    /// this class represents list of Voice Commands
    /// </summary>
    public class VoiceCommandList
    {
        internal SafeCommandListHandle _handle;
        private List<VoiceCommand> _list;
        private VcCmdListCb _callback;

        /// <summary>
        /// Public Constructor
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// This Exception can be due to the following reaons
        /// 1. Invalid parameter
        /// 2. Permission Denied
        /// 3. Not supported
        /// 4. Out of memory
        /// </exception>
        public VoiceCommandList()
        {
            SafeCommandListHandle handle = new SafeCommandListHandle();
            ErrorCode error = VcCmdListCreate(out handle);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "Create Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
            _handle = handle;
        }

        internal VoiceCommandList(SafeCommandListHandle handle)
        {
            _handle = handle;
        }

        /// <summary>
        /// Gets command count of list.
        /// -1 is returned in case of internal failure.
        /// </summary>
        public int GetCount
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
        /// Get current command from command list by index.
        /// null will be returned in case of Empty List
        /// </summary>
        public VoiceCommand GetCurrent
        {
            get
            {
                SafeCommandHandle current;
                ErrorCode error = VcCmdListGetCurrent(_handle, out current);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "Current Failed with error " + error);
                    return null;
                }
                current._ownership = false;
                return new VoiceCommand(current);
            }
        }

        /// <summary>
        /// Adds command to command list.
        /// </summary>
        /// <param name="command">The command</param>
        /// <exception cref="InvalidOperationException">
        /// This Exception can be due to the following reaons
        /// 1. Invalid parameter
        /// 2. Permission Denied
        /// 3. Not supported
        /// </exception>
        /// <exception cref="NullReferenceException">This will occur if the provide parameter is null</exception>
        public void Add(VoiceCommand command)
        {
            ErrorCode error = VcCmdListAdd(_handle, command._handle);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "Add Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Removes command from command list.
        /// </summary>
        /// <param name="command">The command</param>
        /// <exception cref="InvalidOperationException">
        /// This Exception can be due to the following reaons
        /// 1. Invalid parameter
        /// 2. Permission Denied
        /// 3. Not supported
        /// </exception>
        /// <exception cref="NullReferenceException">This will occur if the provide parameter is null</exception>
        public void Remove(VoiceCommand command)
        {
            ErrorCode error = VcCmdListRemove(_handle, command._handle);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "Remove Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Retrieves all commands of command list.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// This Exception can be due to the following reaons
        /// 1. Permission Denied
        /// 2. Not supported
        /// </exception>
        public IEnumerable<VoiceCommand> GetAllCommands()
        {
            _list = new List<VoiceCommand>();
            _callback = (IntPtr vcCommand, IntPtr userData) =>
            {
                SafeCommandHandle handle = new SafeCommandHandle(vcCommand);
                handle._ownership = false;
                _list.Add(new VoiceCommand(handle));
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
        /// Moves index to first command.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// This Exception can be due to the following reaons
        /// 1. List Empty
        /// 2. Permission Denied
        /// 3. Not supported
        /// </exception>
        public void First()
        {
            ErrorCode error = VcCmdListFirst(_handle);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "First Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Moves index to last command.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// This Exception can be due to the following reaons
        /// 1. List Empty
        /// 2. Permission Denied
        /// 3. Not supported
        /// </exception>
        public void Last()
        {
            ErrorCode error = VcCmdListLast(_handle);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "Last Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Moves index to next command.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// This Exception can be due to the following reaons
        /// 1. List Empty
        /// 2. List reached end
        /// 3. Permission Denied
        /// 4. Not supported
        /// </exception>
        public void Next()
        {
            ErrorCode error = VcCmdListNext(_handle);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "Next Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Moves index to previous command.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// This Exception can be due to the following reaons
        /// 1. List Empty
        /// 2. List reached end
        /// 3. Permission Denied
        /// 4. Not supported
        /// </exception>
        public void Previous()
        {
            ErrorCode error = VcCmdListPrev(_handle);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "Previous Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }
    }
}
