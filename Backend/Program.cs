using Backend.Data;
using Backend.Services.ClientService;
using Backend.Services.ProductService;
using Backend.Services.SellerService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using System.Text.Json.Serialization;
using System.Text.Json;
using Backend.Services.OrderService;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    {
      options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
      options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    });
// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

builder.Services.AddDbContext<BackendContext>(options =>
                options.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=Backend;Integrated Security=True"));
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<ISellerService, SellerService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<IdentityUser>().AddRoles<IdentityRole>()
  .AddEntityFrameworkStores<BackendContext>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
  options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
  {
    In = ParameterLocation.Header,
    Name = "Authorization",
    Type = SecuritySchemeType.ApiKey
  });
  options.OperationFilter<SecurityRequirementsOperationFilter>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}
app.MapIdentityApi<IdentityUser>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
using(var scope  = app.Services.CreateScope())
{
  var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
  var roles = new[] { "Admin", "Client", "Seller" };
  foreach (var role in roles)
  {
    if (!await roleManager.RoleExistsAsync(role))
      await roleManager.CreateAsync(new IdentityRole(role));
  }
}
using (var scope = app.Services.CreateScope())
{

  var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
  string email = "admin@admin.com";
  string password = "Cerebel1233@";
  if(await userManager.FindByEmailAsync(email) == null)
  {
    var user = new IdentityUser();
    user.UserName = email;
    user.Email = email;
    user.EmailConfirmed = true;
    await userManager.CreateAsync(user);
    await userManager.AddToRoleAsync(user, "Admin");

  }
}

app.Run();
