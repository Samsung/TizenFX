using System;

// include all custom views here which will be
namespace Tizen.NUI
{
  public class ViewRegistryHelper
  {
    static public void Initialize()
    {
       // Register all views with the type registry
       System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor (typeof(Tizen.NUI.Spin).TypeHandle);
    }
  }
}

