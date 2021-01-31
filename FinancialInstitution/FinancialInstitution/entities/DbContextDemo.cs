using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialInstitution.entities
{
    

    public class DbContextDemo : DbContext
    {
        const string DbName = "financialinstitution-10.mdf";
        static string DbPath = Path.Combine(Environment.CurrentDirectory, DbName);
        

        public DbContextDemo() : base($@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={DbPath};Integrated Security=True;Connect Timeout=30")
        { }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>()
                .HasRequired<User>(s => s.User)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Transaction>()
                .HasRequired<Account>(s => s.Account)
                .WithMany()
                .WillCascadeOnDelete(false);
        }
        

        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }


    }
}
