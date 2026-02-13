using Microsoft.EntityFrameworkCore;

namespace Web.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<Note> Notes => Set<Note>();
}