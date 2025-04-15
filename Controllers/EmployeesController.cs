using Microsoft.AspNetCore.Mvc;
using NET_9_Business_App_MVC.Models;

namespace NET_9_Business_App_MVC.Controllers
{
    public class EmployeesController : Controller
    {
        //test data 
        //Sample data for testing
        private List<Employee> employees =
        [
        new (1,"Ozzy","Osbourne", "Membranophone Specialist","Vocals", 500000),
        new (2,"Tony", "Iommi", "Guitar Player", "Guitars", 500000),
        new (3,"Geezer", "Butler", "Bass Player", "Guitars", 500000),
        new (4,"Bill", "Ward", "Bongos", "Percussion", 500000),
        ];
        
        
        public IActionResult GetEmployeesByDepartment([FromRoute(Name ="departmentId")]int departmentId)
        {
            return Content($"Loading Employees under Department: {departmentId}");
        }
    }
}
