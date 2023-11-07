using System.Text.Json;

namespace CodenameFlanker.Data.Helpers;

public static class JsonParser
{
	public static List<T> ParseSection<T>(string sectionName, string jsonFile)
	{
		List<T> list = new List<T>();

		string jsonPath = Path.Combine(Directory.GetCurrentDirectory(), jsonFile);

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

	public static string GetConnectionString(string connectionString, string jsonFile)
	{
		string jsonPath = Path.Combine(Directory.GetCurrentDirectory(), jsonFile);

		using (StreamReader reader = new StreamReader(jsonPath))
		{
			string json = reader.ReadToEnd();

			using (JsonDocument document = JsonDocument.Parse(json))
			{
				JsonElement root = document.RootElement;
				JsonElement section = root.GetProperty("ConnectionStrings");
				JsonElement connection = section.GetProperty(connectionString);
				return JsonSerializer.Deserialize<string>(connection);
			}
		}
	}
}
