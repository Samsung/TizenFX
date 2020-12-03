using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

[assembly: global::Tizen.NUI.Xaml.XamlResourceIdAttribute("Tizen.NUI.Samples.res.xaml.RelativeLayoutSampleView.xaml", "res/xaml/RelativeLayoutSampleView.xaml", typeof(global::Tizen.NUI.Samples.RelativeLayoutSampleView))]
namespace Tizen.NUI.Samples
{
    public class RelativeLayoutSample : IExample
    {
        public void Activate()
        {
            View root = new View();
            root.BackgroundColor = new Color(255 / 255f, 255 / 255f, 227 / 255f, 1.0f);
            root.Layout = new AbsoluteLayout();
            root.WidthSpecification = LayoutParamPolicies.MatchParent;
            root.HeightSpecification = LayoutParamPolicies.MatchParent;
            Window.Instance.GetDefaultLayer().Add(root);

            RelativeLayoutSampleView relativeLayoutSampleView = new RelativeLayoutSampleView();
            relativeLayoutSampleView.WidthSpecification = LayoutParamPolicies.MatchParent;
            relativeLayoutSampleView.HeightSpecification = LayoutParamPolicies.MatchParent;
            root.Add(relativeLayoutSampleView);
        }

        public void Deactivate() {}
    }
    public partial class RelativeLayoutSampleView : View
    {
        public RelativeLayoutSampleView() : base()
        {
            InitializeComponent();
        }
    }

    [Tizen.NUI.Xaml.XamlFilePathAttribute("res\\xaml\\RelativeLayoutSampleView.xaml")]
    [Tizen.NUI.Xaml.XamlCompilationAttribute(global::Tizen.NUI.Xaml.XamlCompilationOptions.Compile)]
    public partial class RelativeLayoutSampleView : global::Tizen.NUI.BaseComponents.View
    {

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Tizen.NUI.Xaml.Build.Tasks.XamlG", "1.0.11.0")]
        public global::Tizen.NUI.BaseComponents.View MainView;

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Tizen.NUI.Xaml.Build.Tasks.XamlG", "1.0.11.0")]
        public global::Tizen.NUI.Components.Button left;

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Tizen.NUI.Xaml.Build.Tasks.XamlG", "1.0.11.0")]
        public global::Tizen.NUI.Components.Button right;

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Tizen.NUI.Xaml.Build.Tasks.XamlG", "1.0.11.0")]
        public global::Tizen.NUI.Components.Button center;

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Tizen.NUI.Xaml.Build.Tasks.XamlG", "1.0.11.0")]
        public global::Tizen.NUI.Components.Button fill;

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Tizen.NUI.Xaml.Build.Tasks.XamlG", "1.0.11.0")]
        public global::Tizen.NUI.Components.Button start;

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Tizen.NUI.Xaml.Build.Tasks.XamlG", "1.0.11.0")]
        public global::Tizen.NUI.Components.Button startandright;

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Tizen.NUI.Xaml.Build.Tasks.XamlG", "1.0.11.0")]
        private void InitializeComponent()
        {
            global::Tizen.NUI.Xaml.Extensions.LoadFromXaml(this, typeof(RelativeLayoutSampleView));
            MainView = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<global::Tizen.NUI.BaseComponents.View>(this, "MainView");
            left = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<global::Tizen.NUI.Components.Button>(this, "left");
            right = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<global::Tizen.NUI.Components.Button>(this, "right");
            center = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<global::Tizen.NUI.Components.Button>(this, "center");
            fill = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<global::Tizen.NUI.Components.Button>(this, "fill");
            start = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<global::Tizen.NUI.Components.Button>(this, "start");
            startandright = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<global::Tizen.NUI.Components.Button>(this, "startandright");
        }
    }
}
