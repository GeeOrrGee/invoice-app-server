using InvoiceAPP.Data;
using InvoiceAPP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddNewtonsoftJson()
    .AddXmlDataContractSerializerFormatters();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });
});
builder.Services.AddControllers(option =>
{
    option.ReturnHttpNotAcceptable = true;
}).AddNewtonsoftJson().AddXmlDataContractSerializerFormatters();;

//builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
//builder.Services.AddScoped<IInvoiceService, InvoiceService>();

builder.Services.Configure<RouteOptions>(options =>
{
    options.ConstraintMap.Add("Invoice.Status", typeof(InvoiceAPP.Controllers.EnumRoutes.Extensions.CustomRouteConstraint<InvoiceAPP.Models.Invoice.Invoice.Status>));
});

builder.Services.AddDbContext<InvoiceDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection")));

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1");
    });
    app.UseSwaggerUI();
}


app.UseExceptionHandler("/Home/Error");

app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();