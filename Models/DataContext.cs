using Microsoft.EntityFrameworkCore;

public class DataContext : DbContext
{
  public DataContext(DbContextOptions<DataContext> options) : base(options) { }
  public DbSet<MiwPlayer> MiwPlayers { get; set; }
  
  public void AddMiwPlayer(MiwPlayer miwPlayer)
  {
    this.Add(miwPlayer);
    this.SaveChanges();
  }
}