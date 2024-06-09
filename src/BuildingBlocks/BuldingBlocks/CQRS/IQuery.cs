using MediatR;

namespace BuildingBlocks.CQRS;
//IQuery when  we want to query something in the application
public interface IQuery<out TResponse> : IRequest<TResponse> where TResponse : notnull
{
}
