using System;
using System.Runtime.InteropServices;

namespace Tizen.WindowSystem
{
    internal static partial class Interop
    {
        internal static partial class InputGenerator
        {
            const string lib = "libtizen-core-wl.so.0";

            [DllImport(lib, EntryPoint = "tizen_core_wl_input_generator_create")]
            internal static extern int Create(IntPtr display, InputGeneratorDevices devType, out IntPtr generator);

            [DllImport(lib, EntryPoint = "tizen_core_wl_input_generator_create_with_name")]
            internal static extern int CreateWithName(IntPtr display, InputGeneratorDevices devType, string devName, out IntPtr generator);

            [DllImport(lib, EntryPoint = "tizen_core_wl_input_generator_create_with_sync")]
            internal static extern int CreateWithSync(IntPtr display, InputGeneratorDevices devType, string devName, out IntPtr generator);

            [DllImport(lib, EntryPoint = "tizen_core_wl_input_generator_destroy")]
            internal static extern int Destroy(IntPtr generator);

            [DllImport(lib, EntryPoint = "tizen_core_wl_input_generator_generate_key")]
            internal static extern int GenerateKey(SafeHandles.InputGeneratorHandle generator, string keyName, [MarshalAs(UnmanagedType.I1)] bool pressed);

            [DllImport(lib, EntryPoint = "tizen_core_wl_input_generator_generate_pointer")]
            internal static extern int GeneratePointer(SafeHandles.InputGeneratorHandle generator, int buttons, int pointerType, int x, int y);

            [DllImport(lib, EntryPoint = "tizen_core_wl_input_generator_generate_wheel")]
            internal static extern int GenerateWheel(SafeHandles.InputGeneratorHandle generator, WheelDirection wheelType, int value);

            [DllImport(lib, EntryPoint = "tizen_core_wl_input_generator_generate_touch")]
            internal static extern int GenerateTouch(SafeHandles.InputGeneratorHandle generator, int idx, int touchType, int x, int y);

            [DllImport(lib, EntryPoint = "tizen_core_wl_input_generator_generate_touch_with_axis")]
            internal static extern int GenerateTouchAxis(SafeHandles.InputGeneratorHandle generator, int idx, int touchType, int x, int y, double radius_x, double radius_y, double pressure, double angle, double palm);

            internal enum ErrorCode
            {
                None = Tizen.Internals.Errors.ErrorCode.None,                            // Successful
                OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory,              // Out of memory
                InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,    // Invalid parameter
                NotSupported = Tizen.Internals.Errors.ErrorCode.NotSupported,            // NOT supported
                PermissionDenied = Tizen.Internals.Errors.ErrorCode.PermissionDenied,    // Permission denied
                NotConnected = -0x02000000 | 0xA000 | 0x01,                              // No connection to display server
            }
        }
    }
}
