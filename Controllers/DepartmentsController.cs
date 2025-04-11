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
        [HttpGet]
        [Route("/departments")]
        public IActionResult Index()//home View for the DepartmentsController
        {         
            //display sample data, make it look "pretty"
            string output = "<style>.results{position: absolute;top: 25%;left: 50%;margin-right: -50%;transform: translate(-50%, -33%)}.center{margin-left:33%;}</style><h2 class='center'>Department Info Page</h2>";

            output += "<h4 class='results'><br/>";
            foreach (var department in departments)
            {
                //test data
                output += ($"<br/>Department. Id: {department.DepartmentId}<br/>Name: {department.DepartmentName} <br/>Description: {department.DepartmentDescription} <br/>Annual Sales: {department.DepartmentAnnualSales}<br/>Location: {department.DepartmentLocation}<br/>");
            }
            output += "</h4><br/>";
            return Content(output, "text/html");
        }

        //Details page for the DepartmentsController
        [HttpGet]
        [Route("/departments/{departmentId}")]
        public object Details([FromHeader] int departmentId)
        {
            //Match object in collection to the departmentID param
            var department = departments.FirstOrDefault(dept => dept.DepartmentId == departmentId);
            if (department is null)
            {
                return "Department is very nully null";
            }
            else if (department is not null)
            {
                return department;
            }
            return "Department was nuller than null";
           
        }//End Details   //working

        //Create page for the DepartmentsController
        [HttpPost]
        public object Create([FromBody] Department department)
        {

            foreach (var value in ModelState.Values)
            {
                foreach (var error in value.Errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                    Console.WriteLine(error.Exception);
                }
            }

            ModelState.AddModelError("Description", "Description is required...");
            
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
            return "Department is nuller than null";

        }//End Create  //Working

        [HttpPost]
        public object Edit([FromBody]Department department)
        {
            
            var dep = departments.FirstOrDefault(dept => dept.DepartmentId == department.DepartmentId);
            if (department is null)
            {
                return "Department is very null";
            }
            else if (department is not null)
            {
                return department;
            }
            return "Department was nuller than null";

        }//End Edit //working

        //Delete page for the DepartmentsController
        [HttpPost]
        [Route("/departments/Delete/{departmentid}")]
        public string Delete([FromHeader] int departmentId)
        {
            //Match object in collection to the departmentID param
            var department = departments.FirstOrDefault(dept => dept.DepartmentId == departmentId);
            if (department is null)
            {
                return $"Department is null...";
            }
            else if (department is not null)
            {
                departments.Remove(department);
                return $"Department: {departmentId} deleted...";
            }
            return $"Department not found or bad request";
            /*if (departmentId != 0)
            {
                return $"Department: {departmentId} deleted...";
            }
            return "Nuller than null";*/

        }//end delete
    }//end DepartmentsController         
}//end namespace

