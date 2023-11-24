using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api.Models.FarmerNew
{
    public class Reports
    {
        [Key]
        public int Id { get; set; }

        public int HarvestId { get; set; }

        [Required]
        public double TotalCost { get; set; }

        [Required]
        public double GrossProfit { get; set; }

        [Required]
        public double NetProfit { get; set; }

        [ForeignKey("HarvestId")]
        public virtual Harvest Harvest { get; set; }
    }

}
