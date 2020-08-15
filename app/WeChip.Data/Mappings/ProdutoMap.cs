using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeChip.Domain.Entities;
using WeChip.Domain.Enums;

namespace WeChip.Data.Mappings
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produtos");
            builder.HasKey(x => x.Id);

            builder.HasData(
                new Produto { Id = 1, Descricao = "Mouse", Preco = "20,00", Tipo = TipoProduto.HARDWARE, CodigoProduto = "00015" },
                new Produto { Id = 2, Descricao = "Teclado", Preco = "30,00", Tipo = TipoProduto.HARDWARE, CodigoProduto = "00106" },
                new Produto { Id = 3, Descricao = "Monitor 17’", Preco = "350,00", Tipo = TipoProduto.HARDWARE, CodigoProduto = "00200" },
                new Produto { Id = 4, Descricao = "Pen Drive 8 GB", Preco = "30,00", Tipo = TipoProduto.HARDWARE, CodigoProduto = "00211" },
                new Produto { Id = 5, Descricao = "Pen Drive 16 GB", Preco = "50,00", Tipo = TipoProduto.HARDWARE, CodigoProduto = "00314" },
                new Produto { Id = 6, Descricao = "AVAST", Preco = "199,99", Tipo = TipoProduto.SOFTWARE, CodigoProduto = "00459" },
                new Produto { Id = 7, Descricao = "Pacote Office", Preco = "499,00", Tipo = TipoProduto.SOFTWARE, CodigoProduto = "01104" },
                new Produto { Id = 8, Descricao = "Spotify (3 meses)", Preco = "45,50", Tipo = TipoProduto.SOFTWARE, CodigoProduto = "01108" },
                new Produto { Id = 9, Descricao = "Netflix (1 mês)", Preco = "19,90", Tipo = TipoProduto.SOFTWARE, CodigoProduto = "01107" });
        }
    }
}
