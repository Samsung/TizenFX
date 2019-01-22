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
    /// This Class represents the Extended Command
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class VoiceControlCommandExtended : VoiceCommand
    {
        private VoiceCommand _cmd;

        /// <summary>
        /// Public Constructor
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="cmd">Voice Command</param>
        public VoiceControlCommandExtended(VoiceCommand cmd)
        {
            _cmd = cmd;
        }

        /// <summary>
        /// Gets or Sets command domain.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <exception cref="NotSupportedException">This exception can be due to not supported.</exception>
        public int Domain
        {
            get
            {
                int domain;

                ErrorCode error = VcCmdGetDomain(_cmd._handle, out domain);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "GetDomain Failed with error " + error);
                    return 0;
                }

                return domain;
            }
            set
            {
                ErrorCode error = VcCmdSetDomain(_cmd._handle, value);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "SetDomain Failed with error " + error);
                    throw ExceptionFactory.CreateException(error);
                }
            }
        }

        /// <summary>
        /// Gets or Sets pid.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public int Pid
        {
            get
            {
                int Pid;

                ErrorCode error = VcCmdGetPid(_cmd._handle, out Pid);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "GetPid Failed with error " + error);
                    return 0;
                }

                return Pid;
            }
            set
            {
                ErrorCode error = VcCmdSetPid(_cmd._handle, value);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "SetPid Failed with error " + error);
                    throw ExceptionFactory.CreateException(error);
                }
            }
        }

        /// <summary>
        /// Gets nlu json data.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string GetNluJson
        {
            get
            {
                string NluJson;

                ErrorCode error = VcCmdGetNluJson(_cmd._handle, out NluJson);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "GetNluJson Failed with error " + error);
                    return "";
                }

                return NluJson;
            }
        }

        /// <summary>
        /// Remove all commands from command list.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="list">The command list</param>
        /// <param name="freeCommand">The command free option ,true is to release each commands in list, false to remove command from list</param>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <exception cref="NotSupportedException">This exception can be due to not supported.</exception>
        /// <exception cref="NullReferenceException">This will occur if the provided parameter is null.</exception>
        public void RemoveAll(VoiceCommandList list, bool freeCommand)
        {
            ErrorCode error = VcCmdListRemoveAll(list._handle, freeCommand);
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
        /// <param name="original">The command list</param>
        /// <param name="type">Command Type</param>
        /// <returns>VoiceCommandList</returns>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <exception cref="NotSupportedException">This exception can be due to not supported.</exception>
        /// <exception cref="NullReferenceException">This will occur if the provided parameter is null.</exception>
        public VoiceCommandList FilterByType(VoiceCommandList original, CommandType type)
        {
            IntPtr filtered;
            ErrorCode error = VcCmdListFilterByType(original._handle, type, out filtered);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "RemoveAll Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }

            return new VoiceCommandList(new Interop.VoiceControlCommand.SafeCommandListHandle(filtered));
        }

        /// <summary>
        /// Sets unfixed command.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="command">The command</param>
        /// <exception cref="ArgumentException">This exception can be due to an invalid parameter.</exception>
        /// <exception cref="NotSupportedException">This exception can be due to not supported.</exception>
        public void SetUnfixedCommand(string command)
        {
            ErrorCode error = VcCmdSetUnfixedCommand(_cmd._handle, command);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "SetUnfixedCommand Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Gets the datetime value from the setence.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="text">The sentence to analyze</param>
        /// <param name="result">The datetime value in the sentence</param>
        /// <param name="remain">Remained text except time</param>
        /// <exception cref="InvalidOperationException">This exception can be due to operation failure.</exception>
        /// <exception cref="ArgumentException">This exception can be due to an invalid parameter.</exception>
        /// <exception cref="OutOfMemoryException">This exception can be due to out of memory.</exception>
        public void GetDatetime(string text, out int result, out string remain)
        {
            ErrorCode error = VcCmdGetDatetime(text, out result, out remain);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "GetDatetime Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }
    }
}
