#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { 
/// <summary>This type is a alias for struct tm. It is intended to be a standard way to reference it in .eo files.
/// 1.18</summary>
[StructLayout(LayoutKind.Sequential)]
public struct Time
{
   /// <summary>Seconds.	[0-60] (1 leap second)</summary>
   public  int Tm_sec;
   /// <summary>Minutes.	[0-59]</summary>
   public  int Tm_min;
   /// <summary>Hours.	[0-23]</summary>
   public  int Tm_hour;
   /// <summary>Day.		[1-31]</summary>
   public  int Tm_mday;
   /// <summary>Month.	[0-11]</summary>
   public  int Tm_mon;
   /// <summary>Year	- 1900.</summary>
   public  int Tm_year;
   /// <summary>Day of week.	[0-6]</summary>
   public  int Tm_wday;
   /// <summary>Days in year.[0-365]</summary>
   public  int Tm_yday;
   /// <summary>DST. [-1/0/1]</summary>
   public  int Tm_isdst;
   ///<summary>Constructor for Time.</summary>
   public Time(
       int Tm_sec=default( int),
       int Tm_min=default( int),
       int Tm_hour=default( int),
       int Tm_mday=default( int),
       int Tm_mon=default( int),
       int Tm_year=default( int),
       int Tm_wday=default( int),
       int Tm_yday=default( int),
       int Tm_isdst=default( int)   )
   {
      this.Tm_sec = Tm_sec;
      this.Tm_min = Tm_min;
      this.Tm_hour = Tm_hour;
      this.Tm_mday = Tm_mday;
      this.Tm_mon = Tm_mon;
      this.Tm_year = Tm_year;
      this.Tm_wday = Tm_wday;
      this.Tm_yday = Tm_yday;
      this.Tm_isdst = Tm_isdst;
   }
public static implicit operator Time(IntPtr ptr)
   {
      var tmp = (Time_StructInternal)Marshal.PtrToStructure(ptr, typeof(Time_StructInternal));
      return Time_StructConversion.ToManaged(tmp);
   }
}
///<summary>Internal wrapper for struct Time.</summary>
[StructLayout(LayoutKind.Sequential)]
public struct Time_StructInternal
{
   
   public  int Tm_sec;
   
   public  int Tm_min;
   
   public  int Tm_hour;
   
   public  int Tm_mday;
   
   public  int Tm_mon;
   
   public  int Tm_year;
   
   public  int Tm_wday;
   
   public  int Tm_yday;
   
   public  int Tm_isdst;
   ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
   public static implicit operator Time(Time_StructInternal struct_)
   {
      return Time_StructConversion.ToManaged(struct_);
   }
   ///<summary>Implicit conversion to the managed representation.</summary>
   public static implicit operator Time_StructInternal(Time struct_)
   {
      return Time_StructConversion.ToInternal(struct_);
   }
}
/// <summary>Conversion class for struct Time</summary>
public static class Time_StructConversion
{
   internal static Time_StructInternal ToInternal(Time _external_struct)
   {
      var _internal_struct = new Time_StructInternal();

      _internal_struct.Tm_sec = _external_struct.Tm_sec;
      _internal_struct.Tm_min = _external_struct.Tm_min;
      _internal_struct.Tm_hour = _external_struct.Tm_hour;
      _internal_struct.Tm_mday = _external_struct.Tm_mday;
      _internal_struct.Tm_mon = _external_struct.Tm_mon;
      _internal_struct.Tm_year = _external_struct.Tm_year;
      _internal_struct.Tm_wday = _external_struct.Tm_wday;
      _internal_struct.Tm_yday = _external_struct.Tm_yday;
      _internal_struct.Tm_isdst = _external_struct.Tm_isdst;

      return _internal_struct;
   }

   internal static Time ToManaged(Time_StructInternal _internal_struct)
   {
      var _external_struct = new Time();

      _external_struct.Tm_sec = _internal_struct.Tm_sec;
      _external_struct.Tm_min = _internal_struct.Tm_min;
      _external_struct.Tm_hour = _internal_struct.Tm_hour;
      _external_struct.Tm_mday = _internal_struct.Tm_mday;
      _external_struct.Tm_mon = _internal_struct.Tm_mon;
      _external_struct.Tm_year = _internal_struct.Tm_year;
      _external_struct.Tm_wday = _internal_struct.Tm_wday;
      _external_struct.Tm_yday = _internal_struct.Tm_yday;
      _external_struct.Tm_isdst = _internal_struct.Tm_isdst;

      return _external_struct;
   }

}
} 
namespace Efl { 
/// <summary>This type describes the version of EFL with an optional variant.
/// This may be used to query the current running version of EFL. Or it can be passed by applications at startup time to inform EFL of the version a certain application was built for.
/// 1.18</summary>
[StructLayout(LayoutKind.Sequential)]
public struct Version
{
   /// <summary>Major component of the version (&gt;= 1).</summary>
   public  int Major;
   /// <summary>Minor component of the version (&gt;= 0).</summary>
   public  int Minor;
   /// <summary>Micro component of the version (&gt;= 0).</summary>
   public  int Micro;
   /// <summary>Revision component of the version (&gt;= 0).</summary>
   public  int Revision;
   /// <summary>Special version string for this build of EFL, <c>null</c> for vanilla (upstream) EFL. Contains <c>EFL_VERSION_FLAVOR</c>.</summary>
   public  System.String Flavor;
   /// <summary>Contains <c>EFL_BUILD_ID</c>.</summary>
   public  System.String Build_id;
   ///<summary>Constructor for Version.</summary>
   public Version(
       int Major=default( int),
       int Minor=default( int),
       int Micro=default( int),
       int Revision=default( int),
       System.String Flavor=default( System.String),
       System.String Build_id=default( System.String)   )
   {
      this.Major = Major;
      this.Minor = Minor;
      this.Micro = Micro;
      this.Revision = Revision;
      this.Flavor = Flavor;
      this.Build_id = Build_id;
   }
public static implicit operator Version(IntPtr ptr)
   {
      var tmp = (Version_StructInternal)Marshal.PtrToStructure(ptr, typeof(Version_StructInternal));
      return Version_StructConversion.ToManaged(tmp);
   }
}
///<summary>Internal wrapper for struct Version.</summary>
[StructLayout(LayoutKind.Sequential)]
public struct Version_StructInternal
{
   
   public  int Major;
   
   public  int Minor;
   
   public  int Micro;
   
   public  int Revision;
///<summary>Internal wrapper for field Flavor</summary>
public System.IntPtr Flavor;
///<summary>Internal wrapper for field Build_id</summary>
public System.IntPtr Build_id;
   ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
   public static implicit operator Version(Version_StructInternal struct_)
   {
      return Version_StructConversion.ToManaged(struct_);
   }
   ///<summary>Implicit conversion to the managed representation.</summary>
   public static implicit operator Version_StructInternal(Version struct_)
   {
      return Version_StructConversion.ToInternal(struct_);
   }
}
/// <summary>Conversion class for struct Version</summary>
public static class Version_StructConversion
{
   internal static Version_StructInternal ToInternal(Version _external_struct)
   {
      var _internal_struct = new Version_StructInternal();

      _internal_struct.Major = _external_struct.Major;
      _internal_struct.Minor = _external_struct.Minor;
      _internal_struct.Micro = _external_struct.Micro;
      _internal_struct.Revision = _external_struct.Revision;
      _internal_struct.Flavor = Eina.MemoryNative.StrDup(_external_struct.Flavor);
      _internal_struct.Build_id = Eina.MemoryNative.StrDup(_external_struct.Build_id);

      return _internal_struct;
   }

   internal static Version ToManaged(Version_StructInternal _internal_struct)
   {
      var _external_struct = new Version();

      _external_struct.Major = _internal_struct.Major;
      _external_struct.Minor = _internal_struct.Minor;
      _external_struct.Micro = _internal_struct.Micro;
      _external_struct.Revision = _internal_struct.Revision;
      _external_struct.Flavor = Eina.StringConversion.NativeUtf8ToManagedString(_internal_struct.Flavor);
      _external_struct.Build_id = Eina.StringConversion.NativeUtf8ToManagedString(_internal_struct.Build_id);

      return _external_struct;
   }

}
} 
namespace Efl { 
/// <summary>This type describes an observable touple</summary>
[StructLayout(LayoutKind.Sequential)]
public struct ObservableTuple
{
   /// <summary>Touple key</summary>
   public  System.String Key;
   /// <summary>Touple data</summary>
   public Eina.Iterator<Efl.Observer> Data;
   ///<summary>Constructor for ObservableTuple.</summary>
   public ObservableTuple(
       System.String Key=default( System.String),
      Eina.Iterator<Efl.Observer> Data=default(Eina.Iterator<Efl.Observer>)   )
   {
      this.Key = Key;
      this.Data = Data;
   }
public static implicit operator ObservableTuple(IntPtr ptr)
   {
      var tmp = (ObservableTuple_StructInternal)Marshal.PtrToStructure(ptr, typeof(ObservableTuple_StructInternal));
      return ObservableTuple_StructConversion.ToManaged(tmp);
   }
}
///<summary>Internal wrapper for struct ObservableTuple.</summary>
[StructLayout(LayoutKind.Sequential)]
public struct ObservableTuple_StructInternal
{
///<summary>Internal wrapper for field Key</summary>
public System.IntPtr Key;
   
   public  System.IntPtr Data;
   ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
   public static implicit operator ObservableTuple(ObservableTuple_StructInternal struct_)
   {
      return ObservableTuple_StructConversion.ToManaged(struct_);
   }
   ///<summary>Implicit conversion to the managed representation.</summary>
   public static implicit operator ObservableTuple_StructInternal(ObservableTuple struct_)
   {
      return ObservableTuple_StructConversion.ToInternal(struct_);
   }
}
/// <summary>Conversion class for struct ObservableTuple</summary>
public static class ObservableTuple_StructConversion
{
   internal static ObservableTuple_StructInternal ToInternal(ObservableTuple _external_struct)
   {
      var _internal_struct = new ObservableTuple_StructInternal();

      _internal_struct.Key = Eina.MemoryNative.StrDup(_external_struct.Key);
      _internal_struct.Data = _external_struct.Data.Handle;

      return _internal_struct;
   }

   internal static ObservableTuple ToManaged(ObservableTuple_StructInternal _internal_struct)
   {
      var _external_struct = new ObservableTuple();

      _external_struct.Key = Eina.StringConversion.NativeUtf8ToManagedString(_internal_struct.Key);
      _external_struct.Data = new Eina.Iterator<Efl.Observer>(_internal_struct.Data, false, false);

      return _external_struct;
   }

}
} 
