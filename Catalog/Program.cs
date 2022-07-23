using Infrastructure.Filters;
using Microsoft.OpenApi.Models;
using Catalog.Configurations;
using Catalog.Repositories.Interfaces;
using Catalog.Repositories;
using Catalog.Services.Interfaces;
using Catalog.Services;
using Catalog.Data;
using Infrastructure.Extensions;
using Microsoft.Extensions.DependencyInjection;

var config = GetConfiguration();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(
    opt => opt.Filters.Add<HttpGlobalExceptionFilter>())
    .AddJsonOptions(opt => opt.JsonSerializerOptions.WriteIndented = true);

builder.Services.AddSwaggerGen(
    opt =>
    {
        opt.SwaggerDoc(
            "v1",
            new OpenApiInfo
        {
            Version = "v1",
            Title = "FigurineShop-Catalog API",
            Description = "The Catalog service HTTP API"
        });
        var authority = config["Authorization:Authority"];
        opt.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
        {
            Type = SecuritySchemeType.OAuth2,
            Flows = new OpenApiOAuthFlows()
            {
                Implicit = new OpenApiOAuthFlow()
                {
                    AuthorizationUrl = new Uri($"{authority}/connect/authorize"),
                    TokenUrl = new Uri($"{authority}/connect/token"),
                    Scopes = new Dictionary<string, string>()
                    {
                        { "mvc", "website" },
                        { "roleidentity", "role" }
                    }
                },
            }
        });
        opt.OperationFilter<AuthorizeCheckOperationFilter>();
    });

builder.AddConfiguration();

builder.Services.Configure<CatalogConfig>(config);

builder.Services.AddAuthorization(config);

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

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "CorsPolicy",
        builder => builder
            .SetIsOriginAllowed((host) => true)
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
});

var app = builder.Build();

app.UseSwagger()
    .UseSwaggerUI(setup =>
    {
        setup.SwaggerEndpoint($"{config["PathBase"]}/swagger/v1/swagger.json", "Catalog.API V1");
        setup.OAuthClientId("catalogswaggerui");
        setup.OAuthAppName("Catalog Swagger UI");
    });

app.UseRouting();
app.UseCors("CorsPolicy");
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endPounts =>
{
    endPounts.MapDefaultControllerRoute();
    endPounts.MapControllers();
});

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