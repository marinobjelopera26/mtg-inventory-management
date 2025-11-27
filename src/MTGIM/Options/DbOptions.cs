namespace MTGIM.Options;

public sealed class DbOptions
{
    public const string SectionName = "DbOptions";
    
    public int CommandTimeoutInSeconds { get; set; }
    public bool EnableDetailedErrors { get; set; }
    public bool EnableSensitiveDataLogging { get; set; }
}