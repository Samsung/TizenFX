using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.WindowSystem
{
    internal static partial class Interop
    {
        internal static partial class InputGenerator
        {
            const string lib = "libcapi-ui-efl-util.so.0";

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "efl_util_input_initialize_generator")]
            internal static extern SafeHandles.InputGeneratorHandle Init(InputGeneratorDevices devType);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "efl_util_input_initialize_generator_with_name")]
            internal static extern SafeHandles.InputGeneratorHandle InitWithName(InputGeneratorDevices devType, string devName);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "efl_util_input_initialize_generator_with_sync")]
            internal static extern SafeHandles.InputGeneratorHandle SyncInit(InputGeneratorDevices devType, string devName);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "efl_util_input_deinitialize_generator")]
            internal static extern ErrorCode Deinit(IntPtr inputGenHandler);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "efl_util_input_generate_key")]
            internal static extern ErrorCode GenerateKey(SafeHandles.InputGeneratorHandle inputGenHandler, string keyName, int pressed);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "efl_util_input_generate_pointer")]
            internal static extern ErrorCode GeneratePointer(SafeHandles.InputGeneratorHandle inputGenHandler, int buttons, PointerAction pointerType, int x, int y);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "efl_util_input_generate_wheel")]
            internal static extern ErrorCode GenerateWheel(SafeHandles.InputGeneratorHandle inputGenHandler, WheelDirection wheelType, int value);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "efl_util_input_generate_touch")]
            internal static extern ErrorCode GenerateTouch(SafeHandles.InputGeneratorHandle inputGenHandler, int idx, TouchAction touchType, int x, int y);

            [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "efl_util_input_generate_touch_axis")]
            internal static extern ErrorCode GenerateTouchAxis(SafeHandles.InputGeneratorHandle inputGenHandler, int idx, TouchAction touchType, int x, int y, double radius_x, double radius_y, double pressure, double angle, double palm);

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
