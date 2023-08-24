
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using System;

namespace Tizen.NUI.Samples
{
    using l = Tizen.Log;

    public class SiblingOrderTest : IExample
    {
        Window win;
        View v;
        Button b1, b2, b3;
        TextLabel text;
        const string t = "NUITEST";
        const int W1 = 700, H1 = 800;
        const int W2 = 230, H2 = 150;
        public void Activate()
        {
            win = NUIApplication.GetDefaultWindow();

            v = new View();
            v.Size = new Size(W1, H1);
            v.Position = new Position(10, 10);
            v.BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1.0f);
            win.Add(v);

            b1 = new Button()
            {
                Size = new Size(700, 100),
                Position = new Position(10, H1 + 20),
                Text = "add new child",
            };
            b1.Clicked += B1_Clicked;
            win.Add(b1);

            b2 = new Button()
            {
                Size = new Size(700, 100),
                Position = new Position(10, H1 + 20 + 120),
                Text = "refresh sibling order",
            };
            b2.Clicked += B2_Clicked;
            win.Add(b2);

            b3 = new Button()
            {
                Size = new Size(700, 100),
                Position = new Position(10, H1 + 20 + 120 + 120),
                Text = "place children to fit parent",
            };
            b3.Clicked += B3_Clicked;
            win.Add(b3);

            text = new TextLabel()
            {
                Size = new Size(700, 100),
                Position = new Position(10, H1 + 20 + 120 + 120 + 120),
                Text = "push buttons above",
                BackgroundColor = Color.Yellow,
                Name = "status",
            };
            win.Add(text);
        }

        private void B1_Clicked(object sender, ClickedEventArgs e)
        {
            string n = "CH" + (v.ChildCount + 1);
            var ch = new TextLabel();
            Random r = new Random();
            int so = r.Next(0, (int)v.ChildCount);

            ch.Size = new Size(W2, H2);
            ch.Position = new Position(100, 900);
            ch.BackgroundColor = new Color((float)r.NextDouble(), (float)r.NextDouble(), (float)r.NextDouble(), 0.5f);
            ch.MultiLine = true;
            ch.Name = n;
            v.Add(ch);
            // SiblingOrder can set the order of mine in the sibling list owned by parent.
            // the lower value of SiblingOrder means it goes lower to the bottom so that it will be covered by higher valued siblings. 
            // (Vise versa, if SiblingOrder goes to high, the object will be up to the top which can be said as a screen.)
            //if new added sibling has same value with previously existed sibling, the existed siblings, which have higer value than new sibling, will get +1 and will be rearranged. 
            // (this means the new added sibling will be placed right under the old sibling that has same SiblingOrder value)
            //Therefore, SiblingOrder will be automatically set as parent's ChildCount + 1 when child itself is added to parent by "Add()".
            ch.SiblingOrder = so;
            ch.Text = ch.Name + "  SO=" + ch.SiblingOrder;

            var a = new Animation(500);
            var targetposition = GetPositionFromSiblingOrder(ch.SiblingOrder);
            a.AnimateTo(ch, "position", new Position((targetposition.X + W2 / 2), (targetposition.Y + H2 / 2), 0));
            a.Play();
            a.Finished += A_Finished;
        }

        private void B2_Clicked(object sender, ClickedEventArgs e)
        {
            for(int i=0; i < v.ChildCount; i++)
            {
                var ch = v.GetChildAt((uint)i) as TextLabel;
                if(ch != null)
                {
                    ch.Text = ch.Name + "  SO=" + ch.SiblingOrder;
                }
            }
        }

        private void B3_Clicked(object sender, ClickedEventArgs e)
        {
            for (int i = 0; i < v.ChildCount; i++)
            {
                var ch = v.GetChildAt((uint)i);
                var ani = new Animation(500);
                ani.AnimateTo(ch, "position", GetPositionFromSiblingOrder(i), new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseOut));
                ani.Play();
            }
        }

        private void A_Finished(object sender, EventArgs e)
        {
            var text = win.GetDefaultLayer().FindChildByName("status") as TextLabel;
            if(text != null)
            {
                int i = (int)v.ChildCount;
                text.Text = $"child {i} (CH{i}) is just added!";
            }
        }

        Position GetPositionFromSiblingOrder(int so)
        {
            int px = (so % (W1 / W2)) * W2;
            int py = (so / (W1 / W2)) * H2;
            return new Position(px, py, 0);
        }

        public void Deactivate()
        {
            b1.Clicked -= B1_Clicked;
            b2.Clicked -= B2_Clicked;
            b3.Clicked -= B3_Clicked;

            b1.Unparent();
            b2.Unparent();
            b3.Unparent();
            b1.Dispose();
            b2.Dispose();
            b3.Dispose();

            text.Unparent();
            text.Dispose();
            text = null;

            v.Unparent();
            v.Dispose();
            v = null;
        }
    }
}
