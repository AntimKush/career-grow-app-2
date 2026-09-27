namespace Career_Growth_App_2._0.Services
{
    public interface IMetricsService
    {
        Task<int> GetTotalApplicationsAsync();
        Task<int> GetSelectedCandidatesAsync();
        Task<int> GetOpenJobsAsync();
        Task<int> GetActiveCoursesAsync();
        Task<int> GetAchievementsAsync();
        Task<int> GetAppliedCountAsync();
    }
}
