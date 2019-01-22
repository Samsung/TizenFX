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
using static Interop.VoiceControlCommand;

namespace Tizen.Uix.VoiceControlManager
{
    /// <summary>
    /// Enumeration for the command format.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public enum CommandFormat
    {
        /// <summary>
        /// The fixed command format.
        /// </summary>
        Fixed = 0,
        /// <summary>
        /// The fixed and variable fixed command format.
        /// </summary>
        FixedAndVFixed = 1,
        /// <summary>
        /// The variable fixed and fixed command format.
        /// </summary>
        VFixedAndFixed = 2,
        /// <summary>
        /// The fixed and non-fixed command format.
        /// </summary>
        FixedAndNonFixed = 3,
        /// <summary>
        /// The non-fixed and fixed command format.
        /// </summary>
        NonFixedAndFixed = 4,
        /// <summary>
        /// The action command
        /// </summary>
        Action = 5,
        /// <summary>
        /// The partial matched command
        /// </summary>
        Partial = 6,
        /// <summary>
        /// Undefined
        /// </summary>
        Undefined = -1
    };

    /// <summary>
    /// This class represents a voice command.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class VoiceCommand
    {
        internal SafeCommandHandle _handle;

        /// <summary>
        /// The public constructor.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <exception cref="InvalidOperationException">This exception can be due to an invalid state.</exception>
        /// <exception cref="OutOfMemoryException">This exception can be due to out Of memory.</exception>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <exception cref="NotSupportedException">This exception can be due to not supported.</exception>
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
        /// An empty string will be returned in case of some internal error.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
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
        /// Gets or sets the command type.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <remarks>If you do not set the command type, the default value is undefined. You should set the type if the command is valid.</remarks>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <exception cref="NotSupportedException">This exception can be due to not supported.</exception>
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
        /// Gets or sets the command format.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <remarks>The default format is Fixed.</remarks>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <exception cref="NotSupportedException">This exception can be due to not supported.</exception>
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
        /// Gets or sets the command.
        /// A get empty string will be returned in case of some internal error.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <exception cref="NotSupportedException">This exception can be due to not supported.</exception>
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
