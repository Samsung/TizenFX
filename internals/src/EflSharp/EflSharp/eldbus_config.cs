#pragma warning disable 1591

using System;
using System.Runtime.InteropServices;

namespace eldbus {

public static class Config
{
    [DllImport(efl.Libs.Eldbus)] private static extern int eldbus_init();
    [DllImport(efl.Libs.Eldbus)] private static extern int eldbus_shutdown();

    public static void Init()
    {
        if (eldbus_init() == 0)
            throw new Efl.EflException("Failed to initialize Eldbus");
    }

    public static void Shutdown()
    {
        eldbus_shutdown();
    }

}

}
