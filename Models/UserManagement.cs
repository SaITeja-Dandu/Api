using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Api.Models
{
    public class UserManagement
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string UserName {  get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName {  get; set; }
        [Required]
        [StringLength(50)]
        public String LastName { get; set; }
        [Required]
        [StringLength(12)]
        public string Password { get; set; }
        [Required]
        public int MobileNo { get; set; }
        [Timestamp]
        public DateTime InsertDate { get; set; }
        [Timestamp]
        public DateTime UpdateDate { get; set;}
        public int UpdatedBy { get; set; }

        //public ICollection<Products> Products { get; set; }
    }
}
