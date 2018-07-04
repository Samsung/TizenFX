using System;

namespace Tizen.NUI.Xaml
{
    // [ProvideCompiled("Tizen.NUI.Build.Tasks.NullExtension")]
    [AcceptEmptyServiceProvider]
    internal class NullExtension : IMarkupExtension
    {
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return null;
        }
    }
}
