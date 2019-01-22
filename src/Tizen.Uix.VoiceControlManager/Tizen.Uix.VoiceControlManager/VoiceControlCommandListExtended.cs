/*
* Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
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
using static Interop.VoiceControlManager;
using static Interop.ControlCommandExpand;

namespace Tizen.Uix.VoiceControlManager
{
    /// <summary>
    /// This Class represents the Extended Command List
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class VoiceControlCommandExtendedList : VoiceCommandList
    {
        private VoiceCommandList _cmdList;

        /// <summary>
        /// Public Constructor
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="cmdList">Voice Command List</param>
        public VoiceControlCommandExtendedList(VoiceCommandList cmdList)
        {
            _cmdList = cmdList;
        }

        /// <summary>
        /// Remove all commands from command list.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="freeCommand">The command free option ,true is to release each commands in list, false to remove command from list</param>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <exception cref="NotSupportedException">This exception can be due to not supported.</exception>
        public void RemoveAll(bool freeCommand)
        {
            ErrorCode error = VcCmdListRemoveAll(_cmdList._handle, freeCommand);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "RemoveAll Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Retrieves all commands of command list
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="type">Command Type</param>
        /// <returns>VoiceCommandList</returns>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <exception cref="NotSupportedException">This exception can be due to not supported.</exception>
        public VoiceCommandList FilterByType(CommandType type)
        {
            IntPtr filtered;
            ErrorCode error = VcCmdListFilterByType(_cmdList._handle, type, out filtered);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "RemoveAll Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }

            return new VoiceCommandList(new Interop.VoiceControlCommand.SafeCommandListHandle(filtered));
        }

    }
}
