using ErrorOr;
using GymManagement.Application.Common.Interfaces;
using GymManagement.Domain.Subscription;
using MediatR;

namespace GymManagement.Application.Subscriptions.Commands.CreateSubscription;

public class CreateSubscriptionCommandHandler : IRequestHandler<CreateSubscriptionCommand, ErrorOr<Subscription>>
{
    private ISubscriptionRepository _subscriptionRepository;
    private IUnitOfWork _unitOfWork;

    public CreateSubscriptionCommandHandler(ISubscriptionRepository subscriptionRepository, IUnitOfWork unitOfWork)
    {
        _subscriptionRepository = subscriptionRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Subscription>> Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
    {
        var subscription = new Subscription
        {
            Id = request.AdminId,
            SubscriptionType = request.SubscriptionType
        };
        await _subscriptionRepository.AddSubscriptionAsync(subscription);
        await _unitOfWork.CommitChangesAsync();
        return subscription;
    }
}