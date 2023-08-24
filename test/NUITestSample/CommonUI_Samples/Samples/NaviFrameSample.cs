using System;
using System.Collections.Generic;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace NuiCommonUiSamples
{
    using Controls = Tizen.FH.NUI.Controls;
    public class NaviFrame : IExample
    {
        private SampleLayout root;
        private Tizen.NUI.CommonUI.Button NextButton;
        private Tizen.NUI.CommonUI.Button BackButton;
        private Controls.NaviFrame navi;
        private Controls.Header h;
        private TextLabel c;
        private int i;
        public void Activate()
        {
            Window.Instance.BackgroundColor = Color.White;
            i = 1;
            root = new SampleLayout(false);
            root.HeaderText = "NaviFrame";

            navi = new Controls.NaviFrame("DefaultNaviFrame");
            root.Add(navi);

            BackButton = new Tizen.NUI.CommonUI.Button()
            {
                Size2D = new Size2D(90, 60),
                BackgroundColor = Color.Cyan,
                Text = "Push",
                PointSize = 14,
            };
            BackButton.PositionUsesPivotPoint = true;
            BackButton.ParentOrigin = Tizen.NUI.ParentOrigin.CenterLeft;
            BackButton.PivotPoint = Tizen.NUI.PivotPoint.CenterLeft;
            BackButton.ClickEvent += ClickPush;

            root.Add(BackButton);
            BackButton.RaiseToTop();
            NextButton = new Tizen.NUI.CommonUI.Button()
            {
                Text = "Pop",
                Size2D = new Size2D(90, 60),
                BackgroundColor = Color.Cyan,
                PointSize = 14,
            };
            NextButton.PositionUsesPivotPoint = true;
            NextButton.ParentOrigin = Tizen.NUI.ParentOrigin.CenterRight;
            NextButton.PivotPoint = Tizen.NUI.PivotPoint.CenterRight;
            NextButton.ClickEvent += ClickPop;

            root.Add(NextButton);
            NextButton.RaiseToTop();

            ClickPush(null, null);
        }
        public void Deactivate()
        {
            if (root != null)
            {

                if (navi != null)
                {
                    root.Remove(navi);
                    navi.Dispose();
                }
                if (BackButton != null)
                {
                    root.Remove(BackButton);
                    BackButton.Dispose();
                }
                if (NextButton != null)
                {
                    root.Remove(NextButton);
                    NextButton.Dispose();
                }

                root.Dispose();
            }
        }
        private Tizen.FH.NUI.Controls.Header MakeHeader(string txt)
        {
            Controls.Header head = new Controls.Header("DefaultHeader");
            head.BackgroundColor = new Color(255, 255, 255, 0.7f);
            head.HeaderText = "Title " + txt;
            return head;
        }
        private TextLabel MakeLabel(string txt)
        {
            TextLabel content = new TextLabel()
            {
                Text = txt,
                PointSize = 90,
                BackgroundColor = new Color(255, 255, 255, 0.7f),
                HeightResizePolicy = ResizePolicyType.FillToParent,
                WidthResizePolicy = ResizePolicyType.FillToParent,
            };

            return content;
        }

        private void ClickPush(object sender, Tizen.NUI.CommonUI.Button.ClickEventArgs e)
        {
            string head = "header" + i;
            string lable = "lable" + i;
            h = MakeHeader(head);
            c = MakeLabel(lable);
            i++;
            if (navi != null)
            {
                navi.NaviFrameItemPush(h, c);
            }

        }
        private void ClickPop(object sender, Tizen.NUI.CommonUI.Button.ClickEventArgs e)
        {
            if (navi != null)
            {
                navi.NaviFrameItemPop();
            }
        }
    }
}
