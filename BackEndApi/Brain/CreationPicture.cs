namespace BackEndApi.Brain
{
    //namespace ConsoleAppOpenAI.DALL_E.HttpServices;
    public class CreationPicture
    {

        // SINGLETON
        private static CreationPicture instance;

        public static CreationPicture Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CreationPicture();
                }
                return instance;
            }
        }


        public void CreateImage()
        {


        }

    }
}
