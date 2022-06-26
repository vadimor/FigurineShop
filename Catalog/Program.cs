using Infrastructure.Filters;
using Microsoft.OpenApi.Models;
using Catalog.Configurations;
using Catalog.Repositories.Interfaces;
using Catalog.Repositories;
using Catalog.Services.Interfaces;
using Catalog.Services;
using Catalog.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(
    opt => opt.Filters.Add<HttpGlobalExceptionFilter>()
    ).AddJsonOptions(opt => opt.JsonSerializerOptions.WriteIndented = true);

builder.Services.AddSwaggerGen(
    opt => opt.SwaggerDoc("v1", 
    new OpenApiInfo
    {
        Version = "v1",
        Title = "FigurineShop-Catalog API",
        Description = "The Catalog service HTTP API"
    }
    ));

var config = GetConfiguration();
builder.Services.Configure<CatalogConfig>(config);

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddTransient<ICatalogItemRepository, CatalogItemRepository>();
builder.Services.AddTransient<ICatalogMaterialRepository, CatalogMaterialRepository>();
builder.Services.AddTransient<ICatalogSourceRepository, CatalogSourceRepository>();
builder.Services.AddTransient<ICatalogService, CatalogService>();
builder.Services.AddTransient<ICatalogSourceService, CatalogSourceService>();
builder.Services.AddTransient<ICatalogItemService, CatalogItemService>();
builder.Services.AddTransient<ICatalogMaterialService, CatalogMaterialService>();

builder.Services.AddDbContextFactory<ApplicationDbContext>(opts => opts.UseNpgsql(config["ConnectionString"]));
builder.Services.AddScoped<IDbContextWrapper<ApplicationDbContext>, DbContextWrapper<ApplicationDbContext>>();

var app = builder.Build();

app.UseSwagger()
    .UseSwaggerUI(setup =>
    {
        setup.SwaggerEndpoint($"{config["PathBase"]}/swagger/v1/swagger.json", "Catalog.API V1");
    });

if (!app.Environment.IsDevelopment())
{
    
    app.UseExceptionHandler("/Home/Error");
}

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
    endpoints.MapControllers();
});
// app.UseAuthorization();
CreateDbIfNotExists(app);
app.Run();

IConfiguration GetConfiguration()
{
    var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddEnvironmentVariables();

    return builder.Build();
}

void CreateDbIfNotExists(IHost host)
{
    using (var scope = host.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        try
        {
            var context = services.GetRequiredService<ApplicationDbContext>();

            DbInitializer.Initialize(context).Wait();
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "An error occurred creating the DB.");
        }
    }
}