/*
 * Copyright(c) 2017 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI.UIComponents
{

    /// <summary>
    /// The PushButton changes its appearance when it is pressed, and returns to its original when it is released.
    /// </summary>
    public class PushButton : Button
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal PushButton(global::System.IntPtr cPtr, bool cMemoryOwn) : base(NDalicPINVOKE.PushButton_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(PushButton obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        /// <summary>
        /// To dispose the PushButton instance.
        /// </summary>
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if(type == DisposeTypes.Explicit)
            {
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.

            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;
                    NDalicPINVOKE.delete_PushButton(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }


        internal new class Property
        {
            internal static readonly int UNSELECTED_ICON = NDalicPINVOKE.PushButton_Property_UNSELECTED_ICON_get();
            internal static readonly int SELECTED_ICON = NDalicPINVOKE.PushButton_Property_SELECTED_ICON_get();
            internal static readonly int ICON_ALIGNMENT = NDalicPINVOKE.PushButton_Property_ICON_ALIGNMENT_get();
            internal static readonly int LABEL_PADDING = NDalicPINVOKE.PushButton_Property_LABEL_PADDING_get();
            internal static readonly int ICON_PADDING = NDalicPINVOKE.PushButton_Property_ICON_PADDING_get();
        }

        /// <summary>
        /// Creates the PushButton.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PushButton() : this(NDalicPINVOKE.PushButton_New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }

        /// <summary>
        /// Please do not use! this will be deprecated
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Please do not use! this will be deprecated")]
        public new static PushButton DownCast(BaseHandle handle)
        {
            PushButton ret =  Registry.GetManagedBaseHandleFromNativePtr(handle) as PushButton;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Please do not use! this will be deprecated
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Please do not use! this will be deprecated")]
        public string UnselectedIcon
        {
            set
            {
                SetProperty(PushButton.Property.UNSELECTED_ICON, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Please do not use! this will be deprecated
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Please do not use! this will be deprecated")]
        public string SelectedIcon
        {
            set
            {
                SetProperty(PushButton.Property.SELECTED_ICON, new Tizen.NUI.PropertyValue(value));
            }
        }
        /// <summary>
        /// Please do not use! this will be deprecated
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Please do not use! this will be deprecated")]
        public IconAlignmentType IconAlignment
        {
            get
            {
                string temp;
                if (GetProperty(PushButton.Property.ICON_ALIGNMENT).Get(out temp) == false)
                {
                    NUILog.Error("IconAlignment get error!");
                }
                switch (temp)
                {
                    case "LEFT":
                        return IconAlignmentType.Left;
                    case "RIGHT":
                        return IconAlignmentType.Right;
                    case "TOP":
                        return IconAlignmentType.Top;
                    case "BOTTOM":
                        return IconAlignmentType.Bottom;
                    default:
                        return IconAlignmentType.Default;
                }
            }
            set
            {
                string valueToString = "";
                switch (value)
                {
                    case IconAlignmentType.Left:
                        {
                            valueToString = "LEFT";
                            break;
                        }
                    case IconAlignmentType.Right:
                        {
                            valueToString = "RIGHT";
                            break;
                        }
                    case IconAlignmentType.Top:
                        {
                            valueToString = "TOP";
                            break;
                        }
                    case IconAlignmentType.Bottom:
                        {
                            valueToString = "BOTTOM";
                            break;
                        }
                    default:
                        {
                            valueToString = "DEFAULT";
                            break;
                        }
                }
                SetProperty(PushButton.Property.ICON_ALIGNMENT, new Tizen.NUI.PropertyValue(valueToString));
            }
        }
        /// <summary>
        /// Please do not use! this will be deprecated
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Please do not use! this will be deprecated")]
        public new Vector4 LabelPadding
        {
            get
            {
                Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
                GetProperty(PushButton.Property.LABEL_PADDING).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(PushButton.Property.LABEL_PADDING, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Please do not use! this will be deprecated
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Please do not use! this will be deprecated")]
        public Vector4 IconPadding
        {
            get
            {
                Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
                GetProperty(PushButton.Property.ICON_PADDING).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(PushButton.Property.ICON_PADDING, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Please do not use! this will be deprecated
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Please do not use! this will be deprecated")]
        public enum IconAlignmentType
        {
            /// <summary>
            /// The icon located to the left of text.
            /// </summary>
            Left,
            /// <summary>
            /// The icon located to the right of text.
            /// </summary>
            Right,
            /// <summary>
            /// The icon located to the top of text.
            /// </summary>
            Top,
            /// <summary>
            /// The icon located to the bottom of text.
            /// </summary>
            Bottom,
            /// <summary>
            /// The icon located to the right of text by default.
            /// </summary>
            Default = Right
        }

    }
}