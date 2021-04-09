using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZTPProject
{
    public class DBConnection
    {

        private ZTPContext context;
        private DBConnection() { }
        private static DBConnection instance = null;
        public static DBConnection GetInstance()
        {
            if (instance == null)
            {
                instance = new DBConnection();
            }
            return instance;
        }
       public void CreateContext()
        {
            ServiceProvider serviceProvider;
            ServiceCollection services = new ServiceCollection();
            services.AddDbContext<ZTPContext>(options =>
            {
                options.UseSqlite("Data Source = ZTP.db");
            });
            serviceProvider = services.BuildServiceProvider();
            var x = serviceProvider.GetService<ZTPContext>();
            context = x;
        }
        public ZTPContext GetContext()
        {
            return context;
        }
    }
}
