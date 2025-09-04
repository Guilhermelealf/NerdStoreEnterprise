using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using NSE.Identidade.API.Configuration;
using NSE.Identidade.API.Extensions;


var builder = WebApplication.CreateBuilder(args);

builder.AddDbConfig();

builder.AddIdentityConfig();

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.AddSwaggerConfig();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
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
