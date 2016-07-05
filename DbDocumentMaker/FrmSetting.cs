using DbDocumentMaker.Models;
using DbDocumentMaker.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DbDocumentMaker
{
    public partial class FrmSetting : Form
    {
        // Fields
        private ConfigContent _configContent = Config.GetInstance().Content.DeepCloneViaJson();


        // Properties
        public bool IsCurrentConnectionChanged { get; set; }

        
        // Constructors
        public FrmSetting()
        {
            InitializeComponent();
            LoadConfig();

            IsCurrentConnectionChanged = false;
        }


        // Methods
        private void LoadConfig()
        {
            // load connections
            cbConnection.Items.Clear();
            cbConnection.Items.AddRange(_configContent.Connections.ToArray());
            cbConnection.SelectedItem = _configContent.CurrentConnection;

            // load doc template
            cbDocTemplate.Items.Clear();
            cbDocTemplate.Items.AddRange(GetDocTemplateFileNames());
            cbDocTemplate.SelectedItem = _configContent.CurrentDocTemplateName;
        }

        private string[] GetDocTemplateFileNames()
        {
            var dirInfo = new DirectoryInfo(_configContent.DocTemplateLocation);
            var files = dirInfo.GetFiles("*.xlsx");
            return files.Select(f => f.Name).ToArray();
        }


        // Events
        private void btnAddConnection_Click(object sender, EventArgs e)
        {
            using (var form = new FrmNewConnection())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    cbConnection.Items.Add(form.NewConnection);
                    cbConnection.SelectedItem = form.NewConnection;
                }
            }
        }

        private void btnRemoveConnection_Click(object sender, EventArgs e)
        {
            if (cbConnection.SelectedIndex > -1)
            {
                if (MsgBoxHelper.Confirm("Remove this connection?") == DialogResult.OK)
                {
                    cbConnection.Items.RemoveAt(cbConnection.SelectedIndex);
                    cbConnection.Text = string.Empty;
                    txtConnStr.Text = string.Empty;
                }
            }
            else
            {
                MsgBoxHelper.Warning("Please choose a connection!");
            }

        }

        private void cbConnection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbConnection.SelectedIndex > -1)
            {
                var selectedCandidate = cbConnection.Items[cbConnection.SelectedIndex] as Connection;
                txtConnStr.Text = selectedCandidate.Str;
            }
            else
            {
                txtConnStr.Text = string.Empty;
            }
        }

        private void btnExportDocTemplate_Click(object sender, EventArgs e)
        {
            if (cbDocTemplate.SelectedIndex > -1)
            {
                using (var dialog = new SaveFileDialog())
                {
                    dialog.Filter = "Excel File|*.xlsx";
                    dialog.Title = "Export Doc Tempalte File";
                    dialog.ShowDialog();
                    if (!string.IsNullOrWhiteSpace(dialog.FileName))
                    {
                        var selectedFile = Path.Combine(_configContent.DocTemplateLocation, cbDocTemplate.SelectedItem.ToString());
                        File.Copy(selectedFile, dialog.FileName, true);
                        MsgBoxHelper.Done();
                    }
                }
            }
            else
            {
                MsgBoxHelper.Warning("Please choose a template!");
            }

        }

        private void btnRemoveDocTemplate_Click(object sender, EventArgs e)
        {
            if (cbDocTemplate.SelectedIndex > -1)
            {

                if (MsgBoxHelper.Confirm("Remove this template?") == DialogResult.OK)
                {
                    try
                    {
                        // delete tempalte file
                        var selectedFile = Path.Combine(_configContent.DocTemplateLocation, cbDocTemplate.SelectedItem.ToString());
                        File.Delete(selectedFile);

                        // remove file name in list
                        cbDocTemplate.Items.RemoveAt(cbDocTemplate.SelectedIndex);
                        cbDocTemplate.Text = string.Empty;

                    }
                    catch (Exception ex)
                    {
                        MsgBoxHelper.Error("Failure: " + ex.Message);
                    }
                }
            }
            else
            {
                MsgBoxHelper.Warning("Please choose a template!");
            }
        }

        private void btnAddDocTemplate_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = "Excel File|*.xlsx";
                dialog.Title = "Add Doc Tempalte File";
                dialog.ShowDialog();
                if (!string.IsNullOrWhiteSpace(dialog.FileName))
                {
                    // add tempalte file
                    var newTemplatePath = Path.Combine(_configContent.DocTemplateLocation, dialog.SafeFileName);
                    File.Copy(dialog.FileName, newTemplatePath, true);

                    // add file name in list
                    cbDocTemplate.Items.Add(dialog.SafeFileName);
                    cbDocTemplate.SelectedItem = dialog.SafeFileName;

                    MsgBoxHelper.Done();
                }
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // update values
            _configContent.Connections = cbConnection.Items.Cast<Connection>().ToList();
            _configContent.CurrentConnectionName = cbConnection.SelectedIndex > -1 ? cbConnection.SelectedItem.ToString() : "";
            _configContent.CurrentDocTemplateName = cbDocTemplate.SelectedIndex > -1 ? cbDocTemplate.SelectedItem.ToString() : "";

            var msg = new StringWriter();
            if (_configContent.IsValid(ref msg))
            {
                // decide need to refresh tables in main form or not
                IsCurrentConnectionChanged =
                    !string.Equals(_configContent.CurrentConnection.Str, Config.GetInstance().Content.CurrentConnection.Str);

                try
                {
                    // save to config
                    Config.GetInstance().Content = _configContent;
                    Config.GetInstance().SaveConfig();

                    // close
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.Error("Failure: " + ex.Message);
                }

            }
            else
            {
                MsgBoxHelper.Warning(msg.ToString());
            }
        }
    }
}
