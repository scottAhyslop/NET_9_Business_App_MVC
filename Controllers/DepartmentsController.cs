using Microsoft.AspNetCore.Mvc;
using NET_9_Business_App_MVC.Models;

namespace NET_9_Business_App_MVC.Controllers
{
    [Route("api/")]
    public class DepartmentsController : Controller
    {
        // GET: Departments
        [HttpGet("departments")]
        public string GetDepartments()
        {
            return "These are Departments";
        }

        // GET: DepartmentsById
        [HttpGet("departments/{departmentId:int}")]
        public string GetDepartmentById(int departmentId)
        {
            return $"This is Department {departmentId}";
        }
    }  //end DepartmentsController         
}//end namespace

/*
 public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentDescription { get; set; }
        public List<Employee> DepartmentEmployees { get; set; }
        public double DepartmentAnnualSales { get; set; }
        public List<InventoryInvoice> DepartmentInvoices { get; set; }
        public List<Inventory> DepartmentItems{ get; set; }
 
 
 
 */