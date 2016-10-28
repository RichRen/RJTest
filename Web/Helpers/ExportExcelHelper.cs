using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using Aspose.Cells;

namespace Web.Helpers
{
    public class ExportExcelHelper
    {
        #region ExportFromDataTable

        public static void ExportFromDataTable(string fileName, DataTable dataTable)
        {
            Workbook workbook = new Workbook();
            Worksheet workSheet = workbook.Worksheets[0];
            Cells cells = workSheet.Cells;
            Row row = cells.Rows[0];

            Style titleStyle = new Style();
            titleStyle.Font.IsBold = true;
            titleStyle.Borders.SetStyle(CellBorderType.Thin);
            titleStyle.Borders.DiagonalStyle = CellBorderType.None;
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                Cell cell = row[i];
                cell.Value = dataTable.Columns[i].ColumnName;
                cell.SetStyle(titleStyle);
            }

            workSheet.Cells.ImportDataTable(dataTable, false, 1, 0);
            Style cellStyle = new Style();
            cellStyle.Borders.SetStyle(CellBorderType.Thin);
            cellStyle.Borders.DiagonalStyle = CellBorderType.None;
            //Range range = cells.CreateRange(1, 0, cells.MaxDataRow - 1, cells.MaxDataColumn - 1);
            //range.SetStyle(cellStyle);
            for (int i = 1; i <= cells.MaxDataRow; i++)
            {
                for (int j = 0; j <= cells.MaxDataColumn; j++)
                {
                    Cell cell = cells.GetCell(i, j);
                    cell.SetStyle(cellStyle);
                }
            }
            workSheet.AutoFitColumns();
            workSheet.AutoFitRows();
            HttpResponse response = HttpContext.Current.Response;

            //清空Response缓存内容
            response.Clear();
            response.Buffer = true;

            //确定字符的编码格式
            response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(fileName));
            response.ContentType = "application/ms-excel";
            response.Charset = "utf-8";
            response.ContentEncoding = System.Text.Encoding.UTF8;

            //写入Response
            workbook.Save(response.OutputStream, SaveFormat.Excel97To2003);
            response.End();

        }

        /// <summary>
        /// 导出数据表到多个Sheet
        /// </summary>
        /// <param name="fileName">导出文件的名称</param>
        /// <param name="dicDataTables">数据表是个字典，Key表示Sheet的名称，Value是具体的数据表</param>
        public static void ExportFromDataTable(string fileName, Dictionary<string, DataTable> dicDataTables)
        {
            Workbook workbook = new Workbook();
            workbook.Worksheets.Clear();
            foreach (KeyValuePair<string, DataTable> keyValuePair in dicDataTables)
            {
                workbook.Worksheets.Add(keyValuePair.Key);
                Worksheet workSheet = workbook.Worksheets[keyValuePair.Key];
                Cells cells = workSheet.Cells;
                Row row = cells.Rows[0];

                Style titleStyle = new Style();
                titleStyle.Font.IsBold = true;
                titleStyle.Borders.SetStyle(CellBorderType.Thin);
                titleStyle.Borders.DiagonalStyle = CellBorderType.None;
                DataTable dt = keyValuePair.Value;
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    Cell cell = row[j];
                    cell.Value = dt.Columns[j].ColumnName;
                    cell.SetStyle(titleStyle);
                }

                workSheet.Cells.ImportDataTable(dt, false, 1, 0);

                Style cellStyle = new Style();
                cellStyle.Borders.SetStyle(CellBorderType.Thin);
                cellStyle.Borders.DiagonalStyle = CellBorderType.None;
                //Range range = cells.CreateRange(1, 0, cells.MaxDataRow - 1, cells.MaxDataColumn - 1);
                //range.SetStyle(cellStyle);
                for (int k = 1; k <= cells.MaxDataRow; k++)
                {
                    for (int m = 0; m <= cells.MaxDataColumn; m++)
                    {
                        Cell cell = cells.GetCell(k, m);
                        cell.SetStyle(cellStyle);
                    }
                }
                workSheet.AutoFitColumns();
                workSheet.AutoFitRows();
            }
            HttpResponse response = HttpContext.Current.Response;

            //清空Response缓存内容
            response.Clear();
            response.Buffer = true;

            //确定字符的编码格式
            response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(fileName));
            response.ContentType = "application/ms-excel";
            response.Charset = "utf-8";
            response.ContentEncoding = System.Text.Encoding.UTF8;

            //写入Response
            workbook.Save(response.OutputStream, SaveFormat.Excel97To2003);
            response.End();
        }
        #endregion
    }

    public interface IExportExcelEntity
    {

    }
    public class EneityWithOrder<T>
    {
        public int Order { get; set; }
        public T Entity { get; set; }
    }
}
