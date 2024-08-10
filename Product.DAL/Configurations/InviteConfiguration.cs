using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.Entity;

namespace Product.DAL.Configurations;

internal class InviteConfiguration : IEntityTypeConfiguration<Invite>
{
	public void Configure(EntityTypeBuilder<Invite> builder)
	{
		builder.ToTable("Invites");

		builder.HasKey(invite => invite.Id);

		builder.Property(invite => invite.CreatedAt)
			.HasColumnName("CreatedAt");

		builder.Property(invite => invite.ExpiresAt)
			.HasColumnName("ExpiresAt");

		builder.HasOne(invite => invite.Admin)
			.WithMany(admin => admin.Invites)
			.HasForeignKey(invite => invite.AdminId)
			.OnDelete(DeleteBehavior.Restrict);

		builder.HasOne(invite => invite.User)
			.WithOne(user => user.Invite)
			.HasForeignKey<Invite>(invite => invite.UserId)
			.OnDelete(DeleteBehavior.Restrict);
	}
}
