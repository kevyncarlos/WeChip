using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeChip.Domain.Entities;

namespace WeChip.Data.Mappings
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.StatusAtual)
                .WithMany(x => x.Clientes)
                .HasForeignKey(x => x.StatusAtualId)
                .HasConstraintName("FK_Cliente_Status_StatusAtualId");

            builder.OwnsOne(x => x.EnderecoEntrega);
        }
    }
}
