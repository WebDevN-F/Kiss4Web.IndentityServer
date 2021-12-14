using IdentityServer4.Services;
using IdentityServer4.Validation;
using Kiss4Web.IdentityServer;
using Kiss4Web.Infrastructure.Authentication;
using SimpleInjector;

Container _container = new Container();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add cors requests
builder.Services.AddCors();

_container.RegisterSingleton<IResourceOwnerPasswordValidator, Kiss4PasswordValidator>();
_container.RegisterSingleton<IProfileService, Kiss4ProfileService>();
_container.RegisterSingleton(() => new Scrambler("kiSS4"));

// configure identity server with in-memory stores, keys, clients and resources
builder.Services.AddIdentityServer(options => options.IssuerUri = builder.Configuration["Authentication:Authority"])
        .AddDeveloperSigningCredential()
        .AddInMemoryApiResources(AuthenticationConfig.GetApiResources())
        .AddInMemoryClients(AuthenticationConfig.GetClients())
        .Services.AddTransient(sp => _container.GetInstance<IResourceOwnerPasswordValidator>())
                 .AddTransient(sp => _container.GetInstance<IProfileService>());

_container.Verify();

//var passhash = new Scrambler("kiSS4").EncryptString("kiSS4web");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseIdentityServer();
app.UseCors(builder =>
       builder.AllowAnyOrigin()
       .AllowAnyHeader()
       .AllowAnyMethod());

app.MapGet("/", () => "Hello guy! this is sample project Idsr4 & minimal-API NET6 implementation for KISS Principle");

app.Run();
