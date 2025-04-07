using Microsoft.AspNetCore.Mvc;
using NET_9_Business_App_MVC.Models;

namespace NET_9_Business_App_MVC.Controllers
{

    public class DepartmentsController : Controller
    {
        //default landing for the DepartmentsController
        public string Index()//home View for the DepartmentsController
        {
            return "These are Departments";
        }

        //Details page for the DepartmentsController
        public string Details(int? departmentId)
        {
            return $"This is Department {departmentId}";
        }

        //Create page for the DepartmentsController
        [HttpPost]
        public string Create(Department department)
        {
            if (department is null)
            {
                return "Department is null";
            }
            else
            {
                return $"This is the new Department {department.DepartmentName} with description {department.DepartmentDescription}";
            }
        }

        //Edit page for the DepartmentsController
        [HttpPost]
        public string Edit(Department department, int? departmentId)
        {
            if (department is null)
            {
                return "Department is null";
            }
            else
            {
                return $"This is the updated Department {department.DepartmentName} with description {department.DepartmentDescription}";
            }
        }

        //Delete page for the DepartmentsController
        [HttpPost]
        public string Delete(int? departmentId)
        {
            if (departmentId is null)
            {
                return "Department is null";
            }
            else
            {
                return $"Ypui have deleted Department {departmentId} ";
            }
        }
    }//end DepartmentsController         
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