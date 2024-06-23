using System.ComponentModel.DataAnnotations;

namespace Hubtel.Gov.Track.Api.Models
{
    public class AthleteModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Group { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public bool HasMedal { get; set; }
        public int Age { get; set; }

        
    }
    
    
}
