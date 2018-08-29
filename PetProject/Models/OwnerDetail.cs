using System.Collections.Generic;
using PetProject.Enums;

namespace PetProject.Models
{
    public class OwnerDetail
    {
        public string Name { get; set; }
        public GenderType Gender { get; set; }
        public int Age { get; set; }

        public List<PetDetail> Pets { get; set; }
    }
}
