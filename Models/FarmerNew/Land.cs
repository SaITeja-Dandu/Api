using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api.Models.FarmerNew
{
    public class Land
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        [Required]
        public double TotalArea { get; set; }

        [Required]
        public int NumberOfParts { get; set; }

        [Required]
        public bool IsReadyForCultivation { get; set; }

        public int DaysToReady { get; set; }

        [Required]
        public string CultivationType { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }

}
