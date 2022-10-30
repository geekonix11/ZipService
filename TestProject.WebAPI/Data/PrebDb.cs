using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ZipService.Models;

namespace ZipService.Data{
    public static class PrepDb{
        public static void PrepPopulation(IApplicationBuilder app, bool isProd){

            using(var serviceScope = app.ApplicationServices.CreateScope() ){
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>(), isProd);
            }


        }

        private static void SeedData(AppDbContext context, bool isProd){
            if(isProd){
                context.Database.Migrate();
                Console.WriteLine("...migrating");
            }
            else{

                if(!context.Users.Any()){
                 Console.WriteLine("...seeding data");
                 context.Users.AddRange(
                    new User() {Name="a", Email= "a@b.com", Expense=100, Salary =5000},
                    new User() {Name="b",Email= "b@b.com", Expense=100, Salary =5000},
                    new User() {Name="c",Email= "c@b.com", Expense=100, Salary =5000}
                 );
            context.SaveChanges();
            Console.WriteLine(context.Users.FirstOrDefault().Email);
            }
            else{

                Console.WriteLine("...We already have data");
                Console.WriteLine(context.Users.FirstOrDefault().Email);
            }
            }
            

        }
          
    }


}