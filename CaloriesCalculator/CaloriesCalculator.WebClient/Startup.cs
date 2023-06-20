using CaloriesCalculator.WebClient.Service;

namespace CaloriesCalculator.WebClient
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            Configuration.Bind("Project", new Config());
        }
    }
}
