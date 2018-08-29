using System.Collections.Generic;

namespace PetProject.Models
{
    public class PetNamesByOwnerGender
    {
        public string Gender { get; set; }
        public List<string> PetNames { get; set; }
    }
}
