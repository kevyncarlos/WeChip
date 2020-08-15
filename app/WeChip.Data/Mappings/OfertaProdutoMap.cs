using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeChip.Domain.Entities;

namespace WeChip.Data.Mappings
{
    public class OfertaProdutoMap : IEntityTypeConfiguration<OfertaProduto>
    {
        public void Configure(EntityTypeBuilder<OfertaProduto> builder)
        {
            builder.ToTable("OfertaProdutos");
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Oferta)
                .WithMany(x => x.OfertaProdutos)
                .HasForeignKey(x => x.OfertaId)
                .HasConstraintName("FK_OfertaProduto_Oferta_OfertaId");

            builder.HasOne(x => x.Produto)
                .WithMany(x => x.OfertaProdutos)
                .HasForeignKey(x => x.ProdutoId)
                .HasConstraintName("FK_OfertaProduto_Produto_ProdutoId");
        }
    }
}
