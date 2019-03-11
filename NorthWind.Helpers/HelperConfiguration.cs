namespace NorthWind.Helpers
{
    using Microsoft.Extensions.Configuration;

    public static class HelperConfiguration
    {
        public static AppConfiguration GetAppConfiguration(string cofigurationFile = "App.Json")
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile(cofigurationFile, optional: false).
                Build();

            return configuration.Get<AppConfiguration>();
        }
    }
}
