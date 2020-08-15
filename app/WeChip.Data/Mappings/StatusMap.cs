using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeChip.Domain.Entities;

namespace WeChip.Data.Mappings
{
    public class StatusMap : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasData(
                new Status { Id = 1, Descricao = "Nome Livre", FinalizaCliente = false, ContabilizaVenda = false, CodigoStatus = "0001" },
                new Status { Id = 2, Descricao = "Não deseja ser contatado", FinalizaCliente = true, ContabilizaVenda = false, CodigoStatus = "0007" },
                new Status { Id = 3, Descricao = "Cliente Aceitou Oferta", FinalizaCliente = true, ContabilizaVenda = true, CodigoStatus = "0009" },
                new Status { Id = 4, Descricao = "Caiu a ligação", FinalizaCliente = false, ContabilizaVenda = false, CodigoStatus = "0015" },
                new Status { Id = 5, Descricao = "Viajou", FinalizaCliente = false, ContabilizaVenda = false, CodigoStatus = "0019" },
                new Status { Id = 6, Descricao = "Falecido", FinalizaCliente = true, ContabilizaVenda = false, CodigoStatus = "0021" });
        }
    }
}
