using NET_9_Business_App_MVC.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddProblemDetails();//adds the problem details middleware to the pipeline
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<Department>();
var app = builder.Build();

if (!app.Environment.IsDevelopment())//always place first in middleware pipeline for all to use
{
    app.UseExceptionHandler();//defaults to RFC 7807 standard as a JSON obj output with ProblemDetails service
}

app.UseStatusCodePages();//adds status code pages middleware to the pipeline, also in RFC 7807 format

app.UseRouting();



#pragma warning disable ASP0014 // Suggest using top level route registrations
app.UseEndpoints(endpoints =>
{
// Map the default route for MVC, which is the controller and action name
    endpoints.MapControllers();//map attribute routes to controllers
                           
    endpoints.MapControllerRoute( // Map the default route for MVC, which is the controller and action name
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}"//default route for MVC            
        );
    endpoints.MapControllerRoute(
            name: "departments",
            pattern: "{controller=Departments}/{id?}"//default route for Departments
        );

});
#pragma warning restore ASP0014 // Suggest using top level route registrations

app.Run();

