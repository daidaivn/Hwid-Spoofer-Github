using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using ApiProject.Models;
using ApiProject.IServices;
using ApiProject.Services;

internal class Program
{
    private static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        //connect to db

        builder.Services.AddControllers()
        .AddJsonOptions(options =>
        {
            // Ignore self reference loop
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        });

        builder.Services.AddDbContext<TestTek4TvContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });
        builder.Services.AddScoped<ICategoryService, CategoryService>();
        //builder.Services.AddScoped<ICWService, CWService>();
        builder.Services.AddScoped<IGenderServices, GenderService>();
        builder.Services.AddScoped<IPrioritizedServices, PrioritizedService>();
        builder.Services.AddScoped<IRoleServices, RoleService>();
       // builder.Services.AddScoped<IUWService, UWService>();
        builder.Services.AddScoped<IUserServices, UserService>();
        builder.Services.AddScoped<IWorkingServices,WorkingService>();
        builder.Services.AddScoped<IWorkingStatusService, WorkingStatusService>();
       
        //builder.Services.AddScoped<IWorkingService, WorkingService>();

        // In general
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(
            name: "_AllowAll",
            builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }
            );
        });
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        // with a named pocili
        app.UseCors(x => x
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                  .SetIsOriginAllowed(origin => true) // allow any origin
                  .AllowCredentials()); // allow credentials


        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}