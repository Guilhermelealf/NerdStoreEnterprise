using NSE.Identidade.API.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.AddDbConfig();

builder.AddIdentityConfig();

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.AddSwaggerConfig();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.AddSwaggerConfig();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
