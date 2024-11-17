﻿
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Web.Infrastructure;

public static class WebApplicationExtensions
{
    public static RouteGroupBuilder MapGroup(this WebApplication app, EndpointGroupBase endpointGroup)
    {
        var groupName = endpointGroup.GetType().Name;

        return app
            .MapGroup($"/api/{groupName}")
            .WithGroupName(groupName)
            .WithTags(groupName)
            .WithOpenApi();
    }

    public static WebApplication MapEndpoints(this WebApplication app)
    {
        var endpointGroupType = typeof(EndpointGroupBase);

        var assembly = Assembly.GetExecutingAssembly();

        var endpointGroupTypes = assembly.GetExportedTypes()
            .Where(t => t.IsSubclassOf(endpointGroupType));

        foreach (var type in endpointGroupTypes)
        {
            if (Activator.CreateInstance(type) is EndpointGroupBase instance)
            {
                instance.Map(app);
            }
        }

        return app;
    }
}