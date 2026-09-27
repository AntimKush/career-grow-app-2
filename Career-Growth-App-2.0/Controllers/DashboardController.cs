using Microsoft.AspNetCore.Mvc;
using Career_Growth_App_2._0.Models;
using Career_Growth_App_2._0.Services;

namespace Career_Growth_App_2._0.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IMetricsService _metrics;

        public DashboardController(IMetricsService metrics)
        {
            _metrics = metrics;
        }

        public async Task<IActionResult> Index()
        {
            var model = new AdminDashboardViewModel
            {
                TotalApplications = await _metrics.GetTotalApplicationsAsync(),
                SelectedCandidates = await _metrics.GetSelectedCandidatesAsync(),
                OpenJobs = await _metrics.GetOpenJobsAsync(),
                ActiveCourses = await _metrics.GetActiveCoursesAsync(),
                Achievements = await _metrics.GetAchievementsAsync(),
                AppliedCount = await _metrics.GetAppliedCountAsync()
            };

            return View(model);
        }
    }
}
