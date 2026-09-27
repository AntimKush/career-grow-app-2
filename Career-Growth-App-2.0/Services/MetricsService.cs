using Microsoft.Extensions.Configuration;

namespace Career_Growth_App_2._0.Services
{
    // Simple metrics service. Replace internals with real DB queries later.
    public class MetricsService : IMetricsService
    {
        private readonly IConfiguration _configuration;

        public MetricsService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task<int> GetActiveCoursesAsync() => Task.FromResult(24);
        public Task<int> GetAchievementsAsync() => Task.FromResult(18);
        public Task<int> GetAppliedCountAsync() => Task.FromResult(950);
        public Task<int> GetOpenJobsAsync() => Task.FromResult(48);
        public Task<int> GetSelectedCandidatesAsync() => Task.FromResult(312);
        public Task<int> GetTotalApplicationsAsync() => Task.FromResult(1254);
    }
}
