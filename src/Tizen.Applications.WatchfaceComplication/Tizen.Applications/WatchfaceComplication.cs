using System;
using System.Collections.Generic;

namespace Tizen.Applications.WatchfaceComplication
{
    public class Complication : IEditable
    {
        Bundle IEditable.LastContext
        {
            get
            {
                return null;
            }
            set
            {
            }
        }

        Bundle IEditable.Context
        {
            get
            {
                return null;
            }
            set
            {
            }
        }
        string IEditable.SetupAppId
        {
            get
            {
                return null;
            }
            set
            {
            }
        }

        EditableState IEditable.State
        {
            get
            {
                return EditableState.Cancel;
            }
            set
            {
            }
        }
        int IEditable.EditableId
        {
            get
            {
                return 0;
            }
            set
            {
            }
        }
        EditableGeometry IEditable.Geometry
        {
            get
            {
                return null;
            }
            set
            {
            }
        }
        IEnumerable<Bundle> IEditable.Candidates
        {
            get
            {
                return null;
            }
            set
            {
            }
        }
        int IEditable.CurrentDataIndex
        {
            get
            {
                return 0;
            }
            set
            {
            }
        }
        int IEditable.LastDataIndex
        {
            get
            {
                return 0;
            }
            set
            {
            }
        }
        string IEditable.Label
        {
            get
            {
                return null;
            }
            set
            {
            }
        }
        EditableShapeType IEditable.ShapeType
        {
            get
            {
                return EditableShapeType.Circle;
            }
            set
            {
            }
        }

        Bundle IEditable.GetNthData(int index)
        {
            throw new NotImplementedException();
        }

        void IEditable.OnEditableUpdated(int selectedIdx, EditableState state)
        {
            throw new NotImplementedException();
        }

        int IEditable.UpdateLastContext()
        {
            throw new NotImplementedException();
        }
    }
}
