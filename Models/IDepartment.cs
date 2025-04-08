
namespace NET_9_Business_App_MVC.Models
{
    public interface IDepartment
    {
        double? DepartmentAnnualSales { get; set; }
        List<Customer>? DepartmentCustomers { get; set; }
        string? DepartmentDescription { get; set; }
        List<Employee>? DepartmentEmployees { get; set; }
        int DepartmentId { get; set; }
        List<InventoryInvoice>? DepartmentInvoices { get; set; }
        List<Inventory>? DepartmentItems { get; set; }
        string? DepartmentLocation { get; set; }
        string? DepartmentName { get; set; }
    }
}