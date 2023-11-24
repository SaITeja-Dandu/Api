using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api.Models.FarmerNew
{
    public class Cultivation
    {
        [Key]
        public int Id { get; set; }

        public int LandId { get; set; }

        [Required]
        public string PlantType { get; set; }

        [Required]
        public double SeedCost { get; set; }

        [Required]
        public double MaintenanceCost { get; set; }

        [Required]
        public DateTime CultivationDate { get; set; }

        [ForeignKey("LandId")]
        public virtual Land Land { get; set; }
    }

}
