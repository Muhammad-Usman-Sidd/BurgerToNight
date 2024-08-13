using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BurgerToNightAPI.Repository.IRepository;
using BurgerToNightAPI.Repository;
using AutoMapper;
using BurgerToNightAPI;
using Microsoft.EntityFrameworkCore;
using BurgerToNightAPI.Data;
using BurgerToNightFunc.Services.IServices;
using BurgerToNightFunc.Services;
using Azure.Storage.Blobs;
using BurgerToNightAPI.Models;
using Microsoft.AspNetCore.Identity;

var host = new HostBuilder()
    .ConfigureAppConfiguration(config =>
    {
        config.AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
              .AddEnvironmentVariables();
    })
    .ConfigureFunctionsWorkerDefaults(workerApp =>
    {
        workerApp.UseMiddleware<AuthorizationMiddleware>();
    })
    .ConfigureServices((context, services) =>
    {
        var configuration = context.Configuration;

        services.AddSingleton(configuration);

        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();

        services.AddSingleton(x =>
        {
            var connectionString = configuration.GetValue<string>("BlobStorage:ConnectionString");
            return new BlobServiceClient(connectionString);
        });
        services.AddTransient<AuthorizationMiddleware>();

        services.AddScoped<IBlobService, BlobService>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUserRepo, UserRepo>();
        services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<BurgerDbContext>()
            .AddDefaultTokenProviders();

        services.AddAutoMapper(typeof(MapProfile));

        services.AddDbContext<BurgerDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
        );

        services.AddCors(options =>
        {
            options.AddPolicy("AllowSpecificOrigin",
                builder => builder.WithOrigins("http://192.168.15.76:5173")
                                  .AllowAnyHeader()
                                  .AllowAnyMethod());
        });
    })
    .Build();

host.Run();
