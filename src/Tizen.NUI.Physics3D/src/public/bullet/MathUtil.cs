﻿/*
 * Copyright (c) 2013-2022 Andres Traks
 *
 * This software is provided 'as-is', without any express or implied warranty.
 * In no event will the authors be held liable for any damages arising from the use of this software.
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it freely,
 * subject to the following restrictions:
 *
 * 1. The origin of this software must not be misrepresented; you must not claim that you wrote the original software. If you use this software in a product, an acknowledgment in the product documentation would be appreciated but is not required.
 * 2. Altered source versions must be plainly marked as such, and must not be misrepresented as being the original software.
 * 3. This notice may not be removed or altered from any source distribution.
 */

﻿//*
// * C# / XNA  port of Bullet (c) 2011 Mark Neale <xexuxjy@hotmail.com>
// *
// * Bullet Continuous Collision Detection and Physics Library
// * Copyright (c) 2003-2008 Erwin Coumans  http://www.bulletphysics.com/
// *
// * This software is provided 'as-is', without any express or implied warranty.
// * In no event will the authors be held liable for any damages arising from
// * the use of this software.
// * 
// * Permission is granted to anyone to use this software for any purpose, 
// * including commercial applications, and to alter it and redistribute it
// * freely, subject to the following restrictions:
// * 
// * 1. The origin of this software must not be misrepresented; you must not
// *    claim that you wrote the original software. If you use this software
// *    in a product, an acknowledgment in the product documentation would be
// *    appreciated but is not required.
// * 2. Altered source versions must be plainly marked as such, and must not be
// *    misrepresented as being the original software.
// * 3. This notice may not be removed or altered from any source distribution.
// */

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.InteropServices;

namespace Tizen.NUI.Physics3D.Bullet
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class MathUtil
    {

        //        //public static Matrix TransposeTimesBasis(ref Matrix a, ref Matrix b)
        //        public static Matrix TransposeTimesBasis(ref Matrix mA, ref Matrix mB)

        //        {
        //            Matrix ba = MathUtil.BasisMatrix(ref mA);
        //            ba = Matrix.Transpose(ba);
        //            Matrix bb = MathUtil.BasisMatrix(ref mB);
        //            return BulletMatrixMultiply(ref ba, ref bb);
        //        }

        //        public static Matrix InverseTimes(Matrix a, Matrix b)
        //        {
        //            return InverseTimes(ref a, ref b);
        //        }

        //        public static Matrix InverseTimes(ref Matrix a, ref Matrix b)
        //        {
        //            Matrix m = Matrix.Invert(a);
        //            return BulletMatrixMultiply(ref m, ref b);
        //        }

        //        public static Matrix TransposeBasis(Matrix m)
        //        {
        //            return TransposeBasis(ref m);
        //        }

        //        public static Matrix TransposeBasis(ref Matrix m)
        //        {
        //            return Matrix.Transpose(BasisMatrix(ref m));
        //        }

        //        public static Matrix InverseBasis(Matrix m)
        //        {
        //            return InverseBasis(ref m);
        //        }

        //        public static Matrix InverseBasis(ref Matrix m)
        //        {
        //            Matrix b = BasisMatrix(ref m);
        //            b = Matrix.Invert(b);
        //            return b;
        //        }

        //        public static float Cofac(ref Matrix m,int r1, int c1, int r2, int c2)
        //        {
        //            float a = MatrixComponent(ref m, r1, c1);
        //            float b = MatrixComponent(ref m, r2, c2);
        //            float c = MatrixComponent(ref m, r1, c2);
        //            float d = MatrixComponent(ref m, r2, c1);

        //            return a * b - c * d;
        //        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public static float FSel(float a, float b, float c)
        {
            // dodgy but seems necessary for rounding issues.
            //return a >= -0.00001 ? b : c;
            return a >= 0 ? b : c;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static int MaxAxis(ref global::System.Numerics.Vector3 a)
        {
            return a.X < a.Y ? (a.Y < a.Z ? 2 : 1) : (a.X < a.Z ? 2 : 0);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static int MaxAxis(global::System.Numerics.Vector4 a)
        {
            return MaxAxis(ref a);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static int MaxAxis(ref global::System.Numerics.Vector4 a)
        {
            int maxIndex = -1;
            float maxVal = -BT_LARGE_FLOAT;
            if (a.X > maxVal)
            {
                maxIndex = 0;
                maxVal = a.X;
            }
            if (a.Y > maxVal)
            {
                maxIndex = 1;
                maxVal = a.Y;
            }
            if (a.Z > maxVal)
            {
                maxIndex = 2;
                maxVal = a.Z;
            }
            if (a.W > maxVal)
            {
                maxIndex = 3;
                //maxVal = a.W;
            }
            return maxIndex;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static int ClosestAxis(ref global::System.Numerics.Vector4 a)
        {
            return MaxAxis(AbsoluteVector4(ref a));
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public static global::System.Numerics.Vector4 AbsoluteVector4(ref global::System.Numerics.Vector4 vec)
        {
            return new global::System.Numerics.Vector4(global::System.Math.Abs(vec.X), global::System.Math.Abs(vec.Y), global::System.Math.Abs(vec.Z), global::System.Math.Abs(vec.W));
        }

        //        public static float VectorComponent(global::System.Numerics.Vector3 v, int i)
        //        {
        //            return VectorComponent(ref v, i);
        //        }

        //        public static float VectorComponent(ref global::System.Numerics.Vector3 v, int i)
        //        {
        //            switch (i)
        //            {
        //                case 0:
        //                    return v.X;
        //                case 1:
        //                    return v.Y;
        //                case 2:
        //                    return v.Z;
        //                default:
        //                    Debug.Assert(false);
        //                    return 0.0f;
        //            }
        //        }

        //        public static void VectorComponent(ref global::System.Numerics.Vector3 v, int i, float f)
        //        {
        //            switch (i)
        //            {
        //                case 0:
        //                    v.X = f;
        //                    return;
        //                case 1:
        //                    v.Y = f;
        //                    return;
        //                case 2:
        //                    v.Z = f;
        //                    return;
        //            }
        //            Debug.Assert(false);
        //        }

        //        public static void VectorComponentAddAssign(ref global::System.Numerics.Vector3 v, int i, float f)
        //        {
        //            switch (i)
        //            {
        //                case 0:
        //                    v.X += f;
        //                    return;
        //                case 1:
        //                    v.Y += f;
        //                    return;
        //                case 2:
        //                    v.Z += f;
        //                    return;
        //            }
        //            Debug.Assert(false);
        //        }

        //        public static void VectorComponentMinusAssign(ref global::System.Numerics.Vector3 v, int i, float f)
        //        {
        //            switch (i)
        //            {
        //                case 0:
        //                    v.X -= f;
        //                    return;
        //                case 1:
        //                    v.Y -= f;
        //                    return;
        //                case 2:
        //                    v.Z -= f;
        //                    return;
        //            }
        //            Debug.Assert(false);
        //        }

        //        public static void VectorComponentMultiplyAssign(ref global::System.Numerics.Vector3 v, int i, float f)
        //        {
        //            switch (i)
        //            {
        //                case 0:
        //                    v.X *= f;
        //                    return;
        //                case 1:
        //                    v.Y *= f;
        //                    return;
        //                case 2:
        //                    v.Z *= f;
        //                    return;
        //            }
        //            Debug.Assert(false);
        //        }

        //        public static void VectorComponentDivideAssign(ref global::System.Numerics.Vector3 v, int i, float f)
        //        {
        //            switch (i)
        //            {
        //                case 0:
        //                    v.X /= f;
        //                    return;
        //                case 1:
        //                    v.Y /= f;
        //                    return;
        //                case 2:
        //                    v.Z /= f;
        //                    return;
        //            }
        //            Debug.Assert(false);
        //        }

        //        public static Matrix AbsoluteMatrix(Matrix input)
        //        {
        //            return AbsoluteMatrix(ref input);
        //        }

        //        public static Matrix AbsoluteMatrix(ref Matrix input)
        //        {
        //            Matrix output;
        //            AbsoluteMatrix(ref input, out output);
        //            return output;
        //        }

        //        public static void AbsoluteMatrix(ref Matrix input, out Matrix output)
        //        {
        //            output = new Matrix(
        //                global::System.Math.Abs(input.M11),
        //                global::System.Math.Abs(input.M12),
        //                global::System.Math.Abs(input.M13),
        //                global::System.Math.Abs(input.M14),
        //                global::System.Math.Abs(input.M21),
        //                global::System.Math.Abs(input.M22),
        //                global::System.Math.Abs(input.M23),
        //                global::System.Math.Abs(input.M24),
        //                global::System.Math.Abs(input.M31),
        //                global::System.Math.Abs(input.M32),
        //                global::System.Math.Abs(input.M33),
        //                global::System.Math.Abs(input.M34),
        //                global::System.Math.Abs(input.M41),
        //                global::System.Math.Abs(input.M42),
        //                global::System.Math.Abs(input.M43),
        //                global::System.Math.Abs(input.M44));
        //        }

        //        public static Matrix AbsoluteBasisMatrix(ref Matrix input)
        //        {
        //            Matrix output;
        //            AbsoluteBasisMatrix(ref input, out output);
        //            return output;
        //        }

        //        public static void AbsoluteBasisMatrix(ref Matrix input, out Matrix output)
        //        {
        //            output = new Matrix(
        //                global::System.Math.Abs(input.M11), global::System.Math.Abs(input.M12), global::System.Math.Abs(input.M13), 0.0f,
        //                global::System.Math.Abs(input.M21), global::System.Math.Abs(input.M22), global::System.Math.Abs(input.M23), 0.0f,
        //                global::System.Math.Abs(input.M31), global::System.Math.Abs(input.M32), global::System.Math.Abs(input.M33), 0.0f,
        //                0.0f, 0.0f, 0.0f, 1.0f);
        //        }

        //        public static void AbsoluteVector(ref global::System.Numerics.Vector3 input, out global::System.Numerics.Vector3 output)
        //        {
        //            output = new global::System.Numerics.Vector3(
        //                global::System.Math.Abs(input.X),
        //                global::System.Math.Abs(input.Y),
        //                global::System.Math.Abs(input.Z));
        //        }

        //        public static void RotateVector(ref global::System.Numerics.Vector3 vec, ref Matrix m, out global::System.Numerics.Vector3 output)
        //        {
        //            Quaternion rotation;
        //            global::System.Numerics.Vector3 component;
        //            m.Decompose(out component, out rotation, out component);
        //            output = global::System.Numerics.Vector3.Transform(vec, rotation);
        //        }

        //        public static void TransformAabb(global::System.Numerics.Vector3 halfExtents, float margin, Matrix trans, out global::System.Numerics.Vector3 aabbMinOut, out global::System.Numerics.Vector3 aabbMaxOut)
        //        {
        //            //TransformAabb(ref halfExtents,margin,ref trans,out aabbMinOut,out aabbMaxOut);
        //            global::System.Numerics.Vector3 halfExtentsWithMargin = halfExtents + new global::System.Numerics.Vector3(margin);
        //            global::System.Numerics.Vector3 center, extent;
        //            AbsoluteExtents(ref trans, ref halfExtentsWithMargin, out center, out extent);
        //            aabbMinOut = center - extent;
        //            aabbMaxOut = center + extent;
        //        }

        //        public static void TransformAabb(ref global::System.Numerics.Vector3 halfExtents, float margin, ref Matrix trans, out global::System.Numerics.Vector3 aabbMinOut, out global::System.Numerics.Vector3 aabbMaxOut)
        //        {
        //            global::System.Numerics.Vector3 halfExtentsWithMargin = halfExtents + new global::System.Numerics.Vector3(margin);
        //            global::System.Numerics.Vector3 center, extent;
        //            AbsoluteExtents(ref trans, ref halfExtentsWithMargin, out center, out extent);
        //            aabbMinOut = center - extent;
        //            aabbMaxOut = center + extent;
        //        }

        //        public static void TransformAabb(global::System.Numerics.Vector3 localAabbMin, global::System.Numerics.Vector3 localAabbMax, float margin, Matrix trans, out global::System.Numerics.Vector3 aabbMinOut, out global::System.Numerics.Vector3 aabbMaxOut)
        //        {
        //            TransformAabb(ref localAabbMin, ref localAabbMax, margin, ref trans, out aabbMinOut, out aabbMaxOut);
        //        }

        //        public static void TransformAabb(ref global::System.Numerics.Vector3 localAabbMin, ref global::System.Numerics.Vector3 localAabbMax, float margin, ref Matrix trans, out global::System.Numerics.Vector3 aabbMinOut, out global::System.Numerics.Vector3 aabbMaxOut)
        //        {
        //            Debug.Assert(localAabbMin.X <= localAabbMax.X);
        //            Debug.Assert(localAabbMin.Y <= localAabbMax.Y);
        //            Debug.Assert(localAabbMin.Z <= localAabbMax.Z);
        //            global::System.Numerics.Vector3 localHalfExtents = 0.5f * (localAabbMax - localAabbMin);
        //            localHalfExtents += new global::System.Numerics.Vector3(margin);

        //            global::System.Numerics.Vector3 localCenter = 0.5f * (localAabbMax + localAabbMin);
        //            Matrix abs_b = MathUtil.AbsoluteBasisMatrix(ref trans);

        //            global::System.Numerics.Vector3 center = global::System.Numerics.Vector3.Transform(localCenter, trans);

        //            global::System.Numerics.Vector3 extent = new global::System.Numerics.Vector3(global::System.Numerics.Vector3.Dot(abs_b.Right, localHalfExtents),
        //                                            global::System.Numerics.Vector3.Dot(abs_b.Up, localHalfExtents),
        //                                            global::System.Numerics.Vector3.Dot(abs_b.Backward, localHalfExtents));

        //            aabbMinOut = center - extent;
        //            aabbMaxOut = center + extent;
        //        }

        //        public static void AbsoluteExtents(ref Matrix trans, ref global::System.Numerics.Vector3 vec, out global::System.Numerics.Vector3 center, out global::System.Numerics.Vector3 extent)
        //        {
        //            Matrix abs_b;
        //            AbsoluteMatrix(ref trans, out abs_b);

        //            center = trans._origin;
        //            extent = new global::System.Numerics.Vector3(global::System.Numerics.Vector3.Dot(abs_b.Right, vec),
        //                                            global::System.Numerics.Vector3.Dot(abs_b.Up, vec),
        //                                            global::System.Numerics.Vector3.Dot(abs_b.Backward, vec));
        //        }

        //        public static void SetMatrixVector(ref Matrix matrix, int row, global::System.Numerics.Vector3 vector)
        //        {
        //            SetMatrixVector(ref matrix, row, ref vector);
        //        }

        //        public static void SetMatrixVector(ref Matrix matrix, int row, ref global::System.Numerics.Vector3 vector)
        //        {
        //            switch (row)
        //            {
        //                case 0:
        //                    matrix.M11 = vector.X;
        //                    matrix.M12 = vector.Y;
        //                    matrix.M13 = vector.Z;
        //                    return;
        //                case 1:
        //                    matrix.M21 = vector.X;
        //                    matrix.M22 = vector.Y;
        //                    matrix.M23 = vector.Z;
        //                    return;
        //                case 2:
        //                    matrix.M31 = vector.X;
        //                    matrix.M32 = vector.Y;
        //                    matrix.M33 = vector.Z;
        //                    return;
        //                case 3:
        //                    matrix.M41 = vector.X;
        //                    matrix.M42 = vector.Y;
        //                    matrix.M43 = vector.Z;
        //                    return;
        //            }
        //            Debug.Assert(false);
        //        }

        //        public static void AddMatrixVector(ref Matrix matrix, int row, ref global::System.Numerics.Vector3 vector)
        //        {
        //            switch (row)
        //            {
        //                case 0:
        //                    matrix.M11 += vector.X;
        //                    matrix.M12 += vector.Y;
        //                    matrix.M13 += vector.Z;
        //                    return;
        //                case 1:
        //                    matrix.M21 += vector.X;
        //                    matrix.M22 += vector.Y;
        //                    matrix.M23 += vector.Z;
        //                    return;
        //                case 2:
        //                    matrix.M31 += vector.X;
        //                    matrix.M32 += vector.Y;
        //                    matrix.M33 += vector.Z;
        //                    return;
        //                case 3:
        //                    matrix.M41 += vector.X;
        //                    matrix.M42 += vector.Y;
        //                    matrix.M43 += vector.Z;
        //                    return;
        //            }
        //            Debug.Assert(false);
        //        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static float Vector3Triple(ref global::System.Numerics.Vector3 a, ref global::System.Numerics.Vector3 b, ref global::System.Numerics.Vector3 c)
        {
            return a.X * (b.Y * c.Z - b.Z * c.Y) +
                a.Y * (b.Z * c.X - b.X * c.Z) +
                a.Z * (b.X * c.Y - b.Y * c.X);
        }

        //        // FIXME - MAN - make sure this is being called how we'd expect , may need to
        //        // swap i,j for row/column differences

        //        public static float MatrixComponent(ref Matrix m, int index)
        //        {
        //            //int i = index % 4;
        //            //int j = index / 4;

        //            int j = index % 4;
        //            int i = index / 4;

        //            return MatrixComponent(ref m,i,j);
        //        }

        //        public static float MatrixComponent(ref Matrix m, int row, int column)
        //        {
        //            switch (row)
        //            {
        //                case 0:
        //                    if (column == 0) return m.M11;
        //                    if (column == 1) return m.M12;
        //                    if (column == 2) return m.M13;
        //                    if (column == 3) return m.M14;
        //                    break;
        //                case 1:
        //                    if (column == 0) return m.M21;
        //                    if (column == 1) return m.M22;
        //                    if (column == 2) return m.M23;
        //                    if (column == 3) return m.M24;
        //                    break;
        //                case 2:
        //                    if (column == 0) return m.M31;
        //                    if (column == 1) return m.M32;
        //                    if (column == 2) return m.M33;
        //                    if (column == 3) return m.M34;
        //                    break;
        //                case 3:
        //                    if (column == 0) return m.M41;
        //                    if (column == 1) return m.M42;
        //                    if (column == 2) return m.M43;
        //                    if (column == 3) return m.M44;
        //                    break;
        //            }
        //            return 0;
        //        }

        //        public static void MatrixComponent(ref Matrix m, int row, int column, float val)
        //        {
        //            switch (row)
        //            {
        //                case 0:
        //                    if (column == 0) m.M11 = val;
        //                    if (column == 1) m.M12 = val;
        //                    if (column == 2) m.M13 = val;
        //                    if (column == 3) m.M14 = val;
        //                    break;
        //                case 1:
        //                    if (column == 0) m.M21 = val;
        //                    if (column == 1) m.M22 = val;
        //                    if (column == 2) m.M23 = val;
        //                    if (column == 3) m.M24 = val;
        //                    break;
        //                case 2:
        //                    if (column == 0) m.M31 = val;
        //                    if (column == 1) m.M32 = val;
        //                    if (column == 2) m.M33 = val;
        //                    if (column == 3) m.M34 = val;
        //                    break;
        //                case 3:
        //                    if (column == 0) m.M41 = val;
        //                    if (column == 1) m.M42 = val;
        //                    if (column == 2) m.M43 = val;
        //                    if (column == 3) m.M44 = val;
        //                    break;
        //            }
        //        }

        //        public static global::System.Numerics.Vector3 MatrixColumn(Matrix matrix, int row)
        //        {
        //            return MatrixColumn(ref matrix, row);
        //        }

        //        public static global::System.Numerics.Vector3 MatrixColumn(ref Matrix matrix, int row)
        //        {
        //            global::System.Numerics.Vector3 vectorRow;
        //            MatrixColumn(ref matrix, row, out vectorRow);
        //            return vectorRow;
        //        }

        //        public static void MatrixColumn(Matrix matrix, int row, out global::System.Numerics.Vector3 vectorRow)
        //        {
        //            MatrixColumn(ref matrix,row, out vectorRow);
        //        }

        //        public static void MatrixColumn(ref Matrix matrix, int row, out global::System.Numerics.Vector3 vectorRow)
        //        {
        //            switch (row)
        //            {
        //                case 0:
        //                    vectorRow = new global::System.Numerics.Vector3(matrix.M11, matrix.M12, matrix.M13);
        //                    break;
        //                case 1:
        //                    vectorRow = new global::System.Numerics.Vector3(matrix.M21, matrix.M22, matrix.M23);
        //                    break;
        //                case 2:
        //                    vectorRow = new global::System.Numerics.Vector3(matrix.M31, matrix.M32, matrix.M33);
        //                    break;
        //                case 3:
        //                    vectorRow = new global::System.Numerics.Vector3(matrix.M41, matrix.M42, matrix.M43);
        //                    break;
        //                default:
        //                    vectorRow = global::System.Numerics.Vector3.Zero;
        //                    break;
        //            }
        //        }

        //        public static global::System.Numerics.Vector3 MatrixRow(Matrix matrix, int row)
        //        {
        //            switch (row)
        //            {
        //                case 0:
        //                    return new global::System.Numerics.Vector3(matrix.M11, matrix.M21, matrix.M31);
        //                case 1:
        //                    return new global::System.Numerics.Vector3(matrix.M12, matrix.M22, matrix.M32);
        //                case 2:
        //                    return new global::System.Numerics.Vector3(matrix.M13, matrix.M23, matrix.M33);
        //                case 3:
        //                    return new global::System.Numerics.Vector3(matrix.M14, matrix.M24, matrix.M34);
        //                default:
        //                    return global::System.Numerics.Vector3.Zero;
        //            }
        //        }

        //        public static global::System.Numerics.Vector3 MatrixRow(ref Matrix matrix, int row)
        //        {
        //            switch (row)
        //            {
        //                case 0:
        //                    return new global::System.Numerics.Vector3(matrix.M11, matrix.M21, matrix.M31);
        //                case 1:
        //                    return new global::System.Numerics.Vector3(matrix.M12, matrix.M22, matrix.M32);
        //                case 2:
        //                    return new global::System.Numerics.Vector3(matrix.M13, matrix.M23, matrix.M33);
        //                case 3:
        //                    return new global::System.Numerics.Vector3(matrix.M14, matrix.M24, matrix.M34);
        //                default:
        //                    return global::System.Numerics.Vector3.Zero;
        //            }
        //        }

        //        public static void MatrixRow(ref Matrix matrix, int row, out global::System.Numerics.Vector3 vectorRow)
        //        {
        //            switch (row)
        //            {
        //                case 0:
        //                    vectorRow = new global::System.Numerics.Vector3(matrix.M11, matrix.M21, matrix.M31);
        //                    break;
        //                case 1:
        //                    vectorRow = new global::System.Numerics.Vector3(matrix.M12, matrix.M22, matrix.M32);
        //                    break;
        //                case 2:
        //                    vectorRow = new global::System.Numerics.Vector3(matrix.M13, matrix.M23, matrix.M33);
        //                    break;
        //                case 3:
        //                    vectorRow = new global::System.Numerics.Vector3(matrix.M14, matrix.M24, matrix.M34);
        //                    break;
        //                default:
        //                    vectorRow = global::System.Numerics.Vector3.Zero;
        //                    break;
        //            }
        //        }



        [EditorBrowsable(EditorBrowsableState.Never)]
        public static int GetQuantized(float x)
        {
            if (x < 0.0)
            {
                return (int)(x - 0.5);
            }
            return (int)(x + 0.5);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static int Clamp(int value, int min, int max)
        {
            return (value < min) ? min : (value > max) ? max : value;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void VectorClampMax(ref global::System.Numerics.Vector3 input, ref global::System.Numerics.Vector3 bounds)
        {
            input.X = global::System.Math.Min(input.X, bounds.X);
            input.Y = global::System.Math.Min(input.Y, bounds.Y);
            input.Z = global::System.Math.Min(input.Z, bounds.Z);
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void VectorClampMin(ref global::System.Numerics.Vector3 input, ref global::System.Numerics.Vector3 bounds)
        {
            input.X = global::System.Math.Max(input.X, bounds.X);
            input.Y = global::System.Math.Max(input.Y, bounds.Y);
            input.Z = global::System.Math.Max(input.Z, bounds.Z);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void VectorMin(ref global::System.Numerics.Vector3 input, ref global::System.Numerics.Vector3 output)
        {
            output.X = global::System.Math.Min(input.X, output.X);
            output.Y = global::System.Math.Min(input.Y, output.Y);
            output.Z = global::System.Math.Min(input.Z, output.Z);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void VectorMin(ref global::System.Numerics.Vector3 input1, ref global::System.Numerics.Vector3 input2, out global::System.Numerics.Vector3 output)
        {
            output = new global::System.Numerics.Vector3(
                global::System.Math.Min(input1.X, input2.X),
                global::System.Math.Min(input1.Y, input2.Y),
                global::System.Math.Min(input1.Z, input2.Z));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void VectorMax(ref global::System.Numerics.Vector3 input, ref global::System.Numerics.Vector3 output)
        {
            output.X = global::System.Math.Max(input.X, output.X);
            output.Y = global::System.Math.Max(input.Y, output.Y);
            output.Z = global::System.Math.Max(input.Z, output.Z);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void VectorMax(ref global::System.Numerics.Vector3 input1, ref global::System.Numerics.Vector3 input2, out global::System.Numerics.Vector3 output)
        {
            output = new global::System.Numerics.Vector3(
                global::System.Math.Max(input1.X, input2.X),
                global::System.Math.Max(input1.Y, input2.Y),
                global::System.Math.Max(input1.Z, input2.Z));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static float RecipSqrt(float a)
        {
            return (float)(1 / global::System.Math.Sqrt(a));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool CompareFloat(float val1, float val2)
        {
            return global::System.Math.Abs(val1 - val2) <= SIMD_EPSILON;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool FuzzyZero(float val)
        {
            return global::System.Math.Abs(val) <= SIMD_EPSILON;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool FuzzyZero(global::System.Numerics.Vector3 val)
        {
            return val.LengthSquared() < SIMD_EPSILON * SIMD_EPSILON;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static uint Select(uint condition, uint valueIfConditionNonZero, uint valueIfConditionZero)
        {
            // Set testNz to 0xFFFFFFFF if condition is nonzero, 0x00000000 if condition is zero
            // Rely on positive value or'ed with its negative having sign bit on
            // and zero value or'ed with its negative (which is still zero) having sign bit off 
            // Use arithmetic shift right, shifting the sign bit through all 32 bits
            uint testNz = (uint)(((int)condition | -(int)condition) >> 31);
            uint testEqz = ~testNz;
            return ((valueIfConditionNonZero & testNz) | (valueIfConditionZero & testEqz));
        }

        //        public static void BasisMatrix(Matrix matrixIn, out Matrix matrixOut)
        //        {
        //            BasisMatrix(ref matrixIn, out matrixOut);
        //        }
        //        public static void BasisMatrix(ref Matrix matrixIn, out Matrix matrixOut)
        //        {
        //            matrixOut = matrixIn;
        //            matrixOut.M41 = 0.0f;
        //            matrixOut.M42 = 0.0f;
        //            matrixOut.M43 = 0.0f;
        //            matrixOut.M44 = 1.0f;
        //        }

        //        public static Matrix BasisMatrix(Matrix matrixIn)
        //        {
        //            return BasisMatrix(ref matrixIn);
        //        }
        //        public static Matrix BasisMatrix(ref Matrix matrixIn)
        //        {
        //            Matrix matrixOut = matrixIn;
        //            matrixOut.M41 = 0.0f;
        //            matrixOut.M42 = 0.0f;
        //            matrixOut.M43 = 0.0f;
        //            matrixOut.M44 = 1.0f;
        //            return matrixOut;
        //        }

        public static Quaternion ShortestArcQuat(ref global::System.Numerics.Vector3 axisInA, ref global::System.Numerics.Vector3 axisInB)
        {
            global::System.Numerics.Vector3 c = global::System.Numerics.Vector3.Cross(axisInA, axisInB);
            float d = global::System.Numerics.Vector3.Dot(axisInA, axisInB);

            if (d < -1.0 + SIMD_EPSILON)
            {
                return new Quaternion(0.0f, 1.0f, 0.0f, 0.0f); // just pick any vector
            }

            float s = (float)global::System.Math.Sqrt((1.0f + d) * 2.0f);
            float rs = 1.0f / s;

            return new Quaternion(c.X * rs, c.Y * rs, c.Z * rs, s * 0.5f);

        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static float QuatAngle(ref Quaternion quat)
        {
            return 2f * (float)global::System.Math.Acos(quat.W);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Quaternion QuatFurthest(ref Quaternion input1, ref Quaternion input2)
        {
            Quaternion diff, sum;
            diff = input1 - input2;
            sum = input1 + input2;
            if (Quaternion.Dot(diff, diff) > Quaternion.Dot(sum, sum))
            {
                return input2;
            }
            return (-input2);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static global::System.Numerics.Vector3 QuatRotate(ref Quaternion rotation, ref global::System.Numerics.Vector3 v)
        {
            Quaternion q = QuatVectorMultiply(ref rotation, ref v);
            q *= QuaternionInverse(ref rotation);
            return new global::System.Numerics.Vector3(q.X, q.Y, q.Z);
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Quaternion QuatVectorMultiply(ref Quaternion q, ref global::System.Numerics.Vector3 w)
        {
            return new Quaternion(q.W * w.X + q.Y * w.Z - q.Z * w.Y,
                                    q.W * w.Y + q.Z * w.X - q.X * w.Z,
                                    q.W * w.Z + q.X * w.Y - q.Y * w.X,
                                    -q.X * w.X - q.Y * w.Y - q.Z * w.Z);
        }

        //      /**@brief diagonalizes this matrix by the Jacobi method.
        //       * @param rot stores the rotation from the coordinate system in which the matrix is diagonal to the original
        //       * coordinate system, i.e., old_this = rot * new_this * rot^T. 
        //       * @param threshold See iteration
        //       * @param iteration The iteration stops when all off-diagonal elements are less than the threshold multiplied 
        //       * by the sum of the absolute values of the diagonal, or when maxSteps have been executed. 
        //       * 
        //       * Note that this matrix is assumed to be symmetric. 
        //       */
        //        public static void Diagonalize(ref Matrix inMatrix,ref Matrix rot, float threshold, int maxSteps)
        //        {
        //            Debug.Assert(false);
        //            rot = Matrix.Identity;
        //            for (int step = maxSteps; step > 0; step--)
        //            {
        //                // find off-diagonal element [p][q] with largest magnitude
        //                int p = 0;
        //                int q = 1;
        //                int r = 2;
        //                float max = global::System.Math.Abs(inMatrix.M12);
        //                float v = global::System.Math.Abs(inMatrix.M13);
        //                if (v > max)
        //                {
        //                   q = 2;
        //                   r = 1;
        //                   max = v;
        //                }
        //                v = global::System.Math.Abs(inMatrix.M23);
        //                if (v > max)
        //                {
        //                   p = 1;
        //                   q = 2;
        //                   r = 0;
        //                   max = v;
        //                }

        //                float t = threshold * (System.Math.Abs(inMatrix.M11) + global::System.Math.Abs(inMatrix.M22) + global::System.Math.Abs(inMatrix.M33));
        //                if (max <= t)
        //                {
        //                   if (max <= SIMD_EPSILON * t)
        //                   {
        //                      return;
        //                   }
        //                   step = 1;
        //                }

        //                // compute Jacobi rotation J which leads to a zero for element [p][q] 
        //                float mpq = MathUtil.MatrixComponent(ref inMatrix,p,q);
        //                float theta = (MathUtil.MatrixComponent(ref inMatrix,q,q)-MathUtil.MatrixComponent(ref inMatrix,p,p)) / (2 * mpq);
        //                float theta2 = theta * theta;
        //                float cos;
        //                float sin;
        //                if (theta2 * theta2 < 10f / SIMD_EPSILON)
        //                {
        //                   t = (theta >= 0f) ? (float)(1f / (theta + global::System.Math.Sqrt(1 + theta2)))
        //                                            : (float)(1f / (theta - global::System.Math.Sqrt(1 + theta2)));
        //                   cos = (float)(1f / global::System.Math.Sqrt(1 + t * t));
        //                   sin = cos * t;
        //                }
        //                else
        //                {
        //                   // approximation for large theta-value, i.e., a nearly diagonal matrix
        //                   t = 1 / (theta * (2 + 0.5f / theta2));
        //                   cos = 1 - 0.5f * t * t;
        //                   sin = cos * t;
        //                }

        //                // apply rotation to matrix (this = J^T * this * J)
        //                MathUtil.MatrixComponent(ref inMatrix,p,q,0f);
        //                MathUtil.MatrixComponent(ref inMatrix,q,p,0f);
        //                MathUtil.MatrixComponent(ref inMatrix,p,p,MathUtil.MatrixComponent(ref inMatrix,p,p)-t*mpq);
        //                MathUtil.MatrixComponent(ref inMatrix,q,q,MathUtil.MatrixComponent(ref inMatrix,q,q)+t*mpq);

        //                float  mrp = MathUtil.MatrixComponent(ref inMatrix,r,p);
        //                float  mrq = MathUtil.MatrixComponent(ref inMatrix,r,q);

        //                MathUtil.MatrixComponent(ref inMatrix,r,p,cos * mrp - sin * mrq);
        //                MathUtil.MatrixComponent(ref inMatrix,p,r,cos * mrp - sin * mrq);

        //                MathUtil.MatrixComponent(ref inMatrix,r,q,cos * mrp + sin * mrq);
        //                MathUtil.MatrixComponent(ref inMatrix,q,r,cos * mrp + sin * mrq);

        //                // apply rotation to rot (rot = rot * J)
        //                for (int i = 0; i < 3; i++)
        //                {
        //                    float  mrp2 = MathUtil.MatrixComponent(ref rot,i,p);
        //                    float  mrq2 = MathUtil.MatrixComponent(ref rot,i,q);
        //                    MathUtil.MatrixComponent(ref rot, i, p, cos * mrp - sin * mrq);
        //                    MathUtil.MatrixComponent(ref rot, i, q, cos * mrp + sin * mrq);
        //                }
        //            }
        //        }



        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void GetSkewSymmetricMatrix(ref global::System.Numerics.Vector3 vecin, out global::System.Numerics.Vector3 v0, out global::System.Numerics.Vector3 v1, out global::System.Numerics.Vector3 v2)
        {
            v0 = new global::System.Numerics.Vector3(0f, -vecin.Z, vecin.Y);
            v1 = new global::System.Numerics.Vector3(vecin.Z, 0f, -vecin.X);
            v2 = new global::System.Numerics.Vector3(-vecin.Y, vecin.X, 0f);
        }

        [Conditional("DEBUG")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void ZeroCheckVector(ref global::System.Numerics.Vector3 v)
        {
            if (FuzzyZero(v.LengthSquared()))
            {
                //Debug.Assert(false);
            }
        }

        [Conditional("DEBUG")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void SanityCheckVector(ref global::System.Numerics.Vector3 v)
        {
            if (float.IsNaN(v.X) || float.IsNaN(v.Y) || float.IsNaN(v.Z))
            {
                Debug.Assert(false);
            }
        }

        [Conditional("DEBUG")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void SanityCheckFloat(float f)
        {
            Debug.Assert(!float.IsInfinity(f) && !float.IsNaN(f));
        }

        //        public static void global::System.Numerics.Vector3FromFloat(out global::System.Numerics.Vector3 v, float[] fa)
        //        {
        //            v = new global::System.Numerics.Vector3(fa[0], fa[1], fa[2]);
        //        }

        //        //public static void FloatFromVector3(global::System.Numerics.Vector3 v, float[] fa)
        //        //{
        //        //    FloatFromVector3(ref v, fa);
        //        //}

        //        //public static void FloatFromVector3(ref global::System.Numerics.Vector3 v, float[] fa)
        //        //{
        //        //    fa[0] = v.X;
        //        //    fa[1] = v.Y;
        //        //    fa[2] = v.Z;
        //        //}

        //        //public static float[] FloatFromVector3(global::System.Numerics.Vector3 v)
        //        //{
        //        //    return FloatFromVector3(ref v);
        //        //}

        //        //public static float[] FloatFromVector3(ref global::System.Numerics.Vector3 v)
        //        //{
        //        //    return new float[] { v.X, v.Y, v.Z };
        //        //}
        /*
        public static bool MatrixToEulerXYZ(ref IndexedBasisMatrix mat, out global::System.Numerics.Vector3 xyz)
        {
            //	// rot =  cy*cz          -cy*sz           sy
            //	//        cz*sx*sy+cx*sz  cx*cz-sx*sy*sz -cy*sx
            //	//       -cx*cz*sy+sx*sz  cz*sx+cx*sy*sz  cx*cy
            //

            float matElem0 = MathUtil.GetMatrixElem(ref mat, 0);
            float matElem1 = MathUtil.GetMatrixElem(ref mat, 1);
            float matElem2 = MathUtil.GetMatrixElem(ref mat, 2);
            float matElem3 = MathUtil.GetMatrixElem(ref mat, 3);
            float matElem4 = MathUtil.GetMatrixElem(ref mat, 4);
            float matElem5 = MathUtil.GetMatrixElem(ref mat, 5);
            float matElem6 = MathUtil.GetMatrixElem(ref mat, 6);
            float matElem7 = MathUtil.GetMatrixElem(ref mat, 7);
            float matElem8 = MathUtil.GetMatrixElem(ref mat, 8);

            float fi = matElem2;
            if (fi < 1.0f)
            {
                if (fi > -1.0f)
                {
                    xyz = new global::System.Numerics.Vector3(
                        (float)Math.Atan2(-matElem5, matElem8),
                        (float)Math.Asin(matElem2),
                        (float)Math.Atan2(-matElem1, matElem0));
                    return true;
                }
                else
                {
                    // WARNING.  Not unique.  XA - ZA = -atan2(r10,r11)
                    xyz = new global::System.Numerics.Vector3(
                        (float)-Math.Atan2(matElem3, matElem4),
                        -SIMD_HALF_PI,
                        0f);
                    return false;
                }
            }
            else
            {
                // WARNING.  Not unique.  XAngle + ZAngle = atan2(r10,r11)
                xyz = new global::System.Numerics.Vector3(
                    (float)Math.Atan2(matElem3, matElem4),
                    SIMD_HALF_PI,
                    0.0f);
            }
            return false;
        }
        */


        //        public static global::System.Numerics.Vector3 MatrixToEuler(ref Matrix m)
        //        {
        //            global::System.Numerics.Vector3 translate;
        //            global::System.Numerics.Vector3 scale;
        //            Quaternion rotate;
        //            m.Decompose(out scale, out rotate, out translate);
        //            return quaternionToEuler(ref rotate);
        //        }

        //        // Taken from Fabian Vikings post at : http://forums.xna.com/forums/p/4574/23763.aspx  
        //        public static global::System.Numerics.Vector3 quaternionToEuler(ref Quaternion q)
        //        {
        //            global::System.Numerics.Vector3 v = global::System.Numerics.Vector3.Zero;

        //            v.X = (float)Math.Atan2
        //            (
        //                2 * q.Y * q.W - 2 * q.X * q.Z,
        //                   1 - 2 * Math.Pow(q.Y, 2) - 2 * Math.Pow(q.Z, 2)
        //            );

        //            v.Z = (float)Math.Asin
        //            (
        //                2 * q.X * q.Y + 2 * q.Z * q.W
        //            );

        //            v.Y = (float)Math.Atan2
        //            (
        //                2 * q.X * q.W - 2 * q.Y * q.Z,
        //                1 - 2 * Math.Pow(q.X, 2) - 2 * Math.Pow(q.Z, 2)
        //            );

        //            if (q.X * q.Y + q.Z * q.W == 0.5)
        //            {
        //                v.X = (float)(2 * Math.Atan2(q.X, q.W));
        //                v.Y = 0;
        //            }

        //            else if (q.X * q.Y + q.Z * q.W == -0.5)
        //            {
        //                v.X = (float)(-2 * Math.Atan2(q.X, q.W));
        //                v.Y = 0;
        //            }

        //            return v;
        //        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Quaternion QuaternionInverse(ref Quaternion q)
        {
            return new Quaternion(-q.X, -q.Y, -q.Z, q.W);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Quaternion QuaternionMultiply(ref Quaternion a, ref Quaternion b)
        {
            return a * b;
            //return b * a;
        }

        //public static Matrix BulletMatrixMultiply(Matrix m1, Matrix m2)
        //{
        //    return m1 * m2;
        //}

        //public static Matrix BulletMatrixMultiply(ref Matrix m1, ref Matrix m2)
        //{
        //    return m1 * m2;
        //}

        //        public static Matrix BulletMatrixMultiplyBasis(Matrix m1, Matrix m2)
        //        {
        //            return BulletMatrixMultiplyBasis(ref m1, ref m2);
        //        }

        //        public static Matrix BulletMatrixMultiplyBasis(ref Matrix m1, ref Matrix m2)
        //        {
        //            Matrix mb1;
        //            BasisMatrix(ref m1, out mb1);
        //            Matrix mb2;
        //            BasisMatrix(ref m2, out mb2);
        //            return BulletMatrixMultiply(ref mb1, ref mb2);
        //        }



        [EditorBrowsable(EditorBrowsableState.Never)]
        public static float NormalizeAngle(float angleInRadians)
        {
            // Need to check this mod operator works with floats...
            angleInRadians = angleInRadians % SIMD_2_PI;
            if (angleInRadians < -SIMD_PI)
            {
                return angleInRadians + SIMD_2_PI;
            }
            else if (angleInRadians > SIMD_PI)
            {
                return angleInRadians - SIMD_2_PI;
            }
            else
            {
                return angleInRadians;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static float DegToRadians(float degrees)
        {
            return (degrees / 360.0f) * SIMD_2_PI;
        }

        /*
        public static Matrix SetEulerZYX(float eulerX, float eulerY, float eulerZ)
        {
            //return Matrix.CreateFromYawPitchRoll(y, x,z);
            // This version tested and compared to c++ version. don't break it.
            // note that the row/column settings are switched from c++
            Matrix m = Matrix.Identity;
            m._basis.SetEulerZYX(eulerX, eulerY, eulerZ);
            return m;

        }

        //        public static global::System.Numerics.Vector3 MatrixToVector(Matrix m, global::System.Numerics.Vector3 v)
        //        {
        //            return new global::System.Numerics.Vector3(
        //                global::System.Numerics.Vector3.Dot(new global::System.Numerics.Vector3(m.M11, m.M12, m.M13), v) + m._origin.X,
        //                global::System.Numerics.Vector3.Dot(new global::System.Numerics.Vector3(m.M21, m.M22, m.M23), v) + m._origin.Y,
        //                global::System.Numerics.Vector3.Dot(new global::System.Numerics.Vector3(m.M31, m.M32, m.M33), v) + m._origin.Z
        //                );
        //        }
        */

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static global::System.Numerics.Vector3 Vector4ToVector3(ref global::System.Numerics.Vector4 v4)
        {
            return new global::System.Numerics.Vector3(v4.X, v4.Y, v4.Z);
        }


        //        public static global::System.Numerics.Vector3 TransposeTransformNormal(global::System.Numerics.Vector3 v,Matrix m)
        //        {
        //            return TransposeTransformNormal(ref v, ref m);
        //        }

        //        public static global::System.Numerics.Vector3 TransposeTransformNormal(ref global::System.Numerics.Vector3 v,ref Matrix m)
        //        {
        //            Matrix mt = TransposeBasis(ref m);
        //            return global::System.Numerics.Vector3.TransformNormal(v, mt);
        //        }

        //        //public static global::System.Numerics.Vector3 TransposeTransformNormal(ref global::System.Numerics.Vector3 v, ref Matrix m)
        //        //{
        //        //    Matrix mt = TransposeBasis(ref m);
        //        //    return global::System.Numerics.Vector3.TransformNormal(ref v, ref mt);
        //        //}

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool IsAlmostZero(ref global::System.Numerics.Vector3 v)
        {
            if (global::System.Math.Abs(v.X) > 1e-6 || global::System.Math.Abs(v.Y) > 1e-6 || global::System.Math.Abs(v.Z) > 1e-6) return false;
            return true;
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public static global::System.Numerics.Vector3 Vector3Lerp(ref global::System.Numerics.Vector3 a, ref global::System.Numerics.Vector3 b, float t)
        {
            return new global::System.Numerics.Vector3(
                a.X + (b.X - a.X) * t,
                a.Y + (b.Y - a.Y) * t,
                a.Z + (b.Z - a.Z) * t);
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public static float Vector3Distance2XZ(global::System.Numerics.Vector3 x, global::System.Numerics.Vector3 y)
        {
            global::System.Numerics.Vector3 xa = new global::System.Numerics.Vector3(x.X, 0, x.Z);
            global::System.Numerics.Vector3 ya = new global::System.Numerics.Vector3(y.X, 0, y.Z);
            return (xa - ya).LengthSquared();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void SetRotation(this Matrix4x4 matrix, Quaternion newRotation, out Matrix4x4 result)
        {
            Matrix4x4.Decompose(matrix, out global::System.Numerics.Vector3 scale, out _, out global::System.Numerics.Vector3 translation);
            result = Matrix4x4.CreateScale(scale) * Matrix4x4.CreateFromQuaternion(newRotation) * Matrix4x4.CreateTranslation(translation);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Quaternion GetRotation(this Matrix4x4 matrix)
        {
            Matrix4x4.Decompose(matrix, out _, out Quaternion rot, out _);
            return rot;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static global::System.Numerics.Vector3 GetColumn(this Matrix4x4 matrix, int column)
        {
            return new global::System.Numerics.Vector3(matrix.GetComponent(0, column), matrix.GetComponent(1, column), matrix.GetComponent(2, column));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static global::System.Numerics.Vector3 GetRow(this Matrix4x4 matrix, int row)
        {
            return new global::System.Numerics.Vector3(matrix.GetComponent(row, 0), matrix.GetComponent(row, 1), matrix.GetComponent(row, 2));
        }

        /// <summary>
        /// Gets the component at the specified index.
        /// </summary>
        /// <value>The value of the X, Y, or Z component, depending on the index.</value>
        /// <param name="vector">The vector that contains the components to be accessed</param>
        /// <param name="index">The index of the component to access. Use 0 for the X component, 1 for the Y component, and 2 for the Z component.</param>
        /// <returns>The value of the component at the specified index.</returns>
        /// <exception cref="global::System.ArgumentOutOfRangeException">Thrown when the <paramref name="index"/> is out of the range [0, 2].</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static float GetComponent(this global::System.Numerics.Vector3 vector, int index)
        {
            switch (index)
            {
                case 0: return vector.X;
                case 1: return vector.Y;
                case 2: return vector.Z;
            }

            throw new ArgumentOutOfRangeException("index", "Indices for global::System.Numerics.Vector3 run from 0 to 2, inclusive.");
        }

        /// <summary>
        /// Sets the component at the specified index.
        /// </summary>
        /// <value>The value of the X, Y, or Z component, depending on the index.</value>
        /// <param name="vector">The vector that contains the components to be accessed</param>
        /// <param name="index">The index of the component to access. Use 0 for the X component, 1 for the Y component, and 2 for the Z component.</param>
        /// <param name="value">The new value of the component.</param>
        /// <exception cref="global::System.ArgumentOutOfRangeException">Thrown when the <paramref name="index"/> is out of the range [0, 2].</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void SetComponent(ref this global::System.Numerics.Vector3 vector, int index, float value)
        {
            switch (index)
            {
                case 0: vector.X = value; break;
                case 1: vector.Y = value; break;
                case 2: vector.Z = value; break;
                default: throw new ArgumentOutOfRangeException("index", "Indices for global::System.Numerics.Vector3 run from 0 to 2, inclusive.");
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static global::System.Numerics.Vector3 MakeVector3(float[] values)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));
            if (values.Length != 3)
                throw new ArgumentOutOfRangeException(nameof(values), "There must be three and only three input values for a global::System.Numerics.Vector3.");

            return new global::System.Numerics.Vector3(values[0], values[1], values[2]);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Matrix4x4 GetBasis(this Matrix4x4 matrix)
        {
            return new Matrix4x4(matrix.M11, matrix.M12, matrix.M13, 0,
                                 matrix.M21, matrix.M22, matrix.M23, 0,
                                 matrix.M31, matrix.M32, matrix.M33, 0,
                                 0, 0, 0, 1);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void SetBasis(ref this Matrix4x4 matrix, Matrix4x4 basis)
        {
            matrix.M11 = basis.M11;
            matrix.M12 = basis.M12;
            matrix.M13 = basis.M13;
            matrix.M21 = basis.M21;
            matrix.M22 = basis.M22;
            matrix.M23 = basis.M23;
            matrix.M31 = basis.M31;
            matrix.M32 = basis.M32;
            matrix.M33 = basis.M33;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static float GetComponent(ref this Matrix4x4 matrix, int index)
        {
            switch (index)
            {
                case 0: return matrix.M11;
                case 1: return matrix.M12;
                case 2: return matrix.M13;
                case 3: return matrix.M14;
                case 4: return matrix.M21;
                case 5: return matrix.M22;
                case 6: return matrix.M23;
                case 7: return matrix.M24;
                case 8: return matrix.M31;
                case 9: return matrix.M32;
                case 10: return matrix.M33;
                case 11: return matrix.M34;
                case 12: return matrix.M41;
                case 13: return matrix.M42;
                case 14: return matrix.M43;
                case 15: return matrix.M44;
            }

            throw new ArgumentOutOfRangeException("index", "Indices for Matrix run from 0 to 15, inclusive.");
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void SetComponent(ref this Matrix4x4 matrix, int index, float value)
        {
            switch (index)
            {
                case 0: matrix.M11 = value; break;
                case 1: matrix.M12 = value; break;
                case 2: matrix.M13 = value; break;
                case 3: matrix.M14 = value; break;
                case 4: matrix.M21 = value; break;
                case 5: matrix.M22 = value; break;
                case 6: matrix.M23 = value; break;
                case 7: matrix.M24 = value; break;
                case 8: matrix.M31 = value; break;
                case 9: matrix.M32 = value; break;
                case 10: matrix.M33 = value; break;
                case 11: matrix.M34 = value; break;
                case 12: matrix.M41 = value; break;
                case 13: matrix.M42 = value; break;
                case 14: matrix.M43 = value; break;
                case 15: matrix.M44 = value; break;
                default: throw new ArgumentOutOfRangeException("index", "Indices for Matrix run from 0 to 15, inclusive.");
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static float GetComponent(this Matrix4x4 matrix, int row, int column)
        {
            if (row < 0 || row > 3)
                throw new ArgumentOutOfRangeException("row", "Rows and columns for matrices run from 0 to 3, inclusive.");
            if (column < 0 || column > 3)
                throw new ArgumentOutOfRangeException("column", "Rows and columns for matrices run from 0 to 3, inclusive.");

            return matrix.GetComponent((row * 4) + column);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void SetComponent(ref this Matrix4x4 matrix, int row, int column, float value)
        {
            if (row < 0 || row > 3)
                throw new ArgumentOutOfRangeException("row", "Rows and columns for matrices run from 0 to 3, inclusive.");
            if (column < 0 || column > 3)
                throw new ArgumentOutOfRangeException("column", "Rows and columns for matrices run from 0 to 3, inclusive.");

            matrix.SetComponent((row * 4) + column, value);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Matrix4x4 MakeMatrix4x4(float[] values)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));
            if (values.Length != 16)
                throw new ArgumentOutOfRangeException(nameof(values), "There must be sixteen and only sixteen input values for a Matrix4x4.");

            return new Matrix4x4(values[0], values[1], values[2], values[3],
                                 values[4], values[5], values[6], values[7],
                                 values[8], values[9], values[10], values[11],
                                 values[12], values[13], values[14], values[15]);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static T Clamp<T>(T value, T min, T max)
         where T : global::System.IComparable<T>
        {
            T result = value;
            if (value.CompareTo(max) > 0)
                result = max;
            if (value.CompareTo(min) < 0)
                result = min;
            return result;
        }

        //public const float SIMD_EPSILON = 0.0000001f;
        [EditorBrowsable(EditorBrowsableState.Never)]
        public const float SIMD_EPSILON = 1.192092896e-07f;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public const float SIMDSQRT12 = 0.7071067811865475244008443621048490f;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public const float BT_LARGE_FLOAT = 1e18f;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static global::System.Numerics.Vector3 MAX_VECTOR = new global::System.Numerics.Vector3(BT_LARGE_FLOAT);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static global::System.Numerics.Vector3 MIN_VECTOR = new global::System.Numerics.Vector3(-BT_LARGE_FLOAT);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public const float SIMD_2_PI = 6.283185307179586232f;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public const float SIMD_PI = SIMD_2_PI * 0.5f;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public const float SIMD_HALF_PI = SIMD_PI * 0.5f;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public const float SIMD_QUARTER_PI = SIMD_PI * 0.25f;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public const float SIMD_INFINITY = float.MaxValue;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public const float SIMD_RADS_PER_DEG = (SIMD_2_PI / 360.0f);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public const float SIMD_DEGS_PER_RAD = (360.0f / SIMD_2_PI);
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct Matrix3x3FloatData
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector3FloatData Element0;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector3FloatData Element1;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector3FloatData Element2;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct Matrix3x3DoubleData
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector3DoubleData Element0;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector3DoubleData Element1;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector3DoubleData Element2;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct TransformFloatData
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Matrix3x3FloatData Basis;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector3FloatData Origin;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public const int OriginOffset = 48;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct TransformDoubleData
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Matrix3x3DoubleData Basis;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector3DoubleData Origin;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public const int OriginOffset = 96;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal unsafe struct Vector3FloatData
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float[] floats;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal unsafe struct Vector3DoubleData
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double[] floats;
    }
}
