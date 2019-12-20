using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tizen.NUI.Samples
{
    public class ContactCardsSample : IExample
    {
        private readonly Vector4 WINDOW_COLOR = new Vector4( 211.0f / 255.0f, 211.0f / 255.0f, 211.0f / 255.0f, 1.0f );
        private ContactCardLayouter mContactCardLayouter;

        //protected override void OnCreate()
        //{
        //    base.OnCreate();
        //    Activate();
        //}

        public void Activate()
        {
            Window.Instance.BackgroundColor = WINDOW_COLOR;
            //Window.Instance.KeyEvent += OnKeyEvent;

            mContactCardLayouter = new ContactCardLayouter();

            for (int i = 0; i < ContactData.itemSize; i++)
            {
                mContactCardLayouter.AddContact(ContactData.itmes[i].name, ContactData.itmes[i].address, ContactData.itmes[i].imagePath);
            }
        }

        public void Deactivate()
        {

        }

        //private void OnKeyEvent(object sender, Window.KeyEventArgs e)
        //{
        //    if(e.Key.State == Key.StateType.Down)
        //    {
        //        FocusManager focusManager = FocusManager.Instance;
        //        if(!focusManager.GetCurrentFocusView())
        //        {
        //            if (e.Key.KeyPressedName == "Escape" || e.Key.KeyPressedName == "BackSpace")
        //            {
                        
        //            }
        //        }
        //    }
        //}
    }
}
