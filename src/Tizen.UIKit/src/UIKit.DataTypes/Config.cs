#pragma warning disable 1591

using System;
using System.Runtime.InteropServices;

namespace UIKit
{

namespace DataTypes
{

/// <summary>
/// Manage the initialization and cleanup for eina.
///
/// Since EFL 1.23.
/// </summary>
public class Config
{
    [DllImport(UIKit.Libs.Eina)] private static extern int eina_init();
    [DllImport(UIKit.Libs.Eina)] private static extern int eina_shutdown();

    public static void Init()
    {
        if (eina_init() == 0)
        {
            throw (new UIKit.UIKitException("Failed to initialize Eina"));
        }
    }

    public static int Shutdown()
    {
        return eina_shutdown();
    }

}

/// <summary>
/// Wrapper class for pointers that need some cleanup afterwards like strings
///
/// Since EFL 1.23.
/// </summary>
public class DisposableIntPtr : IDisposable
{
    public IntPtr Handle { get; set; }
    private bool ShouldFree;
    private bool Disposed;

    /// <summary>Wraps a new ptr what will be freed based on the
    /// value of shouldFree</summary>
    public DisposableIntPtr(IntPtr ptr, bool shouldFree = false)
    {
        Handle = ptr;
        ShouldFree = shouldFree;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!Disposed && ShouldFree)
        {
            MemoryNative.Free(this.Handle);
        }

        Disposed = true;
    }

    ~DisposableIntPtr()
    {
        Dispose(false);
    }
}

}

}
