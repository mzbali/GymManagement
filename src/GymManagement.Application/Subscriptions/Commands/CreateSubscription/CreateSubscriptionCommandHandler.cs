using ErrorOr;
using GymManagement.Application.Common.Interfaces;
using GymManagement.Domain.Subscription;
using MediatR;

namespace GymManagement.Application.Subscriptions.Commands.CreateSubscription;

public class CreateSubscriptionCommandHandler : IRequestHandler<CreateSubscriptionCommand, ErrorOr<Subscription>>
{
    private ISubscriptionsRepository _subscriptionsRepository;
    // private IUnitOfWork _unitOfWork;

    public CreateSubscriptionCommandHandler(ISubscriptionsRepository subscriptionsRepository)
    {
        _subscriptionsRepository = subscriptionsRepository;
    }

    public async Task<ErrorOr<Subscription>> Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
    {
        var subscription = new Subscription
        {
            Id = request.AdminId,
            SubscriptionType = request.SubscriptionType
        };
        await _subscriptionsRepository.AddSubscriptionAsync(subscription);
        // await _unitOfWork.CommitChangesAsync();
        return subscription;
    }
}