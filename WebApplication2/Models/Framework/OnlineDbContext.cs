using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Models.Framework
{
  public partial class OnlineDbContext : DbContext
  {
    public OnlineDbContext()
        : base("name=OnlineDbContext")
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }
    public virtual DbSet<UserInfor> UserInfors { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      //modelBuilder.Entity<Account>().Property(e => e.UserName).IsUnicode(false);
      //modelBuilder.Entity<Account>().Property(e => e.Password).IsUnicode(false);
    }
  }
}
