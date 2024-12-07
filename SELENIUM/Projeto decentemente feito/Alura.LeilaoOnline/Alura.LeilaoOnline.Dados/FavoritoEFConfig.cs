using Alura.LeilaoOnline.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alura.LeilaoOnline.WebApp.Dados
{
    internal class FavoritoEFConfig : IEntityTypeConfiguration<Favorito>
    {
        public void Configure(EntityTypeBuilder<Favorito> builder)
        {
            builder.HasKey(f => new { f.LeilaoId, f.IdInteressada });
            builder
                .HasOne<Leilao>(f => f.LeilaoFavorito)
                .WithMany(l => l.Seguidores)
                .HasForeignKey(f => f.LeilaoId);
            builder
                .HasOne<Interessada>(f => f.Seguidor)
                .WithMany(i => i.Favoritos)
                .HasForeignKey(f => f.IdInteressada);
        }
    }
}