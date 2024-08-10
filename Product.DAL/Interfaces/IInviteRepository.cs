using Product.Domain.Entity;

namespace Product.DAL.Interfaces;

public interface IInviteRepository : IRepository<Invite>
{
	Task<Invite> GetByIdAsync(int inviteId);
}