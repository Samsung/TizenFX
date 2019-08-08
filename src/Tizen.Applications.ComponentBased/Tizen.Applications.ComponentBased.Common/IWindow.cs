using System;

namespace Tizen.Applications.ComponentBased.Common
{
    /// <summary>
    /// Interface for window
    /// </summary>
    public interface IWindow
    {
        /// <summary>
        /// Gets window resource ID
        /// </summary>
        /// <returns></returns>
        int GetResId();

        /// <summary>
        /// Gets window raw pointer
        /// </summary>
        /// <returns></returns>
        IntPtr GetRaw();
    }
}
