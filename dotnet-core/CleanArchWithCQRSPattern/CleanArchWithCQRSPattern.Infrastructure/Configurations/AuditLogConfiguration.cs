// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchWithCQRSPattern.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class AuditLogConfiguration : IEntityTypeConfiguration<AuditLog>
{
    public void Configure(EntityTypeBuilder<AuditLog> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(250);
        builder.Property(x => x.EntityName)
            .IsRequired()
            .HasMaxLength(250);
        builder.Property(x => x.Action)
            .IsRequired()
            .HasMaxLength(250);
    }
}
