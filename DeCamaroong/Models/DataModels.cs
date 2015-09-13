using DeCamaroong.Domain;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace DeCamaroong.Models
{
    public class DBContext : IdentityDbContext<User>
    {
        public DBContext()
            : base("applicationDB")
        {

        }
        //Override default table names
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public static DBContext Create()
        {
            return new DBContext();
        }

        public DbSet<BlogItem> BlogItems { get; set; }
        public DbSet<Mail> Mails { get; set; }
        public DbSet<PropertyBuilding> Buildings {get;set;}
        public DbSet<Gallery> Galleries { get; set; }

    }

    //This function will ensure the database is created and seeded with any default data.
    public class DBInitializer : CreateDatabaseIfNotExists<DBContext>
    {
        protected override void Seed(DBContext context)
        {
            //Create an seed data you wish in the database.
        }
    }
}

