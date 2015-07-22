using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    class SharedMethods
    {
        internal void RemoveTrailingZeros(float from, float to, out string fromAnswerForDisplay, out string toAnswerForDisplay)
        {
            if (from == 0)
            {
                fromAnswerForDisplay = "0";
                toAnswerForDisplay = "0";
            }
            else if (to <= 0.009f)
            {
                fromAnswerForDisplay = from.ToString();
                toAnswerForDisplay = "< 0.01";
            }
            else
            {
                fromAnswerForDisplay = from.ToString("N");
                fromAnswerForDisplay = fromAnswerForDisplay.TrimEnd('0');
                fromAnswerForDisplay = fromAnswerForDisplay.TrimEnd('.');

                toAnswerForDisplay = to.ToString("N");
                toAnswerForDisplay = toAnswerForDisplay.TrimEnd('0');
                toAnswerForDisplay = toAnswerForDisplay.TrimEnd('.');
            }
        }
    }
}
