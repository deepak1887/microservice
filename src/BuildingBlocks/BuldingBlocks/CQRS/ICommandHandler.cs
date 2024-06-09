﻿using MediatR;

namespace BuildingBlocks.CQRS;
//Handeling the command, command with response and command without response


public interface ICommandHandler<in TCommand>
    : IRequestHandler<TCommand, Unit> where TCommand : ICommand<Unit>
{
}
public interface ICommandHandler<in TCommand, TResponse>
    : IRequestHandler<TCommand, TResponse> where TCommand : ICommand<TResponse>
    where TResponse : notnull
{
}