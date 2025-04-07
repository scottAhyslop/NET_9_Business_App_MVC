namespace NET_9_Business_App_MVC.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentDescription { get; set; }
        public List<Employee> DepartmentEmployees { get; set; }
        public double DepartmentAnnualSales { get; set; }
        public List<InventoryInvoice> DepartmentInvoices { get; set; }
        public List<Inventory> DepartmentItems{ get; set; }



    }
}
