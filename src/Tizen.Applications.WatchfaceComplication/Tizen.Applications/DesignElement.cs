/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace Tizen.Applications.WatchfaceComplication
{
    /// <summary>
    /// Represents the DesignElement class for the watch application.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public abstract class DesignElement : IEditable
    {

        private IEnumerable<Bundle> _candidates;
        private int _currentDataIndex;
        private Highlight _highlight;
        private string _editableName;
        private int _editableId;

        /// <summary>
        /// Initializes the DesignElement class.
        /// </summary>
        /// <param name="candidates">The candidates list.</param>
        /// <param name="currentDataIndex">The currently selected data index of candidate list.</param>
        /// <param name="editableName">The design element name.</param>
        /// <exception cref="ArgumentException">Thrown when e is invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to invalid operation.</exception>
        /// <exception cref="NotSupportedException">Thrown when the watchface complication is not supported.</exception>
        /// <example>
        /// <code>
        /// public class ColorDesign : DesignElement
        /// {
        ///     private Button _layout;
        ///     private static string _colorKey = "TEST_COLOR";
        ///     public ColorDesign(IEnumerable candidates, int curDataIdx, string editableName, Button layout)
        ///         : base(candidates, curDataIdx, editableName)
        ///     {
        ///         _layout = layout;
        ///     }
        ///     protected override void OnDesignUpdated(int selectedIdx, State state)
        ///     {
        ///         int idx = 0;
        ///         string color = "";
        ///         foreach (Bundle candidate in this.Candidates)
        ///         {
        ///             if (idx++ != selectedIdx)
        ///                 continue;
        ///             color = candidate.GetItem(_colorKey);
        ///             break;
        ///         }
        ///         Log.Warn(_logTag, "Color : " + color);
        ///         if (color.Equals("YELLOW"))
        ///         {
        ///             _layout.BackgroundColor = Color.Yellow;
        ///         }
        ///    }
        /// }
        ///
        /// List&lt;Bundle&gt; candidatesList = new List&lt;Bundle&gt;();
        /// data = new Bundle();
        /// data.AddItem(_colorKey, "RED");
        /// candidatesList.Add(data);
        /// data.AddItem(_colorKey, "BLUE");
        /// candidatesList.Add(data);
        /// ColorDesign colorEdit = new ColorDesign(candidatesList, curIdx, "COLOR", _complicationBtn);
        /// </code>
        /// </example>
        /// <since_tizen> 6 </since_tizen>
        protected DesignElement(IEnumerable<Bundle> candidates, int currentDataIndex, string editableName)
        {
            if (candidates == null || currentDataIndex < 0)
                ErrorFactory.ThrowException(ComplicationError.InvalidParam);
            List<Bundle> candidatesList = candidates.ToList();
            if (candidatesList.Count < currentDataIndex)
                ErrorFactory.ThrowException(ComplicationError.InvalidParam);

            _candidates = candidates;
            _currentDataIndex = currentDataIndex;
            _editableName = editableName;
        }

        /// <summary>
        /// The information of Editable ID.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        int IEditable.EditableId
        {
            get
            {
                return _editableId;
            }
            set
            {
                _editableId = value;
            }
        }

        /// <summary>
        /// The information of Editable candidates.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public IEnumerable<Bundle> Candidates
        {
            get
            {
                return _candidates;
            }
        }

        /// <summary>
        /// The information of Editable name.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        string IEditable.Name
        {
            get
            {
                return _editableName;
            }
            set
            {
                _editableName = value;
            }
        }

        /// <summary>
        /// The information of editable's highlight.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        Highlight IEditable.Highlight
        {
            get
            {
                return _highlight;
            }
            set
            {
                _highlight = value;
            }
        }

        /// <summary>
        /// The information of design element's highlight.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public Highlight Highlight
        {
            get
            {
                return _highlight;
            }
            set
            {
                _highlight = value;
            }
        }

        /// <summary>
        /// Gets the editable's currently selected data index of candidate list.
        /// </summary>
        /// <returns>The currently selected data index of candidate list.</returns>
        /// <since_tizen> 6 </since_tizen>
        int IEditable.GetCurrentDataIndex()
        {
            return _currentDataIndex;
        }

        internal void SetCurrentDataIndex(int idx)
        {
            _currentDataIndex = idx;
        }

        /// <summary>
        /// Gets the editable's currently selected data.
        /// </summary>
        /// <returns>The currently selected data.</returns>
        /// <since_tizen> 6 </since_tizen>
        Bundle IEditable.GetCurrentData()
        {
            int idx = 0;
            foreach (Bundle data in _candidates)
            {
                if (idx == _currentDataIndex)
                    return data;
                idx++;
            }
            return null;
        }

        internal void NotifyUpdate(int candidateIdx, State state)
        {
            OnDesignUpdated(candidateIdx, state);
        }

        /// <summary>
        /// Overrides this method to handle the behavior when the design element is updated.
        /// </summary>
        /// <param name="selectedIdx">The selected candidate index.</param>
        /// <param name="state">The update state.</param>
        /// <since_tizen> 6 </since_tizen>
        protected abstract void OnDesignUpdated(int selectedIdx, State state);
    }
}
