using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using INFO4042___Projet_Final.Data;
using INFO4042___Projet_Final.Models;
using INFO4042___Projet_Final.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<INFO4042___Projet_FinalContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("INFO4042___Projet_FinalContext") ?? throw new InvalidOperationException("Connection string 'INFO4042___Projet_FinalContext' not found.")));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<INFO4042___Projet_FinalContext>();
builder.Services.AddControllersWithViews();

/* Add Email support
   - Add EmailSender as a transient service.
   - Register the AuthMessageSenderOptions configuration instance.

     With a transient service, a new instance is provided every time an instance is requested 
     whether it is in the scope of same HTTP request or across different HTTP requests. 

     With a scoped service we get the same instance within the scope of a given HTTP request 
     but a new instance across different HTTP requests.
    
    Le mot de passe oublié est quelque chose de secondaire, il ne fait pas partie de la logique 
    principale de l'application, il est donc moins cher en termes de ressources
*/
builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.Configure<AuthMessageSenderOptions>(builder.Configuration);
//end email support

var app = builder.Build();

// Demorome: Pour initialiser la base de données (seeding)
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
// Custom 404 and 500 Error pages
//Note:  Must call the UseStatusCodePages before request handling middlewares
//       like Static Files and MVC middlewares
app.UseStatusCodePagesWithReExecute("/Error/{0}");//send to Error Controller passing status code arg

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
