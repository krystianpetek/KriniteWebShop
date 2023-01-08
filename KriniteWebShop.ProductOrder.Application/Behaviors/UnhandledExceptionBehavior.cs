﻿using MediatR;
using Microsoft.Extensions.Logging;

namespace KriniteWebShop.ProductOrder.Application.Behaviors;
public class UnhandledExceptionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly ILogger<TRequest> _logger;
    public UnhandledExceptionBehavior(ILogger<TRequest> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            return await next();
        }
        catch (Exception ex)
        {
            var requestClassName = typeof(TRequest).Name;
            _logger.LogError(ex, "Application Request: Unhandled exception for Request {requestClassName} {@Request}");
            throw;
        }
    }
}
