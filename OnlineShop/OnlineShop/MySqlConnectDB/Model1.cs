using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace MySqlConnectDB
{
  public partial class Model1 : DbContext
  {
    public Model1()
        : base("name=Model1")
    {
    }

    public virtual DbSet<product> products { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Entity<product>()
          .Property(e => e.Name)
          .IsUnicode(false);

      modelBuilder.Entity<product>()
          .Property(e => e.Description)
          .IsUnicode(false);
    }
  }
}
