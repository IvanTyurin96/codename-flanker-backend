namespace CodenameFlanker.WebApi.Helpers;

public static class ImageBase64Converter
{
    public static string Convert(string imagePath)
    {
        byte[] bytes = File.ReadAllBytes(imagePath);
        string base64 = "data:image/jpg;base64," + System.Convert.ToBase64String(bytes);
        return base64;
    }
}
