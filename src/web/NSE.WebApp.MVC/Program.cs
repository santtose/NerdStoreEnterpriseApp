using NSE.WebApp.MVC.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentityConfiguration();

builder.Services.AddControllersWithViews();

builder.Services.RegisterServices();

var app = builder.Build();

app.UseMvcConfiguration();

app.Run();
