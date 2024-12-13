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
            // �K�[ CORS �t�m
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins", policy =>
                {
                    policy.AllowAnyOrigin() // ���\�Ҧ��ӷ�
                          .AllowAnyHeader() // ���\�Ҧ� Header
                          .AllowAnyMethod(); // ���\�Ҧ� HTTP ��k
                });
            });

            // ��l�����ε{���A��
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
            // �ҥ� CORS�A�M�Τ��e�w�q������
            app.UseCors("AllowAllOrigins");

            // ��l�����ε{��
            app.InitializeApplication();
        }
    }
}
