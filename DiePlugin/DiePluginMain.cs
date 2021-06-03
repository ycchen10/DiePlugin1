using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NXOpen;
using NXOpen.Utilities;
using NXOpen.UF;
using Basic;

namespace DiePlugin
{
    public class DiePluginMain
    {
        public static int Main(string[] args)
        {

            if (args[0] == "MENU_BatchExportDrawing")
            {
                BatchExportDrawing batch = new BatchExportDrawing();
                batch.Show();

            }
            if (args[0] == "MENU_DimensionMinRad")
            {
                DimensionMinRad dim = new DimensionMinRad();
                dim.Show();

            }
          
            return 1;
        }
        /// <summary>
        /// 卸载函数
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public static int GetUnloadOption(string arg)
        {
            // return System.Convert.ToInt32(Session.LibraryUnloadOption.Explicitly);
            return System.Convert.ToInt32(Session.LibraryUnloadOption.Immediately);
            // return System.Convert.ToInt32(Session.LibraryUnloadOption.AtTermination);
        }

    }
}
