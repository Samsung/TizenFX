/*
 * Copyright(c) 2019 Samsung Electronics Co., Ltd.
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

using System;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    internal class NDalic
    {
        public static uint int_to_uint(int x)
        {
            uint ret = Interop.NDalic.IntToUint(x);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public static readonly int VisualPropertyTransform = Interop.Visual.TransformGet();
        public static readonly int VisualPropertyPremultipliedAlpha = Interop.Visual.PremultipliedAlphaGet();
        public static readonly int VisualPropertyMixColor = Interop.Visual.MixColorGet();
        public static readonly int ImageVisualBorder = Interop.Visual.ImageVisualBorderGet();

        public static void DaliAssertMessage(string location, string condition)
        {
            Interop.NDalic.DaliAssertMessage(location, condition);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public static Vector2 Min(Vector2 a, Vector2 b)
        {
            Vector2 ret = new Vector2(Interop.NDalic.MinVector2(Vector2.getCPtr(a), Vector2.getCPtr(b)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public static Vector2 Max(Vector2 a, Vector2 b)
        {
            Vector2 ret = new Vector2(Interop.NDalic.MaxVector2(Vector2.getCPtr(a), Vector2.getCPtr(b)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public static Vector2 Clamp(Vector2 v, float min, float max)
        {
            Vector2 ret = new Vector2(Interop.NDalic.ClampVector2(Vector2.getCPtr(v), min, max), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public static Vector3 Min(Vector3 a, Vector3 b)
        {
            Vector3 ret = new Vector3(Interop.NDalic.MinVector3(Vector3.getCPtr(a), Vector3.getCPtr(b)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public static Vector3 Max(Vector3 a, Vector3 b)
        {
            Vector3 ret = new Vector3(Interop.NDalic.MaxVector3(Vector3.getCPtr(a), Vector3.getCPtr(b)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public static Vector3 Clamp(Vector3 v, float min, float max)
        {
            Vector3 ret = new Vector3(Interop.NDalic.ClampVector3(Vector3.getCPtr(v), min, max), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public static Vector4 Min(Vector4 a, Vector4 b)
        {
            Vector4 ret = new Vector4(Interop.NDalic.MinVector4(Vector4.getCPtr(a), Vector4.getCPtr(b)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public static Vector4 Max(Vector4 a, Vector4 b)
        {
            Vector4 ret = new Vector4(Interop.NDalic.MaxVector4(Vector4.getCPtr(a), Vector4.getCPtr(b)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public static Vector4 Clamp(Vector4 v, float min, float max)
        {
            Vector4 ret = new Vector4(Interop.NDalic.ClampVector4(Vector4.getCPtr(v), min, max), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public static bool EqualTo(AngleAxis lhs, AngleAxis rhs)
        {
            bool ret = Interop.NDalic.EqualToSwig9(AngleAxis.getCPtr(lhs), AngleAxis.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public static uint NextPowerOfTwo(uint i)
        {
            uint ret = Interop.NDalic.NextPowerOfTwo(i);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public static bool IsPowerOfTwo(uint i)
        {
            bool ret = Interop.NDalic.IsPowerOfTwo(i);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public static float GetRangedEpsilon(float a, float b)
        {
            float ret = Interop.NDalic.GetRangedEpsilon(a, b);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public static bool EqualsZero(float value)
        {
            bool ret = Interop.NDalic.EqualsZero(value);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public static bool Equals(float a, float b)
        {
            bool ret = Interop.NDalic.Equals(a, b);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public static bool Equals(float a, float b, float epsilon)
        {
            bool ret = Interop.NDalic.Equals(a, b, epsilon);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public static float Round(float value, int pos)
        {
            float ret = Interop.NDalic.Round(value, pos);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public static float WrapInDomain(float x, float start, float end)
        {
            float ret = Interop.NDalic.WrapInDomain(x, start, end);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public static float ShortestDistanceInDomain(float a, float b, float start, float end)
        {
            float ret = Interop.NDalic.ShortestDistanceInDomain(a, b, start, end);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public static string GetName(PropertyType type)
        {
            string ret = Interop.NDalic.GetName((int)type);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public static BaseObject c(BaseHandle handle)
        {
            BaseObject ret = new BaseObject(Interop.NDalic.GetImplementation(BaseHandle.getCPtr(handle)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public static int WEIGHT
        {
            get
            {
                int ret = Interop.NDalic.WeightGet();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static bool RegisterType(string name, SWIGTYPE_p_std__type_info baseType, System.Delegate f)
        {
            System.IntPtr ip = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate<System.Delegate>(f);
            {
                bool ret = Interop.NDalic.RegisterType(name, SWIGTYPE_p_std__type_info.getCPtr(baseType), new System.Runtime.InteropServices.HandleRef(null, ip));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static bool RegisterProperty(string objectName, string name, int index, PropertyType type, System.Delegate setFunc, System.Delegate getFunc)
        {
            System.IntPtr ip = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate<System.Delegate>(setFunc);
            System.IntPtr ip2 = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate<System.Delegate>(getFunc);
            {
                bool ret = Interop.NDalic.RegisterProperty(objectName, name, index, (int)type, new System.Runtime.InteropServices.HandleRef(null, ip), new System.Runtime.InteropServices.HandleRef(null, ip2));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private static Color aliceBlue = null;
        public static Color ALICE_BLUE
        {
            get
            {
                if (null == aliceBlue)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.AliceBlueGet();
                    aliceBlue = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return aliceBlue;
            }
        }

        private static Color antiqueWhite = null;
        public static Color ANTIQUE_WHITE
        {
            get
            {
                if (null == antiqueWhite)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.AntiqueWhiteGet();
                    antiqueWhite = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return antiqueWhite;
            }
        }

        private static Color aqua = null;
        public static Color AQUA
        {
            get
            {
                if (null == aqua)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.AquaGet();
                    aqua = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return aqua;
            }
        }

        private static Color aquaMarine = null;
        public static Color AQUA_MARINE
        {
            get
            {
                if (null == aquaMarine)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.AquaMarineGet();
                    aquaMarine = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return aquaMarine;
            }
        }

        private static Color azure = null;
        public static Color AZURE
        {
            get
            {
                if (null == azure)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.AzureGet();
                    azure = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return azure;
            }
        }

        private static Color beige = null;
        public static Color BEIGE
        {
            get
            {
                if (null == beige)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.BeigeGet();
                    beige = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return beige;
            }
        }

        private static Color bisque = null;
        public static Color BISQUE
        {
            get
            {
                if (null == bisque)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.BisqueGet();
                    bisque = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return bisque;
            }
        }

        private static Color black = null;
        public static Color BLACK
        {
            get
            {
                if (null == black)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.BlackGet();
                    black = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return black;
            }
        }

        private static Color blancheDalmond = null;
        public static Color BLANCHE_DALMOND
        {
            get
            {
                if (null == blancheDalmond)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.BlancheDalmondGet();
                    blancheDalmond = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return blancheDalmond;
            }
        }

        private static Color blue = null;
        public static Color BLUE
        {
            get
            {
                if (null == blue)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.BlueGet();
                    blue = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return blue;
            }
        }

        private static Color blueViolet = null;
        public static Color BLUE_VIOLET
        {
            get
            {
                if (null == blueViolet)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.BlueVioletGet();
                    blueViolet = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return blueViolet;
            }
        }

        private static Color brown = null;
        public static Color BROWN
        {
            get
            {
                if (null == brown)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.BrownGet();
                    brown = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return brown;
            }
        }

        private static Color burlyWood = null;
        public static Color BURLY_WOOD
        {
            get
            {
                if (null == burlyWood)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.BurlyWoodGet();
                    burlyWood = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return burlyWood;
            }
        }

        private static Color cadetBlue = null;
        public static Color CADET_BLUE
        {
            get
            {
                if (null == cadetBlue)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.CadetBlueGet();
                    cadetBlue = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return cadetBlue;
            }
        }

        private static Color chartreuse = null;
        public static Color CHARTREUSE
        {
            get
            {
                if (null == chartreuse)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.ChartreuseGet();
                    chartreuse = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return chartreuse;
            }
        }

        private static Color chocolate = null;
        public static Color CHOCOLATE
        {
            get
            {
                if (null == chocolate)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.ChocolateGet();
                    chocolate = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return chocolate;
            }
        }

        private static Color coral = null;
        public static Color CORAL
        {
            get
            {
                if (null == coral)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.CoralGet();
                    coral = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return coral;
            }
        }

        private static Color cornflowerBlue = null;
        public static Color CORNFLOWER_BLUE
        {
            get
            {
                if (null == cornflowerBlue)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.CornflowerBlueGet();
                    cornflowerBlue = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return cornflowerBlue;
            }
        }

        private static Color cornsilk = null;
        public static Color CORNSILK
        {
            get
            {
                if (null == cornsilk)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.CornsilkGet();
                    cornsilk = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return cornsilk;
            }
        }

        private static Color crimson = null;
        public static Color CRIMSON
        {
            get
            {
                if (null == crimson)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.CrimsonGet();
                    crimson = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return crimson;
            }
        }

        private static Color cyan = null;
        public static Color CYAN
        {
            get
            {
                if (null == cyan)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.CyanGet();
                    cyan = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return cyan;
            }
        }

        private static Color darkBlue = null;
        public static Color DARK_BLUE
        {
            get
            {
                if (null == darkBlue)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.DarkBlueGet();
                    darkBlue = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return darkBlue;
            }
        }

        private static Color darkCyan = null;
        public static Color DARK_CYAN
        {
            get
            {
                if (null == darkCyan)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.DarkCyanGet();
                    darkCyan = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return darkCyan;
            }
        }

        private static Color darkGoldenrod = null;
        public static Color DARK_GOLDENROD
        {
            get
            {
                if (null == darkGoldenrod)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.DarkGoldenrodGet();
                    darkGoldenrod = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return darkGoldenrod;
            }
        }

        private static Color darkGray = null;
        public static Color DARK_GRAY
        {
            get
            {
                if (null == darkGray)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.DarkGrayGet();
                    darkGray = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return darkGray;
            }
        }

        private static Color darkGreen = null;
        public static Color DARK_GREEN
        {
            get
            {
                if (null == darkGreen)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.DarkGreenGet();
                    darkGreen = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return darkGreen;
            }
        }

        private static Color darkGrey = null;
        public static Color DARK_GREY
        {
            get
            {
                if (null == darkGrey)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.DarkGreyGet();
                    darkGrey = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return darkGrey;
            }
        }

        private static Color darkKhaki = null;
        public static Color DARK_KHAKI
        {
            get
            {
                if (null == darkKhaki)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.DarkKhakiGet();
                    darkKhaki = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return darkKhaki;
            }
        }

        private static Color darkMagenta = null;
        public static Color DARK_MAGENTA
        {
            get
            {
                if (null == darkMagenta)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.DarkMagentaGet();
                    darkMagenta = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return darkMagenta;
            }
        }

        private static Color darkOliveGreen = null;
        public static Color DARK_OLIVE_GREEN
        {
            get
            {
                if (null == darkOliveGreen)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.DarkOliveGreenGet();
                    darkOliveGreen = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return darkOliveGreen;
            }
        }

        private static Color darkOrange = null;
        public static Color DARK_ORANGE
        {
            get
            {
                if (null == darkOrange)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.DarkOrangeGet();
                    darkOrange = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return darkOrange;
            }
        }

        private static Color darkOrchid = null;
        public static Color DARK_ORCHID
        {
            get
            {
                if (null == darkOrchid)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.DarkOrchidGet();
                    darkOrchid = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return darkOrchid;
            }
        }

        private static Color darkRed = null;
        public static Color DARK_RED
        {
            get
            {
                if (null == darkRed)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.DarkRedGet();
                    darkRed = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return darkRed;
            }
        }

        private static Color darkSalmon = null;
        public static Color DARK_SALMON
        {
            get
            {
                if (null == darkSalmon)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.DarkSalmonGet();
                    darkSalmon = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return darkSalmon;
            }
        }

        private static Color darkSeaGreen = null;
        public static Color DARK_SEA_GREEN
        {
            get
            {
                if (null == darkSeaGreen)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.DarkSeaGreenGet();
                    darkSeaGreen = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return darkSeaGreen;
            }
        }

        private static Color darkSlateBlue = null;
        public static Color DARK_SLATE_BLUE
        {
            get
            {
                if (null == darkSlateBlue)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.DarkSlateBlueGet();
                    darkSlateBlue = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return darkSlateBlue;
            }
        }

        private static Color darkSlateGray = null;
        public static Color DARK_SLATE_GRAY
        {
            get
            {
                if (null == darkSlateGray)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.DarkSlateGrayGet();
                    darkSlateGray = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return darkSlateGray;
            }
        }

        private static Color darkSlateGrey = null;
        public static Color DARK_SLATE_GREY
        {
            get
            {
                if (null == darkSlateGrey)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.DarkSlateGreyGet();
                    darkSlateGrey = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return darkSlateGrey;
            }
        }

        private static Color darkTurquoise = null;
        public static Color DARK_TURQUOISE
        {
            get
            {
                if (null == darkTurquoise)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.DarkTurquoiseGet();
                    darkTurquoise = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return darkTurquoise;
            }
        }

        private static Color darkViolet = null;
        public static Color DARK_VIOLET
        {
            get
            {
                if (null == darkViolet)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.DarkVioletGet();
                    darkViolet = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return darkViolet;
            }
        }

        private static Color deepPink = null;
        public static Color DEEP_PINK
        {
            get
            {
                if (null == deepPink)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.DeepPinkGet();
                    deepPink = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return deepPink;
            }
        }

        private static Color deepSkyBlue = null;
        public static Color DEEP_SKY_BLUE
        {
            get
            {
                if (null == deepSkyBlue)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.DeepSkyBlueGet();
                    deepSkyBlue = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return deepSkyBlue;
            }
        }

        private static Color dimGray = null;
        public static Color DIM_GRAY
        {
            get
            {
                if (null == dimGray)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.DimGrayGet();
                    dimGray = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return dimGray;
            }
        }

        private static Color dimGrey = null;
        public static Color DIM_GREY
        {
            get
            {
                if (null == dimGrey)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.DimGreyGet();
                    dimGrey = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return dimGrey;
            }
        }

        private static Color dodgerBlue = null;
        public static Color DODGER_BLUE
        {
            get
            {
                if (null == dodgerBlue)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.DodgerBlueGet();
                    dodgerBlue = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return dodgerBlue;
            }
        }

        private static Color fireBrick = null;
        public static Color FIRE_BRICK
        {
            get
            {
                if (null == fireBrick)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.FireBrickGet();
                    fireBrick = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return fireBrick;
            }
        }

        private static Color floralWhite = null;
        public static Color FLORAL_WHITE
        {
            get
            {
                if (null == floralWhite)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.FloralWhiteGet();
                    floralWhite = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return floralWhite;
            }
        }

        private static Color forestGreen = null;
        public static Color FOREST_GREEN
        {
            get
            {
                if (null == forestGreen)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.ForestGreenGet();
                    forestGreen = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return forestGreen;
            }
        }

        private static Color fuchsia = null;
        public static Color FUCHSIA
        {
            get
            {
                if (null == fuchsia)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.FuchsiaGet();
                    fuchsia = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return fuchsia;
            }
        }

        private static Color gainsboro = null;
        public static Color GAINSBORO
        {
            get
            {
                if (null == gainsboro)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.GainsboroGet();
                    gainsboro = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return gainsboro;
            }
        }

        private static Color ghostWhite = null;
        public static Color GHOST_WHITE
        {
            get
            {
                if (null == ghostWhite)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.GhostWhiteGet();
                    ghostWhite = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return ghostWhite;
            }
        }

        private static Color gold = null;
        public static Color GOLD
        {
            get
            {
                if (null == gold)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.GoldGet();
                    gold = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return gold;
            }
        }

        private static Color goldenRod = null;
        public static Color GOLDEN_ROD
        {
            get
            {
                if (null == goldenRod)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.GoldenRodGet();
                    goldenRod = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return goldenRod;
            }
        }

        private static Color gray = null;
        public static Color GRAY
        {
            get
            {
                if (null == gray)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.GrayGet();
                    gray = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return gray;
            }
        }

        private static Color green = null;
        public static Color GREEN
        {
            get
            {
                if (null == green)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.GreenGet();
                    green = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return green;
            }
        }

        private static Color greenYellow = null;
        public static Color GREEN_YELLOW
        {
            get
            {
                if (null == greenYellow)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.GreenYellowGet();
                    greenYellow = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return greenYellow;
            }
        }

        private static Color grey = null;
        public static Color GREY
        {
            get
            {
                if (null == grey)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.GreyGet();
                    grey = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return grey;
            }
        }

        private static Color honeydew = null;
        public static Color HONEYDEW
        {
            get
            {
                if (null == honeydew)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.HoneydewGet();
                    honeydew = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return honeydew;
            }
        }

        private static Color hotPink = null;
        public static Color HOT_PINK
        {
            get
            {
                if (null == hotPink)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.HotPinkGet();
                    hotPink = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return hotPink;
            }
        }

        private static Color indianred = null;
        public static Color INDIANRED
        {
            get
            {
                if (null == indianred)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.IndianredGet();
                    indianred = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return indianred;
            }
        }

        private static Color indigo = null;
        public static Color INDIGO
        {
            get
            {
                if (null == indigo)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.IndigoGet();
                    indigo = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return indigo;
            }
        }

        private static Color ivory = null;
        public static Color IVORY
        {
            get
            {
                if (null == ivory)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.IvoryGet();
                    ivory = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return ivory;
            }
        }

        private static Color khaki = null;
        public static Color KHAKI
        {
            get
            {
                if (null == khaki)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.KhakiGet();
                    khaki = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return khaki;
            }
        }

        private static Color lavender = null;
        public static Color LAVENDER
        {
            get
            {
                if (null == lavender)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.LavenderGet();
                    lavender = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return lavender;
            }
        }

        private static Color lavenderBlush = null;
        public static Color LAVENDER_BLUSH
        {
            get
            {
                if (null == lavenderBlush)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.LavenderBlushGet();
                    lavenderBlush = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return lavenderBlush;
            }
        }

        private static Color lawnGreen = null;
        public static Color LAWN_GREEN
        {
            get
            {
                if (null == lawnGreen)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.LawnGreenGet();
                    lawnGreen = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return lawnGreen;
            }
        }

        private static Color lemonChiffon = null;
        public static Color LEMON_CHIFFON
        {
            get
            {
                if (null == lemonChiffon)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.LemonChiffonGet();
                    lemonChiffon = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return lemonChiffon;
            }
        }

        private static Color lightBlue = null;
        public static Color LIGHT_BLUE
        {
            get
            {
                if (null == lightBlue)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.LightBlueGet();
                    lightBlue = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return lightBlue;
            }
        }

        private static Color lightCoral = null;
        public static Color LIGHT_CORAL
        {
            get
            {
                if (null == lightCoral)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.LightCoralGet();
                    lightCoral = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return lightCoral;
            }
        }

        private static Color lightCyan = null;
        public static Color LIGHT_CYAN
        {
            get
            {
                if (null == lightCyan)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.LightCyanGet();
                    lightCyan = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return lightCyan;
            }
        }

        private static Color lightGoldenRodYellow = null;
        public static Color LIGHT_GOLDEN_ROD_YELLOW
        {
            get
            {
                if (null == lightGoldenRodYellow)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.LightGoldenRodYellowGet();
                    lightGoldenRodYellow = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return lightGoldenRodYellow;
            }
        }

        private static Color lightGray = null;
        public static Color LIGHT_GRAY
        {
            get
            {
                if (null == lightGray)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.LightGrayGet();
                    lightGray = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return lightGray;
            }
        }

        private static Color lightGreen = null;
        public static Color LIGHT_GREEN
        {
            get
            {
                if (null == lightGreen)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.LightGreenGet();
                    lightGreen = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return lightGreen;
            }
        }

        private static Color lightGrey = null;
        public static Color LIGHT_GREY
        {
            get
            {
                if (null == lightGrey)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.LightGreyGet();
                    lightGrey = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return lightGrey;
            }
        }

        private static Color lightPink = null;
        public static Color LIGHT_PINK
        {
            get
            {
                if (null == lightPink)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.LightPinkGet();
                    lightPink = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return lightPink;
            }
        }

        private static Color lightSalmon = null;
        public static Color LIGHT_SALMON
        {
            get
            {
                if (null == lightSalmon)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.LightSalmonGet();
                    lightSalmon = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return lightSalmon;
            }
        }

        private static Color lightSeaGreen = null;
        public static Color LIGHT_SEA_GREEN
        {
            get
            {
                if (null == lightSeaGreen)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.LightSeaGreenGet();
                    lightSeaGreen = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return lightSeaGreen;
            }
        }

        private static Color lightSkyBlue = null;
        public static Color LIGHT_SKY_BLUE
        {
            get
            {
                if (null == lightSkyBlue)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.LightSkyBlueGet();
                    lightSkyBlue = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return lightSkyBlue;
            }
        }

        private static Color lightSlateGray = null;
        public static Color LIGHT_SLATE_GRAY
        {
            get
            {
                if (null == lightSlateGray)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.LightSlateGrayGet();
                    lightSlateGray = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return lightSlateGray;
            }
        }

        private static Color lightSlateGrey = null;
        public static Color LIGHT_SLATE_GREY
        {
            get
            {
                if (null == lightSlateGrey)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.LightSlateGreyGet();
                    lightSlateGrey = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return lightSlateGrey;
            }
        }

        private static Color lightSteelBlue = null;
        public static Color LIGHT_STEEL_BLUE
        {
            get
            {
                if (null == lightSteelBlue)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.LightSteelBlueGet();
                    lightSteelBlue = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return lightSteelBlue;
            }
        }

        private static Color lightYellow = null;
        public static Color LIGHT_YELLOW
        {
            get
            {
                if (null == lightYellow)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.LightYellowGet();
                    lightYellow = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return lightYellow;
            }
        }

        private static Color lime = null;
        public static Color LIME
        {
            get
            {
                if (null == lime)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.LimeGet();
                    lime = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return lime;
            }
        }

        private static Color limeGreen = null;
        public static Color LIME_GREEN
        {
            get
            {
                if (null == limeGreen)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.LimeGreenGet();
                    limeGreen = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return limeGreen;
            }
        }

        private static Color linen = null;
        public static Color LINEN
        {
            get
            {
                if (null == linen)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.LinenGet();
                    linen = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return linen;
            }
        }

        private static Color magenta = null;
        public static Color MAGENTA
        {
            get
            {
                if (null == magenta)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.MagentaGet();
                    magenta = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return magenta;
            }
        }

        private static Color maroon = null;
        public static Color MAROON
        {
            get
            {
                if (null == maroon)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.MaroonGet();
                    maroon = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return maroon;
            }
        }

        private static Color mediumAquaMarine = null;
        public static Color MEDIUM_AQUA_MARINE
        {
            get
            {
                if (null == mediumAquaMarine)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.MediumAquaMarineGet();
                    mediumAquaMarine = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return mediumAquaMarine;
            }
        }

        private static Color mediumBlue = null;
        public static Color MEDIUM_BLUE
        {
            get
            {
                if (null == mediumBlue)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.MediumBlueGet();
                    mediumBlue = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return mediumBlue;
            }
        }

        private static Color mediumOrchid = null;
        public static Color MEDIUM_ORCHID
        {
            get
            {
                if (null == mediumOrchid)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.MediumOrchidGet();
                    mediumOrchid = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return mediumOrchid;
            }
        }

        private static Color mediumPurple = null;
        public static Color MEDIUM_PURPLE
        {
            get
            {
                if (null == mediumPurple)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.MediumPurpleGet();
                    mediumPurple = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return mediumPurple;
            }
        }

        private static Color mediumSeaGreen = null;
        public static Color MEDIUM_SEA_GREEN
        {
            get
            {
                if (null == mediumSeaGreen)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.MediumSeaGreenGet();
                    mediumSeaGreen = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return mediumSeaGreen;
            }
        }

        private static Color mediumSlateBlue = null;
        public static Color MEDIUM_SLATE_BLUE
        {
            get
            {
                if (null == mediumSlateBlue)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.MediumSlateBlueGet();
                    mediumSlateBlue = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return mediumSlateBlue;
            }
        }

        private static Color mediumSpringGreen = null;
        public static Color MEDIUM_SPRING_GREEN
        {
            get
            {
                if (null == mediumSpringGreen)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.MediumSpringGreenGet();
                    mediumSpringGreen = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return mediumSpringGreen;
            }
        }

        private static Color mediumTurquoise = null;
        public static Color MEDIUM_TURQUOISE
        {
            get
            {
                if (null == mediumTurquoise)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.MediumTurquoiseGet();
                    mediumTurquoise = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return mediumTurquoise;
            }
        }

        private static Color mediumVioletred = null;
        public static Color MEDIUM_VIOLETRED
        {
            get
            {
                if (null == mediumVioletred)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.MediumVioletredGet();
                    mediumVioletred = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return mediumVioletred;
            }
        }

        private static Color midnightBlue = null;
        public static Color MIDNIGHT_BLUE
        {
            get
            {
                if (null == midnightBlue)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.MidnightBlueGet();
                    midnightBlue = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return midnightBlue;
            }
        }

        private static Color mintCream = null;
        public static Color MINT_CREAM
        {
            get
            {
                if (null == mintCream)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.MintCreamGet();
                    mintCream = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return mintCream;
            }
        }

        private static Color mistyRose = null;
        public static Color MISTY_ROSE
        {
            get
            {
                if (null == mistyRose)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.MistyRoseGet();
                    mistyRose = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return mistyRose;
            }
        }

        private static Color moccasin = null;
        public static Color MOCCASIN
        {
            get
            {
                if (null == moccasin)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.MoccasinGet();
                    moccasin = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return moccasin;
            }
        }

        private static Color navajoWhite = null;
        public static Color NAVAJO_WHITE
        {
            get
            {
                if (null == navajoWhite)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.NavajoWhiteGet();
                    navajoWhite = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return navajoWhite;
            }
        }

        private static Color navy = null;
        public static Color NAVY
        {
            get
            {
                if (null == navy)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.NavyGet();
                    navy = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return navy;
            }
        }

        private static Color oldLace = null;
        public static Color OLD_LACE
        {
            get
            {
                if (null == oldLace)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.OldLaceGet();
                    oldLace = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return oldLace;
            }
        }

        private static Color olive = null;
        public static Color OLIVE
        {
            get
            {
                if (null == olive)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.OliveGet();
                    olive = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return olive;
            }
        }

        private static Color oliveDrab = null;
        public static Color OLIVE_DRAB
        {
            get
            {
                if (null == oliveDrab)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.OliveDrabGet();
                    oliveDrab = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return oliveDrab;
            }
        }

        private static Color orange = null;
        public static Color ORANGE
        {
            get
            {
                if (null == orange)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.OrangeGet();
                    orange = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return orange;
            }
        }

        private static Color orangeRed = null;
        public static Color ORANGE_RED
        {
            get
            {
                if (null == orangeRed)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.OrangeRedGet();
                    orangeRed = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return orangeRed;
            }
        }

        private static Color orchid = null;
        public static Color ORCHID
        {
            get
            {
                if (null == orchid)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.OrchidGet();
                    orchid = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return orchid;
            }
        }

        private static Color paleGoldenRod = null;
        public static Color PALE_GOLDEN_ROD
        {
            get
            {
                if (null == paleGoldenRod)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.PaleGoldenRodGet();
                    paleGoldenRod = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return paleGoldenRod;
            }
        }

        private static Color paleGreen = null;
        public static Color PALE_GREEN
        {
            get
            {
                if (null == paleGreen)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.PaleGreenGet();
                    paleGreen = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return paleGreen;
            }
        }

        private static Color paleTurquoise = null;
        public static Color PALE_TURQUOISE
        {
            get
            {
                if (null == paleTurquoise)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.PaleTurquoiseGet();
                    paleTurquoise = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return paleTurquoise;
            }
        }

        private static Color paleVioletRed = null;
        public static Color PALE_VIOLET_RED
        {
            get
            {
                if (null == paleVioletRed)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.PaleVioletRedGet();
                    paleVioletRed = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return paleVioletRed;
            }
        }

        private static Color papayaWhip = null;
        public static Color PAPAYA_WHIP
        {
            get
            {
                if (null == papayaWhip)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.PapayaWhipGet();
                    papayaWhip = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return papayaWhip;
            }
        }

        private static Color peachPuff = null;
        public static Color PEACH_PUFF
        {
            get
            {
                if (null == peachPuff)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.PeachPuffGet();
                    peachPuff = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return peachPuff;
            }
        }

        private static Color peru = null;
        public static Color PERU
        {
            get
            {
                if (null == peru)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.PeruGet();
                    peru = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return peru;
            }
        }

        private static Color pink = null;
        public static Color PINK
        {
            get
            {
                if (null == pink)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.PinkGet();
                    pink = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return pink;
            }
        }

        private static Color plum = null;
        public static Color PLUM
        {
            get
            {
                if (null == plum)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.PlumGet();
                    plum = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return plum;
            }
        }

        private static Color powderBlue = null;
        public static Color POWDER_BLUE
        {
            get
            {
                if (null == powderBlue)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.PowderBlueGet();
                    powderBlue = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return powderBlue;
            }
        }

        private static Color purple = null;
        public static Color PURPLE
        {
            get
            {
                if (null == purple)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.PurpleGet();
                    purple = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return purple;
            }
        }

        private static Color red = null;
        public static Color RED
        {
            get
            {
                if (null == red)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.RedGet();
                    red = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return red;
            }
        }

        private static Color rosyBrown = null;
        public static Color ROSY_BROWN
        {
            get
            {
                if (null == rosyBrown)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.RosyBrownGet();
                    rosyBrown = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return rosyBrown;
            }
        }

        private static Color royalBlue = null;
        public static Color ROYAL_BLUE
        {
            get
            {
                if (null == royalBlue)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.RoyalBlueGet();
                    royalBlue = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return royalBlue;
            }
        }

        private static Color saddleBrown = null;
        public static Color SADDLE_BROWN
        {
            get
            {
                if (null == saddleBrown)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.SaddleBrownGet();
                    saddleBrown = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return saddleBrown;
            }
        }

        private static Color salmon = null;
        public static Color SALMON
        {
            get
            {
                if (null == salmon)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.SalmonGet();
                    salmon = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return salmon;
            }
        }

        private static Color sandyBrown = null;
        public static Color SANDY_BROWN
        {
            get
            {
                if (null == sandyBrown)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.SandyBrownGet();
                    sandyBrown = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return sandyBrown;
            }
        }

        private static Color seaGreen = null;
        public static Color SEA_GREEN
        {
            get
            {
                if (null == seaGreen)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.SeaGreenGet();
                    seaGreen = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return seaGreen;
            }
        }

        private static Color seaShell = null;
        public static Color SEA_SHELL
        {
            get
            {
                if (null == seaShell)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.SeaShellGet();
                    seaShell = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return seaShell;
            }
        }

        private static Color sienna = null;
        public static Color SIENNA
        {
            get
            {
                if (null == sienna)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.SiennaGet();
                    sienna = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return sienna;
            }
        }

        private static Color silver = null;
        public static Color SILVER
        {
            get
            {
                if (null == silver)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.SilverGet();
                    silver = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return silver;
            }
        }

        private static Color skyBlue = null;
        public static Color SKY_BLUE
        {
            get
            {
                if (null == skyBlue)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.SkyBlueGet();
                    skyBlue = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return skyBlue;
            }
        }

        private static Color slateBlue = null;
        public static Color SLATE_BLUE
        {
            get
            {
                if (null == slateBlue)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.SlateBlueGet();
                    slateBlue = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return slateBlue;
            }
        }

        private static Color slateGray = null;
        public static Color SLATE_GRAY
        {
            get
            {
                if (null == slateGray)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.SlateGrayGet();
                    slateGray = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return slateGray;
            }
        }

        private static Color slateGrey = null;
        public static Color SLATE_GREY
        {
            get
            {
                if (null == slateGrey)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.SlateGreyGet();
                    slateGrey = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return slateGrey;
            }
        }

        private static Color snow = null;
        public static Color SNOW
        {
            get
            {
                if (null == snow)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.SnowGet();
                    snow = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return snow;
            }
        }

        private static Color springGreen = null;
        public static Color SPRING_GREEN
        {
            get
            {
                if (null == springGreen)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.SpringGreenGet();
                    springGreen = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return springGreen;
            }
        }

        private static Color steelBlue = null;
        public static Color STEEL_BLUE
        {
            get
            {
                if (null == steelBlue)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.SteelBlueGet();
                    steelBlue = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return steelBlue;
            }
        }

        private static Color tan = null;
        public static Color TAN
        {
            get
            {
                if (null == tan)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.TanGet();
                    tan = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return tan;
            }
        }

        private static Color teal = null;
        public static Color TEAL
        {
            get
            {
                if (null == teal)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.TealGet();
                    teal = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return teal;
            }
        }

        private static Color thistle = null;
        public static Color THISTLE
        {
            get
            {
                if (null == thistle)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.ThistleGet();
                    thistle = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return thistle;
            }
        }

        private static Color tomato = null;
        public static Color TOMATO
        {
            get
            {
                if (null == tomato)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.TomatoGet();
                    tomato = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return tomato;
            }
        }

        private static Color transparent = null;
        public static Color TRANSPARENT
        {
            get
            {
                if (null == transparent)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.TransparentGet();
                    transparent = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return transparent;
            }
        }

        private static Color turquoise = null;
        public static Color TURQUOISE
        {
            get
            {
                if (null == turquoise)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.TurquoiseGet();
                    turquoise = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return turquoise;
            }
        }

        private static Color violet = null;
        public static Color VIOLET
        {
            get
            {
                if (null == violet)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.VioletGet();
                    violet = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return violet;
            }
        }

        private static Color wheat = null;
        public static Color WHEAT
        {
            get
            {
                if (null == wheat)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.WheatGet();
                    wheat = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return wheat;
            }
        }

        private static Color white = null;
        public static Color WHITE
        {
            get
            {
                if (null == white)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.WhiteGet();
                    white = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return white;
            }
        }

        private static Color whiteSmoke = null;
        public static Color WHITE_SMOKE
        {
            get
            {
                if (null == whiteSmoke)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.WhiteSmokeGet();
                    whiteSmoke = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return whiteSmoke;
            }
        }

        private static Color yellow = null;
        public static Color YELLOW
        {
            get
            {
                if (null == yellow)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.YellowGet();
                    yellow = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return yellow;
            }
        }

        private static Color yellowGreen = null;
        public static Color YELLOW_GREEN
        {
            get
            {
                if (null == yellowGreen)
                {
                    global::System.IntPtr cPtr = Interop.NDalicColor.YellowGreenGet();
                    yellowGreen = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }

                return yellowGreen;
            }
        }

        internal static float MACHINE_EPSILON_0
        {
            get
            {
                float ret = Interop.NDalicMachine.MachineEpsilon0Get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        internal static float MACHINE_EPSILON_1
        {
            get
            {
                float ret = Interop.NDalicMachine.MachineEpsilon1Get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        internal static float MACHINE_EPSILON_10
        {
            get
            {
                float ret = Interop.NDalicMachine.MachineEpsilon10Get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        internal static float MACHINE_EPSILON_100
        {
            get
            {
                float ret = Interop.NDalicMachine.MachineEpsilon100Get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        internal static float MACHINE_EPSILON_1000
        {
            get
            {
                float ret = Interop.NDalicMachine.MachineEpsilon1000Get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        internal static float MACHINE_EPSILON_10000
        {
            get
            {
                float ret = Interop.NDalicMachine.MachineEpsilon10000Get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        internal static PixelFormat FIRST_VALID_PIXEL_FORMAT
        {
            get
            {
                PixelFormat ret = (PixelFormat)Interop.NDalic.FirstValidPixelFormatGet();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        internal static PixelFormat LAST_VALID_PIXEL_FORMAT
        {
            get
            {
                PixelFormat ret = (PixelFormat)Interop.NDalic.LastValidPixelFormatGet();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        internal static bool HasAlpha(PixelFormat pixelformat)
        {
            bool ret = Interop.NDalic.HasAlpha((int)pixelformat);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static uint GetBytesPerPixel(PixelFormat pixelFormat)
        {
            uint ret = Interop.NDalic.GetBytesPerPixel((int)pixelFormat);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static void GetAlphaOffsetAndMask(PixelFormat pixelFormat, SWIGTYPE_p_int byteOffset, SWIGTYPE_p_int bitMask)
        {
            Interop.NDalic.GetAlphaOffsetAndMask((int)pixelFormat, SWIGTYPE_p_int.getCPtr(byteOffset), SWIGTYPE_p_int.getCPtr(bitMask));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal static uint POSITIVE_X
        {
            get
            {
                uint ret = Interop.NDalicXYZ.PositiveXGet();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        internal static uint NEGATIVE_X
        {
            get
            {
                uint ret = Interop.NDalicXYZ.NegativeXGet();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        internal static uint POSITIVE_Y
        {
            get
            {
                uint ret = Interop.NDalicXYZ.PositiveYGet();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        internal static uint NEGATIVE_Y
        {
            get
            {
                uint ret = Interop.NDalicXYZ.NegativeYGet();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        internal static uint POSITIVE_Z
        {
            get
            {
                uint ret = Interop.NDalicXYZ.PositiveZGet();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        internal static uint NEGATIVE_Z
        {
            get
            {
                uint ret = Interop.NDalicXYZ.NegativeZGet();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private static string GetDeviceName(Key keyEvent)
        {
            string ret = Interop.NDalic.GetDeviceName(Key.getCPtr(keyEvent));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public static DeviceClassType GetDeviceClass(Key keyEvent)
        {
            DeviceClassType ret = (DeviceClassType)Interop.NDalic.GetDeviceClass(Key.getCPtr(keyEvent));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public static void Raise(View view)
        {
            Interop.NDalic.Raise(View.getCPtr(view));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public static void Lower(View view)
        {
            Interop.NDalic.Lower(View.getCPtr(view));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public static void RaiseToTop(View view)
        {
            Interop.NDalic.RaiseToTop(View.getCPtr(view));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public static void LowerToBottom(View view)
        {
            Interop.NDalic.LowerToBottom(View.getCPtr(view));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public static void RaiseAbove(View view, View target)
        {
            Interop.NDalic.RaiseAbove(View.getCPtr(view), View.getCPtr(target));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public static void LowerBelow(View view, View target)
        {
            Interop.NDalic.LowerBelow(View.getCPtr(view), View.getCPtr(target));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public static ViewImpl GetImplementation(View handle)
        {
            ViewImpl ret = new ViewImpl(Interop.NDalic.GetImplementationControl(View.getCPtr(handle)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static SWIGTYPE_p_Dali__IntrusivePtrT_Dali__Toolkit__ItemLayout_t NewItemLayout(DefaultItemLayoutType type)
        {
            SWIGTYPE_p_Dali__IntrusivePtrT_Dali__Toolkit__ItemLayout_t ret = new SWIGTYPE_p_Dali__IntrusivePtrT_Dali__Toolkit__ItemLayout_t(Interop.NDalic.NewItemLayout((int)type));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static void SetCustomAlgorithm(SWIGTYPE_p_KeyboardFocusManager keyboardFocusManager, CustomAlgorithmInterface arg1)
        {
            Interop.NDalic.SetCustomAlgorithm(SWIGTYPE_p_KeyboardFocusManager.getCPtr(keyboardFocusManager), CustomAlgorithmInterface.getCPtr(arg1));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal static readonly int VisualPropertyType = Interop.NDalicVisual.VisualPropertyTypeGet();
        internal static readonly int VisualPropertyShader = Interop.NDalicVisual.VisualPropertyShaderGet();

        internal static readonly int VisualShaderVertex = Interop.NDalicVisual.VisualShaderVertexGet();
        internal static readonly int VisualShaderFragment = Interop.NDalicVisual.VisualShaderFragmentGet();
        internal static readonly int VisualShaderSubdivideGridX = Interop.NDalicVisual.VisualShaderSubdivideGridXGet();
        internal static readonly int VisualShaderSubdivideGridY = Interop.NDalicVisual.VisualShaderSubdivideGridYGet();
        internal static readonly int VisualShaderHints = Interop.NDalicVisual.VisualShaderHintsGet();

        internal static readonly int BorderVisualColor = Interop.NDalicBorderVisual.ColorGet();
        internal static readonly int BorderVisualSize = Interop.NDalicBorderVisual.SizeGet();
        internal static readonly int BorderVisualAntiAliasing = Interop.NDalicBorderVisual.AntiAliasingGet();

        internal static readonly int ColorVisualMixColor = Interop.NDalicColorVisual.ColorVisualMixColorGet();

        internal static readonly int GradientVisualStartPosition = Interop.NDalicGradientVisual.GradientVisualStartPositionGet();
        internal static readonly int GradientVisualEndPosition = Interop.NDalicGradientVisual.GradientVisualEndPositionGet();
        internal static readonly int GradientVisualCenter = Interop.NDalicGradientVisual.GradientVisualCenterGet();
        internal static readonly int GradientVisualRadius = Interop.NDalicGradientVisual.GradientVisualRadiusGet();
        internal static readonly int GradientVisualStopOffset = Interop.NDalicGradientVisual.GradientVisualStopOffsetGet();
        internal static readonly int GradientVisualStopColor = Interop.NDalicGradientVisual.GradientVisualStopColorGet();
        internal static readonly int GradientVisualUnits = Interop.NDalicGradientVisual.GradientVisualUnitsGet();
        internal static readonly int GradientVisualSpreadMethod = Interop.NDalicGradientVisual.GradientVisualSpreadMethodGet();

        internal static readonly int ImageVisualUrl = Interop.NDalicImageVisual.ImageVisualUrlGet();
        internal static readonly int ImageVisualAlphaMaskUrl = Interop.NDalicImageVisual.ImageVisualAlphaMaskUrlGet();
        internal static readonly int ImageVisualFittingMode = Interop.NDalicImageVisual.ImageVisualFittingModeGet();
        internal static readonly int ImageVisualSamplingMode = Interop.NDalicImageVisual.ImageVisualSamplingModeGet();
        internal static readonly int ImageVisualDesiredWidth = Interop.NDalicImageVisual.ImageVisualDesiredWidthGet();
        internal static readonly int ImageVisualDesiredHeight = Interop.NDalicImageVisual.ImageVisualDesiredHeightGet();
        internal static readonly int ImageVisualSynchronousLoading = Interop.NDalicImageVisual.ImageVisualSynchronousLoadingGet();
        internal static readonly int ImageVisualBorderOnly = Interop.NDalicImageVisual.ImageVisualBorderOnlyGet();
        internal static readonly int ImageVisualPixelArea = Interop.NDalicImageVisual.ImageVisualPixelAreaGet();
        internal static readonly int ImageVisualWrapModeU = Interop.NDalicImageVisual.ImageVisualWrapModeUGet();
        internal static readonly int ImageVisualWrapModeV = Interop.NDalicImageVisual.ImageVisualWrapModeVGet();
        internal static readonly int ImageVisualBatchSize = Interop.NDalicImageVisual.ImageVisualBatchSizeGet();
        internal static readonly int ImageVisualCacheSize = Interop.NDalicImageVisual.ImageVisualCacheSizeGet();
        internal static readonly int ImageVisualFrameDelay = Interop.NDalicImageVisual.ImageVisualFrameDelayGet();
        internal static readonly int ImageVisualLoopCount = Interop.NDalicImageVisual.ImageVisualLoopCountGet();
        internal static readonly int ImageVisualMaskContentScale = Interop.NDalicImageVisual.ImageVisualMaskContentScaleGet();
        internal static readonly int ImageVisualCropToMask = Interop.NDalicImageVisual.ImageVisualCropToMaskGet();
        internal static readonly int ImageVisualReleasePolicy = Interop.NDalicImageVisual.ImageVisualReleasePolicyGet();
        internal static readonly int ImageVisualLoadPolicy = Interop.NDalicImageVisual.ImageVisualLoadPolicyGet();
        internal static readonly int ImageVisualOrientationCorrection = Interop.NDalicImageVisual.ImageVisualOrientationCorrectionGet();
        internal static readonly int ImageVisualAuxiliaryImageUrl = Interop.NDalicImageVisual.ImageVisualAuxiliaryImageUrlGet();
        internal static readonly int ImageVisualAuxiliaryImageAlpha = Interop.NDalicImageVisual.ImageVisualAuxiliaryImageAlphaGet();

        internal static readonly int MeshVisualObjectUrl = Interop.NDalicMeshVisual.MeshVisualObjectUrlGet();
        internal static readonly int MeshVisualMaterialUrl = Interop.NDalicMeshVisual.MeshVisualMaterialUrlGet();
        internal static readonly int MeshVisualTexturesPath = Interop.NDalicMeshVisual.MeshVisualTexturesPathGet();
        internal static readonly int MeshVisualShadingMode = Interop.NDalicMeshVisual.MeshVisualShadingModeGet();
        internal static readonly int MeshVisualUseMipmapping = Interop.NDalicMeshVisual.MeshVisualUseMipmappingGet();
        internal static readonly int MeshVisualUseSoftNormals = Interop.NDalicMeshVisual.MeshVisualUseSoftNormalsGet();
        internal static readonly int MeshVisualLightPosition = Interop.NDalicMeshVisual.MeshVisualLightPositionGet();

        internal static readonly int PrimitiveVisualShape = Interop.NdalicPrimitive.PrimitiveVisualShapeGet();
        internal static readonly int PrimitiveVisualMixColor = Interop.NdalicPrimitive.PrimitiveVisualMixColorGet();
        internal static readonly int PrimitiveVisualSlices = Interop.NdalicPrimitive.PrimitiveVisualSlicesGet();
        internal static readonly int PrimitiveVisualStacks = Interop.NdalicPrimitive.PrimitiveVisualStacksGet();
        internal static readonly int PrimitiveVisualScaleTopRadius = Interop.NdalicPrimitive.PrimitiveVisualScaleTopRadiusGet();
        internal static readonly int PrimitiveVisualScaleBottomRadius = Interop.NdalicPrimitive.PrimitiveVisualScaleBottomRadiusGet();
        internal static readonly int PrimitiveVisualScaleHeight = Interop.NdalicPrimitive.PrimitiveVisualScaleHeightGet();
        internal static readonly int PrimitiveVisualScaleRadius = Interop.NdalicPrimitive.PrimitiveVisualScaleRadiusGet();
        internal static readonly int PrimitiveVisualScaleDimensions = Interop.NdalicPrimitive.PrimitiveVisualScaleDimensionsGet();
        internal static readonly int PrimitiveVisualBevelPercentage = Interop.NdalicPrimitive.PrimitiveVisualBevelPercentageGet();
        internal static readonly int PrimitiveVisualBevelSmoothness = Interop.NdalicPrimitive.PrimitiveVisualBevelSmoothnessGet();
        internal static readonly int PrimitiveVisualLightPosition = Interop.NdalicPrimitive.PrimitiveVisualLightPositionGet();

        internal static readonly int TextVisualText = Interop.NDalicText.TextVisualTextGet();
        internal static readonly int TextVisualFontFamily = Interop.NDalicText.TextVisualFontFamilyGet();
        internal static readonly int TextVisualFontStyle = Interop.NDalicText.TextVisualFontStyleGet();
        internal static readonly int TextVisualPointSize = Interop.NDalicText.TextVisualPointSizeGet();
        internal static readonly int TextVisualMultiLine = Interop.NDalicText.TextVisualMultiLineGet();
        internal static readonly int TextVisualHorizontalAlignment = Interop.NDalicText.TextVisualHorizontalAlignmentGet();
        internal static readonly int TextVisualVerticalAlignment = Interop.NDalicText.TextVisualVerticalAlignmentGet();
        internal static readonly int TextVisualTextColor = Interop.NDalicText.TextVisualTextColorGet();
        internal static readonly int TextVisualEnableMarkup = Interop.NDalicText.TextVisualEnableMarkupGet();

        internal static readonly int TooltipContent = Interop.NDalicToolTip.TooltipContentGet();
        internal static readonly int TooltipLayout = Interop.NDalicToolTip.TooltipLayoutGet();
        internal static readonly int TooltipWaitTime = Interop.NDalicToolTip.TooltipWaitTimeGet();
        internal static readonly int TooltipBackground = Interop.NDalicToolTip.TooltipBackgroundGet();
        internal static readonly int TooltipTail = Interop.NDalicToolTip.TooltipTailGet();
        internal static readonly int TooltipPosition = Interop.NDalicToolTip.TooltipPositionGet();
        internal static readonly int TooltipHoverPointOffset = Interop.NDalicToolTip.TooltipHoverPointOffsetGet();
        internal static readonly int TooltipMovementThreshold = Interop.NDalicToolTip.TooltipMovementThresholdGet();
        internal static readonly int TooltipDisappearOnMovement = Interop.NDalicToolTip.TooltipDisappearOnMovementGet();

        internal static readonly int TooltipBackgroundVisual = Interop.NDalicToolTip.TooltipBackgroundVisualGet();
        internal static readonly int TooltipBackgroundBorder = Interop.NDalicToolTip.TooltipBackgroundBorderGet();

        internal static readonly int TooltipTailVisibility = Interop.NDalicToolTip.TooltipTailVisibilityGet();
        internal static readonly int TooltipTailAboveVisual = Interop.NDalicToolTip.TooltipTailAboveVisualGet();
        internal static readonly int TooltipTailBelowVisual = Interop.NDalicToolTip.TooltipTailBelowVisualGet();


        [Obsolete("This has been deprecated in API9 and will be removed in API11. Use ImageVisualUrl instead.")]
        internal static readonly int IMAGE_VISUAL_URL = Interop.NDalicImageVisual.ImageVisualUrlGet();
        [Obsolete("This has been deprecated in API9 and will be removed in API11. Use ImageVisualAlphaMaskUrl instead.")]
        internal static readonly int IMAGE_VISUAL_ALPHA_MASK_URL = Interop.NDalicImageVisual.ImageVisualAlphaMaskUrlGet();
        [Obsolete("This has been deprecated in API9 and will be removed in API11. Use ImageVisualAuxiliaryImageUrl instead.")]
        internal static readonly int IMAGE_VISUAL_AUXILIARY_IMAGE_URL = Interop.NDalicImageVisual.ImageVisualAuxiliaryImageUrlGet();
    }
}
