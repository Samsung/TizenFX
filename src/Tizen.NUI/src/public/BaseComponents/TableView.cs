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
using System.ComponentModel;
using System.Runtime.InteropServices;
using Tizen.NUI.Binding;

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
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty RowsProperty = BindableProperty.Create("Rows", typeof(int), typeof(TableView), default(int), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var tableView = (TableView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(tableView.swigCPtr, TableView.Property.ROWS, new Tizen.NUI.PropertyValue((int)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var tableView = (TableView)bindable;
            int temp = 0;
            Tizen.NUI.Object.GetProperty(tableView.swigCPtr, TableView.Property.ROWS).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ColumnsProperty = BindableProperty.Create("Columns", typeof(int), typeof(TableView), default(int), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var tableView = (TableView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(tableView.swigCPtr, TableView.Property.COLUMNS, new Tizen.NUI.PropertyValue((int)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var tableView = (TableView)bindable;
            int temp = 0;
            Tizen.NUI.Object.GetProperty(tableView.swigCPtr, TableView.Property.COLUMNS).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CellPaddingProperty = BindableProperty.Create("CellPadding", typeof(Vector2), typeof(TableView), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var tableView = (TableView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(tableView.swigCPtr, TableView.Property.CELL_PADDING, new Tizen.NUI.PropertyValue((Vector2)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var tableView = (TableView)bindable;
            Vector2 temp = new Vector2(0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty(tableView.swigCPtr, TableView.Property.CELL_PADDING).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LayoutRowsProperty = BindableProperty.Create("LayoutRows", typeof(PropertyMap), typeof(TableView), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var tableView = (TableView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(tableView.swigCPtr, TableView.Property.LAYOUT_ROWS, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var tableView = (TableView)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty(tableView.swigCPtr, TableView.Property.LAYOUT_ROWS).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LayoutColumnsProperty = BindableProperty.Create("LayoutColumns", typeof(PropertyMap), typeof(TableView), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var tableView = (TableView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(tableView.swigCPtr, TableView.Property.LAYOUT_COLUMNS, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var tableView = (TableView)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty(tableView.swigCPtr, TableView.Property.LAYOUT_COLUMNS).Get(temp);
            return temp;
        });


        /// <summary>
        /// Creates the default TableView view.
        /// </summary>
        public TableView() : this(Interop.TableView.TableView_New(1, 1), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Creates the TableView view.
        /// </summary>
        /// <param name="initialRows">Initial rows for the table.</param>
        /// <param name="initialColumns">Initial columns for the table.</param>
        /// <since_tizen> 3 </since_tizen>
        public TableView(uint initialRows, uint initialColumns) : this(Interop.TableView.TableView_New(initialRows, initialColumns), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }

        /// <summary>
        /// The Copy constructor. Creates another handle that points to the same real object.
        /// </summary>
        /// <param name="handle">Handle to copy from.</param>
        /// <since_tizen> 3 </since_tizen>
        public TableView(TableView handle) : this(Interop.TableView.new_TableView__SWIG_1(TableView.getCPtr(handle)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal TableView(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.TableView.TableView_SWIGUpcast(cPtr), cMemoryOwn)
        {
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
                return (int)GetValue(RowsProperty);
            }
            set
            {
                SetValue(RowsProperty, value);
                NotifyPropertyChanged();
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
                return (int)GetValue(ColumnsProperty);
            }
            set
            {
                SetValue(ColumnsProperty, value);
                NotifyPropertyChanged();
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
                return (Vector2)GetValue(CellPaddingProperty);
            }
            set
            {
                SetValue(CellPaddingProperty, value);
                NotifyPropertyChanged();
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
                return (PropertyMap)GetValue(LayoutRowsProperty);
            }
            set
            {
                SetValue(LayoutRowsProperty, value);
                NotifyPropertyChanged();
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
                return (PropertyMap)GetValue(LayoutColumnsProperty);
            }
            set
            {
                SetValue(LayoutColumnsProperty, value);
                NotifyPropertyChanged();
            }
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
            bool ret = Interop.TableView.TableView_AddChild(swigCPtr, View.getCPtr(child), TableView.CellPosition.getCPtr(position));
            Children.Add(child);
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
            IntPtr cPtr = Interop.TableView.TableView_GetChildAt(swigCPtr, TableView.CellPosition.getCPtr(position));
            HandleRef CPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
            View ret = Registry.GetManagedBaseHandleFromNativePtr(CPtr.Handle) as View;
            Interop.BaseHandle.delete_BaseHandle(CPtr);
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
            IntPtr cPtr = Interop.TableView.TableView_RemoveChildAt(swigCPtr, TableView.CellPosition.getCPtr(position));
            View ret = this.GetInstanceSafely<View>(cPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            Children.Remove(ret);

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
            bool ret = Interop.TableView.TableView_FindChildPosition(swigCPtr, View.getCPtr(child), TableView.CellPosition.getCPtr(position));
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
            Interop.TableView.TableView_InsertRow(swigCPtr, rowIndex);
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
            Interop.TableView.TableView_DeleteRow__SWIG_0(swigCPtr, rowIndex);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Inserts a new column to the given index.
        /// </summary>
        /// <param name="columnIndex">The columnIndex of the new column.</param>
        /// <since_tizen> 3 </since_tizen>
        public void InsertColumn(uint columnIndex)
        {
            Interop.TableView.TableView_InsertColumn(swigCPtr, columnIndex);
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
            Interop.TableView.TableView_DeleteColumn__SWIG_0(swigCPtr, columnIndex);
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
            Interop.TableView.TableView_Resize__SWIG_0(swigCPtr, rows, columns);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets the horizontal and the vertical padding between cells.
        /// </summary>
        /// <param name="padding">Width and height.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetCellPadding(Size2D padding)
        {
            Interop.TableView.TableView_SetCellPadding(swigCPtr, Size2D.getCPtr(padding));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the current padding as width and height.
        /// </summary>
        /// <returns>The current padding as width and height.</returns>
        /// <since_tizen> 3 </since_tizen>
        public Vector2 GetCellPadding()
        {
            Vector2 ret = new Vector2(Interop.TableView.TableView_GetCellPadding(swigCPtr), true);
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
            Interop.TableView.TableView_SetFitHeight(swigCPtr, rowIndex);
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
            bool ret = Interop.TableView.TableView_IsFitHeight(swigCPtr, rowIndex);
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
            Interop.TableView.TableView_SetFitWidth(swigCPtr, columnIndex);
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
            bool ret = Interop.TableView.TableView_IsFitWidth(swigCPtr, columnIndex);
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
            Interop.TableView.TableView_SetFixedHeight(swigCPtr, rowIndex, height);
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
            float ret = Interop.TableView.TableView_GetFixedHeight(swigCPtr, rowIndex);
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
            Interop.TableView.TableView_SetRelativeHeight(swigCPtr, rowIndex, heightPercentage);
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
            float ret = Interop.TableView.TableView_GetRelativeHeight(swigCPtr, rowIndex);
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
            Interop.TableView.TableView_SetFixedWidth(swigCPtr, columnIndex, width);
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
            float ret = Interop.TableView.TableView_GetFixedWidth(swigCPtr, columnIndex);
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
            Interop.TableView.TableView_SetRelativeWidth(swigCPtr, columnIndex, widthPercentage);
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
            float ret = Interop.TableView.TableView_GetRelativeWidth(swigCPtr, columnIndex);
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
            Interop.TableView.TableView_SetCellAlignment(swigCPtr, TableView.CellPosition.getCPtr(position), (int)horizontal, (int)vertical);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
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
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.TableView.delete_TableView(swigCPtr);
        }

        /// <summary>
        /// Class to specify the layout position for the child view.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public class CellPosition : Disposable
        {

            /// <summary>
            /// The constructor.
            /// </summary>
            /// <param name="rowIndex">The row index initialized.</param>
            /// <param name="columnIndex">The column index initialized.</param>
            /// <param name="rowSpan">The row span initialized.</param>
            /// <param name="columnSpan">The column span initialized.</param>
            /// <since_tizen> 3 </since_tizen>
            public CellPosition(uint rowIndex, uint columnIndex, uint rowSpan, uint columnSpan) : this(Interop.TableView.new_TableView_CellPosition__SWIG_0(rowIndex, columnIndex, rowSpan, columnSpan), true)
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
            public CellPosition(uint rowIndex, uint columnIndex, uint rowSpan) : this(Interop.TableView.new_TableView_CellPosition__SWIG_1(rowIndex, columnIndex, rowSpan), true)
            {
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }

            /// <summary>
            /// The constructor to initialize values to defaults for convenience.
            /// </summary>
            /// <param name="rowIndex">The row index initialized.</param>
            /// <param name="columnIndex">The column index initialized.</param>
            /// <since_tizen> 3 </since_tizen>
            public CellPosition(uint rowIndex, uint columnIndex) : this(Interop.TableView.new_TableView_CellPosition__SWIG_2(rowIndex, columnIndex), true)
            {
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }

            /// <summary>
            /// The constructor to initialize values to default for convenience.
            /// </summary>
            /// <param name="rowIndex">The row index initialized.</param>
            /// <since_tizen> 3 </since_tizen>
            public CellPosition(uint rowIndex) : this(Interop.TableView.new_TableView_CellPosition__SWIG_3(rowIndex), true)
            {
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }

            /// <summary>
            /// The default constructor.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public CellPosition() : this(Interop.TableView.new_TableView_CellPosition__SWIG_4(), true)
            {
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }

            internal CellPosition(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
            {
            }

            /// <summary>
            /// The index of a row.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [Obsolete("Please do not use! This will be deprecated! Please use RowIndex instead!")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public uint rowIndex
            {
                set
                {
                    Interop.TableView.TableView_CellPosition_rowIndex_set(swigCPtr, value);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
                get
                {
                    uint ret = Interop.TableView.TableView_CellPosition_rowIndex_get(swigCPtr);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                    return ret;
                }
            }

            /// <summary>
            /// The index or position of a row.
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            public uint RowIndex
            {
                get
                {
                    uint ret = Interop.TableView.TableView_CellPosition_rowIndex_get(swigCPtr);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                    return ret;
                }
            }


            /// <summary>
            /// The index of a column.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [Obsolete("Please do not use! This will be deprecated! Please use ColumnIndex instead!")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public uint columnIndex
            {
                set
                {
                    Interop.TableView.TableView_CellPosition_columnIndex_set(swigCPtr, value);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
                get
                {
                    uint ret = Interop.TableView.TableView_CellPosition_columnIndex_get(swigCPtr);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                    return ret;
                }
            }

            /// <summary>
            /// The index or position of a column.
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            public uint ColumnIndex
            {
                get
                {
                    uint ret = Interop.TableView.TableView_CellPosition_columnIndex_get(swigCPtr);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                    return ret;
                }
            }

            /// <summary>
            /// The span of a row.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [Obsolete("Please do not use! This will be deprecated! Please use RowSpan instead!")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public uint rowSpan
            {
                set
                {
                    Interop.TableView.TableView_CellPosition_rowSpan_set(swigCPtr, value);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
                get
                {
                    uint ret = Interop.TableView.TableView_CellPosition_rowSpan_get(swigCPtr);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                    return ret;
                }
            }

            /// <summary>
            /// The span of a row.
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            public uint RowSpan
            {
                get
                {
                    uint ret = Interop.TableView.TableView_CellPosition_rowSpan_get(swigCPtr);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                    return ret;
                }
            }

            /// <summary>
            /// The span of a column.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [Obsolete("Please do not use! This will be deprecated! Please use ColumnSpan instead!")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public uint columnSpan
            {
                set
                {
                    Interop.TableView.TableView_CellPosition_columnSpan_set(swigCPtr, value);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
                get
                {
                    uint ret = Interop.TableView.TableView_CellPosition_columnSpan_get(swigCPtr);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                    return ret;
                }
            }

            /// <summary>
            /// The span of a column.
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            public uint ColumnSpan
            {
                get
                {
                    uint ret = Interop.TableView.TableView_CellPosition_columnSpan_get(swigCPtr);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                    return ret;
                }
            }

            internal static global::System.Runtime.InteropServices.HandleRef getCPtr(CellPosition obj)
            {
                return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
            }

            /// <summary>
            /// Dispose.
            /// </summary>
            /// <param name="type">DisposeTypes</param>
            /// <since_tizen> 3 </since_tizen>
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
                Interop.TableView.delete_TableView_CellPosition(swigCPtr);
        }
        }

        internal new class Property
        {
            internal static readonly int ROWS = Interop.TableView.TableView_Property_ROWS_get();
            internal static readonly int COLUMNS = Interop.TableView.TableView_Property_COLUMNS_get();
            internal static readonly int CELL_PADDING = Interop.TableView.TableView_Property_CELL_PADDING_get();
            internal static readonly int LAYOUT_ROWS = Interop.TableView.TableView_Property_LAYOUT_ROWS_get();
            internal static readonly int LAYOUT_COLUMNS = Interop.TableView.TableView_Property_LAYOUT_COLUMNS_get();
        }

        internal class ChildProperty
        {
            internal static readonly int CELL_INDEX = Interop.TableView.TableView_ChildProperty_CELL_INDEX_get();
            internal static readonly int ROW_SPAN = Interop.TableView.TableView_ChildProperty_ROW_SPAN_get();
            internal static readonly int COLUMN_SPAN = Interop.TableView.TableView_ChildProperty_COLUMN_SPAN_get();
            internal static readonly int CELL_HORIZONTAL_ALIGNMENT = Interop.TableView.TableView_ChildProperty_CELL_HORIZONTAL_ALIGNMENT_get();
            internal static readonly int CELL_VERTICAL_ALIGNMENT = Interop.TableView.TableView_ChildProperty_CELL_VERTICAL_ALIGNMENT_get();
        }
    }
}
