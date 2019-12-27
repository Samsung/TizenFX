/*
 * Copyright 2019 by its authors. See AUTHORS.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
#pragma warning disable 1591

using System;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace CoreUI.DataTypes
{

/// <summary>
/// Manage the initialization and cleanup for eina.
/// </summary>
/// <since_tizen> 6 </since_tizen>
public static class Config
{
    [DllImport(CoreUI.Libs.Eina)] private static extern int eina_init();
    [DllImport(CoreUI.Libs.Eina)] private static extern int eina_shutdown();

    /// <summary>
    /// Initialize the Eina library.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public static void Init()
    {
        if (eina_init() == 0)
        {
            throw (new CoreUI.CoreUIException("Failed to initialize Eina"));
        }
    }

    /// <summary>
    /// Finalize the Eina library.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public static int Shutdown()
    {
        return eina_shutdown();
    }

}

/// <summary>
/// Wrapper class for pointers that need some cleanup afterwards like strings
/// </summary>
/// <since_tizen> 6 </since_tizen>
public class DisposableIntPtr : IDisposable
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public IntPtr Handle { get; set; }
    private bool ShouldFree;
    private bool Disposed;

    /// <summary>Wraps a new ptr what will be freed based on the
    /// value of shouldFree
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public DisposableIntPtr(IntPtr ptr, bool shouldFree = false)
    {
        Handle = ptr;
        ShouldFree = shouldFree;
    }


    /// <summary>Release the native resources held by this instance.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>Disposes of this wrapper, releasing the native handle if
    /// owned.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="disposing">True if this was called from <see cref="Dispose()"/> public method. False if
    /// called from the C# finalizer.</param>
    protected virtual void Dispose(bool disposing)
    {
        if (!Disposed && ShouldFree)
        {
            MemoryNative.Free(this.Handle);
        }

        Disposed = true;
    }

    
    /// <summary>Release the native resources held by this instance.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    ~DisposableIntPtr()
    {
        Dispose(false);
    }
}

}
