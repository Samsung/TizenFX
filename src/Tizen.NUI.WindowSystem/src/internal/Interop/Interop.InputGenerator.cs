using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI.WindowSystem
{
    internal static partial class Interop
    {
        internal static partial class InputGenerator
        {
            const string lib = "libcapi-ui-efl-util.so.0";

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "efl_util_input_initialize_generator")]
            internal static extern IntPtr Init(int devType);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "efl_util_input_initialize_generator_with_name")]
            internal static extern IntPtr InitWithName(int devType, string devName);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "efl_util_input_initialize_generator_with_sync")]
            internal static extern IntPtr SyncInit(int devType, string devName);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "efl_util_input_deinitialize_generator")]
            internal static extern ErrorCode Deinit(IntPtr inputGenHandler);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "efl_util_input_generate_key")]
            internal static extern ErrorCode GenerateKey(IntPtr inputGenHandler, string keyName, int pressed);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "efl_util_input_generate_pointer")]
            internal static extern ErrorCode GeneratePointer(IntPtr inputGenHandler, int buttons, int pointerType, int x, int y);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "efl_util_input_generate_wheel")]
            internal static extern ErrorCode GenerateWheel(IntPtr inputGenHandler, int wheelType, int value);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "efl_util_input_generate_touch")]
            internal static extern ErrorCode GenerateTouch(IntPtr inputGenHandler, int idx, int touchType, int x, int y);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "efl_util_input_generate_touch_axis")]
            internal static extern ErrorCode GenerateTouchAxis(IntPtr inputGenHandler, int idx, int touchType, int x, int y, double radius_x, double radius_y, double pressure, double angle, double palm);

            // Enumeration of input device types.
            // The device type may be used overlapped.
            internal enum DeviceType
            {
                None = 0x0,
                Touchscreen = (1 << 0),
                Keyboard = (1 << 1),
                Pointer = (1 << 2),
                All = Touchscreen | Keyboard,   // Keyboard and Touchscreen
            }

            // Enumeration of touch event types
            internal enum TouchType
            {
                None,
                Begin,
                Update,
                End,
            }

            // Enumeration of pointer event types
            internal enum PointerType
            {
                Down,
                Up,
                Move,
            }

            // Enumeration of pointer wheel event types
            internal enum PointerWheelType
            {
                Vertical,
                Horizontal,
            }

            private const int ErrorTzsh = -0x02860000;

            internal enum ErrorCode
            {
                None = Tizen.Internals.Errors.ErrorCode.None,                            // Successful
                OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory,              // Out of memory
                InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,    // Invalid parameter
                InvalidOperation = Tizen.Internals.Errors.ErrorCode.InvalidOperation,    // Invalid operation
                PermissionDenied = Tizen.Internals.Errors.ErrorCode.PermissionDenied,    // Permission denied
                NotSupported = Tizen.Internals.Errors.ErrorCode.NotSupported,            // NOT supported
                NoService = ErrorTzsh | 0x01,                                            // Service does not exist
            }
        }
    }
}
