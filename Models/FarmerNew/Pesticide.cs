using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api.Models.FarmerNew
{
    public class Pesticide
    {
        [Key]
        public int Id { get; set; }

        public int CultivationId { get; set; }

        [Required]
        public string PesticideType { get; set; }

        [Required]
        public double Price { get; set; }

        [ForeignKey("CultivationId")]
        public virtual Cultivation Cultivation { get; set; }
    }

}
