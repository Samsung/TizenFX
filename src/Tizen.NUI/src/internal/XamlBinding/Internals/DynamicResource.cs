using System.ComponentModel;

namespace Tizen.NUI.Binding.Internals
{
    internal class DynamicResource
    {
        public DynamicResource(string key)
        {
            Key = key;
        }

        public string Key { get; private set; }
    }
}