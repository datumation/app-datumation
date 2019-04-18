using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Datumation.Extensions
{
    public static class DataExtensions
    {
        public static void AddReportColumns(List<string> columnNames, System.Data.DataTable dt, string dataType = "System.String")
        {
            for (int i = 0; i < columnNames.Count; i++)
            {
                System.Data.DataColumn column;
                // Create new DataColumn, set DataType, ColumnName and add to DataTable.
                column = new System.Data.DataColumn();
                column.DataType = System.Type.GetType(dataType);
                column.ColumnName = columnNames[i];
                dt.Columns.Add(column);
            }
        }
    }
}