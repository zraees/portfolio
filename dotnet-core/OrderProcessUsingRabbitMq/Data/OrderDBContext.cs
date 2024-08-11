﻿using Microsoft.EntityFrameworkCore;

namespace Publisher.Data;

public class OrderDBContext : DbContext
{
    public OrderDBContext(DbContextOptions<OrderDBContext> dbContextOptions) : base(dbContextOptions)
    {

    }

    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}
