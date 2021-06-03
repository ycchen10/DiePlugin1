using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Basic;
using NXOpen;
using NXOpen.UF;
using DiePlugin.DAL;
using System.IO;
using System.Security.AccessControl;
using System.Threading;

namespace ExportDwgForWEDM
{
    public partial class ExportDwgForWEDMForm : Form
    {
        public static bool isDisposeCalled;
        private string _saveFilePath = null;
        private string _filePath = null;
        private List<string> _partsPath = new List<string>();
        private int _max = 0;
        public ExportDwgForWEDMForm()
        {
            InitializeComponent();

        }

        private void butt_SaveAS_Click(object sender, EventArgs e)
        {
            _saveFilePath = null;
            _saveFilePath = OpenFileUtils.OpenFolderBrowser();
        }

        private void butt_Parts_Click(object sender, EventArgs e)
        {
            _partsPath.Clear();
            _partsPath = OpenFileUtils.OpenFiles("请选择需要导出2D档", "2D档(*.prt*)|");
            if (_partsPath.Count != 0)
            {
                foreach (string str in _partsPath)
                {
                    _max++;
                    ListViewItem lv1 = new ListViewItem();
                    lv1.SubItems.Add(_max.ToString());
                    lv1.SubItems.Add(Path.GetFileNameWithoutExtension(str));
                    lv1.SubItems.Add(str);
                    lv1.Checked = true;
                    listView.Items.Add(lv1);
                }
            }
        }

        private void butt_Flie_Click(object sender, EventArgs e)
        {
            _filePath = null;
            _filePath = OpenFileUtils.OpenFolderBrowser();
            if (_filePath != null)
            {
                List<string> filePath = ExportFile.GetDWGFile(_filePath);

                foreach (string str in filePath)
                {
                    _max++;
                    ListViewItem lv1 = new ListViewItem();
                    lv1.SubItems.Add(_max.ToString());
                    lv1.SubItems.Add(Path.GetFileNameWithoutExtension(str));
                    lv1.SubItems.Add(str);
                    lv1.Checked = true;
                    listView.Items.Add(lv1);
                }
            }
        }

        private void buttAllSelet_Click(object sender, EventArgs e)
        {

            if (buttAllSelet.Text == "全选")
            {
                buttAllSelet.Text = "单选";

                for (int i = 0; i < listView.Items.Count; i++)
                {
                    listView.Items[i].Checked = false;
                }
            }
            else
            {
                buttAllSelet.Text = "全选";

                for (int i = 0; i < listView.Items.Count; i++)
                {
                    listView.Items[i].Checked = true;
                }
            }
        }

        private void but_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butt_Export_Click(object sender, EventArgs e)
        {
            bool isFile = true;
            string saveFile = null;
            if (_filePath != null && _saveFilePath == null)
            {
                DirectorySecurity s = new DirectorySecurity(_filePath, AccessControlSections.Access);
                if (s.AreAccessRulesProtected)
                    isFile = true;
                else
                {
                    saveFile = _filePath;
                    isFile = false;
                }
            }
            if (_saveFilePath == null && isFile)
            {
                MessageBox.Show("请选择保存文件地址！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (_saveFilePath != null)
                saveFile = _saveFilePath;
            for (int i = 0; i < listView.Items.Count; i++)
            {
                ExportDWG ed = new ExportDWG(saveFile, listView.Items[i].SubItems[3].Text.ToString());
                ConsoleHelper.HideConsoleForBool("Exporting to DXFDWG File");
                ed.Export();
                ConsoleHelper.HideConsoleForBool("Exporting to DXFDWG File");
            }
            Thread.Sleep(5000);
            string dwgFile = saveFile + "\\" ;
            DirectoryInfo info = new DirectoryInfo(dwgFile);
            foreach (FileInfo fi in info.GetFiles())
            {
                string name = fi.Name;
                if (name.LastIndexOf(".log") != -1)
                {
                    File.Delete(fi.FullName);
                }
            }
            this.listView.Clear();
        }

        private void butt_Clear_Click(object sender, EventArgs e)
        {
            this.listView.Clear();
            this._max = 0;
        }
    }
}
