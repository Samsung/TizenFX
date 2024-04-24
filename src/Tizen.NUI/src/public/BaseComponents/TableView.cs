/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
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
        public static BindableProperty RowsProperty = null;
        internal static void SetInternalRowsProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var tableView = (TableView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)tableView.SwigCPtr, TableView.Property.ROWS, new Tizen.NUI.PropertyValue((int)newValue));
            }
        }
        internal static object GetInternalRowsProperty(BindableObject bindable)
        {
            var tableView = (TableView)bindable;
            int temp = 0;
            Tizen.NUI.Object.GetProperty((HandleRef)tableView.SwigCPtr, TableView.Property.ROWS).Get(out temp);
            return temp;
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BindableProperty ColumnsProperty = null;
        internal static void SetInternalColumnsProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var tableView = (TableView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)tableView.SwigCPtr, TableView.Property.COLUMNS, new Tizen.NUI.PropertyValue((int)newValue));
            }
        }
        internal static object GetInternalColumnsProperty(BindableObject bindable)
        {
            var tableView = (TableView)bindable;
            int temp = 0;
            Tizen.NUI.Object.GetProperty((HandleRef)tableView.SwigCPtr, TableView.Property.COLUMNS).Get(out temp);
            return temp;
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BindableProperty CellPaddingProperty = null;
        internal static void SetInternalCellPaddingProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var tableView = (TableView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)tableView.SwigCPtr, TableView.Property.CellPadding, new Tizen.NUI.PropertyValue((Vector2)newValue));
            }
        }
        internal static object GetInternalCellPaddingProperty(BindableObject bindable)
        {
            var tableView = (TableView)bindable;
            Vector2 temp = new Vector2(0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty((HandleRef)tableView.SwigCPtr, TableView.Property.CellPadding).Get(temp);
            return temp;
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BindableProperty LayoutRowsProperty = null;
        internal static void SetInternalLayoutRowsProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var tableView = (TableView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)tableView.SwigCPtr, TableView.Property.LayoutRows, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }
        internal static object GetInternalLayoutRowsProperty(BindableObject bindable)
        {
            var tableView = (TableView)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty((HandleRef)tableView.SwigCPtr, TableView.Property.LayoutRows).Get(temp);
            return temp;
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BindableProperty LayoutColumnsProperty = null;
        internal static void SetInternalLayoutColumnsProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var tableView = (TableView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)tableView.SwigCPtr, TableView.Property.LayoutColumns, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }
        internal static object GetInternalLayoutColumnsProperty(BindableObject bindable)
        {
            var tableView = (TableView)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty((HandleRef)tableView.SwigCPtr, TableView.Property.LayoutColumns).Get(temp);
            return temp;
        }

        static TableView()
        {
            if (NUIApplication.IsUsingXaml)
            {

                RowsProperty = BindableProperty.Create(nameof(Rows), typeof(int), typeof(TableView), default(int),
                    propertyChanged: SetInternalRowsProperty, defaultValueCreator: GetInternalRowsProperty);

                ColumnsProperty = BindableProperty.Create(nameof(Columns), typeof(int), typeof(TableView), default(int),
                    propertyChanged: SetInternalColumnsProperty, defaultValueCreator: GetInternalColumnsProperty);

                CellPaddingProperty = BindableProperty.Create(nameof(CellPadding), typeof(Vector2), typeof(TableView), null,
                    propertyChanged: SetInternalCellPaddingProperty, defaultValueCreator: GetInternalCellPaddingProperty);

                LayoutRowsProperty = BindableProperty.Create(nameof(LayoutRows), typeof(PropertyMap), typeof(TableView), null,
                    propertyChanged: SetInternalLayoutRowsProperty, defaultValueCreator: GetInternalLayoutRowsProperty);

                LayoutColumnsProperty = BindableProperty.Create(nameof(LayoutColumns), typeof(PropertyMap), typeof(TableView), null,
                    propertyChanged: SetInternalLayoutColumnsProperty, defaultValueCreator: GetInternalLayoutColumnsProperty);
            }
        }

        /// <summary>
        /// Creates the default TableView view.
        /// </summary>
        public TableView() : this(Interop.TableView.New(1, 1), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Creates the TableView view.
        /// </summary>
        /// <param name="initialRows">Initial rows for the table.</param>
        /// <param name="initialColumns">Initial columns for the table.</param>
        /// <since_tizen> 3 </since_tizen>
        public TableView(uint initialRows, uint initialColumns) : this(Interop.TableView.New(initialRows, initialColumns), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }

        /// <summary>
        /// The Copy constructor. Creates another handle that points to the same real object.
        /// </summary>
        /// <param name="handle">Handle to copy from.</param>
        /// <since_tizen> 3 </since_tizen>
        public TableView(TableView handle) : this(Interop.TableView.NewTableView(TableView.getCPtr(handle)), true, false)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal TableView(global::System.IntPtr cPtr, bool cMemoryOwn) : this(cPtr, cMemoryOwn, cMemoryOwn)
        {
        }

        internal TableView(global::System.IntPtr cPtr, bool cMemoryOwn, bool cRegister) : base(cPtr, cMemoryOwn, true, cRegister)
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (int)GetValue(RowsProperty);
                }
                else
                {
                    return (int)GetInternalRowsProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(RowsProperty, value);
                }
                else
                {
                    SetInternalRowsProperty(this, null, value);
                }
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (int)GetValue(ColumnsProperty);
                }
                else
                {
                    return (int)GetInternalColumnsProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ColumnsProperty, value);
                }
                else
                {
                    SetInternalColumnsProperty(this, null, value);
                }
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (Vector2)GetValue(CellPaddingProperty);
                }
                else
                {
                    return (Vector2)GetInternalCellPaddingProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(CellPaddingProperty, value);
                }
                else
                {
                    SetInternalCellPaddingProperty(this, null, value);
                }
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (PropertyMap)GetValue(LayoutRowsProperty);
                }
                else
                {
                    return (PropertyMap)GetInternalLayoutRowsProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(LayoutRowsProperty, value);
                }
                else
                {
                    SetInternalLayoutRowsProperty(this, null, value);
                }
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (PropertyMap)GetValue(LayoutColumnsProperty);
                }
                else
                {
                    return (PropertyMap)GetInternalLayoutColumnsProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(LayoutColumnsProperty, value);
                }
                else
                {
                    SetInternalLayoutColumnsProperty(this, null, value);
                }
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
            bool ret = Interop.TableView.AddChild(SwigCPtr, View.getCPtr(child), TableView.CellPosition.getCPtr(position));
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
            IntPtr cPtr = Interop.TableView.GetChildAt(SwigCPtr, TableView.CellPosition.getCPtr(position));
            HandleRef CPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
            View ret = Registry.GetManagedBaseHandleFromNativePtr(CPtr.Handle) as View;
            Interop.BaseHandle.DeleteBaseHandle(CPtr);
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
            IntPtr cPtr = Interop.TableView.RemoveChildAt(SwigCPtr, TableView.CellPosition.getCPtr(position));
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
            bool ret = Interop.TableView.FindChildPosition(SwigCPtr, View.getCPtr(child), TableView.CellPosition.getCPtr(position));
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
            Interop.TableView.InsertRow(SwigCPtr, rowIndex);
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
            Interop.TableView.DeleteRow(SwigCPtr, rowIndex);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Inserts a new column to the given index.
        /// </summary>
        /// <param name="columnIndex">The columnIndex of the new column.</param>
        /// <since_tizen> 3 </since_tizen>
        public void InsertColumn(uint columnIndex)
        {
            Interop.TableView.InsertColumn(SwigCPtr, columnIndex);
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
            Interop.TableView.DeleteColumn(SwigCPtr, columnIndex);
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
            Interop.TableView.Resize(SwigCPtr, rows, columns);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets the horizontal and the vertical padding between cells.
        /// </summary>
        /// <param name="padding">Width and height.</param>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("This has been deprecated in API9 and will be removed in API11. Use CellPadding property instead.")]
        public void SetCellPadding(Size2D padding)
        {
            Interop.TableView.SetCellPadding(SwigCPtr, Size2D.getCPtr(padding));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the current padding as width and height.
        /// </summary>
        /// <returns>The current padding as width and height.</returns>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("This has been deprecated in API9 and will be removed in API11. Use CellPadding property instead.")]
        public Vector2 GetCellPadding()
        {
            Vector2 ret = new Vector2(Interop.TableView.GetCellPadding(SwigCPtr), true);
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
            Interop.TableView.SetFitHeight(SwigCPtr, rowIndex);
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
            bool ret = Interop.TableView.IsFitHeight(SwigCPtr, rowIndex);
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
            Interop.TableView.SetFitWidth(SwigCPtr, columnIndex);
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
            bool ret = Interop.TableView.IsFitWidth(SwigCPtr, columnIndex);
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
            Interop.TableView.SetFixedHeight(SwigCPtr, rowIndex, height);
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
            float ret = Interop.TableView.GetFixedHeight(SwigCPtr, rowIndex);
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
            Interop.TableView.SetRelativeHeight(SwigCPtr, rowIndex, heightPercentage);
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
            float ret = Interop.TableView.GetRelativeHeight(SwigCPtr, rowIndex);
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
            Interop.TableView.SetFixedWidth(SwigCPtr, columnIndex, width);
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
            float ret = Interop.TableView.GetFixedWidth(SwigCPtr, columnIndex);
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
            Interop.TableView.SetRelativeWidth(SwigCPtr, columnIndex, widthPercentage);
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
            float ret = Interop.TableView.GetRelativeWidth(SwigCPtr, columnIndex);
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
            Interop.TableView.SetCellAlignment(SwigCPtr, TableView.CellPosition.getCPtr(position), (int)horizontal, (int)vertical);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.TableView.DeleteTableView(swigCPtr);
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
            public CellPosition(uint rowIndex, uint columnIndex, uint rowSpan, uint columnSpan) : this(Interop.TableView.NewTableViewCellPosition(rowIndex, columnIndex, rowSpan, columnSpan), true)
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
            public CellPosition(uint rowIndex, uint columnIndex, uint rowSpan) : this(Interop.TableView.NewTableViewCellPosition(rowIndex, columnIndex, rowSpan), true)
            {
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }

            /// <summary>
            /// The constructor to initialize values to defaults for convenience.
            /// </summary>
            /// <param name="rowIndex">The row index initialized.</param>
            /// <param name="columnIndex">The column index initialized.</param>
            /// <since_tizen> 3 </since_tizen>
            public CellPosition(uint rowIndex, uint columnIndex) : this(Interop.TableView.NewTableViewCellPosition(rowIndex, columnIndex), true)
            {
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }

            /// <summary>
            /// The constructor to initialize values to default for convenience.
            /// </summary>
            /// <param name="rowIndex">The row index initialized.</param>
            /// <since_tizen> 3 </since_tizen>
            public CellPosition(uint rowIndex) : this(Interop.TableView.NewTableViewCellPosition(rowIndex), true)
            {
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }

            /// <summary>
            /// The default constructor.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public CellPosition() : this(Interop.TableView.NewTableViewCellPosition(), true)
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
            [Obsolete("Do not use this, that will be deprecated. Use RowIndex instead.")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public uint rowIndex
            {
                set
                {
                    Interop.TableView.CellPositionRowIndexSet(SwigCPtr, value);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
                get
                {
                    uint ret = Interop.TableView.CellPositionRowIndexGet(SwigCPtr);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
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
                    uint ret = Interop.TableView.CellPositionRowIndexGet(SwigCPtr);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                    return ret;
                }
            }


            /// <summary>
            /// The index of a column.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [Obsolete("Do not use this, that will be deprecated. Use ColumnIndex instead.")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public uint columnIndex
            {
                set
                {
                    Interop.TableView.CellPositionColumnIndexSet(SwigCPtr, value);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
                get
                {
                    uint ret = Interop.TableView.CellPositionColumnIndexGet(SwigCPtr);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
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
                    uint ret = Interop.TableView.CellPositionColumnIndexGet(SwigCPtr);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                    return ret;
                }
            }

            /// <summary>
            /// The span of a row.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [Obsolete("Do not use this, that will be deprecated. Use RowSpan instead.")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public uint rowSpan
            {
                set
                {
                    Interop.TableView.CellPositionRowSpanSet(SwigCPtr, value);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
                get
                {
                    uint ret = Interop.TableView.CellPositionRowSpanGet(SwigCPtr);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
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
                    uint ret = Interop.TableView.CellPositionRowSpanGet(SwigCPtr);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                    return ret;
                }
            }

            /// <summary>
            /// The span of a column.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            [Obsolete("Do not use this, that will be deprecated. Use ColumnSpan instead.")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public uint columnSpan
            {
                set
                {
                    Interop.TableView.CellPositionColumnSpanSet(SwigCPtr, value);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
                get
                {
                    uint ret = Interop.TableView.CellPositionColumnSpanGet(SwigCPtr);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
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
                    uint ret = Interop.TableView.CellPositionColumnSpanGet(SwigCPtr);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                    return ret;
                }
            }

            /// This will not be public opened.
            [EditorBrowsable(EditorBrowsableState.Never)]
            protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
            {
                Interop.TableView.DeleteTableViewCellPosition(swigCPtr);
            }
        }

        internal new class Property
        {
            internal static readonly int ROWS = Interop.TableView.RowsGet();
            internal static readonly int COLUMNS = Interop.TableView.ColumnsGet();
            internal static readonly int CellPadding = Interop.TableView.CellPaddingGet();
            internal static readonly int LayoutRows = Interop.TableView.LayoutRowsGet();
            internal static readonly int LayoutColumns = Interop.TableView.LayoutColumnsGet();
        }

        internal class ChildProperty
        {
            internal static readonly int CellIndex = Interop.TableView.ChildPropertyCellIndexGet();
            internal static readonly int RowSpan = Interop.TableView.ChildPropertyRowSpanGet();
            internal static readonly int ColumnSpan = Interop.TableView.ChildPropertyColumnSpanGet();
            internal static readonly int CellHorizontalAlignment = Interop.TableView.ChildPropertyCellHorizontalAlignmentGet();
            internal static readonly int CellVerticalAlignment = Interop.TableView.ChildPropertyCellVerticalAlignmentGet();
        }
    }
}
