using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api.Models.FarmerNew
{
    public class Harvest
    {
        [Key]
        public int Id { get; set; }

        public int CultivationId { get; set; }

        [Required]
        public double Yield { get; set; }

        [Required]
        public double SellingCost { get; set; }

        [ForeignKey("CultivationId")]
        public virtual Cultivation Cultivation { get; set; }
    }

}
