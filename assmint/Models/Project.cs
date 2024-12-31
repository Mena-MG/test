using System.ComponentModel.DataAnnotations;

namespace assmint.Models
{
    public class Project
    {
        [Key]
        public int Projectid { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Name length can't be more than 50.")]
        public string name { get; set; }

        [StringLength(500, ErrorMessage = "Description length can't be more than 200.")]
        public string description { get; set; }

        public DateTime stratdatee { get; set; }
        public DateTime EndDate { get; set; }

        public List<Taske> taskes { get; set; } = new List<Taske>();


    }

}