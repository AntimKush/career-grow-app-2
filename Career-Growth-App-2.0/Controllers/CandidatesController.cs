using Career_Growth_App_2._0.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Career_Growth_App_2._0.Controllers
{
    public class CandidatesController : Controller
    {
        public IActionResult Index(int page = 1, int pageSize = 10)
        {
            // Generate sample data. Replace with DB queries in production.
            var all = GenerateSampleCandidates(57);

            var total = all.Count;
            var items = all.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var result = new PagedResult<Candidate>
            {
                Items = items,
                Page = page,
                PageSize = pageSize,
                TotalItems = total
            };

            return View(result);
        }

        private List<Candidate> GenerateSampleCandidates(int count)
        {
            var list = new List<Candidate>();
            var rnd = new Random(123);
            var statuses = new[] { "Applied", "Interview", "Selected", "Rejected" };
            var titles = new[] { "Software Engineer", "Data Analyst", "DevOps Engineer", "UI/UX Designer" };

            for (int i = 1; i <= count; i++)
            {
                list.Add(new Candidate
                {
                    Id = i,
                    FullName = $"Candidate {i}",
                    Title = titles[rnd.Next(titles.Length)],
                    Location = (i % 3 == 0) ? "Remote" : "New York, NY",
                    AppliedOn = DateTime.UtcNow.AddDays(-rnd.Next(1, 90)),
                    Status = statuses[rnd.Next(statuses.Length)],
                    ExperienceYears = rnd.Next(0, 12),
                    Email = $"candidate{i}@example.com",
                    Phone = $"+1-555-{1000 + i}",
                    Source = (i % 2 == 0) ? "LinkedIn" : "Referral",
                    AvatarUrl = $"https://picsum.photos/seed/candidate{i}/64/64"
                });
            }

            return list;
        }
    }
}
