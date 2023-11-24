using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    public class LandArea
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        
    }
}
