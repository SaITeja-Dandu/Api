using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    public class UserRole
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public int Id { get; set; }
        [Required]
        public int RoleID { get; set; }
        [Required]
        [MaxLength(50)]
        public string RoleName { get; set; }
        [Required]
        [MaxLength(150)]
        public string RoleDescription { get; set; } = string.Empty;
        [Required]
        public bool IsActived { get; set; }=false;
        [Timestamp]
        public DateTime InsertDate { get; set; }
        [Timestamp]
        public DateTime UpdateDate { get; set; }
        public int UpdatedBy { get; set; }
    }
}
