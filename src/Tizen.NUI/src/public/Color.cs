namespace NUI
{
  using System;

  public enum Colors
  {
    Red,
    White,
    Blue,
    Green,
    Black,
    Yellow,
    Magenta,
    Cyan
  }


  public class Color
  {

    private float r;
    private float g;
    private float b;
    private float a;

    /**
     * @brief constructor
     *
     * @since 1.0.0
     */
    public Color()
    {
      r = 0.0f;
      g = 0.0f;
      b = 0.0f;
      a = 0.0f;
    }

    /**
     * @brief constructor
     *
     * @since 1.0.0
     * @param [in] red The Color r.
     * @param [in] green The Color g.
     * @param [in] blue The Color b.
     * @param [in] alpha The Color a.
     */
    public Color(float red, float green, float blue, float alpha)
    {
      r = red;
      g = green;
      b = blue;
      a = alpha;
    }

    /**
     * @brief constructor
     *
     * @since 1.0.0
     * @param [in] o The Vector4 having r g b a components
     */
    public Color(Vector4 o)
    {
      r = o.r;
      g = o.g;
      b = o.b;
      a = o.a;
    }


    /**
     * @brief constructor
     *
     * @since 1.0.0
     * @param [in] color as enum Colors.
     */
    public Color(Colors color)
    {
      switch (color)
      {
        case Colors.Red:
          SetColor(1.0f, 0.0f, 0.0f, 1.0f);
          break;
        case Colors.White:
          SetColor(1.0f, 1.0f, 1.0f, 1.0f);
          break;
        case Colors.Blue:
          SetColor(0.0f, 0.0f, 1.0f, 1.0f);
          break;
        case Colors.Green:
          SetColor(0.0f, 1.0f, 0.0f, 1.0f);
          break;
        case Colors.Black:
          SetColor(0.0f, 0.0f, 0.0f, 1.0f);
          break;
        case Colors.Yellow:
          SetColor(1.0f, 1.0f, 0.0f, 1.0f);
          break;
        case Colors.Cyan:
          SetColor(0.0f, 1.0f, 1.0f, 1.0f);
          break;
        case Colors.Magenta:
          SetColor(1.0f, 0.0f, 1.0f, 1.0f);
          break;
      }
    }


    /**
     * @brief SetColor
     *
     * @since 1.0.0
     * @param [in] red The Color r.
     * @param [in] green The Color g.
     * @param [in] blue The Color b.
     * @param [in] alpha The Color a.
     */
    public void SetColor(float red, float green, float blue, float alpha)
    {
      r = red;
      g = green;
      b = blue;
      a = alpha;
    }

    /**
     * @brief name "R", type float (Color's Red component)
     * @SINCE_1_0.0
     */

    public float R
    {
      get { return r; }
      set { r = value; }
    }

    /**
     * @brief name "G", type float (Color's Green component)
     * @SINCE_1_0.0
     */
    public float G
    {
      get { return g; }
      set { g = value; }
    }

    /**
     * @brief name "B", type float (Color's Blue component)
     * @SINCE_1_0.0
     */
    public float B
    {
      get { return b; }
      set { b = value; }
    }

    /**
     * @brief name "A", type float (Color's Alpha value)
     * @SINCE_1_0.0
     */
    public float A
    {
      get { return a; }
      set { a = value; }
    }

    /**
     * @brief operator+
     *
     * @since 1.0.0
     * @param [in] l The Color to add.
     * @param [in] r The Color to add
     * @return A reference to this
     */
    public static Color operator +(Color l, Color r)
    {
      return new Color(l.R + r.R, l.G + r.G, l.B + r.B, l.A + r.A);
    }

    /**
     * @brief operator-
     *
     * @since 1.0.0
     * @param [in] l The Color to substract.
     * @param [in] r The Color to substract
     * @return A reference to this
     */
    public static Color operator -(Color l, Color r)
    {
      return new Color(l.R - r.R, l.G - r.G, l.B - r.B, l.A - r.A);
    }

    /**
     * @brief operator*
     *
     * @since 1.0.0
     * @param [in] a The Color to multiply.
     * @param [in] b The constant double to multiply.
     * @return A reference to this
     */
    public static Color operator *(Color a, double b)
    {
      return new Color((float)(a.R * b), (float)(a.G * b), (float)(a.B * b), (float)(a.A * b));
    }

    /**
     * @brief operator/
     *
     * @since 1.0.0
     * @param [in] a The Color to divide.
     * @param [in] b The Color to divide
     * @return float value of division operation
     */
    public static float operator /(Color a, Color b)
    {
      return (float)System.Math.Sqrt((a.R / b.R) * (a.G / b.G) * (a.B / b.B) * (a.A / b.A));
    }

    /**
     * @brief Operator ==
     *
     * @since 1.0.0
     * @param [in] x The Color object to compare.
     * @param [in] y The Color object to compare.
     * @return bool, whether colors are equal or not
     */
    public static bool operator == (Color x, Color y)
    {
      return x.R == y.R && x.G == y.G && x.B == y.B && x.A == y.A;
    }

    /**
     * @brief Operator !=
     *
     * @since 1.0.0
     * @param [in] x The Color object to compare.
     * @param [in] y The Color object to compare.
     * @return bool, whether colors are equal or not
     */
    public static bool operator != (Color x, Color y)
    {
      return x.R != y.R || x.G != y.G || x.B != y.B || x.A != y.A;
    }

    /**
     * @brief GetHashCode
     *
     * @since 1.0.0
     * @return int, hascode of Color
     */
    public override int GetHashCode()
    {
      return base.GetHashCode();
    }

    /**
     * @brief Clone
     *
     * @since 1.0.0
     * @return Color object
     */
    public Color Clone()
    {
      Color copy = new Color(R, G, B, A);
      return copy;
    }

    // Create a color for RGBA values ranging from 0..255, useful when dealing with HTML colors
    static Color FromRgbaByte( byte red, byte green, byte blue, byte alpha )
    {
      return new Color ( red / 255,  green / 255, blue / 255, alpha / 255 );
    }

    // User-defined conversion from Color to Vector4
    public static implicit operator Vector4(Color color)
    {
      return new Vector4(color.r, color.g, color.b, color.a);
    }

    public static implicit operator Color(Vector4 vec)
    {
      return new Color(vec.r, vec.g, vec.b, vec.a);
    }

    /**
     * @brief name "White", type Color (White Color object)
     * @SINCE_1_0.0
     */
    public static Color White
    {
      get
      {
        return new Color(Colors.White);
      }
    }

    /**
     * @brief name "Black", type Color (Black Color object)
     * @SINCE_1_0.0
     */
    public static Color Black
    {
      get
      {
        return new Color(Colors.Black);
      }
    }

    /**
     * @brief name "Red", type Color (Red Color object)
     * @SINCE_1_0.0
     */
    public static Color Red
    {
      get
      {
        return new Color(Colors.Red);
      }
    }

    /**
     * @brief name "Green", type Color (Green Color object)
     * @SINCE_1_0.0
     */
    public static Color Green
    {
      get
      {
        return new Color(Colors.Green);
      }
    }

    /**
     * @brief name "Blue", type Color (Blue Color object)
     * @SINCE_1_0.0
     */
    public static Color Blue
    {
      get
      {
        return new Color(Colors.Blue);
      }
    }

    /**
     * @brief name "Yellow", type Color (Yellow Color object)
     * @SINCE_1_0.0
     */
    public static Color Yellow
    {
      get
      {
        return new Color(Colors.Yellow);
      }
    }

    /**
     * @brief name "Magenta", type Color (Magenta Color object)
     * @SINCE_1_0.0
     */
    public static Color Magenta
    {
      get
      {
        return new Color(Colors.Magenta);
      }
    }

    /**
     * @brief name "Cyan", type Color (Cyan Color object)
     * @SINCE_1_0.0
     */
    public static Color Cyan
    {
      get
      {
        return new Color(Colors.Cyan);
      }
    }
  }
}
