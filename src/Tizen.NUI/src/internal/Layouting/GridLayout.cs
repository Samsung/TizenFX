/* Copyright (c) 2018 Samsung Electronics Co., Ltd.
.*
.* Licensed under the Apache License, Version 2.0 (the "License");
.* you may not use this file except in compliance with the License.
.* You may obtain a copy of the License at
.*
.* http://www.apache.org/licenses/LICENSE-2.0
.*
.* Unless required by applicable law or agreed to in writing, software
.* distributed under the License is distributed on an "AS IS" BASIS,
.* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
.* See the License for the specific language governing permissions and
.* limitations under the License.
.*
.*/

using System.ComponentModel;

namespace Tizen.NUI
{
    /// <summary>
    /// [Draft] This class implements a grid layout
    /// </summary>
    internal class GridLayout : LayoutGroupWrapper
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        /// <summary>
        /// [draft] Internal contstructor/>
        /// </summary>
        /// <param name="cPtr"> object to get handle to.</param>
        /// <param name="cMemoryOwn"> flag to indicate if memory is owned.</param>
        internal GridLayout(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.GridLayout.GridLayout_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        /// <summary>
        /// [draft] Get C pointer for the GridLayout/>
        /// </summary>
        /// <param name="obj"> object to get handle to.</param>
        /// <returns>Handle to the managed C class.</returns>
        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(GridLayout obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        /// <summary>
        /// [draft] Dispose/>
        /// </summary>
        /// <param name="type"> Type of disposal.</param>
        protected override void Dispose(DisposeTypes type)
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
                    Interop.GridLayout.delete_GridLayout(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }
            base.Dispose(type);
        }

        /// <summary>
        /// [draft] GridLayout Constructor/>
        /// </summary>
        /// <returns> New Grid object.</returns>
        public GridLayout() : this(Interop.GridLayout.GridLayout_New(), true)
        {
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// [draft] Downcast/>
        /// </summary>
        /// <param name="handle">Handle to the given object that maybe be a GridLayout.</param>
        /// <returns>Grid object if Downcase possible.</returns>
        public static GridLayout DownCast(BaseHandle handle)
        {
            GridLayout ret = new GridLayout(Interop.GridLayout.GridLayout_DownCast(BaseHandle.getCPtr(handle)), true);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// [draft] Copy of a Gridlayout to another GridLayout />
        /// </summary>
        /// <param name="other">Copy the given Grid object to another Grid object.</param>
        /// <returns>The newly created Grid object.</returns>
        internal GridLayout(GridLayout other) : this(Interop.GridLayout.new_GridLayout_SWIG_1(GridLayout.getCPtr(other)), true)
        {
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// [draft] Assignment of a Gridlayout to another GridLayout />
        /// </summary>
        /// <param name="other">Assign the given Grid object to another Grid object.</param>
        /// <returns>The newly assigned Grid object.</returns>
        internal GridLayout Assign(GridLayout other)
        {
            GridLayout ret = new GridLayout(Interop.GridLayout.GridLayout_Assign(swigCPtr, GridLayout.getCPtr(other)), false);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// [draft ] Sets the number of columns the GridLayout should have. />
        /// </summary>
        /// <param name="columns">The nunber of columns.</param>
        internal void SetColumns(int columns)
        {
            Interop.GridLayout.GridLayout_SetColumns(swigCPtr, columns);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// [draft ] Gets the number of columns in the Grid />
        /// </summary>
        /// <returns>The number of coulumns in the Grid.</returns>
        internal int GetColumns()
        {
            int ret = (int)Interop.GridLayout.GridLayout_GetColumns(swigCPtr);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        // <summary>
        // [Draft] Get/Set the number of columns in the grid
        // </summary>
        public int Columns
        {
            get
            {
                return GetColumns();
            }
            set
            {
                SetColumns(value);
            }
        }
    }

}
