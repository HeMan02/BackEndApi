using BackEndApi.General;
using System.Data;

namespace BackEndApi.Brain
{
    public class BubbleMain
    {
        // SINGLETON
        private static BubbleMain instance;

        public static BubbleMain Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BubbleMain();
                }
                return instance;
            }
        }

        public void Test()
        {
            DataTable testTable = new DataTable();

            testTable = MyConnection.Instance.GetDataFromDb();
        }
        public void CreationPdf()
        {

            //Brain.CreationPdf.Instance.CreatePage();
            Brain.CreationPdf.Instance.CreatePageFree();

        }

        public String CreationPicture(string inputText)
        {

            String pathImage = Brain.CreationPicture.Instance.CreateImageAsync(inputText).Result;
            return pathImage;
        }
    }
}
