using GymManagement.Domain.Subscription;
using MediatR;
using ErrorOr;
using GymManagement.Application.Common.Interfaces;

namespace GymManagement.Application.Subscriptions.Queries.GetSubscriptions;

public class GetSubscriptioQueryHandler: IRequestHandler<GetSubscriptionQuery, ErrorOr<Subscription>>
{
   private readonly ISubscriptionsRepository _subscriptionsRepository;

   public GetSubscriptioQueryHandler(ISubscriptionsRepository subscriptionsRepository)
   {
      _subscriptionsRepository = subscriptionsRepository;
   }

   public async Task<ErrorOr<Subscription>> Handle(GetSubscriptionQuery request, CancellationToken cancellationToken)
   {
      var subscription = await _subscriptionsRepository.GetByIdAsync(request.Id);
      return subscription is null ? 
         Error.NotFound(description: "Subscription not found") 
         : subscription;
   }
}