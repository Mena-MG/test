using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace assmint.Models
{
    public class Taske
    {
        [Key]
        public int Taskeid { get; set; }

        
        public Project Projects { get; set; }

        
        public int Projectsid { get; set; }

        [ForeignKey("Projectsid")]
        
        [StringLength(100)]
        public string title { get; set; }

        [StringLength(500)]
        public string descrription { get; set; }

        
        public string statues { get; set; }

        
        public string priority { get; set; }


        public TeamMember TeamMembers { get; set; }

        [Required]
        public int TeamMembersid { get; set; }

        [ForeignKey("TeamMembersid")]
        
        public DateTime deadlin { get; set; }
    }

}
