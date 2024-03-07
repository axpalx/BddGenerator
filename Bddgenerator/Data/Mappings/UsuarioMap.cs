using Bddgenerator.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace Bddgenerator.Data.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");
            builder.ToTable(t => t.HasComment("Tabela de usuário"));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasComment("Código do usuário");

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(255)
                .HasComment("Nome do usuário");

            builder
                .HasIndex(x => x.Nome, "IX_Usuário_Nome");

            builder.Property(x => x.Email)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(254)
                .HasComment("E-mail do usuário");

            builder
                .HasIndex(x => x.Email, "IX_Usuario_Email")
                .IsUnique();

            builder.Property(x => x.Senha)
                .IsRequired()
                .HasColumnName("Senha")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(84)
                .HasComment("Senha do usuário");

            builder.Property(x => x.Data_Criacao)
                .IsRequired()
                .HasColumnName("Data_Criacao")
                .HasColumnType("DATETIME")
                .HasComment("Data em que o usuário foi criado");

            builder.Property(x => x.Status)
                .HasColumnName("Status")
                .HasColumnType("BIT")
                .HasComment("Indica se o usuário está ativo ou inativo");
        }
    }
}
