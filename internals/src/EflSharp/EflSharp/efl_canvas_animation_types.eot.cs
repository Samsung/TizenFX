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
      var tmp = (AnimationPlayerEventRunning_StructInternal)Marshal.PtrToStructure(ptr, typeof(AnimationPlayerEventRunning_StructInternal));
      return AnimationPlayerEventRunning_StructConversion.ToManaged(tmp);
   }
}
///<summary>Internal wrapper for struct AnimationPlayerEventRunning.</summary>
[StructLayout(LayoutKind.Sequential)]
public struct AnimationPlayerEventRunning_StructInternal
{
internal IntPtr field;
   ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
   public static implicit operator AnimationPlayerEventRunning(AnimationPlayerEventRunning_StructInternal struct_)
   {
      return AnimationPlayerEventRunning_StructConversion.ToManaged(struct_);
   }
   ///<summary>Implicit conversion to the managed representation.</summary>
   public static implicit operator AnimationPlayerEventRunning_StructInternal(AnimationPlayerEventRunning struct_)
   {
      return AnimationPlayerEventRunning_StructConversion.ToInternal(struct_);
   }
}
/// <summary>Conversion class for struct AnimationPlayerEventRunning</summary>
public static class AnimationPlayerEventRunning_StructConversion
{
   internal static AnimationPlayerEventRunning_StructInternal ToInternal(AnimationPlayerEventRunning _external_struct)
   {
      var _internal_struct = new AnimationPlayerEventRunning_StructInternal();


      return _internal_struct;
   }

   internal static AnimationPlayerEventRunning ToManaged(AnimationPlayerEventRunning_StructInternal _internal_struct)
   {
      var _external_struct = new AnimationPlayerEventRunning();


      return _external_struct;
   }

}
} } 
