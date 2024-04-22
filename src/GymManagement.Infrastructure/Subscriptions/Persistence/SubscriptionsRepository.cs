using GymManagement.Domain.Subscription;
using GymManagement.Application.Common.Interfaces;

namespace GymManagement.Infrastructure.Subscriptions.Persistence;

public class SubscriptionsRepository: ISubscriptionsRepository
{
    private static readonly List<Subscription> _subscriptions = new();
    public Task AddSubscriptionAsync(Subscription subscription)
    {
        _subscriptions.Add(subscription);
        return Task.CompletedTask;
    }
    public Task<Subscription?> GetByIdAsync(Guid subscriptionId)
    {
        var subscription = _subscriptions.FirstOrDefault(s => s.Id == subscriptionId);
        return Task.FromResult(subscription);
    }
}