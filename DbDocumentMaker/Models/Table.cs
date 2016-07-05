using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbDocumentMaker.Models
{
    class Table
    {
        // Properties
        public string TableName { get; set; }

        public string Description { get; set; }

        public string TableType { get; set; }

        public bool IsViewTable
        {
            get
            {
                return TableType != null
                  && TableType.IndexOf("VIEW", StringComparison.OrdinalIgnoreCase) >= 0;
            }
        }

        public List<Column> Columns { get; set; }


        // Constructor
        public Table()
        {
            Columns = new List<Column>();
        }


        // Methods
        public override string ToString()
        {
            return TableName + (IsViewTable ? " (view)" : "");
        }
    }
}
