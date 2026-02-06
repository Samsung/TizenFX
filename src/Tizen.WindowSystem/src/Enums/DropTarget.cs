using System.ComponentModel;

namespace Tizen.WindowSystem.Shell
{
    /// <summary>
    /// Drop target type of PerformDrop request of KVM Service.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum DropTarget
    {
        /// <summary>
        /// Drop to KVM Service window self.
        /// </summary>
        KVMServiceWin = 0,
        /// <summary>
        /// Drop to the window that under pointer.
        /// </summary>
        UnderPointer = 1,
    };
}
