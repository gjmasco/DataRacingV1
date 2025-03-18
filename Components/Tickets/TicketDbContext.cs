using DataRacingV1.Components.Tickets;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public class TicketDbContext : DbContext
{
    public DbSet<TicketEntity> Tickets { get; set; }

    public TicketDbContext(DbContextOptions<TicketDbContext> options)
        : base(options)
    {
    }


}