using System.ComponentModel.DataAnnotations.Schema;

namespace assmint.Models.viewmodels
{
    public class listeditviewmodel
    {

        public List<Project>  projects{set; get;}
        public List<TeamMember> TeamMembers{ set; get;}

        public int Taskeid { get; set; }


        public int Projectsid { get; set; }

        
        public string title { get; set; } = string.Empty;
        public string descrription { get; set; } = string.Empty;
        public string statues { get; set; } = string.Empty;
        public string priority { get; set; } = string.Empty;
        public int TeamMembersid { get; set; }
        public DateTime deadlin { get; set; }

    }
}
