namespace Tizen.NUI.Binding
{
    internal interface IPageContainer<out T> where T : Page
    {
        T CurrentPage { get; }
    }
}