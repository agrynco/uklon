namespace Yandex.Api.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var yandexApi = new YandexApi();

            info regionInfo = yandexApi.GetRegionInfo("143");
        }
    }
}