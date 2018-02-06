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
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Tizen.NUI.BaseComponents
{

    /// <summary>
    /// TableView is a layout container for aligning child actors in a grid like layout.<br />
    /// TableView constraints the X and the Y position and the width and the height of the child actors.<br />
    /// The Z position and depth are left intact so that the 3D model actors can also be laid out
    /// in a grid without loosing their depth scaling.<br />
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class TableView : View
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal TableView(global::System.IntPtr cPtr, bool cMemoryOwn) : base(NDalicPINVOKE.TableView_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(TableView obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        /// <summary>
        /// Dispose
        /// </summary>
        /// <param name="type">The dispose type</param>
        /// <since_tizen> 3 </since_tizen>
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
                    NDalicPINVOKE.delete_TableView(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }


        internal new class Property
        {
            internal static readonly int ROWS = NDalicPINVOKE.TableView_Property_ROWS_get();
            internal static readonly int COLUMNS = NDalicPINVOKE.TableView_Property_COLUMNS_get();
            internal static readonly int CELL_PADDING = NDalicPINVOKE.TableView_Property_CELL_PADDING_get();
            internal static readonly int LAYOUT_ROWS = NDalicPINVOKE.TableView_Property_LAYOUT_ROWS_get();
            internal static readonly int LAYOUT_COLUMNS = NDalicPINVOKE.TableView_Property_LAYOUT_COLUMNS_get();
        }

        internal class ChildProperty
        {
            internal static readonly int CELL_INDEX = NDalicPINVOKE.TableView_ChildProperty_CELL_INDEX_get();
            internal static readonly int ROW_SPAN = NDalicPINVOKE.TableView_ChildProperty_ROW_SPAN_get();
            internal static readonly int COLUMN_SPAN = NDalicPINVOKE.TableView_ChildProperty_COLUMN_SPAN_get();
            internal static readonly int CELL_HORIZONTAL_ALIGNMENT = NDalicPINVOKE.TableView_ChildProperty_CELL_HORIZONTAL_ALIGNMENT_get();
            internal static readonly int CELL_VERTICAL_ALIGNMENT = NDalicPINVOKE.TableView_ChildProperty_CELL_VERTICAL_ALIGNMENT_get();
        }

        /// <summary>
        /// Class to specify the layout position for the child view.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public class CellPosition : global::System.IDisposable
        {
            private global::System.Runtime.InteropServices.HandleRef swigCPtr;
            /// <summary>
            /// swigCMemOwn
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            protected bool swigCMemOwn;

            internal CellPosition(global::System.IntPtr cPtr, bool cMemoryOwn)
            {
                swigCMemOwn = cMemoryOwn;
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
            }

            internal static global::System.Runtime.InteropServices.HandleRef getCPtr(CellPosition obj)
            {
                return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
            }

            //A Flag to check who called Dispose(). (By User or DisposeQueue)
            private bool isDisposeQueued = false;
            /// <summary>
            /// A Flat to check if it is already disposed.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            protected bool disposed = false;

            /// <summary>
            /// Dispose.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            ~CellPosition()
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

            /// <summary>
            /// Dispose.
            /// </summary>
            /// <param name="type">DisposeTypes</param>
            /// <since_tizen> 3 </since_tizen>
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
                        NDalicPINVOKE.delete_TableView_CellPosition(swigCPtr);
                    }
                    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
                }
                disposed = true;
            }

            /// <summary>
            /// The constructor.
            /// </summary>
            /// <param name="rowIndex">The row index initialized.</param>
            /// <param name="columnIndex">The column index initialized.</param>
            /// <param name="rowSpan">The row span initialized.</param>
            /// <param name="columnSpan">The column span initialized.</param>
            /// <since_tizen> 3 </since_tizen>
            public CellPosition(uint rowIndex, uint columnIndex, uint rowSpan, uint columnSpan) : this(NDalicPINVOKE.new_TableView_CellPosition__SWIG_0(rowIndex, columnIndex, rowSpan, columnSpan), true)
            {
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }

            /// <summary>
            /// The constructor to initialize values to defaults for convenience.
            /// </summary>
            /// <param name="rowIndex">The row index initialized.</param>
            /// <param name="columnIndex">The column index initialized.</param>
            /// <param name="rowSpan">The row span initialized.</param>
            /// <since_tizen> 3 </since_tizen>
            public CellPosition(uint rowIndex, uint columnIndex, uint rowSpan) : this(NDalicPINVOKE.new_TableView_CellPosition__SWIG_1(rowIndex, columnIndex, rowSpan), true)
            {
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }

            /// <summary>
            /// The constructor to initialize values to defaults for convenience.
            /// </summary>
            /// <param name="rowIndex">The row index initialized.</param>
            /// <param name="columnIndex">The column index initialized.</param>
            /// <since_tizen> 3 </since_tizen>
            public CellPosition(uint rowIndex, uint columnIndex) : this(NDalicPINVOKE.new_TableView_CellPosition__SWIG_2(rowIndex, columnIndex), true)
            {
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }

            /// <summary>
            /// The constructor to initialize values to default for convenience.
            /// </summary>
            /// <param name="rowIndex">The row index initialized.</param>
            /// <since_tizen> 3 </since_tizen>
            public CellPosition(uint rowIndex) : this(NDalicPINVOKE.new_TableView_CellPosition__SWIG_3(rowIndex), true)
            {
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }

            /// <summary>
            /// The default constructor.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public CellPosition() : this(NDalicPINVOKE.new_TableView_CellPosition__SWIG_4(), true)
            {
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }

            /// <summary>
            /// The index of a row.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public uint rowIndex
            {
                set
                {
                    NDalicPINVOKE.TableView_CellPosition_rowIndex_set(swigCPtr, value);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
                get
                {
                    uint ret = NDalicPINVOKE.TableView_CellPosition_rowIndex_get(swigCPtr);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                    return ret;
                }
            }

            /// <summary>
            /// The index of a column.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public uint columnIndex
            {
                set
                {
                    NDalicPINVOKE.TableView_CellPosition_columnIndex_set(swigCPtr, value);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
                get
                {
                    uint ret = NDalicPINVOKE.TableView_CellPosition_columnIndex_get(swigCPtr);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                    return ret;
                }
            }

            /// <summary>
            /// The span of a row.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public uint rowSpan
            {
                set
                {
                    NDalicPINVOKE.TableView_CellPosition_rowSpan_set(swigCPtr, value);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
                get
                {
                    uint ret = NDalicPINVOKE.TableView_CellPosition_rowSpan_get(swigCPtr);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                    return ret;
                }
            }

            /// <summary>
            /// The span of a column.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public uint columnSpan
            {
                set
                {
                    NDalicPINVOKE.TableView_CellPosition_columnSpan_set(swigCPtr, value);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
                get
                {
                    uint ret = NDalicPINVOKE.TableView_CellPosition_columnSpan_get(swigCPtr);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                    return ret;
                }
            }

        }

        /// <summary>
        /// Creates the TableView view.
        /// </summary>
        /// <param name="initialRows">Initial rows for the table.</param>
        /// <param name="initialColumns">Initial columns for the table.</param>
        /// <since_tizen> 3 </since_tizen>
        public TableView(uint initialRows, uint initialColumns) : this(NDalicPINVOKE.TableView_New(initialRows, initialColumns), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }

        /// <summary>
        /// The Copy constructor. Creates another handle that points to the same real object.
        /// </summary>
        /// <param name="handle">Handle to copy from.</param>
        /// <since_tizen> 3 </since_tizen>
        public TableView(TableView handle) : this(NDalicPINVOKE.new_TableView__SWIG_1(TableView.getCPtr(handle)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Adds a child to the table.<br />
        /// If the row or column index is outside the table, the table gets resized bigger.<br />
        /// </summary>
        /// <param name="child">The child to add.</param>
        /// <param name="position">The position for the child.</param>
        /// <returns>True if the addition succeeded, and false if the cell is already occupied.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool AddChild(View child, TableView.CellPosition position)
        {
            bool ret = NDalicPINVOKE.TableView_AddChild(swigCPtr, View.getCPtr(child), TableView.CellPosition.getCPtr(position));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Returns a child from the given layout position.
        /// </summary>
        /// <param name="position">The position in the table.</param>
        /// <returns>Child that was in the cell or an uninitialized handle.</returns>
        /// <since_tizen> 3 </since_tizen>
        public View GetChildAt(TableView.CellPosition position)
        {
            //to fix memory leak issue, match the handle count with native side.
            IntPtr cPtr = NDalicPINVOKE.TableView_GetChildAt(swigCPtr, TableView.CellPosition.getCPtr(position));
            HandleRef CPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
            View ret = Registry.GetManagedBaseHandleFromNativePtr(CPtr.Handle) as View;
            NDalicPINVOKE.delete_BaseHandle(CPtr);
            CPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Removes a child from the given layout position.
        /// </summary>
        /// <param name="position">The position for the child to remove.</param>
        /// <returns>Child that was removed or an uninitialized handle.</returns>
        /// <since_tizen> 3 </since_tizen>
        public View RemoveChildAt(TableView.CellPosition position)
        {
            //to fix memory leak issue, match the handle count with native side.
            IntPtr cPtr = NDalicPINVOKE.TableView_RemoveChildAt(swigCPtr, TableView.CellPosition.getCPtr(position));
            HandleRef CPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
            View ret = Registry.GetManagedBaseHandleFromNativePtr(CPtr.Handle) as View;
            NDalicPINVOKE.delete_BaseHandle(CPtr);
            CPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Finds the child's layout position.
        /// </summary>
        /// <param name="child">The child to search for.</param>
        /// <param name="position">The position for the child.</param>
        /// <returns>True if the child was included in this TableView.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool FindChildPosition(View child, TableView.CellPosition position)
        {
            bool ret = NDalicPINVOKE.TableView_FindChildPosition(swigCPtr, View.getCPtr(child), TableView.CellPosition.getCPtr(position));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Inserts a new row to the given index.
        /// </summary>
        /// <param name="rowIndex">The rowIndex of the new row.</param>
        /// <since_tizen> 3 </since_tizen>
        public void InsertRow(uint rowIndex)
        {
            NDalicPINVOKE.TableView_InsertRow(swigCPtr, rowIndex);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Deletes a row from the given index.<br />
        /// Removed elements are deleted.<br />
        /// </summary>
        /// <param name="rowIndex">The rowIndex of the row to delete.</param>
        /// <since_tizen> 3 </since_tizen>
        public void DeleteRow(uint rowIndex)
        {
            NDalicPINVOKE.TableView_DeleteRow__SWIG_0(swigCPtr, rowIndex);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Inserts a new column to the given index.
        /// </summary>
        /// <param name="columnIndex">The columnIndex of the new column.</param>
        /// <since_tizen> 3 </since_tizen>
        public void InsertColumn(uint columnIndex)
        {
            NDalicPINVOKE.TableView_InsertColumn(swigCPtr, columnIndex);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Deletes a column from the given index.<br />
        /// Removed elements are deleted.<br />
        /// </summary>
        /// <param name="columnIndex">The columnIndex of the column to delete.</param>
        /// <since_tizen> 3 </since_tizen>
        public void DeleteColumn(uint columnIndex)
        {
            NDalicPINVOKE.TableView_DeleteColumn__SWIG_0(swigCPtr, columnIndex);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Resizes the TableView.
        /// </summary>
        /// <param name="rows">The rows for the table.</param>
        /// <param name="columns">The columns for the table.</param>
        /// <since_tizen> 3 </since_tizen>
        public void Resize(uint rows, uint columns)
        {
            NDalicPINVOKE.TableView_Resize__SWIG_0(swigCPtr, rows, columns);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets the horizontal and the vertical padding between cells.
        /// </summary>
        /// <param name="padding">Width and height.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetCellPadding(Size2D padding)
        {
            NDalicPINVOKE.TableView_SetCellPadding(swigCPtr, Size2D.getCPtr(padding));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the current padding as width and height.
        /// </summary>
        /// <returns>The current padding as width and height.</returns>
        /// <since_tizen> 3 </since_tizen>
        public Vector2 GetCellPadding()
        {
            Vector2 ret = new Vector2(NDalicPINVOKE.TableView_GetCellPadding(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Specifies this row as fitting its height to its children.
        /// </summary>
        /// <param name="rowIndex">The row to set.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetFitHeight(uint rowIndex)
        {
            NDalicPINVOKE.TableView_SetFitHeight(swigCPtr, rowIndex);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Checks if the row is a fit row.
        /// </summary>
        /// <param name="rowIndex">The row to check.</param>
        /// <returns>True if the row is fit.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool IsFitHeight(uint rowIndex)
        {
            bool ret = NDalicPINVOKE.TableView_IsFitHeight(swigCPtr, rowIndex);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Specifies this column as fitting its width to its children.
        /// </summary>
        /// <param name="columnIndex">The column to set.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetFitWidth(uint columnIndex)
        {
            NDalicPINVOKE.TableView_SetFitWidth(swigCPtr, columnIndex);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Checks if the column is a fit column.
        /// </summary>
        /// <param name="columnIndex">The column to check.</param>
        /// <returns>True if the column is fit.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool IsFitWidth(uint columnIndex)
        {
            bool ret = NDalicPINVOKE.TableView_IsFitWidth(swigCPtr, columnIndex);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets a row to have a fixed height.<br />
        /// Setting a fixed height of 0 has no effect.<br />
        /// </summary>
        /// <param name="rowIndex">The rowIndex for row with a fixed height.</param>
        /// <param name="height">The height in world coordinate units.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetFixedHeight(uint rowIndex, float height)
        {
            NDalicPINVOKE.TableView_SetFixedHeight(swigCPtr, rowIndex, height);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets a row's fixed height.
        /// </summary>
        /// <param name="rowIndex">The row index with a fixed height.</param>
        /// <returns>height The height in world coordinate units.</returns>
        /// <since_tizen> 3 </since_tizen>
        public float GetFixedHeight(uint rowIndex)
        {
            float ret = NDalicPINVOKE.TableView_GetFixedHeight(swigCPtr, rowIndex);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets a row to have a relative height. Relative height means percentage of
        /// the remainder of the table height after subtracting padding and fixed height rows.<br />
        /// Setting a relative height of 0 has no effect.<br />
        /// </summary>
        /// <param name="rowIndex">The rowIndex for row with a relative height.</param>
        /// <param name="heightPercentage">The height percentage between 0.0f and 1.0f.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetRelativeHeight(uint rowIndex, float heightPercentage)
        {
            NDalicPINVOKE.TableView_SetRelativeHeight(swigCPtr, rowIndex, heightPercentage);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets a row's relative height.
        /// </summary>
        /// <param name="rowIndex">The row index with a relative height.</param>
        /// <returns>Height in percentage units, between 0.0f and 1.0f.</returns>
        /// <since_tizen> 3 </since_tizen>
        public float GetRelativeHeight(uint rowIndex)
        {
            float ret = NDalicPINVOKE.TableView_GetRelativeHeight(swigCPtr, rowIndex);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets a column to have a fixed width.<br />
        /// Setting a fixed width of 0 has no effect.<br />
        /// </summary>
        /// <param name="columnIndex">The columnIndex for column with a fixed width.</param>
        /// <param name="width">The width in world coordinate units.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetFixedWidth(uint columnIndex, float width)
        {
            NDalicPINVOKE.TableView_SetFixedWidth(swigCPtr, columnIndex, width);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets a column's fixed width.
        /// </summary>
        /// <param name="columnIndex">The column index with a fixed width.</param>
        /// <returns>Width in world coordinate units.</returns>
        /// <since_tizen> 3 </since_tizen>
        public float GetFixedWidth(uint columnIndex)
        {
            float ret = NDalicPINVOKE.TableView_GetFixedWidth(swigCPtr, columnIndex);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets a column to have a relative width. Relative width means percentage of
        /// the remainder of the table width after subtracting padding and fixed width columns.<br />
        /// Setting a relative width of 0 has no effect.<br />
        /// </summary>
        /// <param name="columnIndex">The columnIndex for column with a fixed width.</param>
        /// <param name="widthPercentage">The widthPercentage between 0.0f and 1.0f.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetRelativeWidth(uint columnIndex, float widthPercentage)
        {
            NDalicPINVOKE.TableView_SetRelativeWidth(swigCPtr, columnIndex, widthPercentage);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets a column's relative width.
        /// </summary>
        /// <param name="columnIndex">The column index with a relative width.</param>
        /// <returns>Width in percentage units, between 0.0f and 1.0f.</returns>
        /// <since_tizen> 3 </since_tizen>
        public float GetRelativeWidth(uint columnIndex)
        {
            float ret = NDalicPINVOKE.TableView_GetRelativeWidth(swigCPtr, columnIndex);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets the alignment on a cell.<br />
        /// Cells without calling this function have the default values of left and top respectively.<br />
        /// </summary>
        /// <param name="position">The cell to set alignment on.</param>
        /// <param name="horizontal">The horizontal alignment.</param>
        /// <param name="vertical">The vertical alignment.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetCellAlignment(TableView.CellPosition position, HorizontalAlignmentType horizontal, VerticalAlignmentType vertical)
        {
            NDalicPINVOKE.TableView_SetCellAlignment(swigCPtr, TableView.CellPosition.getCPtr(position), (int)horizontal, (int)vertical);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Enumeration for describing how the size of a row or column has been set.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public enum LayoutPolicy
        {
            /// <summary>
            /// Fixed with the given value.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            Fixed,
            /// <summary>
            /// Calculated as percentage of the remainder after subtracting Padding and Fixed height/width.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            Relative,
            /// <summary>
            ///  Default policy, get the remainder of the 100% (after subtracting Fixed, Fit and Relative height/ width) divided evenly between 'fill' rows/columns.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            Fill,
            /// <summary>
            /// Fit around its children.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            Fit
        }

        /// <summary>
        /// The amount of rows in the table.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int Rows
        {
            get
            {
                int temp = 0;
                GetProperty(TableView.Property.ROWS).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TableView.Property.ROWS, new Tizen.NUI.PropertyValue(value));
            }
        }
        /// <summary>
        /// The amount of columns in the table.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int Columns
        {
            get
            {
                int temp = 0;
                GetProperty(TableView.Property.COLUMNS).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TableView.Property.COLUMNS, new Tizen.NUI.PropertyValue(value));
            }
        }
        /// <summary>
        /// Padding between cells.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector2 CellPadding
        {
            get
            {
                Vector2 temp = new Vector2(0.0f, 0.0f);
                GetProperty(TableView.Property.CELL_PADDING).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(TableView.Property.CELL_PADDING, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// The number of layout rows.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap LayoutRows
        {
            get
            {
                PropertyMap temp = new PropertyMap();
                GetProperty(TableView.Property.LAYOUT_ROWS).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(TableView.Property.LAYOUT_ROWS, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// The number of layout columns.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap LayoutColumns
        {
            get
            {
                PropertyMap temp = new PropertyMap();
                GetProperty(TableView.Property.LAYOUT_COLUMNS).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(TableView.Property.LAYOUT_COLUMNS, new Tizen.NUI.PropertyValue(value));
            }
        }

    }
}