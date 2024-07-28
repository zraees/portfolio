// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace CleanArchWithCQRSPattern.Domain.Entities;
public class AuditLog : BaseEntity
{
    public required string Email { get; set; }

    public required string EntityName { get; set; }

    public required string Action { get; set; }

    public required DateTime Timestamp { get; set; }

    public required string Changes { get; set; }
}
