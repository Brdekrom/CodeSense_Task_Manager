using CodeSense.Application;
using CodeSense.Domain;
using CodeSense.Infrastructure;
using CodeSense.Infrastructure.Data;
using CodeSense.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddInMemoryDatabase();
builder.Services.AddApplicationServices();
builder.Services.AddDomainLayer();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "CodeSense.Api", Version = "v1" });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<CodeSenseDbContext>();
    DbInitializer.Seed(context);
}

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("./swagger/v1/swagger.json", "");
        c.RoutePrefix = string.Empty;
    });
}

app.UseRouting();
app.UseHttpsRedirection();

app.MapControllers();

app.Run();