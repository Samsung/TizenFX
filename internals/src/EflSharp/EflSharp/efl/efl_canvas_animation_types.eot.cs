#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Canvas { 
/// <summary>Animation repeat mode</summary>
public enum AnimationRepeatMode
{
/// <summary>Restart animation when the animation ends.</summary>
Restart = 0,
/// <summary>Reverse animation when the animation ends.</summary>
Reverse = 1,
}
} } 
namespace Efl { namespace Canvas { 
/// <summary>Information of event running</summary>
[StructLayout(LayoutKind.Sequential)]
public struct AnimationPlayerEventRunning
{
    ///<summary>Placeholder field</summary>
    public IntPtr field;
    public static implicit operator AnimationPlayerEventRunning(IntPtr ptr)
    {
        var tmp = (AnimationPlayerEventRunning.NativeStruct)Marshal.PtrToStructure(ptr, typeof(AnimationPlayerEventRunning.NativeStruct));
        return tmp;
    }

    ///<summary>Internal wrapper for struct AnimationPlayerEventRunning.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        internal IntPtr field;
        ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator AnimationPlayerEventRunning.NativeStruct(AnimationPlayerEventRunning _external_struct)
        {
            var _internal_struct = new AnimationPlayerEventRunning.NativeStruct();
            return _internal_struct;
        }

        ///<summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator AnimationPlayerEventRunning(AnimationPlayerEventRunning.NativeStruct _internal_struct)
        {
            var _external_struct = new AnimationPlayerEventRunning();
            return _external_struct;
        }

    }

}

} } 
