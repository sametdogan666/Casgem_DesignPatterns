using Microsoft.EntityFrameworkCore;
using UnitOfWork.Business.Abstract;
using UnitOfWork.Business.Concrete;
using UnitOfWork.DataAccess.Abstract;
using UnitOfWork.DataAccess.Concrete;
using UnitOfWork.DataAccess.EntityFramework;
using UnitOfWork.DataAccess.UnitOfWork.Abstract;
using UnitOfWork.DataAccess.UnitOfWork.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Context>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICustomerDal, EfCustomerDal>();
builder.Services.AddScoped<ICustomerService, CustomerManager>();

builder.Services.AddScoped<ICustomerProcessDal, EfCustomerProcessDal>();
builder.Services.AddScoped<ICustomerProcessService, CustomerProcessManager>();

builder.Services.AddScoped<IUnitOfWorkDal, UnitOfWorkDal>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
