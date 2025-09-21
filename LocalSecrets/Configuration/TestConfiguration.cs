namespace LocalSecrets.Configuration;

public class TestConfiguration(IConfiguration configuration)
{
    public string ReadSettings()
    {
        var myKeyValue = configuration["MyKey"];
        var title = configuration["Position:Title"];
        var name = configuration["Position:Name"];
        var defaultLogLevel = configuration["Logging:LogLevel:Default"];

        return $"MyKey value: {myKeyValue} " +
               $"Title: {title} " +
               $"Name: {name} " +
               $"Default Log Level: {defaultLogLevel}";
    }

    public string BindCfgToClass()
    {
        // Bind configuration section to a class
        var opt = configuration.GetSection(PositionOptions.OptName).Get<PositionOptions>();
        return $"Title: {opt.Title} " +
               $"Name: {opt.Name}";
    }
}