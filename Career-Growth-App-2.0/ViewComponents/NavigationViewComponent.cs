using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Career_Growth_App_2._0.Models;

namespace Career_Growth_App_2._0.ViewComponents
{
    public class NavigationViewComponent : ViewComponent
    {
        private readonly string _connectionString;

        // Inject IConfiguration to read the connection string from appsettings.json
        public NavigationViewComponent(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var flatMenuList = new List<MenuItem>();

            // Execute ADO.NET command to call the stored procedure
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("Get_Menu_Items", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    await connection.OpenAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            flatMenuList.Add(new MenuItem
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                ParentId = reader.IsDBNull(reader.GetOrdinal("ParentId"))
                                    ? (int?)null
                                    : reader.GetInt32(reader.GetOrdinal("ParentId")),
                                Title = reader.GetString(reader.GetOrdinal("Title")),
                                ControllerName = reader.IsDBNull(reader.GetOrdinal("ControllerName"))
                                    ? null
                                    : reader.GetString(reader.GetOrdinal("ControllerName")),
                                ActionName = reader.IsDBNull(reader.GetOrdinal("ActionName"))
                                    ? null
                                    : reader.GetString(reader.GetOrdinal("ActionName"))
                            });
                        }
                    }
                }
            }

            // Convert Flat List into Recursive Tree Structure using LINQ
            var menuTree = BuildMenuTree(flatMenuList, null);

            return View(menuTree);
        }

        private List<MenuItem> BuildMenuTree(List<MenuItem> allItems, int? parentId)
        {
            return allItems
                .Where(m => m.ParentId == parentId)
                .Select(m => new MenuItem
                {
                    Id = m.Id,
                    ParentId = m.ParentId,
                    Title = m.Title,
                    ControllerName = m.ControllerName,
                    ActionName = m.ActionName,
                    Children = BuildMenuTree(allItems, m.Id) // Recursive call for child menus
                })
                .ToList();
        }
    }
}