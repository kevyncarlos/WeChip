using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeChip.Domain.Entities;

namespace WeChip.Data.Mappings
{
    public class OfertaMap : IEntityTypeConfiguration<Oferta>
    {
        public void Configure(EntityTypeBuilder<Oferta> builder)
        {
            builder.ToTable("Ofertas");
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Cliente)
                .WithMany(x => x.Ofertas)
                .HasForeignKey(x => x.ClienteId)
                .HasConstraintName("FK_Cliente_Oferta_ClienteId");
        }
    }
}
