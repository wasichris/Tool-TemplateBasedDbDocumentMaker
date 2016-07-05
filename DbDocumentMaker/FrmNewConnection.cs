using DbDocumentMaker.Models;
using DbDocumentMaker.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DbDocumentMaker
{
    public partial class FrmNewConnection : Form
    {
        // Fields
        private BindingSource _source = new BindingSource();


        // Properties
        public Connection NewConnection { get; set; }


        // Constructors
        public FrmNewConnection()
        {
            InitializeComponent();

            // data binding
            this.NewConnection = new Connection();
            _source.DataSource = NewConnection;
            txtName.DataBindings.Add("Text", this._source, "Name");
            txtConnStr.DataBindings.Add("Text", this._source, "Str");
        }

      
        // Event Handler
        private void btnCreate_Click(object sender, EventArgs e)
        {

            if (this.NewConnection.IsValid())
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MsgBoxHelper.Warning("Please fill all info!");
            }
        }

        private void btnConnTest_Click(object sender, EventArgs e)
        {
            try
            {
                using (var connection = new SqlConnection(NewConnection.Str))
                {
                    connection.Open();
                    MsgBoxHelper.Done("SQL Connection successful.");

                }
            }
            catch (Exception ex)
            {
                MsgBoxHelper.Warning("Failure: " + ex.Message);
            }
        }
    }
}
