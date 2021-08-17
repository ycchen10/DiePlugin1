using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NXOpen;
using NXOpen.UF;
using NXOpen.Utilities;
using NXOpen.Drawings;
using Basic;
using DiePlugin.DAL;
using System.IO;

namespace ExportDwgForWEDM
{
    public class ExportDWG
    {
        private static Session theSession = Session.GetSession();
        private static UFSession theUFSession = UFSession.GetUFSession();
        private string _saveAsFile = null;
        private string _partPath = null;
        public ExportDWG(string saveAsFile, string partPath)
        {
            //  theUFSession.UF.SetVariable(" UGII_LOAD_OPTIONS", @"C:\Users\ycchen10\OneDrive - kochind.com\Desktop\MolexPlugIn-1899\Part\load_options.def");
            this._saveAsFile = saveAsFile;
            _partPath = partPath;
        }
        /// <summary>
        /// 打开文件
        /// </summary>
        /// <param name="partTag"></param>
        /// <returns></returns>
        private bool Open(out Tag partTag)
        {
            partTag = Tag.Null;
            if (_partPath == null)
                return false;
            try
            {
                UFPart.LoadStatus err;
                theUFSession.Part.Open(_partPath, out partTag, out err);
                if (partTag != Tag.Null)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 关闭零件
        /// </summary>
        /// <param name="partTag"></param>
        private void Close(Tag partTag)
        {
            try
            {
                //bool anyPartsModified1;
                //NXOpen.PartSaveStatus partSaveStatus1;
                //theSession.Parts.SaveAll(out anyPartsModified1, out partSaveStatus1);
                theUFSession.Part.CloseAll();
            }
            catch
            {

            }
        }
        /// <summary>
        /// 设置颜色
        /// </summary>
        /// <param name="partTag"></param>
        private void SetColour(Part part)
        {
            //Part part = NXObjectManager.Get(partTag) as Part;
            NXOpen.Assemblies.Component ct = part.ComponentAssembly.RootComponent;
            if (ct != null)
            {
                foreach (NXOpen.Assemblies.Component cmp in ct.GetChildren())
                {
                    GetBodyForComp(cmp);
                }
                PartUtils.SetPartDisplay(part);
            }
            else
            {
                foreach (Body by in part.Bodies)
                {
                    by.Color = 1;
                    foreach (Face fe in by.GetFaces())
                    {
                        SetFaceColour(fe);
                    }
                }
            }
        }
        /// <summary>
        /// 设置面颜色
        /// </summary>
        /// <param name="face"></param>
        private void SetFaceColour(Face face)
        {
            face.Color = 1;
            if (face == null)
                return;
            if (face.SolidFaceType == Face.FaceType.Cylindrical || face.SolidFaceType == Face.FaceType.Conical)
            {
                try
                {
                    AbstractFaceSlopeAndDia abs = FaceSlopeAndDiaFactory.CreateFaceSlopeAndDia(face);
                    if (abs.Data.IntNorm == -1)
                    {
                        double[] slope;
                        double[] dia;
                        abs.GetSlopeAndDia(new Vector3d(0, 0, 1), out slope, out dia);
                        FaceColourForDia.SetFaceColour(face, dia[0]);
                    }
                }
                catch
                {

                }
            }
        }
        /// <summary>
        /// 递归改颜色
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        private void GetBodyForComp(NXOpen.Assemblies.Component ct)
        {
            NXOpen.Assemblies.Component[] comp = ct.GetChildren();
            if (comp.Length == 0)
            {
                Part cpPart = ct.Prototype as Part;

                if (cpPart != null)
                {
                    /*                   Tag bodyTag = Tag.Null;
                                       Tag[] faceList;
                                       theUFSession.Obj.CycleObjsInPart(cpPart.Tag, UFConstants.UF_solid_type, ref bodyTag);
                                       while (bodyTag != Tag.Null)
                                       {
                                           faceList = null;

                                           Body by = NXObjectManager.Get(bodyTag) as Body;
                                           Body bd = AssmbliesUtils.GetNXObjectOfOcc(bodyTag, ct.Tag) as Body;
                                           if (by != null && bd != null)
                                           {
                                               bd.Color = 1;
                                               foreach (Face fe in by.GetFaces())
                                               {
                                                   Face fa= AssmbliesUtils.GetNXObjectOfOcc(fe.Tag, ct.Tag) as Face;
                                                   SetFaceColour(fa);
                                               }
                                           }

                                           theUFSession.Obj.CycleObjsInPart(cpPart.Tag, UFConstants.UF_solid_type, ref bodyTag);
                                       }*/

                    PartUtils.SetPartDisplay(cpPart);
                    foreach (Body by in cpPart.Bodies)
                    {
                        by.Color = 1;
                        Body occBody = AssmbliesUtils.GetNXObjectOfOcc(ct.Tag, by.Tag) as Body;
                        if (occBody != null)
                            occBody.Color = 1;
                        foreach (Face fe in by.GetFaces())
                        {
                            this.SetFaceColour(fe);
                            Face occFace = AssmbliesUtils.GetNXObjectOfOcc(ct.Tag, fe.Tag) as Face;
                            if (occFace != null)
                                this.SetFaceColour(occFace);
                        }
                    }

                }
            }
            else
            {
                foreach (NXOpen.Assemblies.Component cp in comp)
                {
                    Part cpPart = cp.Prototype as Part;
                    if (cpPart != null)
                    {
                        PartUtils.SetPartDisplay(cpPart);

                        foreach (Body by in cpPart.Bodies)
                        {
                            by.Color = 1;
                            Body occBody = AssmbliesUtils.GetNXObjectOfOcc(ct.Tag, by.Tag) as Body;
                            foreach (Face fe in by.GetFaces())
                            {
                                this.SetFaceColour(fe);
                                Face occFace = AssmbliesUtils.GetNXObjectOfOcc(ct.Tag, fe.Tag) as Face;
                                if (occFace != null)
                                    this.SetFaceColour(occFace);
                            }
                        }
                    }
                    GetBodyForComp(cp);
                }

            }

        }

        /// <summary>
        /// 更新图纸
        /// </summary>
        /// <param name="part"></param>
        /// <returns></returns>
        private bool UpdateDraw(Part part)
        {
            NXOpen.Drawings.DrawingSheet[] sheets = part.DrawingSheets.ToArray();
            if (sheets.Length == 0)
                return false;
            else
            {
                List<DisplayableObject> objs = new List<DisplayableObject>();
                foreach (NXOpen.Annotations.Dimension dim in part.Dimensions) //删除尺寸
                {
                    if (Math.Round(dim.ComputedSize, 4) == 0)
                    {
                        objs.Add(dim);
                    }
                    else
                    {
                        theUFSession.Obj.DeleteObject(dim.Tag);
                    }
                }
                //foreach (NXOpen.Annotations.Note ne in part.Notes) //删除注释
                //{

                //    theUFSession.Obj.DeleteObject(ne.Tag);

                //}
                objs.AddRange(part.Notes.ToArray());
                objs.AddRange(part.Annotations.IdSymbols.ToArray());
                objs.AddRange(part.Annotations.Centerlines.ToArray());
                NXOpen.DisplayModification displayModification1;
                displayModification1 = theSession.DisplayManager.NewDisplayModification();

                displayModification1.ApplyToAllFaces = true;

                displayModification1.ApplyToOwningParts = false;

                displayModification1.NewColor = 186;
                displayModification1.NewWidth = NXOpen.DisplayableObject.ObjectWidth.One;
                try
                {
                    displayModification1.Apply(objs.ToArray());
                }
               catch
                {

                }
                finally
                {
                    displayModification1.Dispose();
                }
               
                foreach (NXOpen.Annotations.Hatch hc in part.Annotations.Hatches) //删除剖面线
                {
                    try
                    {
                        theUFSession.Obj.DeleteObject(hc.Tag);
                    }
                    catch
                    {

                    }
                }
                //foreach (NXOpen.Annotations.IdSymbol id in part.Annotations.IdSymbols) //删除符号标注
                //{
                //    theUFSession.Obj.DeleteObject(id.Tag);
                //}
                try
                {
                    foreach (NXOpen.Drawings.DrawingSheet st in sheets)
                    {
                        DraftingView[] view = st.GetDraftingViews();
                        foreach (DraftingView dv in view)
                        {
                            //  dv.SetScale(1.0);
                            try
                            {
                                Basic.DrawingUtils.SetWireframeColorSource(NXOpen.Preferences.GeneralWireframeColorSourceOption.FromFace, dv);
                            }
                            catch
                            {

                            }
                            dv.Update();
                        }
                    }
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public void Export()
        {
            Tag partTag = Tag.Null;
            if (Open(out partTag))
            {
                Part part = NXObjectManager.Get(partTag) as Part;
                SetColour(part);
                UpdateDraw(part);
                bool exp = ExportDwg(part);
                //bool hide = true;
                //while (hide && exp)
                //{
                //    if (ConsoleHelper.HideConsoleForBool("Exporting to DXFDWG File"))
                //        hide = false;
                //}             
                this.Close(partTag);
                ConsoleHelper.HideConsoleForBool("Exporting to DXFDWG File");
            }
        }

        public bool ExportDwg(Part part)
        {
            string dwgFile = _saveAsFile + "\\";
            string dwg = dwgFile + Path.GetFileNameWithoutExtension(_partPath) + ".dwg";
            if (!File.Exists(dwgFile))
                Directory.CreateDirectory(dwgFile);
            if (File.Exists(dwg))
                File.Delete(dwg);
            return ExportFileUtils.PrintDWG(part, dwg);
        }

        private void SetBodyColor(Tag partTag)
        {
            Tag bodyTag = Tag.Null;
            theUFSession.Obj.CycleObjsInPart(partTag, UFConstants.UF_component_type, ref bodyTag);
            while (bodyTag != Tag.Null)
            {
                Tag[] faceList;
                theUFSession.Obj.SetColor(bodyTag, 1);
                //theUFSession.Modl.AskBodyFaces(bodyTag, out faceList);
                //foreach (Tag fe in faceList)
                //{
                //    this.SetFaceColour(NXObjectManager.Get(fe) as Face);
                //}
                theUFSession.Obj.CycleObjsInPart(partTag, UFConstants.UF_solid_type, ref bodyTag);
            }
        }
    }
}
