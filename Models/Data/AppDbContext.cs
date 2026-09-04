using Microsoft.EntityFrameworkCore;
using WorkoutTrackerApi.Models;

namespace WorkoutTrackerApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    // Veritabanındaki 'WorkoutLogs' tablomuz
    public DbSet<WorkoutLog> WorkoutLogs => Set<WorkoutLog>();
}