using Microsoft.EntityFrameworkCore;
using Hubtel.Gov.Track.Api.Models;

namespace Hubtel.Gov.Track.Api.Data
{
    public class AthleteDbContext: DbContext
    {
        public AthleteDbContext(DbContextOptions<AthleteDbContext> options) :
            base(options)
        {

        }
        public DbSet<AthleteModel> Athletes { get; set; }
        public DbSet<Team> Teams { get; set; }
    }
}
