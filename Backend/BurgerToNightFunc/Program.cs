using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using BurgerToNightAPI.Repository.IRepository;
using BurgerToNightAPI.Repository;
using AutoMapper;
using BurgerToNightAPI;
using Microsoft.EntityFrameworkCore;
using BurgerToNightAPI.Data;
using BurgerToNightFunc.Services.IServices;
using BurgerToNightFunc.Services;
using Azure.Storage.Blobs;

var host = new HostBuilder()
    .ConfigureAppConfiguration(config =>
    {
        config.AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
              .AddEnvironmentVariables();
    })
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices((context, services) =>
    {
        var configuration = context.Configuration;

        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();

        services.AddSingleton(x =>
        {
            var connectionString = configuration.GetValue<string>("BlobStorage:ConnectionString");
            return new BlobServiceClient(connectionString);
        });

        services.AddScoped<IBlobService, BlobService>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddAutoMapper(typeof(MapProfile));

        services.AddDbContext<BurgerDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
        );

        services.AddCors(options =>
        {
            options.AddPolicy("AllowSpecificOrigin",
                builder => builder.WithOrigins("http://192.168.15.38:5173")
                                  .AllowAnyHeader()
                                  .AllowAnyMethod());
        });
    })
    .Build();

host.Run();
