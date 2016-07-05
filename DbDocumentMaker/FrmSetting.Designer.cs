namespace DbDocumentMaker
{
    partial class FrmSetting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAddConnection = new System.Windows.Forms.Button();
            this.lbConn = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRemoveConnection = new System.Windows.Forms.Button();
            this.cbConnection = new System.Windows.Forms.ComboBox();
            this.txtConnStr = new System.Windows.Forms.TextBox();
            this.cbDocTemplate = new System.Windows.Forms.ComboBox();
            this.lbDocTemplate = new System.Windows.Forms.Label();
            this.btnExportDocTemplate = new System.Windows.Forms.Button();
            this.btnRemoveDocTemplate = new System.Windows.Forms.Button();
            this.btnAddDocTemplate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddConnection
            // 
            this.btnAddConnection.Location = new System.Drawing.Point(379, 37);
            this.btnAddConnection.Name = "btnAddConnection";
            this.btnAddConnection.Size = new System.Drawing.Size(48, 20);
            this.btnAddConnection.TabIndex = 2;
            this.btnAddConnection.Text = "Add";
            this.btnAddConnection.UseVisualStyleBackColor = true;
            this.btnAddConnection.Click += new System.EventHandler(this.btnAddConnection_Click);
            // 
            // lbConn
            // 
            this.lbConn.AutoSize = true;
            this.lbConn.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbConn.Location = new System.Drawing.Point(9, 18);
            this.lbConn.Name = "lbConn";
            this.lbConn.Size = new System.Drawing.Size(59, 12);
            this.lbConn.TabIndex = 3;
            this.lbConn.Text = "Connection";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LightGreen;
            this.btnSave.Location = new System.Drawing.Point(311, 202);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(116, 35);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRemoveConnection
            // 
            this.btnRemoveConnection.Location = new System.Drawing.Point(311, 37);
            this.btnRemoveConnection.Name = "btnRemoveConnection";
            this.btnRemoveConnection.Size = new System.Drawing.Size(62, 20);
            this.btnRemoveConnection.TabIndex = 5;
            this.btnRemoveConnection.Text = "Remove";
            this.btnRemoveConnection.UseVisualStyleBackColor = true;
            this.btnRemoveConnection.Click += new System.EventHandler(this.btnRemoveConnection_Click);
            // 
            // cbConnection
            // 
            this.cbConnection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbConnection.FormattingEnabled = true;
            this.cbConnection.Location = new System.Drawing.Point(10, 37);
            this.cbConnection.Name = "cbConnection";
            this.cbConnection.Size = new System.Drawing.Size(295, 20);
            this.cbConnection.TabIndex = 6;
            this.cbConnection.SelectedIndexChanged += new System.EventHandler(this.cbConnection_SelectedIndexChanged);
            // 
            // txtConnStr
            // 
            this.txtConnStr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConnStr.Location = new System.Drawing.Point(10, 63);
            this.txtConnStr.Multiline = true;
            this.txtConnStr.Name = "txtConnStr";
            this.txtConnStr.ReadOnly = true;
            this.txtConnStr.Size = new System.Drawing.Size(417, 58);
            this.txtConnStr.TabIndex = 7;
            // 
            // cbDocTemplate
            // 
            this.cbDocTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDocTemplate.FormattingEnabled = true;
            this.cbDocTemplate.Location = new System.Drawing.Point(10, 155);
            this.cbDocTemplate.Name = "cbDocTemplate";
            this.cbDocTemplate.Size = new System.Drawing.Size(417, 20);
            this.cbDocTemplate.TabIndex = 8;
            // 
            // lbDocTemplate
            // 
            this.lbDocTemplate.AutoSize = true;
            this.lbDocTemplate.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbDocTemplate.Location = new System.Drawing.Point(8, 136);
            this.lbDocTemplate.Name = "lbDocTemplate";
            this.lbDocTemplate.Size = new System.Drawing.Size(70, 12);
            this.lbDocTemplate.TabIndex = 9;
            this.lbDocTemplate.Text = "Doc Template";
            // 
            // btnExportDocTemplate
            // 
            this.btnExportDocTemplate.Location = new System.Drawing.Point(10, 182);
            this.btnExportDocTemplate.Name = "btnExportDocTemplate";
            this.btnExportDocTemplate.Size = new System.Drawing.Size(51, 20);
            this.btnExportDocTemplate.TabIndex = 10;
            this.btnExportDocTemplate.Text = "Export";
            this.btnExportDocTemplate.UseVisualStyleBackColor = true;
            this.btnExportDocTemplate.Click += new System.EventHandler(this.btnExportDocTemplate_Click);
            // 
            // btnRemoveDocTemplate
            // 
            this.btnRemoveDocTemplate.Location = new System.Drawing.Point(67, 182);
            this.btnRemoveDocTemplate.Name = "btnRemoveDocTemplate";
            this.btnRemoveDocTemplate.Size = new System.Drawing.Size(62, 20);
            this.btnRemoveDocTemplate.TabIndex = 11;
            this.btnRemoveDocTemplate.Text = "Remove";
            this.btnRemoveDocTemplate.UseVisualStyleBackColor = true;
            this.btnRemoveDocTemplate.Click += new System.EventHandler(this.btnRemoveDocTemplate_Click);
            // 
            // btnAddDocTemplate
            // 
            this.btnAddDocTemplate.Location = new System.Drawing.Point(135, 182);
            this.btnAddDocTemplate.Name = "btnAddDocTemplate";
            this.btnAddDocTemplate.Size = new System.Drawing.Size(48, 20);
            this.btnAddDocTemplate.TabIndex = 12;
            this.btnAddDocTemplate.Text = "Add";
            this.btnAddDocTemplate.UseVisualStyleBackColor = true;
            this.btnAddDocTemplate.Click += new System.EventHandler(this.btnAddDocTemplate_Click);
            // 
            // FrmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 248);
            this.Controls.Add(this.btnAddDocTemplate);
            this.Controls.Add(this.btnRemoveDocTemplate);
            this.Controls.Add(this.btnExportDocTemplate);
            this.Controls.Add(this.lbDocTemplate);
            this.Controls.Add(this.cbDocTemplate);
            this.Controls.Add(this.txtConnStr);
            this.Controls.Add(this.cbConnection);
            this.Controls.Add(this.btnRemoveConnection);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lbConn);
            this.Controls.Add(this.btnAddConnection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Setting";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAddConnection;
        private System.Windows.Forms.Label lbConn;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnRemoveConnection;
        private System.Windows.Forms.ComboBox cbConnection;
        private System.Windows.Forms.TextBox txtConnStr;
        private System.Windows.Forms.ComboBox cbDocTemplate;
        private System.Windows.Forms.Label lbDocTemplate;
        private System.Windows.Forms.Button btnExportDocTemplate;
        private System.Windows.Forms.Button btnRemoveDocTemplate;
        private System.Windows.Forms.Button btnAddDocTemplate;
    }
}