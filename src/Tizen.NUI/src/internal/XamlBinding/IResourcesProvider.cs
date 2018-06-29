namespace Tizen.NUI.Binding
{
    interface IResourcesProvider
    {
        bool IsResourcesCreated { get; }
        ResourceDictionary Resources { get; set; }
    }
}