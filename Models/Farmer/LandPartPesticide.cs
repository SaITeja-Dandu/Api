using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api.Models.Farmer
{
    public class LandPartPesticide
    {
        [Key]
        public int LandPartPesticideID { get; set; }

        [ForeignKey("LandPart")]
        public int LandPartID { get; set; }

        [ForeignKey("Pesticide")]
        public int PesticideID { get; set; }

        [Required]
        public DateTime DateUsed { get; set; }

        public virtual LandPart LandPart { get; set; }

        public virtual Pesticide Pesticide { get; set; }
    }

}
