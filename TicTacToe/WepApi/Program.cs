using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using TicTacToe.WepApi.Controllers.Exceptions;
using TicTacToe.WepApi.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<GameService>();
builder.Services.AddControllers();
builder.Services.AddMvc(
        config => {
            config.Filters.Add(typeof(ExceptionFilter));
        }
    );

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
app.UseExceptionHandler(
 options => {
     options.Run(
     async context =>
     {
         context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
         context.Response.ContentType = "text/html";
         var ex = context.Features.Get<IExceptionHandlerFeature>();
         if (ex != null)
         {
             var err = $"<h1>Error: {ex.Error.Message}</h1>{ex.Error.StackTrace}";
             await context.Response.WriteAsync(err).ConfigureAwait(false);
         }
     });
 }
);


app.MapControllerRoute(
    name: "tic-tac-toe",
    pattern: "{controller}/{action}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
