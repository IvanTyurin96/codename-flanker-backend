using System.Text.Json;

namespace CodenameFlanker.Data.Helpers;

public static class InitialDataParser
{
	public static List<T> ParseSection<T>(string sectionName)
	{
		List<T> list = new List<T>();

		string currentDirectory = Directory.GetCurrentDirectory();
		string jsonPath = Path.Combine(currentDirectory, "initialData.json");

		using (StreamReader reader = new StreamReader(jsonPath))
		{
			string json = reader.ReadToEnd();

			using (JsonDocument document = JsonDocument.Parse(json))
			{
				JsonElement root = document.RootElement;
				JsonElement section = root.GetProperty(sectionName);

				list = JsonSerializer.Deserialize<List<T>>(section);
			}
		}
		return list;
	}
}
