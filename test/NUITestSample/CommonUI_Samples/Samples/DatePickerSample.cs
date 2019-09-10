using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.CommonUI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Tizen.FH.NUI.Controls;

namespace NuiCommonUiSamples
{
    public class DatePicker : IExample
    {
        private SampleLayout root;
        private Tizen.NUI.CommonUI.Popup popup = null;
        private Picker datePicker = null;

        public void Activate()
        {
            Window.Instance.BackgroundColor = Color.White;
            root = new SampleLayout();
            root.HeaderText = "Date Picker";

            CreateDatePicker();
        }

        private void CreateDatePicker()
        {
            popup = new Tizen.NUI.CommonUI.Popup("Popup");
            popup.Size2D = new Size2D(1032, 982);
            popup.Position2D = new Position2D(24, 50);
            popup.TitleText = "Set Date";
            popup.ButtonCount = 2;
            popup.SetButtonText(0, "Cancel");
            popup.SetButtonText(1, "OK");
            popup.PopupButtonClickedEvent += PopupButtonClickedEvent;
            root.Add(popup);

            datePicker = new Picker("DAPicker");
            datePicker.Size2D = new Size2D(1032, 724);
            datePicker.Position2D = new Position2D(0, 0);
            datePicker.CurDate = new DateTime(2012, 12, 12);
            popup.ContentView.Add(datePicker);
        }

        private void PopupButtonClickedEvent(object sender, Tizen.NUI.CommonUI.Popup.ButtonClickEventArgs e)
        {

        }

        private void DestoryDatePicker()
        {
            if (popup != null)
            {
                if (datePicker != null)
                {
                    popup.ContentView.Remove(datePicker);
                    datePicker.Dispose();
                    datePicker = null;
                }

                root.Remove(popup);
                popup.Dispose();
                popup = null;
            }
        }

        public void Deactivate()
        {
            if (root != null)
            {
                DestoryDatePicker();
                root.Dispose();
            }
        }
    }
}
