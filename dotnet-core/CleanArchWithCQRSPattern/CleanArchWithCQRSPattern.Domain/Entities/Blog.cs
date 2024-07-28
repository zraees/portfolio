// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace CleanArchWithCQRSPattern.Domain.Entities;

public class Blog : BaseEntity
{
    public required string Name { get; set; }

    public required string Description { get; set; }

    public required string Author { get; set; }
}
