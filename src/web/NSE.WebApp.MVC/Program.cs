using NSE.WebApp.MVC.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentityConfiguration();

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseMvcConfiguration();

app.Run();
