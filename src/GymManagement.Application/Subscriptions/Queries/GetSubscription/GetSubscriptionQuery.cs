using GymManagement.Domain.Subscription;
using MediatR;
using ErrorOr;

namespace GymManagement.Application.Subscriptions.Queries.GetSubscriptions;

public record GetSubscriptionQuery(Guid Id) : IRequest<ErrorOr<Subscription>>;