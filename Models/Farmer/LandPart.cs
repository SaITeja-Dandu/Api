using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api.Models.Farmer
{
    public class LandPart
    {
        [Key]
        public int LandPartID { get; set; }

        [ForeignKey("Land")]
        public int LandID { get; set; }

        [Required]
        public int PartNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string CropType { get; set; }

        [Required]
        public decimal SeedCost { get; set; }

        [Required]
        public decimal LaborCost { get; set; }

        [Required]
        public DateTime CultivationDate { get; set; }

        public virtual Land Land { get; set; }
    }

}
