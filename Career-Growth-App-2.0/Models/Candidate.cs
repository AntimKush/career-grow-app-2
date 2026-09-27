using System;

namespace Career_Growth_App_2._0.Models
{
    public class Candidate
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public DateTime AppliedOn { get; set; }
        public string Status { get; set; }
        public int ExperienceYears { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Source { get; set; }
        public string AvatarUrl { get; set; }
    }
}
