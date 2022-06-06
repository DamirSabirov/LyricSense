using Microsoft.EntityFrameworkCore;

namespace LyricSense.Models
{
    public class LyricsContext : DbContext
    {
        public DbSet<Songs> Songs { get; set; }

        public LyricsContext(DbContextOptions<LyricsContext> options) : base(options)
        {

        }
    }
}
