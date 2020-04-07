using Dapper;
using DbDocumentMaker.Models;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbDocumentMaker.Utility
{
    class DbManager
    {
        // Fields
        private string _connStr;

        private List<Table> _dbTables;


        // Properties
        public List<Table> DbTables { get { return _dbTables; } }


        // Methods
        public DbManager(string connStr)
        {
            this._connStr = connStr;
            this._dbTables = new List<Table>();
        }

        public void LoadTables()
        {
            var columns = new List<Column>();

            using (var conn = new SqlConnection(_connStr))
            {
                try
                {
                    // open connection
                    conn.Open();

                    // execute
                    columns = conn.Query<Column>(this.GetSql()).ToList();

                    // separate columns to tables
                    _dbTables = columns.GroupBy(p => p.TableName,
                               (key, group) => new Table()
                               {
                                   TableName = key,
                                   Description = group.Any() ? group.First().TableDescription : "",
                                   TableType = group.Any() ? group.First().TableType : "",
                                   Columns = group.ToList()
                               }
                              ).ToList();


                }
                catch (Exception ex)
                {
                    MsgBoxHelper.Error("Failure: " + ex.Message);
                }

            }
        }

        public void LoadTables(string newConnStr) 
        {
            this._connStr = newConnStr;
            this.LoadTables();
        }

        private string GetSql()
        {
            return @"

                  SELECT 
                       tb.TABLE_NAME AS 'TableName'
                      ,CASE 
                        WHEN tb.TABLE_TYPE = 'VIEW'
                        THEN (SELECT value 
                                FROM sys.fn_listextendedproperty(NULL, 'user', tb.TABLE_SCHEMA, 'view', tb.TABLE_NAME, DEFAULT, DEFAULT)
                                WHERE name = 'MS_Description'
                                AND objtype = 'VIEW')
                        ELSE (SELECT value 
                                FROM sys.fn_listextendedproperty(NULL, 'user', tb.TABLE_SCHEMA, 'table', tb.TABLE_NAME, DEFAULT, DEFAULT)
                                WHERE name = 'MS_Description'
                                AND objtype = 'TABLE')
                       END AS 'TableDescription'
                      ,tb.TABLE_TYPE AS 'TableType'
                      ,col.ORDINAL_POSITION AS 'No'
                      ,col.COLUMN_NAME AS 'ColumnName'
                      ,col.DATA_TYPE AS 'DataType'
                      ,CASE 
                        WHEN col.CHARACTER_MAXIMUM_LENGTH = -1
                          THEN 'MAX' 
                          ELSE LTRIM(STR(col.CHARACTER_MAXIMUM_LENGTH,10))
                       END AS 'Length'
                      ,col.NUMERIC_SCALE AS 'NumericScale'
                      ,col.NUMERIC_PRECISION AS 'NumericPrecision'
                      ,col.COLUMN_DEFAULT AS 'Default'
                      ,col.IS_NULLABLE AS 'Nullable'   
                      ,CASE 
                        WHEN COLUMNPROPERTY(object_id(tb.TABLE_NAME), col.COLUMN_NAME, 'IsIdentity') = 1  
                          THEN 'YES' 
                          ELSE 'NO' 
                       END AS 'Identity'  
                      ,(SELECT value
                          FROM sys.fn_listextendedproperty(NULL, 'schema', tb.TABLE_SCHEMA, 'table', tb.TABLE_NAME, 'column', DEFAULT)
                          WHERE name = 'MS_Description'
                          AND objtype = 'COLUMN'
                          AND objname COLLATE Chinese_Taiwan_Stroke_CI_AS = col.COLUMN_NAME) AS 'Description'
                      ,CASE 
                        WHEN tbc.CONSTRAINT_NAME is not null  
                          THEN 'YES' 
                          ELSE 'NO' 
                       END AS 'PK' 
                      ,tbc.CONSTRAINT_NAME AS ' PkConstraint' 
                      ,CASE 
                        WHEN kcu1.CONSTRAINT_NAME is not null  
                          THEN 'YES' 
                          ELSE 'NO' 
                       END AS 'FK'  
                      ,kcu1.CONSTRAINT_NAME AS ' FkConstraint'
                      ,kcu2.TABLE_NAME AS 'FkReferencedTable' 
                      ,kcu2.COLUMN_NAME AS 'FkReferencedColumn'

                  FROM 

                  INFORMATION_SCHEMA.TABLES tb
                  LEFT JOIN INFORMATION_SCHEMA.COLUMNS col ON (tb.TABLE_NAME = col.TABLE_NAME)
                  LEFT JOIN
                  (
                    INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS AS rc 
                    INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE AS kcu1 
                      ON kcu1.CONSTRAINT_CATALOG = rc.CONSTRAINT_CATALOG  
                      AND kcu1.CONSTRAINT_SCHEMA = rc.CONSTRAINT_SCHEMA 
                      AND kcu1.CONSTRAINT_NAME = rc.CONSTRAINT_NAME 
                    INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE AS kcu2 
                      ON kcu2.CONSTRAINT_CATALOG = rc.UNIQUE_CONSTRAINT_CATALOG  
                      AND kcu2.CONSTRAINT_SCHEMA = rc.UNIQUE_CONSTRAINT_SCHEMA 
                      AND kcu2.CONSTRAINT_NAME = rc.UNIQUE_CONSTRAINT_NAME 
                      AND kcu2.ORDINAL_POSITION = kcu1.ORDINAL_POSITION 
                  ) ON (tb.TABLE_NAME = kcu1.TABLE_NAME AND col.COLUMN_NAME = kcu1.COLUMN_NAME)
                  LEFT JOIN
                  (
                    INFORMATION_SCHEMA.TABLE_CONSTRAINTS AS tbc
                    INNER JOIN INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE AS colc 
                    ON  colc.CONSTRAINT_NAME = tbc.CONSTRAINT_NAME
                    AND colc.TABLE_NAME = tbc.TABLE_NAME
                    AND tbc.CONSTRAINT_TYPE = 'PRIMARY KEY' 
                  )  ON (tb.TABLE_NAME = tbc.TABLE_NAME AND col.COLUMN_NAME = colc.COLUMN_NAME)
                  --where 
                  --tb.TABLE_TYPE = 'BASE TABLE'
                  --tb.TABLE_NAME = 'SSO_ACTIVE_USER' 
                  ORDER BY tb.TABLE_NAME, col.ORDINAL_POSITION  

                    ";
        }

        public void GenerateDocument(List<string> tableNames, string templatePath, string outputDocPath)
        {
            const string sheetName4TableListTempalte = "#TableListTemplate";
            const string sheetName4TableSchemaTempalte = "#TableSchemaTemplate";
            const string tagName4TableNo = "#table.no";
            const string tagName4TableName = "#table.name";
            const string tagName4TableDesc = "#table.description";
            const string tagName4TableView = "#table.view";
            const string tagName4TableType = "#table.type";
            const string tagName4ColumnNo = "#column.no";
            const string tagName4ColumnName = "#column.name";
            const string tagName4ColumnPK = "#column.pk";
            const string tagName4ColumnFK = "#column.fk";
            const string tagName4ColumnFKReference = "#column.fkreference";
            const string tagName4ColumnNullable = "#column.nullable";
            const string tagName4ColumnIdentity = "#column.identity";
            const string tagName4ColumnDataType = "#column.datatype";
            const string tagName4ColumnDefault = "#column.default";
            const string tagName4ColumnDesc = "#column.description";


            // open template file
            XSSFWorkbook workbook;
            using (FileStream fs = new FileStream(templatePath, FileMode.Open, FileAccess.Read))
            {
                workbook = new XSSFWorkbook(fs);
            }



            // TABLE LIST

            // clone tempalte table list sheet & rename sheet
            var tableSheet = workbook.CloneSheet(workbook.GetSheetIndex(sheetName4TableListTempalte));
            workbook.SetSheetName(workbook.NumberOfSheets - 1, "Table List");

            var tableIndex = 1;
            foreach (var table in DbTables.Where(t => tableNames.Contains(t.TableName)))
            {
                var noLocation = tableSheet.FindCellLocation(tagName4TableNo);
                if (noLocation.HasValue)
                {
                    // copy the table info row from tempalte
                    tableSheet.CopyRow(noLocation.Value.Y, noLocation.Value.Y + 1);

                    var newRowIndex = noLocation.Value.Y;
                    tableSheet.SetFirstMatchCellContentInRow(newRowIndex, tagName4TableNo, tableIndex.ToString());
                    tableSheet.SetFirstMatchCellHyperlinkInRow(newRowIndex, tagName4TableName, table.TableName, tableIndex.ToString());
                    tableSheet.SetFirstMatchCellContentInRow(newRowIndex, tagName4TableDesc, table.Description);
                    tableSheet.SetFirstMatchCellContentInRow(newRowIndex, tagName4TableView, table.IsViewTable ? "V" : "");
                    tableSheet.SetFirstMatchCellContentInRow(newRowIndex, tagName4TableType, table.TableType.ToTitleCase());

                    tableIndex++;
                }

            }

            // remove the last template row
            tableSheet.RemoveFirstMatchRow(tagName4TableNo);


            // TABLE SCHEMA SHEETS

            tableIndex = 1;
            foreach (var table in DbTables.Where(t => tableNames.Contains(t.TableName)))
            {
                // clone tempalte schema sheet & rename sheet
                var schemaSheet = workbook.CloneSheet(workbook.GetSheetIndex(sheetName4TableSchemaTempalte));
                workbook.SetSheetName(workbook.NumberOfSheets - 1, tableIndex.ToString()/*table.TableName*/);

                // table name & description
                schemaSheet.SetFirstMatchCellContent(tagName4TableName, table.TableName);
                schemaSheet.SetFirstMatchCellContent(tagName4TableDesc, table.Description);
                schemaSheet.SetFirstMatchCellContent(tagName4TableView, table.IsViewTable ? "V" : "");
                schemaSheet.SetFirstMatchCellContent(tagName4TableType, table.TableType.ToTitleCase());

                // prepare each column info
                foreach (var column in table.Columns)
                {
                    var noLocation = schemaSheet.FindCellLocation(tagName4ColumnNo);
                    if (noLocation.HasValue)
                    {
                        // copy the column info row from tempalte
                        schemaSheet.CopyRow(noLocation.Value.Y, noLocation.Value.Y + 1);

                        var newRowIndex = noLocation.Value.Y;
                        schemaSheet.SetFirstMatchCellContentInRow(newRowIndex, tagName4ColumnNo, column.No.ToString());
                        schemaSheet.SetFirstMatchCellContentInRow(newRowIndex, tagName4ColumnName, column.ColumnName);
                        schemaSheet.SetFirstMatchCellContentInRow(newRowIndex, tagName4ColumnPK, column.IsPrimaryKey ? "V" : "");
                        schemaSheet.SetFirstMatchCellContentInRow(newRowIndex, tagName4ColumnFK, column.IsForeignKey ? "V" : "");
                        schemaSheet.SetFirstMatchCellContentInRow(newRowIndex, tagName4ColumnFKReference, column.FkReferencedInfo);
                        schemaSheet.SetFirstMatchCellContentInRow(newRowIndex, tagName4ColumnNullable, column.IsNullable ? "V" : "");
                        schemaSheet.SetFirstMatchCellContentInRow(newRowIndex, tagName4ColumnIdentity, column.IsIdentity ? "V" : "");
                        schemaSheet.SetFirstMatchCellContentInRow(newRowIndex, tagName4ColumnDataType, column.FullDataType);
                        schemaSheet.SetFirstMatchCellContentInRow(newRowIndex, tagName4ColumnDefault, column.Default);
                        schemaSheet.SetFirstMatchCellContentInRow(newRowIndex, tagName4ColumnDesc, column.Description);

                    }

                }

                // remove the last template row
                schemaSheet.RemoveFirstMatchRow(tagName4ColumnNo);

                tableIndex++;
            }

            // remove template sheet
            workbook.RemoveSheetAt(workbook.GetSheetIndex(sheetName4TableListTempalte));
            workbook.RemoveSheetAt(workbook.GetSheetIndex(sheetName4TableSchemaTempalte));

            // save as another excel file
            using (FileStream stream = new FileStream(outputDocPath, FileMode.Create, FileAccess.Write))
            {
                workbook.Write(stream);
            }

            // set null 
            workbook = null;
        }
    }
}
