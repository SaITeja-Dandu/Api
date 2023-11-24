using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Api.Models.Farmer
{
    public class Yield
{
    [Key]
    public int YieldID { get; set; }

    [ForeignKey("LandPart")]
    public int LandPartID { get; set; }

    [Required]
    public decimal YieldAmount { get; set; }

    [Required]
    public decimal SellingCost { get; set; }

    [Required]
    public DateTime YieldDate { get; set; }

    public virtual LandPart LandPart { get; set; }
}

}
