using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    public class MultiWindowLayoutSample : IExample
    {
        private Window mainWindow = null;
        private Window subWindow = null;
        private View mainView = null;
        private View subView = null;

        public void Activate()
        {
            mainWindow = NUIApplication.GetDefaultWindow();

            mainView = new View()
            {
                Layout = new LinearLayout(),
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.White
            };
            mainWindow.Add(mainView);

            var mainChild = new View()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.Red
            };
            mainView.Add(mainChild);

            var mainChild2 = new View()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.Yellow
            };
            mainView.Add(mainChild2);

            subWindow = new Window();

            subView = new View()
            {
                Layout = new LinearLayout(),
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.White
            };
            subWindow.Add(subView);

            var subChild = new View()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.Green
            };
            subView.Add(subChild);

            var subChild2 = new View()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.Blue
            };
            subView.Add(subChild2);
        }

        public void Deactivate()
        {
            if (subWindow != null)
            {
                if (subView != null)
                {
                    subWindow.Remove(subView);
                    subView.Dispose();
                    subView = null;
                }

                subWindow.Dispose();
                subWindow = null;
            }

            if (mainWindow != null)
            {
                if (mainView != null)
                {
                    mainWindow.Remove(mainView);
                    mainView.Dispose();
                    mainView = null;
                }

                mainWindow = null;
            }
        }
    }
}
