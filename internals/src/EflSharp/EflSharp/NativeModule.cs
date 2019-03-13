using System;

namespace Efl { namespace Eo {

public partial class NativeModule : IDisposable
{
    private Lazy<IntPtr> module;

    public NativeModule(string libName)
    {
        module = new Lazy<IntPtr>
            (() =>
             {
                 return LoadLibrary(libName);
             });
    }

    public IntPtr Module
    {
        get
        {
            return module.Value;
        }
    }

    public void Dispose()
    {
        UnloadLibrary(module.Value);
        module = null;
    }
}

} }
