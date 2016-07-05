using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DbDocumentMaker.Utility
{
    class MsgBoxHelper
    {
        public static DialogResult Confirm(string msg)
        {
            return MessageBox.Show(msg, 
                "Comfirm Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        }

        public static void Done()
        {
            MessageBox.Show("It's done.",
                "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void Done(string msg)
        {
            MessageBox.Show(msg,
                "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void Warning(string msg)
        {
            MessageBox.Show(msg,
                "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void Error(string msg)
        {
            MessageBox.Show(msg,
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
