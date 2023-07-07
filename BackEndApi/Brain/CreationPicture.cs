using static BackEndApi.ConsoleAppOpenAI.HttpServices;
using static BackEndApi.ConsoleAppOpenAI.OpenAIHttpService;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using BackEndApi.ConsoleAppOpenAI;

namespace BackEndApi.Brain
{
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


        public async Task<String> CreateImageAsync(string inputText)
        {
            Console.WriteLine("Starting commandline for DALL-E [Open AI]");

            var config = BuildConfig();

            IOpenAIProxy aiClient = new OpenAIHttpService(config);

            Console.WriteLine("Type your first Prompt");
            //string messageInput = "Wide and green garden with a lot of flowers, with sunflowers, and a small dog running around";
            string messageInput = inputText;
            //var msg = Console.ReadLine();
            var msg = messageInput;

            var nImages = int.Parse(config["OpenAi:DALL-E:N"]);
            var imageSize = config["OpenAi:DALL-E:Size"];
            var prompt = new GenerateImageRequest(msg, nImages, imageSize);

            var result = await aiClient.GenerateImages(prompt);
            var fullPath = "";

            foreach (var item in result.Data)
            {
                Console.WriteLine(item.Url);

                fullPath = Path.Combine(Directory.GetCurrentDirectory(), $"{Guid.NewGuid()}.png");
                var img = await aiClient.DownloadImage(item.Url);

                await File.WriteAllBytesAsync(fullPath, img);

                Console.WriteLine("New image saved at {0}", fullPath);
            }

            Console.WriteLine("Press any key to exit");
            //Console.ReadKey();
            return fullPath;
        }

        static IConfiguration BuildConfig()
        {
            var dir = Directory.GetCurrentDirectory();
            var configBuilder = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(dir, "appsettings.json"), optional: false)
                .AddUserSecrets(Assembly.GetExecutingAssembly());

            return configBuilder.Build();
        }

    }
}
