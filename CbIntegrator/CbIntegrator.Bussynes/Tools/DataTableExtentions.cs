using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CbIntegrator.Bussynes.Tools
{
    /// <summary>
    /// Класс для преобразования DataTable
    /// </summary>
    public static class DataTableExtentions
    {
        /// <summary>
        /// Разделение DataTable по строкам
        /// </summary>
        /// <param name="originalTable"></param>
        /// <param name="batchSize">Кол-во строк</param>
        /// <returns></returns>W
        /*public static List<DataTable> SplitTable(DataTable originalTable, int batchSize)
        {
            List<DataTable> tables = new();
            int i = 0;
            int j = 1;
            DataTable newDt = originalTable.Clone();
            newDt.TableName = "Table_" + j;
            newDt.Clear();
            foreach (DataRow row in originalTable.Rows)
            {
                DataRow newRow = newDt.NewRow();
                newRow.ItemArray = row.ItemArray;
                newDt.Rows.Add(newRow);
                i++;
                if (i == batchSize)
                {
                    tables.Add(newDt);
                    j++;
                    newDt = originalTable.Clone();
                    newDt.TableName = "Table_" + j;
                    newDt.Clear();
                    i = 0;
                }
            }
            return tables;
        }*/
        public static List<DataTable> SplitTable(DataTable originalTable, int batchSize,List<string> items)
        {
            List<DataTable> tables = new();
            int i = 0;
            int j = 1;
            DataTable newDt = originalTable.Clone();
            newDt.TableName = "Table_" + j;
            newDt.Clear();
            if (items.Count > 10 ) { 
                foreach (DataRow row in originalTable.Rows)
                {
                    foreach (var item in items)
                    {
                        if (row[0].ToString().Replace(" ", "") == item.Replace(" ", ""))
                        {

                            DataRow newRow = newDt.NewRow();
                            newRow.ItemArray = row.ItemArray;
                            newDt.Rows.Add(newRow);
                            i++;
                            if (i == batchSize)
                            {
                                tables.Add(newDt);
                                j++;
                                newDt = originalTable.Clone();
                                newDt.TableName = "Table_" + j;
                                newDt.Clear();
                                i = 0;
                            }
                        }
                    }
                }
                if(newDt.Rows.Count > 0)
                {
                    tables.Add(newDt);
                }
            }
            else
            {
                tables.Add(originalTable);
            }
            return tables;
        }
    }
}
