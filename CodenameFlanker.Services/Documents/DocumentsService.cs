using Microsoft.VisualBasic.FileIO;

namespace CodenameFlanker.Services.Documents;

public sealed class DocumentsService
{
	private readonly string _domainDirectory = AppDomain.CurrentDomain.BaseDirectory;

	public DocumentsService()
	{
	}

	public async Task<(byte[], string, string)> GetManual(string language)
	{
		string fileName;
		switch (language)
		{
			case "en":
				fileName = "Su-30 EFM Documentation EN.pdf";
				break;
			case "ru":
				fileName = "Su-30 EFM Documentation RU.pdf";
				break;
			default:
				throw new Exception("Documentation for this language not found.");
		}

		string path = Path.Combine(_domainDirectory, "docs", fileName);
		string fileType = "application/pdf";
		byte[] file = await File.ReadAllBytesAsync(path);

		return (file, fileType, fileName);
	}
}
