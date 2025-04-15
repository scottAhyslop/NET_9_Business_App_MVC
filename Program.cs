using NET_9_Business_App_MVC.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddProblemDetails();//adds the problem details middleware to the pipeline
builder.Services.AddControllers().AddXmlSerializerFormatters();//adds the controllers to the pipeline with XML capabilities for both JSON and XML formatting
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())//always place first in middleware pipeline for all to use
{
    app.UseExceptionHandler();//defaults to RFC 7807 standard as a JSON obj output with ProblemDetails service
}

app.UseStatusCodePages();//adds status code pages middleware to the pipeline, also in RFC 7807 format

app.UseRouting();

//Map the default route for MVC, which is the controller and action name

app.MapControllers();//map attribute routes to controllers

app.MapControllerRoute( // Home route
            name: "default",
            pattern: "{controller=Home}/{action=Index}"//default route for Home          
        );
app.MapControllerRoute(// Departments route
            name: "departments",
            pattern: "{controller=Departments}/{action=Index}"//default route for Departments 
        );
/*app.MapControllerRoute(// Departments/Details/{id?} route
            name: "departments/details",
            pattern: "{controller=Departments}/{action=Details}/{id:int?}"//default route for Departments {id?}
        );*/

app.Run();

