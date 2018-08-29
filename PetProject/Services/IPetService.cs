using System.Collections.Generic;
using PetProject.Enums;
using PetProject.Models;

namespace PetProject.Services
{
    public interface IPetService
    {
        List<OwnerDetail> GetAllOwners();
        List<PetNamesByOwnerGender> GetOwnersWithPetType(PetType petType);
    }
}
