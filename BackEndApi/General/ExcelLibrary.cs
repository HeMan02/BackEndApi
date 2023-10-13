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


        public DataTable GetDataTableFromXls()
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

            int i = 1;
            IRow currentRow = sheet.GetRow(i);
            while (currentRow != null)
            {
                DataRow dr = dataTable.NewRow();

                for (int j = 0; j < length; j++)
                {
                    ICell cell = currentRow.GetCell(j);

                    if(cell != null)
                    {

                        switch (dataTable.Columns[j].DataType.ToString())
                        {
                            case "System.Double":
                                break;
                        }

                    }

                }



            }

        }
    }
}
