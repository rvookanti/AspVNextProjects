using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
namespace MiddlewareSample{

public class MyMiddleWare{
    RequestDelegate _next;
    public MyMiddleWare(RequestDelegate  next){
        _next = next;
    }
    public async Task Invoke(HttpContext context){
        await context.Response.WriteAsync(" MyMiddleWare ");
        await _next.Invoke(context);
    }
}
}