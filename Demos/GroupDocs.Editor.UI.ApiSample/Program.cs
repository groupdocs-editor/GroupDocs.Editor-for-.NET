using GroupDocs.Editor.UI.Api.Extensions;
using GroupDocs.Editor.UI.Api.Services.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddEditorControllers(builder.Configuration);
builder.Services.AddEditorSwagger();
builder.Services.AddEditor<LocalStorage>(builder.Configuration);
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
