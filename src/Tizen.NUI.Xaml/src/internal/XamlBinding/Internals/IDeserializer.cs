using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tizen.NUI.XamlBinding.Internals
{
    internal interface IDeserializer
    {
        Task<IDictionary<string, object>> DeserializePropertiesAsync();
        Task SerializePropertiesAsync(IDictionary<string, object> properties);
    }
}