using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
namespace MiddlewareSample
{
    public class Startup
    {

        public void Configure(IApplicationBuilder app)
        { 
            
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello ");
                await next.Invoke();
                await context.Response.WriteAsync("!");
            });
            app.UseMiddleware<MyMiddleWare>();
            app.Map("/Raj", HandleRaj);
           
            app.Run(async context =>
            {
                await context.Response.WriteAsync("World");
            });
        }
        
        private static void HandleRaj(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Raj");
            });
}   
        
        
            
    }
}