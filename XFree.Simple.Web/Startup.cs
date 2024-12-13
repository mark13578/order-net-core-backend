using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XFree.SimpleService.Host
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            // 添加 CORS 配置
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins", policy =>
                {
                    policy.AllowAnyOrigin() // 允許所有來源
                          .AllowAnyHeader() // 允許所有 Header
                          .AllowAnyMethod(); // 允許所有 HTTP 方法
                });
            });

            // 初始化應用程式服務
            services.AddApplication<SystemServiceHostModule>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="loggerFactory"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            // 啟用 CORS，套用之前定義的策略
            app.UseCors("AllowAllOrigins");

            // 初始化應用程式
            app.InitializeApplication();
        }
    }
}
