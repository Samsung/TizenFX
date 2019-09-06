using System;

namespace Efl
{

namespace Eo
{

///<summary>Wraps a native module that was opened with dlopen/LoadLibrary.</summary>
public partial class NativeModule : IDisposable
{
    private Lazy<IntPtr> module;

    ///<summary>Lazily tries to load the module with the given name.</summary>
    ///<param name="libName">The name of the module to load.</param>
    public NativeModule(string libName)
    {
        module = new Lazy<IntPtr>
            (() =>
             {
                 return LoadLibrary(libName);
             });
    }

    ///<summary>The module that was loaded.</summary>
    public IntPtr Module
    {
        get
        {
            return module.Value;
        }
    }

    ///<summary>Unload and released the handle to the wrapped module.</summary>
    public void Dispose()
    {
        UnloadLibrary(module.Value);
        module = null;
    }
}

}

}
