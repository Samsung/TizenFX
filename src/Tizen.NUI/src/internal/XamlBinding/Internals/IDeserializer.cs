using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Tizen.NUI.Binding.Internals
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal interface IDeserializer
    {
        Task<IDictionary<string, object>> DeserializePropertiesAsync();
        Task SerializePropertiesAsync(IDictionary<string, object> properties);
    }
}