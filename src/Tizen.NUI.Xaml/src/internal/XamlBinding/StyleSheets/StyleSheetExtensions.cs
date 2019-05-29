using System.Collections.Generic;
using Tizen.NUI.XamlBinding;

namespace Tizen.NUI.StyleSheets
{
    internal static class StyleSheetExtensions
    {
        public static IEnumerable<StyleSheet> GetStyleSheets(this IResourcesProvider resourcesProvider)
        {
            if (!resourcesProvider.IsResourcesCreated)
                yield break;
            if (resourcesProvider.XamlResources.StyleSheets == null)
                yield break;
            foreach (var styleSheet in resourcesProvider.XamlResources.StyleSheets)
                yield return styleSheet;
        }
    }
}