using System;
using System.Collections.Generic;

namespace Tizen.NUI.Binding
{
    internal static class ResourcesExtensions
    {
        public static IEnumerable<KeyValuePair<string, object>> GetMergedResources(this IElement element)
        {
            Dictionary<string, object> resources = null;
            while (element != null)
            {
                var ve = element as IResourcesProvider;
                if (ve != null && ve.IsResourcesCreated)
                {
                    resources = resources ?? new Dictionary<string, object>();
                    if (null == resources)
                    {
                        return null;
                    }

                    if (ve.XamlResources != null)
                    {
                        foreach (KeyValuePair<string, object> res in ve.XamlResources.MergedResources)
                            if (!resources.ContainsKey(res.Key))
                                resources.Add(res.Key, res.Value);
                    }
                }

                var app = element as Application;
                if (app != null && app.SystemResources != null)
                {
                    resources = resources ?? new Dictionary<string, object>(8);
                    if (null == resources)
                    {
                        return null;
                    }

                    foreach (KeyValuePair<string, object> res in app.SystemResources)
                        if (!resources.ContainsKey(res.Key))
                            resources.Add(res.Key, res.Value);
                }
                element = element.Parent;
            }
            return resources;
        }

        public static bool TryGetResource(this IElement element, string key, out object value)
        {
            while (element != null)
            {
                var ve = element as IResourcesProvider;
                if (ve != null && ve.IsResourcesCreated && ve.XamlResources != null && ve.XamlResources.TryGetValue(key, out value))
                {
                    return true;
                }
                var app = element as Application;
                if (app != null && app.SystemResources != null && app.SystemResources.TryGetValue(key, out value))
                {
                    return true;
                }
                element = element.Parent;
            }

            //Fallback for the XF previewer
            if (Application.Current != null && ((IResourcesProvider)Application.Current).IsResourcesCreated && Application.Current.XamlResources.TryGetValue(key, out value))
                return true;

            value = null;
            return false;
        }
    }
}
