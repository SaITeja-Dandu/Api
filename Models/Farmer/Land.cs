using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api.Models.Farmer
{
    public class Land
    {
        [Key]
        public int LandID { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }

        [Required]
        public decimal TotalArea { get; set; }

        [Required]
        public int NumberOfParts { get; set; }

        public bool ReadyForCultivation { get; set; }

        public int DaysToReady { get; set; }

        public virtual User User { get; set; }
    }

}
