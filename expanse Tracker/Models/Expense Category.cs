using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using expanse_Tracker.Models;

namespace expanse_Tracker.Models
{
    
    public class Expense_Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }
    public class Expanses
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExpansesId { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Column(TypeName ="money")]
        public Decimal Amount { get; set; }
        [ForeignKey("Expense_Category")]
        public int Id { get; set; }
        public virtual Expense_Category Expense_Category { get; set; }
    }

    //public class ExpanseDbContext : IdentityDbContext<ApplicationUser>
    //{
    //    public ExpanseDbContext(DbContextOptions<ExpanseDbContext>options):base(options)
    //    {

    //    }
    //    protected override void OnModelCreating(ModelBuilder modelBuilder)
    //    {
    //        base.OnModelCreating(modelBuilder);
    //        modelBuilder.Entity<Expense_Category>()
    //            .HasIndex(x => x.CategoryName).IsUnique();
    //        modelBuilder.Entity<Signup>().HasNoKey();
    //        modelBuilder.Entity<Login>().HasNoKey();
    //        //modelBuilder.Entity<ApplicationUser>().HasNoKey();
    //    }
    //    public DbSet<Expense_Category> Expense_Categories { get; set; }
    //    public DbSet<Expanses> Expanses { get; set; }
    //    public DbSet<expanse_Tracker.Models.Signup> Signup { get; set; }
    //    public DbSet<expanse_Tracker.Models.Login> Login { get; set; }
    //}
}
