using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NXOpen;
using NXOpen.UF;
using Basic;


namespace DiePlugin.Model
{
    public class PartDrawingModel
    {
        private string filePath;
        private string paperFile;
        private string name;

        public PartDrawingModel(string filePath)
        {
            this.filePath = filePath;
            string dwgName = Path.GetFileNameWithoutExtension(filePath);
            this.paperFile = Path.GetDirectoryName(filePath) + "\\";
            string[] temp = { "_dwg" };
            name = dwgName.Split(temp, StringSplitOptions.RemoveEmptyEntries)[0];
        }
        /// <summary>
        /// 打开文件
        /// </summary>
        /// <returns></returns>
        public Part Open()
        {
            bool isok = true;
            Session theSession = Session.GetSession();
            foreach (Part part in Session.GetSession().Parts)
            {
                if (filePath.Equals(part.FullPath, StringComparison.CurrentCultureIgnoreCase))
                {
                    isok = false;
                    UFSession.GetUFSession().Part.SetDisplayPart(part.Tag);

                    return part;
                }
            }
            if (isok)
            {
                theSession.ApplicationSwitchImmediate("UG_APP_DRAFTING");
                return PartUtils.OpenPartFile(filePath);
            }

            return null;
        }
        /// <summary>
        /// 关闭文件
        /// </summary>
        /// <param name="part"></param>
        public void Close(Part part)
        {
            part.Close(BasePart.CloseWholeTree.True, BasePart.CloseModified.UseResponses, null);
        }
        /// <summary>
        /// 查询是否有图纸
        /// </summary>
        /// <param name="part"></param>
        /// <returns></returns>
        public bool IsDrawing(Part part)
        {
            if (part.DrawingSheets.ToArray().Length > 0)
            {
                part.DrawingSheets.ToArray()[0].Open();
                return true;
            }
            else
                return false;
        }

        public bool ExportPDF(Part part, string outFilePath)
        {
            string pdfFile = outFilePath + "\\" + "PDF" + "\\";
            string pdf = pdfFile + name + ".pdf";
            if (!File.Exists(pdfFile))
                Directory.CreateDirectory(pdfFile);
            if (File.Exists(pdf))
                File.Delete(pdf);
            return ExportFileUtils.PrintPDF(part, pdf);
        }
        public bool ExportDWG(Part part, string outFilePath)
        {
            string dwgFile = outFilePath + "\\" + "DWG" + "\\";
            string dwg = dwgFile + name + ".dwg";
            if (!File.Exists(dwgFile))
                Directory.CreateDirectory(dwgFile);
            if (File.Exists(dwg))
                File.Delete(dwg);
            return ExportFileUtils.PrintDWG(part, dwg);
        }

        public static void DeleteLog(string outFilePath)
        {
            string dwgFile = outFilePath + "\\" + "DWG" + "\\";
            DirectoryInfo info = new DirectoryInfo(dwgFile);
            foreach (FileInfo fi in info.GetFiles())
            {
                string name = fi.Name;
                if (name.LastIndexOf(".log") != -1)
                {
                    File.Delete(fi.FullName);
                }
            }
        }
    }
}
