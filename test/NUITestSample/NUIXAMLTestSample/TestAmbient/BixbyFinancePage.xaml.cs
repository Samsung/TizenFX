using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Examples
{
    partial class BixbyFinancePage : ContentPage
    {
        private Vector2 bezierPointIn1 = new Vector2(0.21f, 2);
        private Vector2 bezierPointIn2 = new Vector2(0.14f, 1);
        private Vector2 bezierPointOut1 = new Vector2(0.19f, 1);
        private Vector2 bezierPointOut2 = new Vector2(0.22f, 1);
        private Animation scaleInAni = null;
        private Animation scaleOutAni = null;
        private ImageView buttonClose = null;
        private ImageView buttonSend = null;

        public BixbyFinancePage(Window win) : base(win)
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

            scaleInAni?.Dispose();
            scaleInAni = null;
            scaleOutAni?.Dispose();
            scaleOutAni = null;
            FocusManager.Instance.PreFocusChange -= OnPreFocusChange;

            base.Dispose(type);
        }

        private View OnPreFocusChange(object obj, FocusManager.PreFocusChangeEventArgs e)
        {
            if (e.CurrentView != null && !e.ProposedView)
            {
                if (e.Direction == View.FocusDirection.Left)
                {
                    e.ProposedView = buttonClose;
                }
                if (e.Direction == View.FocusDirection.Right)
                {
                    e.ProposedView = buttonSend;
                }
            }
            if (!e.ProposedView && !e.CurrentView)
            {
                e.ProposedView = buttonSend;
            }
            return e.ProposedView;
        }

        public override void SetFocus()
        {
            buttonClose = Root.FindChildByName("ButtonClose") as ImageView;
            buttonSend = Root.FindChildByName("ButtonSend") as ImageView;
            FocusManager.Instance.FocusIndicator = new View();
            FocusManager.Instance.PreFocusChange += OnPreFocusChange;
        }

        private void OnFocusGained(object obj, EventArgs e)
        {
            ImageView view = obj as ImageView;
            {
                view.ResourceUrl = "/home/owner/apps_rw/org.tizen.example.NUIXAMLTestSample/res/images/bixby/btn_focused_bg.png";
                // view.Border = new Rectangle(14,14,20,20);
            }
            view.RaiseToTop();
             if (scaleInAni == null)
            {
                scaleInAni = new Animation();
            }
            scaleInAni.Clear();
            scaleInAni.EndAction = Animation.EndActions.StopFinal;
            scaleInAni.AnimateTo(view, "Scale", new Vector3(1.1f, 1.1f, 0), 0, 1100, new AlphaFunction(bezierPointIn1, bezierPointIn2));
            scaleInAni.Play();
        }

        private void OnFocusLost(object obj, EventArgs e)
        {
            ImageView view = obj as ImageView;
            {
                view.ResourceUrl = "/home/owner/apps_rw/org.tizen.example.NUIXAMLTestSample/res/images/bixby/btn_normal_bg.png";
                // view.Border = new Rectangle(4,4,5,5);
            }
            if (scaleOutAni == null)
            {
                scaleOutAni = new Animation();
            }
            scaleOutAni.Clear();
            scaleOutAni.EndAction = Animation.EndActions.StopFinal;
            scaleOutAni.AnimateTo(view, "Scale", new Vector3(1.0f, 1.0f, 0), 0, 850, new AlphaFunction(bezierPointOut1, bezierPointOut2));
            scaleOutAni.Play();
        }
    }
}
