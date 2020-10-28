using System;
using System.Collections.Generic;
using System.Text;

namespace Efl
{
    namespace Ui
    {
        namespace Wearable
        {
            public interface ICircleColor
            {
                void SetColor(int r, int g, int b, int a);
                void GetColor(out int r, out int g, out int b, out int a);
            }
        }
    }
}
