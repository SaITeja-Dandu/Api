using System.ComponentModel.DataAnnotations;

namespace Api.Models.Farmer
{
    public class Pesticide
    {
        [Key]
        public int PesticideID { get; set; }

        [Required]
        [StringLength(50)]
        public string PesticideName { get; set; }

        [Required]
        [StringLength(255)]
        public string SuitableFor { get; set; }

        [Required]
        [StringLength(50)]
        public string Dosage { get; set; }

        [Required]
        public decimal Price { get; set; }
    }

}
