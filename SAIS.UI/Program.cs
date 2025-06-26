using AspNetCoreHero.ToastNotification;
using Microsoft.EntityFrameworkCore;
using SAIS.API.Extentions;
using SAIS.Core.Domain.IRepository;
using SAIS.Core.IServices;
using SAIS.Core.Services;
using SAIS.Infra.DbContexts;
using SAIS.Infra.Persistence;
using SAIS.Infra.Repository;
using System;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();

// Add DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<IGenderRepo, GenderRepo>();
builder.Services.AddScoped<IGenderService, GenderService>();

builder.Services.AddScoped<IProgrammesRepo, ProgrammesRepo > ();
builder.Services.AddScoped<IProgrammesService, ProgrammesService>();

builder.Services.AddScoped<IMaritualStatusRepo, MaritualStatusRepo>();
builder.Services.AddScoped<IMaritualStatusServices, MaritualStatusService>();


builder.Services.AddScoped<IApplicationRepo, ApplicationRepo>();

builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


//builder.Services.AddControllers()
//    .AddJsonOptions(options =>
//    {
//        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
//        options.JsonSerializerOptions.WriteIndented = true;
//    });

// Register API Services
builder.Services.AddApiServices(builder.Configuration);

// Toast messages
builder.Services.AddNotyf(config =>
{
    config.DurationInSeconds = 10;
    config.IsDismissable = true;
    config.Position = NotyfPosition.TopCenter;
    config.IsDismissable = true;
    config.HasRippleEffect = true;
});


builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "CorsApi",
        builder =>
        {
            builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .SetIsOriginAllowed(hostName => true);
        });
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Visitors");


    });
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Visitors");


    });
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<AppDbContext>();

    await LookUpDataSeeder.SeedAsync(dbContext);
}


app.Run();
