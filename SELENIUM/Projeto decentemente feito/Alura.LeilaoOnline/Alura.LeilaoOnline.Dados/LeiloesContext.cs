using Microsoft.EntityFrameworkCore;
using Alura.LeilaoOnline.Core;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Alura.LeilaoOnline.WebApp.Dados
{
    public class LeiloesContext : DbContext
    {
        public DbSet<Leilao> Leiloes { get; set; }
        public DbSet<Interessada> Interessada { get; set; }
        public DbSet<Lance> Lance { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Favorito> Favoritos { get; set; }

        public LeiloesContext(DbContextOptions<LeiloesContext> dbContextOptions) :
        base(dbContextOptions)
        { }


        //
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //string stringconexao = "server=localhost;" +
        //    //                      "DataBase=bytebankBD_webapp;Uid=root;Pwd=root";
        //    //string stringconexao = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ByteBank;Connect Timeout=30";
        //    string stringconexao = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ByteBank;Connect Timeout=30;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        //    optionsBuilder.UseSqlServer(stringconexao);
        //}
        //


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration<Leilao>(new LeilaoEFConfig());
            modelBuilder.ApplyConfiguration<Lance>(new LanceEFConfig());
            modelBuilder.ApplyConfiguration<Interessada>(new InteressadaEFConfig());
            modelBuilder.ApplyConfiguration<Usuario>(new UsuarioEFConfig());
            modelBuilder.ApplyConfiguration<Favorito>(new FavoritoEFConfig());

        }
    }
}
