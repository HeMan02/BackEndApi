
namespace BackEndApi.ConsoleAppOpenAI
{
    public class HttpServices
    {

        public interface IOpenAIProxy
        {
            //👇 Send the Prompt Text with and return a list of image URLs
            Task<GenerateImageResponse> GenerateImages(
                GenerateImageRequest prompt,
                CancellationToken cancellation = default);

            //👇 Download the Image as byte array
            Task<byte[]> DownloadImage(string url);
        }


        public record class GenerateImageRequest(
       string Prompt,
       int N,
       string Size);

        public record class GenerateImageResponse(
            long Created,
            GeneratedImageData[] Data);

        public record class GeneratedImageData(string Url);

    }
}
