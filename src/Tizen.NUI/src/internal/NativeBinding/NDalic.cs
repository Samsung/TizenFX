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

        public static Color ALICE_BLUE
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.AliceBlueGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color ANTIQUE_WHITE
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.AntiqueWhiteGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color AQUA
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.AquaGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color AQUA_MARINE
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.AquaMarineGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color AZURE
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.AzureGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color BEIGE
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.BeigeGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color BISQUE
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.BisqueGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color BLACK
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.BlackGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color BLANCHE_DALMOND
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.BlancheDalmondGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color BLUE
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.BlueGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color BLUE_VIOLET
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.BlueVioletGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color BROWN
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.BrownGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color BURLY_WOOD
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.BurlyWoodGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color CADET_BLUE
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.CadetBlueGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color CHARTREUSE
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.ChartreuseGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color CHOCOLATE
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.ChocolateGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color CORAL
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.CoralGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color CORNFLOWER_BLUE
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.CornflowerBlueGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color CORNSILK
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.CornsilkGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color CRIMSON
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.CrimsonGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color CYAN
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.CyanGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color DARK_BLUE
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.DarkBlueGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color DARK_CYAN
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.DarkCyanGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color DARK_GOLDENROD
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.DarkGoldenrodGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color DARK_GRAY
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.DarkGrayGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color DARK_GREEN
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.DarkGreenGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color DARK_GREY
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.DarkGreyGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color DARK_KHAKI
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.DarkKhakiGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color DARK_MAGENTA
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.DarkMagentaGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color DARK_OLIVE_GREEN
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.DarkOliveGreenGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color DARK_ORANGE
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.DarkOrangeGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color DARK_ORCHID
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.DarkOrchidGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color DARK_RED
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.DarkRedGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color DARK_SALMON
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.DarkSalmonGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color DARK_SEA_GREEN
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.DarkSeaGreenGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color DARK_SLATE_BLUE
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.DarkSlateBlueGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color DARK_SLATE_GRAY
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.DarkSlateGrayGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color DARK_SLATE_GREY
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.DarkSlateGreyGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color DARK_TURQUOISE
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.DarkTurquoiseGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color DARK_VIOLET
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.DarkVioletGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color DEEP_PINK
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.DeepPinkGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color DEEP_SKY_BLUE
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.DeepSkyBlueGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color DIM_GRAY
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.DimGrayGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color DIM_GREY
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.DimGreyGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color DODGER_BLUE
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.DodgerBlueGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color FIRE_BRICK
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.FireBrickGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color FLORAL_WHITE
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.FloralWhiteGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color FOREST_GREEN
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.ForestGreenGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color FUCHSIA
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.FuchsiaGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color GAINSBORO
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.GainsboroGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color GHOST_WHITE
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.GhostWhiteGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color GOLD
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.GoldGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color GOLDEN_ROD
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.GoldenRodGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color GRAY
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.GrayGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color GREEN
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.GreenGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color GREEN_YELLOW
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.GreenYellowGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color GREY
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.GreyGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color HONEYDEW
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.HoneydewGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color HOT_PINK
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.HotPinkGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color INDIANRED
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.IndianredGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color INDIGO
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.IndigoGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color IVORY
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.IvoryGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color KHAKI
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.KhakiGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color LAVENDER
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.LavenderGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color LAVENDER_BLUSH
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.LavenderBlushGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color LAWN_GREEN
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.LawnGreenGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color LEMON_CHIFFON
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.LemonChiffonGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color LIGHT_BLUE
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.LightBlueGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color LIGHT_CORAL
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.LightCoralGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color LIGHT_CYAN
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.LightCyanGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color LIGHT_GOLDEN_ROD_YELLOW
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.LightGoldenRodYellowGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color LIGHT_GRAY
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.LightGrayGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color LIGHT_GREEN
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.LightGreenGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color LIGHT_GREY
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.LightGreyGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color LIGHT_PINK
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.LightPinkGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color LIGHT_SALMON
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.LightSalmonGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color LIGHT_SEA_GREEN
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.LightSeaGreenGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color LIGHT_SKY_BLUE
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.LightSkyBlueGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color LIGHT_SLATE_GRAY
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.LightSlateGrayGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color LIGHT_SLATE_GREY
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.LightSlateGreyGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color LIGHT_STEEL_BLUE
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.LightSteelBlueGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color LIGHT_YELLOW
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.LightYellowGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color LIME
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.LimeGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color LIME_GREEN
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.LimeGreenGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color LINEN
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.LinenGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color MAGENTA
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.MagentaGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color MAROON
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.MaroonGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color MEDIUM_AQUA_MARINE
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.MediumAquaMarineGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color MEDIUM_BLUE
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.MediumBlueGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color MEDIUM_ORCHID
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.MediumOrchidGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color MEDIUM_PURPLE
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.MediumPurpleGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color MEDIUM_SEA_GREEN
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.MediumSeaGreenGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color MEDIUM_SLATE_BLUE
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.MediumSlateBlueGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color MEDIUM_SPRING_GREEN
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.MediumSpringGreenGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color MEDIUM_TURQUOISE
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.MediumTurquoiseGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color MEDIUM_VIOLETRED
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.MediumVioletredGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color MIDNIGHT_BLUE
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.MidnightBlueGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color MINT_CREAM
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.MintCreamGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color MISTY_ROSE
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.MistyRoseGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color MOCCASIN
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.MoccasinGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color NAVAJO_WHITE
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.NavajoWhiteGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color NAVY
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.NavyGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color OLD_LACE
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.OldLaceGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color OLIVE
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.OliveGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color OLIVE_DRAB
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.OliveDrabGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color ORANGE
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.OrangeGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color ORANGE_RED
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.OrangeRedGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color ORCHID
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.OrchidGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color PALE_GOLDEN_ROD
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.PaleGoldenRodGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color PALE_GREEN
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.PaleGreenGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color PALE_TURQUOISE
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.PaleTurquoiseGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color PALE_VIOLET_RED
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.PaleVioletRedGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color PAPAYA_WHIP
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.PapayaWhipGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color PEACH_PUFF
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.PeachPuffGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color PERU
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.PeruGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color PINK
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.PinkGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color PLUM
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.PlumGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color POWDER_BLUE
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.PowderBlueGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color PURPLE
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.PurpleGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color RED
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.RedGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color ROSY_BROWN
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.RosyBrownGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color ROYAL_BLUE
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.RoyalBlueGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color SADDLE_BROWN
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.SaddleBrownGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color SALMON
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.SalmonGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color SANDY_BROWN
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.SandyBrownGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color SEA_GREEN
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.SeaGreenGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color SEA_SHELL
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.SeaShellGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color SIENNA
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.SiennaGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color SILVER
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.SilverGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color SKY_BLUE
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.SkyBlueGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color SLATE_BLUE
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.SlateBlueGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color SLATE_GRAY
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.SlateGrayGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color SLATE_GREY
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.SlateGreyGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color SNOW
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.SnowGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color SPRING_GREEN
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.SpringGreenGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color STEEL_BLUE
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.SteelBlueGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color TAN
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.TanGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color TEAL
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.TealGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color THISTLE
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.ThistleGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color TOMATO
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.TomatoGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color TRANSPARENT
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.TransparentGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color TURQUOISE
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.TurquoiseGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color VIOLET
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.VioletGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color WHEAT
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.WheatGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color WHITE
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.WhiteGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color WHITE_SMOKE
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.WhiteSmokeGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color YELLOW
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.YellowGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Color YELLOW_GREEN
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.YellowGreenGet();
                Color ret = (cPtr == global::System.IntPtr.Zero) ? null : new Color(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
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
                //this originates to FIRST_VALID_PIXEL_FORMAT = A8
                return PixelFormat.A8;
            }
        }

        internal static PixelFormat LAST_VALID_PIXEL_FORMAT
        {
            get
            {
                //this originates to LAST_VALID_PIXEL_FORMAT = CHROMINANCE_V
                return (PixelFormat)62;
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
                //this originates to Dali::CubeMapLayer::POSITIVE_X = 0u
                return 0;
            }
        }

        internal static uint NEGATIVE_X
        {
            get
            {
                //this originates to Dali::CubeMapLayer::NEGATIVE_X = 1u
                return 1;
            }
        }

        internal static uint POSITIVE_Y
        {
            get
            {
                //this originates to Dali::CubeMapLayer::POSITIVE_Y = 2u
                return 2;
            }
        }

        internal static uint NEGATIVE_Y
        {
            get
            {
                //this originates to Dali::CubeMapLayer::NEGATIVE_Y = 3u
                return 3;
            }
        }

        internal static uint POSITIVE_Z
        {
            get
            {
                //this originates to Dali::CubeMapLayer::POSITIVE_Z = 4u
                return 4;
            }
        }

        internal static uint NEGATIVE_Z
        {
            get
            {
                //this originates to Dali::CubeMapLayer::NEGATIVE_Z = 5u
                return 5;
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
