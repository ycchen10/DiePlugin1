using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using NXOpen;
using NXOpen.Utilities;
using NXOpen.UF;

namespace ExportDwgForWEDM
{
    //public class Program
    //{

    //    // class members
    //    private static Session theSession;
    //    private static UFSession theUfSession;
    //    public static Program theProgram;
    //    public static bool isDisposeCalled;

    //    //------------------------------------------------------------------------------
    //    // Constructor
    //    //------------------------------------------------------------------------------
    //    public Program()
    //    {
    //        try
    //        {
    //           // theSession = Session.GetSession();
    //           // theUfSession = UFSession.GetUFSession();
    //            isDisposeCalled = false;
    //        }
    //        catch (NXOpen.NXException ex)
    //        {
    //            // ---- Enter your exception handling code here -----
    //            // UI.GetUI().NXMessageBox.Show("Message", NXMessageBox.DialogType.Error, ex.Message);
    //        }
    //    }

    //    //------------------------------------------------------------------------------
    //    //  Explicit Activation
    //    //      This entry point is used to activate the application explicitly
    //    //------------------------------------------------------------------------------
    //    public static int Main(string[] args)
    //    {
    //        int retValue = 0;
    //        try
    //        {
    //            theProgram = new Program();

    //            // TODO: Add your application code here

    //            ExportDwgForWEDMForm edf = new ExportDwgForWEDMForm();
    //            edf.Show();
    //            theProgram.Dispose();
    //        }
    //        catch (NXOpen.NXException ex)
    //        {
    //            // ---- Enter your exception handling code here -----

    //        }
    //        return retValue;
    //    }

    //    //------------------------------------------------------------------------------
    //    // Following method disposes all the class members
    //    //------------------------------------------------------------------------------
    //    public void Dispose()
    //    {
    //        try
    //        {
    //            if (isDisposeCalled == false)
    //            {
    //                //TODO: Add your application code here 
    //            }
    //            isDisposeCalled = true;
    //        }
    //        catch (NXOpen.NXException ex)
    //        {
    //            // ---- Enter your exception handling code here -----

    //        }
    //    }
    //}

    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
         
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ExportDwgForWEDMForm());
        }
    }


}
