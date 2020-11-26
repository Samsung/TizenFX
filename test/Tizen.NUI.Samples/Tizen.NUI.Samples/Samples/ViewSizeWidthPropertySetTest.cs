
using global::System;
using System.Threading.Tasks;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Samples
{
    public class ViewWidthSizePropertySetTest : IExample
    {
        public void Activate()
        {
            _ = test();
            //TDD
            SizeWidthTest1();
            SizeWidthTest2();
        }

        public void Deactivate()
        {

        }

        Window window;
        Layer layer;
        View root, view1;
        public async Task test()
        {
            //await Task.Delay(500);

            tlog.prt($"### START test : HeghtResizePolicy is changed by setting Size2D.Width \n");

            window = NUIApplication.GetDefaultWindow();
            layer = window.GetDefaultLayer();

            window.TouchEvent += Window_TouchEvent;
            window.KeyEvent += Window_KeyEvent;

            root = new View()
            {
                Size = new Size(500, 500),
                Position = new Position(50, 50),
                BackgroundColor = Color.White,
            };
            layer.Add(root);

            view1 = new View()
            {
                Size = new Size(100, 100),
                BackgroundColor = Color.Cyan,
                MaximumSize = new Size2D(1000, 1000),
            };
            root.Add(view1);
        }

        private void Window_KeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down)
            {
                if (e.Key.KeyPressedName == "1")
                {
                    view1.SizeWidth += 10;
                }
                else if (e.Key.KeyPressedName == "2")
                {
                    view1.SizeHeight += 10;
                }
                else if (e.Key.KeyPressedName == "3")
                {
                    view1.WidthResizePolicy = ResizePolicyType.FillToParent;
                }
                else if (e.Key.KeyPressedName == "4")
                {
                    view1.WidthResizePolicy = ResizePolicyType.Fixed;
                }
                else if (e.Key.KeyPressedName == "5")
                {
                    view1.MinimumSize.Width = 500;
                }
                else if (e.Key.KeyPressedName == "6")
                {
                    view1.MinimumSize.Width = 100;
                }
                else if (e.Key.KeyPressedName == "7")
                {
                    view1.MaximumSize.Width = 700;
                }
                else if (e.Key.KeyPressedName == "8")
                {
                    view1.MaximumSize.Width = 70;
                }
                else if (e.Key.KeyPressedName == "9")
                {
                    view1.Size += new Size(10, 10);
                }
                else if (e.Key.KeyPressedName == "0")
                {
                    view1.SizeWidth -= 10;
                    view1.SizeHeight -= 10;
                }
            }
        }

        private void Window_TouchEvent(object sender, Window.TouchEventArgs e)
        {
            if (e.Touch.GetState(0) == PointStateType.Down)
            {
                string log = "";
                log += $"view1 Size2D=({view1.Size2D.Width}, {view1.Size2D.Height}) \n";
                log += $"SizeWidth={view1.SizeWidth}, SizeHeight={view1.SizeHeight} \n";
                log += $"Size={view1.Size.Width}, SizeHeight={view1.Size.Height} \n";
                log += $"WidthResizePolicy={view1.WidthResizePolicy}, HeightResizePolicy={view1.HeightResizePolicy} \n";
                log += $"WidthSpecification={view1.WidthSpecification}, HeightSpecification={view1.HeightSpecification} \n";
                log += $"MinimumSize=({view1.MinimumSize.Width}, {view1.MinimumSize.Height}) \n";
                log += $"MaximumSize=({view1.MaximumSize.Width}, {view1.MaximumSize.Height}) \n";
                tlog.prt(log);
            }
        }

        void SizeWidthTest1()
        {
            var sizeW1 = 100;
            var sizeW2 = 200;
            var sizeH1 = 100;
            var sizeH2 = 200;

            var view = new View()
            {
                Size2D = new Size2D(sizeW1, sizeH1),
            };
            layer.Add(view);

            Assert.AreEqual(sizeW1, view.Size.Width, "Size.Width test fail!");
            Assert.AreEqual(sizeH1, view.Size.Height, "Size.Height test fail!");
            Assert.AreEqual(sizeW1, view.Size2D.Width, "Size2D.Width test fail!");
            Assert.AreEqual(sizeH1, view.Size2D.Height, "Size2D.Height test fail!");

            view.Size.Width = sizeW2;
            Assert.AreEqual(sizeW2, view.Size.Width, "Size.Width test fail!");
            Assert.AreEqual(sizeW2, view.Size2D.Width, "Size2D.Width test fail!");

            view.Size2D.Height = sizeH2;
            Assert.AreEqual(sizeH2, view.Size.Height, "Size.Height test fail!");
            Assert.AreEqual(sizeH2, view.Size2D.Height, "Size2D.Height test fail!");

            view.Unparent();
            view.Dispose();
        }

        void SizeWidthTest2()
        {
            var sizeW1 = 100;
            var sizeW2 = 200;
            var sizeH1 = 100;
            var resizeP1 = ResizePolicyType.FillToParent;
            var resizeP2 = ResizePolicyType.Fixed;

            var view = new View()
            {
                Size2D = new Size2D(sizeW1, sizeH1),
                HeightResizePolicy = resizeP1,
            };
            layer.Add(view);

            view.Size2D.Width = sizeW2;
            Assert.AreEqual(sizeW2, view.Size.Width, "Size.Width test fail!");
            Assert.AreEqual(sizeW2, view.Size2D.Width, "Size2D.Width test fail!");
            Assert.AreEqual((int)resizeP1, (int)view.HeightResizePolicy, "HeightResizePolicy test fail!");
            Assert.AreEqual((int)resizeP2, (int)view.WidthResizePolicy, "WidthResizePolicy test fail!");
            Assert.AreEqual(sizeH1, view.Size.Height, "Size.Height test fail!");
            Assert.AreEqual(sizeH1, view.Size2D.Height, "Size2D.Height test fail!");

            view.Size.Width = sizeW1;
            Assert.AreEqual(sizeW1, view.Size.Width, "Size.Width test fail!");
            Assert.AreEqual(sizeW1, view.Size2D.Width, "Size2D.Width test fail!");
            Assert.AreEqual((int)resizeP1, (int)view.HeightResizePolicy, "HeightResizePolicy test fail!");
            Assert.AreEqual((int)resizeP2, (int)view.WidthResizePolicy, "WidthResizePolicy test fail!");
            Assert.AreEqual(sizeH1, view.Size.Height, "Size.Height test fail!");
            Assert.AreEqual(sizeH1, view.Size2D.Height, "Size2D.Height test fail!");

            view.Unparent();
            view.Dispose();
        }


        static class tlog
        {
            static public void prt(string log)
            {
                Tizen.Log.Debug("NUITEST", log);
                Console.Write(log);
            }
        }

        static class Assert
        {
            static public void AreEqual(float a, float b, string msg)
            {
                tlog.prt($"AreEqual(a={a}, b={b}) \n");
                if (a != b)
                {
                    tlog.prt($"Different! FAIL! \n");
                    throw new ApplicationException(msg);
                }
                else
                {
                    tlog.prt($"Same! PASS! \n");
                }
            }

            static public void IsTrue(bool a, string msg)
            {
                tlog.prt($"IsTrue(a={a} \n");
                if (a != true)
                {
                    tlog.prt($"false! FAIL! \n");
                    throw new ApplicationException(msg);
                }
                else
                {
                    tlog.prt($"true! PASS! \n");
                }
            }
        }

    }
}
