using Kiss4Web.IdentityServer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddSingleton(typeof(IMyDependency<,>), typeof(MyDependency));
// or 
//builder.Services.AddSingleton<IMyDependency, MyDependency>();

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

app.UseAuthorization();

app.MapGet("/hello", () => "Hello guy! this is sample project Idsr4 & minimal-API NET6 implementation for KISS Principle");

app.Run();
