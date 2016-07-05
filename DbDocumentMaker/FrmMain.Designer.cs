namespace DbDocumentMaker
{
    partial class FrmMain
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGenerate = new System.Windows.Forms.Button();
            this.dgvColumns = new System.Windows.Forms.DataGridView();
            this.clbTables = new System.Windows.Forms.CheckedListBox();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnRememberCheckedTables = new System.Windows.Forms.Button();
            this.btnCheckAll = new System.Windows.Forms.Button();
            this.btnUnCheckAll = new System.Windows.Forms.Button();
            this.btnSetting = new System.Windows.Forms.Button();
            this.lbTables = new System.Windows.Forms.Label();
            this.lbColumnInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColumns)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGenerate
            // 
            this.btnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerate.BackColor = System.Drawing.Color.LightGreen;
            this.btnGenerate.Location = new System.Drawing.Point(657, 19);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(160, 38);
            this.btnGenerate.TabIndex = 0;
            this.btnGenerate.Text = "Generate Document";
            this.btnGenerate.UseVisualStyleBackColor = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // dgvColumns
            // 
            this.dgvColumns.AllowUserToAddRows = false;
            this.dgvColumns.AllowUserToDeleteRows = false;
            this.dgvColumns.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvColumns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvColumns.Location = new System.Drawing.Point(264, 89);
            this.dgvColumns.Name = "dgvColumns";
            this.dgvColumns.ReadOnly = true;
            this.dgvColumns.RowTemplate.Height = 24;
            this.dgvColumns.Size = new System.Drawing.Size(639, 364);
            this.dgvColumns.TabIndex = 1;
            // 
            // clbTables
            // 
            this.clbTables.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.clbTables.CheckOnClick = true;
            this.clbTables.FormattingEnabled = true;
            this.clbTables.Location = new System.Drawing.Point(12, 89);
            this.clbTables.Name = "clbTables";
            this.clbTables.Size = new System.Drawing.Size(241, 361);
            this.clbTables.TabIndex = 2;
            this.clbTables.SelectedValueChanged += new System.EventHandler(this.clbTables_SelectedValueChanged);
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(12, 17);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(86, 38);
            this.btnReload.TabIndex = 3;
            this.btnReload.Text = "Reload";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnRememberCheckedTables
            // 
            this.btnRememberCheckedTables.Location = new System.Drawing.Point(264, 18);
            this.btnRememberCheckedTables.Name = "btnRememberCheckedTables";
            this.btnRememberCheckedTables.Size = new System.Drawing.Size(167, 37);
            this.btnRememberCheckedTables.TabIndex = 4;
            this.btnRememberCheckedTables.Text = "Remember Checked Tables";
            this.btnRememberCheckedTables.UseVisualStyleBackColor = true;
            this.btnRememberCheckedTables.Click += new System.EventHandler(this.btnRememberCheckedTables_Click);
            // 
            // btnCheckAll
            // 
            this.btnCheckAll.Location = new System.Drawing.Point(104, 17);
            this.btnCheckAll.Name = "btnCheckAll";
            this.btnCheckAll.Size = new System.Drawing.Size(67, 37);
            this.btnCheckAll.TabIndex = 5;
            this.btnCheckAll.Text = "Check All";
            this.btnCheckAll.UseVisualStyleBackColor = true;
            this.btnCheckAll.Click += new System.EventHandler(this.btnCheckAll_Click);
            // 
            // btnUnCheckAll
            // 
            this.btnUnCheckAll.Location = new System.Drawing.Point(177, 18);
            this.btnUnCheckAll.Name = "btnUnCheckAll";
            this.btnUnCheckAll.Size = new System.Drawing.Size(76, 37);
            this.btnUnCheckAll.TabIndex = 6;
            this.btnUnCheckAll.Text = "UnCheck All";
            this.btnUnCheckAll.UseVisualStyleBackColor = true;
            this.btnUnCheckAll.Click += new System.EventHandler(this.btnUnCheckAll_Click);
            // 
            // btnSetting
            // 
            this.btnSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetting.BackColor = System.Drawing.Color.BurlyWood;
            this.btnSetting.Location = new System.Drawing.Point(823, 19);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(80, 37);
            this.btnSetting.TabIndex = 7;
            this.btnSetting.Text = "Setting";
            this.btnSetting.UseVisualStyleBackColor = false;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // lbTables
            // 
            this.lbTables.AutoSize = true;
            this.lbTables.Location = new System.Drawing.Point(12, 68);
            this.lbTables.Name = "lbTables";
            this.lbTables.Size = new System.Drawing.Size(54, 12);
            this.lbTables.TabIndex = 8;
            this.lbTables.Text = "DB Tables";
            // 
            // lbColumnInfo
            // 
            this.lbColumnInfo.AutoSize = true;
            this.lbColumnInfo.Location = new System.Drawing.Point(267, 68);
            this.lbColumnInfo.Name = "lbColumnInfo";
            this.lbColumnInfo.Size = new System.Drawing.Size(66, 12);
            this.lbColumnInfo.TabIndex = 9;
            this.lbColumnInfo.Text = "Column Info";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 465);
            this.Controls.Add(this.lbColumnInfo);
            this.Controls.Add(this.lbTables);
            this.Controls.Add(this.btnSetting);
            this.Controls.Add(this.btnUnCheckAll);
            this.Controls.Add(this.btnCheckAll);
            this.Controls.Add(this.btnRememberCheckedTables);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.clbTables);
            this.Controls.Add(this.dgvColumns);
            this.Controls.Add(this.btnGenerate);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Template-based DB Document Generator for SQL Server";
            ((System.ComponentModel.ISupportInitialize)(this.dgvColumns)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.DataGridView dgvColumns;
        private System.Windows.Forms.CheckedListBox clbTables;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Button btnRememberCheckedTables;
        private System.Windows.Forms.Button btnCheckAll;
        private System.Windows.Forms.Button btnUnCheckAll;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.Label lbTables;
        private System.Windows.Forms.Label lbColumnInfo;
    }
}

