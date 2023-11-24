using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Api.Models
{
    public class UserManagement
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       
        public int Id { get; set; }
        [Required (ErrorMessage ="User Name is Required")]
        [StringLength(50)]
        public string UserName {  get; set; }
        [Required(ErrorMessage = "First Name is Required")]
        [StringLength(50)]
        public string FirstName {  get; set; }
        [Required(ErrorMessage = "Last Name is Required")]
        [StringLength(50)]
        public String LastName { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        [StringLength(12)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Mobile Number is Required")]
        public int MobileNo { get; set; }
        [Timestamp]
        public DateTime InsertDate { get; set; }
        [Timestamp]
        public DateTime UpdateDate { get; set;}
        public int UpdatedBy { get; set; }

        //public ICollection<Products> Products { get; set; }
    }
}
