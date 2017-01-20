/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

namespace NUI
{
  using System;

  public class Position
  {

    private float x;
    private float y;
    private float z;

    /**
     * @brief constructor
     *
     * @since 1.0.0
     */
    public Position()
    {
      x = 0.0f;
      y = 0.0f;
      z = 0.0f;
    }

    /**
     * @brief constructor
     *
     * @since 1.0.0
     * @param [in] a The Position X.
     * @param [in] b The Position Y.
     * @param [in] c The Position Z.
     */
    public Position(float a, float b, float c)
    {
      x = a;
      y = b;
      z = c;
    }

    /**
     * @brief constructor
     *
     * @since 1.0.0
     * @param [in] o The Vector Position X, Y, Z.
     */
    public Position(Vector3 o)
    {
      x = o.X;
      y = o.Y;
      z = o.Z;
    }

    ///< name "X", type float (Position X value)
    //@since 1.0.0
    public float X
    {
      get { return x; }
      set { x = value; }
    }

    ///< name "Y", type float (Position Y value)
    //@since 1.0.0
    public float Y
    {
      get { return y; }
      set { y = value; }
    }

    ///< name "Z", type float (Position Z value)
    //@since 1.0.0
    public float Z
    {
      get { return z; }
      set { z = value; }
    }

    /**
     * @brief operator+
     *
     * @since 1.0.0
     * @param [in] l The Position to add.
     * @param [in] r The Position to add
     * @return A reference to this
     */
    public static Position operator +(Position l, Position r)
    {
      return new Position(l.X + r.X, l.Y + r.Y, l.Z + r.Z);
    }

    /**
     * @brief operator-
     *
     * @since 1.0.0
     * @param [in] l The Position to substract.
     * @param [in] r The Position to substract
     * @return A reference to this
     */
    public static Position operator -(Position l, Position r)
    {
      return new Position(l.X - r.X, l.Y - r.Y, l.Z - r.Z);
    }

    /**
     * @brief operator*
     *
     * @since 1.0.0
     * @param [in] a The Position to multiply.
     * @param [in] b The constant to multiply of type double.
     * @return A reference to this
     */
    public static Position operator *(Position a, double b)
    {
      return new Position((int)(a.X * b), (int)(a.Y * b), (int)(a.Z * b));
    }

    /**
     * @brief operator/
     *
     * @since 1.0.0
     * @param [in] a The Position to divide.
     * @param [in] b The Position to divide
     * @return float value of division operation
     */
    public static float operator /(Position a, Position b)
    {
      return (float)System.Math.Sqrt((a.X / b.X) * (a.Y / b.Y) * (a.Z / b.Z));
    }

    /**
     * @brief Operator ==
     *
     * @since 1.0.0
     * @param [in] a The Position object to compare.
     * @param [in] b The Position object to compare.
     * @return bool, whether Position are equal or not
     */
    public static bool operator == (Position a, Position b)
    {
      return a.X == b.X && a.Y == b.Y && a.Z == b.Z;
    }

    /**
     * @brief Operator !=
     *
     * @since 1.0.0
     * @param [in] a The Position object to compare.
     * @param [in] b The Position object to compare.
     * @return bool, whether Position are equal or not
     */
    public static bool operator != (Position a, Position b)
    {
      return a.X != b.X || a.Y != b.Y || a.Z == b.Z;
    }

    /**
     * @brief GetHashCode
     *
     * @since 1.0.0
     * @return int, hascode of position
     */
    public override int GetHashCode()
    {
      return base.GetHashCode();
    }

    /**
     * @brief Clone
     *
     * @since 1.0.0
     * @return Position object
     */
    public Position Clone()
    {
      Position copy = new Position(X, Y, Z);
      return copy;
    }

    // User-defined conversion from Position to Vector3
    public static implicit operator Vector3(Position pos)
    {
      return new Vector3(pos.x, pos.y, pos.z);
    }

    public static implicit operator Position(Vector3 vec)
    {
      return new Position(vec.X, vec.Y, vec.Z);
    }
  }
}
