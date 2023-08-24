using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Samples
{
    public class MyPropertyCheckTest : IExample
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

        void initMultiCascadePropertySet()
        {
            root = new View();
            root.Focusable = true;
            Window.Instance.Add(root);
            root.KeyEvent += Root_KeyEvent;
            FocusManager.Instance.SetCurrentFocusView(root);
            Window.Instance.BackgroundColor = Color.White;

            //ImageView
            iv1 = new ImageView();
            iv1.ResourceUrl = Applications.Application.Current.DirectoryInfo.Resource + "gallary-1.jpg";
            iv1.Size2D = new Size(100, 100);
            iv1.Position2D = new Position2D(100, 100);
            root.Add(iv1);
            //TextEditor
            te1 = new TextEditor();
            te1.Text = "test TextEditor";
            te1.Size2D = new Size(100, 100);
            te1.Position2D = new Position2D(200, 200);
            root.Add(te1);
            //TextField
            tf1 = new TextField();
            tf1.Text = "test TextField";
            tf1.Size2D = new Size(100, 100);
            tf1.Position2D = new Position2D(300, 300);
            root.Add(tf1);
            //TextLabel
            tl1 = new TextLabel();
            tl1.Text = "test TextLabel";
            tl1.Size2D = new Size(100, 100);
            tl1.Position2D = new Position2D(400, 400);
            root.Add(tl1);
            //View
            v1 = new View();
            v1.Size2D = new Size(100, 100);
            v1.Position2D = new Position2D(500, 500);
            root.Add(v1);


            // ImageView.PixelArea
            iv1.PixelArea = new RelativeVector4(valueFloatShouldBe, valueFloatShouldBe, valueFloatShouldBe, valueFloatShouldBe);
            // ImageView.Border
            iv1.Border = new Rectangle(valueIntShouldBe, valueIntShouldBe, valueIntShouldBe, valueIntShouldBe);

            //TextEditor.DecorationBoundingBox
            te1.DecorationBoundingBox = new Rectangle(valueIntShouldBe, valueIntShouldBe, valueIntShouldBe, valueIntShouldBe);
            //TextEditor.InputColor
            te1.InputColor = new Vector4(valueFloatShouldBe, valueFloatShouldBe, valueFloatShouldBe, valueFloatShouldBe);
            //TextEditor.PlaceholderTextColor
            te1.PlaceholderTextColor = new Color(valueFloatShouldBe, valueFloatShouldBe, valueFloatShouldBe, valueFloatShouldBe);
            //TextEditor.PrimaryCursorColor
            te1.PrimaryCursorColor = new Vector4(valueFloatShouldBe, valueFloatShouldBe, valueFloatShouldBe, valueFloatShouldBe);
            //TextEditor.SecondaryCursorColor
            te1.SecondaryCursorColor = new Vector4(valueFloatShouldBe, valueFloatShouldBe, valueFloatShouldBe, valueFloatShouldBe);
            //TextEditor.SelectionHighlightColor
            te1.SelectionHighlightColor = new Vector4(valueFloatShouldBe, valueFloatShouldBe, valueFloatShouldBe, valueFloatShouldBe);
            //TextEditor.TextColor
            te1.TextColor = new Vector4(valueFloatShouldBe, valueFloatShouldBe, valueFloatShouldBe, valueFloatShouldBe);

            //TextField.DecorationBoundingBox
            tf1.DecorationBoundingBox = new Rectangle(valueIntShouldBe, valueIntShouldBe, valueIntShouldBe, valueIntShouldBe);
            //TextField.InputColor
            tf1.InputColor = new Vector4(valueFloatShouldBe, valueFloatShouldBe, valueFloatShouldBe, valueFloatShouldBe);
            //TextField.PlaceholderTextColor
            tf1.PlaceholderTextColor = new Vector4(valueFloatShouldBe, valueFloatShouldBe, valueFloatShouldBe, valueFloatShouldBe);
            //TextField.PrimaryCursorColor
            tf1.PrimaryCursorColor = new Vector4(valueFloatShouldBe, valueFloatShouldBe, valueFloatShouldBe, valueFloatShouldBe);
            //TextField.SecondaryCursorColor
            tf1.SecondaryCursorColor = new Vector4(valueFloatShouldBe, valueFloatShouldBe, valueFloatShouldBe, valueFloatShouldBe);
            //TextField.SelectionHighlightColor
            tf1.SelectionHighlightColor = new Vector4(valueFloatShouldBe, valueFloatShouldBe, valueFloatShouldBe, valueFloatShouldBe);
            //TextField.ShadowColor
            tf1.ShadowColor = new Vector4(valueFloatShouldBe, valueFloatShouldBe, valueFloatShouldBe, valueFloatShouldBe);
            //TextField.ShadowOffset
            tf1.ShadowOffset = new Vector2(valueFloatShouldBe, valueFloatShouldBe);
            //TextField.TextColor
            tf1.TextColor = new Color(valueFloatShouldBe, valueFloatShouldBe, valueFloatShouldBe, valueFloatShouldBe);

            //TextLabel.ShadowColor
            tl1.ShadowColor = new Vector4(valueFloatShouldBe, valueFloatShouldBe, valueFloatShouldBe, valueFloatShouldBe);
            //TextLabel.ShadowOffset
            tl1.ShadowOffset = new Vector2(valueFloatShouldBe, valueFloatShouldBe);
            //TextLabel.TextColor
            tl1.TextColor = new Color(valueFloatShouldBe, valueFloatShouldBe, valueFloatShouldBe, valueFloatShouldBe);
            //TextLabel.UnderlineColor
            tl1.UnderlineColor = new Vector4(valueFloatShouldBe, valueFloatShouldBe, valueFloatShouldBe, valueFloatShouldBe);

            //View.Scale
            v1.Scale = new Vector3(valueFloatShouldBe, valueFloatShouldBe, valueFloatShouldBe);
            //View.BackgroundColor
            v1.BackgroundColor = new Color(valueFloatShouldBe, valueFloatShouldBe, valueFloatShouldBe, valueFloatShouldBe);
            //View.Padding
            v1.Padding = new Extents(valueUshortShouldBe, valueUshortShouldBe, valueUshortShouldBe, valueUshortShouldBe);
            //View.Margin
            v1.Margin = new Extents(valueUshortShouldBe, valueUshortShouldBe, valueUshortShouldBe, valueUshortShouldBe);
            //View.Color
            v1.Color = new Color(valueFloatShouldBe, valueFloatShouldBe, valueFloatShouldBe, 1.0f);
            //View.AnchorPoint
            v1.AnchorPoint = new Position(valueFloatShouldBe, valueFloatShouldBe, valueFloatShouldBe);
            //View.CellIndex
            v1.CellIndex = new Vector2(valueFloatShouldBe, valueFloatShouldBe);
            //View.FlexMargin
            v1.FlexMargin = new Vector4(valueFloatShouldBe, valueFloatShouldBe, valueFloatShouldBe, valueFloatShouldBe);
            //View.PaddingEX
            v1.PaddingEX = new Extents(valueUshortShouldBe, valueUshortShouldBe, valueUshortShouldBe, valueUshortShouldBe);
            //View.SizeModeFactor
            v1.SizeModeFactor = new Vector3(valueFloatShouldBe, valueFloatShouldBe, valueFloatShouldBe);

        }

        private bool Root_KeyEvent(object source, View.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down)
            {
                if (e.Key.KeyPressedName == "1")
                {
                    //ImageView
                    iv1.PixelArea.X += valueFloatIncreament; iv1.PixelArea.Y += valueFloatIncreament; iv1.PixelArea.Z += valueFloatIncreament; iv1.PixelArea.W += valueFloatIncreament;
                    iv1.Border.X += valueIntIncreament; iv1.Border.Y += valueIntIncreament; iv1.Border.Width += valueIntIncreament; iv1.Border.Height += valueIntIncreament;

                    //TextEditor
                    te1.DecorationBoundingBox.X += valueIntIncreament; te1.DecorationBoundingBox.Y += valueIntIncreament; te1.DecorationBoundingBox.Width += valueIntIncreament; te1.DecorationBoundingBox.Height += valueIntIncreament;
                    te1.InputColor.X += valueFloatIncreament; te1.InputColor.Y += valueFloatIncreament; te1.InputColor.Z += valueFloatIncreament; te1.InputColor.W += valueFloatIncreament;
                    te1.PlaceholderTextColor.R += valueFloatIncreament; te1.PlaceholderTextColor.G += valueFloatIncreament; te1.PlaceholderTextColor.B += valueFloatIncreament; te1.PlaceholderTextColor.A += valueFloatIncreament;
                    te1.PrimaryCursorColor.X += valueFloatIncreament; te1.PrimaryCursorColor.Y += valueFloatIncreament; te1.PrimaryCursorColor.Z += valueFloatIncreament; te1.PrimaryCursorColor.W += valueFloatIncreament;
                    te1.SecondaryCursorColor.X += valueFloatIncreament; te1.SecondaryCursorColor.Y += valueFloatIncreament; te1.SecondaryCursorColor.Z += valueFloatIncreament; te1.SecondaryCursorColor.W += valueFloatIncreament;
                    te1.SelectionHighlightColor.X += valueFloatIncreament; te1.SelectionHighlightColor.Y += valueFloatIncreament; te1.SelectionHighlightColor.Z += valueFloatIncreament; te1.SelectionHighlightColor.W += valueFloatIncreament;
                    te1.TextColor.X += valueFloatIncreament; te1.TextColor.Y += valueFloatIncreament; te1.TextColor.Z += valueFloatIncreament; te1.TextColor.W += valueFloatIncreament;

                    //TextField
                    tf1.DecorationBoundingBox.X += valueIntIncreament; tf1.DecorationBoundingBox.Y += valueIntIncreament; tf1.DecorationBoundingBox.Width += valueIntIncreament; tf1.DecorationBoundingBox.Height += valueIntIncreament;
                    tf1.InputColor.X += valueFloatIncreament; tf1.InputColor.Y += valueFloatIncreament; tf1.InputColor.Z += valueFloatIncreament; tf1.InputColor.W += valueFloatIncreament;
                    tf1.PlaceholderTextColor.X += valueFloatIncreament; tf1.PlaceholderTextColor.Y += valueFloatIncreament; tf1.PlaceholderTextColor.Z += valueFloatIncreament; tf1.PlaceholderTextColor.W += valueFloatIncreament;
                    tf1.PrimaryCursorColor.X += valueFloatIncreament; tf1.PrimaryCursorColor.Y += valueFloatIncreament; tf1.PrimaryCursorColor.Z += valueFloatIncreament; tf1.PrimaryCursorColor.W += valueFloatIncreament;
                    tf1.SecondaryCursorColor.X += valueFloatIncreament; tf1.SecondaryCursorColor.Y += valueFloatIncreament; tf1.SecondaryCursorColor.Z += valueFloatIncreament; tf1.SecondaryCursorColor.W += valueFloatIncreament;
                    tf1.SelectionHighlightColor.X += valueFloatIncreament; tf1.SelectionHighlightColor.Y += valueFloatIncreament; tf1.SelectionHighlightColor.Z += valueFloatIncreament; tf1.SelectionHighlightColor.W += valueFloatIncreament;
                    tf1.ShadowColor.X += valueFloatIncreament; tf1.ShadowColor.Y += valueFloatIncreament; tf1.ShadowColor.Z += valueFloatIncreament; tf1.ShadowColor.W += valueFloatIncreament;
                    tf1.ShadowOffset.X += valueFloatIncreament; tf1.ShadowOffset.Y += valueFloatIncreament;
                    tf1.TextColor.R += valueFloatIncreament; tf1.TextColor.G += valueFloatIncreament; tf1.TextColor.B += valueFloatIncreament; tf1.TextColor.A += valueFloatIncreament;

                    //TextLabel
                    tl1.ShadowColor.X += valueFloatIncreament; tl1.ShadowColor.Y += valueFloatIncreament; tl1.ShadowColor.Z += valueFloatIncreament; tl1.ShadowColor.W += valueFloatIncreament;
                    tl1.ShadowOffset.X += valueFloatIncreament; tl1.ShadowOffset.Y += valueFloatIncreament;
                    tl1.TextColor.R += valueFloatIncreament; tl1.TextColor.G += valueFloatIncreament; tl1.TextColor.B += valueFloatIncreament; tl1.TextColor.A += valueFloatIncreament;
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
                    v1.Color.R += valueFloatIncreament; v1.Color.G += valueFloatIncreament; v1.Color.B += valueFloatIncreament;
                    //View.AnchorPoint
                    v1.AnchorPoint.X += valueFloatIncreament; v1.AnchorPoint.Y += valueFloatIncreament; v1.AnchorPoint.Z += valueFloatIncreament;
                    //View.CellIndex
                    v1.CellIndex.X += valueFloatIncreament; v1.CellIndex.Y += valueFloatIncreament;
                    //View.FlexMargin
                    v1.FlexMargin.X += valueFloatIncreament; v1.FlexMargin.Y += valueFloatIncreament; v1.FlexMargin.Z += valueFloatIncreament; v1.FlexMargin.W += valueFloatIncreament;
                    //View.PaddingEX
                    //Padding and PaddingEX are same property
                    //v1.PaddingEX.Start += valueUshortIncreament; v1.PaddingEX.End += valueUshortIncreament; v1.PaddingEX.Top += valueUshortIncreament; v1.PaddingEX.Bottom += valueUshortIncreament;
                    //View.SizeModeFactor
                    v1.SizeModeFactor.X += valueFloatIncreament; v1.SizeModeFactor.Y += valueFloatIncreament; v1.SizeModeFactor.Z += valueFloatIncreament;

                    valueFloatShouldBe += valueFloatIncreament;
                    valueIntShouldBe += valueIntIncreament;
                    valueUshortShouldBe += valueUshortIncreament;

                    //ImageView
                    if (iv1.PixelArea.X != valueFloatShouldBe || iv1.PixelArea.Y != valueFloatShouldBe || iv1.PixelArea.Z != valueFloatShouldBe || iv1.PixelArea.W != valueFloatShouldBe)
                    {
                        throw new ApplicationException("ImageView.PixelArea property check ERROR!");
                    }
                    if (iv1.Border.X != valueIntShouldBe || iv1.Border.Y != valueIntShouldBe || iv1.Border.Width != valueIntShouldBe || iv1.Border.Height != valueIntShouldBe)
                    {
                        throw new ApplicationException("ImageView.Border property check ERROR!");
                    }

                    //TextEditor
                    if (te1.DecorationBoundingBox.X != valueIntShouldBe || te1.DecorationBoundingBox.Y != valueIntShouldBe || te1.DecorationBoundingBox.Width != valueIntShouldBe || te1.DecorationBoundingBox.Height != valueIntShouldBe)
                    {
                        throw new ApplicationException("TextEditor.DecorationBoundingBox property check ERROR!");
                    }
                    if (te1.InputColor.X != valueFloatShouldBe || te1.InputColor.Y != valueFloatShouldBe || te1.InputColor.Z != valueFloatShouldBe || te1.InputColor.W != valueFloatShouldBe)
                    {
                        throw new ApplicationException("TextEditor.InputColor property check ERROR!");
                    }
                    if (te1.PlaceholderTextColor.R != valueFloatShouldBe || te1.PlaceholderTextColor.G != valueFloatShouldBe || te1.PlaceholderTextColor.B != valueFloatShouldBe || te1.PlaceholderTextColor.A != valueFloatShouldBe)
                    {
                        throw new ApplicationException("TextEditor.PlaceholderTextColor property check ERROR!");
                    }
                    if (te1.PrimaryCursorColor.X != valueFloatShouldBe || te1.PrimaryCursorColor.Y != valueFloatShouldBe || te1.PrimaryCursorColor.Z != valueFloatShouldBe || te1.PrimaryCursorColor.W != valueFloatShouldBe)
                    {
                        throw new ApplicationException("TextEditor.PrimaryCursorColor property check ERROR!");
                    }
                    if (te1.SecondaryCursorColor.X != valueFloatShouldBe || te1.SecondaryCursorColor.Y != valueFloatShouldBe || te1.SecondaryCursorColor.Z != valueFloatShouldBe || te1.SecondaryCursorColor.W != valueFloatShouldBe)
                    {
                        throw new ApplicationException("TextEditor.SecondaryCursorColor property check ERROR!");
                    }
                    if (te1.SelectionHighlightColor.X != valueFloatShouldBe || te1.SelectionHighlightColor.Y != valueFloatShouldBe || te1.SelectionHighlightColor.Z != valueFloatShouldBe || te1.SelectionHighlightColor.W != valueFloatShouldBe)
                    {
                        throw new ApplicationException("TextEditor.SelectionHighlightColor property check ERROR!");
                    }
                    if (te1.TextColor.X != valueFloatShouldBe || te1.TextColor.Y != valueFloatShouldBe || te1.TextColor.Z != valueFloatShouldBe || te1.TextColor.W != valueFloatShouldBe)
                    {
                        throw new ApplicationException("TextEditor.TextColor property check ERROR!");
                    }

                    //TextField
                    if (tf1.DecorationBoundingBox.X != valueIntShouldBe || tf1.DecorationBoundingBox.Y != valueIntShouldBe || tf1.DecorationBoundingBox.Width != valueIntShouldBe || tf1.DecorationBoundingBox.Height != valueIntShouldBe)
                    {
                        throw new ApplicationException("TextField.DecorationBoundingBox property check ERROR!");
                    }
                    if (tf1.InputColor.X != valueFloatShouldBe || tf1.InputColor.Y != valueFloatShouldBe || tf1.InputColor.Z != valueFloatShouldBe || tf1.InputColor.W != valueFloatShouldBe)
                    {
                        throw new ApplicationException("TextField.InputColor property check ERROR!");
                    }
                    if (tf1.PlaceholderTextColor.X != valueFloatShouldBe || tf1.PlaceholderTextColor.Y != valueFloatShouldBe || tf1.PlaceholderTextColor.Z != valueFloatShouldBe || tf1.PlaceholderTextColor.W != valueFloatShouldBe)
                    {
                        throw new ApplicationException("TextField.PlaceholderTextColor property check ERROR!");
                    }
                    if (tf1.PrimaryCursorColor.X != valueFloatShouldBe || tf1.PrimaryCursorColor.Y != valueFloatShouldBe || tf1.PrimaryCursorColor.Z != valueFloatShouldBe || tf1.PrimaryCursorColor.W != valueFloatShouldBe)
                    {
                        throw new ApplicationException("TextField.PrimaryCursorColor property check ERROR!");
                    }
                    if (tf1.SecondaryCursorColor.X != valueFloatShouldBe || tf1.SecondaryCursorColor.Y != valueFloatShouldBe || tf1.SecondaryCursorColor.Z != valueFloatShouldBe || tf1.SecondaryCursorColor.W != valueFloatShouldBe)
                    {
                        throw new ApplicationException("TextField.SecondaryCursorColor property check ERROR!");
                    }
                    if (tf1.SelectionHighlightColor.X != valueFloatShouldBe || tf1.SelectionHighlightColor.Y != valueFloatShouldBe || tf1.SelectionHighlightColor.Z != valueFloatShouldBe || tf1.SelectionHighlightColor.W != valueFloatShouldBe)
                    {
                        throw new ApplicationException("TextField.SelectionHighlightColor property check ERROR!");
                    }
                    if (tf1.SelectionHighlightColor.X != valueFloatShouldBe || tf1.SelectionHighlightColor.Y != valueFloatShouldBe || tf1.SelectionHighlightColor.Z != valueFloatShouldBe || tf1.SelectionHighlightColor.W != valueFloatShouldBe)
                    {
                        throw new ApplicationException("TextField.SelectionHighlightColor property check ERROR!");
                    }
                    if (tf1.ShadowColor.X != valueFloatShouldBe || tf1.ShadowColor.Y != valueFloatShouldBe || tf1.ShadowColor.Z != valueFloatShouldBe || tf1.ShadowColor.W != valueFloatShouldBe)
                    {
                        throw new ApplicationException("TextField.ShadowColor property check ERROR!");
                    }
                    if (tf1.ShadowOffset.X != valueFloatShouldBe || tf1.ShadowOffset.Y != valueFloatShouldBe)
                    {
                        throw new ApplicationException("TextField.ShadowOffset property check ERROR!");
                    }
                    if (tf1.TextColor.R != valueFloatShouldBe || tf1.TextColor.G != valueFloatShouldBe || tf1.TextColor.B != valueFloatShouldBe || tf1.TextColor.A != valueFloatShouldBe)
                    {
                        throw new ApplicationException("TextField.TextColor property check ERROR!");
                    }

                    //TextLabel
                    if (tl1.ShadowColor.X != valueFloatShouldBe || tl1.ShadowColor.Y != valueFloatShouldBe || tl1.ShadowColor.Z != valueFloatShouldBe || tl1.ShadowColor.W != valueFloatShouldBe)
                    {
                        throw new ApplicationException("TextLabel.ShadowColor property check ERROR!");
                    }
                    if (tl1.ShadowOffset.X != valueFloatShouldBe || tl1.ShadowOffset.Y != valueFloatShouldBe)
                    {
                        throw new ApplicationException("TextLabel.ShadowOffset property check ERROR!");
                    }
                    if (tl1.TextColor.R != valueFloatShouldBe || tl1.TextColor.G != valueFloatShouldBe || tl1.TextColor.B != valueFloatShouldBe || tl1.TextColor.A != valueFloatShouldBe)
                    {
                        throw new ApplicationException("TextLabel.TextColor property check ERROR!");
                    }
                    //This is because When TextColor is increased, this UnderlineColor is also updated sychronousely. 
                    if (tl1.UnderlineColor.X != (float)(valueFloatShouldBe + valueFloatIncreament) || tl1.UnderlineColor.Y != (float)(valueFloatShouldBe + valueFloatIncreament) || tl1.UnderlineColor.Z != (float)(valueFloatShouldBe + valueFloatIncreament) || tl1.UnderlineColor.W != (float)(valueFloatShouldBe + valueFloatIncreament))
                    {
                        throw new ApplicationException("TextLabel.UnderlineColor property check ERROR!");
                    }

                    //View
                    if (v1.Scale.X != valueFloatShouldBe || v1.Scale.Y != valueFloatShouldBe || v1.Scale.Z != valueFloatShouldBe)
                    {
                        throw new ApplicationException("View.Scale property check ERROR!");
                    }
                    if (v1.BackgroundColor.R != valueFloatShouldBe || v1.BackgroundColor.G != valueFloatShouldBe || v1.BackgroundColor.B != valueFloatShouldBe || v1.BackgroundColor.A != valueFloatShouldBe)
                    {
                        throw new ApplicationException("View.BackgroundColor property check ERROR!");
                    }
                    //Padding and PaddingEX are same property, this is why increament is added one more time.
                    if ( v1.Padding.Start != valueUshortShouldBe || v1.Padding.End != valueUshortShouldBe || v1.Padding.Top != valueUshortShouldBe || v1.Padding.Bottom != valueUshortShouldBe)
                    {
                        throw new ApplicationException("View.Padding property check ERROR!");
                    }
                    if (v1.Margin.Start != valueUshortShouldBe || v1.Margin.End != valueUshortShouldBe || v1.Margin.Top != valueUshortShouldBe || v1.Margin.Bottom != valueUshortShouldBe)
                    {
                        throw new ApplicationException("View.Margin property check ERROR!");
                    }

                    if (v1.Color.R != valueFloatShouldBe || v1.Color.G != valueFloatShouldBe || v1.Color.B != valueFloatShouldBe)
                    {
                        throw new ApplicationException("View.Color property check ERROR!");
                    }

                    if (v1.AnchorPoint.X != valueFloatShouldBe || v1.AnchorPoint.Y != valueFloatShouldBe || v1.AnchorPoint.Z != valueFloatShouldBe)
                    {
                        throw new ApplicationException("View.AnchorPoint property check ERROR!");
                    }
                    if (v1.CellIndex.X != valueFloatShouldBe || v1.CellIndex.Y != valueFloatShouldBe)
                    {
                        throw new ApplicationException("View.CellIndex property check ERROR!");
                    }
                    if (v1.FlexMargin.X != valueFloatShouldBe || v1.FlexMargin.Y != valueFloatShouldBe || v1.FlexMargin.Z != valueFloatShouldBe || v1.FlexMargin.W != valueFloatShouldBe)
                    {
                        throw new ApplicationException("View.FlexMargin property check ERROR!");
                    }
                    if (v1.PaddingEX.Start != valueUshortShouldBe || v1.PaddingEX.End != valueUshortShouldBe || v1.PaddingEX.Top != valueUshortShouldBe || v1.PaddingEX.Bottom != valueUshortShouldBe)
                    {
                        throw new ApplicationException("View.PaddingEX property check ERROR!");
                    }
                    if (v1.SizeModeFactor.X != valueFloatShouldBe || v1.SizeModeFactor.Y != valueFloatShouldBe || v1.SizeModeFactor.Z != valueFloatShouldBe)
                    {
                        throw new ApplicationException("View.SizeModeFactor property check ERROR!");
                    }

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
            initMultiCascadePropertySet();
        }
        public void Deactivate()
        {
            root.KeyEvent -= Root_KeyEvent;
        }
    }
}

