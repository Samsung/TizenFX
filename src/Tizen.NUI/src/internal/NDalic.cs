/*
 * Copyright(c) 2018 Samsung Electronics Co., Ltd.
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

using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{

    internal class NDalic
    {
        public static uint int_to_uint(int x)
        {
            uint ret = Interop.NDalic.int_to_uint(x);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }


        public static readonly int VISUAL_PROPERTY_TRANSFORM = Interop.Visual.Visual_Property_TRANSFORM_get();
        public static readonly int VISUAL_PROPERTY_PREMULTIPLIED_ALPHA = Interop.Visual.Visual_Property_PREMULTIPLIED_ALPHA_get();
        public static readonly int VISUAL_PROPERTY_MIX_COLOR = Interop.Visual.Visual_Property_MIX_COLOR_get();
        public static readonly int IMAGE_VISUAL_BORDER = Interop.Visual.Image_Visual_BORDER_get();

        public static void DaliAssertMessage(string location, string condition)
        {
            Interop.NDalic.DaliAssertMessage(location, condition);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public static Vector2 Min(Vector2 a, Vector2 b)
        {
            Vector2 ret = new Vector2(Interop.NDalic.Min__SWIG_0(Vector2.getCPtr(a), Vector2.getCPtr(b)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public static Vector2 Max(Vector2 a, Vector2 b)
        {
            Vector2 ret = new Vector2(Interop.NDalic.Max__SWIG_0(Vector2.getCPtr(a), Vector2.getCPtr(b)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public static Vector2 Clamp(Vector2 v, float min, float max)
        {
            Vector2 ret = new Vector2(Interop.NDalic.Clamp__SWIG_0(Vector2.getCPtr(v), min, max), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public static Vector3 Min(Vector3 a, Vector3 b)
        {
            Vector3 ret = new Vector3(Interop.NDalic.Min__SWIG_1(Vector3.getCPtr(a), Vector3.getCPtr(b)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public static Vector3 Max(Vector3 a, Vector3 b)
        {
            Vector3 ret = new Vector3(Interop.NDalic.Max__SWIG_1(Vector3.getCPtr(a), Vector3.getCPtr(b)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public static Vector3 Clamp(Vector3 v, float min, float max)
        {
            Vector3 ret = new Vector3(Interop.NDalic.Clamp__SWIG_1(Vector3.getCPtr(v), min, max), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public static Vector4 Min(Vector4 a, Vector4 b)
        {
            Vector4 ret = new Vector4(Interop.NDalic.Min__SWIG_2(Vector4.getCPtr(a), Vector4.getCPtr(b)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public static Vector4 Max(Vector4 a, Vector4 b)
        {
            Vector4 ret = new Vector4(Interop.NDalic.Max__SWIG_2(Vector4.getCPtr(a), Vector4.getCPtr(b)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public static Vector4 Clamp(Vector4 v, float min, float max)
        {
            Vector4 ret = new Vector4(Interop.NDalic.Clamp__SWIG_2(Vector4.getCPtr(v), min, max), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public static bool EqualTo(AngleAxis lhs, AngleAxis rhs)
        {
            bool ret = Interop.NDalic.EqualTo__SWIG_9(AngleAxis.getCPtr(lhs), AngleAxis.getCPtr(rhs));
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
            bool ret = Interop.NDalic.Equals__SWIG_0(a, b);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public static bool Equals(float a, float b, float epsilon)
        {
            bool ret = Interop.NDalic.Equals__SWIG_1(a, b, epsilon);
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
                int ret = Interop.NDalic.WEIGHT_get();
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

        public static float ParentOriginTop
        {
            get
            {
                float ret = Interop.NDalicParentOrigin.ParentOriginTop_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static float ParentOriginBottom
        {
            get
            {
                float ret = Interop.NDalicParentOrigin.ParentOriginBottom_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static float ParentOriginLeft
        {
            get
            {
                float ret = Interop.NDalicParentOrigin.ParentOriginLeft_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static float ParentOriginRight
        {
            get
            {
                float ret = Interop.NDalicParentOrigin.ParentOriginRight_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static float ParentOriginMiddle
        {
            get
            {
                float ret = Interop.NDalicParentOrigin.ParentOriginMiddle_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Vector3 ParentOriginTopLeft
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicParentOrigin.ParentOriginTopLeft_get();
                Vector3 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector3(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Vector3 ParentOriginTopCenter
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicParentOrigin.ParentOriginTopCenter_get();
                Vector3 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector3(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Vector3 ParentOriginTopRight
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicParentOrigin.ParentOriginTopRight_get();
                Vector3 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector3(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Vector3 ParentOriginCenterLeft
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicParentOrigin.ParentOriginCenterLeft_get();
                Vector3 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector3(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Vector3 ParentOriginCenter
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicParentOrigin.ParentOriginCenter_get();
                Vector3 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector3(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Vector3 ParentOriginCenterRight
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicParentOrigin.ParentOriginCenterRight_get();
                Vector3 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector3(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Vector3 ParentOriginBottomLeft
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicParentOrigin.ParentOriginBottomLeft_get();
                Vector3 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector3(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Vector3 ParentOriginBottomCenter
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicParentOrigin.ParentOriginBottomCenter_get();
                Vector3 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector3(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Vector3 ParentOriginBottomRight
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicParentOrigin.ParentOriginBottomRight_get();
                Vector3 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector3(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static float AnchorPointTop
        {
            get
            {
                float ret = Interop.NDalicAnchorPoint.AnchorPointTop_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static float AnchorPointBottom
        {
            get
            {
                float ret = Interop.NDalicAnchorPoint.AnchorPointBottom_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static float AnchorPointLeft
        {
            get
            {
                float ret = Interop.NDalicAnchorPoint.AnchorPointLeft_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static float AnchorPointRight
        {
            get
            {
                float ret = Interop.NDalicAnchorPoint.AnchorPointRight_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static float AnchorPointMiddle
        {
            get
            {
                float ret = Interop.NDalicAnchorPoint.AnchorPointMiddle_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Vector3 AnchorPointTopLeft
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicAnchorPoint.AnchorPointTopLeft_get();
                Vector3 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector3(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Vector3 AnchorPointTopCenter
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicAnchorPoint.AnchorPointTopCenter_get();
                Vector3 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector3(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Vector3 AnchorPointTopRight
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicAnchorPoint.AnchorPointTopRight_get();
                Vector3 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector3(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Vector3 AnchorPointCenterLeft
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicAnchorPoint.AnchorPointCenterLeft_get();
                Vector3 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector3(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Vector3 AnchorPointCenter
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicAnchorPoint.AnchorPointCenter_get();
                Vector3 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector3(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Vector3 AnchorPointCenterRight
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicAnchorPoint.AnchorPointCenterRight_get();
                Vector3 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector3(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Vector3 AnchorPointBottomLeft
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicAnchorPoint.AnchorPointBottomLeft_get();
                Vector3 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector3(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Vector3 AnchorPointBottomCenter
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicAnchorPoint.AnchorPointBottomCenter_get();
                Vector3 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector3(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Vector3 AnchorPointBottomRight
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicAnchorPoint.AnchorPointBottomRight_get();
                Vector3 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector3(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Vector4 BLACK
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.BLACK_get();
                Vector4 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector4(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Vector4 WHITE
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.WHITE_get();
                Vector4 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector4(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Vector4 RED
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.RED_get();
                Vector4 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector4(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Vector4 GREEN
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.GREEN_get();
                Vector4 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector4(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Vector4 BLUE
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.BLUE_get();
                Vector4 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector4(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Vector4 YELLOW
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.YELLOW_get();
                Vector4 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector4(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Vector4 MAGENTA
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.MAGENTA_get();
                Vector4 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector4(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Vector4 CYAN
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.CYAN_get();
                Vector4 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector4(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public static Vector4 TRANSPARENT
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicColor.TRANSPARENT_get();
                Vector4 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector4(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        internal static float MACHINE_EPSILON_0
        {
            get
            {
                float ret = Interop.NDalicMachine.MACHINE_EPSILON_0_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        internal static float MACHINE_EPSILON_1
        {
            get
            {
                float ret = Interop.NDalicMachine.MACHINE_EPSILON_1_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        internal static float MACHINE_EPSILON_10
        {
            get
            {
                float ret = Interop.NDalicMachine.MACHINE_EPSILON_10_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        internal static float MACHINE_EPSILON_100
        {
            get
            {
                float ret = Interop.NDalicMachine.MACHINE_EPSILON_100_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        internal static float MACHINE_EPSILON_1000
        {
            get
            {
                float ret = Interop.NDalicMachine.MACHINE_EPSILON_1000_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        internal static float MACHINE_EPSILON_10000
        {
            get
            {
                float ret = Interop.NDalicMachine.MACHINE_EPSILON_10000_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        internal static PixelFormat FIRST_VALID_PIXEL_FORMAT
        {
            get
            {
                PixelFormat ret = (PixelFormat)Interop.NDalic.FIRST_VALID_PIXEL_FORMAT_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        internal static PixelFormat LAST_VALID_PIXEL_FORMAT
        {
            get
            {
                PixelFormat ret = (PixelFormat)Interop.NDalic.LAST_VALID_PIXEL_FORMAT_get();
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
                uint ret = Interop.NDalicXYZ.POSITIVE_X_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        internal static uint NEGATIVE_X
        {
            get
            {
                uint ret = Interop.NDalicXYZ.NEGATIVE_X_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        internal static uint POSITIVE_Y
        {
            get
            {
                uint ret = Interop.NDalicXYZ.POSITIVE_Y_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        internal static uint NEGATIVE_Y
        {
            get
            {
                uint ret = Interop.NDalicXYZ.NEGATIVE_Y_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        internal static uint POSITIVE_Z
        {
            get
            {
                uint ret = Interop.NDalicXYZ.POSITIVE_Z_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        internal static uint NEGATIVE_Z
        {
            get
            {
                uint ret = Interop.NDalicXYZ.NEGATIVE_Z_get();
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
            ViewImpl ret = new ViewImpl(Interop.NDalic.GetImplementation__SWIG_0(View.getCPtr(handle)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static SWIGTYPE_p_Dali__IntrusivePtrT_Dali__Toolkit__ItemLayout_t NewItemLayout(DefaultItemLayoutType type)
        {
            SWIGTYPE_p_Dali__IntrusivePtrT_Dali__Toolkit__ItemLayout_t ret = new SWIGTYPE_p_Dali__IntrusivePtrT_Dali__Toolkit__ItemLayout_t(Interop.NDalic.NewItemLayout((int)type), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static void SetCustomAlgorithm(SWIGTYPE_p_KeyboardFocusManager keyboardFocusManager, CustomAlgorithmInterface arg1)
        {
            Interop.NDalic.SetCustomAlgorithm(SWIGTYPE_p_KeyboardFocusManager.getCPtr(keyboardFocusManager), CustomAlgorithmInterface.getCPtr(arg1));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal static readonly int VISUAL_PROPERTY_TYPE = Interop.NDalicVisual.VISUAL_PROPERTY_TYPE_get();
        internal static readonly int VISUAL_PROPERTY_SHADER = Interop.NDalicVisual.VISUAL_PROPERTY_SHADER_get();

        internal static readonly int VISUAL_SHADER_VERTEX = Interop.NDalicVisual.VISUAL_SHADER_VERTEX_get();
        internal static readonly int VISUAL_SHADER_FRAGMENT = Interop.NDalicVisual.VISUAL_SHADER_FRAGMENT_get();
        internal static readonly int VISUAL_SHADER_SUBDIVIDE_GRID_X = Interop.NDalicVisual.VISUAL_SHADER_SUBDIVIDE_GRID_X_get();
        internal static readonly int VISUAL_SHADER_SUBDIVIDE_GRID_Y = Interop.NDalicVisual.VISUAL_SHADER_SUBDIVIDE_GRID_Y_get();
        internal static readonly int VISUAL_SHADER_HINTS = Interop.NDalicVisual.VISUAL_SHADER_HINTS_get();

        internal static readonly int BORDER_VISUAL_COLOR = Interop.NDalicBorderVisual.BORDER_VISUAL_COLOR_get();
        internal static readonly int BORDER_VISUAL_SIZE = Interop.NDalicBorderVisual.BORDER_VISUAL_SIZE_get();
        internal static readonly int BORDER_VISUAL_ANTI_ALIASING = Interop.NDalicBorderVisual.BORDER_VISUAL_ANTI_ALIASING_get();

        internal static readonly int COLOR_VISUAL_MIX_COLOR = Interop.NDalicColorVisual.COLOR_VISUAL_MIX_COLOR_get();

        internal static readonly int GRADIENT_VISUAL_START_POSITION = Interop.NDalicGradientVisual.GRADIENT_VISUAL_START_POSITION_get();
        internal static readonly int GRADIENT_VISUAL_END_POSITION = Interop.NDalicGradientVisual.GRADIENT_VISUAL_END_POSITION_get();
        internal static readonly int GRADIENT_VISUAL_CENTER = Interop.NDalicGradientVisual.GRADIENT_VISUAL_CENTER_get();
        internal static readonly int GRADIENT_VISUAL_RADIUS = Interop.NDalicGradientVisual.GRADIENT_VISUAL_RADIUS_get();
        internal static readonly int GRADIENT_VISUAL_STOP_OFFSET = Interop.NDalicGradientVisual.GRADIENT_VISUAL_STOP_OFFSET_get();
        internal static readonly int GRADIENT_VISUAL_STOP_COLOR = Interop.NDalicGradientVisual.GRADIENT_VISUAL_STOP_COLOR_get();
        internal static readonly int GRADIENT_VISUAL_UNITS = Interop.NDalicGradientVisual.GRADIENT_VISUAL_UNITS_get();
        internal static readonly int GRADIENT_VISUAL_SPREAD_METHOD = Interop.NDalicGradientVisual.GRADIENT_VISUAL_SPREAD_METHOD_get();

        internal static readonly int IMAGE_VISUAL_URL = Interop.NDalicImageVisual.IMAGE_VISUAL_URL_get();
        internal static readonly int IMAGE_VISUAL_ALPHA_MASK_URL = Interop.NDalicImageVisual.IMAGE_VISUAL_ALPHA_MASK_URL_get();
        internal static readonly int IMAGE_VISUAL_FITTING_MODE = Interop.NDalicImageVisual.IMAGE_VISUAL_FITTING_MODE_get();
        internal static readonly int IMAGE_VISUAL_SAMPLING_MODE = Interop.NDalicImageVisual.IMAGE_VISUAL_SAMPLING_MODE_get();
        internal static readonly int IMAGE_VISUAL_DESIRED_WIDTH = Interop.NDalicImageVisual.IMAGE_VISUAL_DESIRED_WIDTH_get();
        internal static readonly int IMAGE_VISUAL_DESIRED_HEIGHT = Interop.NDalicImageVisual.IMAGE_VISUAL_DESIRED_HEIGHT_get();
        internal static readonly int IMAGE_VISUAL_SYNCHRONOUS_LOADING = Interop.NDalicImageVisual.IMAGE_VISUAL_SYNCHRONOUS_LOADING_get();
        internal static readonly int IMAGE_VISUAL_BORDER_ONLY = Interop.NDalicImageVisual.IMAGE_VISUAL_BORDER_ONLY_get();
        internal static readonly int IMAGE_VISUAL_PIXEL_AREA = Interop.NDalicImageVisual.IMAGE_VISUAL_PIXEL_AREA_get();
        internal static readonly int IMAGE_VISUAL_WRAP_MODE_U = Interop.NDalicImageVisual.IMAGE_VISUAL_WRAP_MODE_U_get();
        internal static readonly int IMAGE_VISUAL_WRAP_MODE_V = Interop.NDalicImageVisual.IMAGE_VISUAL_WRAP_MODE_V_get();
        internal static readonly int IMAGE_VISUAL_BATCH_SIZE = Interop.NDalicImageVisual.IMAGE_VISUAL_BATCH_SIZE_get();
        internal static readonly int IMAGE_VISUAL_CACHE_SIZE = Interop.NDalicImageVisual.IMAGE_VISUAL_CACHE_SIZE_get();
        internal static readonly int IMAGE_VISUAL_FRAME_DELAY = Interop.NDalicImageVisual.IMAGE_VISUAL_FRAME_DELAY_get();
        internal static readonly int IMAGE_VISUAL_LOOP_COUNT = Interop.NDalicImageVisual.IMAGE_VISUAL_LOOP_COUNT_get();
        internal static readonly int IMAGE_VISUAL_MASK_CONTENT_SCALE = Interop.NDalicImageVisual.IMAGE_VISUAL_MASK_CONTENT_SCALE_get();
        internal static readonly int IMAGE_VISUAL_CROP_TO_MASK = Interop.NDalicImageVisual.IMAGE_VISUAL_CROP_TO_MASK_get();
        internal static readonly int IMAGE_VISUAL_RELEASE_POLICY = Interop.NDalicImageVisual.IMAGE_VISUAL_RELEASE_POLICY_get();
        internal static readonly int IMAGE_VISUAL_LOAD_POLICY = Interop.NDalicImageVisual.IMAGE_VISUAL_LOAD_POLICY_get();
        internal static readonly int IMAGE_VISUAL_ORIENTATION_CORRECTION = Interop.NDalicImageVisual.IMAGE_VISUAL_ORIENTATION_CORRECTION_get();
        internal static readonly int IMAGE_VISUAL_AUXILIARY_IMAGE_URL = Interop.NDalicImageVisual.IMAGE_VISUAL_AUXILIARY_IMAGE_URL_get();
        internal static readonly int IMAGE_VISUAL_AUXILIARY_IMAGE_ALPHA = Interop.NDalicImageVisual.IMAGE_VISUAL_AUXILIARY_IMAGE_ALPHA_get();

        internal static readonly int MESH_VISUAL_OBJECT_URL = Interop.NDalicMeshVisual.MESH_VISUAL_OBJECT_URL_get();
        internal static readonly int MESH_VISUAL_MATERIAL_URL = Interop.NDalicMeshVisual.MESH_VISUAL_MATERIAL_URL_get();
        internal static readonly int MESH_VISUAL_TEXTURES_PATH = Interop.NDalicMeshVisual.MESH_VISUAL_TEXTURES_PATH_get();
        internal static readonly int MESH_VISUAL_SHADING_MODE = Interop.NDalicMeshVisual.MESH_VISUAL_SHADING_MODE_get();
        internal static readonly int MESH_VISUAL_USE_MIPMAPPING = Interop.NDalicMeshVisual.MESH_VISUAL_USE_MIPMAPPING_get();
        internal static readonly int MESH_VISUAL_USE_SOFT_NORMALS = Interop.NDalicMeshVisual.MESH_VISUAL_USE_SOFT_NORMALS_get();
        internal static readonly int MESH_VISUAL_LIGHT_POSITION = Interop.NDalicMeshVisual.MESH_VISUAL_LIGHT_POSITION_get();

        internal static readonly int PRIMITIVE_VISUAL_SHAPE = Interop.NdalicPrimitive.PRIMITIVE_VISUAL_SHAPE_get();
        internal static readonly int PRIMITIVE_VISUAL_MIX_COLOR = Interop.NdalicPrimitive.PRIMITIVE_VISUAL_MIX_COLOR_get();
        internal static readonly int PRIMITIVE_VISUAL_SLICES = Interop.NdalicPrimitive.PRIMITIVE_VISUAL_SLICES_get();
        internal static readonly int PRIMITIVE_VISUAL_STACKS = Interop.NdalicPrimitive.PRIMITIVE_VISUAL_STACKS_get();
        internal static readonly int PRIMITIVE_VISUAL_SCALE_TOP_RADIUS = Interop.NdalicPrimitive.PRIMITIVE_VISUAL_SCALE_TOP_RADIUS_get();
        internal static readonly int PRIMITIVE_VISUAL_SCALE_BOTTOM_RADIUS = Interop.NdalicPrimitive.PRIMITIVE_VISUAL_SCALE_BOTTOM_RADIUS_get();
        internal static readonly int PRIMITIVE_VISUAL_SCALE_HEIGHT = Interop.NdalicPrimitive.PRIMITIVE_VISUAL_SCALE_HEIGHT_get();
        internal static readonly int PRIMITIVE_VISUAL_SCALE_RADIUS = Interop.NdalicPrimitive.PRIMITIVE_VISUAL_SCALE_RADIUS_get();
        internal static readonly int PRIMITIVE_VISUAL_SCALE_DIMENSIONS = Interop.NdalicPrimitive.PRIMITIVE_VISUAL_SCALE_DIMENSIONS_get();
        internal static readonly int PRIMITIVE_VISUAL_BEVEL_PERCENTAGE = Interop.NdalicPrimitive.PRIMITIVE_VISUAL_BEVEL_PERCENTAGE_get();
        internal static readonly int PRIMITIVE_VISUAL_BEVEL_SMOOTHNESS = Interop.NdalicPrimitive.PRIMITIVE_VISUAL_BEVEL_SMOOTHNESS_get();
        internal static readonly int PRIMITIVE_VISUAL_LIGHT_POSITION = Interop.NdalicPrimitive.PRIMITIVE_VISUAL_LIGHT_POSITION_get();

        internal static readonly int TEXT_VISUAL_TEXT = Interop.NDalicText.TEXT_VISUAL_TEXT_get();
        internal static readonly int TEXT_VISUAL_FONT_FAMILY = Interop.NDalicText.TEXT_VISUAL_FONT_FAMILY_get();
        internal static readonly int TEXT_VISUAL_FONT_STYLE = Interop.NDalicText.TEXT_VISUAL_FONT_STYLE_get();
        internal static readonly int TEXT_VISUAL_POINT_SIZE = Interop.NDalicText.TEXT_VISUAL_POINT_SIZE_get();
        internal static readonly int TEXT_VISUAL_MULTI_LINE = Interop.NDalicText.TEXT_VISUAL_MULTI_LINE_get();
        internal static readonly int TEXT_VISUAL_HORIZONTAL_ALIGNMENT = Interop.NDalicText.TEXT_VISUAL_HORIZONTAL_ALIGNMENT_get();
        internal static readonly int TEXT_VISUAL_VERTICAL_ALIGNMENT = Interop.NDalicText.TEXT_VISUAL_VERTICAL_ALIGNMENT_get();
        internal static readonly int TEXT_VISUAL_TEXT_COLOR = Interop.NDalicText.TEXT_VISUAL_TEXT_COLOR_get();
        internal static readonly int TEXT_VISUAL_ENABLE_MARKUP = Interop.NDalicText.TEXT_VISUAL_ENABLE_MARKUP_get();

        internal static readonly int TOOLTIP_CONTENT = Interop.NDalicToolTip.TOOLTIP_CONTENT_get();
        internal static readonly int TOOLTIP_LAYOUT = Interop.NDalicToolTip.TOOLTIP_LAYOUT_get();
        internal static readonly int TOOLTIP_WAIT_TIME = Interop.NDalicToolTip.TOOLTIP_WAIT_TIME_get();
        internal static readonly int TOOLTIP_BACKGROUND = Interop.NDalicToolTip.TOOLTIP_BACKGROUND_get();
        internal static readonly int TOOLTIP_TAIL = Interop.NDalicToolTip.TOOLTIP_TAIL_get();
        internal static readonly int TOOLTIP_POSITION = Interop.NDalicToolTip.TOOLTIP_POSITION_get();
        internal static readonly int TOOLTIP_HOVER_POINT_OFFSET = Interop.NDalicToolTip.TOOLTIP_HOVER_POINT_OFFSET_get();
        internal static readonly int TOOLTIP_MOVEMENT_THRESHOLD = Interop.NDalicToolTip.TOOLTIP_MOVEMENT_THRESHOLD_get();
        internal static readonly int TOOLTIP_DISAPPEAR_ON_MOVEMENT = Interop.NDalicToolTip.TOOLTIP_DISAPPEAR_ON_MOVEMENT_get();

        internal static readonly int TOOLTIP_BACKGROUND_VISUAL = Interop.NDalicToolTip.TOOLTIP_BACKGROUND_VISUAL_get();
        internal static readonly int TOOLTIP_BACKGROUND_BORDER = Interop.NDalicToolTip.TOOLTIP_BACKGROUND_BORDER_get();

        internal static readonly int TOOLTIP_TAIL_VISIBILITY = Interop.NDalicToolTip.TOOLTIP_TAIL_VISIBILITY_get();
        internal static readonly int TOOLTIP_TAIL_ABOVE_VISUAL = Interop.NDalicToolTip.TOOLTIP_TAIL_ABOVE_VISUAL_get();
        internal static readonly int TOOLTIP_TAIL_BELOW_VISUAL = Interop.NDalicToolTip.TOOLTIP_TAIL_BELOW_VISUAL_get();

    }

}
