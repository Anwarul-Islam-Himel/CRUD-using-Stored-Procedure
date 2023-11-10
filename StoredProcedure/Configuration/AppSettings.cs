namespace StoredProcedure.Configuration
{
    public static class AppSettings
    {
        public const string SectionName = "AppSettings";
        public static Settings Settings { get; set; } = new();
    }

    public class Settings
    {
        public string DBConnection { get; set; }
    }
}
