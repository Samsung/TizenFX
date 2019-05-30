namespace Tizen.NUI.XamlBinding
{
    internal static class DataTemplateExtensions
    {
        public static DataTemplate SelectDataTemplate(this DataTemplate self, object item, BindableObject container)
        {
            var selector = self as DataTemplateSelector;
            if (selector == null)
                return self;

            return selector.SelectTemplate(item, container);
        }

        public static object CreateContent(this DataTemplate self, object item, BindableObject container)
        {
            return self.SelectDataTemplate(item, container).CreateContent();
        }
    }
}