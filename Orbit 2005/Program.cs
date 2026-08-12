using FluentValidation;
using FluentValidation.AspNetCore;
using Orbit_2005.Data;
using Orbit_2005.Repositories;
using Orbit_2005.Repositories.Interfaces;
using Orbit_2005.Services;
using Orbit_2005.Validators;

namespace Orbit_2005
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Any controller asks for AppDbContext, it will be provided by the DI container.
            builder.Services.AddDbContext<AppDbContext>();

            builder.Services.AddValidatorsFromAssemblyContaining<ProductValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<PlanetValidator>();


            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<ProductService, ProductService>();
            builder.Services.AddScoped<CategoryService, CategoryService>();
            builder.Services.AddScoped<AdminHomeService, AdminHomeService>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<UserService, UserService>();
            builder.Services.AddScoped<HomeService, HomeService>();
            builder.Services.AddScoped<UserRepository, UserRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<ICartItemRepository, CartItemRepository>();
            builder.Services.AddScoped<CartService, CartService>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<OrderService, OrderService>();

            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();


            

            app.Run();
            app.Run();
        }
    }
}
