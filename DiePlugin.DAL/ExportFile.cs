using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NXOpen;
using DiePlugin.Model;
using Basic;
using System.Threading;

namespace DiePlugin.DAL
{
    public class ExportFile
    {
        /// <summary>
        /// 获取所有DWG格式图档
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static List<string> GetDWGFile(string filePath)
        {
            List<string> path = new List<string>();
            DirectoryInfo info = new DirectoryInfo(filePath);
            foreach (FileInfo fi in info.GetFiles())
            {
                string name = fi.Name;
                if (name.LastIndexOf("_dwg") != -1)
                    path.Add(filePath + "\\" + fi.Name);
            }
            return path;
        }
        /// <summary>
        /// 导出档案
        /// </summary>
        /// <param name="partPath"></param>
        /// <param name="outPath"></param>
        /// <param name="pdf"></param>
        /// <param name="dwg"></param>
        public static void Export(List<string> partPath, string outPath, bool pdf, bool dwg)
        {
            if (!pdf && !dwg)
                return;
            List<Part> parts = new List<Part>();
            foreach (string st in partPath)
            {
                PartDrawingModel model = new PartDrawingModel(st);
                Part part = model.Open();
                bool isok = model.IsDrawing(part);
                if (isok)
                {
                    parts.Add(part);
                }
                if (pdf && isok)
                {
                    model.ExportPDF(part, outPath);
                }
                if (dwg && isok)
                {
                    model.ExportDWG(part, outPath);

                }
                Thread.Sleep(50);

            }

        }
      
    }
}
