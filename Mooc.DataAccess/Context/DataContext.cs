using Mooc.DataAccess.Entities.EntityConfig;
using Mooc.Models.Entities;
using System.Configuration;
using System.Data.Entity;

namespace Mooc.DataAccess.Context
{
    public class DataContext : DbContext, IDataContextProvider
    {

        public DataContext(): base(GetConnectionString())
        {
           
        }

        //public DataContext() 
        //{
        //    Database.Connection.ConnectionString= ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        //}

        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.UserModelBuilder();
            modelBuilder.StudentModelBuilder();
        }

        public DataContext GetDataContext()
        {
            return this;
        }
    }
}
