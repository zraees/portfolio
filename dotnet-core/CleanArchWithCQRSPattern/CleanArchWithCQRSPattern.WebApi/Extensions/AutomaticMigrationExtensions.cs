// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.EntityFrameworkCore;

namespace CleanArchWithCQRSPattern.WebApi.Extensions;

public static class AutomaticMigrationExtensions
{
    public static void UseAutomaticMigration<TDbContext>(this IApplicationBuilder applicationBuilder)
        where TDbContext : DbContext
    {
        using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        {
            var context = serviceScope.ServiceProvider.GetService<TDbContext>();
            context.Database.Migrate();
        }
    }
}
