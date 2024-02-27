namespace CodenameFlanker.Services.Documents;

public sealed class DocumentsService
{
	public DocumentsService()
	{
	}

	public (string, string, string) GetManual(string language)
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

		string fileFolder = "docs";
		string fileType = "application/pdf";

		return (fileFolder, fileType, fileName);
	}
}
