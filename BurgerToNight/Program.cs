using BurgerToNight;
using BurgerToNight.Data;
using BurgerToNight.Repository;
using BurgerToNight.Repository.IRepository;
using BurgerToNightAPI.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BurgerDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IFileRepo,FileRepo>();
builder.Services.AddAutoMapper(typeof(MapProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles(new StaticFileOptions
{ FileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "images")), RequestPath = "/Resources" });
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
