using System.Collections.Generic;
using System.ComponentModel;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components
{
    public partial class DropDown
    {

        /// <summary>
        /// DropDownListBridge is bridge to connect item data and an item View.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class DropDownListBridge
        {
            private List<DropDownDataItem> itemDataList = new List<DropDownDataItem>();

            internal bool AdapterPurge { get; set; } = false;  // Set to true if adapter content changed since last iteration.

            /// <summary>
            /// Creates a new instance of a DropDownListBridge.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public DropDownListBridge() { }

            /// <summary>
            /// Insert data. The inserted data will be added to the special position by index automatically.
            /// </summary>
            /// <param name="position">Position index where will be inserted.</param>
            /// <param name="data">Item data which will apply to tab item view.</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void InsertData(int position, DropDownDataItem data)
            {
                if (position == -1)
                {
                    position = itemDataList.Count;
                }
                itemDataList.Insert(position, data);
                AdapterPurge = true;
            }

            /// <summary>
            /// Remove data by position.
            /// </summary>
            /// <param name="position">Position index where will be removed.</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void RemoveData(int position)
            {
                itemDataList.RemoveAt(position);
                AdapterPurge = true;
            }

            /// <summary>
            /// Get data by position.
            /// </summary>
            /// <param name="position">Position index where will be gotten.</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public DropDownDataItem GetData(int position)
            {
                return itemDataList[position];
            }

            /// <summary>
            /// Get view holder by view type.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public ViewHolder OnCreateViewHolder()
            {
                ViewHolder viewHolder = new ViewHolder(new DropDownItemView());

                return viewHolder;
            }

            /// <summary>
            /// Bind ViewHolder with View.
            /// </summary>
            /// <param name="holder">View holder.</param>
            /// <param name="position">Position index of source data.</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void BindViewHolder(ViewHolder holder, int position)
            {
                if (null == holder) return;
                DropDownDataItem listItemData = itemDataList[position];
                if (listItemData == null)
                {
                    return;
                }
                DropDownItemView listItemView = holder.ItemView as DropDownItemView;
                listItemView.Name = "Item" + position;
                if (listItemData.Size != null)
                {
                    if (listItemData.Size.Width > 0)
                    {
                        holder.ItemView.WidthSpecification = (int)listItemData.Size.Width;
                    }
                    else
                    {
                        holder.ItemView.WidthSpecification = LayoutParamPolicies.MatchParent;
                    }

                    if (listItemData.Size.Height > 0)
                    {
                        holder.ItemView.HeightSpecification = (int)listItemData.Size.Height;
                    }
                    else
                    {
                        holder.ItemView.HeightSpecification = LayoutParamPolicies.MatchParent;
                    }
                }

                if (listItemView != null)
                {
                    listItemView.BackgroundColorSelector = listItemData.BackgroundColor;
                    if (listItemData.Text != null)
                    {
                        listItemView.Text = listItemData.Text;
                        listItemView.PointSize = listItemData.PointSize;
                        listItemView.FontFamily = listItemData.FontFamily;
                        listItemView.TextPosition = listItemData.TextPosition;
                    }

                    if (listItemData.IconResourceUrl != null)
                    {
                        listItemView.IconResourceUrl = listItemData.IconResourceUrl;
                        listItemView.IconSize = listItemData.IconSize;
                        if (listItemView.IconSize != null)
                        {
                            listItemView.IconPosition = new Position(listItemData.IconPosition.X, (listItemView.Size2D.Height - listItemView.IconSize.Height) / 2);
                        }
                    }

                    if (listItemData.CheckImageResourceUrl != null)
                    {
                        listItemView.CheckResourceUrl = listItemData.CheckImageResourceUrl;

                        if (null != listItemData.CheckImageSize)
                        {
                            listItemView.CheckImageSize = listItemData.CheckImageSize;
                        }

                        if (listItemView.CheckImageSize != null)
                        {
                            listItemView.CheckPosition = new Position(listItemView.Size2D.Width - listItemData.CheckImageGapToBoundary - listItemView.CheckImageSize.Width, (listItemView.Size2D.Height - listItemView.CheckImageSize.Height) / 2);
                        }
                    }

                    listItemView.IsSelected = listItemData.IsSelected;
                }
            }

            /// <summary>
            /// Destroy view holder, it can be override.
            /// </summary>
            /// <param name="holder">View holder.</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void OnDestroyViewHolder(ViewHolder holder)
            {
                if (null == holder) return;
                if (holder.ItemView != null)
                {
                    holder.ItemView.Dispose();
                }
            }

            /// <summary>
            /// Get item count, it can be override.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public int GetItemCount()
            {
                return itemDataList.Count;
            }
        }
    }
}
