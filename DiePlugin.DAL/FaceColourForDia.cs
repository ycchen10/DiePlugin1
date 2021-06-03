using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NXOpen;

namespace DiePlugin.DAL
{
    /// <summary>
    /// 按直径给面上颜色
    /// </summary>
    public class FaceColourForDia
    {
        public static void SetFaceColour(Face face, double minDia)
        {
            double rid = minDia / 2;
            if (rid >= 0.15)
                return;
            if (rid >= 0.13 && rid < 0.15)
            {
                face.Color = 211;//Blue
                return;
            }
            if (rid >= 0.09 && rid < 0.13)
            {
                face.Color = 31;//Cyan
                return;
            }
            if (rid >= 0.07 && rid < 0.09)
            {
                face.Color = 36;//Medium Violet
                return;
            }
            if (rid >= 0.05 && rid < 0.07)
            {
                face.Color = 185;//Strong Pink
                return;
            }
            if  (rid < 0.05)
            {
                face.Color = 186;//Strong Pink
                return;
            }
        }
    }
}
