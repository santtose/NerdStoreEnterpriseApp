using Microsoft.AspNetCore.HttpOverrides;
using NSE.WebApp.MVC.Extensions;

namespace NSE.WebApp.MVC.Configuration
{
    public static class WebAppConfig
    {
        public static void AddMvcConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllersWithViews();

            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders =
                    ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });

            services.Configure<AppSettings>(configuration);
        }

        public static void UseMvcConfiguration(this WebApplication app)
        {
            app.UseForwardedHeaders();

            if (app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/erro/500");
                app.UseStatusCodePagesWithRedirects("/erro/{0}");

                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseIdentityConfiguration();

            app.UseMiddleware<ExceptionMiddleware>();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Catalogo}/{action=Index}/{id?}");
        }
    }
}
