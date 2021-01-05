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

        public static Vector4 BLACK
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.BlackGet();
                Vector4 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector4(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Vector4 WHITE
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.WhiteGet();
                Vector4 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector4(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Vector4 RED
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.RedGet();
                Vector4 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector4(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Vector4 GREEN
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.GreenGet();
                Vector4 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector4(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Vector4 BLUE
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.BlueGet();
                Vector4 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector4(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Vector4 YELLOW
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.YellowGet();
                Vector4 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector4(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Vector4 MAGENTA
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.MagentaGet();
                Vector4 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector4(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Vector4 CYAN
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.CyanGet();
                Vector4 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector4(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Vector4 TRANSPARENT
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.TransparentGet();
                Vector4 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector4(cPtr, false);
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


        [Obsolete("Please do not use this! Deprecated in API9, will be removed in API11! Please use ImageVisualUrl instead!")]
        internal static readonly int IMAGE_VISUAL_URL = Interop.NDalicImageVisual.ImageVisualUrlGet();
        [Obsolete("Please do not use this! Deprecated in API9, will be removed in API11! Please use ImageVisualAlphaMaskUrl instead!")]
        internal static readonly int IMAGE_VISUAL_ALPHA_MASK_URL = Interop.NDalicImageVisual.ImageVisualAlphaMaskUrlGet();
        [Obsolete("Please do not use this! Deprecated in API9, will be removed in API11! Please use ImageVisualAuxiliaryImageUrl instead!")]
        internal static readonly int IMAGE_VISUAL_AUXILIARY_IMAGE_URL = Interop.NDalicImageVisual.ImageVisualAuxiliaryImageUrlGet();
    }
}
