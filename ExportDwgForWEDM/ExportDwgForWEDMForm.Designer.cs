namespace ExportDwgForWEDM
{
    partial class ExportDwgForWEDMForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ColumnHeader path;
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.number = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.file = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttAllSelet = new System.Windows.Forms.Button();
            this.butt_Flie = new System.Windows.Forms.Button();
            this.butt_Parts = new System.Windows.Forms.Button();
            this.butt_Export = new System.Windows.Forms.Button();
            this.but_Cancel = new System.Windows.Forms.Button();
            this.butt_SaveAS = new System.Windows.Forms.Button();
            this.butt_Clear = new System.Windows.Forms.Button();
            path = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // path
            // 
            path.Text = "路径";
            path.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // listView
            // 
            this.listView.CheckBoxes = true;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.number,
            this.file,
            path});
            this.listView.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView.FullRowSelect = true;
            this.listView.Location = new System.Drawing.Point(12, 12);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(474, 569);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "选择";
            this.columnHeader1.Width = 50;
            // 
            // number
            // 
            this.number.Text = "个数";
            this.number.Width = 80;
            // 
            // file
            // 
            this.file.Text = "文件名";
            this.file.Width = 350;
            // 
            // buttAllSelet
            // 
            this.buttAllSelet.BackColor = System.Drawing.Color.White;
            this.buttAllSelet.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttAllSelet.ForeColor = System.Drawing.SystemColors.MenuText;
            this.buttAllSelet.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttAllSelet.Location = new System.Drawing.Point(13, 598);
            this.buttAllSelet.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttAllSelet.Name = "buttAllSelet";
            this.buttAllSelet.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttAllSelet.Size = new System.Drawing.Size(88, 42);
            this.buttAllSelet.TabIndex = 25;
            this.buttAllSelet.Text = "全选";
            this.buttAllSelet.UseVisualStyleBackColor = false;
            this.buttAllSelet.Click += new System.EventHandler(this.buttAllSelet_Click);
            // 
            // butt_Flie
            // 
            this.butt_Flie.BackColor = System.Drawing.Color.White;
            this.butt_Flie.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butt_Flie.ForeColor = System.Drawing.SystemColors.MenuText;
            this.butt_Flie.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.butt_Flie.Location = new System.Drawing.Point(511, 42);
            this.butt_Flie.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.butt_Flie.Name = "butt_Flie";
            this.butt_Flie.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.butt_Flie.Size = new System.Drawing.Size(88, 42);
            this.butt_Flie.TabIndex = 25;
            this.butt_Flie.Text = "打开文件夹";
            this.butt_Flie.UseVisualStyleBackColor = false;
            this.butt_Flie.Click += new System.EventHandler(this.butt_Flie_Click);
            // 
            // butt_Parts
            // 
            this.butt_Parts.BackColor = System.Drawing.Color.White;
            this.butt_Parts.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butt_Parts.ForeColor = System.Drawing.SystemColors.MenuText;
            this.butt_Parts.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.butt_Parts.Location = new System.Drawing.Point(511, 181);
            this.butt_Parts.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.butt_Parts.Name = "butt_Parts";
            this.butt_Parts.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.butt_Parts.Size = new System.Drawing.Size(88, 42);
            this.butt_Parts.TabIndex = 25;
            this.butt_Parts.Text = "打开文件";
            this.butt_Parts.UseVisualStyleBackColor = false;
            this.butt_Parts.Click += new System.EventHandler(this.butt_Parts_Click);
            // 
            // butt_Export
            // 
            this.butt_Export.BackColor = System.Drawing.Color.White;
            this.butt_Export.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butt_Export.ForeColor = System.Drawing.SystemColors.MenuText;
            this.butt_Export.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.butt_Export.Location = new System.Drawing.Point(262, 598);
            this.butt_Export.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.butt_Export.Name = "butt_Export";
            this.butt_Export.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.butt_Export.Size = new System.Drawing.Size(88, 42);
            this.butt_Export.TabIndex = 25;
            this.butt_Export.Text = "导出";
            this.butt_Export.UseVisualStyleBackColor = false;
            this.butt_Export.Click += new System.EventHandler(this.butt_Export_Click);
            // 
            // but_Cancel
            // 
            this.but_Cancel.BackColor = System.Drawing.Color.White;
            this.but_Cancel.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_Cancel.ForeColor = System.Drawing.SystemColors.MenuText;
            this.but_Cancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.but_Cancel.Location = new System.Drawing.Point(511, 598);
            this.but_Cancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.but_Cancel.Name = "but_Cancel";
            this.but_Cancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.but_Cancel.Size = new System.Drawing.Size(88, 42);
            this.but_Cancel.TabIndex = 25;
            this.but_Cancel.Text = "取消";
            this.but_Cancel.UseVisualStyleBackColor = false;
            this.but_Cancel.Click += new System.EventHandler(this.but_Cancel_Click);
            // 
            // butt_SaveAS
            // 
            this.butt_SaveAS.BackColor = System.Drawing.Color.White;
            this.butt_SaveAS.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butt_SaveAS.ForeColor = System.Drawing.SystemColors.MenuText;
            this.butt_SaveAS.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.butt_SaveAS.Location = new System.Drawing.Point(511, 459);
            this.butt_SaveAS.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.butt_SaveAS.Name = "butt_SaveAS";
            this.butt_SaveAS.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.butt_SaveAS.Size = new System.Drawing.Size(88, 42);
            this.butt_SaveAS.TabIndex = 25;
            this.butt_SaveAS.Text = "另存为";
            this.butt_SaveAS.UseVisualStyleBackColor = false;
            this.butt_SaveAS.Click += new System.EventHandler(this.butt_SaveAS_Click);
            // 
            // butt_Clear
            // 
            this.butt_Clear.BackColor = System.Drawing.Color.White;
            this.butt_Clear.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butt_Clear.ForeColor = System.Drawing.SystemColors.MenuText;
            this.butt_Clear.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.butt_Clear.Location = new System.Drawing.Point(511, 320);
            this.butt_Clear.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.butt_Clear.Name = "butt_Clear";
            this.butt_Clear.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.butt_Clear.Size = new System.Drawing.Size(88, 42);
            this.butt_Clear.TabIndex = 25;
            this.butt_Clear.Text = "清空";
            this.butt_Clear.UseVisualStyleBackColor = false;
            this.butt_Clear.Click += new System.EventHandler(this.butt_Clear_Click);
            // 
            // ExportDwgForWEDMForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 652);
            this.Controls.Add(this.butt_Clear);
            this.Controls.Add(this.butt_SaveAS);
            this.Controls.Add(this.butt_Parts);
            this.Controls.Add(this.butt_Flie);
            this.Controls.Add(this.but_Cancel);
            this.Controls.Add(this.butt_Export);
            this.Controls.Add(this.buttAllSelet);
            this.Controls.Add(this.listView);
            this.MaximizeBox = false;
            this.Name = "ExportDwgForWEDMForm";
            this.Text = "导出DWG";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.Button buttAllSelet;
        private System.Windows.Forms.Button butt_Parts;
        private System.Windows.Forms.Button butt_Export;
        private System.Windows.Forms.Button but_Cancel;
        private System.Windows.Forms.Button butt_Flie;
        private System.Windows.Forms.Button butt_SaveAS;
        private System.Windows.Forms.ColumnHeader number;
        private System.Windows.Forms.ColumnHeader file;
        private System.Windows.Forms.Button butt_Clear;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}

