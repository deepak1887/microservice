using MediatR;

namespace BuildingBlocks.CQRS;

//defining the command types
//1. Command which can return response
//2. Commant which will not return anything
public interface ICommand<out TResponse> : IRequest<TResponse>
{
}

public interface ICommand : ICommand<Unit>
{

}