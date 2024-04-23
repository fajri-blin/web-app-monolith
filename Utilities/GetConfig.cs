namespace web_app.Utilities;

public class GetConfig
{
	public static IConfiguration AppSetting { get; }

	static GetConfig()
	{
		AppSetting = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json")
			.Build();
	}
}
