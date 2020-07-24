using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Examples
{
    partial class BixbyWidgetPage : ContentPage
    {
        private ImageView widget = null;
        public BixbyWidgetPage(Window win) : base(win)
        {
            InitializeComponent();
        }

        /// <summary>
        /// To make the ContentPage instance be disposed.
        /// </summary>
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
            }

            base.Dispose(type);
        }

        public override void SetFocus()
        {
            widget = Root.FindChildByName("Widget") as ImageView;
            Animation animation = new Animation(2000);
            animation.AnimateTo(widget, "Opacity", 1.0f);
            animation.Play();
        }
  
    }
}
