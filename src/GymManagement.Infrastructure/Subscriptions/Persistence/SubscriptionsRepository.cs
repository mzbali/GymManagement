using GymManagement.Domain.Subscriptions;
using GymManagement.Application.Common.Interfaces;
using GymManagement.Infrastructure.Common.Persistence;

namespace GymManagement.Infrastructure.Subscriptions.Persistence;

public class SubscriptionsRepository : ISubscriptionsRepository
{
    private readonly GymManagementDbContext _dbContext;

    public SubscriptionsRepository(GymManagementDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddSubscriptionAsync(Subscription subscription)
    {
        _dbContext.Subscriptions.Add(subscription);
    }
    public async Task<Subscription?> GetByIdAsync(Guid subscriptionId)
    {
        return await _dbContext.Subscriptions.FindAsync(subscriptionId);
    }
}