namespace GymManagement.Domain.Subscriptions;

public class Subscription
{
    public Guid AdminId { get; }
    public Guid Id { get; private set; }
    public SubscriptionType SubscriptionType { get; private set; }

    public Subscription(Guid adminId, SubscriptionType subscriptionType, Guid? id = null)
    {
        AdminId = adminId;
        Id = id ?? Guid.NewGuid();
        SubscriptionType = subscriptionType;
    }

    // EF Core constructor
    private Subscription()
    {
    }
}