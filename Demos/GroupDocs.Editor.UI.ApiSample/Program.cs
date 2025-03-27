using GroupDocs.Editor.UI.Api.Extensions;
using GroupDocs.Editor.UI.Api.Services.Implementation;
using GroupDocs.Editor.UI.Api.Services.Licensing;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddEditorControllers();
builder.Services.AddEditorSwagger();
// uncomment for set license
builder.Services.AddEditorLicense<Base64FileLicenseService>(builder.Configuration);
builder.Services.AddEditor<AwsS3Storage>(builder.Configuration);
builder.Services.AddCors(p => p.AddPolicy("corsApp", policy =>
{
    policy.WithOrigins("*").AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
}));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseEditorSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("corsApp");
app.UseAuthorization();

app.MapControllers();

app.Run();
