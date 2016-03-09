using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tizen.Applications
{
    internal class ContextGroup
    {
        private List<Context> _contextList;

        public bool IsEmpty
        {
            get
            {
                return _contextList.Count == 0;
            }
        }

        public Context TopContext
        {
            get
            {
                return _contextList.LastOrDefault(null);
            }
        }

        public ContextGroup()
        {
            _contextList = new List<Context>();
        }

        public void AddContext(Context ctx)
        {
            _contextList.Add(ctx);
        }

        public void RemoveContext(Context ctx)
        {
            _contextList.Remove(ctx);
        }

        public Context FindContext(Type type)
        {
            return _contextList.Find(s => s.GetType() == type);
        }

        public Context FindContext(Context ctx)
        {
            return _contextList.Find(s => s == ctx);
        }

        public Context MoveToTop(Context ctx)
        {
            var found = FindContext(ctx);
            if (found != null)
            {
                _contextList.Remove(found);
                _contextList.Add(found);
            }
            return found;
        }
    }
}
