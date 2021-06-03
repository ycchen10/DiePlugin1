using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NXOpen;
using System.Threading;

namespace Basic
{
    /// <summary>
    /// 导出文件
    /// </summary>
    public class ExportFileUtils
    {
        /// <summary>
        /// 导出PDF档
        /// </summary>
        /// <param name="part"></param>
        /// <param name="fileName">导出路径</param>
        /// <returns></returns>
        public static bool PrintPDF(Part part, string fileName)
        {
            NXOpen.PrintPDFBuilder printPDFBuilder1;
            printPDFBuilder1 = part.PlotManager.CreatePrintPdfbuilder();
            printPDFBuilder1.Scale = 1.0;
            printPDFBuilder1.Colors = NXOpen.PrintPDFBuilder.Color.BlackOnWhite;
            printPDFBuilder1.Widths = NXOpen.PrintPDFBuilder.Width.SingleWidth;
            printPDFBuilder1.Size = NXOpen.PrintPDFBuilder.SizeOption.ScaleFactor;
            printPDFBuilder1.RasterImages = true;
            printPDFBuilder1.Watermark = "";

            //NXOpen.NXObject[] sheets1 = new NXOpen.NXObject[1];
            //NXOpen.Drawings.DrawingSheet drawingSheet1 = (NXOpen.Drawings.DrawingSheet)workPart.DrawingSheets.FindObject("Sheet_001");
            //sheets1[0] = drawingSheet1;
            printPDFBuilder1.SourceBuilder.SetSheets(part.DrawingSheets.ToArray());
            printPDFBuilder1.Filename = fileName;
            try
            {
                NXOpen.NXObject nXObject1;
                nXObject1 = printPDFBuilder1.Commit();
                return true;
            }
            catch (NXException ex)
            {
                LogMgr.WriteLog("ExportFileUtils.PrintPDF             " + ex.Message);
                return false;
            }
            finally
            {
                printPDFBuilder1.Destroy();
            }
        }
        /// <summary>
        /// 导出DWG档
        /// </summary>
        /// <param name="part"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool PrintDWG(Part part, string fileName)
        {
            ConsoleHelper.HideConsole("Exporting to DXFDWG File");
            NXOpen.DxfdwgCreator dxfdwgCreator1;
            dxfdwgCreator1 = Session.GetSession().DexManager.CreateDxfdwgCreator();

            dxfdwgCreator1.ExportData = NXOpen.DxfdwgCreator.ExportDataOption.Drawing;

            dxfdwgCreator1.AutoCADRevision = NXOpen.DxfdwgCreator.AutoCADRevisionOptions.R2004;

            dxfdwgCreator1.ViewEditMode = true;

            dxfdwgCreator1.FlattenAssembly = true;

            dxfdwgCreator1.ExportScaleValue = 1.0;

            dxfdwgCreator1.InputFile = part.FullPath;

            dxfdwgCreator1.OutputFile = fileName;
            dxfdwgCreator1.OutputFileType = NXOpen.DxfdwgCreator.OutputFileTypeOption.Dxf;


            dxfdwgCreator1.WidthFactorMode = NXOpen.DxfdwgCreator.WidthfactorMethodOptions.AutomaticCalculation;


            dxfdwgCreator1.LayerMask = "1-256";
            dxfdwgCreator1.ProcessHoldFlag = true;

            try
            {
                foreach (NXOpen.Drawings.DrawingSheet sheet in part.DrawingSheets)
                {
                    dxfdwgCreator1.DrawingList = sheet.Name;
                    NXOpen.NXObject nXObject1;
                    nXObject1 = dxfdwgCreator1.Commit();
                    Thread.Sleep(5);
                    ConsoleHelper.HideConsole("Exporting to DXFDWG File");
                }

                return true;
            }
            catch (NXException ex)
            {
                LogMgr.WriteLog("ExportFileUtils.PrintDWG             " + ex.Message);
                return false;
            }
            finally
            {
                dxfdwgCreator1.Destroy();

            }

        }
    }
}
