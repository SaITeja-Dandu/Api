using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api.Models.FarmerNew
{
    public class Watering
    {
        [Key]
        public int Id { get; set; }

        public int CultivationId { get; set; }

        [Required]
        public int WateringFrequency { get; set; }

        [Required]
        public int WateringDuration { get; set; }

        [ForeignKey("CultivationId")]
        public virtual Cultivation Cultivation { get; set; }
    }

}
