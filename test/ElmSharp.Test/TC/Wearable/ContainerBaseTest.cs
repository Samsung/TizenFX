using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ElmSharp.Test.Wearable
{
    class ContainerBaseTest : WearableTestCase
    {
        public override string TestName => "ContainerBase";

        public override string TestDescription => "Custom Container Test with ContainerBase";

        public override void Run(Window window)
        {
            Rect square = window.GetInnerSquare();

            var bb = new BorderBox(window)
            {
                Border = new Thickness(10, 5, 20, 30),
                Padding = new Thickness(20, 25, 10, 0),
                BorderColor = Color.Red,
                BackgroundColor = Color.Blue
            };
            bb.Geometry = new Rect(0, 0, 80, 80);
            var img = new Image(bb);
            img.Show();
            img.Load(Path.Combine(TestRunner.ResourceDir, "small_me.png"));
            img.Resize(40, 40);
            bb.Add(img);
            double minr = square.Width - Math.Min(bb.Geometry.Width, bb.Geometry.Height) * 1.41421;
            double degree = 0;

            IntPtr anim = EcoreAnimator.AddAnimator(() =>
            {
                int x = square.X + square.Width/2 - bb.Geometry.Width/2 + (int)(minr * Math.Cos(Math.PI / 180 * degree));
                int y = square.Y + square.Height/ 2 - bb.Geometry.Width / 2 + (int)(minr * Math.Sin(Math.PI / 180 * degree));
                bb.Move(x, y);
                degree = degree + 1 < 360 ? degree + 1 : 0;
                var foo = 0xff - (int)(0xff * degree / 360);
                bb.Opacity = foo;
                return true;
            });
            bb.Show();

            bb.Deleted += (s, e) => EcoreAnimator.RemoveAnimator(anim);
        }

        class BorderBox : ContainerBase
        {
            Rectangle leftBorder, topBorder, rightBorder, bottomBorder;
            Color borderColor;

            public BorderBox(EvasObject parent) : base(parent)
            {
                leftBorder = new Rectangle(this);
                topBorder = new Rectangle(this);
                rightBorder = new Rectangle(this);
                bottomBorder = new Rectangle(this);
                Border = new Thickness();
                leftBorder.Show();
                topBorder.Show();
                rightBorder.Show();
                bottomBorder.Show();

                Add(leftBorder);
                Add(topBorder);
                Add(rightBorder);
                Add(bottomBorder);
            }

            public Thickness Border { get; set; }
            public Thickness Padding { get; set; }
            public Color BorderColor
            {
                get => borderColor;
                set
                {
                    if (BorderColor == value) return;
                    borderColor = value;
                    leftBorder.Color = borderColor;
                    topBorder.Color = borderColor;
                    rightBorder.Color = borderColor;
                    bottomBorder.Color = borderColor;
                }
            }

            protected override void OnLayout(Rect geometry)
            {
                leftBorder.Geometry = new Rect(geometry.X, geometry.Y, Border.Left, geometry.Height);
                topBorder.Geometry = new Rect(geometry.X, geometry.Y, geometry.Width, Border.Top);
                rightBorder.Geometry = new Rect(geometry.X + geometry.Width - Border.Right, geometry.Y, Border.Right, geometry.Height);
                bottomBorder.Geometry = new Rect(geometry.X, geometry.Y + geometry.Height - Border.Bottom, geometry.Width, Border.Bottom);

                var maxW = geometry.Width - Border.Left - Border.Right - Padding.Left - Padding.Right;
                var maxH = geometry.Height - Border.Top - Border.Bottom - Padding.Top - Padding.Bottom;
                var left = geometry.X + Border.Left + Padding.Left;
                var top = geometry.Y + Border.Top + Padding.Top;

                foreach (var child in Children)
                {
                    if (child == leftBorder || child == topBorder || child == rightBorder || child == bottomBorder)
                        continue;
                    var r = child.Geometry;
                    var minW = child.MinimumWidth;
                    var minH = child.MinimumHeight;
                    var alignX = child.AlignmentX;
                    var alignY = child.AlignmentY;
                    var w = 0;
                    var h = 0;
                    var l = 0;
                    var t = 0;
                    if (alignX < 0)
                    {
                        w = maxW;
                    }
                    else
                    {
                        w = Math.Min(Math.Max(minW, r.Width), maxW);
                        l = (int)((maxW - w) * alignX);
                    }
                    if (alignY < 0)
                    {
                        h = maxH;
                    }
                    else
                    {
                        h = Math.Min(Math.Max(minH, r.Height), maxH);
                        t = (int)((maxH - h) * alignY);
                    }
                    child.Geometry = new Rect(left + l, top + t, w, h);
                }
            }
        }

        struct Thickness
        {
            public Thickness(int left, int top, int right, int bottom)
            {
                Left = left;
                Top = top;
                Right = right;
                Bottom = bottom;
            }
            public int Left { get; set; }
            public int Top { get; set; }
            public int Right { get; set; }
            public int Bottom { get; set; }
        }
    }
}
