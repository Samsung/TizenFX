using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    public partial class CustomXamlView : View
    {
        public CustomXamlView()
        {
#pragma warning disable Reflection // The code contains reflection
            global::Tizen.NUI.Xaml.Extensions.LoadFromXaml(this, typeof(CustomXamlView));
#pragma warning restore Reflection // The code contains reflection
        }
    }
}
