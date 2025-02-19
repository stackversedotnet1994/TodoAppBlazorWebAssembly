using Microsoft.EntityFrameworkCore;
using TodoAppBlazorWebAssembly.Infrastructure.Data;
using TodoAppBlazorWebAssembly.Server.Extensions;
using TodoAppBlazorWebAssembly.Server.Interfaces;
using TodoAppBlazorWebAssembly.Server.Services;

var builder = WebApplication.CreateBuilder(args);
ConfigureServices(builder.Services, builder.Configuration);
var app = builder.Build();

ConfigureMiddleware(app, app.Environment.IsDevelopment());
ConfigureEndpoints(app);
OnBeforeRun(app);

app.Run();


void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    services.AddDbContext<EFCoreContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

    builder.Services.AddScoped<ITodoService, TodoService>();

    builder.Services.AddControllersWithViews();
    builder.Services.AddRazorPages();
}

void ConfigureMiddleware(WebApplication app, bool isDevelopmentMode)
{
    if (isDevelopmentMode)
    {
        app.UseWebAssemblyDebugging();
    }
    else
    {
        app.UseExceptionHandler("/Error");
        app.UseHsts();
    }

    app.UseMiddleware<ExceptionHandlingMiddleware>();
    app.UseHttpsRedirection();
    app.UseBlazorFrameworkFiles();
    app.UseStaticFiles();

    app.UseRouting();
}

void ConfigureEndpoints(IEndpointRouteBuilder app)
{
    app.MapControllers();
    app.MapFallbackToFile("index.html");
}

void OnBeforeRun(IHost app)
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;

        var context = services.GetRequiredService<EFCoreContext>();
        context.Database.Migrate();
    }
}