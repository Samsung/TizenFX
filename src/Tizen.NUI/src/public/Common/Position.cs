/*
 * Copyright (c) 2021 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.Binding;
using System.ComponentModel;

namespace Tizen.NUI
{

    /// <summary>
    /// Position is a three-dimensional vector.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [Tizen.NUI.Binding.TypeConverter(typeof(PositionTypeConverter))]
    public class Position : Disposable, ICloneable
    {

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <remarks>
        /// Position2D and Position are implicitly converted to each other, so these are compatible and can be replaced without any type casting. <br />
        /// For example, the followings are possible. <br />
        /// view.Position2D = new Position(10.0f, 10.0f, 10.0f); // be aware that here the z value(10.0f) will be lost. <br />
        /// view.Position = new Position2D(10, 10); // be aware that here the z value is 0.0f by default. <br />
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public Position() : this(Interop.Vector3.NewVector3(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="x">The x component.</param>
        /// <param name="y">The y component.</param>
        /// <param name="z">The z component(optional).</param>
        /// <remarks>
        /// Position2D and Position are implicitly converted to each other, so these are compatible and can be replaced without any type casting. <br />
        /// For example, the followings are possible. <br />
        /// view.Position2D = new Position(10.0f, 10.0f, 10.0f); // be aware that here the z value(10.0f) will be lost. <br />
        /// view.Position = new Position2D(10, 10); // be aware that here the z value is 0.0f by default. <br />
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public Position(float x, float y, float z = 0.0f) : this(Interop.Vector3.NewVector3(x, y, z), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="position2d">Position2D to create this vector from.</param>
        /// <since_tizen> 3 </since_tizen>
        public Position(Position2D position2d) : this(Interop.Vector3.NewVector3WithVector2(Position2D.getCPtr(position2d)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Position(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// ParentOrigin constants. It's 0.0.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static float ParentOriginTop
        {
            get
            {
                float ret = Interop.NDalicParentOrigin.ParentOriginTopGet();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// ParentOrigin constants. It's 1.0.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static float ParentOriginBottom
        {
            get
            {
                float ret = Interop.NDalicParentOrigin.ParentOriginBottomGet();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// ParentOrigin constants. It's 0.0.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static float ParentOriginLeft
        {
            get
            {
                float ret = Interop.NDalicParentOrigin.ParentOriginLeftGet();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// ParentOrigin constants. It's 1.0.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static float ParentOriginRight
        {
            get
            {
                float ret = Interop.NDalicParentOrigin.ParentOriginRightGet();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// ParentOrigin constants. It's 0.5.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static float ParentOriginMiddle
        {
            get
            {
                float ret = Interop.NDalicParentOrigin.ParentOriginMiddleGet();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// ParentOrigin constants: 0.0, 0.0, 0.5.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position ParentOriginTopLeft
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicParentOrigin.ParentOriginTopLeftGet();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// ParentOrigin constants: 0.5, 0.0, 0.5.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position ParentOriginTopCenter
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicParentOrigin.ParentOriginTopCenterGet();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// ParentOrigin constants: 1.0, 0.0, 0.5.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position ParentOriginTopRight
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicParentOrigin.ParentOriginTopRightGet();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// ParentOrigin constants: 0.0, 0.5, 0.5.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position ParentOriginCenterLeft
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicParentOrigin.ParentOriginCenterLeftGet();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// ParentOrigin constants: 0.0, 0.5, 0.5
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position ParentOriginCenter
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicParentOrigin.ParentOriginCenterGet();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// ParentOrigin constants: 1.0, 0.5, 0.5.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position ParentOriginCenterRight
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicParentOrigin.ParentOriginCenterRightGet();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// ParentOrigin constants: 0.0f, 1.0f, 0.5f.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position ParentOriginBottomLeft
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicParentOrigin.ParentOriginBottomLeftGet();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// ParentOrigin constants: 0.5, 1.0, 0.5.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position ParentOriginBottomCenter
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicParentOrigin.ParentOriginBottomCenterGet();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// ParentOrigin constants: 1.0, 1.0, 0.5.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position ParentOriginBottomRight
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicParentOrigin.ParentOriginBottomRightGet();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// PivotPoint constants: 0.0.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static float PivotPointTop
        {
            get
            {
                float ret = Interop.NDalicAnchorPoint.AnchorPointTopGet();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// PivotPoint constants: 1.0.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static float PivotPointBottom
        {
            get
            {
                float ret = Interop.NDalicAnchorPoint.AnchorPointBottomGet();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// PivotPoint constants: 0.0.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static float PivotPointLeft
        {
            get
            {
                float ret = Interop.NDalicAnchorPoint.AnchorPointLeftGet();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// PivotPoint constants: 1.0.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static float PivotPointRight
        {
            get
            {
                float ret = Interop.NDalicAnchorPoint.AnchorPointRightGet();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// PivotPoint constants: 0.5.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static float PivotPointMiddle
        {
            get
            {
                float ret = Interop.NDalicAnchorPoint.AnchorPointMiddleGet();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// PivotPoint constants: 0.0, 0.0, 0.5.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position PivotPointTopLeft
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicAnchorPoint.AnchorPointTopLeftGet();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// PivotPoint constants: 0.5, 0.0, 0.5.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position PivotPointTopCenter
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicAnchorPoint.AnchorPointTopCenterGet();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// PivotPoint constants: 1.0, 0.0, 0.5.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position PivotPointTopRight
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicAnchorPoint.AnchorPointTopRightGet();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// PivotPoint constants: 0.0, 0.5, 0.5.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position PivotPointCenterLeft
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicAnchorPoint.AnchorPointCenterLeftGet();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// PivotPoint constants: 0.5, 0.5, 0.5.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position PivotPointCenter
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicAnchorPoint.AnchorPointCenterGet();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// PivotPoint constants: 1.0, 0.5, 0.5.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position PivotPointCenterRight
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicAnchorPoint.AnchorPointCenterRightGet();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// PivotPoint constants: 0.0, 1.0, 0.5.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position PivotPointBottomLeft
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicAnchorPoint.AnchorPointBottomLeftGet();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// PivotPoint constants: 0.5, 1.0, 0.5
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position PivotPointBottomCenter
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicAnchorPoint.AnchorPointBottomCenterGet();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// PivotPoint constants: 1.0, 1.0, 0.5.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position PivotPointBottomRight
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicAnchorPoint.AnchorPointBottomRightGet();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// Constant ( 1.0f, 1.0f, 1.0f ).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position One
        {
            get
            {
                global::System.IntPtr cPtr = Interop.Vector3.OneGet();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// Constant ( 0.0f, 0.0f, 0.0f ).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position Zero
        {
            get
            {
                global::System.IntPtr cPtr = Interop.Vector3.ZeroGet();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// The x component.
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Please use new Position(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use like the followings!
        /// Position position = new Position();
        /// position.X = 1.0f; 
        /// // Please USE like this
        /// float x = 1.0f, y = 2.0f, z = 3.0f;
        /// Position position = new Position(x, y, z);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public float X
        {
            [Obsolete("Please do not use this setter, Deprecated in API8, will be removed in API10. please use new Position(...) constructor")]
            set
            {
                Interop.Vector3.XSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                callback?.Invoke(X, Y, Z);
            }
            get
            {
                float ret = Interop.Vector3.XGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// The y component.
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Please use new Position(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use like the followings!
        /// Position position = new Position();
        /// position.Y = 2.0f; 
        /// // Please USE like this
        /// float x = 1.0f, y = 2.0f, z = 3.0f;
        /// Position position = new Position(x, y, z);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public float Y
        {
            [Obsolete("Please do not use this setter, Deprecated in API8, will be removed in API10. please use new Position(...) constructor")]
            set
            {
                Interop.Vector3.YSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                callback?.Invoke(X, Y, Z);
            }
            get
            {
                float ret = Interop.Vector3.YGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// The z component.
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Please use new Position(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use like the followings!
        /// Position position = new Position();
        /// position.Z = 3.0f; 
        /// // Please USE like this
        /// float x = 1.0f, y = 2.0f, z = 3.0f;
        /// Position position = new Position(x, y, z);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public float Z
        {
            [Obsolete("Please do not use this setter, Deprecated in API8, will be removed in API10. please use new Position(...) constructor")]
            set
            {
                Interop.Vector3.ZSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                callback?.Invoke(X, Y, Z);
            }
            get
            {
                float ret = Interop.Vector3.ZGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        internal static Position XAxis
        {
            get
            {
                global::System.IntPtr cPtr = Interop.Vector3.XaxisGet();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        internal static Position YAxis
        {
            get
            {
                global::System.IntPtr cPtr = Interop.Vector3.YaxisGet();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        internal static Position ZAxis
        {
            get
            {
                global::System.IntPtr cPtr = Interop.Vector3.ZaxisGet();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        internal static Position NegativeXAxis
        {
            get
            {
                global::System.IntPtr cPtr = Interop.Vector3.NegativeXaxisGet();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        internal static Position NegativeYAxis
        {
            get
            {
                global::System.IntPtr cPtr = Interop.Vector3.NegativeYaxisGet();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        internal static Position NegativeZAxis
        {
            get
            {
                global::System.IntPtr cPtr = Interop.Vector3.NegativeZaxisGet();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// The const array subscript operator overload. Should be 0, 1, or 2.
        /// </summary>
        /// <param name="index">The subscript index.</param>
        /// <returns>The float at the given index.</returns>
        /// <since_tizen> 3 </since_tizen>
        public float this[uint index]
        {
            get
            {
                return ValueOfIndex(index);
            }
        }


        /// <summary>
        /// An addition operator.
        /// </summary>
        /// <param name="arg1">The vector to add.</param>
        /// <param name="arg2">The vector to add.</param>
        /// <returns>The vector containing the result of the addition.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Position operator +(Position arg1, Position arg2)
        {
            return arg1?.Add(arg2);
        }

        /// <summary>
        /// The subtraction operator.
        /// </summary>
        /// <param name="arg1">The vector to subtract.</param>
        /// <param name="arg2">The vector to subtract.</param>
        /// <returns>The vector containing the result of the subtraction.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Position operator -(Position arg1, Position arg2)
        {
            return arg1?.Subtract(arg2);
        }

        /// <summary>
        /// The unary negation operator.
        /// </summary>
        /// <param name="arg1">The vector to negate.</param>
        /// <returns>The vector containg the negation.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Position operator -(Position arg1)
        {
            return arg1?.Subtract();
        }

        /// <summary>
        /// The multiplication operator.
        /// </summary>
        /// <param name="arg1">The vector to multiply.</param>
        /// <param name="arg2">The vector to multiply.</param>
        /// <returns>The vector containing the result of the multiplication.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Position operator *(Position arg1, Position arg2)
        {
            return arg1?.Multiply(arg2);
        }

        /// <summary>
        /// The multiplication operator.
        /// </summary>
        /// <param name="arg1">The vector to multiply</param>
        /// <param name="arg2">The float value to scale the vector.</param>
        /// <returns>The vector containing the result of scaling.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Position operator *(Position arg1, float arg2)
        {
            return arg1?.Multiply(arg2);
        }

        /// <summary>
        /// The division operator.
        /// </summary>
        /// <param name="arg1">The vector to divide.</param>
        /// <param name="arg2">The vector to divide.</param>
        /// <returns>The vector containing the result of the division.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Position operator /(Position arg1, Position arg2)
        {
            return arg1?.Divide(arg2);
        }

        /// <summary>
        /// The division operator.
        /// </summary>
        /// <param name="arg1">The vector to divide.</param>
        /// <param name="arg2">The float value to scale the vector by.</param>
        /// <returns>The vector containing the result of scaling.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Position operator /(Position arg1, float arg2)
        {
            return arg1?.Divide(arg2);
        }

        /// <summary>
        /// Converts a position instance to a Vector3 instance.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static implicit operator Vector3(Position position)
        {
            if (position == null)
            {
                return null;
            }
            return new Vector3(position.X, position.Y, position.Z);
        }

        /// <summary>
        /// Converts a Vector3 instance to a position instance.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static implicit operator Position(Vector3 vec)
        {
            if (vec == null)
            {
                return null;
            }
            return new Position(vec.X, vec.Y, vec.Z);
        }

        /// <summary>
        /// Implicit type cast operator, Position2D to Position
        /// </summary>
        /// <param name="position2d">The object of Position2D type.</param>
        /// <since_tizen> none </since_tizen>
        /// This will be public opened in tizen_next by ACR.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static implicit operator Position(Position2D position2d)
        {
            if (position2d == null)
            {
                return null;
            }
            return new Position(position2d.X, position2d.Y, 0);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(System.Object obj)
        {
            Position position = obj as Position;
            bool equal = false;
            if (X == position?.X && Y == position?.Y && Z == position?.Z)
            {
                equal = true;
            }
            return equal;
        }

        /// <summary>
        /// Gets the hash code of this Position.
        /// </summary>
        /// <returns>The Hash Code.</returns>
        /// <since_tizen> 6 </since_tizen>
        public override int GetHashCode()
        {
            return SwigCPtr.Handle.GetHashCode();
        }

        /// <summary>
        /// Compares if rhs is equal to.
        /// </summary>
        /// <param name="rhs">The vector to compare.</param>
        /// <returns>Returns true if the two vectors are equal, otherwise false.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool EqualTo(Position rhs)
        {
            bool ret = Interop.Vector3.EqualTo(SwigCPtr, Position.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Compares if rhs is not equal to.
        /// </summary>
        /// <param name="rhs">The vector to compare.</param>
        /// <returns>Returns true if the two vectors are not equal, otherwise false.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool NotEqualTo(Position rhs)
        {
            bool ret = Interop.Vector3.NotEqualTo(SwigCPtr, Position.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public object Clone() => new Position(X, Y, Z);

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Position obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        internal static Position GetPositionFromPtr(global::System.IntPtr cPtr)
        {
            Position ret = new Position(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Vector3.DeleteVector3(swigCPtr);
        }


        private Position Add(Position rhs)
        {
            Position ret = new Position(Interop.Vector3.Add(SwigCPtr, Position.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Position Subtract(Position rhs)
        {
            Position ret = new Position(Interop.Vector3.Subtract(SwigCPtr, Position.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Position Multiply(Position rhs)
        {
            Position ret = new Position(Interop.Vector3.Multiply(SwigCPtr, Position.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Position Multiply(float rhs)
        {
            Position ret = new Position(Interop.Vector3.Multiply(SwigCPtr, rhs), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Position Divide(Position rhs)
        {
            Position ret = new Position(Interop.Vector3.Divide(SwigCPtr, Position.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Position Divide(float rhs)
        {
            Position ret = new Position(Interop.Vector3.Divide(SwigCPtr, rhs), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Position Subtract()
        {
            Position ret = new Position(Interop.Vector3.Subtract(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private float ValueOfIndex(uint index)
        {
            float ret = Interop.Vector3.ValueOfIndex(SwigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal delegate void PositionChangedCallback(float x, float y, float z);

        internal Position(PositionChangedCallback cb, float x, float y, float z) : this(Interop.Vector3.NewVector3(x, y, z), true)
        {
            callback = cb;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        private PositionChangedCallback callback = null;
    }
}
