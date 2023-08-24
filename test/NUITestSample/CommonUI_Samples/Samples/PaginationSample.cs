using System;
using Tizen.NUI;

namespace NuiCommonUiSamples
{
    using Controls = Tizen.FH.NUI.Controls;
    public class Pagination : IExample
    {
        private SampleLayout root;

        private Tizen.FH.NUI.Controls.Pagination DAPagination1;
        private Tizen.FH.NUI.Controls.Pagination DAPagination2;
        private Tizen.FH.NUI.Controls.Pagination DAPagination3;

        private readonly int PAGE_COUNT = 14;

        public void Activate()
        {
            Window.Instance.BackgroundColor = Color.White;
            root = new SampleLayout(false);
            root.HeaderText = "Pagination";

            ///////////////////////////////////////////////Create by Style//////////////////////////////////////////////////////////
            DAPagination1 = new Tizen.FH.NUI.Controls.Pagination("DefaultPagination");
            DAPagination1.Name = "DAAppPagination1";
            DAPagination1.Position2D = new Position2D(200, 50);
            DAPagination1.Size2D = new Size2D(400, 30);
            DAPagination1.BackgroundColor = new Color(1.0f, 1.0f, 1.0f, 0.6f);
            DAPagination1.IndicatorCount = PAGE_COUNT;
            DAPagination1.SelectedIndex = 0;
            DAPagination1.Focusable = true;
            root.Add(DAPagination1);

            DAPagination1.SelectChangeEvent += DAPagination_SelectChangeEvent;

            DAPagination2 = new Controls.Pagination("DefaultPagination");
            DAPagination2.Name = "DAAppPagination2";
            DAPagination2.Position2D = new Position2D(200, 150);
            DAPagination2.Size2D = new Size2D(230, 30);
            DAPagination2.BackgroundColor = new Color(1.0f, 1.0f, 1.0f, 0.6f);
            DAPagination2.IndicatorCount = PAGE_COUNT;
            DAPagination2.SelectedIndex = 1;
            DAPagination2.Focusable = true;
            root.Add(DAPagination2);

            DAPagination2.SelectChangeEvent += DAPagination_SelectChangeEvent;


            ///////////////////////////////////////////////Create by Properties//////////////////////////////////////////////////////////
            DAPagination3 = new Tizen.FH.NUI.Controls.Pagination();
            DAPagination3.Name = "DAAppPagination3";
            DAPagination3.Position2D = new Position2D(200, 250);
            DAPagination3.Size2D = new Size2D(400, 30);
            DAPagination3.BackgroundColor = new Color(1.0f, 1.0f, 1.0f, 0.6f);
            DAPagination3.IndicatorSize = new Size2D(26, 26);
            DAPagination3.IndicatorBackgroundURL = CommonResource.GetResourcePath() + "9. Controller/pagination_ic_nor.png";
            DAPagination3.IndicatorSelectURL = CommonResource.GetResourcePath() + "9. Controller/pagination_ic_sel.png";
            DAPagination3.IndicatorSpacing = 8;
            DAPagination3.ReturnArrowURLs = new Tizen.NUI.CommonUI.StringSelector
            {
                All = CommonResource.GetResourcePath() + "9. Controller/pagination_ic_return.png"
            };
            DAPagination3.ReturnArrowSize = new Size2D(26, 26);
            DAPagination3.NextArrowURLs = new Tizen.NUI.CommonUI.StringSelector
            {
                All = CommonResource.GetResourcePath() + "9. Controller/pagination_ic_next.png"
            };
            DAPagination3.NextArrowSize = new Size2D(26, 26);
            DAPagination3.IndicatorCount = PAGE_COUNT;
            DAPagination3.SelectedIndex = 0;
            DAPagination3.Focusable = true;
            root.Add(DAPagination3);

            DAPagination3.SelectChangeEvent += DAPagination_SelectChangeEvent;

        }

        private void DAPagination_SelectChangeEvent(object sender, Tizen.FH.NUI.Controls.Pagination.SelectChangeEventArgs e)
        {
            Tizen.FH.NUI.Controls.Pagination pagination = sender as Tizen.FH.NUI.Controls.Pagination;

            Console.WriteLine($"{pagination?.Name} Select index changed from {e.PreviousIndex} to {e.CurrentIndex}");
        }

        //private void Window_KeyEvent(object sender, Window.KeyEventArgs e)
        //{
        //    if (e.Key.State == Key.StateType.Down)
        //    {
        //        if (e.Key.KeyPressedName == "Left")
        //        {
        //            if (DAPagination1.SelectedIndex > 0)
        //            {
        //                DAPagination1.SelectedIndex = DAPagination1.SelectedIndex - 1;
        //            }
        //            if (DAPagination2.SelectedIndex > 0)
        //            {
        //                DAPagination2.SelectedIndex = DAPagination2.SelectedIndex - 1;
        //            }
        //            if (DAPagination3.SelectedIndex > 0)
        //            {
        //                DAPagination3.SelectedIndex = DAPagination3.SelectedIndex - 1;
        //            }
        //        }
        //        else if (e.Key.KeyPressedName == "Right")
        //        {
        //            if (DAPagination1.SelectedIndex < DAPagination1.IndicatorCount - 1)
        //            {
        //                DAPagination1.SelectedIndex = DAPagination1.SelectedIndex + 1;
        //            }
        //            if (DAPagination2.SelectedIndex < DAPagination2.IndicatorCount - 1)
        //            {
        //                DAPagination2.SelectedIndex = DAPagination2.SelectedIndex + 1;
        //            }
        //            if (DAPagination3.SelectedIndex < DAPagination3.IndicatorCount - 1)
        //            {
        //                DAPagination3.SelectedIndex = DAPagination3.SelectedIndex + 1;
        //            }
        //        }
        //    }
        //}

        public void Deactivate()
        {
            root.Remove(DAPagination1);
            root.Remove(DAPagination2);
            root.Remove(DAPagination3);

            DAPagination1.Dispose();
            DAPagination2.Dispose();
            DAPagination3.Dispose();

            root.Dispose();
        }
    }
}
