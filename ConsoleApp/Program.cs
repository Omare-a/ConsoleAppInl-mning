using ConsoleApp.Context;
using ConsoleApp.Dto;
using ConsoleApp.Entities;
using ConsoleApp.Repositories;
using ConsoleApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
{
    services.AddDbContext<DataContext>(x => x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\myC-Project\SkapaAnvädareOchProduct\ConsoleApp\Data\DataLocal.mdf;Integrated Security=True;Connect Timeout=30"));

    services.AddSingleton<ProductRepository>();
    services.AddSingleton<OrderRepository>();
    services.AddSingleton<CustomerRepository>();
    services.AddSingleton<RoleReposirtory>();
    services.AddSingleton<OrderProductRowRepositories>();

    services.AddSingleton<CustomerService>();
    services.AddSingleton<OrderProductRowService>();
    services.AddSingleton<OrderService>();
    services.AddSingleton<ProductService>();
    services.AddSingleton<RoleService>();


}).Build();

builder.Start();



var productService = builder.Services.GetRequiredService<ProductService>();
var result = productService.CreatOrder(new ProductDto
{
    ProductName = "Test",
    Price = 1900
});
if (result)
    Console.WriteLine("Lyckades");
else
    Console.WriteLine("Failed");
Console.ReadKey();

var customerService = builder.Services.GetRequiredService<CustomerService>();

var orderProductRowService = builder.Services.GetRequiredService<OrderProductRowService>();

var roleService = builder.Services.GetRequiredService<RoleService>();


