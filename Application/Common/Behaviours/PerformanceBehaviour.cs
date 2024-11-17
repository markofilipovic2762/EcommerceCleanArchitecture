﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Common.Behaviours;

public class PerformanceBahaviour<TRequest, TResponse> : IPipelineBehavior<TRequest,TResponse>
    where TRequest: notnull
{
    private readonly Stopwatch _timer;
    private readonly ILogger<TRequest> _logger;
    private readonly IUser _user;
    private readonly IIdentityService _identityService;

    public PerformanceBahaviour(ILogger<TRequest> logger,  IUser user, IIdentityService identityService)
    {
        _timer = new Stopwatch();
        _logger = logger;
        _user = user;
        _identityService = identityService;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _timer.Start();

        var response = await next();

        _timer.Stop();

        var ellapsedMilliseconds = _timer.ElapsedMilliseconds;

        if (ellapsedMilliseconds > 500)
        {
            var requestName = typeof(TRequest).Name;
            var userId = _user.Id ?? string.Empty;
            var userName = string.Empty;

            if (!string.IsNullOrEmpty(userId))
            { 
                userName = await _identityService.GetUserNameAsync(userId);
            }

            _logger.LogWarning("Clean architecture long running request: {Name} ({EllapsedMilliseconds} milliseconds) {@UserId} {@UserName} {@Request}",
                requestName, ellapsedMilliseconds, userId, userName, request );

        }

        return response;
    }
}
