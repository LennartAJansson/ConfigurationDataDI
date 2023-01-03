namespace ConfigurationDataDI;

public class ConfigurationData
{
    public static string SectionName = "ConfigurationData";
    public string Url { get; set; } = string.Empty;
    public int TimeOut { get; set; } = 10;
}
