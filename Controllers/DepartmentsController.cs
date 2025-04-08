using Microsoft.AspNetCore.Mvc;
using NET_9_Business_App_MVC.Models;

namespace NET_9_Business_App_MVC.Controllers
{

    public class DepartmentsController : Controller
    {
        //Sample data for testing
        private List<Department> departments = new List<Department>
        {
        new Department(1,"Amplified Voice",  "Ottawa St.", "Selling amps, microphones, and mixing boards", 50000),
        new Department(2,"Guitars",  "Ottawa St.", "Selling amps, guitars, and effects pedals", 150000),
        new Department(3,"Basses", "Ottawa St.", "Selling amps, basses, and effects pedals", 75000),
        new Department(4,"Percussion", "Ottawa St.", "Selling drums, bongos, and cymbals", 850000),
        };
        

        //default landing for the DepartmentsController
        public string Index()//home View for the DepartmentsController
        {
            string output = "";
            foreach (var department in departments)
            {
                //test data
                output += ($"Department. Id: {department.DepartmentId}\n\tName: {department.DepartmentName} \n\tDescription: {department.DepartmentDescription} \n\tAnnual Sales: {department.DepartmentAnnualSales}\n\tLocation: {department.DepartmentLocation}\n\n");
            }
            return output;//simple string output for now, error messages (if any) still being returned in *&07 fmt, as specfied
        }

        //Details page for the DepartmentsController
        [HttpGet]
        [Route("/departments/{id}")  ]
        public string Details([FromHeader] int departmentId)
        {
            //nonfunctional bit to get the actual department object from the id
           /* var department = departments.FirstOrDefault(dept => dept.DepartmentId == departmentId);
            if (department is null)
            {
                return "Department is very null";
            }
            else if (department is not null)
            {
                return department;
            }
            return "Department was nuller than null";*/

            return $"Department {departmentId} has returned";
        }

        //Create page for the DepartmentsController
        [HttpPost]
        public object Create([FromBody] Department department)
        {
            
            if (department is null)
            {
                return "Department is null";
            }
            else if (department is not null)
            {
                int maxId = departments.Max(dep => dep.DepartmentId);//get max id from list
                department.DepartmentId = maxId + 1; //increment id by 1
                departments.Add(department);
                
                return department;
            }
            return "Department is null";

        }//End create  //Working

        [HttpPost]
        public string Edit([FromBody]Department department)
        {
            if (department is null)
            {
                return "Department is null";
            }
            else
            {
                return $"This is the updated Department {department.DepartmentName} with description {department.DepartmentDescription}";
            }
            
        }//working

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
                return $"You have deleted Department {departmentId} ";
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