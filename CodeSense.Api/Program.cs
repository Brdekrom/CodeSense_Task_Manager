using CodeSense.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddInMemoryDatabase(); // Make sure you have implemented this extension method for in-memory database.
builder.Services.AddScoped<IEmployeeService, EmployeeService>(); // Example of service registration
builder.Services.AddHealthChecks(); // Health checks

// Configure Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "CodeSense.Api", Version = "v1" });
});

// Build the application
var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CodeSense.Api v1"));
}

app.UseHttpsRedirection();

app.UseAuthentication();  // If you're using authentication
app.UseAuthorization();

app.UseHealthChecks("/health"); // Health checks endpoint

app.MapControllers();

app.Run();

