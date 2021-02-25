using System;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;

namespace Tizen.NUI.Binding
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal interface IIsolatedStorageFile
    {
        Task CreateDirectoryAsync(string path);
        Task<bool> GetDirectoryExistsAsync(string path);
        Task<bool> GetFileExistsAsync(string path);

        Task<DateTimeOffset> GetLastWriteTimeAsync(string path);

        Task<Stream> OpenFileAsync(string path, FileMode mode, FileAccess access);
        Task<Stream> OpenFileAsync(string path, FileMode mode, FileAccess access, FileShare share);
    }
}
