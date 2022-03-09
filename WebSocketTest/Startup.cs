using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;
using WebSocketTest.Middleware;
namespace WebSocketTest
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddWebSocketManager();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseWebSockets();

          
            app.UseWebSocketServer();

            app.Run(async context =>
            {
                Console.WriteLine("Hello from 3rd (terminal) Request Delegate");
                await context.Response.WriteAsync("Hello from 3rd (terminal) Request Delegate");
            });
      
        }

        public void WriteRequestParam(HttpContext httpContext)
        {
            Console.WriteLine("Request Method: " + httpContext.Request.Method);
            Console.WriteLine("Request Protocol: " + httpContext.Request.Protocol);

            if (httpContext.Request.Headers != null)
            {
                foreach (var j in httpContext.Request.Headers)
                {
                    Console.WriteLine("--> " + j.Key + " : " + j.Value);
                }
            }

        }

 
    }
}
