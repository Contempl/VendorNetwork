using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.Entity;

namespace Product.DAL.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
	public void Configure(EntityTypeBuilder<User> builder)
	{
		builder.ToTable("Users");

		builder.HasKey(u => u.Id);

		builder.Property(u => u.FirstName)
			.HasColumnName("FirstName")
			.HasMaxLength(50)
			.IsRequired(false);

		builder.Property(u => u.LastName)
			.HasColumnName("LastName")
			.HasMaxLength (50)
			.IsRequired(false);

		builder.Property(u => u.UserName)
			.HasColumnName("Username")
			.HasMaxLength(50)
			.IsRequired(false);

		builder.Property(u => u.PasswordHash)
			.HasColumnName("Password")
			.IsRequired(false);

		builder.Property(u => u.Email)
			.HasColumnName("Email")
			.IsRequired();

		builder.HasOne(u => u.Invite)
			.WithOne(i => i.User)
			.HasForeignKey<User>(u => u.InviteId)
			.IsRequired(false);
	}
}
