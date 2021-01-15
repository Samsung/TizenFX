
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    using tlog = Tizen.Log;
    public class FindChildByIdTest : IExample
    {
        private const string tag = "NUITEST";
        private const int numberOfChildren = 10;
        private Window win;
        private View root, parent1, parent2;
        private TextLabel[] childList1, childList2;
        private Button button1, button2;
        private Random rand;
        private uint removeTargetID1, removeTargetID2;

        public void Activate()
        {
            rand = new Random();
            win = NUIApplication.GetDefaultWindow();
            win.BackgroundColor = Color.Green;

            root = new View()
            {
                Size = new Size(1000, 1000),
                BackgroundColor = Color.Yellow,
                PositionUsesPivotPoint = true,
                ParentOrigin = ParentOrigin.Center,
                PivotPoint = PivotPoint.Center,
            };
            root.TouchEvent += OnRootTouchEvent;
            root.Name = "root";
            win.Add(root);

            makeParentsAndChildrenToAdd(root);

            makeButtons(root);
        }

        private void Button_Clicked(object sender, ClickedEventArgs e)
        {
            TextLabel currentChild;
            bool isCurrentParent1 = (sender as Button) == button1;
            View currentParent = isCurrentParent1 ? parent1 : parent2;
            if (isCurrentParent1)
            {
                currentChild = currentParent.FindChildByID(removeTargetID1) as TextLabel;
            }
            else
            {
                currentChild = currentParent.FindChildByID(removeTargetID2) as TextLabel;
            }

            if (currentChild != null && currentChild.Name.Contains("ID"))
            {
                tlog.Debug(tag, $"found child : Name={currentChild.Name}, Id={currentChild.Id}, ID={currentChild.ID} and unparent the child!");
                currentChild.Unparent();

                if (isCurrentParent1)
                {
                    removeTargetID1 = currentParent.GetChildAt(0).ID;
                }
                else
                {
                    removeTargetID2 = currentParent.GetChildAt(0).ID;
                }
            }
            else
            {
                tlog.Debug(tag, $"couldn't find the child of ID {(isCurrentParent1 ? removeTargetID1 : removeTargetID2)}, or this is not a target of this test!");
            }

            currentChild = new TextLabel();
            currentChild.Size = new Size(100, 100);
            currentChild.PositionUsesPivotPoint = true;
            currentChild.ParentOrigin = ParentOrigin.TopLeft;
            currentChild.PivotPoint = PivotPoint.Center;
            currentChild.BackgroundColor = new Color((float)rand.NextDouble(), (float)rand.NextDouble(), (float)rand.NextDouble(), 0.8f);
            currentChild.Position = new Position(rand.Next(100, 400), rand.Next(100, 400));
            currentChild.Name = currentChild.Text = $"ID-{currentChild.ID}";
            currentChild.TextFit = new PropertyMap().Add("enable", new PropertyValue(true)).Add("minSize", new PropertyValue(5.0f)).Add("maxSize", new PropertyValue(50.0f));
            currentParent.Add(currentChild);
            tlog.Debug(tag, $"Add new child.ID={currentChild.ID}, Id={currentChild.Id}, Name={currentChild.Name}");
        }

        private bool OnRootTouchEvent(object source, View.TouchEventArgs e)
        {
            if (e.Touch.GetState(0) == PointStateType.Down)
            {
                printChildrenIDs(parent1);
                printChildrenIDs(parent2);
            }
            return false;
        }

        private void printChildrenIDs(View parent)
        {
            uint numChild = parent.ChildCount;
            tlog.Debug(tag, $"=============================================");
            tlog.Debug(tag, $"parent: Name={parent.Name}, Id={parent.Id}, ID={parent.ID}");
            for (int i = (int)numChild - 1; i >= 0; i--)
            {
                View child = parent.GetChildAt((uint)i);
                tlog.Debug(tag, $" + child index[{i}]: Name={child.Name}, Id={child.Id}, ID={child.ID}");
            }
            tlog.Debug(tag, $"=============================================");
        }

        private void makeButtons(View root)
        {
            button1 = new Button();
            button1.Text = "Remove & Add in parent1";
            button1.Size = new Size(200, 200);
            button1.BackgroundColor = Color.Cyan;
            button1.Position = new Position(10, 600);
            root.Add(button1);
            button1.Clicked += Button_Clicked;

            button2 = new Button();
            button2.Text = "Remove & Add in parent2";
            button2.Size = new Size(200, 200);
            button2.BackgroundColor = Color.Cyan;
            button2.Position = new Position(510, 600);
            root.Add(button2);
            button2.Clicked += Button_Clicked;
        }

        private void makeParentsAndChildrenToAdd(View root)
        {
            parent1 = new View()
            {
                Size = new Size(500, 500),
                Position = new Position(0, 10),
                BackgroundColor = Color.Blue,
                Name = "parent1",
            };
            root.Add(parent1);

            childList1 = new TextLabel[numberOfChildren];

            for (int i = 0; i < numberOfChildren; i++)
            {
                childList1[i] = new TextLabel();
                childList1[i].Size = new Size(100, 100);
                childList1[i].PositionUsesPivotPoint = true;
                childList1[i].ParentOrigin = ParentOrigin.TopLeft;
                childList1[i].PivotPoint = PivotPoint.Center;
                childList1[i].BackgroundColor = new Color(0.1f, 0.1f, (float)rand.NextDouble(), 0.8f);
                childList1[i].Position = new Position(rand.Next(100, 400), rand.Next(100, 400));
                childList1[i].Name = childList1[i].Text = $"ID={childList1[i].ID}";
                childList1[i].TextFit = new PropertyMap().Add("enable", new PropertyValue(true)).Add("minSize", new PropertyValue(5.0f)).Add("maxSize", new PropertyValue(50.0f));
                parent1.Add(childList1[i]);
            }
            removeTargetID1 = childList1[0].ID;

            tlog.Debug(tag, $" \n");
            tlog.Debug(tag, $" parent1 Id={parent1.Id} ID={parent1.ID}");
            for (int i = 0; i < numberOfChildren; i++)
            {
                tlog.Debug(tag, $" child1({childList1[i].Text}) Id={childList1[i].Id}, ID={childList1[i].ID}");
            }

            parent2 = new View()
            {
                Size = new Size(500, 500),
                Position = new Position(500, 10),
                BackgroundColor = Color.Red,
                Name = "parent2",
            };
            root.Add(parent2);

            childList2 = new TextLabel[numberOfChildren];

            for (int i = 0; i < numberOfChildren; i++)
            {
                childList2[i] = new TextLabel();
                childList2[i].Size = new Size(100, 100);
                childList2[i].PositionUsesPivotPoint = true;
                childList2[i].ParentOrigin = ParentOrigin.TopLeft;
                childList2[i].PivotPoint = PivotPoint.Center;
                childList2[i].BackgroundColor = new Color((float)rand.NextDouble(), 0.1f, 0.1f, 1.0f);
                childList2[i].Position = new Position(rand.Next(100, 400), rand.Next(100, 400));
                childList2[i].Name = childList2[i].Text = $"ID={childList2[i].ID}";
                childList2[i].TextFit = new PropertyMap().Add("enable", new PropertyValue(true)).Add("minSize", new PropertyValue(5.0f)).Add("maxSize", new PropertyValue(50.0f));
                parent2.Add(childList2[i]);
            }
            removeTargetID2 = childList2[0].ID;

            tlog.Debug(tag, $" \n");
            tlog.Debug(tag, $" parent2 Id={parent2.Id} ID={parent2.ID}");
            for (int i = 0; i < numberOfChildren; i++)
            {
                tlog.Debug(tag, $" child2({childList2[i].Text}) Id={childList2[i].Id}, ID={childList2[i].ID}");
            }
        }

        public void Deactivate()
        {
            for (int i = (int)(parent1.ChildCount - 1); i >= 0; i--)
            {
                View child = parent1.GetChildAt((uint)i);
                child.Unparent();
                child.Dispose();
            }
            parent1.Unparent();
            parent1.Dispose();

            for (int i = (int)(parent2.ChildCount - 1); i >= 0; i--)
            {
                View child = parent2.GetChildAt((uint)i);
                child.Unparent();
                child.Dispose();
            }
            parent2.Unparent();
            parent2.Dispose();

            root.Unparent();
            root.Dispose();
        }
    }
}
