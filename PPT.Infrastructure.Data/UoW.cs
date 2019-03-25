using PPT.Domain;
using PPT.Domain.entities;
using PPT.Infrastructure.Core;
using System.Data.Entity;

namespace PPT.Infrastructure.Data
{
    public class UoW : UnitOfWork
    {
        public UoW(string connectionStringName, string schema) : base(connectionStringName, schema)
        {
#pragma warning disable S125 // Sections of code should not be "commented out"
            //this.Database.Log = (s) => { Debug.Write(s); };
#pragma warning restore S125 // Sections of code should not be "commented out"
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblGame>().ToTable("tblGames", schema);
            modelBuilder.Entity<tblGame>().HasKey(s => s.Id);

            modelBuilder.Entity<tblPlayer>().ToTable("tblPlayers", schema);
            modelBuilder.Entity<tblPlayer>().HasKey(s => s.Id);

            modelBuilder.Entity<tblResultGame>().ToTable("tblResultGames", schema);
            modelBuilder.Entity<tblResultGame>().HasKey(s => s.Id);

   
            base.OnModelCreating(modelBuilder);
        }


    }
}
