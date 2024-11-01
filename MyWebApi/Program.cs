using Microsoft.AspNetCore.Mvc;
using MyWebApi.Data;
using MyWebApi.Services;
using StackExchange.Profiling;


var builder = WebApplication.CreateBuilder(args);

// Other service configurations
builder.Services.AddControllers();

//// Add MiniProfiler services
builder.Services.AddMiniProfiler(options =>
{
    options.RouteBasePath = "/profiler"; // Base path for MiniProfiler
    options.PopupStartHidden = true; // Optional: start with the popup hidden
    // Additional options can be set here

});




// DI
builder.Services.AddScoped<DapperContext>();
builder.Services.AddScoped<IMyService, MyService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Use MiniProfiler middleware
app.UseMiniProfiler();
app.UseRouting(); // Ensure this comes after MiniProfiler

app.UseAuthorization();
app.MapControllers();
app.Run();