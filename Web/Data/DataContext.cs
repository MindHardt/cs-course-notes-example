using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Web.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options), IDataProtectionKeyContext
{
    public DbSet<Note> Notes => Set<Note>();
    public DbSet<DataProtectionKey> DataProtectionKeys => Set<DataProtectionKey>();
}