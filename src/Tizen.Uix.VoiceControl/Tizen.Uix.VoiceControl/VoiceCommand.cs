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
using static Interop.VoiceControl;
using static Interop.VoiceControlCommand;

namespace Tizen.Uix.VoiceControl
{
    /// <summary>
    /// Enumeration for Command Format
    /// </summary>
    public enum CommandFormat
    {
        /// <summary>
        /// fixed command format.
        /// </summary>
        Fixed = 0,
        /// <summary>
        /// fixed and variable fixed command format.
        /// </summary>
        FixedAndVFixed = 1,
        /// <summary>
        /// variable fixed and fixed command format.
        /// </summary>
        VFixedAndFixed = 2,
        /// <summary>
        /// fixed and non-fixed command format.
        /// </summary>
        FixedAndNonFixed = 3,
        /// <summary>
        /// non-fixed and fixed command format.
        /// </summary>
        NonFixedAndFixed = 4,
        /// <summary>
        /// Undefined
        /// </summary>
        Undefined = 5
    };

    /// <summary>
    /// This class represents a Voice Command
    /// </summary>
    public class VoiceCommand
    {
        internal SafeCommandHandle _handle;

        /// <summary>
        /// Public Constructor
        /// </summary>
        /// <exception cref="InvalidOperationException"> This Exception can be due to Invalid State. </exception>
        /// <exception cref="OutOfMemoryException"> This Exception can be due to Out Of Memory. </exception>
        /// <exception cref="UnauthorizedAccessException"> This Exception can be due to Permission Denied. </exception>
        /// <exception cref="NotSupportedException"> This Exception can be due to Not Supported. </exception>
        public VoiceCommand()
        {
            SafeCommandHandle handle;
            ErrorCode error = VcCmdCreate(out handle);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "Create Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
            _handle = handle;
        }

        internal VoiceCommand(SafeCommandHandle handle)
        {
            _handle = handle;
        }

        /// <summary>
        /// Gets the unfixed command.
        /// This property should be used for commands which have non-fixed format.
        /// empty string will be returned in case of some internal error
        /// </summary>
        public string UnfixedCommand
        {
            get
            {
                string unfixedCommand;
                ErrorCode error = VcCmdGetUnfixedCommand(_handle, out unfixedCommand);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "UnfixedCommand Failed with error " + error);
                    return "";
                }

                return unfixedCommand;
            }
        }

        /// <summary>
        /// Gets/Sets command type.
        /// </summary>
        /// <remarks>If you do not set the command type, the default value is Undefined. You should set type if command is valid</remarks>
        /// <exception cref="UnauthorizedAccessException"> This Exception can be due to Permission Denied. </exception>
        /// <exception cref="NotSupportedException"> This Exception can be due to Not Supported. </exception>
        public CommandType Type
        {
            get
            {
                CommandType cmdType = CommandType.Undefined;
                int type;
                ErrorCode error = VcCmdGetType(_handle, out type);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "GetType Failed with error " + error);
                    return CommandType.Undefined;
                }

                if (type != -1)
                {
                    cmdType = (CommandType)type;
                }

                return cmdType;
            }
            set
            {
                ErrorCode error = VcCmdSetType(_handle, value);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "SetType Failed with error " + error);
                }
            }
        }

        /// <summary>
        /// Gets/Sets the command format.
        /// </summary>
        /// <remarks>The default format is Fixed</remarks>
        /// <exception cref="UnauthorizedAccessException"> This Exception can be due to Permission Denied. </exception>
        /// <exception cref="NotSupportedException"> This Exception can be due to Not Supported. </exception>
        public CommandFormat Format
        {
            get
            {
                CommandFormat format;
                ErrorCode error = VcCmdGetFormat(_handle, out format);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "GetFormat Failed with error " + error);
                    return CommandFormat.Undefined;
                }

                return format;
            }
            set
            {
                ErrorCode error = VcCmdSetFormat(_handle, value);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "SetFormat Failed with error " + error);
                }
            }
        }

        /// <summary>
        /// Gets/Sets command
        /// in case of get empty string will be returned in case of some internal error
        /// </summary>
        /// <exception cref="UnauthorizedAccessException"> This Exception can be due to Permission Denied. </exception>
        /// <exception cref="NotSupportedException"> This Exception can be due to Not Supported. </exception>
        public string Command
        {
            get
            {
                string command;
                ErrorCode error = VcCmdGetCommand(_handle, out command);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "GetCommand Failed with error " + error);
                    return "";
                }

                return command;
            }
            set
            {
                ErrorCode error = VcCmdSetCommand(_handle, value);
                if (error != ErrorCode.None)
                {
                    Log.Error(LogTag, "SetCommand Failed with error " + error);
                }
            }
        }
    }
}
