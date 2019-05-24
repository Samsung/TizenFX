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
using Tizen.NUI;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Xaml.Forms.BaseComponents
{

    /// <summary>
    /// TableView is a layout container for aligning child actors in a grid like layout.<br />
    /// TableView constraints the X and the Y position and the width and the height of the child actors.<br />
    /// The Z position and depth are left intact so that the 3D model actors can also be laid out
    /// in a grid without loosing their depth scaling.<br />
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class TableView : View
    {
        private Tizen.NUI.BaseComponents.TableView _tableView;
        internal Tizen.NUI.BaseComponents.TableView tableView
        {
            get
            {
                if (null == _tableView)
                {
                    _tableView = handleInstance as Tizen.NUI.BaseComponents.TableView;
                }

                return _tableView;
            }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TableView() : this(new Tizen.NUI.BaseComponents.TableView())
        {
        }

        internal TableView(Tizen.NUI.BaseComponents.TableView nuiInstance) : base(nuiInstance)
        {
            SetNUIInstance(nuiInstance);
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty RowsProperty = Binding.BindableProperty.Create("Rows", typeof(int), typeof(TableView), default(int), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var tableView = ((TableView)bindable).tableView;
            tableView.Rows = (int)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var tableView = ((TableView)bindable).tableView;
            return tableView.Rows;
        });
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty ColumnsProperty = Binding.BindableProperty.Create("Columns", typeof(int), typeof(TableView), default(int), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var tableView = ((TableView)bindable).tableView;
            tableView.Columns = (int)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var tableView = ((TableView)bindable).tableView;
            return tableView.Columns;
        });
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty CellPaddingProperty = Binding.BindableProperty.Create("CellPadding", typeof(Vector2), typeof(TableView), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var tableView = ((TableView)bindable).tableView;
            tableView.CellPadding = (Vector2)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var tableView = ((TableView)bindable).tableView;
            return tableView.CellPadding;
        });
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty LayoutRowsProperty = Binding.BindableProperty.Create("LayoutRows", typeof(PropertyMap), typeof(TableView), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var tableView = ((TableView)bindable).tableView;
            tableView.LayoutRows = (PropertyMap)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var tableView = ((TableView)bindable).tableView;
            return tableView.LayoutRows;
        });
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty LayoutColumnsProperty = Binding.BindableProperty.Create("LayoutColumns", typeof(PropertyMap), typeof(TableView), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var tableView = ((TableView)bindable).tableView;
            tableView.LayoutColumns = (PropertyMap)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var tableView = ((TableView)bindable).tableView;
            return tableView.LayoutColumns;
        });

        /// <summary>
        /// Adds a child to the table.<br />
        /// If the row or column index is outside the table, the table gets resized bigger.<br />
        /// </summary>
        /// <param name="child">The child to add.</param>
        /// <param name="position">The position for the child.</param>
        /// <returns>True if the addition succeeded, and false if the cell is already occupied.</returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool AddChild(View child, Tizen.NUI.BaseComponents.TableView.CellPosition position)
        {
            return tableView.AddChild(child.view, position);
        }

        /// <summary>
        /// Returns a child from the given layout position.
        /// </summary>
        /// <param name="position">The position in the table.</param>
        /// <returns>Child that was in the cell or an uninitialized handle.</returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public View GetChildAt(Tizen.NUI.BaseComponents.TableView.CellPosition position)
        {
            return BaseHandle.GetHandle(tableView.GetChildAt(position)) as View;
        }

        /// <summary>
        /// Removes a child from the given layout position.
        /// </summary>
        /// <param name="position">The position for the child to remove.</param>
        /// <returns>Child that was removed or an uninitialized handle.</returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public View RemoveChildAt(Tizen.NUI.BaseComponents.TableView.CellPosition position)
        {
            return BaseHandle.GetHandle(tableView.RemoveChildAt(position)) as View;
        }

        /// <summary>
        /// Finds the child's layout position.
        /// </summary>
        /// <param name="child">The child to search for.</param>
        /// <param name="position">The position for the child.</param>
        /// <returns>True if the child was included in this TableView.</returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool FindChildPosition(View child, Tizen.NUI.BaseComponents.TableView.CellPosition position)
        {
            return tableView.FindChildPosition(child.view, position);
        }

        /// <summary>
        /// Inserts a new row to the given index.
        /// </summary>
        /// <param name="rowIndex">The rowIndex of the new row.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void InsertRow(uint rowIndex)
        {
            tableView.InsertRow(rowIndex);
        }

        /// <summary>
        /// Deletes a row from the given index.<br />
        /// Removed elements are deleted.<br />
        /// </summary>
        /// <param name="rowIndex">The rowIndex of the row to delete.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void DeleteRow(uint rowIndex)
        {
            tableView.DeleteRow(rowIndex);
        }

        /// <summary>
        /// Inserts a new column to the given index.
        /// </summary>
        /// <param name="columnIndex">The columnIndex of the new column.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void InsertColumn(uint columnIndex)
        {
            tableView.InsertColumn(columnIndex);
        }

        /// <summary>
        /// Deletes a column from the given index.<br />
        /// Removed elements are deleted.<br />
        /// </summary>
        /// <param name="columnIndex">The columnIndex of the column to delete.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void DeleteColumn(uint columnIndex)
        {
            tableView.DeleteColumn(columnIndex);
        }

        /// <summary>
        /// Resizes the TableView.
        /// </summary>
        /// <param name="rows">The rows for the table.</param>
        /// <param name="columns">The columns for the table.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Resize(uint rows, uint columns)
        {
            tableView.Resize(rows, columns);
        }

        /// <summary>
        /// Sets the horizontal and the vertical padding between cells.
        /// </summary>
        /// <param name="padding">Width and height.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetCellPadding(Size2D padding)
        {
            tableView.SetCellPadding(padding);
        }

        /// <summary>
        /// Gets the current padding as width and height.
        /// </summary>
        /// <returns>The current padding as width and height.</returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 GetCellPadding()
        {
            return tableView.GetCellPadding();
        }

        /// <summary>
        /// Specifies this row as fitting its height to its children.
        /// </summary>
        /// <param name="rowIndex">The row to set.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetFitHeight(uint rowIndex)
        {
            tableView.SetFitHeight(rowIndex);
        }

        /// <summary>
        /// Checks if the row is a fit row.
        /// </summary>
        /// <param name="rowIndex">The row to check.</param>
        /// <returns>True if the row is fit.</returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsFitHeight(uint rowIndex)
        {
            return tableView.IsFitHeight(rowIndex);
        }

        /// <summary>
        /// Specifies this column as fitting its width to its children.
        /// </summary>
        /// <param name="columnIndex">The column to set.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetFitWidth(uint columnIndex)
        {
            tableView.SetFitWidth(columnIndex);
        }

        /// <summary>
        /// Checks if the column is a fit column.
        /// </summary>
        /// <param name="columnIndex">The column to check.</param>
        /// <returns>True if the column is fit.</returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsFitWidth(uint columnIndex)
        {
            return tableView.IsFitWidth(columnIndex);
        }

        /// <summary>
        /// Sets a row to have a fixed height.<br />
        /// Setting a fixed height of 0 has no effect.<br />
        /// </summary>
        /// <param name="rowIndex">The rowIndex for row with a fixed height.</param>
        /// <param name="height">The height in world coordinate units.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetFixedHeight(uint rowIndex, float height)
        {
            tableView.SetFixedHeight(rowIndex, height);
        }

        /// <summary>
        /// Gets a row's fixed height.
        /// </summary>
        /// <param name="rowIndex">The row index with a fixed height.</param>
        /// <returns>height The height in world coordinate units.</returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float GetFixedHeight(uint rowIndex)
        {
            return tableView.GetFixedHeight(rowIndex);
        }

        /// <summary>
        /// Sets a row to have a relative height. Relative height means percentage of
        /// the remainder of the table height after subtracting padding and fixed height rows.<br />
        /// Setting a relative height of 0 has no effect.<br />
        /// </summary>
        /// <param name="rowIndex">The rowIndex for row with a relative height.</param>
        /// <param name="heightPercentage">The height percentage between 0.0f and 1.0f.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetRelativeHeight(uint rowIndex, float heightPercentage)
        {
            tableView.SetRelativeHeight(rowIndex, heightPercentage);
        }

        /// <summary>
        /// Gets a row's relative height.
        /// </summary>
        /// <param name="rowIndex">The row index with a relative height.</param>
        /// <returns>Height in percentage units, between 0.0f and 1.0f.</returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float GetRelativeHeight(uint rowIndex)
        {
            return tableView.GetRelativeHeight(rowIndex);
        }

        /// <summary>
        /// Sets a column to have a fixed width.<br />
        /// Setting a fixed width of 0 has no effect.<br />
        /// </summary>
        /// <param name="columnIndex">The columnIndex for column with a fixed width.</param>
        /// <param name="width">The width in world coordinate units.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetFixedWidth(uint columnIndex, float width)
        {
            tableView.SetFixedWidth(columnIndex, width);
        }

        /// <summary>
        /// Gets a column's fixed width.
        /// </summary>
        /// <param name="columnIndex">The column index with a fixed width.</param>
        /// <returns>Width in world coordinate units.</returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float GetFixedWidth(uint columnIndex)
        {
            return tableView.GetFixedWidth(columnIndex);
        }

        /// <summary>
        /// Sets a column to have a relative width. Relative width means percentage of
        /// the remainder of the table width after subtracting padding and fixed width columns.<br />
        /// Setting a relative width of 0 has no effect.<br />
        /// </summary>
        /// <param name="columnIndex">The columnIndex for column with a fixed width.</param>
        /// <param name="widthPercentage">The widthPercentage between 0.0f and 1.0f.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetRelativeWidth(uint columnIndex, float widthPercentage)
        {
            tableView.SetRelativeWidth(columnIndex, widthPercentage);
        }

        /// <summary>
        /// Gets a column's relative width.
        /// </summary>
        /// <param name="columnIndex">The column index with a relative width.</param>
        /// <returns>Width in percentage units, between 0.0f and 1.0f.</returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float GetRelativeWidth(uint columnIndex)
        {
            return tableView.GetRelativeWidth(columnIndex);
        }

        /// <summary>
        /// Sets the alignment on a cell.<br />
        /// Cells without calling this function have the default values of left and top respectively.<br />
        /// </summary>
        /// <param name="position">The cell to set alignment on.</param>
        /// <param name="horizontal">The horizontal alignment.</param>
        /// <param name="vertical">The vertical alignment.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetCellAlignment(Tizen.NUI.BaseComponents.TableView.CellPosition position, HorizontalAlignmentType horizontal, VerticalAlignmentType vertical)
        {
            tableView.SetCellAlignment(position, horizontal, vertical);
        }

        /// <summary>
        /// The amount of rows in the table.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int Rows
        {
            get
            {
                return (int)GetValue(RowsProperty);
            }
            set
            {
                SetValue(RowsProperty, value);
            }
        }
        /// <summary>
        /// The amount of columns in the table.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int Columns
        {
            get
            {
                return (int)GetValue(ColumnsProperty);
            }
            set
            {
                SetValue(ColumnsProperty, value);
            }
        }
        /// <summary>
        /// Padding between cells.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 CellPadding
        {
            get
            {
                return (Vector2)GetValue(CellPaddingProperty);
            }
            set
            {
                SetValue(CellPaddingProperty, value);
            }
        }

        /// <summary>
        /// The number of layout rows.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyMap LayoutRows
        {
            get
            {
                return (PropertyMap)GetValue(LayoutRowsProperty);
            }
            set
            {
                SetValue(LayoutRowsProperty, value);
            }
        }

        /// <summary>
        /// The number of layout columns.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyMap LayoutColumns
        {
            get
            {
                return (PropertyMap)GetValue(LayoutColumnsProperty);
            }
            set
            {
                SetValue(LayoutColumnsProperty, value);
            }
        }
    }
}
