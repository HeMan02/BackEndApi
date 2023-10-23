using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.Data;

namespace BackEndApi.General
{
    public class ExcelLibrary
    {
        // SINGLETON
        private static ExcelLibrary instance;

        public static ExcelLibrary Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ExcelLibrary();
                }
                return instance;
            }
        }


        public DataTable GetDataTableFromXls(string path)
        {
            IWorkbook workBook;

            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                workBook = new HSSFWorkbook(stream);
            }


            ISheet sheet = workBook.GetSheetAt(0);
            DataTable dataTable = new DataTable(sheet.SheetName);

            IRow row = sheet.GetRow(0);
            int col = 0;

            foreach (ICell itemRow in row)
            {
                string type = GetTypeColumn(sheet,col);
                dataTable.Columns.Add(itemRow.ToString(),Type.GetType(type));
                col++;
            }

            int count = dataTable.Columns.Count;
            int rowCount = 0;
            int i = 1;
            IRow currentRow = sheet.GetRow(i);
            while (currentRow != null)
            {
                rowCount++;
                DataRow dr = dataTable.NewRow();

                for (int j = 0; j < count; j++)
                {
                    ICell cell = currentRow.GetCell(j);

                    if(cell != null)
                    {

                        switch (dataTable.Columns[j].DataType.ToString())
                        {
                            case "System.Double":
                                if (cell.ToString() != "")
                                    dr[j] = Convert.ToDouble(cell.NumericCellValue);
                                break;
                            case "System.DateTime":
                                if (cell.ToString() != "")
                                    dr[j] = Convert.ToDateTime(cell.DateCellValue);
                                break;
                            case "System.Int64":
                                if (cell.ToString() != "")
                                    dr[j] = Convert.ToInt64(cell.NumericCellValue);
                                break;
                            case "System.String":
                                    dr[j] = cell.StringCellValue;
                                break;
                        }
                    }
                }
                dataTable.Rows.Add(dr);
                i++;
                currentRow = sheet.GetRow(i);


            }

            return dataTable;

        }

        private string GetTypeColumn(ISheet sheet,int col)
        {
            string tipo = "";
            int irow = 1;
            int icell = col;

            IRow currentRow = sheet.GetRow(irow);
            while (currentRow!=null)
            {
                ICell cell = currentRow.GetCell(icell);
                if(cell != null)
                {
                    switch (cell.CellType)
                    {
                        case CellType.Numeric:
                            if (DateUtil.IsCellDateFormatted(cell))
                            {
                                tipo = "System.DateTime";
                            }
                            else
                            {
                                tipo = "System.Double";
                            }
                            break;
                        case CellType.String:
                            if(cell.StringCellValue == "")
                            {
                                break;
                            }
                            else
                            {
                                tipo = "System.String";
                                break;
                            }    
                    }
                }
                if (tipo != "")
                {
                    return tipo;
                }
                irow++;
                currentRow = sheet.GetRow(irow);
            }
            return "System.Strig";
        }
    }
}
