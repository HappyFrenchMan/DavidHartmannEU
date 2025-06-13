using DHA.BUSINESS.Interface;
using DHA.BUSINESS.Service;
using DHA.FRONT.MVC.CustomMiddleWare;
using DHA.UTIL.Log4Net;


//using DHA.ErrorHandling;
using log4net;
using log4net.Config;

public class Program
{
    public static void Main(string[] args)
    {        
        // Init Log4Net with his config file
        sLog4NetLogger.sInitConfig();

        // Configuration du Generateur d'application h�te 
        // Ajout des services pour l injection de d�pendaance
        // On souhaite uniquement du MVC avec des vues
        WebApplicationBuilder wab = WebApplication.CreateBuilder(args);        
        wab.Services.AddControllersWithViews();
        wab.Services.AddSingleton<ICVReadService, CVReadService>();
        wab.Services.AddSingleton<IDOCReadService, DOCReadService>();

        //  Application web utilis�e pour configurer le pipeline HTTP et les itin�raires.
        WebApplication wa = wab.Build();
        // En production uniquement -> page d'erreur
        //if (wa.Environment.IsDevelopment())
        //{
        //    wa.UseDeveloperExceptionPage();
        //}
        //else
        //{
        //    // Adds a middleware to the pipeline that will catch exceptions
        //    // log them, reset the request path, and re-execute the request.
        //    wa.UseExceptionHandler("/Home/Error");
        //}

        wa.UseHttpsRedirection();

        wa.UseRequestDuration();

        wa.UseStaticFiles();
        wa.UseRouting();
        wa.UseAuthorization();
        wa.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        // Ex�cute une application et bloque le thread appelant jusqu�� l�arr�t de l�h�te.
        wa.Run();
    }//RunWebSite




}//class