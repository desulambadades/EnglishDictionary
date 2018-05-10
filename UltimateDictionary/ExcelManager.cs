using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace UltimateDictionary
{
    class ExcelManager
    {
        private Application excelapp;
        private Window excelWindow;
        private Workbooks excelappworkbooks;
        private Workbook excelappworkbook;
        private Sheets excelsheets;
        private Worksheet excelworksheet;
        private Range excelcell;       

        public int Open(string path)
        {
            try
            {
                excelapp = new Application();
                excelapp.Visible = true;
                excelapp.Workbooks.Open(path);
                excelworksheet = excelapp.Workbooks[1].Worksheets[1];
                excelapp.Visible = false;
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
            
        }
        public void Quit()
        {
            excelapp.Workbooks.Close();
            excelapp.Quit();
        }
        public void makeVisible()
        {
            excelapp.Visible = true;

        }
        public void Save()
        {
            excelapp.DisplayAlerts = false;
            excelappworkbooks = excelapp.Workbooks;
            excelappworkbook = excelappworkbooks[1];
            //excelappworkbook.Saved = true;
            excelappworkbook.Save();
        }
        public int lastRow
        {
            get
            {
                int lastRow = excelworksheet.Cells.SpecialCells(XlCellType.xlCellTypeLastCell).Row;
                /*if (excelworksheet.get_Range("A" + lastRow.ToString()).Value2 != null)
                   lastRow++;*/
                return lastRow + 1;
            }
        }
        
        public List<string> GetColumn(int column)
        {
            var cells = (object[,])excelworksheet.Columns[column].Value2;

            List<string> lst = cells.Cast<object>().ToList().ConvertAll(x => Convert.ToString(x));            
            lst.RemoveRange(0, 1);
            lst.RemoveRange(lastRow-2,lst.Count - lastRow + 2);

            return lst;
        }
        public void SetValue(int col,int row,string val)
        {            
            excelcell = excelworksheet.Cells[row, col];

            var height = excelcell.Height;
            excelcell.Value2 = val;
            excelcell.RowHeight = height;
        }
        public string GetValue(int col, int row)
        {
            string val = "";
            try
            {
                val = excelworksheet.Cells[row, col].Value2.ToString();
                return val;
            }
            catch (Exception)
            {
                
            }
            return null;
        }
    }
}
