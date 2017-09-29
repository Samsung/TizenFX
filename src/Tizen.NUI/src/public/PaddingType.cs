/** Copyright (c) 2017 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI
{
    /// <summary>
    /// The gesture state.
    /// </summary>
    public class PaddingType : global::System.IDisposable
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;
        protected bool swigCMemOwn;

        internal PaddingType(global::System.IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(PaddingType obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        //A Flag to check who called Dispose(). (By User or DisposeQueue)
        private bool isDisposeQueued = false;
        //A Flat to check if it is already disposed.
        protected bool disposed = false;


        ~PaddingType()
        {
            if (!isDisposeQueued)
            {
                isDisposeQueued = true;
                DisposeQueue.Instance.Add(this);
            }
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Dispose()
        {
            //Throw excpetion if Dispose() is called in separate thread.
            if (!Window.IsInstalled())
            {
                throw new System.InvalidOperationException("This API called from separate thread. This API must be called from MainThread.");
            }

            if (isDisposeQueued)
            {
                Dispose(DisposeTypes.Implicit);
            }
            else
            {
                Dispose(DisposeTypes.Explicit);
                System.GC.SuppressFinalize(this);
            }
        }

        protected virtual void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
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
                    NDalicPINVOKE.delete_PaddingType(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            disposed = true;
        }

        /// <summary>
        /// Equality operator
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static bool operator ==(PaddingType a, PaddingType b)
        {
            // If both are null, or both are same instance, return true.
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            // Return true if the fields match:
            return (System.Math.Abs(a.Left - b.Left) < NDalic.GetRangedEpsilon(a.Left, b.Left)) &&
                   (System.Math.Abs(a.Right - b.Right) < NDalic.GetRangedEpsilon(a.Right, b.Right)) &&
                   (System.Math.Abs(a.Bottom - b.Bottom) < NDalic.GetRangedEpsilon(a.Bottom, b.Bottom)) &&
                   (System.Math.Abs(a.Top - b.Top) < NDalic.GetRangedEpsilon(a.Top, b.Top));
        }

        /// <summary>
        /// Inequality operator. Returns Null if either operand is Null
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static bool operator !=(PaddingType a, PaddingType b)
        {
            return !(a == b);
        }


        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="o">The object should be compared.</param>
        /// <returns>True if equal.</returns>
        /// <since_tizen> 4 </since_tizen>
        public override bool Equals(object o)
        {
            if(o == null)
            {
                return false;
            }
            if(!(o is PaddingType))
            {
                return false;
            }
            PaddingType p = (PaddingType)o;

            // Return true if the fields match:
            return (System.Math.Abs(Left - p.Left) < NDalic.GetRangedEpsilon(Left, p.Left)) &&
                   (System.Math.Abs(Right - p.Right) < NDalic.GetRangedEpsilon(Right, p.Right)) &&
                   (System.Math.Abs(Bottom - p.Bottom) < NDalic.GetRangedEpsilon(Bottom, p.Bottom)) &&
                   (System.Math.Abs(Top - p.Top) < NDalic.GetRangedEpsilon(Top, p.Top));
        }

        /// <summary>
        /// Gets the the hash code of this baseHandle.
        /// </summary>
        /// <returns>The Hash Code.</returns>
        /// <since_tizen> 4 </since_tizen>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// The Left value.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float Left
        {
            set
            {
                left = value;
            }
            get
            {
                return left;
            }
        }

        /// <summary>
        /// The Right value.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float Right
        {
            set
            {
                right = value;
            }
            get
            {
                return right;
            }
        }

        /// <summary>
        /// The Bottom value.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float Bottom
        {
            set
            {
                bottom = value;
            }
            get
            {
                return bottom;
            }
        }

        /// <summary>
        /// The Top value.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float Top
        {
            set
            {
                top = value;
            }
            get
            {
                return top;
            }
        }

        /// <summary>
        /// Create an instance of paddingType.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PaddingType() : this(NDalicPINVOKE.new_PaddingType__SWIG_0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Create an instance of BaseHandle.
        /// </summary>
        /// <param name="x">The x value.</param>
        /// <param name="y">The y value.</param>
        /// <param name="width">The width value.</param>
        /// <param name="height">The height value.</param>
        /// <since_tizen> 3 </since_tizen>
        public PaddingType(float x, float y, float width, float height) : this(NDalicPINVOKE.new_PaddingType__SWIG_1(x, y, width, height), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Set the x, y, width, height of this paddingtype.
        /// </summary>
        /// <param name="x">The x value.</param>
        /// <param name="y">The y value.</param>
        /// <param name="width">The width value.</param>
        /// <param name="height">The height value.</param>
        /// <since_tizen> 3 </since_tizen>
        public void Set(float newX, float newY, float newWidth, float newHeight)
        {
            NDalicPINVOKE.PaddingType_Set(swigCPtr, newX, newY, newWidth, newHeight);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        private float x
        {
            set
            {
                NDalicPINVOKE.PaddingType_x_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                float ret = NDalicPINVOKE.PaddingType_x_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private float left
        {
            set
            {
                NDalicPINVOKE.PaddingType_left_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                float ret = NDalicPINVOKE.PaddingType_left_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private float y
        {
            set
            {
                NDalicPINVOKE.PaddingType_y_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                float ret = NDalicPINVOKE.PaddingType_y_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private float right
        {
            set
            {
                NDalicPINVOKE.PaddingType_right_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                float ret = NDalicPINVOKE.PaddingType_right_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private float width
        {
            set
            {
                NDalicPINVOKE.PaddingType_width_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                float ret = NDalicPINVOKE.PaddingType_width_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private float bottom
        {
            set
            {
                NDalicPINVOKE.PaddingType_bottom_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                float ret = NDalicPINVOKE.PaddingType_bottom_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private float height
        {
            set
            {
                NDalicPINVOKE.PaddingType_height_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                float ret = NDalicPINVOKE.PaddingType_height_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private float top
        {
            set
            {
                NDalicPINVOKE.PaddingType_top_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                float ret = NDalicPINVOKE.PaddingType_top_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

    }

}