using Bddgenerator.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bddgenerator.Data.Mappings
{
    public class ProjetoMap : IEntityTypeConfiguration<Projeto>
    {
        public void Configure(EntityTypeBuilder<Projeto> builder)
        {
            builder.ToTable("Projeto");
            builder.ToTable(t => t.HasComment("Tabela de Projeto"));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(255)
                .HasComment("Nome do projeto");

            builder
                .HasIndex(x => x.Nome, "IX_Projeto_Nome")
                .IsUnique();

            builder.Property(x => x.Descricao)
                .IsRequired()
                .HasColumnName("Descricao")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(1000)
                .HasComment("Descrição do projeto");

            builder.Property(x => x.Quantidade_Sprint)
                .IsRequired()
                .HasColumnName("Quantidade_Sprint")
                .HasColumnType("INT")
                .HasComment("Quantidade de sprints que o projeto irá ter");

            builder.Property(x => x.Data_Criacao)
                .IsRequired()
                .HasColumnName("Data_Criacao")
                .HasColumnType("DATETIME")
                .HasComment("Data em que o projeto foi criado no sistema");

            builder.Property(x => x.Criado_Por)
                .HasColumnName("Criado_Por")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(254)
                .HasComment("Nome de quem criou o projeto no sistema");
        }
    }
}
