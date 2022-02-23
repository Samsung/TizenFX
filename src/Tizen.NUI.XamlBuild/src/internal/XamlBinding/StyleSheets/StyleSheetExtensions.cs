using System.Collections.Generic;
using Tizen.NUI.Binding;
using Tizen.NUI.Binding;

namespace Tizen.NUI.StyleSheets
{
    internal static class StyleSheetExtensions
    {
        public static IEnumerable<StyleSheet> GetStyleSheets(this IResourcesProvider resourcesProvider)
        {
            if (!resourcesProvider.IsResourcesCreated)
                yield break;
            if (resourcesProvider.Resources.StyleSheets == null)
                yield break;
            foreach (var styleSheet in resourcesProvider.Resources.StyleSheets)
                yield return styleSheet;
        }
    }
}