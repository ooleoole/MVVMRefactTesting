using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PointManager.ViewModels.UNIT;

namespace PointManagerTests.MovmentSimulator
{
    internal class OrientationSimulator
    {
        internal static void LookDirectionSimulator(iCameraProperties instance, bool moveDirectionFlag)
        {

            if (moveDirectionFlag)
            {
                instance.degH += 0.1;
            }
            else
            {
                instance.degV += 0.1;
            }
        }
    }
}
