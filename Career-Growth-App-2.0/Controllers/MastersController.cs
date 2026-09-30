using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace Career_Growth_App_2._0.Controllers
{
    public class MastersController : Controller
    {
        [HttpGet]
        public IActionResult Get_Districts()
        {
            Dictionary<int, string> districts = new Dictionary<int, string>();
            districts.Add(1, "Guna");
            districts.Add(2, "Vidisha");
            return Json(districts);
        }

        [HttpGet]
        public IActionResult Get_Tehsils_By_District_Id(int District_Id)
        {
            Dictionary<int, string> districts = new Dictionary<int, string>();

            if (District_Id == 1)
            {
                districts.Add(10, "Raghogarh");
                districts.Add(20, "Madhusudangarh");
                districts.Add(30, "Guna");
            }
            else if(District_Id==2)
            {
                districts.Add(10, "Vidisha");
                districts.Add(20, "Lateri");
            }
            return Json(districts);
        }
        
    }
}
