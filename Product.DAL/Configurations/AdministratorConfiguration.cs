using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.Entity;

namespace Product.DAL.Configurations;

public class AdministratorConfiguration : IEntityTypeConfiguration<Administrator>
{
	public void Configure(EntityTypeBuilder<Administrator> builder)
	{
		builder.ToTable("Administrators");

		builder.HasKey(admin => admin.Id)
			.HasName("Id");

		builder.Property(admin => admin.UserName)
			.HasColumnName("Username")
			.HasMaxLength(50)
			.IsRequired();

		builder.Property(admin => admin.PasswordHash)
			.HasColumnName("Password")
			.IsRequired();

		builder.HasMany(admin => admin.Invites)
			.WithOne(invite => invite.Admin)
			.HasForeignKey(invite => invite.AdminId);

		builder.Property(admin => admin.FirstName)
			.HasColumnName("FirstName")
			.HasMaxLength(50)
			.IsRequired();

		builder.Property(admin => admin.LastName)
			.HasColumnName("LastName")
			.HasMaxLength(50)
			.IsRequired();

		builder.Property(admin => admin.Email)
			.HasColumnName("Email")
			.HasMaxLength(50)
			.IsRequired();
	}
}
