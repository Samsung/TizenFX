using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Example
{
    public class MyPropertyCheckSpeedTest : IExample
    {
        View root;
        ImageView iv1;
        TextEditor te1;
        TextField tf1;
        TextLabel tl1;
        View v1;
        float valueFloatShouldBe = 0.1f; float valueFloatIncreament = 0.01f;
        int valueIntShouldBe = 10; int valueIntIncreament = 2;
        ushort valueUshortShouldBe = 3; ushort valueUshortIncreament = 1;

        void setProperty1()
        {
            Random r = new Random();
            float float1 = (float)r.NextDouble();
            float float2 = (float)r.NextDouble();
            float float3 = (float)r.NextDouble();
            float float4 = (float)r.NextDouble();
            int int1 = (int)r.Next(0, 1000);
            int int2 = (int)r.Next(0, 1000);
            int int3 = (int)r.Next(0, 1000);
            int int4 = (int)r.Next(0, 1000);
            ushort ushort1 = (ushort)r.Next(0, 1000);
            ushort ushort2 = (ushort)r.Next(0, 1000);
            ushort ushort3 = (ushort)r.Next(0, 1000);
            ushort ushort4 = (ushort)r.Next(0, 1000);

            double start = DateTime.Now.Ticks;

            // ImageView.PixelArea
            iv1.PixelArea = new RelativeVector4(float1, float2, float3, float4);
            // ImageView.Border
            iv1.Border = new Rectangle(int1, int2, int3, int4);

            //TextEditor.DecorationBoundingBox
            te1.DecorationBoundingBox = new Rectangle(int1, int2, int3, int4);
            //TextEditor.InputColor
            te1.InputColor = new Vector4(float1, float2, float3, float4);
            //TextEditor.PlaceholderTextColor
            te1.PlaceholderTextColor = new Color(float1, float2, float3, float4);
            //TextEditor.PrimaryCursorColor
            te1.PrimaryCursorColor = new Vector4(float1, float2, float3, float4);
            //TextEditor.SecondaryCursorColor
            te1.SecondaryCursorColor = new Vector4(float1, float2, float3, float4);
            //TextEditor.SelectionHighlightColor
            te1.SelectionHighlightColor = new Vector4(float1, float2, float3, float4);
            //TextEditor.TextColor
            te1.TextColor = new Vector4(float1, float2, float3, float4);

            //TextField.DecorationBoundingBox
            tf1.DecorationBoundingBox = new Rectangle(int1, int2, int3, int4);
            //TextField.InputColor
            tf1.InputColor = new Vector4(float1, float2, float3, float4);
            //TextField.PlaceholderTextColor
            tf1.PlaceholderTextColor = new Vector4(float1, float2, float3, float4);
            //TextField.PrimaryCursorColor
            tf1.PrimaryCursorColor = new Vector4(float1, float2, float3, float4);
            //TextField.SecondaryCursorColor
            tf1.SecondaryCursorColor = new Vector4(float1, float2, float3, float4);
            //TextField.SelectionHighlightColor
            tf1.SelectionHighlightColor = new Vector4(float1, float2, float3, float4);
            //TextField.ShadowColor
            tf1.ShadowColor = new Vector4(float1, float2, float3, float4);
            //TextField.ShadowOffset
            tf1.ShadowOffset = new Vector2(float1, float2);
            //TextField.TextColor
            tf1.TextColor = new Color(float1, float2, float3, float4);

            //TextLabel.ShadowColor
            tl1.ShadowColor = new Vector4(float1, float2, float3, float4);
            //TextLabel.ShadowOffset
            tl1.ShadowOffset = new Vector2(float1, float2);
            //TextLabel.TextColor
            tl1.TextColor = new Color(float1, float2, float3, float4);
            //TextLabel.UnderlineColor
            tl1.UnderlineColor = new Vector4(float1, float2, float3, float4);

            //View.Scale
            v1.Scale = new Vector3(float1, float2, float3);
            //View.BackgroundColor
            v1.BackgroundColor = new Color(float1, float2, float3, float4);
            //View.Padding
            v1.Padding = new Extents(ushort1, ushort2, ushort3, ushort4);
            //View.Margin
            v1.Margin = new Extents(ushort1, ushort2, ushort3, ushort4);
            //View.Color
            v1.Color = new Color(float1, float2, float3, float4);
            //View.AnchorPoint
            v1.AnchorPoint = new Position(float1, float2, float3);
            //View.CellIndex
            v1.CellIndex = new Vector2(float1, float2);
            //View.FlexMargin
            v1.FlexMargin = new Vector4(float1, float2, float3, float4);
            //View.PaddingEX
            v1.PaddingEX = new Extents(ushort1, ushort2, ushort3, ushort4);
            //View.SizeModeFactor
            v1.SizeModeFactor = new Vector3(float1, float2, float3);

            double end = DateTime.Now.Ticks;
            Tizen.Log.Fatal("NUITEST", $"setProperty1() elapsed time={(double)(end - start) / (double)TimeSpan.TicksPerMillisecond}ms");
        }
        void setProperty2()
        {
            double start = DateTime.Now.Ticks;

            // ImageView.PixelArea
            var var1 = iv1.PixelArea;
            iv1.PixelArea = new RelativeVector4(var1.X + valueFloatIncreament, var1.Y + valueFloatIncreament, var1.Z + valueFloatIncreament, var1.W + valueFloatIncreament);
            // ImageView.Border
            var var2 = iv1.Border;
            iv1.Border = new Rectangle(var2.X + valueIntIncreament, var2.Y + valueIntIncreament, var2.Width + valueIntIncreament, var2.Height + valueIntIncreament);

            //TextEditor.DecorationBoundingBox
            var var3 = te1.DecorationBoundingBox;
            te1.DecorationBoundingBox = new Rectangle(var3.X + valueIntIncreament, var3.Y + valueIntIncreament, var3.Width + valueIntIncreament, var3.Height + valueIntIncreament);
            //TextEditor.InputColor
            var var4 = te1.InputColor;
            te1.InputColor = new Vector4(var4.X + valueFloatIncreament, var4.Y + valueFloatIncreament, var4.Z + valueFloatIncreament, var4.W + valueFloatIncreament);
            //TextEditor.PlaceholderTextColor
            var var5 = te1.PlaceholderTextColor;
            te1.PlaceholderTextColor = new Color(var5.R + valueFloatIncreament, var5.G + valueFloatIncreament, var5.B + valueFloatIncreament, var5.A + valueFloatIncreament);
            //TextEditor.PrimaryCursorColor
            var var6 = te1.PrimaryCursorColor;
            te1.PrimaryCursorColor = new Vector4(var6.X + valueFloatIncreament, var6.Y + valueFloatIncreament, var6.Z + valueFloatIncreament, var6.W + valueFloatIncreament);
            //TextEditor.SecondaryCursorColor
            var var7 = te1.SecondaryCursorColor;
            te1.SecondaryCursorColor = new Vector4(var7.X + valueFloatIncreament, var7.Y + valueFloatIncreament, var7.Z + valueFloatIncreament, var7.W + valueFloatIncreament);
            //TextEditor.SelectionHighlightColor
            var var8 = te1.SelectionHighlightColor;
            te1.SelectionHighlightColor = new Vector4(var8.X + valueFloatIncreament, var8.Y + valueFloatIncreament, var8.Z + valueFloatIncreament, var8.W + valueFloatIncreament);
            //TextEditor.TextColor
            var var9 = te1.TextColor;
            te1.TextColor = new Vector4(var9.X + valueFloatIncreament, var9.Y + valueFloatIncreament, var9.Z + valueFloatIncreament, var9.W + valueFloatIncreament);
            //TextField.DecorationBoundingBox
            var var10 = tf1.DecorationBoundingBox;
            tf1.DecorationBoundingBox = new Rectangle(var10.X + valueIntIncreament, var10.Y + valueIntIncreament, var10.Width + valueIntIncreament, var10.Height + valueIntIncreament);
            //TextField.InputColor
            var var11 = tf1.InputColor;
            tf1.InputColor = new Vector4(var11.X + valueFloatIncreament, var11.Y + valueFloatIncreament, var11.Z + valueFloatIncreament, var11.W + valueFloatIncreament);
            //TextField.PlaceholderTextColor
            var var12 = tf1.PlaceholderTextColor;
            tf1.PlaceholderTextColor = new Vector4(var12.X + valueFloatIncreament, var12.Y + valueFloatIncreament, var12.Z + valueFloatIncreament, var12.W + valueFloatIncreament);
            //TextField.PrimaryCursorColor
            var var13 = tf1.PrimaryCursorColor;
            tf1.PrimaryCursorColor = new Vector4(var13.X + valueFloatIncreament, var13.Y + valueFloatIncreament, var13.Z + valueFloatIncreament, var13.W + valueFloatIncreament);
            //TextField.SecondaryCursorColor
            var var14 = tf1.SecondaryCursorColor;
            tf1.SecondaryCursorColor = new Vector4(var14.X + valueFloatIncreament, var14.Y + valueFloatIncreament, var14.Z + valueFloatIncreament, var14.W + valueFloatIncreament);
            //TextField.SelectionHighlightColor
            var var15 = tf1.SelectionHighlightColor;
            tf1.SelectionHighlightColor = new Vector4(var15.X + valueFloatIncreament, var15.Y + valueFloatIncreament, var15.Z + valueFloatIncreament, var15.W + valueFloatIncreament);
            //TextField.ShadowColor
            var var16 = tf1.ShadowColor;
            tf1.ShadowColor = new Vector4(var16.X + valueFloatIncreament, var16.Y + valueFloatIncreament, var16.Z + valueFloatIncreament, var16.W + valueFloatIncreament);
            //TextField.ShadowOffset
            var var17 = tf1.ShadowOffset;
            tf1.ShadowOffset = new Vector2(var17.X + valueFloatIncreament, var17.Y + valueFloatIncreament);
            //TextField.TextColor
            var var18 = tf1.TextColor;
            tf1.TextColor = new Color(var18.R + valueFloatIncreament, var18.G + valueFloatIncreament, var18.B + valueFloatIncreament, var18.A + valueFloatIncreament);

            //TextLabel.ShadowColor
            var var19 = tl1.ShadowColor;
            tl1.ShadowColor = new Vector4(var19.X + valueFloatIncreament, var19.Y + valueFloatIncreament, var19.Z + valueFloatIncreament, var19.W + valueFloatIncreament);
            //TextLabel.ShadowOffset
            var var20 = tl1.ShadowOffset;
            tl1.ShadowOffset = new Vector2(var20.X + valueFloatIncreament, var20.Y + valueFloatIncreament);
            //TextLabel.TextColor
            var var21 = tl1.TextColor;
            tl1.TextColor = new Color(var21.R + valueFloatIncreament, var21.G + valueFloatIncreament, var21.B + valueFloatIncreament, var21.A + valueFloatIncreament);
            //TextLabel.UnderlineColor
            var var22 = tl1.UnderlineColor;
            tl1.UnderlineColor = new Vector4(var22.X + valueFloatIncreament, var22.Y + valueFloatIncreament, var22.Z + valueFloatIncreament, var22.W + valueFloatIncreament);

            //View.Scale
            var var23 = v1.Scale;
            v1.Scale = new Vector3(var23.X + valueFloatIncreament, var23.Y + valueFloatIncreament, var23.Z + valueFloatIncreament);
            //View.BackgroundColor
            var var24 = v1.BackgroundColor;
            v1.BackgroundColor = new Color(var24.R + valueFloatIncreament, var24.G + valueFloatIncreament, var24.B + valueFloatIncreament, var24.A + valueFloatIncreament);
            //View.Padding
            var var25 = v1.Padding;
            v1.Padding = new Extents((ushort)(var25.Start + valueUshortIncreament), (ushort)(var25.End + valueUshortIncreament), (ushort)(var25.Top + valueUshortIncreament), (ushort)(var25.Bottom + valueUshortIncreament));
            //View.Margin
            var var26 = v1.Margin;
            v1.Margin = new Extents((ushort)(var26.Start + valueUshortIncreament), (ushort)(var26.End + valueUshortIncreament), (ushort)(var26.Top + valueUshortIncreament), (ushort)(var26.Bottom + valueUshortIncreament));
            //View.Color
            var var27 = v1.Color;
            v1.Color = new Color(var27.R + valueFloatIncreament, var27.G + valueFloatIncreament, var27.B + valueFloatIncreament, var27.A + valueFloatIncreament);
            //View.AnchorPoint
            var var28 = v1.AnchorPoint;
            v1.AnchorPoint = new Position(var28.X + valueFloatIncreament, var28.Y + valueFloatIncreament, var28.Z + valueFloatIncreament);
            //View.CellIndex
            var var29 = v1.CellIndex;
            v1.CellIndex = new Vector2(var29.X + valueFloatIncreament, var29.Y + valueFloatIncreament);
            //View.FlexMargin
            var var30 = v1.FlexMargin;
            v1.FlexMargin = new Vector4(var30.X + valueFloatIncreament, var30.Y + valueFloatIncreament, var30.Z + valueFloatIncreament, var30.W + valueFloatIncreament);
            //View.PaddingEX
            var var31 = v1.PaddingEX;
            v1.PaddingEX = new Extents((ushort)(var31.Start + valueUshortIncreament), (ushort)(var31.End + valueUshortIncreament), (ushort)(var31.Top + valueUshortIncreament), (ushort)(var31.Bottom + valueUshortIncreament));
            //View.SizeModeFactor
            var var32 = v1.SizeModeFactor;
            v1.SizeModeFactor = new Vector3(var32.X + valueFloatIncreament, var32.Y + valueFloatIncreament, var32.Z + valueFloatIncreament);


            double end = DateTime.Now.Ticks;
            Tizen.Log.Fatal("NUITEST", $"setProperty2() elapsed time={(double)(end - start) / (double)TimeSpan.TicksPerMillisecond}ms");
        }

        void setProperty3()
        {
            iv1.PixelArea = new RelativeVector4(0.5f, 0.5f, 0.5f, 0.5f);
            iv1.PixelArea.X = 0.4f;

            if(iv1.PixelArea.X == 0.4f)
            {
                Tizen.Log.Fatal("NUITEST", $"property cascading set patch is applied!");
            }
            else if(iv1.PixelArea.X == 0.5f)
            {
                Tizen.Log.Fatal("NUITEST", $"property cascading set patch is NOT applied!");
            }
            else
            {
                Tizen.Log.Fatal("NUITEST", $"Something wrong! this log shold not be shown!");
            }

            double start = DateTime.Now.Ticks;

            // ImageView.PixelArea
            iv1.PixelArea.X += valueFloatIncreament; iv1.PixelArea.Y += valueFloatIncreament; iv1.PixelArea.Z += valueFloatIncreament; iv1.PixelArea.W += valueFloatIncreament;
            // ImageView.Border
            iv1.Border.X += valueIntIncreament; iv1.Border.Y += valueIntIncreament; iv1.Border.Width += valueIntIncreament; iv1.Border.Height += valueIntIncreament;

            //TextEditor.DecorationBoundingBox
            te1.DecorationBoundingBox.X += valueIntIncreament; te1.DecorationBoundingBox.Y += valueIntIncreament; te1.DecorationBoundingBox.Width += valueIntIncreament; te1.DecorationBoundingBox.Height += valueIntIncreament;
            //TextEditor.InputColor
            te1.InputColor.X += valueFloatIncreament; te1.InputColor.Y += valueFloatIncreament; te1.InputColor.Z += valueFloatIncreament; te1.InputColor.W += valueFloatIncreament;
            //TextEditor.PlaceholderTextColor
            te1.PlaceholderTextColor.R += valueFloatIncreament; te1.PlaceholderTextColor.G += valueFloatIncreament; te1.PlaceholderTextColor.B += valueFloatIncreament; te1.PlaceholderTextColor.A += valueFloatIncreament;
            //TextEditor.PrimaryCursorColor
            te1.PrimaryCursorColor.X += valueFloatIncreament; te1.PrimaryCursorColor.Y += valueFloatIncreament; te1.PrimaryCursorColor.Z += valueFloatIncreament; te1.PrimaryCursorColor.W += valueFloatIncreament;
            //TextEditor.SecondaryCursorColor
            te1.SecondaryCursorColor.X += valueFloatIncreament; te1.SecondaryCursorColor.Y += valueFloatIncreament; te1.SecondaryCursorColor.Z += valueFloatIncreament; te1.SecondaryCursorColor.W += valueFloatIncreament;
            //TextEditor.SelectionHighlightColor
            te1.SelectionHighlightColor.X += valueFloatIncreament; te1.SelectionHighlightColor.Y += valueFloatIncreament; te1.SelectionHighlightColor.Z += valueFloatIncreament; te1.SelectionHighlightColor.W += valueFloatIncreament;
            //TextEditor.TextColor
            te1.TextColor.X += valueFloatIncreament; te1.TextColor.Y += valueFloatIncreament; te1.TextColor.Z += valueFloatIncreament; te1.TextColor.W += valueFloatIncreament;
            //TextField.DecorationBoundingBox
            tf1.DecorationBoundingBox.X += valueIntIncreament; tf1.DecorationBoundingBox.Y += valueIntIncreament; tf1.DecorationBoundingBox.Width += valueIntIncreament; tf1.DecorationBoundingBox.Height += valueIntIncreament;
            //TextField.InputColor
            tf1.InputColor.X += valueFloatIncreament; tf1.InputColor.Y += valueFloatIncreament; tf1.InputColor.Z += valueFloatIncreament; tf1.InputColor.W += valueFloatIncreament;
            //TextField.PlaceholderTextColor
            tf1.PlaceholderTextColor.X += valueFloatIncreament; tf1.PlaceholderTextColor.Y += valueFloatIncreament; tf1.PlaceholderTextColor.Z += valueFloatIncreament; tf1.PlaceholderTextColor.W += valueFloatIncreament;
            //TextField.PrimaryCursorColor
            tf1.PrimaryCursorColor.X += valueFloatIncreament; tf1.PrimaryCursorColor.Y += valueFloatIncreament; tf1.PrimaryCursorColor.Z += valueFloatIncreament; tf1.PrimaryCursorColor.W += valueFloatIncreament;
            //TextField.SecondaryCursorColor
            tf1.SecondaryCursorColor.X += valueFloatIncreament; tf1.SecondaryCursorColor.Y += valueFloatIncreament; tf1.SecondaryCursorColor.Z += valueFloatIncreament; tf1.SecondaryCursorColor.W += valueFloatIncreament;
            //TextField.SelectionHighlightColor
            tf1.SelectionHighlightColor.X += valueFloatIncreament; tf1.SelectionHighlightColor.Y += valueFloatIncreament; tf1.SelectionHighlightColor.Z += valueFloatIncreament; tf1.SelectionHighlightColor.W += valueFloatIncreament;
            //TextField.ShadowColor
            tf1.ShadowColor.X += valueFloatIncreament; tf1.ShadowColor.Y += valueFloatIncreament; tf1.ShadowColor.Z += valueFloatIncreament; tf1.ShadowColor.W += valueFloatIncreament;
            //TextField.ShadowOffset
            tf1.ShadowOffset.X += valueFloatIncreament; tf1.ShadowOffset.Y += valueFloatIncreament;
            //TextField.TextColor
            tf1.TextColor.R += valueFloatIncreament; tf1.TextColor.G += valueFloatIncreament; tf1.TextColor.B += valueFloatIncreament; tf1.TextColor.A += valueFloatIncreament;

            //TextLabel.ShadowColor
            tl1.ShadowColor.X += valueFloatIncreament; tl1.ShadowColor.Y += valueFloatIncreament; tl1.ShadowColor.Z += valueFloatIncreament; tl1.ShadowColor.W += valueFloatIncreament;
            //TextLabel.ShadowOffset
            tl1.ShadowOffset.X += valueFloatIncreament; tl1.ShadowOffset.Y += valueFloatIncreament;
            //TextLabel.TextColor
            tl1.TextColor.R += valueFloatIncreament; tl1.TextColor.G += valueFloatIncreament; tl1.TextColor.B += valueFloatIncreament; tl1.TextColor.A += valueFloatIncreament;
            //TextLabel.UnderlineColor
            tl1.UnderlineColor.X += valueFloatIncreament; tl1.UnderlineColor.Y += valueFloatIncreament; tl1.UnderlineColor.Z += valueFloatIncreament; tl1.UnderlineColor.W += valueFloatIncreament;

            //View.Scale
            v1.Scale.X += valueFloatIncreament; v1.Scale.Y += valueFloatIncreament; v1.Scale.Z += valueFloatIncreament;
            //View.BackgroundColor
            v1.BackgroundColor.R += valueFloatIncreament; v1.BackgroundColor.G += valueFloatIncreament; v1.BackgroundColor.B += valueFloatIncreament; v1.BackgroundColor.A += valueFloatIncreament;
            //View.Padding
            v1.Padding.Start += valueUshortIncreament; v1.Padding.End += valueUshortIncreament; v1.Padding.Top += valueUshortIncreament; v1.Padding.Bottom += valueUshortIncreament;
            //View.Margin
            v1.Margin.Start += valueUshortIncreament; v1.Margin.End += valueUshortIncreament; v1.Margin.Top += valueUshortIncreament; v1.Margin.Bottom += valueUshortIncreament;
            //View.Color
            v1.Color.R += valueFloatIncreament; v1.Color.G += valueFloatIncreament; v1.Color.B += valueFloatIncreament; v1.Color.A += valueFloatIncreament;
            //View.AnchorPoint
            v1.AnchorPoint.X += valueFloatIncreament; v1.AnchorPoint.Y += valueFloatIncreament; v1.AnchorPoint.Z += valueFloatIncreament;
            //View.CellIndex
            v1.CellIndex.X += valueFloatIncreament; v1.CellIndex.Y += valueFloatIncreament;
            //View.FlexMargin
            v1.FlexMargin.X += valueFloatIncreament; v1.FlexMargin.Y += valueFloatIncreament; v1.FlexMargin.Z += valueFloatIncreament; v1.FlexMargin.W += valueFloatIncreament;
            //View.PaddingEX
            v1.PaddingEX.Start += valueUshortIncreament; v1.PaddingEX.End += valueUshortIncreament; v1.PaddingEX.Top += valueUshortIncreament; v1.PaddingEX.Bottom += valueUshortIncreament;
            //View.SizeModeFactor
            v1.SizeModeFactor.X += valueFloatIncreament; v1.SizeModeFactor.Y += valueFloatIncreament; v1.SizeModeFactor.Z += valueFloatIncreament;

            double end = DateTime.Now.Ticks;
            Tizen.Log.Fatal("NUITEST", $"setProperty3() elapsed time={(double)(end - start) / (double)TimeSpan.TicksPerMillisecond}ms");
        }
        void initMultiCascadePropertySetSpeedCheck()
        {
            root = new View();
            root.Focusable = true;
            Window.Instance.Add(root);
            root.KeyEvent += Root_KeyEvent;
            FocusManager.Instance.SetCurrentFocusView(root);
            Window.Instance.BackgroundColor = Color.White;

            //ImageView
            iv1 = new ImageView();
            iv1.ResourceUrl = Applications.Application.Current.DirectoryInfo.Resource + "/images/gallery-0.jpg";
            iv1.Size2D = new Size2D(100, 100);
            iv1.Position2D = new Position2D(100, 100);
            root.Add(iv1);
            //TextEditor
            te1 = new TextEditor();
            te1.Text = "test TextEditor";
            te1.Size2D = new Size2D(100, 100);
            te1.Position2D = new Position2D(200, 200);
            root.Add(te1);
            //TextField
            tf1 = new TextField();
            tf1.Text = "test TextField";
            tf1.Size2D = new Size2D(100, 100);
            tf1.Position2D = new Position2D(300, 300);
            root.Add(tf1);
            //TextLabel
            tl1 = new TextLabel();
            tl1.Text = "test TextLabel";
            tl1.Size2D = new Size2D(100, 100);
            tl1.Position2D = new Position2D(400, 400);
            root.Add(tl1);
            //View
            v1 = new View();
            v1.Size2D = new Size2D(100, 100);
            v1.Position2D = new Position2D(500, 500);
            root.Add(v1);
        }

        private bool Root_KeyEvent(object source, View.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down)
            {
                if (e.Key.KeyPressedName == "1")
                {
                }
            }
            return true;
        }

        void checkMultiCascadePropertySet()
        {
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////
        public void Activate()
        {
            initMultiCascadePropertySetSpeedCheck();
            setProperty1();
            setProperty1();
            setProperty1();

            setProperty2();
            setProperty2();
            setProperty2();

            setProperty3();
            setProperty3();
            setProperty3();
        }
        public void Deactivate()
        {
            root.KeyEvent -= Root_KeyEvent;
        }
    }
}

