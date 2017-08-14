using System;
using Tizen.NUI;


namespace DatePickerUsingJson
{
  public class ViewRegistryHelper
  {
    static public void Initialize()
    {
       // Register all views with the type registry
       System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor (typeof(Spin).TypeHandle);
    }
  }
}

