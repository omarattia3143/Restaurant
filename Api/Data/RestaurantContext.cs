﻿using LinkDev.EgyptianRecipes.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace LinkDev.EgyptianRecipes.Data;

public class RestaurantContext : DbContext
{
    public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options)
    {
        
    }

    public DbSet<Branch> Branches { get; set; }
    public DbSet<Booking> Bookings { get; set; }
}