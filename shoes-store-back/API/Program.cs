using API;
using WebAPI.Utils.Middlewares;

var builder = WebApplication.CreateBuilder(args);

var apiPolicy = "ShoesStorePolicy";

builder.Services.AddInfrastructure();
builder.Services.AddWebAPI();

builder.Services.AddCors(options =>
{
    options.AddPolicy(apiPolicy, policy =>
    {
        policy.WithOrigins("http://localhost:3000")
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(apiPolicy);

app.UseMiddleware<JWTAuthenticationMiddleware>();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
