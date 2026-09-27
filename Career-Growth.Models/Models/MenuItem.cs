namespace Career_Growth_App_2._0.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Title { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }

        // Holds child sub-menus for recursion
        public List<MenuItem> Children { get; set; } = new();
    }
}
