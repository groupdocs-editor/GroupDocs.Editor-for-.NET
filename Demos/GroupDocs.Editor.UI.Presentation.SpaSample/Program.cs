using GroupDocs.Editor.UI.Api.Extensions;
using GroupDocs.Editor.UI.Api.Services.Implementation;
using GroupDocs.Editor.UI.Api.Services.Licensing;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEditorControllers();
builder.Services.AddEditorSwagger();
// uncomment for set license
builder.Services.AddEditorLicense<LocalFileLicenseService>(builder.Configuration);
builder.Services.AddEditor<LocalStorage>(builder.Configuration);
builder.Services.AddCors(p => p.AddPolicy("corsApp", policy =>
{
    policy.WithOrigins("*").AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
}));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

if (app.Environment.IsDevelopment())
{
    app.UseEditorSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("corsApp");

app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
