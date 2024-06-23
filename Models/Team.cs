namespace Hubtel.Gov.Track.Api.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<AthleteModel> Athletes { get; set;}

        public Team()
        {
            Athletes = new HashSet<AthleteModel>();
        }

    }
}