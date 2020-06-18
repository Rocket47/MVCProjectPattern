using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MVCApps.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace MVCApps
{
    public class Program
    {      
        public static void Main(string[] args)
        {           
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var Services = scope.ServiceProvider;
                try
                {
                    var context = Services.GetRequiredService<UniversityContext>();                   
                    if (context.Courses.ToList().Count == 0)
                    {
                        context.Database.ExecuteSqlRaw("INSERT INTO [COURSES] ([NAME], [DESCRIPTION]) VALUES ('Математика', 'Учим математику')");
                        context.Database.ExecuteSqlRaw("INSERT INTO [COURSES] ([NAME], [DESCRIPTION]) VALUES ('Физика', 'Учим физику')");
                        context.Database.ExecuteSqlRaw("INSERT INTO [COURSES] ([NAME], [DESCRIPTION]) VALUES ('Статистика', 'Учим статистику')");
                        context.Database.ExecuteSqlRaw("INSERT INTO [COURSES] ([NAME], [DESCRIPTION]) VALUES ('Лингвистика', 'Учим лингвистику')");
                        context.Database.ExecuteSqlRaw("INSERT INTO [COURSES] ([NAME], [DESCRIPTION]) VALUES ('Тайм менеджмент', 'Учим тайм менеджмент')");
                        context.Database.ExecuteSqlRaw("INSERT INTO [GROUPS] ([COURSE_ID], [NAME]) VALUES ('1', 'SR1')");
                        context.Database.ExecuteSqlRaw("INSERT INTO [GROUPS] ([COURSE_ID], [NAME]) VALUES ('2', 'SR2')");
                        context.Database.ExecuteSqlRaw("INSERT INTO [GROUPS] ([COURSE_ID], [NAME]) VALUES ('3', 'SR3')");
                        context.Database.ExecuteSqlRaw("INSERT INTO [GROUPS] ([COURSE_ID], [NAME]) VALUES ('4', 'SR4')");
                        context.Database.ExecuteSqlRaw("INSERT INTO [GROUPS] ([COURSE_ID], [NAME]) VALUES ('5', 'SR5')");
                        context.Database.ExecuteSqlRaw("INSERT INTO [STUDENTS] ([GROUP_ID], [FIRST_NAME], [LAST_NAME]) VALUES ('1', 'Владимир', 'Добрый')");
                        context.Database.ExecuteSqlRaw("INSERT INTO [STUDENTS] ([GROUP_ID], [FIRST_NAME], [LAST_NAME]) VALUES ('2', 'Гоша', 'Злой')");
                        context.Database.ExecuteSqlRaw("INSERT INTO [STUDENTS] ([GROUP_ID], [FIRST_NAME], [LAST_NAME]) VALUES ('3', 'Марина', 'Иванова')");
                        context.Database.ExecuteSqlRaw("INSERT INTO [STUDENTS] ([GROUP_ID], [FIRST_NAME], [LAST_NAME]) VALUES ('4', 'Зоя', 'Чехова')");
                        context.Database.ExecuteSqlRaw("INSERT INTO [STUDENTS] ([GROUP_ID], [FIRST_NAME], [LAST_NAME]) VALUES ('5', 'Арина', 'Долгова')");
                        context.SaveChanges();
                    }
                    SampleData.Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = Services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred seeding the DB");
                }
                host.Run();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });      
    }
}
