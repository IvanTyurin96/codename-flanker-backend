using Microsoft.VisualBasic.FileIO;

namespace CodenameFlanker.Services.Documents;

public sealed class DocumentsService
{
	private readonly string _domainDirectory = AppDomain.CurrentDomain.BaseDirectory;

	public DocumentsService()
	{
	}

	//public string GetManual(string language)
	//{
	//	string selectedFile;
	//	switch (language)
	//	{
	//		case "en":
	//			selectedFile = "Su-30 EFM Documentation EN.pdf";
	//			break;
	//		case "ru":
	//			selectedFile = "Su-30 EFM Documentation RU.pdf";
	//			break;
	//		default:
	//			throw new Exception("Documentation for this language not found.");
	//	}

	//	string path = Path.Combine(_domainDirectory, "docs", selectedFile);
	//	byte[] byteArray = System.IO.File.ReadAllBytes(path);
	//	string fileType = "application/pdf";
	//	string fileName = Path.GetFileName(path);

	//	return new File(byteArray, fileType, fileName);
	//}
}
