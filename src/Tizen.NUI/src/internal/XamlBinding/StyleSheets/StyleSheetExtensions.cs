using System.Collections.Generic;
using Tizen.NUI.Binding;

namespace Tizen.NUI.StyleSheets
{
    internal static class StyleSheetExtensions
    {
        public static IEnumerable<StyleSheet> GetStyleSheets(this IResourcesProvider resourcesProvider)
        {
            if (resourcesProvider == null)
            {
                yield break;
            }
            if (!resourcesProvider.IsResourcesCreated)
            {
                yield break;
            }
            if (resourcesProvider.XamlResources == null || resourcesProvider.XamlResources.StyleSheets == null)
            {
                yield break;
            }
            foreach (var styleSheet in resourcesProvider.XamlResources.StyleSheets)
            {
                yield return styleSheet;
            }
        }
    }
}